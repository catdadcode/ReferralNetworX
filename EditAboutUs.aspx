<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="EditAboutUs.aspx.cs" Inherits="EditAboutUs" ValidateRequest="false"
    Title="Edit About Us" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Edit About Us
    </div>
    <div class="formpanel">
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXAdministrator" Height="500px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
            Style="height: 26px" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
