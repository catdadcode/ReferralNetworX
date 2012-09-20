<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" Title="Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="loggedincontent" runat="server">
    </div>
    <div id="loggedoutcontent" runat="server">
        <div class="contenttitle">
            Welcome to ReferralNetworX.com!</div>
        <div class="formpanel" style="text-align: center; font-size: 20px; font-weight: bold;
            font-family: Arial;">
            Use these links to learn more about our amazing community!<br />
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:LinkButton ID="lbWelcome" CssClass="navlink" runat="server" OnClick="lbWelcome_Click"
                            CausesValidation="False">Welcome</asp:LinkButton>
                    </td>
                    <td>
                        -=-
                    </td>
                    <td>
                        <asp:LinkButton ID="lbTakeATour" CssClass="navlink" runat="server" OnClick="lbTakeATour_Click"
                            CausesValidation="False">Key To Success</asp:LinkButton>
                    </td>
                    <td>
                        -=-
                    </td>
                    <%--<td>
                        <asp:LinkButton ID="lbTestimonials" CssClass="navlink" runat="server" OnClick="lbTestimonials_Click"
                            CausesValidation="False">Success Stories</asp:LinkButton>
                    </td
                    <td>
                        -=-
                    </td>>--%>
                    <td>
                        <asp:LinkButton ID="lbSignUp" CssClass="navlink" runat="server" Font-Size="25px"
                            Font-Bold="true" OnClick="lbSignUp_Click" CausesValidation="False">Sign Up!</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="text-align: left; font-weight: normal;">
                <div id="tour" style="border-top: dashed 10px #333333;" runat="server">
                    <br />
                    <div style="text-align: center; font-size: 35px;">
                        <div style="width: 550px; height: 400px; margin-left: auto; margin-right: auto; border: solid 5px #000000;">
                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
                                width="550" height="400" id="Yourfilename" align="">
                                <param name="movie" value="videos/RNXIntro.swf">
                                <param name="quality" value="high">
                                <embed src="videos/RNXIntro.swf" quality="high" width="550" height="400" name="RNXIntro"
                                    align="" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>
                            </object>
                        </div>
                        <a href="SignUp.aspx">SIGN UP NOW!</a>
                    </div>
                </div>
                <div id="pricing" style="border-top: dashed 10px #333333;" runat="server">
                    <div style="font-size: 25px;">
                        <h2 style="text-align: center; color: #0000ff;">
                            FREE for 7 days!</h2>
                        <h3 style="text-align: center; color: #0000ff;">
                            $19.95/mo</h3>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;At Referral NetworX we believe that if it's
                        good for the world then it is good for us. We want to reach as many business-minded
                        people as we possibly can. That is why we put in the extra effort to keep our price
                        down to an ultra-affordable level.<br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We are confident that the RNX community is such
                        a valuable resource for you as a business person. We want the tools and information
                        found here to be easily accessible and exciting. Click through to the sign up page
                        to subscribe for your free trial.
                        <br />
                        <br />
                        <div style="text-align: center">
                            You're gonna LOVE it here!</div>
                        <div style="text-align: center; font-size: 35px;">
                            <a href="SignUp.aspx">Join us today!</a>
                        </div>
                    </div>
                </div>
                <div id="testimoials" style="border-top: dashed 10px #333333;" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In this section we felt that we should show
                    off a little bit. Our members are AMAZING and we are so blessed to have them in
                    our ranks! Referral NetworX is barely six months old at the time of this writing
                    and already we have some amazing success stories. Without even going into the success
                    story of RNX itself, members have experienced some pretty amazing things that we
                    would like to share with you.
                    <br />
                    <br />
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        <a style="text-decoration: none;" href="Profile.aspx?member=newmancarrie@yahoo.com">
                            Carrie Newman
                            <br />
                            <img style="border-width: 0px;" src="http://www.referralnetworx.com/MakeThumbnail.aspx?size=250&image=images/MemberAvatars/newmancarrie@yahoo.com.JPG" /></a></div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>"&nbsp;&nbsp;I have loved being a member of Referral
                        Networx. I have learned so many things but the biggest is how to successfully receive
                        referrals from my existing customers. This has helped my business explode! I have
                        also met many amazing people. The quality of this group is phenomenal without the
                        expensive price tag of other networking groups."
                        <br />
                        <br />
                        Thanks,
                        <br />
                        <br />
                        Carrie Newman<br />
                        <a style="text-decoration: none;" href="http://www.afreshnewoutlook.com">
                            <img style="width: 250px; border-width: 0px;" src="http://www.referralnetworx.com/images/BusinessLogos/newmancarrie@yahoo.com.JPG" /><br />
                            www.AFreshNewOutlook.com</a></i>
                    <br />
                    <br />
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        <a style="text-decoration: none;" href="Profile.aspx?member=Mike@ConstructionMonsters.com">
                            Mike Douglas</a></div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>"&nbsp;&nbsp;As a member of Referral NetworX,
                        I find that my time is rewarded, and I don’t have to spend as much on marketing
                        and advertising. Just being there and participating helps keep my focus on the things
                        that matter for my business. I feel that I am more vested in others success, and
                        that others get more vested with me, also! I have seen 6 figure projects come out
                        of our networking efforts this past fall, and I am looking for ways to increase
                        my involvement. I love the education and success stories that come from Referral
                        NetworX!"
                        <br />
                        <br />
                        - Mike<br />
                        <a style="text-decoration: none;" href="http://www.ConstructionMonsters.com">
                            <img style="border-width: 0px;" src="http://www.referralnetworx.com/MakeThumbnail.aspx?size=300&image=images/BusinessLogos/scott@constructionmonsters.com.JPG" />
                            <br />
                            www.ConstructionMonsters.com</a></i>
                    <br />
                    <br />
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        <a style="text-decoration: none;" href="http://www.PCRescueTechs.com">Steve Morris</a></div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>"&nbsp;&nbsp;I found attending the Referral NetworX
                        meeting gave me a lot of hope. I was with other people trying to build their business.
                        Just getting to know other owners and independent operators gives you a sense of
                        being part of the community and not a stranger in town. That first meeting I met
                        a new client that has turned into a big account for me. Between the confidence of
                        getting to know others in my community and finding more clients I have been thrilled
                        with the results. In the end, having hope or the lack their of is key in succeeding.
                        Meeting with others of the same mind gives me great hope."
                        <br />
                        <br />
                        Thanks,
                        <br />
                        <br />
                        Steve Morris<br />
                        <a href="http://www.PCRescueTechs.com">
                            <img style="width: 250px; border-width: 0px;" src="http://www.pcrescuetechs.com/index_files/image7021.jpg" />
                            <br />
                            www.PCRescueTechs.com</a></i>
                    <br />
                    <br />
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        <a style="text-decoration: none;" href="Profile.aspx?member=newmancarrie@yahoo.com">
                            Holly M. Adams</a></div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>"&nbsp;&nbsp;I always look forward to the mornings
                        that I attend the Referral Networx meetings. The room is full of amazing people
                        willing to share their time and talents with everyone else. It has helped educate
                        me on how to better myself and my business. Networking is so important in today’s
                        business world; it is nice to have people on your team."
                        <br />
                        <br />
                        Holly M. Adams<br />
                        <a href="http://www.azaleadayspa.com">
                            <img style="width: 250px; border-width: 0px;" src="http://www.referralnetworx.com/images/BusinessLogos/hollysazalea@yahoo.com.jpg" />
                            <br />
                            www.AzaleaDaySpa.com</a></i>
                    <br />
                    <br />
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        <a style="text-decoration: none;" href="http://www.QtScraps.com">Karie Siqua</a>
                    </div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>"Hi Walt, I enjoyed the meeting on Friday for
                        the few minutes that I was there. :o) But it reminded me of the Bridal fair and
                        I wanted to share my experience with you especially, after you challenged everyone
                        who attended a networking event of 300 people to just walk away with only 2 contacts.
                        <br />
                        <br />
                        As you know the bridal fair is a very expensive event to attend, and just like any
                        event you participate in, you want to be sure you make it worth your time. Since
                        being apart of RNX, I've really been trying to focus more on building a lasting
                        relationship with my clients/competitors/acquaintances etc., vs just "getting exposure"
                        or making a contact for my personal and business life. RNX couldn't have come at
                        a better time in my life when starting a new business and getting "back in the game".
                        <br />
                        <br />
                        Typically at an event, many vendors usually have a prize box for drawing slips.
                        Even though you are taught these are your golden tickets for your business they
                        NEVER seemed very fruitful. Most of the time the person didn't even remember you
                        or your booth when you gave a follow up call because they were SO busy just entering
                        their information into everyone else's drawings. When I decided to stop doing prize
                        drawings, I didn't realize that I gave myself a better opportunity to get to know
                        the people really interested in my business and not just collect as many names as
                        possible within 2 (or more) hrs. When it came time to work the bridal fair this
                        time I kept in the back of my mind to do everything we've every talked about doing
                        at RNX - build a relationship with them.
                        <br />
                        <br />
                        I honestly can say it was SO hard to do this! To stay focused on the ONE client
                        when 3, 4, 8, 12 people were walking into the booth and wanted to know more!! (especially
                        when I was all by myself for the 1st hour) BUT, I did it. And there were even times
                        when all 4 of us where not enough to fill the clients needs, but again I did my
                        best to stay focused on the person I was talking to and not jump to a new person
                        in mid conversation (which I've done in past thinking I was "collecting" more clients).
                        There were 633 brides registered at this event. I spoke to 34 of them in my 8 hours
                        there. Even though it was fast pace and brides were there to get as much info as
                        they could, I noticed that when I spent the time with them, they came back for more
                        information. AND on top of that, I've had a much better response to my follow up
                        calls and emails too!
                        <br />
                        <br />
                        So THANK YOU for your training, and sharing your knowledge. I feel that RNX came
                        at a much better point in my life when just starting a new business and having an
                        open mind to new ideas too. Granted, I consider myself a nice person and like to
                        help people use a product they purchase, I do not like to sell, and then disappear
                        - repeat business has always been key for me, but the knowledge I'm gaining and
                        using in my day to day life has proven to strengthen my relationships. So Thank
                        you Again!
                        <br />
                        <br />
                        TTYS,
                        <br />
                        <br />
                        Karie<br />
                        Personal Publishing Consultant
                        <br />
                        <br />
                        QtKarie@gmail.com<br />
                        www.QtScraps.com<br />
                        www.StoriesLastForever.blogspot.com"</i>
                </div>
            </div>
        </div>
        <div id="welcome" runat="server">
            <div id="dailymotivator" runat="server">
            </div>
            <div id="latestblog" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="plmplayer" runat="server">
        <div class="formtitle">
            KRNX Podcast!
        </div>
        <div class="formpanel" style="text-align: center;">
            <div style="font-size: 20px; text-align: center; font-weight: bold;">
                <a style="text-decoration: none;" href="http://www.itunes.com/Podcast?id=341311374"
                    target="_blank">iTunes!<img src="images/iTunes.png" style="border-width: 0px; width: 20px;" /></a>
                <br />
                <a style="text-decoration: none;" href="http://feeds.feedburner.com/krnx" target="_blank">
                    RSS<img src="http://www.technewsdaily.com/images/stories/rss-02.gif" style="border: none;
                        width: 20px;" /></a>
                <hr />
                <a style="text-decoration: none; font-size: 15px;" href="PodcastArchive.aspx">Visit Our Podcast Archive</a>
            </div>
        </div>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
    <div id="loggedoutpanels" runat="server">
        <div class="formtitle">
            Newsletter!</div>
        <div class="formpanel">
            <div style="font-size: 15px; padding: 5px; border: solid 1px #375636; background-color: #DDFFDD;
                color: #375636; text-align: center; font-family: Arial;">
                Use this form to sign up for our newsletter as well as the daily motivator!
                <br />
                <br />
                Experience a taste of the RNX community and all it has to offer!</div>
            <br />
            <center>
                Name:
                <asp:TextBox ID="tbxNonMemberName" Width="100px" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNonMemberName"
                    Display="Dynamic" ErrorMessage="* Name Required"></asp:RequiredFieldValidator>
                <br />
                Email:
                <asp:TextBox ID="tbxNonMemberEmail" Width="100px" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Email Required"
                    Display="Dynamic" ControlToValidate="tbxNonMemberEmail"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="tbxNonMemberEmail"
                        runat="server" ErrorMessage="* Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <img style="border: solid 1px #000000; width: 150px;" src="JpegImage.aspx" />
                <br />
                <span style="font-size: 12px;">Enter the code above in the box below.</span>
                <br />
                <asp:TextBox ID="tbxCode" runat="server"></asp:TextBox><br />
                <asp:CustomValidator ID="cvInvalidCode" Display="Dynamic" runat="server" ErrorMessage="* Invalid Code"></asp:CustomValidator>
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Sign Me Up!" OnClick="btnSubmit_Click">
                </asp:Button>
            </center>
        </div>
    </div>
</asp:Content>
