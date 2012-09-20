﻿using System;
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

public partial class DailyMotivatorArchive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    Session["resultColor"] = "#ff0000";
        //    Session["resultTitle"] = "Members Only";
        //    Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
        //    Session["resultReturnURL"] = "DailyMotivatorArchive.aspx";
        //    Response.Redirect("Result.aspx", true);
        //}

        int iPageNumber = 0;
        if (Request.QueryString["p"] != null)
        {
            iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
        }

        DataLayer dl = new DataLayer();
        int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetDailyMotivatorCount()) / 10m));
        pageNav1.NumPages = iMaxPages;
        pageNav2.NumPages = iMaxPages;

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

        loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Popular Topics</div><div style=\"font-size:15px;\" class=\"contentpanel\"><ul>"));
        DataTable dtTopics = dl.GetFiveTopics();
        foreach (DataRow dr in dtTopics.Rows)
        {
            loggedinpanels.Controls.Add(new LiteralControl("<li><a href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a></li>"));
        }
        loggedinpanels.Controls.Add(new LiteralControl("</ul></div>"));

        DataTable dtDailyMotivators = dl.GetTenDailyMotivatorsBy_Page(iPageNumber);
        foreach (DataRow dr in dtDailyMotivators.Rows)
        {
            string sYouTubeLink = dr.ItemArray[5].ToString();
            if (sYouTubeLink != "No Video.")
            {
                sYouTubeLink = sYouTubeLink.Replace(".com/watch?v=", ".com/v/");
                dailymotivators.InnerHtml += "<center><object width=\"425\" height=\"344\"><param name=\"movie\" value=\"" + sYouTubeLink + "&amp;hl=en_US&amp;fs=1&amp;\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"" + sYouTubeLink + "&amp;hl=en_US&amp;fs=1&amp;\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"425\" height=\"344\"></embed></object></center>";
            }
            dailymotivators.InnerHtml += "<center>" + dr.ItemArray[4].ToString() + "</center><br /><hr /><br />";
        }
    }
}
