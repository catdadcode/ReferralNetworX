<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="SignUp.aspx.cs" Inherits="SignUp" Title="Sign Up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        #divSignup hr
        {
            border: dashed 3px #333333;
        }
    </style>
    <div id="signupform" runat="server">
        <div class="formtitle">
            Referral NetworX Sign Up
        </div>
        <div id="divSignup" class="formpanel">
            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <center>
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="signup" runat="server" />
                            <%--<div style="color: #ff0000;">
                                "Thank you for visiting Referral NetworX! Our automated sign up system is currently
                                down. You can still join! We are currently taking new members over the phone. Please
                                call 801-769-6018 to join. We apologize for the inconvenience and expect the system
                                to be functional by Monday 5/17/10. (we are at the mercy of the tekkis)"</div>--%>
                        </center>
                        <h2 align="center">
                            Personal Information</h2>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 40%;">
                        Email:
                    </td>
                    <td style="text-align: left; width: 60%;">
                        <asp:TextBox ID="tbxEmail" autocomplete="off" AutoCompleteType="None" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="signup"
                            ErrorMessage="* Email Already In Use" ControlToValidate="tbxEmail" EnableClientScript="False"
                            SetFocusOnError="True" Display="Dynamic"></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxEmail" ErrorMessage="* Email Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 40%;">
                        Confirm Email:
                    </td>
                    <td style="text-align: left; width: 60%;">
                        <asp:TextBox ID="tbxConfirmEmail" autocomplete="off" AutoCompleteType="None" runat="server"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxConfirmEmail" ErrorMessage="* Confirm Email Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxConfirmEmail" ControlToCompare="tbxEmail" ErrorMessage="* Emails do not match."
                            Display="Dynamic"></asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxEmail" ErrorMessage="* Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Password:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxPassword" TextMode="Password" autocomplete="off" AutoCompleteType="None"
                            runat="server"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxPassword" ErrorMessage="* Password Required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Confirm Password:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxConfirmPassword" TextMode="Password" autocomplete="off" AutoCompleteType="None"
                            runat="server"></asp:TextBox><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxPassword"
                            ControlToValidate="tbxConfirmPassword" ValidationGroup="signup" ErrorMessage="* Passwords do not match."
                            Display="Dynamic"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxConfirmPassword" ErrorMessage="* Confirm Password Required"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Full Name:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="tbxName" Width="250px" runat="server"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="signup"
                            ControlToValidate="tbxName" ErrorMessage="* Name Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; vertical-align: top;" colspan="2">
                        How did you hear about Referral NetworX?&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlHeardAboutUs" runat="server">
                            <asp:ListItem>Not Specified</asp:ListItem>
                            <asp:ListItem>Twitter</asp:ListItem>
                            <asp:ListItem>From A Friend</asp:ListItem>
                            <asp:ListItem>Internet Ad</asp:ListItem>
                            <asp:ListItem>RNX Podcast</asp:ListItem>
                            <asp:ListItem>Radio Interview</asp:ListItem>
                            <asp:ListItem>Television Interview</asp:ListItem>
                            <asp:ListItem>Magazine Interview</asp:ListItem>
                            <asp:ListItem>Facebook</asp:ListItem>
                            <asp:ListItem>Search Engine</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="signup"
                            ErrorMessage="* Please select how you heard about us" ControlToValidate="ddlHeardAboutUs"
                            InitialValue="Not Specified" Display="Dynamic">* Required</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </td>
                </tr>
               <%-- <tr>
                    <td colspan="2">
                        <hr />
                        <center>
                            <h2>
                                Billing Information</h2>
                            <!-- (c) 2005, 2009. Authorize.Net is a registered trademark of CyberSource Corporation -->
                            <div class="AuthorizeNetSeal">
                                <div style="width: 90px; border: solid 1px #333333;">

                                    <script type="text/javascript" language="javascript">                                        var ANS_customer_id = "f21ededa-cd8e-4a8e-9803-35fba21ee832";</script>

                                    <script type="text/javascript" language="javascript" src="//verify.authorize.net/anetseal/seal.js"></script>

                                </div>
                                <a href="http://www.authorize.net/" id="AuthorizeNetText" target="_blank">Secure Online
                                    Payments</a>
                            </div>
                        </center>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Membership:
                    </td>
                    <td style="text-align: left;">
                        <b>$19.95/mo</b>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        First Name:
                    </td>
                    <td style="text-align: left;">
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
                </tr>--%>
                <%-- <tr>
                    <td style="text-align: right;">
                        Phone:
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
                </tr>--%>
               <%-- <tr>
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
                </tr>--%>
                <tr>
                    <td colspan="2">
                        <hr />
                        <br />
                    </td>
                </tr>
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
                        <%--<div id="disclaimer" style="text-align: center;" runat="server">
                            By clicking submit you agree to have your credit card billed in the amount<br />
                            of $19.95 immediately and $19.95 every month thereafter until cancelled.
                        </div>
                        <br />--%>
                        <asp:Button ID="btnSubmit" CausesValidation="true" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
