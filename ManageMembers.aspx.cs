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
using System.Net;
using System.IO;
using System.Web.Mail;

public partial class ManageMembers : System.Web.UI.Page
{
    Random rPassword = new Random();
    Random rand = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (User.Identity.IsAuthenticated)
        {
            if (!dl.IsMemberAdmin(User.Identity.Name))
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Not Authorized";
                Session["resultMessage"] = "You are not authorized to access this area.";
                Session["resultReturnURL"] = "Default.aspx";
                Response.Redirect("Result.aspx");
            }
            else if (dl.IsMemberAdmin(User.Identity.Name))
            {
                memberform.Visible = true;
            }
        }
        else
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Not Logged In";
            Session["resultMessage"] = "You must log in first.";
            Session["resultReturnURL"] = "ManageMembers.aspx";
            Response.Redirect("Result.aspx");
        }

        if (!this.IsPostBack)
        {
            btnSearch_Click(null, null);

            DataTable dtArticleCategories = dl.GetCategories();
            foreach (DataRow dr in dtArticleCategories.Rows)
            {
                ddlArticleColumn.Items.Add(dr.ItemArray[0].ToString());
            }
            btnAddNewMember_Click(null, null);
        }
    }

    protected void btnAddNewMember_Click(object sender, EventArgs e)
    {
        editoptions.Visible = false;
        addedit.InnerText = "Add New Member";
        cbxDeleteMember.Visible = false;
        cbxDeleteMember.Checked = false;
        cbxDeleteMember_CheckedChanged(null, null);
        lblDeleteMember.Visible = false;
        tbxEmail.Text = "";
        tbxName.Text = "";
        tbxBusinessName.Text = "";
        cbxAdmin.Checked = false;
        cbxModerator.Checked = false;
        cbxCanPostBlog.Checked = false;
        cbxMemberNewsletter.Checked = true;
        cbxDailyMotivator.Checked = true;
        lbxMembers.SelectedIndex = -1;
        ddlArticleColumn.SelectedIndex = 0;
    }

    protected void lbxMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        memberform.Visible = true;
        editoptions.Visible = true;
        addedit.InnerText = "Edit Member";
        string sEmail = lbxMembers.SelectedValue;
        DataLayer dl = new DataLayer();
        DataRow drMember = dl.GetMemberBy_Email(sEmail).Rows[0];
        cbxDeleteMember.Visible = true;
        cbxDeleteMember.Checked = false;
        cbxDeleteMember_CheckedChanged(null, null);
        lblDeleteMember.Visible = true;
        tbxEmail.Text = drMember.ItemArray[0].ToString();
        hlEditFullProfile.NavigateUrl = "EditProfile.aspx?member=" + drMember.ItemArray[0].ToString();
        hlViewProfile.NavigateUrl = "Profile.aspx?member=" + drMember.ItemArray[0].ToString();
        tbxName.Text = drMember.ItemArray[2].ToString();
        tbxBusinessName.Text = drMember.ItemArray[8].ToString();
        cbxAdmin.Checked = Convert.ToBoolean(drMember.ItemArray[19]);
        cbxModerator.Checked = Convert.ToBoolean(drMember.ItemArray[20]);
        cbxCanPostBlog.Checked = Convert.ToBoolean(drMember.ItemArray[21]);
        cbxMemberNewsletter.Checked = Convert.ToBoolean(drMember.ItemArray[22]);
        cbxDailyMotivator.Checked = Convert.ToBoolean(drMember.ItemArray[23]);
        string sArticleCategory = drMember.ItemArray[34].ToString();
        lblSubscriptionID.Text = drMember.ItemArray[35].ToString();

        if (sArticleCategory != "None")
        {
            for (int iCount = 0; iCount < ddlArticleColumn.Items.Count; iCount++)
            {
                if (sArticleCategory == ddlArticleColumn.Items[iCount].ToString())
                {
                    ddlArticleColumn.SelectedIndex = iCount;
                    break;
                }
            }
        }
        else
        {
            ddlArticleColumn.SelectedIndex = 0;
        }
        cbxAdmin_CheckedChanged(null, null);
    }

    protected void cbxDeleteMember_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteMember.Checked)
        {
            tbxEmail.Enabled = false;
            tbxName.Enabled = false;
            tbxBusinessName.Enabled = false;
            cbxAdmin.Enabled = false;
            cbxModerator.Enabled = false;
            cbxCanPostBlog.Enabled = false;
            cbxMemberNewsletter.Enabled = false;
            cbxDailyMotivator.Enabled = false;
            ddlArticleColumn.Enabled = false;
        }
        else
        {
            tbxEmail.Enabled = true;
            tbxName.Enabled = true;
            tbxBusinessName.Enabled = true;
            cbxAdmin.Enabled = true;
            cbxModerator.Enabled = true;
            cbxCanPostBlog.Enabled = true;
            cbxMemberNewsletter.Enabled = true;
            cbxDailyMotivator.Enabled = true;
            ddlArticleColumn.Enabled = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxMembers.SelectedIndex == -1)
        {
            string sSubscriptionID = "Free";
            string sMembershipType = "0.00";
            DataLayer dl = new DataLayer();
            DateTime dtJoinDate = DateTime.Now;

            int iPassword = rPassword.Next(9999999);

            dl.AddMember(tbxEmail.Text, iPassword.ToString(), tbxName.Text, "no_avatar.gif", "", "", "", "", tbxBusinessName.Text, "no_logo.gif", "", dtJoinDate, "", "", "", "", "", "", cbxAdmin.Checked, cbxModerator.Checked, cbxCanPostBlog.Checked, cbxMemberNewsletter.Checked, cbxDailyMotivator.Checked, false, false, "", "", "Not Specified", 0, DateTime.Today, "", "#77BB77,#ffffff,#DDFFDD,#444444,#1985b5,#77BB77,#ffffff,#ffffff,#000000,#0000EE,#CCDDCC", ddlArticleColumn.SelectedValue, sSubscriptionID, sMembershipType);

            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create("http://tinyurl.com/api-create.php?url=http://www.ReferralNetworX.com/Profile.aspx?member=" + tbxEmail.Text);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sURL = objReader.ReadToEnd();

                Yedda.Twitter t = new Yedda.Twitter();
                t.Update("ReferralNetworX", "1million!", "New Member! " + dl.GetFullMemberNameBy_Email(tbxEmail.Text) + " has joined us on ReferralNetworX.com " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("Chevex", "Ch3vyF0rd", "New Member! " + dl.GetFullMemberNameBy_Email(tbxEmail.Text) + " has joined us on ReferralNetworX.com " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("WALTatRNX", "robinwalt98", "New Member! " + dl.GetFullMemberNameBy_Email(tbxEmail.Text) + " has joined us on ReferralNetworX.com " + sURL, Yedda.Twitter.OutputFormatType.XML);
            }
            catch
            {
            }

            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            MailMessage mm;

            ////////////////// -= Add Comment To New Member's Profile =- ////////////////////////
            int iPerson = rand.Next(2);
            string sPerson;
            if (iPerson == 0)
            {
                int iComment = rand.Next(10);
                string sComment = "";
                if (iComment == 0)
                {
                    sComment = "Welcome to the site! I hope you like what you find.<br /><br />- Alex";
                }
                else if (iComment == 1)
                {
                    sComment = "Welcome to Referral NetworX! We are glad to have you as a member.<br /><br />- Alex";
                }
                else if (iComment == 2)
                {
                    sComment = "I love seeing new faces! Welcome to the site.<br /><br />- Alex";
                }
                else if (iComment == 3)
                {
                    sComment = "Welcome to the site! I look forward to networking with you.<br /><br />- Alex";
                }
                else if (iComment == 4)
                {
                    sComment = "A new member! I am excited that you have joined us!<br /><br />- Alex";
                }
                else if (iComment == 5)
                {
                    sComment = "Welcome to the site! We are excited to benefit from the knowledge you have to offer!<br /><br />- Alex";
                }
                else if (iComment == 6)
                {
                    sComment = "We are excited to have you here! I am confident you will make a great addition to the RNX community!<br /><br />- Alex";
                }
                else if (iComment == 7)
                {
                    sComment = "Glad you could join us! I look forward to networking with you.<br /><br />- Alex";
                }
                else if (iComment == 8)
                {
                    sComment = "I am happy you decided to be a part of Referral NetworX! Here is your first thumbs up!<br /><br />- Alex";
                }
                else if (iComment == 9)
                {
                    sComment = "Welcome to ReferralNetworX.com! Let me know if you need anything at all!<br /><br />- Alex";
                }

                dl.AddComment("Alex@ReferralNetworX.com", DateTime.Now, sComment, "Member", true, -1, tbxEmail.Text);
                dl.AddThumbsUp(tbxEmail.Text);

                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = tbxEmail.Text;
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Someone posted a comment on your profile!";
                mm.Body = "Alex Ford posted a comment on your profile.";
                mm.Body += "<br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + tbxEmail.Text + "\">Click to view</a>";
                SmtpMail.Send(mm);
            }
            else if (iPerson == 1)
            {
                int iComment = rand.Next(6);
                string sComment = "";
                if (iComment == 0)
                {
                    sComment = "Hi and welcome to Referral NetworX! Our mission is your success!<br /><br />- Walt";
                }
                else if (iComment == 1)
                {
                    sComment = "Welcome to Referral NetworX! I am really looking forward to networking with you. Here's to you continued success!<br /><br />- Walt";
                }
                else if (iComment == 2)
                {
                    sComment = "Its great to have you as a member of Referral NetworX! We are here to help you with your continued success!<br /><br />- Walt";
                }
                else if (iComment == 3)
                {
                    sComment = "Congratulations! You are now a member of Referral NetworX. Our mission is your success!<br /><br />- Walt";
                }
                else if (iComment == 4)
                {
                    sComment = "Welcome! Referral NetworX is your beginning to expanding your personal network! Relationship, Relationship, Relationship!<br /><br />- Walt";
                }
                else if (iComment == 5)
                {
                    sComment = "Welcome to Referral NetworX! Your journey to building quality relationships and expanding your network has begun!<br /><br />- Walt";
                }

                dl.AddComment("Walt@ReferralNetworX.com", DateTime.Now, sComment, "Member", true, -1, tbxEmail.Text);
                dl.AddThumbsUp(tbxEmail.Text);

                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = tbxEmail.Text;
                mm.From = "NoReply@ReferralNetworX.com";
                mm.Subject = "Someone posted a comment on your profile!";
                mm.Body = "Walt Ford posted a comment on your profile.";
                mm.Body += "<br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + tbxEmail.Text + "\">Click to view</a>";
                SmtpMail.Send(mm);
            }

            //////////////////////////////////////////////////////////////

            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = "Alex@ReferralNetworX.com;Walt@ReferralNetworX.com";
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Someone signed up on ReferralNetworX.com!";
            mm.Body = tbxName.Text + " signed up on ReferralNetworX.com.";
            mm.Body += "<br /><br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + tbxEmail.Text + "\">Click to view</a>";
            SmtpMail.Send(mm);

            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = tbxEmail.Text;
            mm.From = "NoReply@ReferralNetworX.com";
            mm.Subject = "Welcome to ReferralNetworX.com!";
            mm.Body = "Welcome " + dl.GetMemberNameBy_Email(tbxEmail.Text) + ",<br /><br />";
            mm.Body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We are dedicated to helping you and your business succeed. I truly hope RNX helps you to grow to new heights and accomplish your goals. I am confident that you will provide a lot of value to the RNX community and that your knowledge will benefit everyone! Please <a href=\"http://www.referralnetworx.com/referralnetworx/Topic.aspx?topic=50\">visit our forums to say hi</a> to fellow members and get to know everyone. Also, be sure to log in and edit your profile. The more information you provide about yourself and your business, the more you will get noticed and more opportunities will be presented to you.<br /><br />Here is your username and temporary password:<br />Password - " + iPassword.ToString() + " (You can change this after logging in)<br />Username - " + tbxEmail.Text + "<br /><br />Alex Ford<br />Referral NetworX Administrator";
            SmtpMail.Send(mm);


            try
            {
                dl.DeleteNonMember(tbxEmail.Text);
            }
            catch { }

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Member Added";
            Session["resultMessage"] = "Member Added Successfuly";
            Session["resultReturnURL"] = "ManageMembers.aspx";
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteMember.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteMember(lbxMembers.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Member Deleted";
                Session["resultMessage"] = "Member Deleted Successfuly";
                Session["resultReturnURL"] = "ManageMembers.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                DataTable dt = dl.GetMemberBy_Email(lbxMembers.SelectedValue);
                string sTwitterFeedStyles = dt.Rows[0].ItemArray[32].ToString();
                string sPersonalAvatar = dt.Rows[0].ItemArray[3].ToString();
                string sMemberAvatar = dt.Rows[0].ItemArray[3].ToString();
                string sPhone = dt.Rows[0].ItemArray[4].ToString();
                string sInterests = dt.Rows[0].ItemArray[5].ToString();
                string sWebsite = dt.Rows[0].ItemArray[6].ToString();
                string sPersonalBio = dt.Rows[0].ItemArray[7].ToString();
                string sBusinessLogo = dt.Rows[0].ItemArray[9].ToString();
                string sBusinessBio = dt.Rows[0].ItemArray[10].ToString();
                string sAIM = dt.Rows[0].ItemArray[13].ToString();
                string sMSN = dt.Rows[0].ItemArray[14].ToString();
                string sYahoo = dt.Rows[0].ItemArray[15].ToString();
                string sGoogleTalk = dt.Rows[0].ItemArray[16].ToString();
                string sLocation = dt.Rows[0].ItemArray[17].ToString();
                string sSignature = dt.Rows[0].ItemArray[18].ToString();
                bool bShowEmail = Convert.ToBoolean(dt.Rows[0].ItemArray[24]);
                bool bUpdateTwitter = Convert.ToBoolean(dt.Rows[0].ItemArray[25]);
                string sTwitterUsername = dt.Rows[0].ItemArray[26].ToString();
                string sTwitterPassword = dt.Rows[0].ItemArray[27].ToString();
                string sGender = dt.Rows[0].ItemArray[28].ToString();
                DateTime dtBirthday = Convert.ToDateTime(dt.Rows[0].ItemArray[30]);
                string sBusinessCategory = dt.Rows[0].ItemArray[31].ToString();

                dl.UpdateMember(lbxMembers.SelectedValue, tbxName.Text, sPersonalAvatar, sPhone, sInterests, sWebsite, sPersonalBio, tbxBusinessName.Text, sBusinessLogo, sBusinessBio, sAIM, sMSN, sYahoo, sGoogleTalk, sLocation, sSignature, cbxAdmin.Checked, cbxModerator.Checked, cbxCanPostBlog.Checked, cbxMemberNewsletter.Checked, cbxDailyMotivator.Checked, bShowEmail, bUpdateTwitter, sTwitterUsername, sTwitterPassword, sGender, dtBirthday, sBusinessCategory, sTwitterFeedStyles, ddlArticleColumn.SelectedValue);
                if (lbxMembers.SelectedValue.ToUpper() != tbxEmail.Text.ToUpper())
                {
                    if (sPersonalAvatar != "no_avatar.gif")
                    {
                        string sExt = sPersonalAvatar.Remove(0, sPersonalAvatar.LastIndexOf('.'));
                        string sNewPersonalAvatar = tbxEmail.Text + sExt;
                        if (File.Exists(MapPath("~/images/MemberAvatars/" + sNewPersonalAvatar)))
                            File.Delete(MapPath("~/images/MemberAvatars/" + sNewPersonalAvatar));
                        File.Move(MapPath("~/images/MemberAvatars/" + sPersonalAvatar), MapPath("~/images/MemberAvatars/" + sNewPersonalAvatar));
                        sPersonalAvatar = sNewPersonalAvatar;
                    }
                    if (sBusinessLogo != "no_logo.gif")
                    {
                        string sExt = sBusinessLogo.Remove(0, sBusinessLogo.LastIndexOf('.'));
                        string sNewBusinessLogo = tbxEmail.Text + sExt;
                        if (File.Exists(MapPath("~/images/BusinessLogos/" + sNewBusinessLogo)))
                            File.Delete(MapPath("~/images/BusinessLogos/" + sNewBusinessLogo));
                        File.Move(MapPath("~/images/BusinessLogos/" + sBusinessLogo), MapPath("~/images/BusinessLogos/" + sNewBusinessLogo));
                        sBusinessLogo = sNewBusinessLogo;
                    }
                    dl.UpdateMemberEmail(lbxMembers.SelectedValue, tbxEmail.Text, sPersonalAvatar, sBusinessLogo);
                    if (User.Identity.Name.ToUpper() == lbxMembers.SelectedValue.ToUpper())
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.SetAuthCookie(tbxEmail.Text, false);
                    }
                }
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Member Updated";
                Session["resultMessage"] = "Member Updated Successfuly ";
                Session["resultReturnURL"] = "ManageMembers.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxAdmin_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxAdmin.Checked)
        {
            ddlArticleColumn.SelectedIndex = 0;
            ddlArticleColumn.Enabled = false;
            cbxModerator.Checked = false;
            cbxModerator.Enabled = false;
            cbxCanPostBlog.Checked = false;
            cbxCanPostBlog.Enabled = false;
        }
        else
        {
            ddlArticleColumn.Enabled = true;
            cbxModerator.Enabled = true;
            cbxCanPostBlog.Enabled = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lbxMembers.Items.Clear();
        DataLayer dl = new DataLayer();
        DataTable dtMembers = dl.GetMemberNamesAndEmailsBy_SearchTerm(tbxSearch.Text);
        nummembers.InnerText = dtMembers.Rows.Count.ToString();
        foreach (DataRow dr in dtMembers.Rows)
        {
            ListItem li = new ListItem(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
            lbxMembers.Items.Add(li);
        }
    }
}
