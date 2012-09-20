<%@ Page Title="My Appreciation Journal" Language="C#" MasterPageFile="~/Template.master"
    AutoEventWireup="true" CodeFile="AppreciationJournal.aspx.cs" Inherits="AppreciationJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        My Appreciation Journal
    </div>
    <div class="formpanel">
        <table style="width: 100%;">
            <tr>
                <td style="width: 425px; vertical-align: top;">
                    What do you appreciate today? <a href="">(learn more)</a><br />
                    <asp:TextBox ID="tbxAppreciate" TextMode="MultiLine" Width="400px" Height="215px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                </td>
                <td style="vertical-align: top;">
                    <br />
                    <div style="width: 250px; height: 215px; border: solid 1px #333333; background-color: #ffffdd;
                        font-size: 14px; padding: 5px;">
                        <div style="text-align: center; font-family: Arial; color: #000000; font-size: 17px;">
                            Staying Positive
                        </div>
                        <div style="width: 220px; margin: auto; color: #005500;">
                            <li>Staying positive is all about learning to appreciate the things you take for granite.
                                No matter who you are or what your situation, there is always something to appreciate.</li>
                            <li>Even if all you can come up with is "I'm grateful for waking up today." then so
                                be it. No negative thoughts go in this box....only positive ones.</li>
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
            <li><a href="SuccessMeter.aspx">My Success Meter</a></li>
            <li><a href="TomorrowPlanner.aspx">My Tomorrow Planner</a></li>
        </ul>
    </div>
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
