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
using System.Net.Mail;
using System.Data.SqlClient;

public partial class ManageBlogs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (!this.IsPostBack)
        {
            btnAddNewBlog_Click(null, null);

            DataTable dt = dl.GetBlogTitlesAndIDs();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
                lbxBlogs.Items.Add(li);
            }
            numblogs.InnerText = lbxBlogs.Items.Count.ToString();
        }

        if (User.Identity.IsAuthenticated)
        {
            if (!dl.IsMemberAdmin(User.Identity.Name) && (dl.CanMemberPostBlog(User.Identity.Name)))
            {
                lbxBlogs.Enabled = false;
                btnAddNewBlog.Enabled = false;
            }
            else if (!dl.IsMemberAdmin(User.Identity.Name) && (!dl.CanMemberPostBlog(User.Identity.Name)))
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
            Session["resultReturnURL"] = "ManageBlogs.aspx";
            Response.Redirect("Result.aspx");
        }
    }

    protected void lbxBlogs_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Blog";
        DataLayer dl = new DataLayer();
        DataTable dtBlog = dl.GetBlogBy_BlogID(Convert.ToInt32(lbxBlogs.SelectedValue));
        cbxDeleteBlog.Visible = true;
        spanAuthor.InnerText = dl.GetFullMemberNameBy_Email(dtBlog.Rows[0].ItemArray[1].ToString());
        tbxTitle.Text = dtBlog.Rows[0].ItemArray[3].ToString();
        rteBody.Value = dtBlog.Rows[0].ItemArray[4].ToString();
        ddlAccessLevel.SelectedIndex = ddlAccessLevel.Items.IndexOf(new ListItem(dtBlog.Rows[0].ItemArray[5].ToString()));
        postedby.Visible = true;
    }

    protected void btnAddNewBlog_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Blog";
        lbxBlogs.SelectedIndex = -1;
        cbxDeleteBlog.Visible = false;
        rteBody.Value = "";
        tbxTitle.Text = "";
        postedby.Visible = false;
        ddlAccessLevel.SelectedIndex = 0;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxBlogs.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            DateTime dtPostTime = DateTime.Now;
            dl.AddBlog(User.Identity.Name, dtPostTime, tbxTitle.Text, rteBody.Value, ddlAccessLevel.SelectedValue);
            SqlCommand sc = new SqlCommand("SELECT BlogID FROM rnxBlogs WHERE Title=@Title AND Date=@Date");
            sc.Parameters.Add(new SqlParameter("Title", tbxTitle.Text));
            sc.Parameters.Add(new SqlParameter("Date", dtPostTime));
            DataSet ds = dl.CustomQuery(sc);

            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create("http://tinyurl.com/api-create.php?url=http://www.ReferralNetworX.com/Blog.aspx?bid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString());
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sURL = objReader.ReadToEnd();

                Yedda.Twitter t = new Yedda.Twitter();
                t.Update("ReferralNetworX", "1million!", "New RNX Blog: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("Chevex", "Ch3vyF0rd!", "New RNX Blog: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("WALTatRNX", "robinwalt98", "New RNX Blog: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
            }
            catch
            {

            }

            SmtpClient smtp = new SmtpClient("localhost");
            MailMessage mm;
            mm = new MailMessage();
            mm.IsBodyHtml = true;
            mm.To.Add("Alex@ReferralNetworX.com");
            mm.To.Add("Walt@ReferralNetworX.com");
            mm.From = new MailAddress("NoReply@ReferralNetworX.com");
            mm.Subject = "Someone posted a blog.";
            mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " posted a blog titled: " + tbxTitle.Text;
            mm.Body += "<br /><a href=\"http://www.referralnetworx.com/Blog.aspx?bid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "\">Click to view</a>";
            mm.Body += "<br /><br />The blog is below:<br /><br />" + rteBody.Value;
            smtp.Send(mm);

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Blog Added";
            Session["resultMessage"] = "Blog Added Successfuly";
            Session["resultReturnURL"] = "Blog.aspx?bid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteBlog.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteBlog(Convert.ToInt32(lbxBlogs.SelectedValue));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Blog Deleted";
                Session["resultMessage"] = "Blog Deleted Successfuly";
                Session["resultReturnURL"] = "ManageBlogs.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateBlog(Convert.ToInt32(lbxBlogs.SelectedValue), tbxTitle.Text, rteBody.Value, ddlAccessLevel.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Blog Updated";
                Session["resultMessage"] = "Blog Updated Successfuly";
                Session["resultReturnURL"] = "ManageBlogs.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeleteBlog_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteBlog.Checked)
        {
            tbxTitle.Enabled = false;
            //rteBody.Enabled = false;
            ddlAccessLevel.Enabled = false;
        }
        else
        {
            tbxTitle.Enabled = true;
            //rteBody.Enabled = true;
            ddlAccessLevel.Enabled = true;
        }
    }

    //protected void btnAddImage_Click(object sender, EventArgs e)
    //{
    //    rteBody.Text += "<img src=\"MakeThumbnail.aspx?size=550&image=" + imageBrowser1.ImageDirectory + "/" + imageBrowser1.SelectedImage + "\" />";
    //}
}
