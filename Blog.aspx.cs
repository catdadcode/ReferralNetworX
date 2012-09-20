using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Blog : System.Web.UI.Page
{
    LinkButton lbDelete;
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }

        if (!User.Identity.IsAuthenticated)
        {
            anonymousbox.Visible = true;
            anonymousbox2.Visible = true;
            cbxThumbsUp.Visible = false;
        }
        else
        {
            anonymousbox.Visible = false;
            anonymousbox2.Visible = false;
        }

        int iPageNumber = 0;
        if (Request.QueryString["p"] != null)
        {
            iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
        }

        int iBlogID = 0;
        if (Request.QueryString["bid"] == null)
        {
            Response.Redirect("Blogs.aspx", true);
        }
        else
        {
            iBlogID = Convert.ToInt32(Request.QueryString["bid"]);
        }

        DataLayer dl = new DataLayer();
        int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetBlogCommentCount(iBlogID)) / 15m));
        pageNav1.NumPages = iMaxPages;
        pageNav2.NumPages = iMaxPages;
        DataTable dtBlog = dl.GetBlogBy_BlogID(iBlogID);
        if (dtBlog.Rows.Count == 0)
        {
            this.Title = "No Blog Found";
            blogtitle.InnerText = "No Blog Found";
            addcomment.Visible = false;
        }
        else
        {
            if (dtBlog.Rows[0].ItemArray[5].ToString() == "Members Only")
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Session["resultColor"] = "#ff0000";
                    Session["resultTitle"] = "Members Only";
                    Session["resultMessage"] = "This is a members only blog.<br />You must log in first.";
                    Session["resultReturnURL"] = "Blogs.aspx";
                    Response.Redirect("Result.aspx", true);
                }
            }

            DataTable dtComments = dl.GetFifteenBlogCommentsBy_Page(iPageNumber, iBlogID);

            if (User.Identity.IsAuthenticated)
            {
                if (dl.GaveBlogThumbsUpAlready(iBlogID, User.Identity.Name) || (User.Identity.Name.ToLower() == dtBlog.Rows[0].ItemArray[1].ToString().ToLower()))
                {
                    cbxThumbsUp.Visible = false;
                }
                else
                {
                    cbxThumbsUp.Visible = true;
                }
            }

            this.Title = dtBlog.Rows[0].ItemArray[3].ToString();
            blogtitle.InnerText = dtBlog.Rows[0].ItemArray[3].ToString();
            postedby.InnerHtml = "Posted by <a href=\"Profile.aspx?member=" + dtBlog.Rows[0].ItemArray[1].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtBlog.Rows[0].ItemArray[1].ToString()) + "</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" + Convert.ToDateTime(dtBlog.Rows[0].ItemArray[2]).ToString("D") + "&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" + dl.GetBlogCommentCount(Convert.ToInt32(dtBlog.Rows[0].ItemArray[0])) + " Comment(s)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<!-- AddThis Button BEGIN --><script type=\"text/javascript\">var addthis_pub=\"chevex\"; var addthis_hide_embed = true;</script><a href=\"http://www.addthis.com/bookmark.php?v=20\" onmouseover=\"return addthis_open(this, '', '[URL]', '[TITLE]')\" onmouseout=\"addthis_close()\" onclick=\"return addthis_sendto()\"><img src=\"http://s7.addthis.com/static/btn/sm-share-en.gif\" width=\"83\" height=\"16\" alt=\"Bookmark and Share\" style=\"border:0;\"/></a><script type=\"text/javascript\" src=\"http://s7.addthis.com/js/200/addthis_widget.js\"></script><!-- AddThis Button END -->";
            blogcontent.InnerHtml = dtBlog.Rows[0].ItemArray[4].ToString().Replace("~", "") + "<br /><br /><b>" + dl.GetBlogThumbsUpCount(iBlogID).ToString() + " Thumbs Up!</b>";

            bool bColored = true;
            foreach (DataRow dr in dtComments.Rows)
            {
                string sEmail = "";
                string sLink = "";
                string sAvatar = "";
                string sName = "";
                string sSignature = "";

                if (dr.ItemArray[1].ToString().StartsWith("ANON"))
                {
                    string[] sSplit = dr.ItemArray[1].ToString().Split('|');
                    sLink = sSplit[2];
                    sAvatar = "images/MemberAvatars/no_avatar.gif";
                    sName = sSplit[1];
                }
                else
                {
                    DataTable dtMember = dl.GetMemberBy_Email(dr.ItemArray[1].ToString());

                    sEmail = dtMember.Rows[0].ItemArray[0].ToString();
                    sLink = "Profile.aspx?member=" + sEmail;
                    sAvatar = "images/MemberAvatars/" + dtMember.Rows[0].ItemArray[3].ToString();
                    sName = dtMember.Rows[0].ItemArray[2].ToString();
                    sSignature = dtMember.Rows[0].ItemArray[18].ToString();
                }

                comments.Controls.Add(new LiteralControl("<div style=\""));
                if (bColored)
                {
                    comments.Controls.Add(new LiteralControl("background-color:#CCDDCC"));
                    bColored = false;
                }
                else
                {
                    comments.Controls.Add(new LiteralControl("background-color:#FFFFFF"));
                    bColored = true;
                }
                comments.Controls.Add(new LiteralControl(";padding:10px;\"><table style=\"width:100%;\"><tr><td rowspan=\"2\" style=\"vertical-align:top;text-align:center;font-size:17px;font-weight:bold;padding-right:15px;border-right:solid 2px #333333;width:150px;\">"));
                if (sLink != "")
                {
                    comments.Controls.Add(new LiteralControl("<a style=\"text-decoration:none;\" href=\"" + sLink + "\">"));
                }
                comments.Controls.Add(new LiteralControl("<img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=150&image=" + sAvatar + "\" />"));
                if (sLink != "")
                {
                    comments.Controls.Add(new LiteralControl("</a>"));
                }
                comments.Controls.Add(new LiteralControl("<br /><br />"));
                if (sLink != "")
                {
                    comments.Controls.Add(new LiteralControl("<a href=\"" + sLink + "\">"));
                }
                comments.Controls.Add(new LiteralControl(sName));
                if (sLink != "")
                {
                    comments.Controls.Add(new LiteralControl("</a>"));
                }
                if (dr.ItemArray[1].ToString().StartsWith("ANON"))
                {
                    comments.Controls.Add(new LiteralControl("<br />(guest)"));
                }
                comments.Controls.Add(new LiteralControl("</td><td style=\"text-align:left;vertical-align:top;padding-left:15px;\">" + dr.ItemArray[3].ToString().Replace("\r", "<br />").Replace("\n", "") + "<br /><br />----------------------------------<br />" + sSignature + "</td></tr><tr><td style=\"vertical-align:bottom;padding-left:15px;padding-top:15px;\"><table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;\"><tr><td style=\"text-align:left;vertical-align:bottom;font-size:12px;font-weight:bold;\">" + dr.ItemArray[2].ToString()));
                if (Convert.ToBoolean(dr.ItemArray[5]))
                    comments.Controls.Add(new LiteralControl("&nbsp&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<img style=\"width:25px;\" src=\"images/ThumbsUp.png\" />"));
                comments.Controls.Add(new LiteralControl("</td><td style=\"text-align:right;vertical-align:bottom;\">"));
                if (User.Identity.IsAuthenticated)
                {
                    if ((User.Identity.Name.ToLower() == dr.ItemArray[1].ToString().ToLower()) || (dl.IsMemberAdmin(User.Identity.Name)) || (dl.IsMemberModerator(User.Identity.Name)))
                    {
                        lbDelete = new LinkButton();
                        lbDelete.Text = "Delete Comment";
                        lbDelete.ID = dr.ItemArray[0].ToString();
                        lbDelete.Click += new EventHandler(lbDelete_Click);
                        lbDelete.CausesValidation = false;
                        comments.Controls.Add(lbDelete);
                    }
                }
                comments.Controls.Add(new LiteralControl("</td></tr></table></td></tr></table></div>"));
            }
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

    void lbDelete_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        dl.DeleteComment(Convert.ToInt32(((LinkButton)sender).ID));
        Session["resultColor"] = "#009900";
        Session["resultTitle"] = "Comment Deleted";
        Session["resultMessage"] = "Comment Deleted Successfully";
        Session["resultReturnURL"] = Request.RawUrl;
        Response.Redirect("Result.aspx", true);
    }

    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        if ((User.Identity.IsAuthenticated) || (tbxCode.Text == Session["CaptchaImageText"].ToString()))
        {
            int iBlogID = Convert.ToInt32(Request.QueryString["bid"]);
            DataLayer dl = new DataLayer();
            DataTable dtBlog = dl.GetBlogBy_BlogID(iBlogID);
            string sName = "";
            if (User.Identity.IsAuthenticated)
            {
                dl.AddComment(User.Identity.Name, DateTime.Now, tbxAddComment.Text, "Blog", cbxThumbsUp.Checked, iBlogID, "");
                sName = dl.GetFullMemberNameBy_Email(User.Identity.Name);
            }
            else
            {
                dl.AddComment("ANON|" + tbxAnonymousName.Text + "|" + tbxAnonymousWebsite.Text, DateTime.Now, tbxAddComment.Text, "Blog", false, iBlogID, "");
                sName = tbxAnonymousName.Text;
            }

            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            MailMessage mm;
            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Someone posted a blog comment.";
            mm.Body = sName + " posted a comment on a blog: " + dtBlog.Rows[0].ItemArray[3].ToString();
            mm.Body += "<br /><br />Here is the comment:<br />" + tbxAddComment.Text;
            mm.Body += "<br /><br /><a href=\"http://www.referralnetworx.com/Blog.aspx?bid=" + iBlogID.ToString() + "\">Click to view</a>";
            SmtpMail.Send(mm);

            if (User.Identity.Name.ToLower() != dtBlog.Rows[0].ItemArray[1].ToString().ToLower())
            {
                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = dtBlog.Rows[0].ItemArray[1].ToString();
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Someone posted a comment on your blog.";
                mm.Body = sName + " posted a comment on your blog titled: " + dtBlog.Rows[0].ItemArray[3].ToString();
                mm.Body += "<br /><a href=\"http://www.referralnetworx.com/Blog.aspx?bid=" + iBlogID.ToString() + "\">Click to view</a>";
                SmtpMail.Send(mm);
            }

            Session["resultColor"] = "#009900";
            Session["resultTitle"] = "Comment Added";
            Session["resultMessage"] = "Thank you for your comment!";
            Session["resultReturnURL"] = Request.RawUrl;
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            cvInvalidCode.IsValid = false;
        }
    }
}
