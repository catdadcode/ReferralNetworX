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

public partial class PrintSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        if (User.Identity.IsAuthenticated)
        {
            if ((!dl.IsMemberAdmin(User.Identity.Name)) && (!dl.IsMemberGroupLeader(User.Identity.Name)))
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
            Session["resultReturnURL"] = "ManageGroups.aspx";
            Response.Redirect("Result.aspx");
        }

        string sSheet = Request.QueryString["Sheet"];

        DataTable dtFullMembers = dl.GetFullMembershipNamesEmailsGroups();

        if (sSheet == "Attendance")
        {
            SheetContent.InnerHtml = "<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" style=\"width:700px;\">";
            SheetContent.InnerHtml += "<tr><td colspan=\"4\" style=\"font-size:35px;padding:5px;text-align:center;padding-bottom:15px;font-family:arial;\">RNX Group Attendance Sheet</td></tr>";
            SheetContent.InnerHtml += "<tr><td style=\"padding:3px;text-align:center;font-size:25px;\"><b>Name</b></td><td style=\"padding:3px;text-align:center;font-size:25px;\"><b>Email</b></td><td style=\"padding:3px;text-align:center;font-size:25px;\"><b>Group</b></td><td style=\"padding:3px;text-align:center;font-size:25px;\"><b>Signature</b></td></tr>";
            foreach (DataRow dr in dtFullMembers.Rows)
            {
                SheetContent.InnerHtml += "<tr><td style=\"padding:3px;\">" + dr.ItemArray[0].ToString() + "</td>";
                SheetContent.InnerHtml += "<td style=\"padding:3px;\">" + dr.ItemArray[1].ToString() + "</td>";
                SheetContent.InnerHtml += "<td style=\"padding:3px;\">" + dr.ItemArray[2].ToString() + "</td>";
                SheetContent.InnerHtml += "<td style=\"width:200px;\"></td></tr>";
            }
            SheetContent.InnerHtml += "</table>";
        }
    }
}
