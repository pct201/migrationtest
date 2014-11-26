<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleRptNonCustomerInquiry.aspx.cs" Inherits="SONIC_CRM_ScheduleRptNonCustomerInquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Non-Customer Inquiry Summary</title>
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
                Non-Customer Inquiry Summary
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
                        <td align="left" valign="top" width="28%">
                            Year
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:DropDownList ID="drpYear" runat="server" SkinID="dropGen" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Location D/B/A
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstDBA" runat="server" Width="280px" SelectionMode="Multiple" Rows="7">                                
                            </asp:ListBox>
                        </td>
                    </tr>                  
                    <tr>
                        <td align="left">
                            Schedule Start Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" nowrap="nowrap">
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="175px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" alt="" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate"
                                ErrorMessage="Schedule Start Date must not be Blank." SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Start Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Schedule Start Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Schedule End Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" nowrap="nowrap">
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="175px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScheduleEndDate"
                                ErrorMessage="Schedule End Date must not be Blank." SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule End Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtScheduleEndDate"
                                ControlToCompare="txtScheduleDate" Display="None" ErrorMessage="Schedule End Date must be greater than Scheduled Start Date"
                                SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Schedule End Date must greater than current date."
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