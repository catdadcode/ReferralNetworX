<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="SendMessage.aspx.cs" Inherits="SendMessage" Title="Send Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Send A Message
    </div>
    <div class="formpanel">
        <div style="width: 515px; margin-left: auto; margin-right: auto;">
            To:
            <asp:Label ID="lblTo" runat="server" Text=""></asp:Label><br />
            <br />
            Subject:
            <asp:TextBox ID="tbxSubject" Width="450px" runat="server"></asp:TextBox>
            <br />
            <br />
            Body:
            <br />
            <asp:TextBox ID="tbxBody" Width="500px" Height="200px" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
