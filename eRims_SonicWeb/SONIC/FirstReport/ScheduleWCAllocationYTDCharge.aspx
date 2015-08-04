<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleWCAllocationYTDCharge.aspx.cs"
    Inherits="SONIC_RealEstate_ScheduleWCAllocationYTDCharge" Title="eRIMS Sonic :: Workers Comp Allocation YTD Charge Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <td align="left" class="ghc">Workers Comp Allocation YTD Charge Report
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;"></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="red" Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="dvContent" align="left">
                    <table cellpadding="5" cellspacing="0" border="0" align="center" style="width: 70%"
                        id="tblReport" runat="server">
                        <tr valign="top" align="left">
                            <td>Region
                            </td>
                            <td align="right">:
                            </td>
                            <td>
                                <asp:ListBox ID="lstRegion" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>Location
                            </td>
                            <td align="right">:
                            </td>
                            <td>
                                <asp:ListBox ID="lstLocation" runat="server" Rows="4" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>Market
                            </td>
                            <td align="right">:
                            </td>
                            <td>
                                <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>Accident Year
                            </td>
                            <td align="right">:
                            </td>
                            <td>
                                <asp:ListBox ID="lstYear" runat="server" Rows="4" Width="250px" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Scheduled Date<span class="mf">*</span>
                            </td>
                            <td align="right">:
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
                            <td align="left">Scheduled End Date<span class="mf">*</span>
                            </td>
                            <td align="right">:
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
                            <td align="left">Recurring Period<span class="mf">*</span>
                            </td>
                            <td align="right">:
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
                            <td align="left">Recipient List<span class="mf">*</span>
                            </td>
                            <td align="right">:
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
                            <td align="right" style="width: 11%">Run report by
                            </td>
                            <td align="center" style="width: 4%">:</td>
                            <td align="left" style="width: 35%">
                                <asp:RadioButtonList ID="rdoRunBy" runat="server">
                                    <asp:ListItem Text="Region" Value="Region" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Market" Value="Market"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td align="left" colspan="8">
                                <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click" />
                                &nbsp;&nbsp;&nbsp;
                            <input type="button" class="btn" value=" Close " onclick="javascript: window.close();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
