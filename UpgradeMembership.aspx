<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="UpgradeMembership.aspx.cs" Inherits="UpgradeMembership" Title="Upgrade My Membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="upgradeform" runat="server">
        <div class="formtitle">
            Upgrade My Membership
        </div>
        <div class="formpanel">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: center; color: #ff0000; font-size: 20px;" colspan="2">
                        <div id="divExpired" style="width: 500px; margin: auto;" runat="server">
                            Your trial period has expired.<br />
                            We encourage you to upgrade your membership so that we can continue to benefit from
                            your presence in the community!
                            <br />
                            <br />
                            <br />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 40%;">
                        Membership Type:
                    </td>
                    <td style="text-align: left; width: 60%;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMembershipType" AutoPostBack="true" OnSelectedIndexChanged="ddlMembershipType_SelectedIndexChanged"
                                    runat="server">
                                    <asp:ListItem>Online-Only ($9.95/mo)</asp:ListItem>
                                    <asp:ListItem>Full Membership ($29.95/mo)</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <div id="divPhysicalGroupDropDown" runat="server">
                                    <asp:DropDownList ID="ddlPhysicalGroup" runat="server">
                                        <asp:ListItem>Select A Group</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvPhysicalGroup" Display="Dynamic" ValidationGroup="signup"
                                        runat="server" ErrorMessage="* Physical Group Required">
                                    </asp:CustomValidator>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                    </td>
                </tr>
            </table>
            <table id="ccinfo" style="width: 100%;" runat="server">
                <tr>
                    <td style="text-align: right; width: 40%;">
                        First Name:
                    </td>
                    <td style="text-align: left; width: 60%;">
                        <asp:TextBox ID="tbxBillingFirstName" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxBillingFirstName" ErrorMessage="* Billing First Name Required"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Last Name:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxBillingLastName" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxBillingLastName" ErrorMessage="* Billing Last Name Required"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Address:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxBillingAddress" Width="300px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxBillingAddress" ErrorMessage="* Billing Address Required"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        City:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxBillingCity" Width="250px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxBillingCity" ErrorMessage="* Billing City Required"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        State:
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlBillingState" runat="server">
                            <asp:ListItem>AL</asp:ListItem>
                            <asp:ListItem>AK</asp:ListItem>
                            <asp:ListItem>AS</asp:ListItem>
                            <asp:ListItem>AZ</asp:ListItem>
                            <asp:ListItem>AR</asp:ListItem>
                            <asp:ListItem>CA</asp:ListItem>
                            <asp:ListItem>CO</asp:ListItem>
                            <asp:ListItem>CT</asp:ListItem>
                            <asp:ListItem>DE</asp:ListItem>
                            <asp:ListItem>DC</asp:ListItem>
                            <asp:ListItem>FM</asp:ListItem>
                            <asp:ListItem>FL</asp:ListItem>
                            <asp:ListItem>GA</asp:ListItem>
                            <asp:ListItem>GU</asp:ListItem>
                            <asp:ListItem>HI</asp:ListItem>
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>IL</asp:ListItem>
                            <asp:ListItem>IN</asp:ListItem>
                            <asp:ListItem>IA</asp:ListItem>
                            <asp:ListItem>KS</asp:ListItem>
                            <asp:ListItem>KY</asp:ListItem>
                            <asp:ListItem>LA</asp:ListItem>
                            <asp:ListItem>ME</asp:ListItem>
                            <asp:ListItem>MH</asp:ListItem>
                            <asp:ListItem>MD</asp:ListItem>
                            <asp:ListItem>MA</asp:ListItem>
                            <asp:ListItem>MI</asp:ListItem>
                            <asp:ListItem>MN</asp:ListItem>
                            <asp:ListItem>MS</asp:ListItem>
                            <asp:ListItem>MO</asp:ListItem>
                            <asp:ListItem>MT</asp:ListItem>
                            <asp:ListItem>NE</asp:ListItem>
                            <asp:ListItem>NV</asp:ListItem>
                            <asp:ListItem>NH</asp:ListItem>
                            <asp:ListItem>NJ</asp:ListItem>
                            <asp:ListItem>NM</asp:ListItem>
                            <asp:ListItem>NY</asp:ListItem>
                            <asp:ListItem>NC</asp:ListItem>
                            <asp:ListItem>ND</asp:ListItem>
                            <asp:ListItem>MP</asp:ListItem>
                            <asp:ListItem>OH</asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>OR</asp:ListItem>
                            <asp:ListItem>PW</asp:ListItem>
                            <asp:ListItem>PA</asp:ListItem>
                            <asp:ListItem>PR</asp:ListItem>
                            <asp:ListItem>RI</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>SD</asp:ListItem>
                            <asp:ListItem>TN</asp:ListItem>
                            <asp:ListItem>TX</asp:ListItem>
                            <asp:ListItem>UT</asp:ListItem>
                            <asp:ListItem>VT</asp:ListItem>
                            <asp:ListItem>VI</asp:ListItem>
                            <asp:ListItem>VA</asp:ListItem>
                            <asp:ListItem>WA</asp:ListItem>
                            <asp:ListItem>WV</asp:ListItem>
                            <asp:ListItem>WI</asp:ListItem>
                            <asp:ListItem>WY</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Zip:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxBillingZip" Width="150px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxBillingZip" ErrorMessage="* Billing Zip Code Required"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbxBillingZip"
                            ErrorMessage="* Invalid Zip Code" ValidationGroup="signup" ValidationExpression="\d{5}(-\d{4})?"
                            Display="Dynamic"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Credit Card #:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxBillingCreditCard" Width="300px" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbxBillingCreditCard"
                            ErrorMessage="* Credit Card # Required" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2" runat="server" ValidationGroup="signup" ControlToValidate="tbxBillingCreditCard"
                                ErrorMessage="* Invalid Credit Card" ValidationExpression="^((4\d{3})|(5[1-5]\d{2})|(6011))-?\d{4}-?\d{4}-?\d{4}|3[4,7]\d{13}$"
                                Display="Dynamic"></asp:RegularExpressionValidator><br />
                        <asp:CustomValidator ID="CustomValidator3" runat="server" ValidationGroup="signup"
                            ErrorMessage="Your card was declined. Please verify your billing information."
                            SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Expiration:
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlBillingExpirationMonth" runat="server">
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
                        /
                        <asp:DropDownList ID="ddlBillingExpirationYear" runat="server">
                        </asp:DropDownList>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <center>
                            <!-- (c) 2005, 2009. Authorize.Net is a registered trademark of CyberSource Corporation -->
                            <div class="AuthorizeNetSeal">
                                <div style="width: 90px; border: solid 1px #333333;">

                                    <script type="text/javascript" language="javascript">var ANS_customer_id="f21ededa-cd8e-4a8e-9803-35fba21ee832";</script>

                                    <script type="text/javascript" language="javascript" src="//verify.authorize.net/anetseal/seal.js"></script>

                                </div>
                                <a href="http://www.authorize.net/" id="AuthorizeNetText" target="_blank">Secure Online
                                    Payments</a>
                            </div>
                        </center>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: center; vertical-align: top;" colspan="2">
                        <div style="text-align: left; width: 500px; margin: auto;">
                            Terms of Service:
                            <asp:TextBox ID="tbxTermsOfUse" TextMode="MultiLine" ReadOnly="true" Width="510px"
                                Height="100px" runat="server">This is the web site of Referral NetworX.

