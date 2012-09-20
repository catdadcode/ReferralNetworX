using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TomorrowPlanner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Members Only";
            Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
            Session["resultReturnURL"] = "SuccessMeter.aspx";
            Response.Redirect("Result.aspx", true);
        }

        DataLayer dl = new DataLayer();
        loggedinpanels.Controls.Add(new LiteralControl("<div style=\"width:250px;\" class=\"contenttitle\">Featured Member</div><div class=\"contentpanel\">"));
        DataTable dtRandomMember = dl.GetRandomMember();
        loggedinpanels.Controls.Add(new LiteralControl("<table style=\"width:100%;\"><tr><td style=\"font-size:13px;text-align:center;\"><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\"><img style=\"border-width:0px;\" src=\"MakeThumbnail.aspx?size=100&image=images/MemberAvatars/" + dtRandomMember.Rows[0].ItemArray[3].ToString() + "\" /></a><br /><a href=\"Profile.aspx?member=" + dtRandomMember.Rows[0].ItemArray[0].ToString() + "\">View Profile</a></td><td style=\"padding-left:5px;font-size:13px;width:100%;\"><b>Name:</b> " + dtRandomMember.Rows[0].ItemArray[2].ToString() + "<br /><br /><b>Location:</b> " + dtRandomMember.Rows[0].ItemArray[17].ToString() + "<br /><br /><b>Business:</b> " + dtRandomMember.Rows[0].ItemArray[8].ToString() + "<br /><br />"));
        if (dtRandomMember.Rows[0].ItemArray[6].ToString() != "")
        {
            loggedinpanels.Controls.Add(new LiteralControl("<center><a href=\"" + dtRandomMember.Rows[0].ItemArray[6].ToString() + "\">Visit Website</a></center>"));
        }
        loggedinpanels.Controls.Add(new LiteralControl("</td></tr></table></div>"));
        DataTable dtMemberAd = dl.GetRandomAd();
        loggedinpanels.Controls.Add(new LiteralControl("<div class=\"contenttitle\">Member Ad</div><div style=\"text-align:center;\" class=\"contentpanel\"><a href=\"" + dtMemberAd.Rows[0].ItemArray[2].ToString() + "\"><img style=\"width:230px; border-width:0px;\" src=\"" + dtMemberAd.Rows[0].ItemArray[1].ToString() + "\" /></a></div>"));

        if (!this.IsPostBack)
        {
            DataTable dtTomorrowsPlan = dl.GetTPEntryBy_UserAndDate(User.Identity.Name, DateTime.Now.AddDays(1).Date);
            if (dtTomorrowsPlan.Rows.Count > 0)
            {
                tbxTomorrowsPlan.Text = dtTomorrowsPlan.Rows[0].ItemArray[3].ToString();
                btnUpdate.Text = "Save Changes";
            }
            else
            {
                btnUpdate.Text = "Save";
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        DataTable dtTomorrowsPlan = dl.GetTPEntryBy_UserAndDate(User.Identity.Name, DateTime.Now.AddDays(1).Date);
        if (dtTomorrowsPlan.Rows.Count > 0)
        {
            int iEntryID = Convert.ToInt32(dtTomorrowsPlan.Rows[0].ItemArray[0]);
            dl.UpdateTPEntry(iEntryID, tbxTomorrowsPlan.Text);
            Session["resultMessage"] = "Your plan for tomorrow was updated successfuly!";
        }
        else
        {
            dl.AddTPEntry(User.Identity.Name, DateTime.Now.AddDays(1).Date, tbxTomorrowsPlan.Text);
            Session["resultMessage"] = "Your plan for tomorrow was created successfully!";
        }
        Session["resultColor"] = "#007700";
        Session["resultTitle"] = "Success";
        Session["resultReturnURL"] = "TomorrowPlanner.aspx";
        Response.Redirect("Result.aspx", true);
    }
}
