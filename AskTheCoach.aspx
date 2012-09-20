<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="AskTheCoach.aspx.cs" Inherits="AskTheCoach" Title="Ask The Success Coach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Ask The Success Coach</div>
    <div class="formpanel">
        <div style="width: 475px; margin: auto;">
            <span style="font-size: 20px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Every week we post a blog
                where the "Success Coach" answers all your burning questions about business and
                life. Use the form below to submit your question and then keep an eye out on the
                blog for your answer!</span><br />
            <br />
            Question:
            <br />
            <asp:TextBox ID="tbxQuestion" Width="450px" Height="150px" TextMode="MultiLine" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxQuestion" ErrorMessage="* Question Required"></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="cbxAnonymous" Text="Ask Anonymously" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnSumbit" runat="server" Text="Ask The Success Coach" OnClick="btnSumbit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="contenttitle">
        Related Links</div>
    <div class="contentpanel">
        <ul>
            <li><a href="Blogs.aspx">The Blog</a></li>
            <li><a href="ContactUs.aspx">Contact Us</a></li>
            <li><a href="FAQ.aspx">Frequently Asked Questions</a></li>
            <li><a href="Topics.aspx?board=12">Member Support</a></li>
            <li><a href="Topics.aspx?board=13">Technical Support</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
