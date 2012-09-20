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
using System.Data.SqlClient;
using System.Net.Mail;

public partial class ManageArticles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (User.Identity.IsAuthenticated)
        {
            if ((dl.MemberArticleColumn(User.Identity.Name) == "None") && (!dl.IsMemberAdmin(User.Identity.Name)))
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
            Session["resultReturnURL"] = "ManageArticles.aspx";
            Response.Redirect("Result.aspx");
        }

        if (Request.Cookies["ReadArticleGuidelines"] == null)
        {
            Response.Redirect("ArticleChecklist.aspx", true);
        }

        if (!this.IsPostBack)
        {
            DataTable dtCategories = dl.GetCategories();
            foreach (DataRow dr in dtCategories.Rows)
            {
                ddlCategory.Items.Add(dr.ItemArray[0].ToString());
            }

            string sArticleCategory = dl.MemberArticleColumn(User.Identity.Name);
            if ((sArticleCategory != "None") && (!dl.IsMemberAdmin(User.Identity.Name)))
            {
                for (int iCount = 0; iCount < ddlCategory.Items.Count; iCount++)
                {
                    if (sArticleCategory == ddlCategory.Items[iCount].ToString())
                    {
                        ddlCategory.SelectedIndex = iCount;
                        ddlCategory.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                ddlCategory.SelectedIndex = 0;
            }

            ddlCategory_SelectedIndexChanged(null, null);
        }
    }

    protected void lbxArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
        checklist.Visible = false;
        cbxDeleteArticle.Checked = false;
        cbxDeleteArticle_CheckedChanged(null, null);
        addedit.InnerText = "Edit Article";
        DataLayer dl = new DataLayer();
        DataTable dtArticle = dl.GetArticleBy_ArticleID(Convert.ToInt32(lbxArticles.SelectedValue));
        cbxDeleteArticle.Visible = true;
        spanAuthor.InnerText = dl.GetFullMemberNameBy_Email(dtArticle.Rows[0].ItemArray[4].ToString());
        tbxTitle.Text = dtArticle.Rows[0].ItemArray[2].ToString();
        rteBody.Value = dtArticle.Rows[0].ItemArray[3].ToString();
        postedby.Visible = true;
        cbxDiscussionThread.Checked = false;
        cbxDiscussionThread.Visible = false;
    }

    protected void btnAddNewArticle_Click(object sender, EventArgs e)
    {
        checklist.Visible = true;
        addedit.InnerText = "Add New Article";
        lbxArticles.SelectedIndex = -1;
        cbxDeleteArticle.Visible = false;
        rteBody.Value = "";
        tbxTitle.Text = "";
        postedby.Visible = false;
        cbxDiscussionThread.Visible = true;
        cbxDiscussionThread.Checked = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxArticles.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            DateTime dtPostTime = DateTime.Now;
            dl.AddArticle(dtPostTime, tbxTitle.Text, rteBody.Value, User.Identity.Name, ddlCategory.SelectedValue);
            SqlCommand sc = new SqlCommand("SELECT ArticleID FROM rnxArticles WHERE Title=@Title AND Date=@Date");
            sc.Parameters.Add(new SqlParameter("Title", tbxTitle.Text));
            sc.Parameters.Add(new SqlParameter("Date", dtPostTime));
            DataSet ds = dl.CustomQuery(sc);

            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create("http://tinyurl.com/api-create.php?url=http://www.ReferralNetworX.com/Article.aspx?aid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString());
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sURL = objReader.ReadToEnd();

                Yedda.Twitter t = new Yedda.Twitter();
                t.Update("ReferralNetworX", "1million!", "New RNX Article: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("Chevex", "Ch3vyF0rd!", "New RNX Article: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                t.Update("WALTatRNX", "robinwalt98", "New RNX Article: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
            }
            catch
            { }

            if (cbxDiscussionThread.Checked)
            {
                dl.AddForumTopic(14, User.Identity.Name, tbxTitle.Text, "<a href=\"Article.aspx?aid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "\">Click to view article</a><br /><br />Discuss this article below.", dtPostTime, false, false);
                SqlCommand sc2 = new SqlCommand("SELECT TopicID FROM rnxForumTopics WHERE Title=@Title AND Date=@Date");
                sc2.Parameters.Add(new SqlParameter("Title", tbxTitle.Text));
                sc2.Parameters.Add(new SqlParameter("Date", dtPostTime));
                DataSet ds2 = dl.CustomQuery(sc2);
                string sTopicID = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
                dl.UpdateArticle(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]), tbxTitle.Text, rteBody.Value + "<br /><br /><a href=\"Topic.aspx?topic=" + sTopicID + "\">Click to discuss this article</a>");
            }

            SmtpClient smtp = new SmtpClient("localhost");
            MailMessage mm;
            mm = new MailMessage();
            mm.IsBodyHtml = true;
            mm.To.Add("Alex@ReferralNetworX.com");
            mm.To.Add("Walt@ReferralNetworX.com");
            mm.From = new MailAddress("NoReply@ReferralNetworX.com");
            mm.Subject = "Someone posted an article.";
            mm.Body = dl.GetFullMemberNameBy_Email(User.Identity.Name) + " posted an article titled: " + tbxTitle.Text;
            mm.Body += "<br /><a href=\"http://www.referralnetworx.com/Article.aspx?aid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "\">Click to view</a>";
            mm.Body += "<br /><br />The article is below:<br /><br />" + rteBody.Value;
            smtp.Send(mm);

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Article Added";
            Session["resultMessage"] = "Article Added Successfuly";
            Session["resultReturnURL"] = "Article.aspx?aid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteArticle.Checked)
            {
                DataLayer dl = new DataLayer();
                DataTable dtArticle = dl.GetArticleBy_ArticleID(Convert.ToInt32(lbxArticles.SelectedValue));
                try
                {
                    SqlCommand sc = new SqlCommand("SELECT TopicID FROM rnxForumTopics WHERE Title=@Title AND Date=@Date");
                    sc.Parameters.Add(new SqlParameter("Title", dtArticle.Rows[0].ItemArray[2].ToString()));
                    sc.Parameters.Add(new SqlParameter("Date", Convert.ToDateTime(dtArticle.Rows[0].ItemArray[1])));
                    DataSet ds = dl.CustomQuery(sc);
                    dl.DeleteForumTopic(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]));
                }
                catch
                {

                }
                dl.DeleteArticle(Convert.ToInt32(lbxArticles.SelectedValue));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Article Deleted";
                Session["resultMessage"] = "Article Deleted Successfuly";
                Session["resultReturnURL"] = "ManageArticles.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateArticle(Convert.ToInt32(lbxArticles.SelectedValue), tbxTitle.Text, rteBody.Value);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Article Updated";
                Session["resultMessage"] = "Article Updated Successfuly";
                Session["resultReturnURL"] = "ManageArticles.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeleteArticle_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteArticle.Checked)
        {
            tbxTitle.Enabled = false;
        }
        else
        {
            tbxTitle.Enabled = true;
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        lbxArticles.Items.Clear();

        DataTable dt = dl.GetArticleTitlesAndIDsBy_Category(ddlCategory.SelectedValue);
        string sArticleCategory = dl.MemberArticleColumn(User.Identity.Name);
        if ((sArticleCategory != "None") && (!dl.IsMemberAdmin(User.Identity.Name)))
        {
            dt = dl.GetArticleTitlesAndIDsBy_CategoryAndAuthor(ddlCategory.SelectedValue, User.Identity.Name);
        }

        foreach (DataRow dr in dt.Rows)
        {
            ListItem li = new ListItem(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
            lbxArticles.Items.Add(li);
        }
        numarticles.InnerText = lbxArticles.Items.Count.ToString();
        btnAddNewArticle_Click(null, null);
    }
}
