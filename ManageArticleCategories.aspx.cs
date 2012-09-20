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

public partial class ManageCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (!this.IsPostBack)
        {
            btnAddNewCategory_Click(null, null);

            DataTable dt = dl.GetCategories();
            foreach (DataRow dr in dt.Rows)
            {
                lbxCategories.Items.Add(dr.ItemArray[0].ToString());
            }
            numCategories.InnerText = lbxCategories.Items.Count.ToString();

            DataTable dtParents = dl.GetParentCategories();
            foreach (DataRow dr in dtParents.Rows)
            {
                ddlParentCategory.Items.Add(dr.ItemArray[0].ToString());
            }
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
            Session["resultReturnURL"] = "ManageArticleCategories.aspx";
            Response.Redirect("Result.aspx");
        }
    }

    protected void lbxCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Category";
        DataLayer dl = new DataLayer();
        cbxDeleteCategory.Visible = true;
        tbxCategory.Text = lbxCategories.SelectedValue;
        string sParentCategory = dl.GetParentCategory(lbxCategories.SelectedValue);
        ddlParentCategory.SelectedIndex = ddlParentCategory.Items.IndexOf(ddlParentCategory.Items.FindByValue(sParentCategory));
    }

    protected void btnAddNewCategory_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Category";
        lbxCategories.SelectedIndex = -1;
        cbxDeleteCategory.Visible = false;
        tbxCategory.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxCategories.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            dl.AddCategory(tbxCategory.Text, ddlParentCategory.SelectedValue);

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Article Category Added";
            Session["resultMessage"] = "Article Category Added Successfuly";
            Session["resultReturnURL"] = "ManageArticleCategories.aspx";
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteCategory.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteCategory(lbxCategories.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Article Category Deleted";
                Session["resultMessage"] = "Article Category Deleted Successfuly";
                Session["resultReturnURL"] = "ManageArticleCategories.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateCategory(lbxCategories.SelectedValue, tbxCategory.Text, ddlParentCategory.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Article Category Updated";
                Session["resultMessage"] = "Article Category Updated Successfuly";
                Session["resultReturnURL"] = "ManageArticleCategories.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeleteCategory_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteCategory.Checked)
        {
            tbxCategory.Enabled = false;
        }
        else
        {
            tbxCategory.Enabled = true;
        }
    }
}
