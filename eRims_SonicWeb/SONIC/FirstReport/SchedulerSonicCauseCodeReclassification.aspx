<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchedulerSonicCauseCodeReclassification.aspx.cs"
    Inherits="SONIC_FirstReport_SchedulerSonicCauseCodeReclassification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
<body>
    <script type="text/javascript" language="javascript">

        function CheckScheduleDate(obj, args) {
            var retVal = true;
            if (document.getElementById('<%=txtScheduleDate.ClientID %>').value != '') {
                var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>').value);
                var dateToday = new Date();
                if (dateSelected < dateToday) {
                    args.IsValid = false;
                    retVal = false;
                }
            }
            return retVal;
        }

        function ScheduleSavedConfirm() {
            if (confirm('Report Scheduled Successfully! Do you want to continue with schedule?'))
                window.location.href = window.location.href;
            else
                window.close();
        }
    
    </script>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsErrorGroup" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1"></asp:ValidationSummary>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Sonic Cause Code Reclassification Report
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="red" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="dvContent" align="left">
                <table cellpadding="5" cellspacing="0" border="0" align="center" style="width: 90%"
                    id="tblReport" runat="server">
                    <tr valign="top" align="left">
                        <td>
                            Region
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td colspan="4">
                            <asp:ListBox ID="lstRegion" runat="server" SelectionMode="Multiple" Width="250px">
                            </asp:ListBox>
                        </td>
                    </tr>
                   <tr valign="top" align="left">
                        <td>
                            Market
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td colspan="4">
                            <asp:ListBox ID="lstMarket" runat="server" Rows="4" SelectionMode="Multiple" Width="250px">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Location
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td colspan="4">
                            <asp:ListBox ID="lstLocation" runat="server" Rows="4" SelectionMode="Multiple" Width="250px">
                            </asp:ListBox>
                        </td>
                    </tr>     
                                      
                    <tr valign="top" align="left">
                        <td style="width: 23%;">
                            Date of Injury Begin
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 30%;">
                            <asp:TextBox ID="txtInjuryDateFrom" runat="server" Width="140px" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInjuryDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Date of Injury Begin" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvtxtInjuryDateFrom" runat="server" ControlToValidate="txtInjuryDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Date of Injury Begin is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 18%;">
                            Date of Injury End
                        </td>
                        <td align="right" style="width: 2%;">
                            :
                        </td>
                        <td style="width: 30%;">
                            <asp:TextBox ID="txtInjuryDateEnd" runat="server" Width="130px" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInjuryDateEnd.ClientID%>', 'mm/dd/y');"
                                alt="Date of Injury End" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtInjuryDateEnd" runat="server" ControlToValidate="txtInjuryDateEnd"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD To is Not Valid Date." Display="none" SetFocusOnError="true"> 
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLCD" runat="server" ControlToCompare="txtInjuryDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtInjuryDateEnd"
                                ErrorMessage="Date of Injury Begin Date must be Less Than Or Equal To Date of Injury End Date."
                                SetFocusOnError="true"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            First Report Number
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox ID="txtFirstReportNumber" runat="server" onKeyPress="return FormatInteger(event);"
                                MaxLength="20" Width="250px">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVFirstReportNumber" runat="server" ControlToValidate="txtFirstReportNumber"
                                Display="none" SetFocusOnError="true" ErrorMessage="First Report Number must be numeric"
                                ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Incident Investigation Number
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox ID="txtIncidentNumber" runat="server" onKeyPress="return FormatInteger(event);"
                                MaxLength="20" Width="250px">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVIncidentNumber" runat="server" ControlToValidate="txtIncidentNumber"
                                Display="none" SetFocusOnError="true" ErrorMessage="Incident Investigation Number must be numeric"
                                ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Claim Number
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox ID="txtClaimNumber" runat="server" Width="250px">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Scheduled Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="140px" SkinID="txtDate">
                            </asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate"
                                ErrorMessage="Schedule Date must not be Blank." SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="true"
                                Text="">
                            </asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Scheduled End Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="140px" SkinID="txtDate">
                            </asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScheduleEndDate"
                                ErrorMessage="Schedule End Date must not be Blank." SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule End Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="txtScheduleEndDate"
                                ControlToCompare="txtScheduleDate" Display="None" ErrorMessage="Scheduled End Date must be greater than Scheduled Start Date"
                                SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Scheduled End Date must greater than current date."
                                Display="None" SetFocusOnError="true" Text="">
                            </asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Recurring Period<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:DropDownList ID="drpRecurringPeriod" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px">
                                <asp:ListItem Value="0" Text="--Select--">
                                </asp:ListItem>
                                <asp:ListItem Value="1" Text="Weekly">
                                </asp:ListItem>
                                <asp:ListItem Value="2" Text="Monthly">
                                </asp:ListItem>
                                <asp:ListItem Value="3" Text="Quarterly">
                                </asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                InitialValue="0" SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Recipient List<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td align="left" colspan="4">
                            <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <input type="button" class="btn" value=" Close " onclick="javascript:window.close();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
