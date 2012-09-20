<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageArticleCategories.aspx.cs" Inherits="ManageCategories" Title="Manage Categories"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New Category
        </div>
    </div>
    <div class="formpanel">
        <div style="width: 400px; margin: auto;">
            <asp:CheckBox ID="cbxDeleteCategory" Text="Delete Category" runat="server" AutoPostBack="True"
                OnCheckedChanged="cbxDeleteCategory_CheckedChanged" />
            <br />
            <br />
            Parent Category:<br />
            <asp:DropDownList ID="ddlParentCategory" runat="server">
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Category:<br />
            <asp:TextBox ID="tbxCategory" Width="400px" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCategory"
                ErrorMessage="* Required"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numCategories" runat="server">0</span>&nbsp;Categories</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxCategories" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxCategories_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewCategory" runat="server" Text="Add New Category" CausesValidation="False"
            OnClick="btnAddNewCategory_Click" />
    </div>
</asp:Content>
