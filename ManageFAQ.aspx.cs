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

public partial class ManageFAQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (!this.IsPostBack)
        {
            btnAddNewFAQ_Click(null, null);

            DataTable dt = dl.GetFAQQuestionsAndIDs();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
                lbxFAQs.Items.Add(li);
            }
            numFAQs.InnerText = lbxFAQs.Items.Count.ToString();
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
            Session["resultReturnURL"] = "ManageFAQ.aspx";
            Response.Redirect("Result.aspx");
        }
    }

    protected void lbxFAQs_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit FAQ";
        DataLayer dl = new DataLayer();
        DataTable dtFAQ = dl.GetFAQBy_FAQID(Convert.ToInt32(lbxFAQs.SelectedValue));
        cbxDeleteFAQ.Visible = true;
        tbxQuestion.Text = dtFAQ.Rows[0].ItemArray[1].ToString();
        tbxAnswer.Text = dtFAQ.Rows[0].ItemArray[2].ToString().Replace("<br />", "\r\n");
    }

    protected void btnAddNewFAQ_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New FAQ";
        lbxFAQs.SelectedIndex = -1;
        cbxDeleteFAQ.Visible = false;
        tbxQuestion.Text = "";
        tbxAnswer.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxFAQs.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            dl.AddFAQ(tbxQuestion.Text, tbxAnswer.Text.Replace("\r", "<br />").Replace("\n", ""));

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "FAQ Added";
            Session["resultMessage"] = "FAQ Added Successfuly";
            Session["resultReturnURL"] = "ManageFAQ.aspx";
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteFAQ.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteFAQ(Convert.ToInt32(lbxFAQs.SelectedValue));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "FAQ Deleted";
                Session["resultMessage"] = "FAQ Deleted Successfuly";
                Session["resultReturnURL"] = "ManageFAQ.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateFAQ(Convert.ToInt32(lbxFAQs.SelectedValue), tbxQuestion.Text, tbxAnswer.Text.Replace("\r", "<br />").Replace("\n", ""));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "FAQ Updated";
                Session["resultMessage"] = "FAQ Updated Successfuly";
                Session["resultReturnURL"] = "ManageFAQ.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeleteFAQ_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteFAQ.Checked)
        {
            tbxQuestion.Enabled = false;
            tbxAnswer.Enabled = false;
        }
        else
        {
            tbxQuestion.Enabled = true;
            tbxAnswer.Enabled = true;
        }
    }
}
