<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendInspectionMail.aspx.cs" Inherits="SONIC_Exposures_SendInspectionMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Send Mail</title>
    <script language="javascript" type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        function ClosePage() {
            parent.parent.GB_hide();
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="2" cellspacing="0" border="0" width="560px" class="dvContainer">
        <tr>
            <td class="bandHeaderRow" colspan="3" width="100%">
                Mail
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="0">
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 8px;" width="100%">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td width="25%" align="left">
                            To Email Address
                        </td>
                        <td width="5px" align="center">
                            &nbsp;:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTo" runat="Server" ></asp:TextBox><br />
                            <span style="font-size: small">Use ',' to add multiple emails.</span>
                            &nbsp;<asp:RequiredFieldValidator ID="reqTo" runat="Server" ControlToValidate="txtTo"
                                SetFocusOnError="true" ErrorMessage="Please Enter E-mail Address" Display="None"
                                CssClass="NormalFont" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtTo"
                                SetFocusOnError="true" ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*,\s*|\s*$))*"
                                ErrorMessage="Please Enter Valid To E-mail Address" CssClass="NormalFont" Display="None"
                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td width="25%" align="left">
                            CC Email Address
                        </td>
                        <td width="5px" align="center">
                            &nbsp;:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCC" runat="Server" ></asp:TextBox><br />
                            <span style="font-size: small">Use ',' to add multiple emails.</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCC"
                                SetFocusOnError="true" ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*,\s*|\s*$))*"
                                ErrorMessage="Please Enter Valid CC E-mail Address" CssClass="NormalFont" Display="None"
                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td width="25%" align="left">
                            BCC Email Address
                        </td>
                        <td width="5px" align="center">
                            &nbsp;:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBCC" runat="Server" ></asp:TextBox><br />
                            <span style="font-size: small">Use ',' to add multiple emails.</span>                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBCC"
                                SetFocusOnError="true" ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*,\s*|\s*$))*"
                                ErrorMessage="Please Enter Valid BCC E-mail Address" CssClass="NormalFont" Display="None"
                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 8px;" width="100%">
                        </td>
                    </tr>                    
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 8px;" width="100%">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="left">
                            Subject
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSubject" runat="Server" MaxLength="250"></asp:TextBox>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 8px;" width="100%">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="left" valign="top">
                            Body
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td valign="top" align="left">
                            <asp:TextBox ID="txtBody" runat="Server" Rows="7" TextMode="multiLine" onkeypress="return CheckMaxLength(event, this,4000);"
                                onchange="return CheckMaxLength(event, this,4000);"></asp:TextBox>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 8px;" width="100%">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSend" runat="Server" OnClick="btnSend_Click" SkinID="send" ValidationGroup="vsErrorGroup" Text="Send" />&nbsp;
                            <asp:Button ID="btnClose" runat="server" SkinID="Close" OnClientClick="javascript:ClosePage();" Text="Close" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
