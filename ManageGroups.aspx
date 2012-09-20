<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageGroups.aspx.cs" Inherits="ManageGroups" ValidateRequest="false"
    Title="Manage Physical Groups" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New Group
        </div>
    </div>
    <div class="formpanel">
        <asp:CheckBox ID="cbxDeleteGroup" Text="Delete Group" runat="server" AutoPostBack="True"
            OnCheckedChanged="cbxDeleteGroup_CheckedChanged" />
        <br />
        <br />
        Name:<br />
        <asp:TextBox ID="tbxGroupName" Width="400px" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxGroupName"
            ErrorMessage="* Required"></asp:RequiredFieldValidator>
        <br />
        State:
        <asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem>Alabama</asp:ListItem>
            <asp:ListItem>Alaska</asp:ListItem>
            <asp:ListItem>Arizona</asp:ListItem>
            <asp:ListItem>Arkansas</asp:ListItem>
            <asp:ListItem>California</asp:ListItem>
            <asp:ListItem>Colorado</asp:ListItem>
            <asp:ListItem>Connecticut</asp:ListItem>
            <asp:ListItem>Delaware</asp:ListItem>
            <asp:ListItem>Florida</asp:ListItem>
            <asp:ListItem>Georgia</asp:ListItem>
            <asp:ListItem>Hawaii</asp:ListItem>
            <asp:ListItem>Idaho</asp:ListItem>
            <asp:ListItem>Illinois</asp:ListItem>
            <asp:ListItem>Indiana</asp:ListItem>
            <asp:ListItem>Iowa</asp:ListItem>
            <asp:ListItem>Kansas</asp:ListItem>
            <asp:ListItem>Kentucky</asp:ListItem>
            <asp:ListItem>Louisiana</asp:ListItem>
            <asp:ListItem>Maine</asp:ListItem>
            <asp:ListItem>Maryland</asp:ListItem>
            <asp:ListItem>Massachusetts</asp:ListItem>
            <asp:ListItem>Michigan</asp:ListItem>
            <asp:ListItem>Minnesota</asp:ListItem>
            <asp:ListItem>Minnesota</asp:ListItem>
            <asp:ListItem>Mississippi</asp:ListItem>
            <asp:ListItem>Missouri</asp:ListItem>
            <asp:ListItem>Montana</asp:ListItem>
            <asp:ListItem>Nebraska</asp:ListItem>
            <asp:ListItem>Nevada</asp:ListItem>
            <asp:ListItem>New Hampshire</asp:ListItem>
            <asp:ListItem>New Jersey</asp:ListItem>
            <asp:ListItem>New Mexico</asp:ListItem>
            <asp:ListItem>New York</asp:ListItem>
            <asp:ListItem>North Carolina</asp:ListItem>
            <asp:ListItem>North Dakota</asp:ListItem>
            <asp:ListItem>Ohio</asp:ListItem>
            <asp:ListItem>Oklahoma</asp:ListItem>
            <asp:ListItem>Oregon</asp:ListItem>
            <asp:ListItem>Pennsylvania</asp:ListItem>
            <asp:ListItem>Rhode Island</asp:ListItem>
            <asp:ListItem>South Carolina</asp:ListItem>
            <asp:ListItem>South Dakota</asp:ListItem>
            <asp:ListItem>Tennessee</asp:ListItem>
            <asp:ListItem>Texas</asp:ListItem>
            <asp:ListItem>Utah</asp:ListItem>
            <asp:ListItem>Vermont</asp:ListItem>
            <asp:ListItem>Virginia</asp:ListItem>
            <asp:ListItem>Washington</asp:ListItem>
            <asp:ListItem>West Virginia</asp:ListItem>
            <asp:ListItem>Wisconsin</asp:ListItem>
            <asp:ListItem>Wyoming</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Group Information:<br />
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXAdministrator" Height="400px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        <span id="numGroups" runat="server">0</span>&nbsp;Groups</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxGroups" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxGroups_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewGroup" runat="server" Text="Add New Group" CausesValidation="False"
            OnClick="btnAddNewGroup_Click" />
    </div>
</asp:Content>
