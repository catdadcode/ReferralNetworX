<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Edit My Profile"
    MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register Assembly="Karpach.WebControls" Namespace="Karpach.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        Edit My Profile
    </div>
    <div class="formpanel">
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        Personal Information
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 35%;">
                    Email:
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Name:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxName" Width="250px" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                        ControlToValidate="tbxName" ErrorMessage="* Name Required"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Personal Avatar:
                </td>
                <td style="text-align: left;">
                    <asp:FileUpload ID="fuPersonalAvatar" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Current Avatar:
                </td>
                <td style="text-align: left;">
                    <asp:Image ID="imgPersonalAvatar" runat="server" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Phone:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxPhone" Width="200px" runat="server"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                        runat="server" ControlToValidate="tbxPhone" ErrorMessage="* Invalid Phone Number"
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Interests:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxInterests" TextMode="MultiLine" Width="300px" Height="150px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Website:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxWebsite" Width="300px" runat="server"></asp:TextBox><br />
                    <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2"
                        runat="server" ControlToValidate="tbxWebsite" ErrorMessage="* Invalid Web Address (don't forget http://)"
                        ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Personal Bio:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxPersonalBio" TextMode="MultiLine" Height="150px" Width="300px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        Business Information
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Business Name:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxBusinessName" Width="250px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Business Category:
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlBusinessCategory" runat="server">
                        <asp:ListItem>Not Selcted</asp:ListItem>
                        <asp:ListItem>Accounting</asp:ListItem>
                        <asp:ListItem>Aerospace and Defense</asp:ListItem>
                        <asp:ListItem>Agriculture and Forestry</asp:ListItem>
                        <asp:ListItem>Arts and Entertainment</asp:ListItem>
                        <asp:ListItem>Associations</asp:ListItem>
                        <asp:ListItem>Automotive</asp:ListItem>
                        <asp:ListItem>Biotechnology and Pharmaceuticals</asp:ListItem>
                        <asp:ListItem>Business and Society</asp:ListItem>
                        <asp:ListItem>Business Services</asp:ListItem>
                        <asp:ListItem>Chemicals</asp:ListItem>
                        <asp:ListItem>Construction and Maintenance</asp:ListItem>
                        <asp:ListItem>Consumer Goods and Services</asp:ListItem>
                        <asp:ListItem>Cooperatives</asp:ListItem>
                        <asp:ListItem>Customer Service</asp:ListItem>
                        <asp:ListItem>Directories</asp:ListItem>
                        <asp:ListItem>E-Commerce</asp:ListItem>
                        <asp:ListItem>Education and Training</asp:ListItem>
                        <asp:ListItem>Electronics and Electrical</asp:ListItem>
                        <asp:ListItem>Employment</asp:ListItem>
                        <asp:ListItem>Energy</asp:ListItem>
                        <asp:ListItem>Environment</asp:ListItem>
                        <asp:ListItem>Financial Services</asp:ListItem>
                        <asp:ListItem>Food and Related Products</asp:ListItem>
                        <asp:ListItem>Healthcare</asp:ListItem>
                        <asp:ListItem>Hospitality</asp:ListItem>
                        <asp:ListItem>Human Resources</asp:ListItem>
                        <asp:ListItem>Identity Theft and Legal Services</asp:ListItem>
                        <asp:ListItem>Industrial Goods and Services</asp:ListItem>
                        <asp:ListItem>Information Services</asp:ListItem>
                        <asp:ListItem>Information Technology</asp:ListItem>
                        <asp:ListItem>Insurance</asp:ListItem>
                        <asp:ListItem>International Business and Trade</asp:ListItem>
                        <asp:ListItem>Investing</asp:ListItem>
                        <asp:ListItem>Major Companies</asp:ListItem>
                        <asp:ListItem>Management</asp:ListItem>
                        <asp:ListItem>Marketing and Advertising</asp:ListItem>
                        <asp:ListItem>Materials</asp:ListItem>
                        <asp:ListItem>Mining and Drilling</asp:ListItem>
                        <asp:ListItem>News and Media</asp:ListItem>
                        <asp:ListItem>Opportunities</asp:ListItem>
                        <asp:ListItem>Publishing and Printing</asp:ListItem>
                        <asp:ListItem>Real Estate</asp:ListItem>
                        <asp:ListItem>Regional</asp:ListItem>
                        <asp:ListItem>Resources</asp:ListItem>
                        <asp:ListItem>Retail Trade</asp:ListItem>
                        <asp:ListItem>Small Business</asp:ListItem>
                        <asp:ListItem>Telecommunications</asp:ListItem>
                        <asp:ListItem>Textiles and Nonwovens</asp:ListItem>
                        <asp:ListItem>Transportation and Logistics</asp:ListItem>
                        <asp:ListItem>Wholesale Trade</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span style="color: #ff0000;">* You must select a category if you want your
                        <br />
                        business to appear in the directory.</span>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Business Logo:
                </td>
                <td style="text-align: left;">
                    <asp:FileUpload ID="fuBusinessLogo" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Current Logo:
                </td>
                <td style="text-align: left;">
                    <asp:Image ID="imgBusinessLogo" runat="server" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Business Description:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxBusinessBio" TextMode="MultiLine" Height="150px" Width="300px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                    <div style="font-size: 35px; text-align: center;">
                        Other Information
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    AIM:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxAIM" Width="200px" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    MSN:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxMSN" Width="200px" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Yahoo:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxYahoo" Width="200px" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Google Talk:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxGoogleTalk" Width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Location:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxLocation" Width="250px" runat="server"></asp:TextBox><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Signature:
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="tbxSignature" TextMode="MultiLine" Height="100px" Width="300px"
                        runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Member Newsletter:
                </td>
                <td style="text-align: left;">
                    <asp:CheckBox ID="cbxMemberNewsletter" runat="server" />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Daily Motivator:
                </td>
                <td style="text-align: left;">
                    <asp:CheckBox ID="cbxDailyMotivator" runat="server" />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Show Age On Profile:
                </td>
                <td style="text-align: left;">
                    <asp:CheckBox ID="cbxShowEmail" runat="server" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 35%;">
                    Gender:
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlGender" runat="server">
                        <asp:ListItem>Not Specified</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Birthday:
                </td>
                <td style="text-align: left;">
                    &nbsp;&nbsp;&nbsp;Year:
                    <asp:DropDownList ID="ddlBirthYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBirth_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;Month:
                    <asp:DropDownList ID="ddlBirthMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBirth_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    Day:
                    <asp:Calendar ID="calBirthday" runat="server" BackColor="White" ShowNextPrevMonth="False">
                        <SelectedDayStyle BackColor="#77BB77" />
                        <TitleStyle BackColor="#77BB77" Font-Bold="True" Font-Size="20px" ForeColor="White" />
                    </asp:Calendar>
                    <br />
                </td>
            </tr>
        </table>
        <div style="border: solid 1px #000000; padding: 10px; background-color: #aaddaa;">
            <table style="width: 100%;">
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <div style="font-size: 30px; color: #0000ff;">
                            Have a Twitter Account?
                        </div>
                        <div style="font-size: 20px; color: #0000ff;">
                            Integrate it with your RNX profile!
                        </div>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 50%;">
                        Twitter Username:
                    </td>
                    <td style="text-align: left; width: 200px;">
                        <asp:TextBox ID="tbxTwitterUsername" autocomplete="off" AutoCompleteType="None" Width="150px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
