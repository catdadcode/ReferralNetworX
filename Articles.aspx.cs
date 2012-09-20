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

public partial class Articles : System.Web.UI.Page
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

        DataLayer dl = new DataLayer();

        int iPageNumber = 0;
        if (Request.QueryString["p"] != null)
        {
            iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
        }

        DataTable dtParentCategories = dl.GetParentCategories();

        foreach (DataRow drParent in dtParentCategories.Rows)
        {
            categorypanel.InnerHtml += "<div class=\"contenttitle\">" + drParent.ItemArray[0].ToString() + "</div>";
            categorypanel.InnerHtml += "<div class=\"contentpanel\">";
            DataTable dtSubCategories = dl.GetCategoriesBy_ParentCategory(drParent.ItemArray[0].ToString());

            categorypanel.InnerHtml += "<table style=\"width:100%;font-size:17px;\"><tr>";
            int iCol = 0;
            foreach (DataRow dr in dtSubCategories.Rows)
            {
                int iNumArticles = dl.GetArticleCountBy_Category(dr.ItemArray[0].ToString());
                categorypanel.InnerHtml += "<td style=\"text-align:center;\"><a href=\"Articles.aspx?category=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[0].ToString() + "</a> (" + iNumArticles.ToString() + ")</td>";
                iCol++;
                if (iCol == 3)
                {
                    categorypanel.InnerHtml += "</tr><tr>";
                    iCol = 0;
                }
            }
            categorypanel.InnerHtml += "</tr></table>";

            categorypanel.InnerHtml += "</div>";
        }

        if (Request.QueryString["category"] == null)
        {
            categorypanel.Visible = true;
            articlepanel.Visible = false;
        }
        else
        {
            string sCategory = Request.QueryString["category"];
            categorypanel.Visible = true; //false;
            articlepanel.Visible = true;

            category.InnerText = sCategory;

            int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetArticleCountBy_Category(sCategory)) / 15m));
            pageNav1.NumPages = iMaxPages;
            pageNav2.NumPages = iMaxPages;



            DataTable dtArticles = dl.GetFifteenArticlesBy_Category(sCategory, iPageNumber);
            if (dtArticles.Rows.Count == 0)
            {
                articles.InnerHtml += "<center>There are no articles in this category.</center>";
            }
            else
            {
                foreach (DataRow dr in dtArticles.Rows)
                {
                    articles.InnerHtml += "<a class=\"navlink\" href=\"Article.aspx?aid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[2].ToString() + "</a><br /><span style=\"font-size:14px;\">Posted by <a href=\"Profile.aspx?member=" + dr.ItemArray[4].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dr.ItemArray[4].ToString()) + "</a></span><hr />";
                }
            }
        }

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
    }
}
