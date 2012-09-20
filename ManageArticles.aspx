<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ManageArticles.aspx.cs" Inherits="ManageArticles" ValidateRequest="false"
    Title="Article Management" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    window.onload = function()
    {
        document.frames[0].objContent.DOM.designMode = 'Off';
    }
    </script>

    <div class="formtitle">
        <div id="addedit" runat="server">
            Add New Article
        </div>
    </div>
    <div class="formpanel">
        <asp:CheckBox ID="cbxDeleteArticle" Text="Delete Article" runat="server" AutoPostBack="True"
            OnCheckedChanged="cbxDeleteArticle_CheckedChanged" />
        <br />
        <br />
        <div id="postedby" runat="server">
            Posted By: <span id="spanAuthor" style="font-weight: bold; border: solid 1px #333333;
                background-color: #77BB77; color: #ffffff; padding: 5px;" runat="server"></span>
        </div>
        <div id="checklist" runat="server">
            Before submitting an article be sure to read the
            <asp:HyperLink ID="hlGuidelines" NavigateUrl="~/ArticleChecklist.aspx" onclick="return confirm('Are you sure you want to navigate away from this page? All unsaved changes will be lost.');"
                runat="server">read the posting guidelines</asp:HyperLink>.
        </div>
        <br />
        Title:
        <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxTitle"
            ErrorMessage="* Title Required"></asp:RequiredFieldValidator>
        <br />
        Body:<br />
        <FCKeditorV2:FCKeditor ID="rteBody" ToolbarSet="RNXAdministrator" Height="400px"
            BasePath="fckeditor/" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:CheckBox ID="cbxDiscussionThread" Text="Allow comments on my article."
            runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="formtitle">
        Category</div>
    <div class="formpanel" style="text-align: center;">
        <asp:DropDownList ID="ddlCategory" Width="225px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <div class="formtitle">
        <span id="numarticles" runat="server">0</span>&nbsp;Article(s)</div>
    <div class="formpanel" style="text-align: center;">
        <asp:ListBox ID="lbxArticles" Width="225px" Height="500px" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="lbxArticles_SelectedIndexChanged"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAddNewArticle" runat="server" Text="Add New Article" CausesValidation="False"
            OnClick="btnAddNewArticle_Click" />
    </div>
</asp:Content>
