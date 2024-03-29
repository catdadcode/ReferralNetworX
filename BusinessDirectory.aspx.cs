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

public partial class BusinessDirectory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    Session["resultColor"] = "#ff0000";
        //    Session["resultTitle"] = "Members Only";
        //    Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
        //    Session["resultReturnURL"] = "BusinessDirectory.aspx";
        //    Response.Redirect("Result.aspx", true);
        //}

        DataLayer dl = new DataLayer();
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

        if (Request.QueryString["c"] == null)
        {
            categories.Visible = true;
            BusinessListings.Visible = false;
        }
        else
        {
            categories.Visible = false;
            BusinessListings.Visible = true;
            PopulateListings(Request.QueryString["c"]);
        }
    }

    protected void PopulateListings(string sCategory)
    {
        businesslistingstitle.InnerText = sCategory;
        int iPageNumber = 0;
        if (Request.QueryString["p"] != null)
            iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
        DataLayer dl = new DataLayer();
        DataTable dtBusinesses = dl.GetFifteenBusinessesBy_BusinessCategory(sCategory, iPageNumber);
        int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetBusinessCountBy_Category(sCategory)) / 15m));

        pageNav1.NumPages = iMaxPages;
        pageNav2.NumPages = iMaxPages;

        foreach (DataRow dr in dtBusinesses.Rows)
        {
            //divBusinessListings.InnerHtml += "<a href=\"Profile.aspx?member=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[1].ToString() + " (" + dr.ItemArray[3].ToString() + ")</a><br />";

            divBusinessListings.Controls.Add(new LiteralControl("<div style=\"background-color:#CCDDCC;border:solid 1px #333333;padding:5px;margin-bottom:10px;\"><table style=\"width:100%;\"><tr><td rowspan=\"2\" style=\"vertical-align:top;text-align:center;font-size:17px;font-weight:bold;padding-right:10px;border-right:solid 1px #333333;width:150px;\"><a style=\"text-decoration:none;\" href=\"Profile.aspx?member=" + dr.ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=150&image=images/BusinessLogos/" + dr.ItemArray[2].ToString() + "\" /></a><br /><br /><a href=\"Profile.aspx?member=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[1].ToString() + "</a></td><td style=\"text-align:left;vertical-align:top;padding-left:10px;\">"));
            divBusinessListings.Controls.Add(new LiteralControl("<b>Location:</b> " + dr.ItemArray[4].ToString() + "<br /><br />"));
            divBusinessListings.Controls.Add(new LiteralControl("<b>Member:</b> " + dr.ItemArray[3].ToString() + "<br /><br />"));
            if (dr.ItemArray[5].ToString().Length > 0)
            {
                divBusinessListings.Controls.Add(new LiteralControl("<b>Website:</b> <a href=\"" + dr.ItemArray[5].ToString() + "\">" + dr.ItemArray[5].ToString() + "</a><br /><br />"));
            }
            divBusinessListings.Controls.Add(new LiteralControl("</td></tr></table></div>"));
        }
    }

    protected void LinkButtonCategory_Click(object sender, EventArgs e)
    {
        string sCategory = ((LinkButton)sender).Text;
        Response.Redirect("BusinessDirectory.aspx?c=" + sCategory, true);
    }
}
