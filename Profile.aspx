<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Profile.aspx.cs" Inherits="ProfilePage" Title="Profile" ValidateRequest="false" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://widgets.twimg.com/j/1/widget.js"></script>

    <link href="http://widgets.twimg.com/j/1/widget.css" type="text/css" rel="stylesheet" />
    <style type="text/css" id="profilestyle" runat="server">
        </style>
    <div id="profilepanel">
        <div class="formtitle">
            <div id="membername" runat="server">
                Profile
            </div>
        </div>
        <div class="formpanel" style="font-size: 20px; padding-top: 15px;">
            <div class="contenttitle">
                Personal Information</div>
            <div class="contentpanel">
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div class="dividerline" style="width: 40%; float: left; margin-right: 15px; margin-bottom: 5px;
                                padding: 10px;">
                                <asp:HyperLink ID="hlAvatar" runat="server">
                                    <asp:Image ID="imgAvatar" Width="100%" BorderWidth="0px" runat="server" />
                                </asp:HyperLink>
                                <br />
                                <br />
                                <b>Name: </b>
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                <br />
                                <b>Joined on: </b>
                                <asp:Label ID="lblJoinDate" runat="server"></asp:Label>
                                <br />
                                <div id="divAge" runat="server">
                                    <b>Age: </b>
                                    <asp:Label ID="lblAge" runat="server"></asp:Label>
                                    <br />
                                </div>
                                <b>Gender: </b>
                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                                <br />
                                <b>Location: </b>
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </div>
                            <div>
                                <div id="memberoptions" runat="server">
                                    <center>
                                        <asp:HyperLink ID="hlSendMessage" Style="font-size: 14px; text-decoration: none;"
                                            runat="server"><img style="width:50px;border-width:0px;" src="images/EmailIcon.png" />
                        Send this user a message.</asp:HyperLink></center>
                                    <br />
                                    <br />
                                </div>
                                <div id="twitterfeed" runat="server">
                                    <div id="twitterbox" runat="server">
                                    </div>
                                    <div id="twitterupdatebox" style="background-color: #77BB77; padding: 3px; border: solid 2px #333333;"
                                        runat="server">
                                        <asp:TextBox ID="tbxTwitterUpdate" MaxLength="140" Width="65%" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnTwitterUpdate" CausesValidation="false" Width="30%" runat="server"
                                            Text="Update" OnClick="btnTwitterUpdate_Click" />
                                    </div>
                                    <hr />
                                </div>
                                <b>Interests: </b>
                                <br />
                                <div id="divInterests" runat="server">
                                </div>
                                <br />
                                <hr />
                                <b>Bio: </b>
                                <br />
                                <div id="divPersonalBio" runat="server">
                                </div>
                                <div id="divSignature" runat="server">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="contenttitle">
                Business Information</div>
            <div class="contentpanel">
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div class="dividerline" style="width: 40%; float: left; margin-right: 15px; margin-bottom: 5px;
                                padding: 10px;">
                                <asp:HyperLink ID="hlLogo" runat="server">
                                    <asp:Image ID="imgLogo" Width="100%" BorderWidth="0px" runat="server" /></asp:HyperLink>
                                <br />
                                <br />
                                <b>Business Name: </b>
                                <asp:Label ID="lblBusinessName" runat="server"></asp:Label>
                                <br />
                                <b>Category: </b>
                                <asp:Label ID="lblBusinessCategory" runat="server"></asp:Label>
                            </div>
                            <div>
                                <b>Description: </b>
                                <div id="divBusinessDescription" runat="server">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="contenttitle">
                Contact Information</div>
            <div class="contentpanel">
                <b>Email: </b>
                <asp:HyperLink ID="hlEmail" runat="server"></asp:HyperLink>
                <br />
                <br />
                <b>Phone: </b>
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                <br />
                <br />
                <b>Website: </b>
                <asp:HyperLink ID="hlWebsite" runat="server"></asp:HyperLink>
                <br />
                <br />
                <b>Twitter Profile: </b>
                <asp:HyperLink ID="hlTwitterProfile" runat="server"></asp:HyperLink>
                <br />
                <br />
                <b>AOL Instant Messenger: </b>
                <asp:Label ID="lblAIM" runat="server"></asp:Label>
                <br />
                <br />
                <b>Windows Live Messenger: </b>
                <asp:Label ID="lblWLM" runat="server"></asp:Label>
                <br />
                <br />
                <b>Yahoo Messenger: </b>
                <asp:Label ID="lblYahoo" runat="server"></asp:Label>
                <br />
                <br />
                <b>Google Talk: </b>
                <asp:Label ID="lblGoogleTalk" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div id="commentbox" runat="server">
        <div class="contenttitle">
            <span id="numcomments" runat="server">0</span> Comment(s)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<span
                id="numthumbsup" runat="server">0</span> Thumbs Up!
        </div>
        <div class="contentpanel">
            <div style="background-color: #ffffff; border: solid 1px #333333;">
                <pn1:pagenav ID="pageNav1" runat="server" />
                <div id="comments" runat="server">
                </div>
                <pn1:pagenav ID="pageNav2" runat="server" />
            </div>
        </div>
        <div id="addcomment" runat="server">
            <div class="formtitle">
                Add Comment</div>
            <div class="formpanel">
                <asp:TextBox ID="tbxAddComment" Width="95%" Height="150px" TextMode="MultiLine" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                    ControlToValidate="tbxAddComment" ErrorMessage="* You must type something to leave a comment."></asp:RequiredFieldValidator>
                <asp:CheckBox ID="cbxThumbsUp" Text="Give Thumbs Up!" ForeColor="#0000ff" runat="server" />
                <br />
                <br />
                <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
