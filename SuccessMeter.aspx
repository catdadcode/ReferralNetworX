<%@ Page Title="My Success Meter" Language="C#" MasterPageFile="~/Template.master"
    AutoEventWireup="true" CodeFile="SuccessMeter.aspx.cs" Inherits="SuccessMeter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        My Success Meter
    </div>
    <div class="formpanel">
        <div id="plannedfortoday" runat="server">
            Here's what you planned to do today...<br />
            <div id="todaysplan" style="border: solid 1px #333333; background-color: #ffffdd;
                font-size: 14px; padding: 5px;" runat="server">
            </div>
        </div>
        <br />
        <table style="width: 100%;">
            <tr>
                <td style="width: 425px; vertical-align: top;">
                    What did you do today? <a href="">(learn more)</a><br />
                    <asp:TextBox ID="tbxDidToday" TextMode="MultiLine" Width="400px" Height="300px" 
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Rate your success today:<br />
                    <asp:ImageButton ID="btnStar1" runat="server" 
                        ImageUrl="images/ratingstar_light.gif" onclick="StarMeter_Click" />
                    <asp:ImageButton ID="btnStar2" runat="server" 
                        ImageUrl="images/ratingstar_light.gif" Height="23px" onclick="StarMeter_Click" />
                    <asp:ImageButton ID="btnStar3" runat="server" 
                        ImageUrl="images/ratingstar_light.gif" onclick="StarMeter_Click" />
                    <asp:ImageButton ID="btnStar4" runat="server" 
                        ImageUrl="images/ratingstar_light.gif" onclick="StarMeter_Click" />
                    <asp:ImageButton ID="btnStar5" runat="server" 
                        ImageUrl="images/ratingstar_light.gif" onclick="StarMeter_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" 
                        onclick="btnUpdate_Click" />
                </td>
                <td style="vertical-align: top;">
                    <br />
                    <div style="width: 250px; height: 375px; border: solid 1px #333333; background-color: #ffffdd;
                        font-size: 14px; padding: 5px;">
                        <div style="text-align: center; font-family: Arial; color: #000000; font-size: 17px;">
                            What will this accomplish?
                        </div>
                        <div style="width: 220px; margin: auto; color: #005500;">
                            <li>The first step to take when you want to change something is to measure it. How can
                                you improve something if you don't know exactly where it's at?</li>
                            <li>This tool is best used in conjunction with the <a href="TomorrowPlanner.aspx">Tomorrow
                                Planner</a>. When you plan your tomorrow then the next day what you planned will
                                appear above this box. You can then compare what you planned to what you actually
                                did.</li>
                            <li>When you rate your success be honest with yourself. This tool is here to help you
                                and is completely private. Use the success meter to stay true to your mission and
                                accomplish your goals.</li>
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
            <li><a href="MissionStatement.aspx">My Mission Statement</a></li>
            <li><a href="AppreciationJournal.aspx">My Appreciation Journal</a></li>
            <li><a href="TomorrowPlanner.aspx">My Tomorrow Planner</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
