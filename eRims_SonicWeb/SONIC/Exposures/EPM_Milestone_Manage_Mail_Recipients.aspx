<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EPM_Milestone_Manage_Mail_Recipients.aspx.cs"
    Inherits="SONIC_Exposures_EPM_Milestone_Manage_Mail_Recipients" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Environmental Project E-Mail Management</title>
    <script type="text/javascript">
        function BindMailRecipientList() {
            window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnhdnBindMailList").click();
            self.close();
        }
    </script>
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
                <td align="left" colspan="2">
                    <div class="bandHeaderRow">
                        Environmental Project E-Mail Management</div>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2">
                    Existing E-Mail Addresses
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:ListBox ID="lstEMail_Recipients" runat="server" Width="250px" Height="80px"
                        SelectionMode="Single" OnSelectedIndexChanged="lstEMail_Recipients_OnSelectedIndexChanged"
                        AutoPostBack="true" />
                </td>
                <td align="left" valign="top">
                    <table border="0" cellpadding="3" cellspacing="1" width="100%">
                        <tr>
                            <td align="left" valign="top" width="18%">
                                Name
                            </td>
                            <td align="left" valign="top" width="4%">
                                :
                            </td>
                            <td align="left" valign="top" width="28%">
                                <asp:TextBox ID="txtName" runat="server" Width="170px" MaxLength="50" />
                                <asp:RequiredFieldValidator ErrorMessage="Please Enter Name" ControlToValidate="txtName"
                                    runat="server" ValidationGroup="vsErrorGroup" Display="None" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" width="18%">
                                E-Mail
                            </td>
                            <td align="left" valign="top" width="4%">
                                :
                            </td>
                            <td align="left" valign="top" width="28%">
                                <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="255" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Enter E-Mail"
                                    ControlToValidate="txtEmail" runat="server" ValidationGroup="vsErrorGroup" Display="None"
                                    SetFocusOnError="True" />
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="E-Mail Address Is Invalid"
                                    SetFocusOnError="True" ToolTip="E-Mail Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr id="trDeleteEmail" runat="server" visible="false">
                            <td align="left" valign="top" width="18%">
                                Delete E-Mail
                            </td>
                            <td align="left" valign="top" width="4%">
                                :
                            </td>
                            <td align="left" valign="top" width="28%">
                                <asp:RadioButtonList ID="rdoDeleteEMail" runat="server" SkinID="YesNoType">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Button ID="btnAdd" Text="Add" runat="server" OnClick="btnAdd_OnClick" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_OnClick" CausesValidation="true"
                        ValidationGroup="vsErrorGroup" Visible="false" />
                    <input type="hidden" id="hdnBackTo" runat="server" value="1" />
                </td>
                <td align="center" valign="top">
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_OnClick" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
