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

public partial class ViewNewsletter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    Session["resultColor"] = "#ff0000";
        //    Session["resultTitle"] = "Members Only";
        //    Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
        //    Session["resultReturnURL"] = "NewsletterArchive.aspx";
        //    Response.Redirect("Result.aspx", true);
        //}

        int iNID = 0;
        if (Request.QueryString["nid"] == null)
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "No Newsletter";
            Session["resultMessage"] = "No Newsletter Specified";
            Session["resultReturnURL"] = "NewsletterArchive.aspx";
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            iNID = Convert.ToInt32(Request.QueryString["nid"]);
        }

        DataLayer dl = new DataLayer();
        DataTable dtNewsletter = dl.GetNewsletterBy_NewsletterID(iNID);
        this.Title = dtNewsletter.Rows[0].ItemArray[2].ToString();
        divNewsletterTitle.InnerText = dtNewsletter.Rows[0].ItemArray[2].ToString();
        divNewsletterContent.InnerHtml = dtNewsletter.Rows[0].ItemArray[3].ToString();
    }
}
