<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup_SLT_ReviewMail.aspx.cs"
    Inherits="SONIC_SLT_Popup_SLT_ReviewMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="vsErrorSLT_Members"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td colspan="3" align="left" valign="top">
                    <div class="bandHeaderRow">
                        SLT Meeting Review Recipients
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2" align="left" valign="top">
                    <span style="font-weight: bold; font-size: 12px">SLT Meeting Attendees</span>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" width="15%">
                    &nbsp;
                </td>
                <td align="center" valign="top" width="75%">
                    <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="false" EmptyDataText="No records Found"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" runat="server" Checked="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left" DataField="First_Name"
                                ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left" DataField="Last_Name"
                                ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="Email Address" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td align="left" valign="top" width="10%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2" align="left" valign="top">
                    <span style="font-weight: bold; font-size: 12px">SLT Additional Recipients</span>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" width="15%">
                    &nbsp;
                </td>
                <td align="center" valign="top" width="75%">
                    <asp:GridView ID="gvAdditional_Recipients" runat="server" AutoGenerateColumns="false"
                        EmptyDataText="No records Found" Width="100%" OnRowCommand="gvAdditional_Recipients_RowCommand"
                        EnableViewState="true">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectedAdditional" runat="server" Checked="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left" DataField="First_Name"
                                ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left" DataField="Last_Name"
                                ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="Email Address" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure to remove the record?');" CommandName="RemoveRecipient"
                                        CommandArgument='<%#Eval("PK_SLT_Additional_Recipients") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td align="left" valign="top" width="10%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    &nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:LinkButton ID="lnkAdd_new" runat="server" Text="Add New" OnClick="lnkAdd_new_Click"></asp:LinkButton>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr id="tr_Email" runat="server" visible="false">
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <table cellpadding="2" cellspacing="0" border="0" width="65%">
                        <tr>
                            <td align="left" valign="top" width="25%">
                                First Name <span style="color: Red;">*</span>
                            </td>
                            <td align="center" valign="top" width="2%">
                                :
                            </td>
                            <td align="left" valign="top" width="38%">
                                <asp:TextBox ID="txtFirst_Name" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqvfNmae" runat="server" ErrorMessage="Please enter First Name"
                                    ControlToValidate="txtFirst_Name" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorSLT_Members"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" width="25%">
                                Last Name <span style="color: Red;">*</span>
                            </td>
                            <td align="center" valign="top" width="2%">
                                :
                            </td>
                            <td align="left" valign="top" width="38%">
                                <asp:TextBox ID="txtLast_Name" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter Last Name"
                                    ControlToValidate="txtLast_Name" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorSLT_Members"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" width="25%">
                                Enter Email Address <span style="color: Red;">*</span>
                            </td>
                            <td align="center" valign="top" width="2%">
                                :
                            </td>
                            <td align="left" valign="top" width="38%">
                                <asp:TextBox ID="txtEmail_Address" runat="server" Width="170px" MaxLength="200"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ErrorMessage="Email Address is not valid"
                                    ControlToValidate="txtEmail_Address" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorSLT_Members"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Email Address"
                                    ControlToValidate="txtEmail_Address" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorSLT_Members"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Button ID="btnSave" runat="server" Text="OK" CausesValidation="true" ValidationGroup="vsErrorSLT_Members"
                                    OnClick="btnSave_Click" />
                                &nbsp;&nbsp;<asp:Button ID="lnkCancel" runat="server" Text="Cancel" OnClick="lnkCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr id="tr_send" runat="server">
                <td align="left" valign="top">
                    &nbsp;
                </td>
                <td align="center" valign="top">
                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:return btnCancel_click();" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:HiddenField ID="hdnEmail" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">
        function SendMail() {
            var Doctype = '<%=Doctype%>'
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnEmail_Address').value = document.getElementById('hdnEmail').value;
            if (Doctype == 'Review') {
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnHdnSend').click();
            }
            else if (Doctype == 'Agenda') {
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnSendMailAgenda').click();
            }
            else if (Doctype == 'Next_Schedule') {
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnSendSchedule').click();
            }
            self.close();
            return false;
        }

        function btnCancel_click() {
            self.close();
            return false;
        }
    </script>
    </form>
</body>
</html>
