<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleWCAllocationLocationReport.aspx.cs"
    Inherits="SONIC_FirstReport_ScheduleWCAllocationLocationReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>
</head>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

<body>

    <script type="text/javascript" language="javascript">
           
    function CheckScheduleDate(obj,args)
    {
        var retVal = true;
        if(document.getElementById('<%=txtScheduleDate.ClientID %>').value != '')
        {
            var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>').value);
            var dateToday =new Date();
            if(dateSelected < dateToday)
            {
                args.IsValid = false;
                retVal= false;
            }
        }
        return retVal;
    }
    
    function ScheduleSavedConfirm()
    {
        if(confirm('Report Scheduled Successfully! Do you want to continue with schedule?'))
            window.location.href = window.location.href;
        else
            window.close();
    }
    
    </script>

    <form id="form1" runat="server">
        <asp:ValidationSummary ID="vsErrorGroup" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            CssClass="errormessage"></asp:ValidationSummary>
        <table width="100%">
            <tr>
                <td align="left" class="ghc">
                    WC Allocation Location Report
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
                <td class="dvContent" align="left">
                    <table cellpadding="3" cellspacing="0" border="0" align="left" style="width: 70%">
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left" style="width: 18%">
                                Year<span style="color: Red;">*</span></td>
                            <td align="center" style="width: 4%">
                                :</td>
                            <td align="left">
                                <asp:DropDownList runat="Server" ID="ddlYear" SkinID="dropGen" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="ddlYear" Display="None"
                                    runat="server" InitialValue="0" Text="*" SetFocusOnError="true" ErrorMessage="Please select Year."></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left" style="width: 18%">
                                Month<span style="color: Red;">*</span></td>
                            <td align="center" style="width: 4%">
                                :</td>
                            <td align="left">
                                <asp:DropDownList runat="Server" ID="ddlMonth" SkinID="dropGen" Width="150px">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                    <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                    <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                    <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                    <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMonth" ControlToValidate="ddlMonth" Display="None"
                                    runat="server" InitialValue="0" Text="*" SetFocusOnError="true" ErrorMessage="Please select Month."></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left" valign="top">
                                Location<span class="mf">*</span>
                            </td>
                            <td width="2%" align="center" valign="top">
                                :</td>
                            <td align="left">
                                <asp:DropDownList runat="Server" ID="ddlLocation" SkinID="dropGen">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="revLocation" ControlToValidate="ddlLocation" Display="None"
                                    runat="server" InitialValue="0" Text="*" SetFocusOnError="true" ErrorMessage="Please select Location."></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left">
                                Scheduled Date<span class="mf">*</span>
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtScheduleDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                                <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                    src="../../Images/iconPicDate.gif" align="middle" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate"
                                    ErrorMessage="Schedule Date must not be Blank." SetFocusOnError="true" Display="none" />
                                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                    MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Date is not valid."
                                    runat="server" SetFocusOnError="true" Display="none" />
                                <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                    ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="true"
                                    Text=""></asp:CustomValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left">
                                Scheduled End Date<span class="mf">*</span>
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="140px" SkinID="txtDate"></asp:TextBox>
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
                                    Display="None" SetFocusOnError="true" Text=""></asp:CustomValidator></td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left" width="150">
                                Recurring Period<span class="mf">*</span>
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td align="left" width="150">
                                <asp:DropDownList ID="drpRecurringPeriod" runat="server" EnableTheming="True" SkinID="dropGen"
                                    Width="150px">
                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                    Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                    InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left" width="150">
                                Recipient List<span class="mf">*</span>
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td align="left" width="150">
                                <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                    Width="150px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                    Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                    InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left" width="150">
                            </td>
                            <td align="right">
                            </td>
                            <td align="left" width="150">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                &nbsp;
                                <input type="button" class="btn" value="Close" onclick="javascript:window.close();" />
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" class="dvContent">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
