using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Data.SqlClient;

public partial class AddEditTopic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (Request.QueryString["topic"] != null)
        {
            int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            Object[] oTopic = dl.GetForumTopicBy_TopicID(iTopicID).Rows[0].ItemArray;

            if (!User.Identity.IsAuthenticated)
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Members Only";
                Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
                Session["resultReturnURL"] = "AddEditTopic.aspx?topic=" + Request.QueryString["topic"];
                Response.Redirect("Result.aspx", true);
            }
            else if ((User.Identity.IsAuthenticated) && (User.Identity.Name.ToLower() != oTopic[2].ToString().ToLower()) && (!dl.IsMemberAdmin(User.Identity.Name)))
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Not Authorized";
                Session["resultMessage"] = "You are not authorized to edit this post.";
                Session["resultReturnURL"] = "Topic.aspx?topic=" + Request.QueryString["topic"];
                Response.Redirect("Result.aspx", true);
            }
            else
            {
                if (!this.IsPostBack)
                {
                    addedit.InnerText = "Edit Topic";
                    tbxTitle.Text = oTopic[4].ToString();
                    rteBody.Value = oTopic[5].ToString();
                }
                cbxLocked.Visible = false;
                cbxSticky.Visible = false;
            }

        }
        else if ((Request.QueryString["board"] == null) && (Request.QueryString["topic"] == null))
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Error";
            Session["resultMessage"] = "No BoardID was specified for the new topic.";
            Session["resultReturnURL"] = "Topics.aspx";
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            DataTable dtBoard = dl.GetForumBoardBy_BoardID(Convert.ToInt32(Request.QueryString["board"]));
            if (Convert.ToBoolean(dtBoard.Rows[0].ItemArray[3]))
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Locked";
                Session["resultMessage"] = "You cannot creat a new topic because this board is locked.";
                Session["resultReturnURL"] = "Topics.aspx?board=" + dtBoard.Rows[0].ItemArray[0].ToString();
                Response.Redirect("Result.aspx", true);
            }

            addedit.InnerText = "Add New Topic";
            if (!User.Identity.IsAuthenticated)
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Members Only";
                Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
                Session["resultReturnURL"] = "AddEditTopic.aspx?board=" + Request.QueryString["board"];
                Response.Redirect("Result.aspx", true);
            }

            if (!dl.IsMemberAdmin(User.Identity.Name))
            {
                cbxSticky.Visible = false;
                cbxLocked.Visible = false;
            }
            else
            {
                cbxSticky.Visible = true;
                cbxLocked.Visible = true;
            }
        }

        loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Popular Topics</div><div style=\"font-size:15px;\" class=\"contentpanel\"><ul>"));
        DataTable dtTopics = dl.GetFiveTopics();
        foreach (DataRow dr in dtTopics.Rows)
        {
            loggedinpanels.Controls.Add(new LiteralControl("<li><a href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a></li>"));
        }
        loggedinpanels.Controls.Add(new LiteralControl("</ul></div>"));

        loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Featured Member</div><div class=\"contentpanel\">"));
        DataTable dtRandomMember = dl.GetRandomMember();
        loggedinpanels.Controls.Add(new LiteralControl("<table style=\"width:100%;\"><tr><td style=\"font-size:13px;text-align:center;\"><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=100&image=images/MemberAvatars/" + dtRandomMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\">View Profile</a></td><td style=\"padding-left:5px;font-size:13px;width:100%;\"><b>Name:</b> " + dtRandomMember.Rows[0].ItemArray[2].ToString() + "<br /><br /><b>Location:</b> " + dtRandomMember.Rows[0].ItemArray[17].ToString() + "<br /><br /><b>Business:</b> " + dtRandomMember.Rows[0].ItemArray[8].ToString() + "<br /><br />"));
        if (dtRandomMember.Rows[0].ItemArray[6].ToString() != "")
        {
            loggedinpanels.Controls.Add(new LiteralControl("<center><a href=\"" + dtRandomMember.Rows[0].ItemArray[6].ToString() + "\">Visit Website</a></center>"));
        }
        loggedinpanels.Controls.Add(new LiteralControl("</td></tr></table></div>"));

        DataTable dtMemberAd = dl.GetRandomAd();
        loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Member Ad</div><div style=\"text-align:center;\" class=\"contentpanel\"><a href=\"" + dtMemberAd.Rows[0].ItemArray[2].ToString() + "\"><img style=\"width:230px; border-width:0px;\" src=\"" + dtMemberAd.Rows[0].ItemArray[1].ToString() + "\" /></a></div>"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        if (Request.QueryString["topic"] != null)
        {
            int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            dl.UpdateForumTopic(iTopicID, tbxTitle.Text, rteBody.Value);
            Response.Redirect("Topic.aspx?topic=" + iTopicID.ToString(), true);
        }
        else
        {
            int iBoardID = Convert.ToInt32(Request.QueryString["board"]);
            DateTime dtPostedDate = DateTime.Now;
            dl.AddForumTopic(iBoardID, User.Identity.Name, tbxTitle.Text, rteBody.Value, dtPostedDate, cbxSticky.Checked, cbxLocked.Checked);
            SqlCommand sc = new SqlCommand("SELECT TopicID FROM rnxForumTopics WHERE Title=@Title AND Date=@Date");
            sc.Parameters.Add(new SqlParameter("Title", tbxTitle.Text));
            sc.Parameters.Add(new SqlParameter("Date", dtPostedDate));
            DataSet ds = dl.CustomQuery(sc);

            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create("http://tinyurl.com/api-create.php?url=http://www.ReferralNetworX.com/Topic.aspx?topic=" + ds.Tables[0].Rows[0].ItemArray[0].ToString());
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sURL = objReader.ReadToEnd();

                Yedda.Twitter t = new Yedda.Twitter();
                t.Update("ReferralNetworX", "1million!", "New RNX Forum Topic: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("Chevex", "Ch3vyF0rd!", "New RNX Forum Topic: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("WALTatRNX", "robinwalt98", "New RNX Forum Topic: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
            }
            catch
            {

            }

            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            MailMessage mm;
            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Someone posted a new forum topic.";
            mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " posted a new forum topic titled: " + tbxTitle.Text;
            mm.Body += "<br /><a href=\"http://www.referralnetworx.com/Topic.aspx?topic=" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "\">Click to view</a>";
            mm.Body += "<br /><br />The post is below:<br /><br />" + rteBody.Value;
            SmtpMail.Send(mm);

            Response.Redirect("Topic.aspx?topic=" + ds.Tables[0].Rows[0].ItemArray[0].ToString(), true);
        }
    }

    //protected void btnAddImage_Click(object sender, EventArgs e)
    //{
    //    rteBody.Value += "<img src=\"" + tbxImageURL.Text + "\" />";
    //    tbxImageURL.Text = "";
    //}
}
