<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Result.aspx.cs" Inherits="Result" Title="Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="resulttitle" runat="server">
        </div>
    </div>
    <div class="formpanel">
        <div id="divResult" style="margin: 100px 0px 100px; font-family: Arial;" runat="server">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