Our postal address is
PO BOX 973
Pleasant Grove, UT, 84062
We can be reached via e-mail at admin@referralnetworx.com
or you can reach us by telephone at (801) 669-6663

For each visitor to our Web page, our Web server automatically recognizes the consumer's domain name and e-mail address (where possible).

We collect the domain name and e-mail address (where possible) of visitors to our Web page, the e-mail addresses of those who post messages to our bulletin board, the e-mail addresses of those who communicate with us via e-mail, the e-mail addresses of those who make postings to our chat areas, aggregate information on what pages consumers access or visit, user-specific information on what pages consumers access or visit, information volunteered by the consumer, such as survey information and/or site registrations, name and address, telephone number, payment information (e.g., credit card number and billing address).

The information we collect is used to improve the content of our Web page, used to customize the content and/or layout of our page for each individual visitor, used to notify consumers about updates to our Web site, , disclosed when legally required to do so, at the request of governmental authorities conducting an investigation, to verify or enforce compliance with the policies governing our Website and applicable laws or to protect against misuse or unauthorized use of our Website.

With respect to cookies: We use cookies to store visitors preferences.

If you do not want to receive e-mail from us in the future, please let us know by sending us e-mail at the above address, calling us at the above telephone number, writing to us at the above address, visiting us at http://www.referralnetworx.com.

We do not share your information with third parties.

With respect to Ad Servers: We do not partner with or have special relationships with any ad server companies.

