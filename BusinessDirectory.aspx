<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="BusinessDirectory.aspx.cs" Inherits="BusinessDirectory" Title="Business Directory" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="categories" runat="server">
        <div class="contenttitle">
            Business Categories</div>
        <div class="contentpanel">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButtonCategory_Click">Accounting</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButtonCategory_Click">Aerospace and Defense</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButtonCategory_Click">Agriculture and Forestry</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButtonCategory_Click">Arts and Entertainment</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButtonCategory_Click">Associations</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButtonCategory_Click">Automitve</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButtonCategory_Click">Biotechnology and Pharmaceuticals</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButtonCategory_Click">Business and Society</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton31" runat="server" OnClick="LinkButtonCategory_Click">Business Services</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButtonCategory_Click">Chemicals</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButtonCategory_Click">Construction and Maintenance</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButtonCategory_Click">Consumer Goods and Services</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButtonCategory_Click">Cooperatives</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButtonCategory_Click">Customer Service</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButtonCategory_Click">Directories</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButtonCategory_Click">E-Commerce</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LinkButtonCategory_Click">Education and Training</asp:LinkButton><br />
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton17" runat="server" OnClick="LinkButtonCategory_Click">Electronics and Electrical</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton18" runat="server" OnClick="LinkButtonCategory_Click">Employment</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton19" runat="server" OnClick="LinkButtonCategory_Click">Energy</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton20" runat="server" OnClick="LinkButtonCategory_Click">Environment</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton21" runat="server" OnClick="LinkButtonCategory_Click">Financial Services</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton22" runat="server" OnClick="LinkButtonCategory_Click">Food and Related Products</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton23" runat="server" OnClick="LinkButtonCategory_Click">Healthcare</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton24" runat="server" OnClick="LinkButtonCategory_Click">Hospitality</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButtonCategory_Click">Human Resources</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton49" runat="server" OnClick="LinkButtonCategory_Click">Identity Theft and Legal Services</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton26" runat="server" OnClick="LinkButtonCategory_Click">Industrial Goods and Services</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButtonCategory_Click">Information Services</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton28" runat="server" OnClick="LinkButtonCategory_Click">Information Technology</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton50" runat="server" OnClick="LinkButtonCategory_Click">Insurance</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton29" runat="server" OnClick="LinkButtonCategory_Click">International Business and Trade</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton30" runat="server" OnClick="LinkButtonCategory_Click">Investing</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton32" runat="server" OnClick="LinkButtonCategory_Click">Major Companies</asp:LinkButton><br />
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton33" runat="server" OnClick="LinkButtonCategory_Click">Management</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton34" runat="server" OnClick="LinkButtonCategory_Click">Marketing and Advertising</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton35" runat="server" OnClick="LinkButtonCategory_Click">Materials</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton36" runat="server" OnClick="LinkButtonCategory_Click">Mining and Drilling</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton37" runat="server" OnClick="LinkButtonCategory_Click">News and Media</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton38" runat="server" OnClick="LinkButtonCategory_Click">Opportunities</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton39" runat="server" OnClick="LinkButtonCategory_Click">Publishing and Printing</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton40" runat="server" OnClick="LinkButtonCategory_Click">Real Estate</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton41" runat="server" OnClick="LinkButtonCategory_Click">Regional</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton42" runat="server" OnClick="LinkButtonCategory_Click">Resources</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton43" runat="server" OnClick="LinkButtonCategory_Click">Retail Trade</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton44" runat="server" OnClick="LinkButtonCategory_Click">Small Business</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton45" runat="server" OnClick="LinkButtonCategory_Click">Telecommunications</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton46" runat="server" OnClick="LinkButtonCategory_Click">Textiles and Nonwovens</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton47" runat="server" OnClick="LinkButtonCategory_Click">Transportation and Logistics</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton48" runat="server" OnClick="LinkButtonCategory_Click">Wholesale Trade</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="BusinessListings" runat="server">
        <div class="contenttitle">
            <span id="businesslistingstitle" runat="server"></span>
        </div>
        <div class="contentpanel">
            <pn1:pagenav ID="pageNav1" runat="server" />
            <div id="divBusinessListings" runat="server">
            </div>
            <pn1:pagenav ID="pageNav2" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="loggedinpanels" runat="server">
    </div>
</asp:Content>
