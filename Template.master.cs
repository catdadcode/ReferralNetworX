using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Template : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer != null)
        {
            string sReferringAddress = Request.UrlReferrer.AbsoluteUri;
            if ((sReferringAddress.ToLower().Contains("encyclopediadramatica.com")) || (sReferringAddress.ToLower().Contains("anonym.to")) || (sReferringAddress.ToLower().Contains("antirefer.com")) || (sReferringAddress.ToLower().Contains("/?http")))
            {
                Response.Redirect(sReferringAddress, true);
            }
        }

        Page.Title += " | ReferralNetworX.com";

        DataLayer dl = new DataLayer();

        if (Request.QueryString["bg"] != null)
        {
            dynamicstyle.InnerHtml = "<style>body{background-image:url(\"" + Request.QueryString["bg"] + "\");}</style>";
        }
        else
        {
            if (Request.QueryString["color"] != null)
            {
                dynamicstyle.InnerHtml = "<style>body{background-color:" + Request.QueryString["color"] + "; background-image: none;}</style>";
            }
        }

        if (Page.User.Identity.IsAuthenticated)
        {
            loginpanel.Visible = false;
            memberpanel.Visible = true;
            membername.InnerHtml = "<a class=\"titlelink\" href=\"Profile.aspx\">" + dl.GetMemberNameBy_Email(Page.User.Identity.Name) + "</a>";
            if (dl.IsMemberAdmin(Page.User.Identity.Name))
            {
                adminpanel.Visible = true;
                divPostBlog.Visible = false;
                divPostArticle.Visible = false;
                archivespanel.Visible = true;
                directorypanel.Visible = true;
                nonmemberdirectorypanel.Visible = false;
                MemberToolsPanel.Visible = true;
            }
            else
            {
                adminpanel.Visible = false;
                archivespanel.Visible = true;
                directorypanel.Visible = true;
                nonmemberdirectorypanel.Visible = false;
                MemberToolsPanel.Visible = true;
                if (dl.CanMemberPostBlog(Page.User.Identity.Name))
                {
                    divPostBlog.Visible = true;
                }
                else
                {
                    divPostBlog.Visible = false;
                }

                if (dl.MemberArticleColumn(Page.User.Identity.Name) != "None")
                {
                    divPostArticle.Visible = true;
                }
                else
                {
                    divPostArticle.Visible = false;
                }
            }
        }
        else
        {
            adminpanel.Visible = false;
            memberpanel.Visible = false;
            loginpanel.Visible = true;
            archivespanel.Visible = false;
            directorypanel.Visible = false;
            nonmemberdirectorypanel.Visible = true;
            MemberToolsPanel.Visible = false;
        }

        if (!this.IsPostBack)
        {
            failfield.Visible = false;
        }

        if (Request.Cookies["ExcludeAnalytics"] != null)
        {
            analytics.Visible = false;
        }
        else
        {
            analytics.Visible = true;
        }
    }

    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
        string sEmail = tbxLoginEmail.Text;
        DataLayer dl = new DataLayer();
        if (dl.EmailExists(sEmail))
        {
            string sPassword = dl.GetMemberPasswordBy_Email(sEmail);
            string sName = dl.GetMemberNameBy_Email(sEmail);
            if (tbxLoginPassword.Text == sPassword)
            {
                FormsAuthentication.SetAuthCookie(sEmail, cbxRememberMe.Checked);
                if (sEmail.ToUpper() != "ALEX@REFERRALNETWORX.COM")
                {
                    dl.UpdateLastLogin(sEmail);
                }
                loginpanel.Visible = false;
                memberpanel.Visible = true;
                archivespanel.Visible = true;
                directorypanel.Visible = true;
                nonmemberdirectorypanel.Visible = false;
                membername.InnerHtml = "<a class=\"titlelink\" href=\"Profile.aspx\">" + sName + "</a>";
                if (dl.IsMemberAdmin(sEmail))
                {
                    adminpanel.Visible = true;
                }
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                failfield.Visible = true;
                failfield.InnerText = "Invalid email or password.";
            }
        }
        else
        {
            failfield.Visible = true;
            failfield.InnerText = "Invalid email or password.";
        }
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        memberpanel.Visible = false;
        adminpanel.Visible = false;
        loginpanel.Visible = true;
        directorypanel.Visible = false;
        nonmemberdirectorypanel.Visible = true;
        Response.Redirect(Request.RawUrl);
    }
}
