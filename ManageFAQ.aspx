<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageFAQ.aspx.cs" Inherits="ManageFAQ" Title="Manage FAQs" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New FAQ
        </div>
    </div>
    <div class="formpanel">
        <div style="width: 400px; margin: auto;">
            <asp:CheckBox ID="cbxDeleteFAQ" Text="Delete FAQ" runat="server" AutoPostBack="True"
                OnCheckedChanged="cbxDeleteFAQ_CheckedChanged" />
            <br />
            <br />
            Question:<br />
            <asp:TextBox ID="tbxQuestion" Width="400px" runat="server"></asp:TextBox>
            <br />
            <br />
            Answer:<br />
            <asp:TextBox ID="tbxAnswer" TextMode="MultiLine" Width="400px" Height="150px" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numFAQs" runat="server">0</span>&nbsp;FAQ(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxFAQs" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxFAQs_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewFAQ" runat="server" Text="Add New FAQ" CausesValidation="False"
            OnClick="btnAddNewFAQ_Click" />
    </div>
</asp:Content>
