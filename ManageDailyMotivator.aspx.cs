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
using System.Net.Mail;
using System.Threading;

public partial class ManageDailyMotivator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        DateTime dtLastMotivatorDate = dl.GetLastMotivatorDate();

        if (DateTime.Now > dtLastMotivatorDate.Add(new TimeSpan(0, 12, 0, 0)))
        {
            btnSendMotivator.Enabled = true;
        }
        else
        {
            btnSendMotivator.Enabled = false;
        }

        if (!this.IsPostBack)
        {
            btnAddNewDailyMotivator_Click(null, null);

            DataTable dt = dl.GetDailyMotivatorTitlesAndIDs();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
                lbxDailyMotivators.Items.Add(li);
            }
            nummotivators.InnerText = lbxDailyMotivators.Items.Count.ToString();
        }

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
        }
        else
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Not Logged In";
            Session["resultMessage"] = "You must log in first.";
            Session["resultReturnURL"] = "ManageDailyMotivator.aspx";
            Response.Redirect("Result.aspx");
        }
    }

    protected void lbxDailyMotivators_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Daily Motivator";
        DataLayer dl = new DataLayer();
        DataTable dtDailyMotivator = dl.GetDailyMotivatorBy_MotivatorID(Convert.ToInt32(lbxDailyMotivators.SelectedValue));
        cbxDeleteDailyMotivator.Visible = true;
        tbxTitle.Text = dtDailyMotivator.Rows[0].ItemArray[3].ToString();
        rteBody.Value = dtDailyMotivator.Rows[0].ItemArray[4].ToString();
        tbxYouTubeLink.Text = dtDailyMotivator.Rows[0].ItemArray[5].ToString();
    }

    protected void btnAddNewDailyMotivator_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Daily Motivator";
        lbxDailyMotivators.SelectedIndex = -1;
        cbxDeleteDailyMotivator.Visible = false;
        rteBody.Value = "";
        tbxTitle.Text = "";
        tbxYouTubeLink.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxDailyMotivators.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            DateTime dtPostTime = DateTime.Now;
            string sYouTubeLink = "No Video.";
            if (tbxYouTubeLink.Text != "")
            {
                sYouTubeLink = tbxYouTubeLink.Text;
            }
            dl.AddDailyMotivator(dtPostTime, tbxTitle.Text, sYouTubeLink, rteBody.Value);
            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Daily Motivator Added";
            Session["resultMessage"] = "Daily Motivator Added Successfuly";
            Session["resultReturnURL"] = "ManageDailyMotivator.aspx";
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteDailyMotivator.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteDailyMotivator(Convert.ToInt32(lbxDailyMotivators.SelectedValue));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Daily Motivator Deleted";
                Session["resultMessage"] = "Daily Motivator Deleted Successfuly";
                Session["resultReturnURL"] = "ManageDailyMotivator.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                string sYouTubeLink = "No Video.";
                if (tbxYouTubeLink.Text != "")
                {
                    sYouTubeLink = tbxYouTubeLink.Text;
                }
                dl.UpdateDailyMotivator(Convert.ToInt32(lbxDailyMotivators.SelectedValue), tbxTitle.Text, sYouTubeLink, rteBody.Value);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Daily Motivator Updated";
                Session["resultMessage"] = "Daily Motivator Updated Successfuly";
                Session["resultReturnURL"] = "ManageDailyMotivator.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeleteDailyMotivator_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteDailyMotivator.Checked)
        {
            tbxTitle.Enabled = false;
            tbxYouTubeLink.Enabled = false;
        }
        else
        {
            tbxTitle.Enabled = true;
            tbxYouTubeLink.Enabled = true;
        }
    }

    protected void btnSendMotivator_Click(object sender, EventArgs e)
    {
        Thread t = new System.Threading.Thread(new ThreadStart(SendEmails));
        t.Start();

        //SendEmails();

        Session["resultColor"] = "#007700";
        Session["resultTitle"] = "Motivator Sent";
        Session["resultMessage"] = "The Daily Motivator is sending.<br />It could take a few hours depending on the number of subscribers.";
        Session["resultReturnURL"] = "ManageDailyMotivator.aspx";
        Response.Redirect("Result.aspx", true);
    }

    protected void SendEmails()
    {
        try
        {
            SmtpClient smtp = new SmtpClient("localhost");
            MailMessage mm;
            DataLayer dl = new DataLayer();
            DataTable dt = dl.GetAllMotivatorSubscribedMembers();
            DataTable dt2 = dl.GetAllMotivatorSubscribedNonMembers();
            DataTable dtMotivator = dl.GetLastUnSentDailyMotivator();
            int iDailyMotivatorID = Convert.ToInt32(dtMotivator.Rows[0].ItemArray[0]);
            dl.MarkDailyMotivatorSent(iDailyMotivatorID);
            dl.UpdateLastMotivatorDate(DateTime.Now);

            ArrayList alFail = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    mm = new MailMessage();
                    mm.IsBodyHtml = true;
                    mm.To.Add(dr.ItemArray[1].ToString());
                    mm.From = new MailAddress("noreply@referralnetworx.com");
                    mm.Subject = dtMotivator.Rows[0].ItemArray[3].ToString();
                    mm.Body = "<div style=\"width: 790px; background-color: #333333; padding: 5px; border: solid 1px #333333;\"><a href=\"http://www.ReferralNetworX.com\"><img style=\"height: 125px; border-width:0px;\" src=\"http://www.referralnetworx.com/MakeThumbnail.aspx?size=237&image=images/networking.jpg\" /><img style=\"border-width:0px;\" src=\"http://www.referralnetworx.com/images/banner.jpg\" /></a></div>";
                    mm.Body += "<div style=\"width: 770px; background-color: #ddeedd; padding: 15px; border: solid 1px #333333;\"><div style=\"font-size:35px;text-align:center;margin-bottom:10px;\">Daily Motivator</div>";
                    string sName = dl.GetMemberNameBy_Email(dr.ItemArray[1].ToString());
                    mm.Body += "Hello " + sName + ",<br /><br />";
                    string sYouTubeLink = dtMotivator.Rows[0].ItemArray[5].ToString();
                    if (sYouTubeLink != "No Video.")
                    {
                        mm.Body += "<h1 style=\"text-align:center;\"><a href=\"" + sYouTubeLink + "\">Click Here to Watch The Video Motivator</a></h1>";
                    }
                    mm.Body += dtMotivator.Rows[0].ItemArray[4].ToString();
                    mm.Body += "<h2 style=\"text-align:center;\"><a href=\"http://www.ReferralNetworX.com\">Visit ReferralNetworX.com!</a></h2>";
                    mm.Body += "</div>";
                    int iCount = 0;
                    bool bLoop = true;
                    while (bLoop)
                    {
                        try
                        {
                            smtp.Send(mm);
                            bLoop = false;
                        }
                        catch (Exception ex)
                        {
                            System.Threading.Thread.Sleep(1000);
                            iCount++;
                            if (iCount >= 3)
                            {
                                alFail.Add(dr.ItemArray[0].ToString() + " - FAILED ON SEND");
                                alFail.Add(ex.ToString());
                                bLoop = false;
                            }
                        }
                    }
                }
                catch (Exception ex2)
                {
                    alFail.Add(dr.ItemArray[0].ToString() + " - FAILED BEFORE SEND");
                    alFail.Add(ex2.ToString());
                }
            }
            foreach (DataRow dr in dt2.Rows)
            {
                try
                {
                    mm = new MailMessage();
                    mm.IsBodyHtml = true;
                    mm.To.Add(dr.ItemArray[1].ToString());
                    mm.From = new MailAddress("noreply@ReferralNetworX.com");
                    mm.Subject = dtMotivator.Rows[0].ItemArray[3].ToString();
                    mm.Body = "<div style=\"width: 790px; background-color: #333333; padding: 5px; border: solid 1px #333333;\"><a href=\"http://www.ReferralNetworX.com\"><img style=\"height: 125px;border-width:0px;\" src=\"http://www.referralnetworx.com/MakeThumbnail.aspx?size=237&image=images/networking.png\" /><img style=\"border-width:0px;\" src=\"http://www.referralnetworx.com/images/banner.png\" /></a></div>";
                    mm.Body += "<div style=\"width: 770px; background-color: #ddeedd; padding: 15px; border: solid 1px #333333;\"><div style=\"font-size:35px;text-align:center;margin-bottom:10px;\">Daily Motivator</div>";
                    string sName = dl.GetNonMemberNameBy_Email(dr.ItemArray[1].ToString());
                    mm.Body += "Hello " + sName + ",<br /><br />";
                    string sYouTubeLink = dtMotivator.Rows[0].ItemArray[5].ToString();
                    if (sYouTubeLink != "No Video.")
                    {
                        mm.Body += "<h1 style=\"text-align:center;\"><a href=\"" + sYouTubeLink + "\">Click Here to Watch The Video Motivator</a></h1>";
                    }
                    mm.Body += dtMotivator.Rows[0].ItemArray[4].ToString();
                    mm.Body += "<h2 style=\"text-align:center;\"><a href=\"http://www.ReferralNetworX.com\">Visit ReferralNetworX.com!</a></h2>";
                    mm.Body += "</div>";
                    mm.Body += "<div style=\"font-size: 12px; border: solid 1px #333333; background-color: #ddeedd; padding: 5px; width: 790px;\">Click <a href=\"http://www.referralnetworx.com/Subscribe.aspx?e=" + dr.ItemArray[1].ToString() + "&type=dailymotivator\">here</a> to unsubscribe.</div>";
                    int iCount = 0;
                    bool bLoop = true;
                    while (bLoop)
                    {
                        try
                        {
                            smtp.Send(mm);
                            bLoop = false;
                        }
                        catch (Exception ex)
                        {
                            System.Threading.Thread.Sleep(1000);
                            iCount++;
                            if (iCount >= 3)
                            {
                                alFail.Add(dr.ItemArray[0].ToString() + " - FAILED ON SEND");
                                alFail.Add(ex.ToString());
                                bLoop = false;
                            }
                        }
                    }
                }
                catch (Exception ex2)
                {
                    alFail.Add(dr.ItemArray[0].ToString() + " - FAILED BEFORE SEND");
                    alFail.Add(ex2.ToString());
                }
            }

            mm = new MailMessage();
            mm.IsBodyHtml = true;
            mm.To.Add("Alex@CodeTunnel.com");
            mm.From = new MailAddress("NoReply@ReferralNetworX.com");
            mm.Subject = "RNX Daily Motivator Failure Report";
            mm.Body = "Number of failures: " + Convert.ToString(alFail.Count / 2) + "<br /><br />";
            foreach (string sFail in alFail)
            {
                mm.Body += sFail + "<br /><br />";
            }
            int iCount2 = 0;
            bool bLoop2 = true;
            while (bLoop2)
            {
                try
                {
                    smtp.Send(mm);
                    bLoop2 = false;
                }
                catch
                {
                    iCount2++;
                    if (iCount2 >= 25)
                    {
                        bLoop2 = false;
                    }
                }
            }
        }
        catch (Exception exc)
        {
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.To.Add("Alex@CodeTunnel.com");
            msg.From = new MailAddress("NoReply@ReferralNetworX.com");
            msg.Subject = "Something went terribly wrong.";
            msg.Body = exc.ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }
    }
}
