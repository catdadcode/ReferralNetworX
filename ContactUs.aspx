<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="Contact Us" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Contact Us</div>
    <div class="formpanel">
        <div style="font-size: 20px; width: 475px; margin: auto;">
            Couldn't find the answer to your question anywhere else?
            <br />
            Contact us using the form below.
        </div>
        <br />
        <br />
        <div style="width: 475px; margin: auto;">
            Email:
            <asp:TextBox ID="tbxEmail" Width="300px" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxEmail"
                ErrorMessage="* Email Required"></asp:RequiredFieldValidator>
            <br />
            Message/Question:
            <br />
            <asp:TextBox ID="tbxQuestion" Width="450px" Height="150px" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />
            <br />
            <img style="border: solid 1px #000000; width: 150px;" src="JpegImage.aspx" />
            <br />
            <span style="font-size: 12px;">Enter the code above in the box below.</span>
            <br />
            <asp:TextBox ID="tbxCode" runat="server"></asp:TextBox><br />
            <asp:CustomValidator ID="cvInvalidCode" Display="Dynamic" runat="server" ErrorMessage="* Invalid Code"></asp:CustomValidator>
            <br />
            <asp:Button ID="btnSumbit" runat="server" Text="Send" OnClick="btnSumbit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="contenttitle">
        Related Links</div>
    <div class="contentpanel">
        <ul>
            <li><a href="FAQ.aspx">Frequently Asked Questions</a></li>
            <li><a href="Topics.aspx?board=12">Member Support</a></li>
            <li><a href="Topics.aspx?board=13">Technical Support</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
