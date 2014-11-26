<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErimsMail.aspx.cs" Inherits="ErimsMail"
    Theme="Default"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Erims Mail</title>
    <link href="App_Themes/Default/Default.css" type="text/css" />
    <script type="text/javascript">
    function Close()
    {
        self.close();
    }
    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
            <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
                ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
        </div>
        <div>
            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;">
                <tr>
                    <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                        align="left">
                        Mail
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="70%">
                            <tr>
                                <td class="lc" align="left" style="width: 50%;">
                                    To Email Address&nbsp;<span style="color:Red">*</span></td>
                                <td class="lc">
                                    :</td>
                                <td class="ic" align="left" style="width: 50%">
                                    <asp:TextBox ID="txtToEmail" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtToEmail" ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Please enter the email Address."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtToEmail"
                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lc" align="left" style="width: 50%;">
                                    Attachment</td>
                                <td class="lc">
                                    :</td>
                                <td class="ic" align="left" style="width: 50%;">
                                    <asp:Label ID="lblAttachment" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="lc" align="left" style="width: 50%;">
                                    Subject</td>
                                <td class="lc">
                                    :</td>
                                <td class="ic" align="left" style="width: 50%;">
                                    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="lc" align="left" style="width: 50%;" valign="top">
                                    Body</td>
                                <td class="lc" valign="top">
                                    :</td>
                                <td class="ic" align="left" style="width: 50%;">
                                    <asp:TextBox ID="txtBody" runat="server" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="ic" colspan="3" align="center">
                                    <asp:Button ID="btnSend" Text="Send" runat="server" OnClick="btnSend_Click" ValidationGroup="vsErrorGroup">
                                    </asp:Button></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display:none;">
        <asp:Label ID="lblScript" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
