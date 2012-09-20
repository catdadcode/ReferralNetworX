<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="MemberDirectory.aspx.cs" Inherits="MemberDirectory" Title="Member Directory" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        Sort Members By
    </div>
    <div class="contentpanel">
        <table style="width: 100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align: center;">
                    <asp:RadioButton ID="rbtnAlphabetical" AutoPostBack="true" GroupName="SortBy" Text="Alphabetical"
                        runat="server" OnCheckedChanged="rbtnAlphabetical_CheckedChanged" />
                </td>
                <td style="text-align: center;">
                    <asp:RadioButton ID="rbtnLastLogin" AutoPostBack="true" GroupName="SortBy" Text="Last Login"
                        runat="server" OnCheckedChanged="rbtnLastLogin_CheckedChanged" />
                </td>
                <td style="text-align: center;">
                    <asp:RadioButton ID="rbtnPopularity" AutoPostBack="true" GroupName="SortBy" Text="Popularity"
                        runat="server" OnCheckedChanged="rbtnPopularity_CheckedChanged" />
                </td>
            </tr>
        </table>
        <div style="text-align: center; border: solid 1px #333333; margin-top: 15px; padding: 10px;
            background-color: #CCDDCC;">
            <asp:TextBox ID="tbxSearch" runat="server" Width="250px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <br />
            <br />
            <asp:LinkButton ID="lbtnViewAll" runat="server" OnClick="lbtnViewAll_Click">View All</asp:LinkButton>
        </div>
    </div>
    <div class="contenttitle">
        Results
    </div>
    <div class="contentpanel">
        <pn1:pagenav ID="pageNav1" runat="server" />
        <div id="divMemberPreviews" runat="server">
        </div>
        <pn1:pagenav ID="pageNav2" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
