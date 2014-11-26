<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AbstractMail.aspx.cs" Inherits="SONIC_CRM_AbstractMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Erims Mail</title>
    <link href="../../App_Themes/Default/Default.css" type="text/css" />
    <script type="text/javascript">
        function Close() {
            self.close();
        }
    </script>
    <script language="javascript" type="text/javascript">
        function CheckValidation() {
            if (Page_ClientValidate("vsErrorGroup")) {

                var bValid = ValidateCCRecipientEmails();
                if (!bValid) {
                    alert('One or more Email Address in CC Email Address List is invalid.');
                    document.getElementById('txtCC').focus();
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        function validate(email) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            return reg.test(email);
        }

        function trim(str) {
            var str = str.replace(/^\s\s*/, ''),
		ws = /\s/,
		i = str.length;
            while (ws.test(str.charAt(--i)));
            return str.slice(0, i + 1);
        }

        function CheckEmailIds(objTxt) {
            var status = true;
            var i = 0;
            var emails = objTxt.value.split(",");
            for (i = 0; i < emails.length; i++) {
                if (!validate(trim(emails[i]))) {
                    //alert("Incorrect format: " + emails[i]);
                    status = false;
                    break;
                }
            }
            return status;
        }

        function ValidateCCRecipientEmails() {
            var txt = document.getElementById('txtCC');
            if (txt.value != '') {
                var bValid = CheckEmailIds(txt);
                return bValid;
            }
            else
                return true;
        }
    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="vsErrorGroup" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>      
    </div>
    
    <div id="dvContain" runat="server">
        <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;">
            <tr>
                <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                    align="left">
                    Mail
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="95%" border="0">
                        <tr>
                            <td class="lc" align="left" style="width: 25%;">
                                To Email Address&nbsp;<span style="color: Red">*</span>
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td class="ic" align="left" style="width: 75%">
                                <asp:TextBox ID="txtToEmail" runat="server" MaxLength="255" Width="338px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtToEmail"
                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Please enter the email Address"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtToEmail"
                                    ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                    SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lc" align="left" style="width: 25%;">
                                CC Email Address
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td class="ic" align="left" style="width: 75%">
                                <asp:TextBox ID="txtCC" runat="server" MaxLength="255" Width="338px"></asp:TextBox>
                               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCC"
                                    ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="CC Email Address Is Invalid"
                                    SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="lc" align="left">
                                Subject
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td class="ic" align="left">
                                <asp:TextBox ID="txtSubject" runat="server" MaxLength="255" Width="340px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="lc" align="left" valign="top">
                                Body
                            </td>
                            <td class="lc" valign="top">
                                :
                            </td>
                            <td class="ic" align="left">
                                <asp:TextBox ID="txtBody" runat="server" Height="100px" TextMode="MultiLine" Width="346px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="ic" colspan="3" align="center">
                                <asp:Button ID="btnSend" Text="Send" runat="server"  OnClientClick="return CheckValidation();" OnClick="btnSend_Click" ValidationGroup="vsErrorGroup"
                                   ></asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false"></asp:Label>
    <div style="display: none;">
        <asp:Label ID="lblScript" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
