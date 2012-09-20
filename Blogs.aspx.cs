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

public partial class Blogs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    Session["resultColor"] = "#ff0000";
        //    Session["resultTitle"] = "Members Only";
        //    Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
        //    Session["resultReturnURL"] = "Blogs.aspx";
        //    Response.Redirect("Result.aspx", true);
        //}

        int iPageNumber = 0;
        if (Request.QueryString["p"] != null)
        {
            iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
        }

        DataLayer dl = new DataLayer();
        int iBlogCount;

        DataTable dtBlogs;
        if (User.Identity.IsAuthenticated)
        {
            dtBlogs = dl.GetFiveBlogsBy_Page(iPageNumber, "Members Only");
            iBlogCount = dl.GetBlogCount("Members Only");
        }
        else
        {
            dtBlogs = dl.GetFiveBlogsBy_Page(iPageNumber, "Everyone");
            iBlogCount = dl.GetBlogCount("Everyone");
        }

        int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(iBlogCount) / 5m));
        pageNav1.NumPages = iMaxPages;
        pageNav2.NumPages = iMaxPages;

        foreach (DataRow dr in dtBlogs.Rows)
        {
            if (dr.ItemArray[5].ToString() == "Members Only")
            {
                blogs.InnerHtml += "<div style=\"background-color:#ddddff; padding:5px;\"><div style=\"text-align:center;\">-= <i>Members Only Blog</i> =-</div><br />";
            }
            else
            {
                blogs.InnerHtml += "<div>";
            }
            blogs.InnerHtml += "<div style=\"text-align:left;font-size:35px;font-family:arial;\"><a class=\"navlink\" href=\"Blog.aspx?bid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a></div>";
            blogs.InnerHtml += "<div style=\"text-align:left;\">Posted by <a href=\"Profile.aspx?member=" + dr.ItemArray[1].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dr.ItemArray[1].ToString()) + "</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" + Convert.ToDateTime(dr.ItemArray[2]).ToString("D") + "&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" + dl.GetBlogCommentCount(Convert.ToInt32(dr.ItemArray[0])) + " Comment(s)</div><br />";
            string sBody = dr.ItemArray[4].ToString();
            if (sBody.Contains('~'))
            {
                sBody = sBody.Remove(sBody.IndexOf('~'));
                blogs.InnerHtml += "<div style=\"text-align:left;\"><table style=\"width:100%;\"><tr><td>" + dr.ItemArray[4].ToString().Remove(dr.ItemArray[4].ToString().IndexOf('~')) + "<br /><br /><b><a class=\"navlink\" href=\"Blog.aspx?bid=" + dr.ItemArray[0].ToString() + "\">(Read More)</a></b><br /></td></tr></table></div>";
            }
            else
            {
                blogs.InnerHtml += "<div><i>No Summary.</i><br /><br /><b><a class=\"navlink\" href=\"Blog.aspx?bid=" + dr.ItemArray[0].ToString() + "\">(Read More)</a></b><br /></div>";
            }
            blogs.InnerHtml += "</div><hr /><br />";
        }

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
    }
}
