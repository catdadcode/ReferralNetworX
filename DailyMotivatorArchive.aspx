<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="DailyMotivatorArchive.aspx.cs" Inherits="DailyMotivatorArchive"
    Title="Daily Motivator Archive" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        Daily Motivator Archive
    </div>
    <div class="contentpanel">
        <pn1:pagenav ID="pageNav1" runat="server" />
        <hr />
        <br />
        <div id="dailymotivators" runat="server">
        </div>
        <pn1:pagenav ID="pageNav2" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
