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

public partial class EditProfile : System.Web.UI.Page
{
    string sEmail;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        if (!User.Identity.IsAuthenticated)
        {
            Session["resultColor"] = "#ff0000";
            Session["resultTitle"] = "Not Logged In";
            Session["resultMessage"] = "You must log in first.";
            Session["resultReturnURL"] = "EditProfile.aspx";
            Response.Redirect("Result.aspx");
        }

        if (!this.IsPostBack)
        {
            int iStartYear = DateTime.Now.Year - 105;
            int iEndYear = DateTime.Now.Year - 3;
            for (int iCount = iStartYear; iCount <= iEndYear; iCount++)
            {
                ddlBirthYear.Items.Add(iCount.ToString());
            }

            sEmail = User.Identity.Name;
            if ((dl.IsMemberAdmin(User.Identity.Name) && (Request.QueryString["member"] != null)))
            {
                sEmail = Request.QueryString["member"];
                if (!dl.IsMemberAdmin(User.Identity.Name))
                {
                    sEmail = User.Identity.Name;
                }
            }
            this.ViewState["sEmail"] = sEmail;

            DataRow drMember = dl.GetMemberBy_Email(sEmail).Rows[0];
            lblEmail.Text = drMember.ItemArray[0].ToString();
            tbxName.Text = drMember.ItemArray[2].ToString();
            imgPersonalAvatar.ImageUrl = "MakeThumbnail.aspx?size=150&image=images/MemberAvatars/" + drMember.ItemArray[3].ToString();
            tbxPhone.Text = drMember.ItemArray[4].ToString();
            tbxInterests.Text = drMember.ItemArray[5].ToString().Replace("<br />", "\r\n");
            tbxWebsite.Text = drMember.ItemArray[6].ToString();
            tbxPersonalBio.Text = drMember.ItemArray[7].ToString().Replace("<br />", "\r\n");
            tbxBusinessName.Text = drMember.ItemArray[8].ToString();
            imgBusinessLogo.ImageUrl = "MakeThumbnail.aspx?size=150&image=images/BusinessLogos/" + drMember.ItemArray[9].ToString();
            tbxBusinessBio.Text = drMember.ItemArray[10].ToString().Replace("<br />", "\r\n");
            tbxAIM.Text = drMember.ItemArray[13].ToString();
            tbxMSN.Text = drMember.ItemArray[14].ToString();
            tbxYahoo.Text = drMember.ItemArray[15].ToString();
            tbxGoogleTalk.Text = drMember.ItemArray[16].ToString();
            tbxLocation.Text = drMember.ItemArray[17].ToString();
            tbxSignature.Text = drMember.ItemArray[18].ToString().Replace("<br />", "\r\n");
            cbxMemberNewsletter.Checked = Convert.ToBoolean(drMember.ItemArray[22]);
            cbxDailyMotivator.Checked = Convert.ToBoolean(drMember.ItemArray[23]);
            cbxShowEmail.Checked = Convert.ToBoolean(drMember.ItemArray[24]);
            tbxTwitterUsername.Text = drMember.ItemArray[26].ToString();
            string sGender = drMember.ItemArray[28].ToString();
            if (sGender == "Not Specified")
                ddlGender.SelectedIndex = 0;
            else if (sGender == "Male")
                ddlGender.SelectedIndex = 1;
            else if (sGender == "Female")
                ddlGender.SelectedIndex = 2;
            DateTime dtBirthday = Convert.ToDateTime(drMember.ItemArray[30]);
            for (int iIndex = 0; iIndex < ddlBirthYear.Items.Count; iIndex++)
            {
                if (dtBirthday.Year.ToString() == ddlBirthYear.Items[iIndex].ToString())
                {
                    ddlBirthYear.SelectedIndex = iIndex;
                    break;
                }
            }
            ddlBirthMonth.SelectedIndex = dtBirthday.Month - 1;
            calBirthday.SelectedDate = Convert.ToDateTime(dtBirthday.Month.ToString() + "/" + dtBirthday.Day.ToString() + "/" + dtBirthday.Year.ToString());
            calBirthday.VisibleDate = calBirthday.SelectedDate;
            string sBusinessCategory = drMember.ItemArray[31].ToString();

            if (sBusinessCategory != "Not Selected")
            {
                for (int iCount = 0; iCount < ddlBusinessCategory.Items.Count; iCount++)
                {
                    if (sBusinessCategory == ddlBusinessCategory.Items[iCount].ToString())
                    {
                        ddlBusinessCategory.SelectedIndex = iCount;
                        break;
                    }
                }
            }
            else
            {
                ddlBusinessCategory.SelectedIndex = 0;
            }
        }
        else
        {
            sEmail = this.ViewState["sEmail"].ToString();
        }
    }

    protected void ddlBirth_SelectedIndexChanged(object sender, EventArgs e)
    {
        calBirthday.SelectedDate = Convert.ToDateTime(ddlBirthMonth.SelectedValue + "/" + calBirthday.SelectedDate.Day.ToString() + "/" + ddlBirthYear.SelectedValue);
        calBirthday.VisibleDate = calBirthday.SelectedDate;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetMemberBy_Email(sEmail);
        string sTwitterFeedStyles = dt.Rows[0].ItemArray[32].ToString();
        string sTwitterPassword = dt.Rows[0].ItemArray[27].ToString();
        bool bUpdateTwitter = Convert.ToBoolean(dt.Rows[0].ItemArray[25]);
        string sPersonalAvatar = dt.Rows[0].ItemArray[3].ToString();
        if (fuPersonalAvatar.HasFile)
        {
            string sExt = fuPersonalAvatar.FileName.Remove(0, fuPersonalAvatar.FileName.LastIndexOf('.'));
            fuPersonalAvatar.SaveAs(MapPath("~/images/MemberAvatars/" + lblEmail.Text + sExt));
            sPersonalAvatar = lblEmail.Text + sExt;
        }
        string sBusinessLogo = dt.Rows[0].ItemArray[9].ToString();
        if (fuBusinessLogo.HasFile)
        {
            string sExt = fuBusinessLogo.FileName.Remove(0, fuBusinessLogo.FileName.LastIndexOf('.'));
            fuBusinessLogo.SaveAs(MapPath("~/images/BusinessLogos/" + lblEmail.Text + sExt));
            sBusinessLogo = lblEmail.Text + sExt;
        }
        bool bAdmin = Convert.ToBoolean(dt.Rows[0].ItemArray[19]);
        bool bModerator = Convert.ToBoolean(dt.Rows[0].ItemArray[20]);
        bool bCanPostBlog = Convert.ToBoolean(dt.Rows[0].ItemArray[21]);
        string sArticleCategory = dt.Rows[0].ItemArray[34].ToString();
        dl.UpdateMember(sEmail, tbxName.Text, sPersonalAvatar, tbxPhone.Text, tbxInterests.Text.Replace("\n", "<br />").Replace("\r", ""), tbxWebsite.Text, tbxPersonalBio.Text.Replace("\n", "<br />").Replace("\r", ""), tbxBusinessName.Text, sBusinessLogo, tbxBusinessBio.Text.Replace("\n", "<br />").Replace("\r", ""), tbxAIM.Text, tbxMSN.Text, tbxYahoo.Text, tbxGoogleTalk.Text, tbxLocation.Text, tbxSignature.Text.Replace("\n", "<br />").Replace("\r", ""), bAdmin, bModerator, bCanPostBlog, cbxMemberNewsletter.Checked, cbxDailyMotivator.Checked, cbxShowEmail.Checked, bUpdateTwitter, tbxTwitterUsername.Text.Replace("@", ""), sTwitterPassword, ddlGender.SelectedValue, calBirthday.SelectedDate, ddlBusinessCategory.SelectedValue, sTwitterFeedStyles, sArticleCategory);
        Session["resultColor"] = "#007700";
        Session["resultTitle"] = "Profile Updated";
        Session["resultMessage"] = "You Profile Has Been Updated Successfuly";
        Session["resultReturnURL"] = "Profile.aspx?member=" + sEmail;
        Response.Redirect("Result.aspx");
    }
}
