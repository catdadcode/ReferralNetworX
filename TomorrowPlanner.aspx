<%@ Page Title="My Tomorrow Planner" Language="C#" MasterPageFile="~/Template.master"
    AutoEventWireup="true" CodeFile="TomorrowPlanner.aspx.cs" Inherits="TomorrowPlanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        My Tomorrow Planner</div>
    <div class="formpanel">
        <table style="width: 100%;">
            <tr>
                <td style="width: 425px; vertical-align: top;">
                    Plan your day tomorrow: <a href="">(learn more)</a><br />
                    <asp:TextBox ID="tbxTomorrowsPlan" TextMode="MultiLine" Width="400px" 
                        Height="335px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" 
                        onclick="btnUpdate_Click" />
                </td>
                <td style="vertical-align: top;">
                    <br />
                    <div style="width: 250px; height: 335px; border: solid 1px #333333; background-color: #ffffdd;
                        font-size: 14px; padding: 5px;">
                        <div style="text-align: center; font-family: Arial; color: #000000; font-size: 17px;">
                            What should I plan?
                        </div>
                        <div style="width: 220px; margin: auto; color: #005500;">
                            <li>The goal is to take your goals one day at a time. That's the reason the tomorrow
                                planner only lets you plan your tomorrow. It's too easy to get overwhelmed when
                                you look too far ahead. Instead focus on the here and the now. As long as you've
                                got your map you don't need to see more than 200 feet in front of your car.</li>
                            <li>Tomorrow you are going to use the <a href="SuccessMeter.aspx">Success Meter</a>
                                to rate how successful your day was. What will it take for you to comfortably rate
                                your day five stars tomorrow? Use this tool to plan out an effective day for yourself.</li>
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
            <li><a href="SuccessMeter.aspx">My Success Meter</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
