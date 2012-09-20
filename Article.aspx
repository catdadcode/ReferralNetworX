<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Article.aspx.cs" Inherits="Article" Title="Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentpanel" style="margin-top: -16px;">
        <div style="font-size: 35px; font-family: Arial; color: #007700;">
            <div id="articletitle" runat="server">
            </div>
        </div>
        <div id="postedby" runat="server">
        </div>
        <br />
        <div id="articlebody" runat="server">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
