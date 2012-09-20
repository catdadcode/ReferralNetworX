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

public partial class Topics : System.Web.UI.Page
{
    LinkButton lbDelete;
    LinkButton lbButton;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["topic"] != null)
        {
            int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
            int iPageNumber = 0;
            if (Request.QueryString["p"] != null)
            {
                iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
            }
            if (!User.Identity.IsAuthenticated)
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Members Only";
                Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
                Session["resultReturnURL"] = "Topic.aspx?topic=" + iTopicID.ToString();
                Response.Redirect("Result.aspx", true);
            }

            DataLayer dl = new DataLayer();
            int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetReplyCountBy_TopicID(iTopicID)) / 15m));
            pageNav1.NumPages = iMaxPages;
            pageNav2.NumPages = iMaxPages;
            DataTable dtTopic = dl.GetForumTopicBy_TopicID(iTopicID);
            DataTable dtBoard = dl.GetForumBoardBy_BoardID(Convert.ToInt32(dtTopic.Rows[0].ItemArray[1]));
            boardtitle.InnerHtml = "<span style=\"font-size:20px;\"><a href=\"Topics.aspx?board=" + dtBoard.Rows[0].ItemArray[0].ToString() + "\" class=\"titlelink\">-= " + dtBoard.Rows[0].ItemArray[1].ToString() + " =-</a></span>";
            topictitle.InnerHtml = dtTopic.Rows[0].ItemArray[4].ToString();
            DataTable dtPosts = dl.GetFifteenPostsBy_Page(iPageNumber, iTopicID);
            DataTable dtMember = dl.GetMemberBy_Email(dtTopic.Rows[0].ItemArray[2].ToString());

            if (iPageNumber == 0)
            {
                posts.Controls.Add(new LiteralControl("<div style=\"background-color:#CCDDCC;padding:10px;\"><table style=\"width:100%;\"><td rowspan=\"2\" style=\"vertical-align:top;text-align:center;font-size:17px;font-weight:bold;padding-right:15px;border-right:solid 2px #333333;width:150px;\"><a style=\"text-decoration:none;\" href=\"Profile.aspx?member=" + dtMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=150&image=images/MemberAvatars/" + dtMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><br /><a href=\"Profile.aspx?member=" + dtMember.Rows[0].ItemArray[0].ToString() + "\">" + dtMember.Rows[0].ItemArray[2].ToString() + "</a></td><td style=\"text-align:left;vertical-align:top;padding-left:15px;\">" + dtTopic.Rows[0].ItemArray[5].ToString() + "<br /><br />----------------------------------<br />" + dtMember.Rows[0].ItemArray[18].ToString() + "<td></tr><tr><td style=\"vertical-align:bottom;padding-left:15px;padding-top:15px;\"><table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;\"><tr><td style=\"text-align:left;vertical-align:bottom;font-size:12px;font-weight:bold;\">" + dtTopic.Rows[0].ItemArray[3].ToString() + "</td><td style=\"text-align:right;vertical-align:bottom;\">"));
                if ((dl.IsMemberAdmin(User.Identity.Name)) || (dl.IsMemberModerator(User.Identity.Name)))
                {
                    if (!Convert.ToBoolean(dtTopic.Rows[0].ItemArray[7]))
                    {
                        lbButton = new LinkButton();
                        lbButton.Text = "Lock";
                        lbButton.Click += new EventHandler(lbButtonLock_Click);
                        posts.Controls.Add(lbButton);
                    }
                    else
                    {
                        lbButton = new LinkButton();
                        lbButton.Text = "Unlock";
                        lbButton.Click += new EventHandler(lbButtonUnLock_Click);
                        posts.Controls.Add(lbButton);
                    }

                    posts.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

                    if (!Convert.ToBoolean(dtTopic.Rows[0].ItemArray[6]))
                    {
                        lbButton = new LinkButton();
                        lbButton.Text = "Sticky";
                        lbButton.Click += new EventHandler(lbButtonSticky_Click);
                        posts.Controls.Add(lbButton);
                    }
                    else
                    {
                        lbButton = new LinkButton();
                        lbButton.Text = "Unsticky";
                        lbButton.Click += new EventHandler(lbButtonUnSticky_Click);
                        posts.Controls.Add(lbButton);
                    }

                    posts.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;&nbsp;"));
                }
                if ((User.Identity.Name.ToLower() == dtTopic.Rows[0].ItemArray[2].ToString().ToLower()) || (dl.IsMemberAdmin(User.Identity.Name)) || (dl.IsMemberModerator(User.Identity.Name)))
                {
                    posts.Controls.Add(new LiteralControl("<a href=\"AddEditTopic.aspx?topic=" + iTopicID.ToString() + "\">Edit</a>&nbsp;&nbsp;&nbsp;"));

                    lbDelete = new LinkButton();
                    lbDelete.Text = "Delete";
                    lbDelete.Click += new EventHandler(lbDeleteTopic_Click);
                    posts.Controls.Add(lbDelete);
                    posts.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                }
                if (!Convert.ToBoolean(dtTopic.Rows[0].ItemArray[7]))
                {
                    posts.Controls.Add(new LiteralControl("<a href=\"AddEditPost.aspx?topic=" + iTopicID.ToString() + "\">Reply</a>"));
                }
                else
                {
                    posts.Controls.Add(new LiteralControl("<span style=\"font-style:italic;color:#ff0000;\">Topic Locked</span>"));
                }
                posts.Controls.Add(new LiteralControl("</td></tr></table></td></tr></table></div>"));
            }

            bool bColored = false;
            if (iPageNumber > 0)
                bColored = true;
            bool bFirst = true;
            foreach (DataRow dr in dtPosts.Rows)
            {
                dtMember = dl.GetMemberBy_Email(dr.ItemArray[2].ToString());
                posts.Controls.Add(new LiteralControl("<div style=\""));
                if (bColored)
                {
                    posts.Controls.Add(new LiteralControl("background-color:#CCDDCC"));
                    bColored = false;
                }
                else
                {
                    posts.Controls.Add(new LiteralControl("background-color:#FFFFFF"));
                    bColored = true;
                }
                posts.Controls.Add(new LiteralControl(";padding:10px;\"><table style=\"width:100%;\"><tr><td rowspan=\"2\" style=\"vertical-align:top;text-align:center;font-size:17px;font-weight:bold;padding-right:15px;border-right:solid 2px #333333;width:150px;\"><a style=\"text-decoration:none;\" href=\"Profile.aspx?member=" + dtMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=150&image=images/MemberAvatars/" + dtMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><br /><a href=\"Profile.aspx?member=" + dtMember.Rows[0].ItemArray[0].ToString() + "\">" + dtMember.Rows[0].ItemArray[2].ToString() + "</a></td><td style=\"text-align:left;vertical-align:top;padding-left:15px;\">" + dr.ItemArray[4].ToString() + "<br /><br />----------------------------------<br />" + dtMember.Rows[0].ItemArray[18].ToString() + "</td></tr><tr><td style=\"vertical-align:bottom;padding-left:15px;padding-top:15px;\"><table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;\"><tr><td style=\"text-align:left;vertical-align:bottom;font-size:12px;font-weight:bold;\">" + dr.ItemArray[3].ToString() + "</td><td style=\"text-align:right;vertical-align:bottom;\">"));
                if ((User.Identity.Name.ToLower() == dr.ItemArray[2].ToString().ToLower()) || (dl.IsMemberAdmin(User.Identity.Name)) || (dl.IsMemberModerator(User.Identity.Name)))
                {
                    posts.Controls.Add(new LiteralControl("<a href=\"AddEditPost.aspx?topic=" + iTopicID.ToString() + "&post=" + dr.ItemArray[0].ToString()));
                    if (!bFirst)
                    {
                        posts.Controls.Add(new LiteralControl("&rt=" + (Convert.ToInt32(dr.ItemArray[0]) - 1).ToString()));
                        bFirst = false;
                    }
                    posts.Controls.Add(new LiteralControl("\">Edit</a>&nbsp;&nbsp;&nbsp;"));
                }
                if ((dl.IsMemberAdmin(User.Identity.Name)) || (dl.IsMemberModerator(User.Identity.Name)))
                {
                    lbDelete = new LinkButton();
                    lbDelete.Text = "Delete";
                    lbDelete.ID = dr.ItemArray[0].ToString();
                    lbDelete.Click += new EventHandler(lbDelete_Click);
                    posts.Controls.Add(lbDelete);
                    posts.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                }
                if (!Convert.ToBoolean(dtTopic.Rows[0].ItemArray[7]))
                {
                    posts.Controls.Add(new LiteralControl("<a href=\"AddEditPost.aspx?topic=" + iTopicID.ToString() + "&rt=" + dr.ItemArray[0].ToString() + "\">Reply</a>"));
                }
                posts.Controls.Add(new LiteralControl("</td></tr></table></td></tr></table></div>"));
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
        else
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Members Only";
            Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
            Session["resultReturnURL"] = "Topic.aspx?topic=" + Request.QueryString["topic"];
            Response.Redirect("Result.aspx", true);
        }
    }

    void lbDelete_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        dl.DeleteForumPost(Convert.ToInt32(((LinkButton)sender).ID));
        Session["resultColor"] = "#009900";
        Session["resultTitle"] = "Post Deleted";
        Session["resultMessage"] = "Post Deleted Successfully";
        Session["resultReturnURL"] = Request.RawUrl;
        Response.Redirect("Result.aspx", true);
    }

    void lbDeleteTopic_Click(object sender, EventArgs e)
    {
        int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
        DataLayer dl = new DataLayer();
        DataTable dtTopic = dl.GetForumTopicBy_TopicID(iTopicID);
        dl.DeleteForumTopic(iTopicID);
        Session["resultColor"] = "#009900";
        Session["resultTitle"] = "Topic Deleted";
        Session["resultMessage"] = "Topic Deleted Successfully";
        Session["resultReturnURL"] = "Topics.aspx?board=" + dtTopic.Rows[0].ItemArray[1].ToString();
        Response.Redirect("Result.aspx", true);

    }

    void lbButtonLock_Click(object sender, EventArgs e)
    {
        int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
        DataLayer dl = new DataLayer();
        dl.LockForumTopic(iTopicID);
        Response.Redirect(Request.RawUrl, true);
    }

    void lbButtonUnLock_Click(object sender, EventArgs e)
    {
        int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
        DataLayer dl = new DataLayer();
        dl.UnlockForumTopic(iTopicID);
        Response.Redirect(Request.RawUrl, true);
    }

    void lbButtonSticky_Click(object sender, EventArgs e)
    {
        int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
        DataLayer dl = new DataLayer();
        dl.StickyForumTopic(iTopicID);
        Response.Redirect(Request.RawUrl, true);
    }

    void lbButtonUnSticky_Click(object sender, EventArgs e)
    {
        int iTopicID = Convert.ToInt32(Request.QueryString["topic"]);
        DataLayer dl = new DataLayer();
        dl.UnstickyForumTopic(iTopicID);
        Response.Redirect(Request.RawUrl, true);
    }
}
