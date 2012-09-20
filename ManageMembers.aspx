<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageMembers.aspx.cs" Inherits="ManageMembers" MaintainScrollPositionOnPostback="true"
    Title="Manage Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <span id="addedit" runat="server">Manage Members</span>
    </div>
    <div class="formpanel">
        <div id="memberform" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="color: #ff0000; text-align: center;" colspan="2">
                        * Denotes Required Field<br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 200px;">
                        <asp:Label ID="lblDeleteMember" runat="server" Text="Delete Member"></asp:Label>
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="cbxDeleteMember" runat="server" AutoPostBack="True" OnCheckedChanged="cbxDeleteMember_CheckedChanged" />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: right; width: 200px;">
                        Subscription ID:
                    </td>
                    <td style="text-align: left;">
                        &nbsp;<asp:Label ID="lblSubscriptionID" Font-Bold="true" runat="server" Text="Free"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 200px;">
                        Email:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxEmail" Width="300px" runat="server"></asp:TextBox><span style="color: #ff0000;">*</span>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="tbxEmail"
                            runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
                            ControlToValidate="tbxEmail" runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Name:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxName" Width="250px" runat="server"></asp:TextBox><span style="color: #ff0000;">*</span>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="tbxName"
                            runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 200px;">
                        Business Name:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxBusinessName" Width="300px" runat="server"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 200px;">
                        Member&nbsp;Newsletter:
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="cbxMemberNewsletter" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Daily&nbsp;Motivator:
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="cbxDailyMotivator" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                    </td>
                    <td style="text-align: left;">
                        <div id="editoptions" runat="server">
                            <asp:HyperLink ID="hlViewProfile" onclick="return confirm('Are you sure you want to navigate away from this page? All unsaved changes will be lost.');"
                                runat="server">View This Member's Profile</asp:HyperLink><br />
                            <asp:HyperLink ID="hlEditFullProfile" onclick="return confirm('Are you sure you want to navigate away from this page? All unsaved changes will be lost.');"
                                runat="server">Edit This Member's Profile</asp:HyperLink>
                        </div>
                        <br />
                    </td>
                </tr>
            </table>
            <table id="administratoroptions" style="width: 100%;" runat="server">
                <tr>
                    <td style="text-align: right; width: 200px;">
                        Administrator:
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="cbxAdmin" runat="server" AutoPostBack="True" OnCheckedChanged="cbxAdmin_CheckedChanged" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Moderator:
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="cbxModerator" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Can&nbsp;Post&nbsp;Blog:
                    </td>
                    <td style="text-align: left;">
                        <asp:CheckBox ID="cbxCanPostBlog" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Article&nbsp;Column:
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlArticleColumn" runat="server">
                            <asp:ListItem>None</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <hr />
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
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        Search</div>
    <div class="formpanel" style="text-align: center;">
        <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
            <asp:TextBox ID="tbxSearch" Width="225px" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="False"
                OnClick="btnSearch_Click" />
        </asp:Panel>
    </div>
    <div class="formtitle">
        <span id="nummembers" runat="server"></span>&nbsp;Member(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxMembers" Width="225px" Height="400px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxMembers_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewMember" runat="server" Text="Add New Member" CausesValidation="false"
            OnClick="btnAddNewMember_Click" />
    </div>
</asp:Content>
