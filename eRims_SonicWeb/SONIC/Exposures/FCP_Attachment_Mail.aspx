<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FCP_Attachment_Mail.aspx.cs" Inherits="SONIC_Exposures_FCP_Attachment_Mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div>
        <table border="0" cellpadding="3" cellspacing="1" width="100%">
            <tr>
                <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                    align="left">
                    Mail
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="100%" border="0">
                        <tr>
                            <td class="lc" align="left" style="width: 25%;">
                                To Email Address
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td class="ic" align="left" style="width: 75%">
                                <asp:TextBox ID="txtToEmail" runat="server" MaxLength="255" Width="238px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtToEmail"
                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Please enter the email Address"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtToEmail"
                                    ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                    SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lc" align="left" style="width: 25%;">
                                Attachment
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td class="ic" align="left" style="width: 75%">
                                <asp:Label ID="lblAttachment" runat="server" />
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
                                <asp:TextBox ID="txtSubject" runat="server" MaxLength="255" Width="238px"></asp:TextBox>
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
                                <asp:TextBox ID="txtBody" runat="server" Height="100px" TextMode="MultiLine" Width="246px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic" colspan="3" align="center">
                                <asp:Button ID="btnSend" Text="Send" runat="server" OnClick="btnSend_Click" ValidationGroup="vsErrorGroup"
                                    Style="display: inline"></asp:Button>&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
