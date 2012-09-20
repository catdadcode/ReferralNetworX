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

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        DataTable dtMemberAd = dl.GetRandomAd();
        loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Member Ad</div><div style=\"text-align:center;\" class=\"contentpanel\"><a href=\"" + dtMemberAd.Rows[0].ItemArray[2].ToString() + "\"><img style=\"width:230px; border-width:0px;\" src=\"" + dtMemberAd.Rows[0].ItemArray[1].ToString() + "\" /></a></div>"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        if (dl.EmailExists(tbxEmail.Text))
        {
            string sPassword = dl.GetMemberBy_Email(tbxEmail.Text).Rows[0].ItemArray[1].ToString();

            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            MailMessage mm;

            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = tbxEmail.Text;
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Your password for ReferralNetworX.com";
            mm.Body = "You requested to have your password sent to you. It is listed below.<br /><br />Username: " + tbxEmail.Text + "<br />Password: " + sPassword;

            SmtpMail.Send(mm);

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Password Sent";
            Session["resultMessage"] = "Your password has been sent to your email.";
            Session["resultReturnURL"] = "Default.aspx";
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Email Not Found";
            Session["resultMessage"] = "The email you provided was not found.";
            Session["resultReturnURL"] = "Default.aspx";
            Response.Redirect("Result.aspx", true);
        }
    }
}