From time to time, we may use customer information for new, unanticipated uses not previously disclosed in our privacy notice. If our information practices change at some time in the future we will contact you before we use your data for these new purposes to notify you of the policy change and to provide you with the ability to opt out of these new uses, we will post the policy changes to our Web site to notify you of these changes and provide you with the ability to opt out of these new uses. If you are concerned about how your information is used, you should check back at our Web site periodically, we will post the policy changes to our Web site to notify you of these changes and we will use for these new purposes only data collected from the time of the policy change forward. If you are concerned about how your information is used, you should check back at our Web site periodically.
Customers may prevent their information from being used for purposes other than those for which it was originally collected by e-mailing us at the above address, writing to us at the above address, visiting us at http://www.referralnetworx.com/ContactUs.aspx.

Upon request we provide site visitors with access to all information [including proprietary information] that we maintain about them, financial information (e.g., credit card account information) that we maintain about them, unique identifier information (e.g., customer number or password) that we maintain about them, transaction information (e.g., dates on which customers made purchases, amounts and types of purchases) that we maintain about them, communications that the consumer/visitor has directed to our site (e.g., e-mails, customer inquiries), contact information (e.g., name, address, phone number) that we maintain about them , a description of information that we maintain about them.
Consumers can access this information by e-mail us at the above address, visiting us at http://www.referralnetworx.com/EditProfile.aspx.

Upon request we offer visitors the ability to have inaccuracies corrected in contact information, financial information, unique identifiers, transaction information, communications that the consumer/visitor has directed to the site.
Consumers can have this information corrected by sending us e-mail at the above address, visiting us at http://www.referralnetworx.com/EditProfile.aspx.

With respect to security: We have appropriate security measures in place in our physical facilities to protect against the loss, misuse or alteration of information that we have collected from you at our site.

If you feel that this site is not following its stated information policy, you may contact us at the above addresses or phone number, The DMA's Committee on Ethical Business Practices at mgoldberger@the-dma.org, state or local chapters of the Better Business Bureau, state or local consumer protection office, The Federal Trade Commission by phone at 202.FTC-HELP (202.382.4357) or electronically at http://www.ftc.gov/ftc/complaint.htm.

Upon successful payment/sign-up you will be granted instant access to the website and all content therein.</asp:TextBox>
                            <br />
                            <asp:CheckBox ID="cbxAgree" ForeColor="#ff0000" Text="I Agree." runat="server" />
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ValidationGroup="signup"
                                ErrorMessage="* You must agree to the Terms of Service." Display="Dynamic"></asp:CustomValidator>
                        </div>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div id="disclaimer" style="text-align: center;" runat="server">
                                    By clicking submit you agree to have your credit card billed in the amount<br />
                                    of $9.95 immediately and $9.95 every month thereafter until cancelled.
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlMembershipType" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="receiptform" runat="server">
        <div class="contenttitle">
            Confirmation Receipt</div>
        <div class="contentpanel">
            <div style="font-size: 35px; color: #007700; text-align: center;">
                Congratulations!<br />
                You are now a member of ReferralNetworX.com.</div>
            <br />
            Your card was billed in the amount of $<span id="receiptprice" runat="server"></span>
            the same amount each month until cancelled. Your next bill date is <span style="font-weight: bold;"
                id="customernextbilldate" runat="server"></span>. You can cancel your membership
            at any time via email to <a href="mailto:support@referralnetworx.com">Support@ReferralNetworX.com</a>
            or by phone at (801) 669-6663.
            <br />
            <br />
            Your subscription ID is: <span id="customersubscriptionid" style="font-weight: bold;"
                runat="server"></span>&nbsp;(Please keep this in a safe place)<br />
            <br />
            Next Billing Date: <span style="font-weight: bold;" id="customernextbilldate2" runat="server">
            </span>
            <br />
            <br />
            Name: <span style="font-weight: bold;" id="customername" runat="server"></span>
            <br />
            <br />
            Address: <span style="font-weight: bold;" id="customeraddress" runat="server"></span>
            <br />
            <br />
            City: <span style="font-weight: bold;" id="customercity" runat="server"></span>
            <br />
            <br />
            State: <span style="font-weight: bold;" id="customerstate" runat="server"></span>
            <br />
            <br />
            Zip: <span style="font-weight: bold;" id="customerzip" runat="server"></span>
            <br />
            <br />
            Card #: <span style="font-weight: bold;">XXXXXXXXXXXX<span></span><span style="font-weight: bold;"
                id="customerlast4" runat="server"></span><br />
                <br />
                Expires: <span style="font-weight: bold;" id="customerexpiration" runat="server">
                </span>
                <br />
                <br />
                <div style="text-align: center; font-size: 20px;">
                    <a href="http://www.ReferralNetworX.com">(Click to continue)</a></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
