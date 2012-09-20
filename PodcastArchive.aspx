<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="PodcastArchive.aspx.cs" Inherits="PodcastArchive" Title="Podcast Archive" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        KRNX Podcast Archive</div>
    <div class="contentpanel">
        <pn1:pagenav ID="pageNav1" runat="server" />
        <div id="podcasts" runat="server">
        </div>
        <pn1:pagenav ID="pageNav2" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="contenttitle" style="width: 250px;">
        Subscribe
    </div>
    <div class="contentpanel" style="text-align: center; font-size: 20px; font-weight: bold;">
        <a style="text-decoration: none;" href="http://www.itunes.com/Podcast?id=341311374"
            target="_blank">iTunes!<img src="images/iTunes.png" style="border-width: 0px; width: 20px;" /></a>
        <br />
        <a style="text-decoration: none;" href="http://feeds.feedburner.com/krnx" target="_blank">
            RSS<img src="http://www.technewsdaily.com/images/stories/rss-02.gif" style="border: none;
                width: 20px;" /></a>
    </div>
    <div class="contenttitle" style="width: 250px;">
        <span style="font-size: 17px;">Help Keep The Lights On!</span>
    </div>
    <div style="text-align: center;" class="contentpanel">
        One-time Donation (any amount)<br />
        <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8F3MQSAEHG3RY">
            <img alt="" border="0" src="images/donate.gif" />
        </a>
        <br />
        <br />
        $5 Monthly Donation <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CP3KFUPTTLSQG">
            <img alt="" border="0" src="images/subscribe.gif" />
        </a>
        <br />
        <br />
        $10 Monthly Donation <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=G8WFHSEFF64EG">
            <img alt="" border="0" src="images/subscribe.gif" />
        </a>
        <br />
        <br />
        $25 Monthly Donation <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KPJ5X92MHDGBA">
            <img alt="" border="0" src="images/subscribe.gif" />
        </a>
    </div>
    <div class="contenttitle">
    </div>
    <div style="text-align: center;" class="contentpanel">
        <script type="text/javascript"><!--
            google_ad_client = "pub-1304273391516838";
            /* 120x600, created 11/8/10 */
            google_ad_slot = "7388442429";
            google_ad_width = 120;
            google_ad_height = 600;
//-->
        </script>
        <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
