<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SabaTrainingFolloeUp.aspx.cs"
    Inherits="Administrator_SabaTrainingFolloeUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System :: Saba Training Import</title>
</head>
<body>

    <script type="text/javascript" language="javascript">
        function ShowHideEmail() {
            if (tblEmail.style.display == "none") {
                tblEmail.style.display = 'block';
            }
            else {
                tblEmail.style.display == "none";
            }
            return false;
        }
    </script>

    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvSabaTraining" runat="server" EnableTheming="false" Style="display: none"
            AutoGenerateColumns="true" HeaderStyle-HorizontalAlign="Left">
            <HeaderStyle Font-Bold="true" HorizontalAlign="Left" />
        </asp:GridView>
        <table width="80%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>eRims2 - Saba Training Import</b>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td align="left">
                    The Saba Training import procedure has run and completed on
                    <asp:Label ID="lblDate" runat="server" />
                    at
                    <asp:Label ID="lblTime" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblImported" runat="server" />&nbsp;of the&nbsp;<asp:Label ID="lblTotal"
                        runat="server" />&nbsp; records were imported into the database successfully.
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" runat="server" id="tblExceptions" style="display: none">
                        <tr>
                            <td class="Spacer" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="lnkExceptions" runat="server" Text="Click Here" OnClick="lnkExceptions_Click" />&nbsp;for
                                a list of exceptions by Saba Training.
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="lnkNotImported" runat="server" Text="Click Here" OnClick="lnkNotImported_Click" />&nbsp;for
                                an Excel File that includes records not imported into the database.
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="AMail" runat="server" Text="Click Here" OnClientClick="javascript:return ShowHideEmail();"></asp:LinkButton>&nbsp;to
                                send exception report on e-mail account.
                                <table id="tblEmail" width="100%" align="left" cellpadding="0" cellspacing="2" style="display: none;">
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="15%">
                                            TO :&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" SetFocusOnError="true" Display="Dynamic"
                                                 ControlToValidate="txtEmail" ValidationGroup="vsErrorEmail"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtEmail" runat="server" width="190px"></asp:TextBox><br />
                                            <asp:RegularExpressionValidator ID="regExEmail" ControlToValidate="txtEmail" ValidationGroup="vsErrorEmail"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Invalid Email Address"></asp:RegularExpressionValidator>
                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <asp:Button ID="btnSendEmail" runat="server" Text="Send Mail" ValidationGroup="vsErrorEmail"
                                                CausesValidation="true"  OnClick="btnSendMail_Click"  />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input type="hidden" id="hdnExceptionLinkClicked" runat="server" />
                    <input type="hidden" id="hdnExcelLinkClicked" runat="server" />
                    <asp:Button ID="btnClose" runat="server" Text="Close Window" OnClientClick="javascript:window.close();"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
