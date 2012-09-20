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
using TagLib;

public partial class PodcastArchive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();


        //Load podcasts
        int iPageNumber = 0;
        if (Request.QueryString["p"] != null)
        {
            iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
        }

        DataTable dtPodcasts = dl.GetFivePodcastsBy_Page(iPageNumber);
        int iPodcastCount = dl.GetPodcastCount();

        int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(iPodcastCount) / 5m));
        pageNav1.NumPages = iMaxPages;
        pageNav2.NumPages = iMaxPages;

        foreach (DataRow dr in dtPodcasts.Rows)
        {
            podcasts.InnerHtml += "<div style=\"min-height:200px;\"><div style=\"text-align:center;float:right;margin:10px;padding:5px;border:solid 1px #000000; border-right:solid 2px #000000; border-bottom:solid 2px #000000; background-color:#ffffcc;\">" + dr["URL"].ToString() + "<br /><span style=\"font-size:12px;\">(" + dr["Size"].ToString() + "mb)</span><br /><a href=\"KRNX/" + dr["URL"].ToString() + "\"><img style=\"border:none;width:100px;\" src=\"images/download_now_button.gif\" /></a><br /><span style=\"font-size:11px;\">(right click > save as)</span></div>";
            podcasts.InnerHtml += "<div style=\"text-align:left;\"><span style=\"font-size:35px;font-family:arial;\">" + dr["Title"].ToString() + "</span></div>";
            podcasts.InnerHtml += "<div style=\"text-align:left;font-size:20px;\">KRNX Episode " + dr["Episode"].ToString() + " <span style=\"font-size:13px;\">(" + dr["Length"].ToString() + " minutes)</span></div>";
            podcasts.InnerHtml += "<div style=\"text-align:left;\">" + Convert.ToDateTime(dr["Date"]).ToString("D") + "</div><br />";
            podcasts.InnerHtml += dr["Description"].ToString() + "<br />";
            //podcasts.InnerHtml += "<i>No Summary.</i><br /><br /><b><a class=\"navlink\" href=\"Podcast.aspx?pid=" + dr["PodcastID"].ToString() + "\">(Read More)</a></b><br />";
            podcasts.InnerHtml += "</div><hr /><br />";
        }


        //Load side bar widgets
        //if (User.Identity.IsAuthenticated)
        //{
        //    loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Featured Member</div><div class=\"contentpanel\">"));
        //    DataTable dtRandomMember = dl.GetRandomMember();
        //    loggedinpanels.Controls.Add(new LiteralControl("<table style=\"width:100%;\"><tr><td style=\"font-size:13px;text-align:center;\"><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=100&image=images/MemberAvatars/" + dtRandomMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\">View Profile</a></td><td style=\"padding-left:5px;font-size:13px;width:100%;\"><b>Name:</b> " + dtRandomMember.Rows[0].ItemArray[2].ToString() + "<br /><br /><b>Location:</b> " + dtRandomMember.Rows[0].ItemArray[17].ToString() + "<br /><br /><b>Business:</b> " + dtRandomMember.Rows[0].ItemArray[8].ToString() + "<br /><br />"));
        //    if (dtRandomMember.Rows[0].ItemArray[6].ToString() != "")
        //    {
        //        loggedinpanels.Controls.Add(new LiteralControl("<center><a href=\"" + dtRandomMember.Rows[0].ItemArray[6].ToString() + "\">Visit Website</a></center>"));
        //    }
        //    loggedinpanels.Controls.Add(new LiteralControl("</td></tr></table></div>"));
        //}

        //DataTable dtMemberAd = dl.GetRandomAd();
        //loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Member Ad</div><div style=\"text-align:center;\" class=\"contentpanel\"><a href=\"" + dtMemberAd.Rows[0].ItemArray[2].ToString() + "\"><img style=\"width:230px; border-width:0px;\" src=\"" + dtMemberAd.Rows[0].ItemArray[1].ToString() + "\" /></a></div>"));

        //if (User.Identity.IsAuthenticated)
        //{
        //    loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Popular Topics</div><div style=\"font-size:15px;\" class=\"contentpanel\"><ul>"));
        //    DataTable dtTopics = dl.GetFiveTopics();
        //    foreach (DataRow dr in dtTopics.Rows)
        //    {
        //        loggedinpanels.Controls.Add(new LiteralControl("<li><a href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a></li>"));
        //    }
        //    loggedinpanels.Controls.Add(new LiteralControl("</ul></div>"));
        //}
    }
}
