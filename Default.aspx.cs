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
using System.Web.Mail;

public partial class Default : System.Web.UI.Page
{
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.UserHostAddress == "98.202.119.104")
        //{
        //    plmplayer.Visible = false;
        //}

        DataLayer dl = new DataLayer();

        //loggedinpanels.Controls.Add(new LiteralControl("<div class=\"formtitle\">KRNX&nbsp;Podcast!</div><div class=\"formpanel\"><center><object class=\"playerpreview\" type=\"application/x-shockwave-flash\" data=\"player_mp3_multi.swf\" width=\"200\" height=\"100\"><param name=\"movie\" value=\"player_mp3_multi.swf\" /><param name=\"FlashVars\" value=\"mp3=/KRNX/Ep01.mp3|/KRNX/Ep02.mp3|/KRNX/Ep03.mp3&amp;title=KRNX 01 - What is Referral NetworX?|KRNX 02 - Why Relationships Are Important|KRNX 03 - Relationship Marketing&amp;bgcolor1=598959&amp;bgcolor2=73B472\" /></object><br /></center></div>"));

        if (User.Identity.IsAuthenticated)
        {
            loggedoutpanels.Visible = false;
            loggedoutcontent.Visible = false;

            DataTable dtMotivator = dl.GetLastSentDailyMotivator();
            if (dtMotivator.Rows.Count > 0)
            {
                loggedincontent.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Daily Motivator</div><div class=\"contentpanel\">"));
                string sYouTubeLink = dtMotivator.Rows[0].ItemArray[5].ToString();
                if (sYouTubeLink != "No Video.")
                {
                    sYouTubeLink = sYouTubeLink.Replace(".com/watch?v=", ".com/v/");
                    loggedincontent.Controls.Add(new LiteralControl("<center><object width=\"425\" height=\"344\"><param name=\"movie\" value=\"" + sYouTubeLink + "&amp;hl=en_US&amp;fs=1&amp;\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"" + sYouTubeLink + "&amp;hl=en_US&amp;fs=1&amp;\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"425\" height=\"344\"></embed></object></center>"));
                }
                loggedincontent.Controls.Add(new LiteralControl("<center>" + dtMotivator.Rows[0].ItemArray[4].ToString() + "</center></div>"));
            }

            DataTable dtBlog = dl.GetLatestBlog();
            if (dtBlog.Rows.Count > 0)
            {
                string sBody = "<i>No Summary</i>";
                if (dtBlog.Rows[0].ItemArray[4].ToString().Contains('~'))
                {
                    sBody = dtBlog.Rows[0].ItemArray[4].ToString();
                    sBody = sBody.Remove(sBody.IndexOf('~'));
                }
                loggedincontent.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Latest Blog</div><div class=\"contentpanel\"><table style=\"width:100%;\"><tr><td><div style=\"font-size:35px;font-family:arial;\"><a class=\"navlink\" href=\"Blog.aspx?bid=" + dtBlog.Rows[0].ItemArray[0].ToString() + "\">" + dtBlog.Rows[0].ItemArray[3].ToString() + "</a></div><div>Posted by <a href=\"Profile.aspx?member=" + dtBlog.Rows[0].ItemArray[1].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtBlog.Rows[0].ItemArray[1].ToString()) + "</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" + Convert.ToDateTime(dtBlog.Rows[0].ItemArray[2]).ToString("D") + "</div><br /><div>" + sBody + "<br /><br /><b><a class=\"navlink\" href=\"Blog.aspx?bid=" + dtBlog.Rows[0].ItemArray[0].ToString() + "\">(Read More)</a></b></div></td></tr></table></div>"));
            }

            loggedincontent.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Check Out Our Latest Articles!</div><div style=\"font-size:25px;text-align:center;\" class=\"contentpanel\">"));
            DataTable dtArticles = dl.GetFiveLatestArticles();
            foreach (DataRow dr in dtArticles.Rows)
            {
                loggedincontent.Controls.Add(new LiteralControl("<a class=\"navlink\" style=\"text-decoration:underline;\" href=\"Article.aspx?aid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[2].ToString() + "</a> <span style=\"font-size:14px;\">by <a href=\"Profile.aspx?member=" + dr.ItemArray[4].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dr.ItemArray[4].ToString()) + "</a></span><hr />"));
            }
            loggedincontent.Controls.Add(new LiteralControl("</div>"));

            //logged in panels

            loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Featured Member</div><div class=\"contentpanel\">"));
            DataTable dtRandomMember = dl.GetRandomMember();
            loggedinpanels.Controls.Add(new LiteralControl("<table style=\"width:100%;\"><tr><td style=\"font-size:13px;text-align:center;\"><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=100&image=images/MemberAvatars/" + dtRandomMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\">View Profile</a></td><td style=\"padding-left:5px;font-size:13px;width:100%;\"><b>Name:</b> " + dtRandomMember.Rows[0].ItemArray[2].ToString() + "<br /><br /><b>Location:</b> " + dtRandomMember.Rows[0].ItemArray[17].ToString() + "<br /><br /><b>Business:</b> " + dtRandomMember.Rows[0].ItemArray[8].ToString() + "<br /><br />"));
            if (dtRandomMember.Rows[0].ItemArray[6].ToString() != "")
            {
                loggedinpanels.Controls.Add(new LiteralControl("<center><a href=\"" + dtRandomMember.Rows[0].ItemArray[6].ToString() + "\">Visit Website</a></center>"));
            }
            loggedinpanels.Controls.Add(new LiteralControl("</td></tr></table></div>"));

            DataTable dtMemberAd = dl.GetRandomAd();
            loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Member Ad</div><div style=\"text-align:center;\" class=\"contentpanel\"><a href=\"" + dtMemberAd.Rows[0].ItemArray[2].ToString() + "\"><img style=\"width:230px; border-width:0px;\" src=\"" + dtMemberAd.Rows[0].ItemArray[1].ToString() + "\" /></a></div>"));

            loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Popular Topics</div><div style=\"font-size:15px;\" class=\"contentpanel\"><ul>"));
            DataTable dtTopics = dl.GetFiveTopics();
            foreach (DataRow dr in dtTopics.Rows)
            {
                loggedinpanels.Controls.Add(new LiteralControl("<li style=\"display:list-item;margin:0px;background-color:transparent;border-width:0px;\"><a href=\"Topic.aspx?topic=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[4].ToString() + "</a></li>"));
            }
            loggedinpanels.Controls.Add(new LiteralControl("</ul></div>"));
        }
        else
        {
            DataTable dtMotivator = dl.GetLastSentDailyMotivator();
            if (dtMotivator.Rows.Count > 0)
            {
                dailymotivator.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Daily Motivator</div><div class=\"contentpanel\">"));
                string sYouTubeLink = dtMotivator.Rows[0].ItemArray[5].ToString();
                if (sYouTubeLink != "No Video.")
                {
                    sYouTubeLink = sYouTubeLink.Replace(".com/watch?v=", ".com/v/");
                    dailymotivator.Controls.Add(new LiteralControl("<center><object width=\"425\" height=\"344\"><param name=\"movie\" value=\"" + sYouTubeLink + "&amp;hl=en_US&amp;fs=1&amp;\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"" + sYouTubeLink + "&amp;hl=en_US&amp;fs=1&amp;\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"425\" height=\"344\"></embed></object></center>"));
                }
                dailymotivator.Controls.Add(new LiteralControl("<center>" + dtMotivator.Rows[0].ItemArray[4].ToString() + "</center></div>"));
            }

            DataTable dtBlog = dl.GetLatestBlog();
            if (dtBlog.Rows.Count > 0)
            {
                string sBody = "<i>No Summary</i>";
                if (dtBlog.Rows[0].ItemArray[4].ToString().Contains('~'))
                {
                    sBody = dtBlog.Rows[0].ItemArray[4].ToString();
                    sBody = sBody.Remove(sBody.IndexOf('~'));
                }
                latestblog.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Latest Blog</div><div class=\"contentpanel\"><table style=\"width:100%;\"><tr><td><div style=\"font-size:35px;font-family:arial;\"><a class=\"navlink\" href=\"Blog.aspx?bid=" + dtBlog.Rows[0].ItemArray[0].ToString() + "\">" + dtBlog.Rows[0].ItemArray[3].ToString() + "</a></div><div>Posted by <a href=\"Profile.aspx?member=" + dtBlog.Rows[0].ItemArray[1].ToString() + "\">" + dl.GetFullMemberNameBy_Email(dtBlog.Rows[0].ItemArray[1].ToString()) + "</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" + Convert.ToDateTime(dtBlog.Rows[0].ItemArray[2]).ToString("D") + "</div><br /><div>" + sBody + "<br /><br /><b><a class=\"navlink\" href=\"Blog.aspx?bid=" + dtBlog.Rows[0].ItemArray[0].ToString() + "\">(Read More)</a></b></div></td></tr></table></div>"));
            }
            loggedoutcontent.Visible = true;
            lbWelcome_Click(null, null);
        }

        if (!this.IsPostBack)
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }
    }

    protected void lbWelcome_Click(object sender, EventArgs e)
    {
        welcome.Visible = true;
        tour.Visible = false;
        pricing.Visible = false;
        testimoials.Visible = false;
    }

    protected void lbTakeATour_Click(object sender, EventArgs e)
    {
        welcome.Visible = false;
        tour.Visible = true;
        pricing.Visible = false;
        testimoials.Visible = false;
    }

    protected void lbPricing_Click(object sender, EventArgs e)
    {
        welcome.Visible = false;
        tour.Visible = false;
        pricing.Visible = true;
        testimoials.Visible = false;
    }

    protected void lbTestimonials_Click(object sender, EventArgs e)
    {
        welcome.Visible = false;
        tour.Visible = false;
        pricing.Visible = false;
        testimoials.Visible = true;
    }

    protected void lbSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx", true);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (tbxCode.Text == Session["CaptchaImageText"].ToString())
        {
            if (this.IsValid)
            {
                DataLayer dl = new DataLayer();
                dl.AddNonMember(tbxNonMemberEmail.Text, tbxNonMemberName.Text, true, true);

                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                MailMessage mm;
                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Someone signed up for the RNX free content.";
                mm.Body = tbxNonMemberName.Text + " subscribed to the RNX free content using this email: " + tbxNonMemberEmail.Text;
                SmtpMail.Send(mm);

                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Success!";
                Session["resultMessage"] = "You have successfully subscribed to the RNX free content!";
                Session["resultReturnURL"] = "Default.aspx";
                Response.Redirect("Result.aspx", true);
            }

        }
        else
        {
            cvInvalidCode.IsValid = false;
        }
    }
}
