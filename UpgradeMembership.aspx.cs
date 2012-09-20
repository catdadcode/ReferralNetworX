using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;
using System.Net;
using System.IO;

public partial class UpgradeMembership : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            Response.Redirect("https://www.ReferralNetworX.com/SignUp.aspx", true);
        }

        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("SignUp.aspx", true);
        }

        if (!this.IsPostBack)
        {
            DataLayer dl = new DataLayer();

            ddlPhysicalGroup.Visible = false;
            receiptform.Visible = false;
            upgradeform.Visible = true;
            divExpired.Visible = false;

            DataTable dtPhysicalGroups = dl.GetGroups();
            foreach (DataRow dr in dtPhysicalGroups.Rows)
            {
                ddlPhysicalGroup.Items.Add(dr.ItemArray[0].ToString());
            }

            int iYear = DateTime.Now.Year;
            for (int iCountYear = 0; iCountYear < 10; iCountYear++)
            {
                ddlBillingExpirationYear.Items.Add(Convert.ToString(iYear + iCountYear));
            }

            string sMembershipType = dl.GetMembershipStatusBy_Email(User.Identity.Name);
            if (sMembershipType == "Online")
            {
                ccinfo.Visible = false;
                ddlMembershipType.SelectedIndex = 1;
                ddlMembershipType.Enabled = false;
                ddlMembershipType_SelectedIndexChanged(null, null);
                disclaimer.InnerHtml = "By clicking submit you agree to have your credit card billed in the amount<br />of $29.95 every month, beginning on your next bill date, until cancelled.";
            }
            else if (sMembershipType == "Trial")
            {
                DateTime dtExpireDate = Convert.ToDateTime(dl.GetSubscriptionIDBy_Email(User.Identity.Name));
                if (DateTime.Today >= dtExpireDate.Date)
                {
                    divExpired.Visible = true;
                }
                ddlMembershipType.Enabled = true;
                ccinfo.Visible = true;
            }
            else
            {
                Response.Redirect("EditProfile.aspx", true);
            }
        }
    }

    protected void ddlMembershipType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMembershipType.SelectedIndex == 0)
        {
            ddlPhysicalGroup.Visible = false;
            disclaimer.InnerHtml = "By clicking submit you agree to have your credit card billed in the amount<br />of $9.95 immediately and $9.95 every month thereafter until cancelled.";
        }
        else
        {
            ddlPhysicalGroup.Visible = true;
            disclaimer.InnerHtml = "By clicking submit you agree to have your credit card billed in the amount<br />of $29.95 immediately and $29.95 every month thereafter until cancelled.";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (cbxAgree.Checked)
        {
            DataLayer dl = new DataLayer();

            if ((ddlMembershipType.SelectedIndex == 1) && (ddlPhysicalGroup.SelectedIndex == 0))
            {
                cvPhysicalGroup.IsValid = false;
            }
            else
            {
                string sPrice = "9.95";
                string sMembershipType = "Online";
                if (ddlMembershipType.SelectedIndex == 1)
                {
                    sPrice = "29.95";
                    sMembershipType = "Full";
                }
                string sOldMembershipType = dl.GetMembershipStatusBy_Email(User.Identity.Name);

                if (sOldMembershipType == "Trial")
                {
                    //////////////////////////////////////////////////////////////////////////////////

                    // By default, this sample code is designed to post to our test server for
                    // developer accounts: https://test.authorize.net/gateway/transact.dll
                    // for real accounts (even in test mode), please make sure that you are
                    // posting to: https://secure.authorize.net/gateway/transact.dll
                    String post_url = "https://secure.authorize.net/gateway/transact.dll";

                    Hashtable post_values = new Hashtable();

                    //the API Login ID and Transaction Key must be replaced with valid values
                    post_values.Add("x_login", "8n3jE77yAPK");
                    post_values.Add("x_tran_key", "6x7mz7V7Uw6F238P");

                    post_values.Add("x_delim_data", "TRUE");
                    post_values.Add("x_delim_char", '|');
                    post_values.Add("x_relay_response", "FALSE");

                    post_values.Add("x_type", "AUTH_CAPTURE");
                    post_values.Add("x_method", "CC");
                    post_values.Add("x_card_num", tbxBillingCreditCard.Text);
                    post_values.Add("x_exp_date", ddlBillingExpirationMonth.SelectedValue.PadLeft(2, '0') + ddlBillingExpirationYear.SelectedValue.Remove(0, 2));

                    post_values.Add("x_amount", sPrice);
                    post_values.Add("x_description", "ReferralNetworX.com Membership");

                    post_values.Add("x_first_name", tbxBillingFirstName.Text);
                    post_values.Add("x_last_name", tbxBillingLastName.Text);
                    post_values.Add("x_address", tbxBillingAddress.Text + " " + tbxBillingCity.Text);
                    post_values.Add("x_state", ddlBillingState.SelectedValue);
                    post_values.Add("x_zip", tbxBillingZip.Text);
                    // Additional fields can be added here as outlined in the AIM integration
                    // guide at: http://developer.authorize.net

                    // This section takes the input fields and converts them to the proper format
                    // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
                    String post_string = "";
                    foreach (DictionaryEntry field in post_values)
                    {
                        post_string += field.Key + "=" + field.Value + "&";
                    }
                    post_string = post_string.TrimEnd('&');

                    // create an HttpWebRequest object to communicate with Authorize.net
                    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
                    objRequest.Method = "POST";
                    objRequest.ContentLength = post_string.Length;
                    objRequest.ContentType = "application/x-www-form-urlencoded";

                    // post data is sent as a stream
                    StreamWriter myWriter = null;
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(post_string);
                    myWriter.Close();

                    // returned values are returned as a stream, then read into a string
                    String post_response;
                    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                    using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
                    {
                        post_response = responseStream.ReadToEnd();
                        responseStream.Close();
                    }

                    // the response string is broken into an array
                    // The split character specified here must match the delimiting character specified above
                    String[] response_array = post_response.Split('|');

                    ////////////////////////////////////////////////////////////////////////////////

                    DateTime dtNextBillDate = DateTime.Now;
                    string sSubscriptionID = "Free";
                    if (response_array[0] == "1")
                    {
                        dtNextBillDate = DateTime.Now.AddMonths(1);
                        ARB arb = new ARB();
                        sSubscriptionID = arb.CreateSubscription(tbxBillingCreditCard.Text, ddlBillingExpirationYear.SelectedValue + "-" + ddlBillingExpirationMonth.SelectedValue, tbxBillingFirstName.Text, tbxBillingLastName.Text, User.Identity.Name, sPrice, dtNextBillDate);
                        dl.UpgradeMembership(User.Identity.Name, sSubscriptionID, sMembershipType);
                    }
                    else if (response_array[0] == "2")
                    {
                        CustomValidator3.IsValid = false;
                    }
                    else if (response_array[0] == "3")
                    {
                        CustomValidator3.ErrorMessage = "There was an error in processing your transaction.<br />" + response_array[3];
                        CustomValidator3.IsValid = false;
                    }
                    else if (response_array[0] == "4")
                    {
                        CustomValidator3.ErrorMessage = "Held for review by Authorize.net.";
                        CustomValidator3.IsValid = false;
                    }

                    upgradeform.Visible = false;
                    receiptform.Visible = true;
                    customernextbilldate.InnerText = dtNextBillDate.ToString("D");
                    customernextbilldate2.InnerText = dtNextBillDate.ToString("D");
                    customername.InnerText = tbxBillingLastName.Text + ", " + tbxBillingFirstName.Text;
                    customersubscriptionid.InnerText = sSubscriptionID;
                    customeraddress.InnerText = tbxBillingAddress.Text;
                    customercity.InnerText = tbxBillingCity.Text;
                    customerstate.InnerText = ddlBillingState.SelectedValue;
                    customerzip.InnerText = tbxBillingZip.Text;
                    customerlast4.InnerText = tbxBillingCreditCard.Text.Remove(0, tbxBillingCreditCard.Text.Length - 4);
                    customerexpiration.InnerText = ddlBillingExpirationMonth.SelectedValue.PadLeft(2, '0') + "/" + ddlBillingExpirationYear.SelectedValue;
                    receiptprice.InnerText = sPrice;
                }
                else
                {
                    string sSubscriptionID = dl.GetSubscriptionIDBy_Email(User.Identity.Name);
                    ARB arb = new ARB();
                    bool bSubscriptionComplete = arb.UpdateSubscription(sSubscriptionID, sPrice);
                    if (bSubscriptionComplete)
                    {
                        dl.UpgradeMembership(User.Identity.Name, sSubscriptionID, sMembershipType);
                        Session["resultColor"] = "#007700";
                        Session["resultTitle"] = "Subscription Updated";
                        Session["resultMessage"] = "Thank you for upgrading, we hope you enjoy your new subscription!";
                        Session["resultReturnURL"] = "Default.aspx";
                        Response.Redirect("Result.aspx");
                    }
                    else
                    {
                        Session["resultColor"] = "#ff0000";
                        Session["resultTitle"] = "Error";
                        Session["resultMessage"] = "Something went wrong, your subscription was not updated.";
                        Session["resultReturnURL"] = "Default.aspx";
                        Response.Redirect("Result.aspx");
                    }
                }



                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                MailMessage mm;

                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Someone upgraded their membership on ReferralNetworX.com!";
                mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " upgraded their membership to " + sMembershipType + " status.";
                SmtpMail.Send(mm);

                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = User.Identity.Name;
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Thank you for upgrading!";
                mm.Body = "We are glad to have your business and we are eager to get to know you! If you did not request a membership upgrade on ReferralNetworX.com please contact us by emailing HelpDesk@ReferralNetworX.com";
                SmtpMail.Send(mm);
            }
        }
        else
        {
            CustomValidator2.IsValid = false;
        }
    }
}
