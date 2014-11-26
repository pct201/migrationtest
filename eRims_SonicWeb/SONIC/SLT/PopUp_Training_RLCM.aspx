<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp_Training_RLCM.aspx.cs"
    Inherits="SONIC_SLT_PopUp_Training_RLCM" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quarterly Training Conducted by RLCM</title>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        function BindTraining_RLCM_Grid() {
            window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnhdnBindRLCM_Training").click();
            self.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="vsErrorSLT_RLCM"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <div>
        <table border="0" cellpadding="3" cellspacing="1" width="100%" id="tblRLCM_TrainingEdit"
            runat="server">
            <tr>
                <td align="left" colspan="6">
                    <div class="bandHeaderRow">
                        Quarterly Training Conducted by RLCM</div>
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" valign="top">
                    Focus
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:TextBox ID="txtFocus" runat="server" Width="170px" Enabled="false" />
                </td>
                <td align="left" width="18%" valign="top">
                    Topic
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:TextBox ID="txtTopic" runat="server" Width="170px" MaxLength="100" />
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" valign="top">
                    Date Scheduled
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:TextBox ID="txtDate_Scheduled" SkinID="txtDate" Width="150px" runat="server"></asp:TextBox>
                    <img alt="Date Scheduled" onclick="return showCalendar('<%= txtDate_Scheduled.ClientID %>', 'mm/dd/y');"
                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                        align="middle" />
                    <br />
                    <asp:RegularExpressionValidator ID="revPolicy_Date" runat="server" ValidationGroup="vsErrorSLT_RLCM"
                        Display="none" ErrorMessage="Date Scheduled is not valid" SetFocusOnError="true"
                        ControlToValidate="txtDate_Scheduled" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                    </asp:RegularExpressionValidator>
                </td>
                <td align="left" width="18%" valign="top">
                    Date Completed
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:TextBox ID="txtDate_Completed" SkinID="txtDate" Width="150px" runat="server"></asp:TextBox>
                    <img alt="Date Completed" onclick="return showCalendar('<%= txtDate_Completed.ClientID %>', 'mm/dd/y');"
                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                        align="middle" />
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorSLT_RLCM"
                        Display="none" ErrorMessage="Date Completed is not valid" SetFocusOnError="true"
                        ControlToValidate="txtDate_Completed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                    </asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Date Completed Should be greater than Date Scheduled"
                        ControlToValidate="txtDate_Completed" ControlToCompare="txtDate_Scheduled" Type="Date"
                        runat="server" SetFocusOnError="true" Display="None" ValidationGroup="vsErrorSLT_RLCM"
                        Operator="GreaterThanEqual" />
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" valign="top">
                    Reason Not Completed
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" valign="top" colspan="4">
                    <uc:ctrlMultiLineTextBox ID="txtReason_Not_Completed" runat="server" MaxLength="150"
                        ControlType="TextBox" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_OnClick" CausesValidation="true"
                        ValidationGroup="vsErrorSLT_RLCM" />&nbsp;
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_OnClick" />
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="3" cellspacing="1" width="100%" id="tblRLCM_TrainingView"
            runat="server" visible="false">
            <tr>
                <td align="left" colspan="6">
                    <div class="bandHeaderRow">
                        Quarterly Training Conducted by RLCM</div>
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" valign="top">
                    Focus
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:Label ID="lblFocus" runat="server" />
                </td>
                <td align="left" width="18%" valign="top">
                    Topic
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:Label ID="lblTopic" runat="server" Width="200px" CssClass="TextClip" />
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" valign="top">
                    Date Scheduled
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:Label ID="lblDate_Scheduled" runat="server"></asp:Label>
                </td>
                <td align="left" width="18%" valign="top">
                    Date Completed
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" width="28%" valign="top">
                    <asp:Label ID="lblDate_Completed" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" width="25%" valign="top">
                    Reason Not Completed
                </td>
                <td align="center" width="4%" valign="top">
                    :
                </td>
                <td align="left" valign="top" colspan="4">
                    <uc:ctrlMultiLineTextBox ID="lblReason_Not_Completed" runat="server" ControlType="Label" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button ID="btnCancelView" Text="Cancel" runat="server" OnClick="btnCancelView_OnClick" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
