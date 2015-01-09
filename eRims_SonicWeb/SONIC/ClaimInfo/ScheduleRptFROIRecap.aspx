<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleRptFROIRecap.aspx.cs" Inherits="SONIC_ClaimInfo_ScheduleRptFROIRecap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: FROI Recap Report</title>
    
</head>
<body>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
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
        <div>
            <table width="100%">
                <tr>
                    <td align="left" class="ghc">FROI Recap Report
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="Spacer" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="100%" border="0">
                            <tr>
                                <td align="left" valign="top" width="24%">Region<span class="mf">*</span>
                                </td>
                                <td width="2%" align="center" valign="top">:</td>
                                <td align="left">
                                    <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                        AutoPostBack="True" Width="250px" OnSelectedIndexChanged="lstRegions_SelectedIndexChanged"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" width="24%">Market<span class="mf">*</span>
                                </td>
                                <td width="2%" align="center" valign="top">:</td>
                                <td align="left">
                                    <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market" Width="250px" ></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Sonic Location Code<span class="mf">*</span>
                                </td>
                                <td width="2%" align="center" valign="top">:</td>
                                <td align="left">
                                    <asp:ListBox ID="lstRMLocationNumber" runat="server" SelectionMode="Multiple" ToolTip="Select Sonic Location Code"
                                        AutoPostBack="false" Width="250px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Date of Incident Begin 
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtIncidentBeginDate" runat="server" SkinID="txtDate" Width="170px"></asp:TextBox>
                                    <img alt="Incident Begin Date" onclick="return showCalendar('txtIncidentBeginDate', 'mm/dd/y');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" />
                                    <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtIncidentBeginDate"
                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Incident Begin Date is not valid."
                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                </td>
                                <td align="left">Date of Incident End
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtIncidentEndDate" runat="server" SkinID="txtDate" Width="170px"></asp:TextBox>
                                    <img alt="Incident End Date" onclick="return showCalendar('txtIncidentEndDate', 'mm/dd/y');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" />
                                    <asp:RangeValidator ID="revDate" ControlToValidate="txtIncidentEndDate" MinimumValue="01/01/1753"
                                        MaximumValue="12/31/9999" Type="Date" ErrorMessage="Incident End Date is not valid."
                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">First Report Category 
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left">
                                    <asp:ListBox runat="server" ID="lstCategory" Width="195px" SelectionMode="Multiple">
                                        <asp:ListItem>NS</asp:ListItem>
                                        <asp:ListItem>WC</asp:ListItem>
                                        <asp:ListItem>AL</asp:ListItem>
                                        <asp:ListItem>DPD</asp:ListItem>
                                        <asp:ListItem>PL</asp:ListItem>
                                        <asp:ListItem>Property</asp:ListItem>
                                    </asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Scheduled Date<span class="mf">*</span>
                                </td>
                                <td align="right">:
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
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="left">Scheduled End Date<span class="mf">*</span>
                                </td>
                                <td align="right">:
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
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="left">Recurring Period<span class="mf">*</span>
                                </td>
                                <td align="right">:
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
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="left">Recipient List<span class="mf">*</span>
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                        Width="165px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                        Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                        InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" width="100"></td>
                                <td align="left" valign="top" width="10"></td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;
                                    <input type="button" class="btn" value=" Close " onclick="javascript: window.close();" />
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
