<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ACI_Approve_Deny.aspx.cs" Inherits="Event_ACI_Approve_Deny" %>

<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">
             function closeForm() {
                 alert('Your comment saved successfully.');
                 window.location = "../Logoff.aspx";
             }
             function closeFormGrid() {
                 alert('Your comment saved successfully.');
                 window.opener.document.getElementById("ctl00_ContentPlaceHolder1_hdnbtnRefresh").click();
             }
    </script>
    
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">ACI Video Request
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="padding-left: 100px;">
                            &nbsp;
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="50%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                            <tr>
                                                <td style="height: 5px" colspan="6">
                                                     <b>Reason for Request Deny</b>&nbsp;<span style="color: Red;">*</span>
                                                    &nbsp;&nbsp; :
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top;">
                                                  &nbsp;
                                                </td>
                                                <td style="vertical-align: top;">&nbsp;</td>
                                                <td colspan="4">
                                                    <uc:ctrlMultiLineTextBox ID="txtReason_Request_Video" runat="server" Width="500" IsRequired="true" RequiredFieldMessage="Please Enter Reason for Request Deny" ValidationGroup="vsErrorGroup" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="50%">
                                    <tr>
                                        <td width="100%" align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                       <asp:Button ID="btnSave" runat="server" ToolTip=" Save " Text=" Save "
                                                            OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            Width="190px" />
                                                    </td>
                                                    <td>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
