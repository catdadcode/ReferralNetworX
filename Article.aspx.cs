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

public partial class Article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    Session["resultColor"] = "#ff0000";
        //    Session["resultTitle"] = "Members Only";
        //    Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
        //    Session["resultReturnURL"] = "Articles.aspx";
        //    Response.Redirect("Result.aspx", true);
        //}

        int iAID = 0;
        if (Request.QueryString["aid"] == null)
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "No Article";
            Session["resultMessage"] = "No Article Specified";
            Session["resultReturnURL"] = "Articles.aspx";
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            iAID = Convert.ToInt32(Request.QueryString["aid"]);
        }


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

        if (User.Identity.IsAuthenticated)
        {
            loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Popular Topics</div><div style=\"font-size:15px;\" class=\"contentpanel\"><ul>"));
            DataTable dtTopics = dl.GetFiveTopics();
            foreach (DataRow dr in dtTopics.Rows)
            {
                loggedinpanels.Controls.Add(new LiteralControl("<li><a href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a></li>"));
            }
            loggedinpanels.Controls.Add(new LiteralControl("</ul></div>"));
        }

        DataTable dtArticle = dl.GetArticleBy_ArticleID(iAID);
        if (dtArticle.Rows.Count == 0)
        {
            this.Title = "No Article Found";
            articletitle.InnerText = "No Article Found";
        }
        else
        {
            this.Title = dtArticle.Rows[0].ItemArray[2].ToString();
            articletitle.InnerText = dtArticle.Rows[0].ItemArray[2].ToString();
            postedby.InnerHtml = "Posted by <a href=\"Profile.aspx?member=" + dtArticle.Rows[0].ItemArray[4].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtArticle.Rows[0].ItemArray[4].ToString()) + "</a>";
            articlebody.InnerHtml = "<!-- AddThis Button BEGIN --><script type=\"text/javascript\">var addthis_pub=\"chevex\"; var addthis_hide_embed = true;</script><a href=\"http://www.addthis.com/bookmark.php?v=20\" onmouseover=\"return addthis_open(this, '', '[URL]', '[TITLE]')\" onmouseout=\"addthis_close()\" onclick=\"return addthis_sendto()\"><img src=\"http://s7.addthis.com/static/btn/sm-share-en.gif\" width=\"83\" height=\"16\" alt=\"Bookmark and Share\" style=\"border:0;\"/></a><script type=\"text/javascript\" src=\"http://s7.addthis.com/js/200/addthis_widget.js\"></script><!-- AddThis Button END --><br /><br />" + dtArticle.Rows[0].ItemArray[3].ToString();
            DataTable dtMember = dl.GetMemberBy_Email(dtArticle.Rows[0].ItemArray[4].ToString());
            articlebody.InnerHtml += "<br /><br />------------------------------------------------------<br />" + dtMember.Rows[0].ItemArray[18].ToString();
        }
    }
}
