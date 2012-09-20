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

public partial class ManageGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();

        if (!this.IsPostBack)
        {
            btnAddNewGroup_Click(null, null);

            DataTable dt = dl.GetGroups();
            foreach (DataRow dr in dt.Rows)
            {
                lbxGroups.Items.Add(dr.ItemArray[0].ToString());
            }
            numGroups.InnerText = lbxGroups.Items.Count.ToString();


            if (User.Identity.IsAuthenticated)
            {
                if (!dl.IsMemberAdmin(User.Identity.Name))
                {
                    if (dl.IsMemberGroupLeader(User.Identity.Name))
                    {
                        string sGroup = dl.GetMemberGroupBy_Email(User.Identity.Name);
                        lbxGroups.SelectedIndex = lbxGroups.Items.IndexOf(new ListItem(sGroup));
                        lbxGroups.Enabled = false;
                        tbxGroupName.Enabled = false;
                        ddlState.Enabled = false;
                        btnAddNewGroup.Enabled = false;
                        lbxGroups_SelectedIndexChanged(null, null);
                        cbxDeleteGroup.Visible = false;
                    }
                    else
                    {
                        Session["resultColor"] = "#ff0000";
                        Session["resultTitle"] = "Not Authorized";
                        Session["resultMessage"] = "You are not authorized to access this area.";
                        Session["resultReturnURL"] = "Default.aspx";
                        Response.Redirect("Result.aspx");
                    }
                }
            }
            else
            {
                Session["resultColor"] = "#ff0000";
                Session["resultTitle"] = "Not Logged In";
                Session["resultMessage"] = "You must log in first.";
                Session["resultReturnURL"] = "ManageGroups.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void lbxGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Group";
        DataLayer dl = new DataLayer();
        DataTable dtGroup = dl.GetGroupBy_GroupName(lbxGroups.SelectedValue);
        cbxDeleteGroup.Visible = true;
        tbxGroupName.Text = dtGroup.Rows[0].ItemArray[0].ToString();
        rteBody.Value = dtGroup.Rows[0].ItemArray[1].ToString();
        ddlState.SelectedIndex = ddlState.Items.IndexOf(new ListItem(dtGroup.Rows[0].ItemArray[2].ToString()));

    }

    protected void btnAddNewGroup_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Group";
        lbxGroups.SelectedIndex = -1;
        cbxDeleteGroup.Visible = false;
        tbxGroupName.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxGroups.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            dl.AddGroup(tbxGroupName.Text, rteBody.Value, ddlState.SelectedValue);

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Group Added";
            Session["resultMessage"] = "Group Added Successfuly";
            Session["resultReturnURL"] = "ManageGroups.aspx";
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeleteGroup.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteGroup(lbxGroups.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Group Deleted";
                Session["resultMessage"] = "Group Deleted Successfuly";
                Session["resultReturnURL"] = "ManageGroups.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateGroup(lbxGroups.SelectedValue, tbxGroupName.Text, rteBody.Value, ddlState.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Group Updated";
                Session["resultMessage"] = "Group Updated Successfuly";
                Session["resultReturnURL"] = "ManageGroups.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeleteGroup_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteGroup.Checked)
        {
            tbxGroupName.Enabled = false;
        }
        else
        {
            tbxGroupName.Enabled = true;
        }
    }
}
