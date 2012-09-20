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

public partial class ContactUs : System.Web.UI.Page
{
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        if (User.Identity.IsAuthenticated)
        {
            loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Featured Member</div><div class=\"contentpanel\">"));
            DataTable dtRandomMember = dl.GetRandomMember();
            loggedinpanels.Controls.Add(new LiteralControl("<table style=\"width:100%;\"><tr><td style=\"font-size:13px;text-align:center;\"><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=100&image=images/MemberAvatars/" + dtRandomMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\">View Profile</a></td><td style=\"padding-left:5px;font-size:13px;width:100%;\"><b>Name:</b> " + dtRandomMember.Rows[0].ItemArray[2].ToString() + "<br /><br /><b>Location:</b> " + dtRandomMember.Rows[0].ItemArray[17].ToString() + "<br /><br /><b>Business:</b> " + dtRandomMember.Rows[0].ItemArray[8].ToString() + "<br /><br />"));
            if (dtRandomMember.Rows[0].ItemArray[6].ToString() != "")
            {
                loggedinpanels.Controls.Add(new LiteralControl("<center><a href=\"" + dtRandomMember.Rows[0].ItemArray[6].ToString() + "\">Visit Website</a></center>"));
            }
            loggedinpanels.Controls.Add(new LiteralControl("</td></tr></table></div>"));
        }

        DataTable dtMemberAd = dl.GetRandomAd();
        loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Member Ad</div><div style=\"text-align:center;\" class=\"contentpanel\"><a href=\"" + dtMemberAd.Rows[0].ItemArray[2].ToString() + "\"><img style=\"width:230px; border-width:0px;\" src=\"" + dtMemberAd.Rows[0].ItemArray[1].ToString() + "\" /></a></div>"));

        if (!this.IsPostBack)
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }
    }

    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        if (tbxCode.Text == Session["CaptchaImageText"].ToString())
        {
            if (this.IsValid)
            {
                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                MailMessage mm;

                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "New message generated from ReferralNetworX.com";
                mm.Body = "New message from " + tbxEmail.Text + ".<br /><br />";
                mm.Body += tbxQuestion.Text.Replace("\n", "<br />").Replace("\r", "");

                SmtpMail.Send(mm);

                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Question Sent";
                Session["resultMessage"] = "Your comment/question has been sent.<br />We will respond within 24 hours.";
                Session["resultReturnURL"] = "ContactUs.aspx";
                Response.Redirect("Result.aspx", true);
            }

        }
        else
        {
            cvInvalidCode.IsValid = false;
        }
    }
}
