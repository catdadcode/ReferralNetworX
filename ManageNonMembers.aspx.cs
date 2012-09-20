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

public partial class ManageMembers : System.Web.UI.Page
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
            Session["resultReturnURL"] = "ManageNonMembers.aspx";
            Response.Redirect("Result.aspx", true);
        }

        if (!this.IsPostBack)
        {
            btnAddNewNonMember_Click(null, null);

            DataTable dt = dl.GetNonMemberNamesAndEmails();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
                lbxNonMembers.Items.Add(li);
            }
            numnonmembers.InnerText = lbxNonMembers.Items.Count.ToString();
        }
    }

    protected void btnAddNewNonMember_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Non-Member";
        cbxDeleteNonMember.Visible = false;
        lblDeleteNonMember.Visible = false;
        tbxEmail.Text = "";
        tbxName.Text = "";
        cbxDailyMotivator.Checked = false;
        cbxNonMemberNewsletter.Checked = false;
        lbxNonMembers.SelectedIndex = -1;
    }

    protected void lbxNonMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Non-Member";
        string sEmail = lbxNonMembers.SelectedValue;
        DataLayer dl = new DataLayer();
        DataRow drNonMember = dl.GetNonMemberBy_Email(sEmail).Rows[0];
        cbxDeleteNonMember.Visible = true;
        lblDeleteNonMember.Visible = true;
        tbxEmail.Text = drNonMember.ItemArray[0].ToString();
        tbxName.Text = drNonMember.ItemArray[1].ToString();
        cbxDailyMotivator.Checked = Convert.ToBoolean(drNonMember.ItemArray[2]);
        cbxNonMemberNewsletter.Checked = Convert.ToBoolean(drNonMember.ItemArray[3]);
    }

    protected void cbxDeleteNonMember_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteNonMember.Checked)
        {
            tbxEmail.Enabled = false;
            tbxName.Enabled = false;
            cbxDailyMotivator.Enabled = false;
            cbxNonMemberNewsletter.Enabled = false;
        }
        else
        {
            tbxEmail.Enabled = true;
            tbxName.Enabled = true;
            cbxDailyMotivator.Enabled = true;
            cbxNonMemberNewsletter.Enabled = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxNonMembers.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            dl.AddNonMember(tbxEmail.Text, tbxName.Text, cbxDailyMotivator.Checked, cbxNonMemberNewsletter.Checked);
            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Non-Member Added";
            Session["resultMessage"] = "Non-Member Added Successfuly";
            Session["resultReturnURL"] = "ManageNonMembers.aspx";
            Response.Redirect("Result.aspx", true);
        }
        else
        {
            if (cbxDeleteNonMember.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeleteNonMember(lbxNonMembers.SelectedValue);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Non-Member Deleted";
                Session["resultMessage"] = "Non-Member Deleted Successfuly";
                Session["resultReturnURL"] = "ManageNonMembers.aspx";
                Response.Redirect("Result.aspx", true);
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdateNonMember(lbxNonMembers.SelectedValue, tbxEmail.Text, tbxName.Text, cbxDailyMotivator.Checked, cbxNonMemberNewsletter.Checked);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Non-Member Updated";
                Session["resultMessage"] = "Non-Member Updated Successfuly";
                Session["resultReturnURL"] = "ManageNonMembers.aspx";
                Response.Redirect("Result.aspx", true);
            }
        }
    }
}
