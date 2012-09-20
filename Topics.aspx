<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Topics.aspx.cs" Inherits="Topics" Title="Forum Topics" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="stickypanel" runat="server">
        <div class="contenttitle">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: center; vertical-align: middle; width: 100%;">
                        Sticky Topics
                    </td>
                    <td style="text-align: right; vertical-align: middle; font-size: 14px;">
                        <asp:HyperLink ID="hlAddTopic2" ForeColor="#ffff00" runat="server">Post&nbsp;New&nbsp;Topic</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <div class="contentpanel">
            <div style="border: solid 1px #333333;">
                <div id="stickytopics" runat="server">
                </div>
            </div>
        </div>
    </div>
    <div class="contenttitle">
        <table style="width: 100%;">
            <tr>
                <td style="text-align: center; vertical-align: middle; width: 100%;">
                    <span id="boardtitle" runat="server">Board Title</span>
                </td>
                <td style="text-align: right; vertical-align: middle; font-size: 14px;">
                    <asp:HyperLink ID="hlAddTopic" ForeColor="#ffff00" runat="server">Post&nbsp;New&nbsp;Topic</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <div class="contentpanel">
        <div style="border: solid 1px #333333;">
            <div style="background-color: #ffffff; border-bottom: solid 1px #333333;">
                <pn1:pagenav ID="pageNav1" runat="server" />
            </div>
            <div id="topics" runat="server">
            </div>
            <div style="background-color: #ffffff; border-top: solid 1px #333333;">
                <pn1:pagenav ID="pageNav2" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
