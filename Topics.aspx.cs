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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["board"] != null)
        {
            int iBoardID = Convert.ToInt32(Request.QueryString["board"]);
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
                Session["resultReturnURL"] = "Topics.aspx?board=" + iBoardID.ToString();
                Response.Redirect("Result.aspx", true);
            }

            hlAddTopic.NavigateUrl = "AddEditTopic.aspx?board=" + iBoardID.ToString();
            hlAddTopic2.NavigateUrl = "AddEditTopic.aspx?board=" + iBoardID.ToString();
            DataLayer dl = new DataLayer();
            int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetTopicCountBy_BoardID(iBoardID)) / 15m));
            pageNav1.NumPages = iMaxPages;
            pageNav2.NumPages = iMaxPages;
            DataTable dtBoard = dl.GetForumBoardBy_BoardID(iBoardID);
            boardtitle.InnerText = dtBoard.Rows[0].ItemArray[1].ToString();
            this.Title = dtBoard.Rows[0].ItemArray[1].ToString();
            if (Convert.ToBoolean(dtBoard.Rows[0].ItemArray[3]))
            {
                hlAddTopic.Visible = false;
                hlAddTopic2.Visible = false;
            }
            DataTable dtTopics = dl.GetFifteenTopicsBy_Page(iPageNumber, iBoardID);
            DataTable dtStickyTopics = dl.GetStickyTopics(iBoardID);

            if (dtStickyTopics.Rows.Count > 0)
            {
                stickypanel.Visible = true;
            }
            else
            {
                stickypanel.Visible = false;
            }

            bool bColored = true;
            foreach (DataRow dr in dtStickyTopics.Rows)
            {
                stickytopics.Controls.Add(new LiteralControl("<div style=\"background-color:"));
                if (bColored)
                {
                    stickytopics.Controls.Add(new LiteralControl("#CCDDCC"));
                    bColored = false;
                }
                else
                {
                    stickytopics.Controls.Add(new LiteralControl("#ffffff"));
                    bColored = true;
                }
                int iNumReplies = dl.GetReplyCountBy_TopicID(Convert.ToInt32(dr.ItemArray[0]));
                stickytopics.Controls.Add(new LiteralControl(";padding:10px;\"><a style=\"font-size:20px;\" href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a><b>&nbsp;&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;&nbsp;" + iNumReplies.ToString() + " replies</b><br /><div style=\"font-size:13px;\">Posted by <a href=\"Profile.aspx?member=" + dr.ItemArray[2].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dr.ItemArray[2].ToString()) + "</a> on " + dr.ItemArray[3].ToString()));
                if (iNumReplies > 0)
                {
                    DataTable dtLastReply = dl.GetLastTopicReplyBy_TopicID(Convert.ToInt32(dr.ItemArray[0]));
                    stickytopics.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;&nbsp;last reply by <a href=\"Profile.aspx?member=" + dtLastReply.Rows[0].ItemArray[0].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtLastReply.Rows[0].ItemArray[0].ToString()) + "</a> on " + dtLastReply.Rows[0].ItemArray[1].ToString()));
                }
                stickytopics.Controls.Add(new LiteralControl("</div></div>"));
            }

            if (dtTopics.Rows.Count == 0)
            {
                if (Convert.ToBoolean(dtBoard.Rows[0].ItemArray[3]))
                {
                    topics.Controls.Add(new LiteralControl("<div style=\"padding:10px;background-color:#CCDDCC;font-size:20px;\">No Topics.</div>"));
                }
                else
                {
                    topics.Controls.Add(new LiteralControl("<div style=\"padding:10px;background-color:#CCDDCC;font-size:20px;\">No Topics. <a href=\"AddEditTopic.aspx?board=" + iBoardID.ToString() + "\">Click here</a> to create a topic of your own.</div>"));
                }
            }

            bColored = true;
            foreach (DataRow dr in dtTopics.Rows)
            {
                topics.Controls.Add(new LiteralControl("<div style=\"background-color:"));
                if (bColored)
                {
                    topics.Controls.Add(new LiteralControl("#CCDDCC"));
                    bColored = false;
                }
                else
                {
                    topics.Controls.Add(new LiteralControl("#ffffff"));
                    bColored = true;
                }
                int iNumReplies = dl.GetReplyCountBy_TopicID(Convert.ToInt32(dr.ItemArray[0]));
                topics.Controls.Add(new LiteralControl(";padding:10px;\"><a style=\"font-size:20px;\" href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a><b>&nbsp;&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;&nbsp;" + iNumReplies.ToString() + " replies</b><br /><div style=\"font-size:13px;\">Posted by <a href=\"Profile.aspx?member=" + dr.ItemArray[2].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dr.ItemArray[2].ToString()) + "</a> on " + dr.ItemArray[3].ToString()));
                if (iNumReplies > 0)
                {
                    DataTable dtLastReply = dl.GetLastTopicReplyBy_TopicID(Convert.ToInt32(dr.ItemArray[0]));
                    topics.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;&nbsp;last reply by <a href=\"Profile.aspx?member=" + dtLastReply.Rows[0].ItemArray[0].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtLastReply.Rows[0].ItemArray[0].ToString()) + "</a> on " + dtLastReply.Rows[0].ItemArray[1].ToString()));
                }
                topics.Controls.Add(new LiteralControl("</div></div>"));
            }

            loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Popular Topics</div><div style=\"font-size:15px;\" class=\"contentpanel\"><ul>"));
            DataTable dtTopics2 = dl.GetFiveTopics();
            foreach (DataRow dr in dtTopics2.Rows)
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
            Session["resultReturnURL"] = "Boards.aspx";
            Response.Redirect("Result.aspx", true);
        }
    }
}
