<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Events.aspx.cs" Inherits="Events" Title="RNX Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://widgets.twimg.com/j/1/widget.js"></script>

    <link href="http://widgets.twimg.com/j/1/widget.css" type="text/css" rel="stylesheet" />
    <div class="contenttitle">
        Referral NetworX Events</div>
    <div class="contentpanel">
        <iframe src="https://www.google.com/calendar/embed?showTitle=0&amp;height=500&amp;wkst=1&amp;bgcolor=%23ffffff&amp;src=mbefgflbpid3295h84ije4jfe8%40group.calendar.google.com&amp;color=%23A32929&amp;ctz=America%2FDenver"
            style="border-width: 0" width="700" height="500" frameborder="0" scrolling="no">
        </iframe>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="margin-bottom: 15px;">
        <center>
            <div id="twtr-profile-widget">
            </div>

            <script>
new TWTR.Widget({
  profile: true,
  id: 'twtr-profile-widget',
  loop: true,
  width: 250,
  height: 300,
  theme: {
    shell: {
      background: '#77BB77',
      color: '#ffffff'
    },
    tweets: {
      background: '#DDFFDD',
      color: '#444444',
      links: '#1985b5'
    }
  }
}).render().setProfile('ReferralNetworX').start();
            </script>

        </center>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
