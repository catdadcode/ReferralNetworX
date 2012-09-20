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
using System.Net;
using System.IO;
using System.Web.Mail;
using System.Data.SqlClient;

public partial class ManagePodcasts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx", true);
        }

        DataLayer dl = new DataLayer();

        if (!this.IsPostBack)
        {
            btnAddNewPodcast_Click(null, null);

            DataTable dt = dl.GetPodcastEpisodesAndIDs();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem("Episode " + dr["Episode"].ToString(), dr["PodcastID"].ToString());
                lbxPodcasts.Items.Add(li);
            }
            numpodcasts.InnerText = dt.Rows.Count.ToString();
        }
    }

    protected void lbxPodcasts_SelectedIndexChanged(object sender, EventArgs e)
    {
        addedit.InnerText = "Edit Podcast";
        DataLayer dl = new DataLayer();
        DataTable dtPodcast = dl.GetPodcastBy_PodcastID(Convert.ToInt32(lbxPodcasts.SelectedValue));
        cbxDeletePodcast.Visible = true;
        tbxTitle.Text = dtPodcast.Rows[0]["Title"].ToString();
        tbxEpisodeNumber.Text = dtPodcast.Rows[0]["Episode"].ToString();
        tbxEpisodeNumber.Enabled = false;
        tbxURL.Text = dtPodcast.Rows[0]["URL"].ToString();
        tbxURL.Enabled = false;
        rteDescription.Value = dtPodcast.Rows[0]["Description"].ToString();
    }

    protected void btnAddNewPodcast_Click(object sender, EventArgs e)
    {
        addedit.InnerText = "Add New Podcast";
        lbxPodcasts.SelectedIndex = -1;
        cbxDeletePodcast.Visible = false;
        rteDescription.Value = "";
        tbxTitle.Text = "";
        tbxEpisodeNumber.Text = "";
        tbxURL.Text = "";
        tbxEpisodeNumber.Enabled = true;
        tbxURL.Enabled = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lbxPodcasts.SelectedIndex == -1)
        {
            DataLayer dl = new DataLayer();
            DateTime dtPostTime = DateTime.Now;
            int iEpisode = Convert.ToInt32(tbxEpisodeNumber.Text);
            FileInfo fi = new FileInfo(MapPath("~/KRNX/" + tbxURL.Text));
            decimal dSize = Math.Round((Convert.ToDecimal(fi.Length) / 1000m) / 1000m, 2);
            TagLib.File f = TagLib.File.Create(MapPath("~/KRNX/" + tbxURL.Text));
            decimal dDuration = Math.Round(Convert.ToDecimal(f.Properties.Duration.TotalMinutes), 1);
            dl.AddPodcast(tbxTitle.Text, rteDescription.Value, tbxURL.Text, dtPostTime, iEpisode, dSize, dDuration);

            //To Do: post to Twitter

            Session["resultColor"] = "#007700";
            Session["resultTitle"] = "Podcast Added";
            Session["resultMessage"] = "Podcast Added Successfuly";
            Session["resultReturnURL"] = "PodcastArchive.aspx";
            Response.Redirect("Result.aspx");
        }
        else
        {
            if (cbxDeletePodcast.Checked)
            {
                DataLayer dl = new DataLayer();
                dl.DeletePodcast(Convert.ToInt32(lbxPodcasts.SelectedValue));
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Podcast Deleted";
                Session["resultMessage"] = "Podcast Deleted Successfuly";
                Session["resultReturnURL"] = "ManagePodcasts.aspx";
                Response.Redirect("Result.aspx");
            }
            else
            {
                DataLayer dl = new DataLayer();
                dl.UpdatePodcast(Convert.ToInt32(lbxPodcasts.SelectedValue), tbxTitle.Text, rteDescription.Value);
                Session["resultColor"] = "#007700";
                Session["resultTitle"] = "Podcast Updated";
                Session["resultMessage"] = "Podcast Updated Successfuly";
                Session["resultReturnURL"] = "ManagePodcasts.aspx";
                Response.Redirect("Result.aspx");
            }
        }
    }

    protected void cbxDeletePodcast_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeletePodcast.Checked)
        {
            tbxTitle.Enabled = false;
            tbxEpisodeNumber.Enabled = false;
            tbxURL.Enabled = false;
        }
        else
        {
            tbxTitle.Enabled = true;
            tbxEpisodeNumber.Enabled = true;
            tbxURL.Enabled = true;
        }
    }
}
