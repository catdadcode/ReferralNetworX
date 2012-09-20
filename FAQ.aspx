<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="FAQ.aspx.cs" Inherits="FAQ" Title="Frequently Asked Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        Frequently Asked Questions</div>
    <div class="contentpanel">
    <hr />
    <br />
        <div id="FAQs" style="font-size:20px;" runat="server">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="contenttitle">
        Related Links</div>
    <div class="contentpanel">
        <ul>
            <li><a href="Topics.aspx?board=12">Member Support</a></li>
            <li><a href="Topics.aspx?board=13">Technical Support</a></li>
            <li><a href="ContactUs.aspx">Contact Us</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
