<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Directory.aspx.cs" Inherits="Directory" Title="Member Directory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        <a class="titlelink" href="MemberDirectory.aspx">Member Directory</a>
    </div>
    <div class="contentpanel" style="font-size: 20px;">
        Click through and meet your fellow members in the member directory. Sort by last
        login, name, or even popularity!
    </div>
    <div class="contenttitle">
        <a class="titlelink" href="BusinessDirectory.aspx">Business Directory</a>
    </div>
    <div class="contentpanel" style="font-size: 20px;">
        Do you have a specific need? Another member of RNX probably provides the product
        or service you are looking for! Select a category and see what businesses are the
        member favorites.
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
