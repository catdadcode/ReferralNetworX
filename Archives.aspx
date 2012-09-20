<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Archives.aspx.cs" Inherits="Archives" Title="Archives" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        <a class="titlelink" href="PodcastArchive.aspx">Podcast Archive</a>
    </div>
    <div class="contentpanel" style="font-size: 20px;">
        Stop in here to find the KRNX podcast archive. This archive contains every single
        episode ever recorded. Subscribe to us on iTunes or download episodes manually.
    </div>
    <div class="contenttitle">
        <a class="titlelink" href="NewsletterArchive.aspx">Newsletter Archive</a>
    </div>
    <div class="contentpanel" style="font-size: 20px;">
        Did you miss a newsletter? You can find past RNX newsletters right here in this
        archive!
    </div>
    <div class="contenttitle">
        <a class="titlelink" href="DailyMotivatorArchive.aspx">Daily Motivator Archive</a>
    </div>
    <div class="contentpanel" style="font-size: 20px;">
        If you are on the lookout for some inspiration or something to get you going in
        the morning, put down that coffee! The RNX Daily Motivator contains an endless stream
        of motivation and positive reinforcement that you can use in both your personal
        and business life.
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
