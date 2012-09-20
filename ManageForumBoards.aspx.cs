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

public partial class ManageForumBoards : System.Web.UI.Page
{
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
                Response.Redirect("Result.aspx", true);
            }
        }
        else
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Not Logged In";
            Session["resultMessage"] = "You must log in first.";
            Session["resultReturnURL"] = "ManageForumBoards.aspx";
            Response.Redirect("Result.aspx", true);
        }

        if (!this.IsPostBack)
        {
            btnAddNewForumBoard_Click(null, null);

            DataTable dt = dl.GetForumBoardTitlesAndIDs();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr.ItemArray[1].ToString(), dr.ItemArray[0].ToString());
                lbxForumBoards.Items.Add(li);
            }
            numboards.InnerText = lbxForumBoards.Items.Count.ToString();
        }
    }

    protected void btnAddNewForumBoard_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Forum Board";
        cbxDeleteForumBoard.Visible = false;
        tbxTitle.Text = "";
        tbxDescription.Text = "";
        cbxLocked.Checked = false;
        lbxForumBoards.SelectedIndex = -1;
    }

    protected void cbxDeleteForumBoard_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteForumBoard.Checked)
        {
            tbxTitle.Enabled = false;
            tbxDescription.Enabled = false;
            cbxLocked.Enabled = false;
        }
        else
        {
            tbxTitle.Enabled = true;
            tbxDescription.Enabled = true;
            cbxLocked.Enabled = true;
        }
    }

    protected void lbxForumBoards_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Forum Board";
        int iBoardID = Convert.ToInt32(lbxForumBoards.SelectedValue);
        DataLayer dl = new DataLayer();
        DataRow drForumBoard = dl.GetForumBoardBy_BoardID(iBoardID).Rows[0];
        cbxDeleteForumBoard.Visible = true;
        tbxTitle.Text = drForumBoard.ItemArray[1].ToString();
        tbxDescription.Text = drForumBoard.ItemArray[2].ToString();
        cbxLocked.Checked = Convert.ToBoolean(drForumBoard.ItemArray[3]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxForumBoards.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            dl.AddForumBoard(tbxTitle.Text, tbxDescription.Text, cbxLocked.Checked);
            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Forum Board Added";
            Session["resultMessage"] = "Forum Board Added Successfuly";
            Session["resultReturnURL"] = "ManageForumBoards.aspx";
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            if (cbxDeleteForumBoard.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteForumBoard(Convert.ToInt32(lbxForumBoards.SelectedValue));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Forum Board Deleted";
                Session["resultMessage"] = "Forum Board Deleted Successfuly";
                Session["resultReturnURL"] = "ManageForumBoards.aspx";
                Response.Redirect("Result.aspx", true);
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateForumBoard(Convert.ToInt32(lbxForumBoards.SelectedValue), tbxTitle.Text, tbxDescription.Text, cbxLocked.Checked);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Forum Board Updated";
                Session["resultMessage"] = "Forum Board Updated Successfuly";
                Session["resultReturnURL"] = "ManageForumBoards.aspx";
                Response.Redirect("Result.aspx", true);
            }
        }
    }
}
