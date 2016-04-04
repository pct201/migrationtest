<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleRptVOCEmissions.aspx.cs" Inherits="SONIC_Exposures_ScheduleRptVOCEmissions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
</head>
<body>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
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


        function CheckEndDate(obj, args) {
            var retVal = true;
            if (document.getElementById('<%=txtEndDate.ClientID %>').value != '') {

                var dateSelected = new Date(document.getElementById('<%=txtEndDate.ClientID %>').value);
                var dateToday = new Date();
                var firstDay = new Date(dateToday.getFullYear(), dateToday.getMonth(), 1);
                
                if (dateSelected > firstDay) {
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
                <td align="left" class="ghc">VOC Report
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;"></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="5" cellspacing="1">
                        <tr>
                            <td align="left" valign="top" width="40%">Location &nbsp;<span style="color: Red; font-weight: bold;">*</span>
                            </td>
                            <td align="center" valign="top" width="5%">:
                            </td>
                            <td align="left" width="60%">
                                <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                                <asp:RequiredFieldValidator ControlToValidate="lstLocation" ID="rfvLocation" Display="None"
                                    ErrorMessage="Please select Location." InitialValue="" runat="server">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Start Date<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtStartDate" Width="180px" SkinID="txtDate"></asp:TextBox>
                                <img onclick="return showCalendar('txtStartDate', 'mm/dd/y');" alt="" onmouseover="javascript:this.style.cursor='hand';"
                                    src="../../Images/iconPicDate.gif" align="middle" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStartDate"
                                    ErrorMessage="Start Date must not be Blank." SetFocusOnError="true" Display="none" />
                                <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtStartDate" MinimumValue="01/01/1753"
                                    MaximumValue="12/31/9999" Type="Date" ErrorMessage="Start Date is not valid."
                                    runat="server" SetFocusOnError="true" Display="none" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">End Date<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtEndDate" Width="180px" SkinID="txtDate"></asp:TextBox>
                                <img onclick="return showCalendar('txtEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                    src="../../Images/iconPicDate.gif" align="middle" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate"
                                    ErrorMessage="End Date must not be Blank." SetFocusOnError="true" Display="none" />
                                <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txtEndDate" MinimumValue="01/01/1753"
                                    MaximumValue="12/31/9999" Type="Date" ErrorMessage="End Date is not valid."
                                    runat="server" SetFocusOnError="true" Display="none" />
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtEndDate"
                                    ControlToCompare="txtStartDate" Display="None" ErrorMessage="End Date must be greater than Start Date."
                                    SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" />
                                 <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="End Date must be less than first of current month."
                                    ClientValidationFunction="CheckEndDate" Display="None" SetFocusOnError="false"
                                    Text=""></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Scheduled Start Date<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtScheduleDate" Width="180px" SkinID="txtDate"></asp:TextBox>
                                <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" alt="" onmouseover="javascript:this.style.cursor='hand';"
                                    src="../../Images/iconPicDate.gif" align="middle" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate"
                                    ErrorMessage="Schedule Start Date must not be Blank." SetFocusOnError="true" Display="none" />
                                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                    MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Start Date is not valid."
                                    runat="server" SetFocusOnError="true" Display="none" />
                                <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Start Date must greater than current date."
                                    ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                    Text=""></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Scheduled End Date<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="180px" SkinID="txtDate"></asp:TextBox>
                                <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                    src="../../Images/iconPicDate.gif" align="middle" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScheduleEndDate"
                                    ErrorMessage="Schedule End Date must not be Blank." SetFocusOnError="true" Display="none" />
                                <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                    MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule End Date is not valid."
                                    runat="server" SetFocusOnError="true" Display="none" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtScheduleEndDate"
                                    ControlToCompare="txtScheduleDate" Display="None" ErrorMessage="Scheduled End Date must be greater than Scheduled Start Date."
                                    SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Scheduled End Date must greater than current date."
                                    Display="None" SetFocusOnError="false" Text=""></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="150">Recurring Period<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left" width="150">
                                <asp:DropDownList ID="drpRecurringPeriod" runat="server" Width="200px" EnableTheming="True"
                                    SkinID="dropGen">
                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Monthly" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                    Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                    InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="150">Recipient List<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left" width="150">
                                <asp:DropDownList ID="drpRecipientList" runat="server" Width="200px" EnableTheming="True"
                                    SkinID="dropGen" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List."
                                    Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                    InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="150">Output Type<span class="mf">*</span>
                            </td>
                            <td align="right">:
                            </td>
                            <td align="left" width="150">
                                <asp:RadioButtonList ID="rdbOutputType" runat="server">
                                    <asp:ListItem Text="Excel" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="PDF" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;"></td>
                        </tr>
                        <tr>
                            <td align="left" width="150"></td>
                            <td align="right"></td>
                            <td align="left" colspan="2">
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
