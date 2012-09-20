<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Blogs.aspx.cs" Inherits="Blogs" Title="Blogs" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        Referral NetworX Blog</div>
    <div class="contentpanel">
        <pn1:pagenav ID="pageNav1" runat="server" />
        <div id="blogs" runat="server">
        </div>
        <pn1:pagenav ID="pageNav2" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
