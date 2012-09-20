using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ArbApiSample;
using System.Xml.Serialization;
using System.Xml;
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        dl.UpdateLastMotivatorDate(new DateTime(2010, 1, 1));
    }
}
