<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="NewsletterArchive.aspx.cs" Inherits="NewsletterArchive" Title="Newsletter Archive" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        Newsletter Archive</div>
    <div class="contentpanel">
        <pn1:pagenav ID="pageNav1" runat="server" />
        <hr />
        <div id="newsletters" style="font-size:25px;text-align:center;" runat="server">
        </div>
        <pn1:pagenav ID="pageNav2" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
