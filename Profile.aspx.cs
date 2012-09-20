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

public partial class ProfilePage : System.Web.UI.Page
{
    string sMember;
    LinkButton lbDelete;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            addcomment.Visible = true;
            memberoptions.Visible = true;
            sMember = User.Identity.Name;
        }
        else
        {
            memberoptions.Visible = false;
            addcomment.Visible = false;
        }

        if (Request.QueryString["member"] != null)
        {
            sMember = Request.QueryString["member"];
        }
        else if ((Request.QueryString["member"] == null) && (!User.Identity.IsAuthenticated))
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "No Member Specified";
            Session["resultMessage"] = "No MemberID was specified.";
            Session["resultReturnURL"] = "Default.aspx";
            Response.Redirect("Result.aspx");
        }

        DataLayer dl = new DataLayer();
        Object[] oMember = dl.GetMemberBy_Email(sMember).Rows[0].ItemArray;
        string sEmail = oMember[0].ToString();
        string sName = oMember[2].ToString();
        string sPersonalAvatar = oMember[3].ToString();
        string sPhone = oMember[4].ToString();
        string sInterests = oMember[5].ToString();
        string sWebsite = oMember[6].ToString();
        string sPersonalBio = oMember[7].ToString();
        string sBusinessName = oMember[8].ToString();
        string sBusinessLogo = oMember[9].ToString();
        string sBusinessDescription = oMember[10].ToString();
        DateTime dtJoinDate = Convert.ToDateTime(oMember[11]);
        string sAIM = oMember[13].ToString();
        string sMSN = oMember[14].ToString();
        string sYahoo = oMember[15].ToString();
        string sGoogleTalk = oMember[16].ToString();
        string sLocation = oMember[17].ToString();
        string sSignature = oMember[18].ToString();
        bool bMemberNewsletter = Convert.ToBoolean(oMember[22]);
        bool bDailyMotivaotr = Convert.ToBoolean(oMember[23]);
        bool bShowEmail = Convert.ToBoolean(oMember[24]);
        bool bUpdateTwitter = Convert.ToBoolean(oMember[25]);
        string sTwitterUsername = oMember[26].ToString();
        string sTwitterPassword = oMember[27].ToString();
        string sGender = oMember[28].ToString();
        DateTime dtBirthday = Convert.ToDateTime(oMember[30]);
        string sBusinessCategory = oMember[31].ToString();
        string[] sTwitterFeedStyles = oMember[32].ToString().Split(',');
        bool bDeleted = Convert.ToBoolean(oMember[33]);
        string sMembershipType = oMember[38].ToString();

        if (bDeleted)
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Profile Doesn't Exist";
            Session["resultMessage"] = "That member no longer exists.";
            Session["resultReturnURL"] = "Default.aspx";
            Response.Redirect("Result.aspx", true);
        }

        hlSendMessage.NavigateUrl = "SendMessage.aspx?member=" + sEmail;
        imgAvatar.ImageUrl = "MakeThumbnail.aspx?size=300&image=images/MemberAvatars/" + sPersonalAvatar;
        hlAvatar.NavigateUrl = "images/MemberAvatars/" + sPersonalAvatar;
        lblName.Text = sName;
        membername.InnerHtml = sName + "'s Profile";
        this.Title = sName + "'s Profile";
        lblJoinDate.Text = dtJoinDate.ToString("d");
        TimeSpan ts = DateTime.Now.Subtract(dtBirthday);
        lblAge.Text = Convert.ToString(ts.Days / 365);
        lblGender.Text = sGender;
        lblLocation.Text = sLocation;
        divInterests.InnerHtml = sInterests;
        divPersonalBio.InnerHtml = sPersonalBio;
        if (sSignature != "")
        {
            divSignature.InnerHtml = "<br /><hr />" + sSignature;
        }

        imgLogo.ImageUrl = "MakeThumbnail.aspx?size=300&image=images/BusinessLogos/" + sBusinessLogo;
        hlLogo.NavigateUrl = "images/BusinessLogos/" + sBusinessLogo;
        lblBusinessName.Text = sBusinessName;
        lblBusinessCategory.Text = sBusinessCategory;
        divBusinessDescription.InnerHtml = sBusinessDescription;

        hlEmail.Text = sEmail;
        hlEmail.NavigateUrl = "mailto:" + sEmail;
        lblPhone.Text = sPhone;
        hlWebsite.Text = sWebsite;
        hlWebsite.NavigateUrl = sWebsite;
        hlTwitterProfile.Text = sTwitterUsername;
        hlTwitterProfile.NavigateUrl = "http://www.twitter.com/" + sTwitterUsername;

        lblAIM.Text = sAIM;
        lblWLM.Text = sMSN;
        lblYahoo.Text = sYahoo;
        lblGoogleTalk.Text = sGoogleTalk;
        twitterupdatebox.Visible = false;

        profilestyle.InnerHtml = "#profilepanel .contenttitle{background-color:" + sTwitterFeedStyles[5] + ";color:" + sTwitterFeedStyles[6] + "; border-width:0px;} #profilepanel .contentpanel{background-color:" + sTwitterFeedStyles[7] + "; color:" + sTwitterFeedStyles[8] + ";} #profilepanel hr {color:" + sTwitterFeedStyles[5] + "; background-color:" + sTwitterFeedStyles[5] + "; height:3px; border-width:0px;} #profilepanel a:link, #profilepanel a:visited, #profilepanel a:hover{color:" + sTwitterFeedStyles[9] + ";} #profilepanel .formtitle{background-color:" + sTwitterFeedStyles[5] + "; color:" + sTwitterFeedStyles[6] + "; border-width:0px;} #profilepanel .formpanel{background-color:" + sTwitterFeedStyles[10] + ";} #profilepanel .dividerline{background-color:" + sTwitterFeedStyles[5] + "; color:" + sTwitterFeedStyles[6] + ";}";

        if ((sTwitterUsername != ""))
        {
            twitterfeed.Visible = true;
            twitterbox.InnerHtml = "<center><div id=\"twtr-profile-widget\"></div><script src=\"http://widgets.twimg.com/j/1/widget.js\"></script><link href=\"http://widgets.twimg.com/j/1/widget.css\" type=\"text/css\" rel=\"stylesheet\" /><script>new TWTR.Widget({profile: true,id: 'twtr-profile-widget',loop: true,width: 300,height: 300,theme: {shell: {background: '" + sTwitterFeedStyles[0] + "',color: '" + sTwitterFeedStyles[1] + "'},tweets: {background: '" + sTwitterFeedStyles[2] + "',color: '" + sTwitterFeedStyles[3] + "',links: '" + sTwitterFeedStyles[4] + "'}}}).render().setProfile('" + sTwitterUsername + "').start();</script></center><br />";
            if ((sTwitterPassword != "") && (sMember.ToUpper() == User.Identity.Name.ToUpper()) && (bUpdateTwitter))
            {
                twitterupdatebox.Visible = true;
            }
            else
            {
                twitterupdatebox.Visible = false;
            }
        }
        else
        {
            twitterfeed.Visible = false;
        }

        if (bShowEmail)
        {
            divAge.Visible = true;
        }
        else
        {
            divAge.Visible = false;
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


            commentbox.Visible = true;

            int iPageNumber = 0;
            if (Request.QueryString["p"] != null)
            {
                iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
            }

            int iCommentCount = dl.GetMemberCommentCount(sMember);
            numthumbsup.InnerText = dl.GetMemberThumbsUpCount(sMember).ToString();
            numcomments.InnerText = iCommentCount.ToString();
            int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(iCommentCount / 15m)));
            pageNav1.NumPages = iMaxPages;
            pageNav2.NumPages = iMaxPages;
            DataTable dtComments = dl.GetFifteenMemberCommentsBy_Page(iPageNumber, sMember);
            if (dl.GaveMemberThumbsUpAlready(sMember, User.Identity.Name) || (User.Identity.Name.ToLower() == sMember.ToLower()))
            {
                cbxThumbsUp.Visible = false;
            }
            else
            {
                cbxThumbsUp.Visible = true;
            }

            bool bColored = true;
            foreach (DataRow dr in dtComments.Rows)
            {
                DataTable dtMember = dl.GetMemberBy_Email(dr.ItemArray[1].ToString());

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
                comments.Controls.Add(new LiteralControl(";padding:10px;\"><table style=\"width:100%;\"><tr><td rowspan=\"2\" style=\"vertical-align:top;text-align:center;font-size:17px;font-weight:bold;padding-right:15px;border-right:solid 2px #333333;width:150px;\"><a style=\"text-decoration:none;\" href=\"Profile.aspx?member=" + dtMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=150&image=images/MemberAvatars/" + dtMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><br /><a href=\"Profile.aspx?member=" + dtMember.Rows[0].ItemArray[0].ToString() + "\">" + dtMember.Rows[0].ItemArray[2].ToString() + "</a></td><td style=\"text-align:left;vertical-align:top;padding-left:15px;\">" + dr.ItemArray[3].ToString() + "<br /><br />----------------------------------<br />" + dtMember.Rows[0].ItemArray[18].ToString() + "</td></tr><tr><td style=\"vertical-align:bottom;padding-left:15px;padding-top:15px;\"><table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;\"><tr><td style=\"text-align:left;vertical-align:bottom;font-size:12px;font-weight:bold;\">" + dr.ItemArray[2].ToString()));
                if (Convert.ToBoolean(dr.ItemArray[5]))
                    comments.Controls.Add(new LiteralControl("&nbsp&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<img style=\"width:25px;\" src=\"images/ThumbsUp.png\" />"));
                comments.Controls.Add(new LiteralControl("</td><td style=\"text-align:right;vertical-align:bottom;\">"));
                if (User.Identity.IsAuthenticated)
                {
                    if ((User.Identity.Name.ToLower() == dr.ItemArray[1].ToString().ToLower()) || (User.Identity.Name.ToLower() == sMember.ToLower()) || (dl.IsMemberAdmin(User.Identity.Name)) || (dl.IsMemberModerator(User.Identity.Name)))
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
        else
        {
            commentbox.Visible = false;
        }
    }

    void lbDelete_Click(object sender, EventArgs e)
    {
        int iCommentID = Convert.ToInt32(((LinkButton)sender).ID);
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetCommentBy_CommentID(iCommentID);
        bool bThumbsUp = Convert.ToBoolean(dt.Rows[0].ItemArray[5]);
        dl.DeleteComment(iCommentID);
        if (bThumbsUp)
        {
            dl.MinusThumbsUp(sMember);
        }
        Session["resultColor"] = "#009900";
        Session["resultTitle"] = "Comment Deleted";
        Session["resultMessage"] = "Comment Deleted Successfully";
        Session["resultReturnURL"] = Request.RawUrl;
        Response.Redirect("Result.aspx", true);
    }

    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        dl.AddComment(User.Identity.Name, DateTime.Now, tbxAddComment.Text.Replace("\r", "<br />").Replace("\n", ""), "Member", cbxThumbsUp.Checked, -1, sMember);
        if (cbxThumbsUp.Checked)
        {
            dl.AddThumbsUp(sMember);
        }

        SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
        MailMessage mm;
        mm = new MailMessage();
        mm.BodyFormat = MailFormat.Html;
        mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
        mm.From = "NoReply@ReferralNetworX.com";
        mm.Subject = "Someone posted a profile comment.";
        mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " posted a comment on " + dl.GetFullMemberNameBy_Email(sMember) + "'s profile.";
        mm.Body += "<br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + sMember + "\">Click to view</a>";
        mm.Body += "<br /><br />The comment is below:<br /><br />" + tbxAddComment.Text.Replace("\r", "<br />").Replace("\n", "");
        SmtpMail.Send(mm);

        if (sMember.ToLower() != User.Identity.Name.ToLower())
        {
            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = sMember;
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Someone posted a comment on your profile!";
            mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " posted a comment on your profile.";
            mm.Body += "<br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + sMember + "\">Click to view</a>";
            SmtpMail.Send(mm);
        }

        Session["resultColor"] = "#009900";
        Session["resultTitle"] = "Comment Added";
        Session["resultMessage"] = "Thank you for your comment! ";
        Session["resultReturnURL"] = Request.RawUrl;
        Response.Redirect("Result.aspx", true);
    }

    protected void btnTwitterUpdate_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        DataTable dtMember = dl.GetMemberBy_Email(sMember);
        string sTwitterUsername = dtMember.Rows[0].ItemArray[26].ToString();
        string sTwitterPassword = dtMember.Rows[0].ItemArray[27].ToString();
        Yedda.Twitter t = new Yedda.Twitter();
        t.Update(sTwitterUsername, sTwitterPassword, tbxTwitterUpdate.Text, Yedda.Twitter.OutputFormatType.XML);
    }
}
