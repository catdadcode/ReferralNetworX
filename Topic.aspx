<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Topic.aspx.cs" Inherits="Topics" Title="Forum Topics" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        <span id="boardtitle" runat="server">Board Title</span>
    </div>
    <div style="background-color: #4B714A; padding: 5px; font-family: Arial; font-size: 25px;
        color: #ffffff; text-align: center; border-top: solid 0px #333333;">
        <span id="topictitle" runat="server">Topic Title</span>
    </div>
    <div class="contentpanel">
        <div style="border: solid 1px #333333;">
            <div style="background-color: #ffffff; border-bottom: solid 1px #333333;">
                <pn1:pagenav ID="pageNav1" runat="server" />
            </div>
            <div id="posts" runat="server">
            </div>
            <div style="background-color: #ffffff; border-top: solid 1px #333333;">
                <pn1:pagenav ID="pageNav2" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
