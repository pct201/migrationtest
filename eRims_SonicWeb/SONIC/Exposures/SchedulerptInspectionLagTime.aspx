<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchedulerptInspectionLagTime.aspx.cs"
    Inherits="SONIC_Exposures_SchedulerptInspectionLagTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Facility Inspection Report</title>
</head>
<body>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ValidationSummary HeaderText="Verify the following fields:" ID="valSummary"
        runat="server" ShowMessageBox="true" ShowSummary="false" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage" />
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Inspection Distribution Lag Time
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" valign="top">
                            Region
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                           <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Location D/B/A
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstLocationDBA" runat="server" SelectionMode="Multiple" ToolTip="Select Location DBA"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="left" valign="top">
                            Inspector Name
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                             <asp:TextBox ID="txtInspectorName" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Inspection Date From
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                             <asp:TextBox ID="txtInspectionDateFrom" runat="server" SkinID="txtdate" MaxLength="10"
                                Width="190px">
                            </asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInspectionDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvStartDateFrom" runat="server" ControlToValidate="txtInspectionDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Inspection Date - From Is Not Valid" Display="none" ValidationGroup="vsErrorGroup">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Inspection Date To
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInspectionDateTo" runat="server" SkinID="txtdate" MaxLength="10"
                                Width="190px">
                            </asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInspectionDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:CompareValidator ID="cbDate" runat="server" ErrorMessage="Inspection Date - From  Must Be Less Than Inspection Date To."
                                ControlToCompare="txtInspectionDateFrom" Type="Date" ValidationGroup="vsErrorGroup"
                                Operator="GreaterThanEqual" ControlToValidate="txtInspectionDateTo" Display="none">
                            </asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="rvStartDateTo" runat="server" ControlToValidate="txtInspectionDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Inspection Date - To Is Not Valid" Display="none" ValidationGroup="vsErrorGroup">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                    <td align="left" valign="top" width="15%">
                            Inspection Area
                        </td>
                        <td align="center" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:ListBox ID="lstInspectionArea" runat="server" SelectionMode="Multiple" ToolTip="Select Inspection Area"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                        <td align="left" valign="top">
                            Lag Time in Days
                        </td>
                        <td align="center" valign="top">:</td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstLagTimeDays" runat="server" SelectionMode="Multiple" Width="220px" Rows="5">
                                <asp:ListItem Text="<=2" Value="1" />
                                <asp:ListItem Text="3 to 5" Value="2" />
                                <asp:ListItem Text="6 to 10" Value="3" />
                                <asp:ListItem Text="11 to 15" Value="4" />
                                <asp:ListItem Text=">15" Value="5" />
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Scheduled Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" nowrap="nowrap">
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="175px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" alt="" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate"
                                ErrorMessage="Schedule Date must not be Blank." SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Scheduled End Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" nowrap="nowrap">
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="175px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" alt="" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScheduleEndDate"
                                ErrorMessage="Schedule End Date must not be Blank." SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule End Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtScheduleEndDate"
                                ControlToCompare="txtScheduleDate" Display="None" ErrorMessage="Scheduled End Date must be greater than Scheduled Start Date"
                                SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Scheduled End Date must greater than current date."
                                Display="None" SetFocusOnError="false" Text=""></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Recurring Period<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" width="150">
                            <asp:DropDownList ID="drpRecurringPeriod" runat="server" Width="200px" EnableTheming="True"
                                SkinID="dropGen">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Recipient List<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" width="150">
                            <asp:DropDownList ID="drpRecipientList" runat="server" Width="200px" EnableTheming="True"
                                SkinID="dropGen" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" colspan="2">
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
