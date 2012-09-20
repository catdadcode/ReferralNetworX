<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Articles.aspx.cs" Inherits="Articles" Title="Articles" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="categorypanel" runat="server">
            
    </div>
    <div id="articlepanel" runat="server">
        <div class="contenttitle">
            <div id="category" runat="server">
            </div>
        </div>
        <div class="contentpanel">
            <pn1:pagenav ID="pageNav1" runat="server" />
            <div id="articles" style="font-size: 25px; text-align: left;" runat="server">
            </div>
            <pn1:pagenav ID="pageNav2" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
