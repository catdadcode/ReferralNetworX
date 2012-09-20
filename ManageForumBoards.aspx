<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageForumBoards.aspx.cs" Inherits="ManageForumBoards" Title="Manage Forum Boards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <span id="addedit" runat="server">Add New Forum Board</span>
    </div>
    <div class="formpanel">
        <div style="width: 410px; margin: auto;">
            <div style="color: #ff0000; text-align: center;">
                * Denotes Required Field</div>
            <br />
            <asp:CheckBox ID="cbxDeleteForumBoard" Text="Delete Forum Board" runat="server" AutoPostBack="True"
                OnCheckedChanged="cbxDeleteForumBoard_CheckedChanged" />
            <br />
            <br />
            Title:
            <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox><span style="color: #ff0000;">*</span>&nbsp;<asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" ControlToValidate="tbxTitle" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            Description:<br />
            <asp:TextBox ID="tbxDescription" Width="400px" Height="100px" TextMode="MultiLine"
                runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="cbxLocked" Text="Locked" runat="server" /><br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numboards" runat="server">0</span>&nbsp;Forum Board(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxForumBoards" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxForumBoards_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewForumBoard" runat="server" Text="Add New Forum Board" CausesValidation="False"
            OnClick="btnAddNewForumBoard_Click" />
    </div>
</asp:Content>
