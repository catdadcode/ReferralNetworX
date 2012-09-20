<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManagePodcasts.aspx.cs" Inherits="ManagePodcasts" ValidateRequest="false"
    Title="Podcast Management" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New Podcast
        </div>
    </div>
    <div class="formpanel">
        <asp:CheckBox ID="cbxDeletePodcast" Text="Delete Podcast" runat="server" AutoPostBack="True"
            OnCheckedChanged="cbxDeletePodcast_CheckedChanged" />
        <br />
        <br />
        Title:<br />
        <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox>
        <br />
        <br />
        Episode Number:<br />
        <asp:TextBox ID="tbxEpisodeNumber" runat="server"></asp:TextBox>
        <br />
        <br />
        URL:<br />
        <asp:TextBox ID="tbxURL" Width="200px" runat="server"></asp:TextBox>
        <br />
        <br />
        Body:<br />
        <FCKeditorV2:FCKeditor ID="rteDescription" ToolbarSet="RNXAdministrator" Height="400px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numpodcasts" runat="server">0</span>&nbsp;Podcast(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxPodcasts" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxPodcasts_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewPodcast" runat="server" Text="Add New Podcast" CausesValidation="False"
            OnClick="btnAddNewPodcast_Click" />
    </div>
</asp:Content>
