<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Newsletter.aspx.cs" Inherits="Newsletter" Title="Newsletter Preview"
    ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Edit Newsletter
    </div>
    <div class="formpanel" style="text-align: center;">
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXAdministrator" Height="400px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="btnSubmitChanges" runat="server" CausesValidation="false" Text="Update Preview"
            OnClick="btnSubmitChanges_Click" />
    </div>
    <div class="formtitle" style="border: solid 3px #333333; border-bottom: solid 0px #333333;">
        Newsletter&nbsp;Preview
    </div>
    <div style="background-image: url(images/grid2.gif); border: solid 3px #333333; padding: 50px;
        overflow: auto; margin-bottom: 25px; height: 400px; overflow: auto;">
        <div style="border: dashed 5px #000000; margin: auto; width: 800px;">
            <div style="width: 790px; background-color: #333333; padding: 5px; border: solid 1px #333333;">
                <img src="http://www.referralnetworx.com/images/banner.jpg" />
                <img style="height: 125px;" src="http://www.referralnetworx.com/images/networking.jpg" />
            </div>
            <div id="divNewsletterContent" style="width: 770px; background-color: #ddeedd; padding: 15px;
                border: solid 1px #333333;" runat="server">
            </div>
            <div style="font-size: 12px; border: solid 1px #333333; background-color: #ddeedd;
                padding: 5px; width: 790px;">
                Click <span style="color: #0000ff; text-decoration: underline;">here</span> to unsubscribe.
            </div>
        </div>
        <br />
        <br />
    </div>
    <div class="formtitle">
        Send Newsletter
    </div>
    <div class="formpanel" style="text-align: center;">
        Send Group:
        <asp:DropDownList ID="ddlSendGroup" runat="server">
            <asp:ListItem>All Members</asp:ListItem>
            <asp:ListItem>Article Authors</asp:ListItem>
            <asp:ListItem>Non-members</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Subject:
        <asp:TextBox ID="tbxSubject" Width="500px" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbxSubject"
            runat="server" ErrorMessage="* Subject Required"></asp:RequiredFieldValidator>
        <br />
        <asp:CheckBox ID="cbxArchive" Text="Add this newsletter to the archive." runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSend" OnClientClick="CopyText()" runat="server" Text="Send Newsletter"
            OnClick="btnSend_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
