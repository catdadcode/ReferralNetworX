using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MissionStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Members Only";
            Session["resultMessage"] = "This is a members only area.<br />You must log in first.";
            Session["resultReturnURL"] = "MissionStatement.aspx";
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
            DataTable dtMissionStatements = dl.GetMissonStatements(User.Identity.Name);
            string sPersonalMissionStatement = dtMissionStatements.Rows[0].ItemArray[0].ToString();
            string sBusinessMissionStatement = dtMissionStatements.Rows[0].ItemArray[1].ToString();
            if (sPersonalMissionStatement.Length > 0)
            {
                string[] sSplit = sPersonalMissionStatement.Split('|');
                tbxPersonalGoals.Text = sSplit[0];
                tbxDefineSuccess.Text = sSplit[1];
                tbxWhatYouBelieve.Text = sSplit[2];
            }
            if (sBusinessMissionStatement.Length > 0)
            {
                string[] sSplit = sBusinessMissionStatement.Split('|');
                tbxBusinessGoals.Text = sSplit[0];
                tbxMoneyThoughts.Text = sSplit[1];
                tbxInBusinessFor.Text = sSplit[2];
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string sPersonal = tbxPersonalGoals.Text + "|" + tbxDefineSuccess.Text + "|" + tbxWhatYouBelieve.Text;
        string sBusiness = tbxBusinessGoals.Text + "|" + tbxMoneyThoughts.Text + "|" + tbxInBusinessFor.Text;
        DataLayer dl = new DataLayer();
        dl.UpdateMissionStatements(User.Identity.Name, sPersonal, sBusiness);
        Session["resultColor"] = "#007700";
        Session["resultTitle"] = "Success";
        Session["resultMessage"] = "Mission statements updated successfully!";
        Session["resultReturnURL"] = "MissionStatement.aspx";
        Response.Redirect("Result.aspx", true);
    }
}
