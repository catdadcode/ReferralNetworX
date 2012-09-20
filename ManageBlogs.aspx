<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageBlogs.aspx.cs" Inherits="ManageBlogs" ValidateRequest="false"
    Title="Blog Management" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New Blog
        </div>
    </div>
    <div class="formpanel">
        <asp:CheckBox ID="cbxDeleteBlog" Text="Delete Blog" runat="server" AutoPostBack="True"
            OnCheckedChanged="cbxDeleteBlog_CheckedChanged" />
        <br />
        <br />
        <div id="postedby" runat="server">
            Posted By: <span id="spanAuthor" style="font-weight: bold; border: solid 1px #333333;
                background-color: #77BB77; color: #ffffff; padding: 5px;" runat="server"></span>
        </div>
        <br />
        Title:
        <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox>
        <br />
        <br />
        Body:<br />
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXAdministrator" Height="400px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        Who can see this blog?
        <asp:DropDownList ID="ddlAccessLevel" runat="server">
            <asp:ListItem>Everyone</asp:ListItem>
            <asp:ListItem>Members Only</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numblogs" runat="server">0</span>&nbsp;Blog(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxBlogs" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxBlogs_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewBlog" runat="server" Text="Add New Blog" CausesValidation="False"
            OnClick="btnAddNewBlog_Click" />
    </div>
</asp:Content>
