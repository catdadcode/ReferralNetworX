using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    Guid gUserID;
    string sName;
    string sCompany;
    string sEmail;
    string sPassword;
    DateTime dtSignUpDate;
    bool bNewsletter;
    string sColumn;
    bool bColumnModerator;
    bool bColumnAdmin;
    bool bSiteModerator;
    bool bSiteAdmin;
    string sNotes;
    string sCompanyLogo;

	public User(Guid gUserID, string sName, string sCompany, string sEmail, string sPassword,
        DateTime dtSignUpDate, bool bNewsletter, string sColumn, bool bColumnModerator,
        bool bColumnAdmin, bool bSiteModerator, bool bSiteAdmin, string sNotes, string sCompanyLogo)
	{
        this.gUserID = gUserID;
        this.sName = sName;
        this.sCompany = sCompany;
        this.sEmail = sEmail;
        this.sPassword = sPassword;
        this.dtSignUpDate = dtSignUpDate;
        this.bNewsletter = bNewsletter;
        this.sColumn = sColumn;
        this.bColumnModerator = bColumnModerator;
        this.bColumnAdmin = bColumnAdmin;
        this.bSiteModerator = bSiteModerator;
        this.bSiteAdmin = bSiteAdmin;
        this.sNotes = sNotes;
        this.sCompanyLogo = sCompanyLogo;
	}

    public string Name
    {
        get { return sName; }
        set { sName = value; }
    }

    public string Company
    {
        get { return sCompany; }
        set { sCompany = value; }
    }

    public string Email
    {
        get { return sEmail; }
        set { sEmail = value; }
    }

    public bool Newsletter
    {
        get { return bNewsletter; }
        set { bNewsletter = value; }
    }

    public bool ColumnModerator
    {
        get { return bColumnModerator; }
        set { bColumnModerator = value; }
    }

    public bool ColumnAdmin
    {
        get { return bColumnAdmin; }
        set { bColumnAdmin = value; }
    }

    public bool SiteModerator
    {
        get { return bSiteModerator; }
        set { bSiteModerator = value; }
    }

    public bool SiteAdmin
    {
        get { return bSiteAdmin; }
        set { bSiteAdmin = value; }
    }

    public override string ToString()
    {
        string[] sNameReversed = sName.Split(' ');
        return sNameReversed[1] + ", " + sNameReversed[0];
    }
}
