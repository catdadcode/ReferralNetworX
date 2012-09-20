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

public partial class AddEditTopic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (Request.QueryString["post"] != null)
        {
            int iPostID = Convert.ToInt32(Request.QueryString["post"]);
            Object[] oPost = dl.GetForumPostBy_PostID(iPostID).Rows[0].ItemArray;

            if (!User.Identity.IsAuthenticated)
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Members Only";
                Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
                Session["resultReturnURL"] = "AddEditPost.aspx?post=" + Request.QueryString["post"];
                Response.Redirect("Result.aspx", true);
            }
            else if ((User.Identity.IsAuthenticated) && (User.Identity.Name.ToLower() != oPost[2].ToString().ToLower()) && (!dl.IsMemberAdmin(User.Identity.Name)))
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Not Authorized";
                Session["resultMessage"] = "You are not authorized to edit this post.";
                Session["resultReturnURL"] = "Boards.aspx";
                Response.Redirect("Result.aspx", true);
            }
            else
            {
                if (!this.IsPostBack)
                {
                    addedit.InnerText = "Edit Post";
                    rteBody.Value = oPost[4].ToString();
                }
            }
        }
        else
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Members Only";
                Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
                Session["resultReturnURL"] = "AddEditPost.aspx?topic=" + Request.QueryString["topic"];
                Response.Redirect("Result.aspx", true);
            }
            addedit.InnerText = "Reply To Topic";
        }

        if (Request.QueryString["rt"] != null)
        {
            int iRTPostID = Convert.ToInt32(Request.QueryString["rt"]);
            DataTable dtRTPost = dl.GetForumPostBy_PostID(iRTPostID);
            replyto.InnerHtml = dtRTPost.Rows[0].ItemArray[4].ToString();
            postedby.InnerHtml = "Posted by <a href=\"Profile.aspx?member=" + dtRTPost.Rows[0].ItemArray[2].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtRTPost.Rows[0].ItemArray[2].ToString()) + "</a> on " + dtRTPost.Rows[0].ItemArray[3].ToString();
        }
        else
        {
            int iRTTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            DataTable dtRTTopic = dl.GetForumTopicBy_TopicID(iRTTopicID);
            replyto.InnerHtml = dtRTTopic.Rows[0].ItemArray[5].ToString();
            postedby.InnerHtml = "Posted by <a href=\"Profile.aspx?member=" + dtRTTopic.Rows[0].ItemArray[2].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtRTTopic.Rows[0].ItemArray[2].ToString()) + "</a> on " + dtRTTopic.Rows[0].ItemArray[3].ToString();
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
        if (Request.QueryString["post"] != null)
        {
            int iPostID = Convert.ToInt32(Request.QueryString["post"]);
            int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            dl.UpdateForumPost(iPostID, rteBody.Value);
            Response.Redirect("Topic.aspx?topic=" + iTopicID.ToString(), true);
        }
        else
        {
            int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            DataTable dtTopic = dl.GetForumTopicBy_TopicID(iTopicID);
            DateTime dtPostedDate = DateTime.Now;
            dl.AddForumPost(iTopicID, User.Identity.Name, dtPostedDate, rteBody.Value);

            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            MailMessage mm;
            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Someone replied to a forum topic.";
            mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " replied to the forum topic titled: " + dtTopic.Rows[0].ItemArray[4].ToString();
            mm.Body += "<br /><a href=\"http://www.referralnetworx.com/Topic.aspx?topic=" + iTopicID.ToString() + "\">Click to view</a>";
            mm.Body += "<br /><br />The post reply is below:<br /><br />" + rteBody.Value;
            SmtpMail.Send(mm);

            if (User.Identity.Name.ToLower() != dtTopic.Rows[0].ItemArray[2].ToString().ToLower())
            {
                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = dtTopic.Rows[0].ItemArray[2].ToString();
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Someone replied to your forum topic.";
                mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " replied to your forum topic titled: " + dtTopic.Rows[0].ItemArray[4].ToString();
                mm.Body += "<br /><a href=\"http://www.referralnetworx.com/Topic.aspx?topic=" + iTopicID.ToString() + "\">Click to view</a>";
                SmtpMail.Send(mm);
            }

            Response.Redirect("Topic.aspx?topic=" + iTopicID.ToString(), true);
        }
    }

    protected void lbtnQuotePost_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["rt"] != null)
        {
            int iRTPostID = Convert.ToInt32(Request.QueryString["rt"]);
            DataLayer dl = new DataLayer();
            DataTable dtRTPost = dl.GetForumPostBy_PostID(iRTPostID);
            rteBody.Value += "<div style=\"background-color:#ddddee; border: solid 2px #000077;padding:10px;\">";
            rteBody.Value += dtRTPost.Rows[0].ItemArray[4].ToString();
            rteBody.Value += "<br /><br /><div style=\"font-size: 12px;font-weight:bold;\">Posted by <a href=\"Profile.aspx?member=" + dtRTPost.Rows[0].ItemArray[2].ToString() + "\">";
            rteBody.Value += dl.GetFullMemberNameBy_Email(dtRTPost.Rows[0].ItemArray[2].ToString());
            rteBody.Value += "</a> on " + dtRTPost.Rows[0].ItemArray[3].ToString() + "</div></div><br />";
        }
        else
        {
            int iRTTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            DataLayer dl = new DataLayer();
            DataTable dtRTTopic = dl.GetForumTopicBy_TopicID(iRTTopicID);
            rteBody.Value += "<div style=\"background-color:#ddddee; border: solid 2px #000077;padding:10px;\">";
            rteBody.Value += dtRTTopic.Rows[0].ItemArray[5].ToString();
            rteBody.Value += "<br /><br /><div style=\"font-size: 12px;font-weight:bold;\">Posted by <a href=\"Profile.aspx?member=" + dtRTTopic.Rows[0].ItemArray[2].ToString() + "\">";
            rteBody.Value += dl.GetFullMemberNameBy_Email(dtRTTopic.Rows[0].ItemArray[2].ToString());
            rteBody.Value += "</a> on " + dtRTTopic.Rows[0].ItemArray[3].ToString() + "</div></div><br />";
        }
    }

    //protected void btnAddImage_Click(object sender, EventArgs e)
    //{
    //    rteBody.Value += "<img src=\"" + tbxImageURL.Text + "\" />";
    //    tbxImageURL.Text = "";
    //}
}
