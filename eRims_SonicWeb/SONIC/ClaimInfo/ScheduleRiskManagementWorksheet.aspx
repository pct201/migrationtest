<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleRiskManagementWorksheet.aspx.cs"
    Inherits="SONIC_ClaimInfo_ScheduleRiskManagementWorksheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Risk Management Worksheet Report</title>
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
    <asp:ValidationSummary HeaderText="Verify the following fields:" ID="valSummary"
        runat="server" ShowMessageBox="true" ShowSummary="false" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage" />
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Risk Management Worksheet Report
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
            <td align="left">
                <table border="0" cellpadding="3" cellspacing="0" style="width: 95%">
                    <tr>
                        <td align="left" valign="top">
                            Region
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="220px"></asp:ListBox>
                        </td>
                        <td align="center" valign="top">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            DBA
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstDBAs" runat="server" SelectionMode="Multiple" ToolTip="Select DBA"
                                AutoPostBack="false" Width="220px"></asp:ListBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="left" valign="top">
                            Market
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                                AutoPostBack="false" Width="220px"></asp:ListBox>
                        </td>
                        <td align="center" colspan="4" valign="top">
                            &nbsp;
                        </td>                        
                    </tr>
                    <tr>
                        <td valign="top" align="left" width="20%">
                            Dates of Incident From
                        </td>
                        <td align="left" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" width="30%">
                            <asp:TextBox runat="server" ID="txtLossFromDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('txtLossFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <%-- <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtLossFromDate"
                                ErrorMessage="Please enter Loss Date From" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />--%>
                            <asp:RangeValidator ID="revDateFrom" ControlToValidate="txtLossFromDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date From is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                        <td align="center" valign="top" width="2%">
                            &nbsp;
                        </td>
                        <td valign="top" align="left" width="14%">
                            To
                        </td>
                        <td align="left" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" width="30%">
                            <asp:TextBox runat="server" ID="txtLossToDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('txtLossToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <%--   <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtLossToDate"
                                ErrorMessage="Please enter Loss Date To" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />--%>
                            <asp:RangeValidator ID="revDateTo" ControlToValidate="txtLossToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date To is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvDate" runat="server" Type="Date" ControlToValidate="txtLossToDate"
                                ControlToCompare="txtLossFromDate" Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date"
                                Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Part of Body
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstPartofBody" runat="server" SelectionMode="Multiple" ToolTip="Select Part of Body"
                                AutoPostBack="false" Width="220px"></asp:ListBox>
                        </td>
                        <td align="center" valign="top">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            Claim Status
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstClaimStatus" runat="server" SelectionMode="Multiple" ToolTip="Select Claim Status"
                                AutoPostBack="false" Width="220px"></asp:ListBox>
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
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="" onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
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
                        <td align="left">
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
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="" onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
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
                        <td align="left">
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
                                Width="165px">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
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
                                Width="165px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" colspan="4">
                            <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <input type="button" class="btn" value=" Close " onclick="javascript:window.close();" />
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
