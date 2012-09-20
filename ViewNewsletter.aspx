<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ViewNewsletter.aspx.cs" Inherits="ViewNewsletter" Title="View Newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle" style="border: solid 3px #333333; border-bottom: solid 0px #333333;">
        <div id="divNewsletterTitle" runat="server">
        </div>
    </div>
    <div style="background-image: url(images/grid2.gif); border: solid 3px #333333; padding: 50px;">
        <div style="border: dashed 5px #000000; margin: auto; width: 800px;">
            <div style="width: 790px; background-color: #333333; padding: 5px; border: solid 1px #333333;">
                <img style="height: 125px;" src="http://www.referralnetworx.com/images/networking.jpg" /><img
                    src="http://www.referralnetworx.com/images/banner.jpg" />
            </div>
            <div id="divNewsletterContent" style="width: 770px; background-color: #ddeedd; padding: 15px;
                border: solid 1px #333333;" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
