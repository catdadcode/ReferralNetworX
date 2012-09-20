<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" Title="About Referral NetworX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://widgets.twimg.com/j/1/widget.js"></script>

    <link href="http://widgets.twimg.com/j/1/widget.css" type="text/css" rel="stylesheet" />
    <div class="contenttitle">
        About Referral NetworX</div>
    <div class="contentpanel">
        <div id="aboutus" runat="server">
        </div>
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
