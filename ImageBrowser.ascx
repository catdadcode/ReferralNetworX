<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageBrowser.ascx.cs"
    Inherits="ImageBrowser" %>
<div id="ImageBrowserControl" runat="server">
    <asp:FileUpload ID="fuUploadImage" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" CausesValidation="false"
        OnClientClick="CopyText()" OnClick="btnUpload_Click" /><br />
    <div id="ExistingImages" runat="server">
    </div>
</div>
