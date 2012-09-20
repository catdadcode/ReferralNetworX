<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Change My Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Change My Password</div>
    <div class="formpanel">
        New Password:
        <asp:TextBox ID="tbxPassword" autocomplete="off" AutoCompleteType="None" Width="200px"
            runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="tbxPassword"
            runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        <br />
        Confirm New Password:
        <asp:TextBox ID="tbxConfirmPassword" autocomplete="off" AutoCompleteType="None" Width="200px"
            runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" ControlToCompare="tbxPassword"
            ControlToValidate="tbxConfirmPassword" runat="server" ErrorMessage="* Passwords Do Not Match"></asp:CompareValidator>
        <br />
        Current Password:
        <asp:TextBox ID="tbxCurrentPassword" autocomplete="off" AutoCompleteType="None" Width="200px"
            TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" runat="server" ErrorMessage="* Invalid Password"></asp:CustomValidator>
        <br />
        <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
