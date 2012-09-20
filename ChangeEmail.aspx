<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ChangeEmail.aspx.cs" Inherits="ChangeEmail" Title="Change My Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Change My Email</div>
    <div class="formpanel">
        New Email Address:
        <asp:TextBox ID="tbxEmail" autocomplete="off" AutoCompleteType="None" Width="300px"
            runat="server"></asp:TextBox><br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Invalid Email Address"
            Display="Dynamic" ControlToValidate="tbxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="tbxEmail"
            runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        <br />
        Confirm Email Address:
        <asp:TextBox ID="tbxConfirmEmail" autocomplete="off" AutoCompleteType="None" Width="300px"
            runat="server"></asp:TextBox><br />
        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" ControlToValidate="tbxConfirmEmail"
            ControlToCompare="tbxEmail" runat="server" ErrorMessage="Emails Do Not Match"></asp:CompareValidator>
        <br />
        Account Password:
        <asp:TextBox ID="tbxPassword" autocomplete="off" AutoCompleteType="None" Width="200px"
            TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" runat="server" ErrorMessage="Invalid Password"></asp:CustomValidator>
        <br />
        <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
