<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Subscribe.aspx.cs" Inherits="Subscribe" Title="Subscriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="unsubscribepanel" runat="server">
        <div class="formtitle">
            Confirmation</div>
        <div class="formpanel" style="text-align: center;">
            <span style="font-size: 55px;">Are you sure?</span>
            <br />
            <br />
            <asp:Button ID="btnYes" runat="server" Text="Yes" onclick="btnYes_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                ID="btnNo" runat="server" Text="No" onclick="btnNo_Click" />
        </div>
    </div>
    <div id="subscribepanel" runat="server">
        <div class="formtitle">
            Subscribe</div>
        <div class="formpanel">
            Name:
            <asp:TextBox ID="tbxName" Width="250px" runat="server"></asp:TextBox><br />
            <br />
            Email:
            <asp:TextBox ID="tbxEmail" Width="300px" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="cbxDailyMotivator" Text="Daily Motivator" runat="server" />
            <br />
            <br />
            <asp:CheckBox ID="cbxNewsletter" Text="Newsletter" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnSumbit" runat="server" Text="Submit" 
                onclick="btnSumbit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
