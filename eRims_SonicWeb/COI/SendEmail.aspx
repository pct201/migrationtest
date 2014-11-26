<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="Admin_SendEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript" src="../JavaScript/Validator.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <%--<div style="text-align:center;">
        <asp:Label ID="lblMsg" runat="Server" CssClass="msg1" EnableViewState="False"></asp:Label>
    </div>--%>
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
                            <asp:TextBox ID="txtTo" runat="Server" MaxLength="254"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="reqTo" runat="Server" ControlToValidate="txtTo"
                                SetFocusOnError="true" ErrorMessage="Please Enter E-mail Address" Display="None"
                                CssClass="NormalFont" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtTo"
                                SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="Please Enter Valid E-mail Address" CssClass="NormalFont" Display="None"
                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 8px;" width="100%">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="left">
                            Attachment
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAttachment" runat="Server" EnableViewState="false" CssClass="SmallFont"></asp:Label>
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
                            <asp:Button ID="btnSend" runat="Server" OnClick="btnSend_Click" SkinID="send" ValidationGroup="vsErrorGroup" />&nbsp;
                            <asp:Button ID="btnClose" runat="server" SkinID="Close" OnClientClick="javascript:window.close();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
