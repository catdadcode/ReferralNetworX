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

public partial class PageNav : System.Web.UI.UserControl
{
    int iNumPages = 0;
    int iPageNum = 0;
    string sCSSClass;
    HyperLink hl;
    LiteralControl lc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["p"] != null)
            iPageNum = Convert.ToInt32(Request.QueryString["p"]);
        else
            iPageNum = 0;
        string sPageQueryString = Request.RawUrl;
        string[] sQueryStrings = Request.QueryString.AllKeys;
        if ((sQueryStrings.Length == 0) || ((sQueryStrings.Length == 1) && (Request.RawUrl.Contains("p="))))
        {
            sPageQueryString = Request.Path + "?p=";
        }
        else if ((sQueryStrings.Length > 0))
        {
            sPageQueryString = Request.Path + "?";
            foreach (string s in sQueryStrings)
            {
                if (s != "p")
                    sPageQueryString += s + "=" + Request.QueryString[s] + "&";
            }
            sPageQueryString += "p=";
        }

        if (iNumPages > 0)
        {
            navcontrols.Controls.Add(new LiteralControl("<div style=\"padding:10px;\">"));
        }

        if (iPageNum > 0)
        {
            hl = new HyperLink();
            hl.CssClass = sCSSClass;
            hl.Text = "&lt;&lt;";
            hl.NavigateUrl = sPageQueryString + "0";
            navcontrols.Controls.Add(hl);

            lc = new LiteralControl(" ");
            navcontrols.Controls.Add(lc);

            hl = new HyperLink();
            hl.CssClass = sCSSClass;
            hl.Text = "&lt;prev";
            hl.NavigateUrl = sPageQueryString + Convert.ToString(iPageNum - 1);
            navcontrols.Controls.Add(hl);

            lc = new LiteralControl(" ");
            navcontrols.Controls.Add(lc);
        }

        int imin = 0;
        int imax = iNumPages;

        if (iPageNum < 3)
        {
            imin = 0;
            if (iNumPages >= 4)
            {
                imax = 4;
            }
        }
        else if (iPageNum > (iNumPages - 3))
        {
            if (iNumPages >= 4)
            {
                imin = iNumPages - 4;
            }
            imax = iNumPages;
        }
        else
        {
            if (iNumPages >= 4)
            {
                imin = iPageNum - 2;
                imax = iPageNum + 2;
            }
        }

        for (int iPageCount = imin; iPageCount <= imax; iPageCount++)
        {
            if (iPageNum != iPageCount)
            {
                hl = new HyperLink();
                hl.CssClass = sCSSClass;
                hl.Text = Convert.ToString(iPageCount + 1);
                hl.NavigateUrl = sPageQueryString + iPageCount;
                navcontrols.Controls.Add(hl);
            }
            else
            {
                if (imax > 0)
                {
                    lc = new LiteralControl("<span style=\"font-size: 25px;\">" + Convert.ToString(iPageCount + 1) + "</span>");
                    navcontrols.Controls.Add(lc);
                }
            }

            lc = new LiteralControl(" ");
            navcontrols.Controls.Add(lc);
        }

        if (iPageNum < iNumPages)
        {
            hl = new HyperLink();
            hl.CssClass = sCSSClass;
            hl.Text = "next&gt;";
            hl.NavigateUrl = sPageQueryString + Convert.ToString(iPageNum + 1);
            navcontrols.Controls.Add(hl);

            lc = new LiteralControl(" ");
            navcontrols.Controls.Add(lc);

            hl = new HyperLink();
            hl.CssClass = sCSSClass;
            hl.Text = "&gt;&gt;";
            hl.NavigateUrl = sPageQueryString + iNumPages;
            navcontrols.Controls.Add(hl);
        }

        if (iNumPages > 0)
        {
            navcontrols.Controls.Add(new LiteralControl("</div>"));
        }
    }

    public int NumPages
    {
        get { return iNumPages; }
        set { iNumPages = value - 1; }
    }

    public string CSSClass
    {
        get { return sCSSClass; }
        set { sCSSClass = value; }
    }
}
