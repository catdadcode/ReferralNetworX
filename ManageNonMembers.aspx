<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageNonMembers.aspx.cs" Inherits="ManageMembers" MaintainScrollPositionOnPostback="true"
    Title="Manage Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <span id="addedit" runat="server">Add New Non-Member</span>
    </div>
    <div class="formpanel">
        <table style="width: 100%;">
            <tr>
                <td style="color: #ff0000; text-align: center;" colspan="2">
                    * Denotes Required Field<br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblDeleteNonMember" runat="server" Text="Delete Non-Member"></asp:Label>
                </td>
                <td style="text-align: left:">
                    <asp:CheckBox ID="cbxDeleteNonMember" runat="server" AutoPostBack="True" OnCheckedChanged="cbxDeleteNonMember_CheckedChanged" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Email:
                </td>
                <td style="text-align: left:">
                    <asp:TextBox ID="tbxEmail" Width="300px" runat="server"></asp:TextBox><span style="color: #ff0000;">*</span>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" ControlToValidate="tbxEmail" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbxEmail"
                        runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Name:
                </td>
                <td style="text-align: left:">
                    <asp:TextBox ID="tbxName" Width="250px" runat="server"></asp:TextBox><span style="color: #ff0000;">*</span>&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" ControlToValidate="tbxName" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Daily Motivator:
                </td>
                <td style="text-align: left:">
                    <asp:CheckBox ID="cbxDailyMotivator" runat="server" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Non-Member Newsletter:
                </td>
                <td style="text-align: left:">
                    <asp:CheckBox ID="cbxNonMemberNewsletter" runat="server" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numnonmembers" runat="server"></span>&nbsp;Non-Member(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxNonMembers" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxNonMembers_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewNonMember" runat="server" CausesValidation="false" Text="Add New Non-Member"
            OnClick="btnAddNewNonMember_Click" />
    </div>
</asp:Content>
