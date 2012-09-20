<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Blog.aspx.cs" Inherits="Blog" Title="Blog" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentpanel" style="margin-top: -16px;">
        <div style="font-size: 35px; font-family: Arial; color: #007700;">
            <div id="blogtitle" runat="server">
            </div>
        </div>
        <div id="postedby" runat="server">
        </div>
        <br />
        <div id="blogcontent" runat="server">
        </div>
        <br />
        <hr />
        <pn1:pagenav ID="pageNav1" runat="server" />
        <div id="comments" runat="server">
        </div>
        <pn1:pagenav ID="pageNav2" runat="server" />
        <div id="addcomment" runat="server">
            <hr />
            <br />
            <div class="formtitle" style="width: 530px; margin: auto;">
                Add Comment</div>
            <div class="formpanel" style="width: 520px; margin: auto;">
                <div id="anonymousbox" runat="server">
                    Name:
                    <asp:TextBox ID="tbxAnonymousName" Width="200px" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Required" Display="Dynamic"
                        ControlToValidate="tbxAnonymousName"></asp:RequiredFieldValidator><br />
                    <br />
                    Website:
                    <asp:TextBox ID="tbxAnonymousWebsite" Width="250px" runat="server"></asp:TextBox>
                    (optional)<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="* Invalid URL. Don't forget http://" Display="Dynamic" ControlToValidate="tbxAnonymousWebsite"
                        ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                </div>
                <asp:TextBox ID="tbxAddComment" Width="500px" Height="200px" TextMode="MultiLine"
                    runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="* Comment cannot be blank" Display="Dynamic" ControlToValidate="tbxAddComment"></asp:RequiredFieldValidator>
                <asp:CheckBox ID="cbxThumbsUp" Text="Give Thumbs Up!" ForeColor="#0000ff" runat="server" />
                <br />
                <br />
                <div id="anonymousbox2" runat="server">
                    <img style="border: solid 1px #000000;" src="JpegImage.aspx" />
                    <br />
                    Enter the code above in the box below.
                    <br />
                    <asp:TextBox ID="tbxCode" Width="200px" runat="server"></asp:TextBox><br />
                    <asp:CustomValidator ID="cvInvalidCode" Display="Dynamic" runat="server" ErrorMessage="* Invalid Code"></asp:CustomValidator>
                    <br />
                </div>
                <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
