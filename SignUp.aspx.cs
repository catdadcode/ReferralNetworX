using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;

public partial class SignUp : System.Web.UI.Page
{
    Random rand = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.UserHostAddress != "98.202.119.104")
        //{
        //    Session["resultColor"] = "#ff0000";
        //    Session["resultTitle"] = "Sign Up Disabled";
        //    Session["resultMessage"] = "Sign up page is temporarily disabled for today 3/13/2010 while we perform maintenance on the site. Memberships will be available again tomorrow 3/14/2010.";
        //    Session["resultReturnURL"] = "Default.aspx";
        //    Response.Redirect("Result.aspx", true);
        //}

        //if (!Request.IsSecureConnection)
        //{
        //    Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"), true);
        //}

        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("EditProfile.aspx", true);
        }

        if (!this.IsPostBack)
        {
            signupform.Visible = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        this.Validate("signup");
        if (Page.IsValid)
        {
            if (cbxAgree.Checked)
            {
                DataLayer dl = new DataLayer();
                if (!dl.EmailExists(tbxEmail.Text))
                {

                    //SmtpClient smtp = new SmtpClient("localhost");
                    
                    //MailMessage mm;

                        dl.AddMember(tbxEmail.Text, tbxPassword.Text, tbxName.Text, "no_avatar.gif", "", "", "", "", "", "no_logo.gif", "", DateTime.Now, "", "", "", "", "", "", false, false, false, true, true, false, false, "", "", "Not Specified", 0, DateTime.Now, "Not Selected", "#77BB77,#ffffff,#DDFFDD,#444444,#1985b5,#77BB77,#ffffff,#ffffff,#000000,#0000EE,#CCDDCC", "None", "", "");

                        #region -= Add Comments to New Member Profile =-

                        int iPerson = rand.Next(2);
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

                            //mm = new MailMessage();
                            //mm.IsBodyHtml = true;
                            //mm.To.Add(tbxEmail.Text);
                            //mm.From = new MailAddress("NoReply@ReferralNetworX.com");
                            //mm.Subject = "Someone posted a comment on your profile!";
                            //mm.Body = "Alex Ford posted a comment on your profile.";
                            //mm.Body += "<br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + tbxEmail.Text + "\">Click to view</a>";
                            //smtp.Send(mm);
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

                            //mm = new MailMessage();
                            //mm.IsBodyHtml = true;
                            //mm.To.Add(tbxEmail.Text);
                            //mm.From = new MailAddress("NoReply@ReferralNetworX.com");
                            //mm.Subject = "Someone posted a comment on your profile!";
                            //mm.Body = "Walt Ford posted a comment on your profile.";
                            //mm.Body += "<br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + tbxEmail.Text + "\">Click to view</a>";
                            //smtp.Send(mm);
                        }

                        #endregion

                        #region -= Email notifcation of new member =-

                        //mm = new MailMessage();
                        //mm.IsBodyHtml = true;
                        //mm.To.Add("Alex@ReferralNetworX.com");
                        //mm.To.Add("Walt@ReferralNetworX.com");
                        //mm.From = new MailAddress("NoReply@ReferralNetworX.com");
                        //mm.Subject = "Someone signed up on ReferralNetworX.com!";
                        //mm.Body = tbxName.Text + " signed up on ReferralNetworX.com.";
                        //mm.Body += "<br /><br />How they heard about us: " + ddlHeardAboutUs.SelectedValue;
                        //mm.Body += "<br /><br /><a href=\"http://www.referralnetworx.com/profile.aspx?member=" + tbxEmail.Text + "\">Click to view</a>";
                        //smtp.Send(mm);

                        //mm = new MailMessage();
                        //mm.IsBodyHtml = true;
                        //mm.To.Add(tbxEmail.Text);
                        //mm.From = new MailAddress("NoReply@ReferralNetworX.com");
                        //mm.Subject = "Welcome to ReferralNetworX.com!";
                        //mm.Body = "Welcome " + dl.GetMemberNameBy_Email(tbxEmail.Text) + ",<br /><br />";
                        //mm.Body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We are dedicated to helping you and your business succeed. I truly hope RNX helps you to grow to new heights and accomplish your goals. I am confident that you will provide a lot of value to the RNX community and that your knowledge will benefit everyone! Please <a href=\"http://www.referralnetworx.com/referralnetworx/Topic.aspx?topic=50\">visit our forums to say hi</a> to fellow members and get to know everyone. Also, be sure to log in and edit your profile. The more information you provide about yourself and your business, the more you will get noticed and more opportunities will be presented to you.<br /><br />Alex Ford<br />Referral NetworX Administrator";
                        //smtp.Send(mm);

                        #endregion

                        try
                        {
                            dl.DeleteNonMember(tbxEmail.Text);
                        }
                        catch { }

                        FormsAuthentication.SetAuthCookie(tbxEmail.Text, false);
                        Response.Redirect("~/");
                }
                else
                {
                    CustomValidator1.IsValid = false;
                }
            }
            else
            {
                CustomValidator2.IsValid = false;
            }
        }
    }
}
