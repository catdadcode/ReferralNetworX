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
using System.Net.Mail;

public partial class Newsletter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (User.Identity.IsAuthenticated)
        {
            if (!dl.IsMemberAdmin(User.Identity.Name))
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Not Authorized";
                Session["resultMessage"] = "You are not authorized to access this area.";
                Session["resultReturnURL"] = "Default.aspx";
                Response.Redirect("Result.aspx");
            }
        }
        else
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Not Logged In";
            Session["resultMessage"] = "You must log in first.";
            Session["resultReturnURL"] = "Newsletter.aspx";
            Response.Redirect("Result.aspx");
        }
    }


    protected void btnSubmitChanges_Click(object sender, EventArgs e)
    {
        divNewsletterContent.InnerHtml = "Hello <i>[member name here]</i>,<br />" + rteBody.Value.Replace("src=\"", "src=\"http://www.referralnetworx.com");
    }

    protected void SendEmails()
    {
        try
        {
            SmtpClient smtp = new SmtpClient("localhost");
            MailMessage mm;
            DataLayer dl = new DataLayer();
            ArrayList alFail = new ArrayList();

            DataTable dtSendGroup = new DataTable();
            if (ddlSendGroup.SelectedValue == "All Members")
            {
                dtSendGroup = dl.GetAllNewsletterSubscribedMembers();
            }
            else if (ddlSendGroup.SelectedValue == "Non-Members")
            {
                dtSendGroup = dl.GetAllNewsletterSubscribedNonMembers();
            }
            else if (ddlSendGroup.SelectedValue == "Article Authors")
            {
                dtSendGroup = dl.GetArticleAuthorNamesAndEmails();
            }

            foreach (DataRow dr in dtSendGroup.Rows)
            {
                try
                {
                    mm = new MailMessage();
                    mm.IsBodyHtml = true;
                    mm.To.Add(dr.ItemArray[1].ToString());
                    mm.From = new MailAddress("noreply@ReferralNetworX.com");
                    mm.Subject = tbxSubject.Text;
                    mm.Body = "<div style=\"width: 790px; background-color: #333333; padding: 5px; border: solid 1px #333333;\"><img src=\"http://www.referralnetworx.com/images/banner.jpg\" /><img style=\"height: 125px;\" src=\"http://www.referralnetworx.com/MakeThumbnail.aspx?size=125&image=images/networking.jpg\" /></div>";
                    mm.Body += "<div style=\"width: 770px; background-color: #ddeedd; padding: 15px; border: solid 1px #333333;\">";
                    string sName = dr.ItemArray[0].ToString();
                    try
                    {
                        sName = dr.ItemArray[0].ToString().Remove(dr.ItemArray[0].ToString().IndexOf(' '));
                    }
                    catch { }
                    mm.Body += "Hello " + sName + ",<br /><br />";
                    mm.Body += rteBody.Value.Replace("src=\"", "src=\"http://www.referralnetworx.com");
                    mm.Body += "</div>";
                    if (ddlSendGroup.SelectedValue == "Non-Members")
                        mm.Body += "<div style=\"font-size: 12px; border: solid 1px #333333; background-color: #ddeedd; padding: 5px; width: 790px;\">Click <a href=\"http://www.referralnetworx.com/Subscribe.aspx?e=" + dr.ItemArray[1].ToString() + "&type=newsletter\">here</a> to unsubscribe.</div>";
                    int iCount = 0;
                    bool bLoop = true;
                    while (bLoop)
                    {
                        try
                        {
                            smtp.Send(mm);
                            bLoop = false;
                        }
                        catch (Exception ex)
                        {
                            System.Threading.Thread.Sleep(1000);
                            iCount++;
                            if (iCount >= 3)
                            {
                                alFail.Add(dr.ItemArray[0].ToString() + " - FAILED ON SEND");
                                alFail.Add(ex.ToString());
                                bLoop = false;
                            }
                        }
                    }
                }
                catch (Exception ex2)
                {
                    alFail.Add(dr.ItemArray[0].ToString() + " - FAILED BEFORE SEND");
                    alFail.Add(ex2.ToString());
                }
            }

            mm = new MailMessage();
            mm.IsBodyHtml = true;
            mm.To.Add("Alex@CodeTunnel.com");
            mm.From = new MailAddress("NoReply@ReferralNetworX.com");
            mm.Subject = "RNX Newsletter Failure Report";
            mm.Body = "Number of failures: " + Convert.ToString(alFail.Count / 2) + "<br /><br />";
            foreach (string sFail in alFail)
            {
                mm.Body += sFail + "<br /><br />";
            }
            int iCount2 = 0;
            bool bLoop2 = true;
            while (bLoop2)
            {
                try
                {
                    smtp.Send(mm);
                    bLoop2 = false;
                }
                catch
                {
                    iCount2++;
                    if (iCount2 >= 25)
                    {
                        bLoop2 = false;
                    }
                }
            }
        }
        catch (Exception exc)
        {
            SmtpClient smtp = new SmtpClient("localhost");
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.To.Add("Alex@CodeTunnel.com");
            msg.From = new MailAddress("NoReply@ReferralNetworX.com");
            msg.Subject = "Something went terribly wrong.";
            msg.Body = exc.ToString();
            smtp.Send(msg);
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        if (cbxArchive.Checked)
        {
            dl.AddNewsletter(DateTime.Now, tbxSubject.Text, rteBody.Value);
        }

        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(SendEmails));
        t.Start();
        //SendEmails();

        Session["resultColor"] = "#007700";
        Session["resultTitle"] = "Newsletter Sent";
        Session["resultMessage"] = "Newsletter is sending.<br />It could take a few hours depending on the number of subscribers.";
        Session["resultReturnURL"] = "Newsletter.aspx";
        Response.Redirect("Result.aspx", true);
    }
}
