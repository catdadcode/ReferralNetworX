<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ArticleChecklist.aspx.cs" Inherits="ArticleChecklist" Title="Article Checklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contenttitle">
        Article Posting Guidelines</div>
    <div class="contentpanel">
        <h2>
            Before posting an article please review the following guidelines.</h2>
        <ul>
            <li>Is your article an original work? All articles must be your own work. You may reference
                other resources in your article but you may not copy and paste from other works
                that are not your own.</li>
            <li>Is your article copyrighted? Even if it's your own work that you are copying from
                another source you may have copyrighted it and sold the rights to someone else in
                the past. Be sure that you have the rights to your work before posting. Referral
                NetworX is not responsible for copyright violations by article authors.</li>
            <li>Is your article a complete topic? Because our members are paying to gain access
                to this content we require that articles be complete from start to finish. You may
                not post half an article with a link to another website that the reader must click
                to finish reading.</li>
            <li>Is your article an advertisement? An article may not be an advertisement for a product,
                service, or event. You are welcome to plug your own product or service within an
                article but it may not be the entire focus of the article. Articles are meant to
                be informational. An advertisement does not immediately benefit the reader and therefore
                it cannot be submitted as an article.</li>
            <li>Is your article timeless? It is important to envision reading your article five
                years from now; will it still be valuable? Articles do not have dates attached to
                them because they are meant to be timeless information that is valuable no matter
                when it is read. You can reference events and times, but avoid plugging events that
                will eventually pass and make the article irrelevent.</li>
            <li>Double check......no, triple check spelling and grammar. You do have the ability
                to edit articles after you have posted them, but do your best to present your first
                post with good grammar and spelling. One of the buttons in the article editor is
                a spell checker, take advantage of it.</li>
            <li>How long is your article? There is no required length for an article, but it is
                important to ensure that your article encompasses everything you intend it to. Have
                others proof read your article if need be, but make sure that your article explains
                your point with some depth.</li>
        </ul>
        <br />
        <div style="font-size: 25px; text-align: center;">
            <asp:LinkButton ID="lbtnIUnderstand" runat="server" 
                onclick="lbtnIUnderstand_Click">I UNDERSTAND</asp:LinkButton>
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
