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
using System.IO;

public partial class ImageBrowser : System.Web.UI.UserControl
{
    protected string sSelectedImage;
    protected string sImageDirectory = "~\\";
    protected string sWidth;
    protected string sHeight;
    protected bool bHorizontal = true;
    protected bool bOverflow = true;
    protected int iImageSize = 100;
    RadioButton rbSelectImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.ViewState["selectedimage"] != null)
        {
            sSelectedImage = this.ViewState["selectedimage"].ToString();
        }

        LoadImages();
    }

    void rbSelectImage_CheckedChanged(object sender, EventArgs e)
    {
        sSelectedImage = ((RadioButton)sender).ID;
        this.ViewState["selectedimage"] = sSelectedImage;
    }

    public string SelectedImage
    {
        get { return sSelectedImage; }
    }

    public string Width
    {
        get { return sWidth; }
        set { sWidth = value; }
    }

    public string Height
    {
        get { return sHeight; }
        set { sHeight = value; }
    }

    public string ImageDirectory
    {
        get { return sImageDirectory; }
        set { sImageDirectory = value; }
    }

    public bool Horizontal
    {
        get { return bHorizontal; }
        set { bHorizontal = value; }
    }

    public bool Overflow
    {
        get { return bOverflow; }
        set { bOverflow = value; }
    }

    public int ImageSize
    {
        get { return iImageSize; }
        set { iImageSize = value; }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string sFileName = fuUploadImage.FileName;//.Remove(0, fuUploadImage.FileName.LastIndexOf('\\'));
        if (!File.Exists(Server.MapPath(sImageDirectory + "/" + sFileName)))
        {
            try
            {
                fuUploadImage.SaveAs(Server.MapPath(sImageDirectory + "/" + sFileName));
            }
            catch (Exception ex)
            {
                ExistingImages.Controls.Add(new LiteralControl(ex.ToString()));
            }
        }
        else
        {

        }
        LoadImages();
    }

    private void LoadImages()
    {
        ExistingImages.Controls.Clear();
        ExistingImages.Controls.Add(new LiteralControl("<div style=\"border:solid 3px #333333;background-color:#DDFFDD;"));
        if (bOverflow)
        {
            ExistingImages.Controls.Add(new LiteralControl("overflow:auto;"));
        }
        ExistingImages.Controls.Add(new LiteralControl("width:" + sWidth + ";"));
        ExistingImages.Controls.Add(new LiteralControl("height:" + sHeight + ";"));
        ExistingImages.Controls.Add(new LiteralControl("\">"));

        ExistingImages.Controls.Add(new LiteralControl("<table><tr>"));
        string[] sImages = Directory.GetFiles(Server.MapPath(sImageDirectory));

        if (sImages.Length == 0)
        {
            ExistingImages.Controls.Add(new LiteralControl("<div style=\"padding:5px;\">No images uploaded.</div>"));
        }

        foreach (string sImage in sImages)
        {
            string sImageName = sImage.Remove(0, sImage.LastIndexOf('\\') + 1);
            ExistingImages.Controls.Add(new LiteralControl("<td style=\"text-align:center;vertical-align:bottom;padding:5px;\"><img style=\"margin-bottom:5px;border:dashed 1px #333333;\" src=\"MakeThumbnail.aspx?size=" + iImageSize.ToString() + "&image=" + sImageDirectory + "/" + sImageName + "\" /><br />"));
            rbSelectImage = new RadioButton();
            rbSelectImage.Attributes.Add("onclick", "CopyText()");
            rbSelectImage.GroupName = "imageselector";
            rbSelectImage.AutoPostBack = true;
            rbSelectImage.ID = sImageName;
            rbSelectImage.CausesValidation = false;
            rbSelectImage.CheckedChanged += new EventHandler(rbSelectImage_CheckedChanged);
            ExistingImages.Controls.Add(rbSelectImage);
            ExistingImages.Controls.Add(new LiteralControl("</td>"));
        }
        ExistingImages.Controls.Add(new LiteralControl("</tr></table>"));

        ExistingImages.Controls.Add(new LiteralControl("</div>"));
    }
}
