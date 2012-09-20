<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="MissionStatement.aspx.cs" Inherits="MissionStatement" Title="Mission Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        My Personal Mission Statement
    </div>
    <div class="formpanel">
        <table style="width: 100%;">
            <tr>
                <td style="width: 425px; vertical-align: top;">
                    What are your personal goals? <a href="http://www.referralnetworx.com/Blog.aspx?bid=122">(learn more)</a><br />
                    <asp:TextBox ID="tbxPersonalGoals" TextMode="MultiLine" Width="400px" Height="100px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Define what success means for you? <a href="http://www.referralnetworx.com/Blog.aspx?bid=123">(learn more)</a><br />
                    <asp:TextBox ID="tbxDefineSuccess" TextMode="MultiLine" Width="400px" Height="100px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    What do you believe about yourself? <a href="http://www.referralnetworx.com/Blog.aspx?bid=106">(learn more)</a><br />
                    <asp:TextBox ID="tbxWhatYouBelieve" TextMode="MultiLine" Width="400px" Height="100px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnUpdatePersonal" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                </td>
                <td style="vertical-align: top;">
                    <br />
                    <div style="width: 250px; height: 400px; border: solid 1px #333333; background-color: #ffffdd;
                        font-size: 14px; padding: 5px;">
                        <div style="text-align: center; font-family: Arial; color: #000000; font-size: 17px;">
                            Why Write A Personal<br />
                            Mission Statement?
                        </div>
                        <div style="width: 220px; margin: auto; color: #005500;">
                            <li>A personal mission statement is a brief but powerful summary of what you want out
                                of life. Writing a mission statement is a very important part of starting out on
                                your path to success.</li>
                            <li>In order to obtain a large goal you have to have a plan in place that will guide
                                your shorter term, day to day plans. Never start a road trip without a map.</li>
                            <li>Your mission statement will guide you on your journey and will reflect the way you
                                feel about yourself and success. Come back as often as possible and update your
                                personal mission statement. This is the first step to achieving your goal, don't
                                skimp on your dream!</li>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="formtitle">
        My Business Mission Statement
    </div>
    <div class="formpanel">
        <table style="width: 100%;">
            <tr>
                <td style="width: 425px; vertical-align: top;">
                    What are your business related goals? <a href="">(learn more)</a><br />
                    <asp:TextBox ID="tbxBusinessGoals" TextMode="MultiLine" Width="400px" Height="100px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    What are your thoughts about money? <a href="">(learn more)</a><br />
                    <asp:TextBox ID="tbxMoneyThoughts" TextMode="MultiLine" Width="400px" Height="100px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    What are you in business for? <a href="">(learn more)</a><br />
                    <asp:TextBox ID="tbxInBusinessFor" TextMode="MultiLine" Width="400px" Height="100px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnUpdateBusiness" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                </td>
                <td style="vertical-align: top;">
                    <br />
                    <div style="width: 250px; height: 400px; border: solid 1px #333333; background-color: #ffffdd;
                        font-size: 14px; padding: 5px;">
                        <div style="text-align: center; font-family: Arial; color: #000000; font-size: 17px;">
                            Why Write A Business<br />
                            Mission Statement?
                        </div>
                        <div style="width: 220px; margin: auto; color: #005500;">
                            <li>The reason for writing a business mission statement might seem obvious after writing
                                a personal one, but there is one key difference. The beliefs we hold about money
                                can be vastly different from the beliefs we hold about ourselves and our success.</li>
                            <li>If what we believe about money is not in line with what we believe about ourselves
                                then financial weath will remain forever unatainable.</li>
                            <li>Use your business mission statement to define your company's direction and align
                                your financial values with your personal ones. You are your business. Click "learn
                                more" on each field for more information.</li>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="contenttitle">
        Related Links</div>
    <div class="contentpanel">
        <ul>
            <li><a href="AppreciationJournal.aspx">My Appreciation Journal</a></li>
            <li><a href="SuccessMeter.aspx">My Success Meter</a></li>
            <li><a href="TomorrowPlanner.aspx">My Tomorrow Planner</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
