<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="AddEditPost.aspx.cs" Inherits="AddEditTopic" ValidateRequest="false"
    Title="Add/Edit Topic" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <span id="addedit" runat="server">Add New Reply</span></div>
    <div class="formpanel">
        <div style="background-color: #ddddee; border: solid 2px #000077; padding: 10px;
            margin-bottom: 15px;">
            <div id="replyto" runat="server">
            </div>
            <br />
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: left; vertical-align: middle; font-size: 12px; font-weight: bold;"
                            id="postedby" runat="server">
                        </td>
                        <td style="text-align: right; vertical-align: middle;">
                            <asp:LinkButton ID="lbtnQuotePost" OnClientClick="CopyText()" runat="server" OnClick="lbtnQuotePost_Click">Quote Post</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        Body:
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXMember" Height="400px" BasePath="fckeditor/"
            runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<div class="formtitle">
        Add Image To Post</div>
    <div class="formpanel">
        <div style="color: #ff0000; font-size: 14px;">
            * Images are added to the bottom of the content window. If you don't see your image,
            scroll down.</div>
        <br />
        Image URL:<br />
        <asp:TextBox ID="tbxImageURL" Width="225px" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAddImage" OnClientClick="CopyText()" runat="server" Text="Add Image"
            CausesValidation="false" OnClick="btnAddImage_Click" />
    </div>--%>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
