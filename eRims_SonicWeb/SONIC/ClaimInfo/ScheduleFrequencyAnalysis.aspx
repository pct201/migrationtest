<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleFrequencyAnalysis.aspx.cs" Inherits="SONIC_ClaimInfo_ScheduleFrequencyAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Frequency Analysis Report</title>
</head>
<body>
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
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
                Frequency Analysis Report
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
                <table cellpadding="3" cellspacing="0" border="0" align="left" style="width: 85%">
                    <tr>
                        <td align="left" width="250">
                        </td>
                        <td colspan="2" align="left">
                            &nbsp;
                        </td>
                        <td align="left" width="150">
                            &nbsp; &nbsp; &nbsp;&nbsp; Accident Date From
                        </td>
                        <td align="left" width="150">
                            &nbsp; &nbsp; &nbsp; Accident Date To
                        </td>
                        <td align="left" style="width: 146px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="250">
                        </td>
                        <td colspan="2" align="left">
                            &nbsp;
                        </td>
                        <td align="left" width="150">
                            &nbsp; &nbsp; &nbsp;&nbsp; (MM/DD/YYYY)
                        </td>
                        <td align="left" width="150">
                            &nbsp; &nbsp;&nbsp; (MM/DD/YYYY)
                        </td>
                        <td align="left" style="width: 146px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="250">
                        </td>
                        <td valign="top" align="left" width="150">
                            Dates of Accident<span class="mf">*</span>
                        </td>
                        <td align="right" valign="top" width="4">
                            :
                        </td>
                        <td width="150" align="left">
                            <asp:TextBox runat="server" ID="txtAccidentFromDate" Width="110px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('txtAccidentFromDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                            align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtAccidentFromDate"
                            ErrorMessage="Please enter Accident Date From" SetFocusOnError="true" 
                            Display="none" />
                            <asp:RangeValidator ID="revDateFrom" ControlToValidate="txtAccidentFromDate" MinimumValue="01/01/1753"
                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid."
                            runat="server" SetFocusOnError="true"  Display="none" />
                        </td>
                        <td width="150" align="left">
                            <asp:TextBox runat="server" ID="txtAccidentToDate" Width="110px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('txtAccidentToDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                            align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtAccidentToDate"
                            ErrorMessage="Please enter Accident Date To" SetFocusOnError="true" 
                            Display="none" />
                            <asp:RangeValidator ID="revDateTo" ControlToValidate="txtAccidentToDate" MinimumValue="01/01/1753"
                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date To is not valid."
                            runat="server" SetFocusOnError="true"  Display="none" />  
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ControlToValidate="txtAccidentToDate" ControlToCompare="txtAccidentFromDate" 
                            Operator="GreaterThanEqual" ErrorMessage="Accident Date To must be greater than Accident Date From" Display="None" SetFocusOnError="true"  />
                        </td>
                        <td style="width: 146px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" valign="top">
                            Claim Type<span class="mf">*</span>
                        </td>
                        <td align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip="Select Claim Type"
                                AutoPostBack="false" Width="148px">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>                                
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Claim Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstClaimType" 
                                SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>                    
                    <tr>
                        <td align="left" >
                        </td>
                        <td align="left" >
                            Scheduled Date<span class="mf">*</span>
                        </td>
                        <td align="right" >
                            :
                        </td>
                        <td align="left" >
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="110px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate" ErrorMessage="Schedule Date must not be Blank."
                            SetFocusOnError="true"  Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                            ErrorMessage="Schedule Date is not valid." runat="server" SetFocusOnError="true"  Display="none" />
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                        <td align="left" >
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" >
                            Scheduled End Date<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" >
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="110px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScheduleEndDate" ErrorMessage="Schedule End Date must not be Blank."
                            SetFocusOnError="true"  Display="none" />
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                            ErrorMessage="Schedule End Date is not valid." runat="server" SetFocusOnError="true"  Display="none" />
                            <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="txtScheduleEndDate" ControlToCompare="txtScheduleDate" Display="None"
                            ErrorMessage="Scheduled End Date must be greater than Scheduled Start Date" SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Scheduled End Date must greater than current date."
                                Display="None" SetFocusOnError="false" Text=""></asp:CustomValidator></td>
                        <td align="left" >
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
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" >
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
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" >
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  />
                            &nbsp;
                            <input type="button" class="btn" value="Close" onclick="javascript:window.close();" />
                        </td>
                        <td align="left" >
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
