<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageDailyMotivator.aspx.cs" Inherits="ManageDailyMotivator" ValidateRequest="false"
    Title="Manage Daily Motivators" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New Daily Motivator
        </div>
    </div>
    <div class="formpanel">
        <asp:CheckBox ID="cbxDeleteDailyMotivator" Text="Delete Daily Motivator" runat="server"
            AutoPostBack="True" OnCheckedChanged="cbxDeleteDailyMotivator_CheckedChanged" />
        <br />
        <br />
        Title:
        <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox>
        <br />
        <br />
        YouTube Link:
        <asp:TextBox ID="tbxYouTubeLink" Width="300px" runat="server"></asp:TextBox>
        <br />
        <br />
        Body:<br />
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXAdministrator" Height="400px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="nummotivators" runat="server">0</span>&nbsp;Daily Motivator(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:Button ID="btnSendMotivator" runat="server" Text="Send Today's Motivator" OnClick="btnSendMotivator_Click" />
        <br />
        <br />
        <asp:ListBox ID="lbxDailyMotivators" Width="225px" Height="500px" runat="server"
            AutoPostBack="True" OnSelectedIndexChanged="lbxDailyMotivators_SelectedIndexChanged">
        </asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewDailyMotivator" runat="server" Text="Add New Daily Motivator"
            CausesValidation="False" OnClick="btnAddNewDailyMotivator_Click" />
    </div>
</asp:Content>
