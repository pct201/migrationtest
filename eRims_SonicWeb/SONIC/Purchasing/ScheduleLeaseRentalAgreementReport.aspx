<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleLeaseRentalAgreementReport.aspx.cs" Inherits="SONIC_Purchasing_ScheduleLeaseRentalAgreementReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Lease Rental Agreement Detail Report</title>
    <style type="text/css">
        .style1
        {
            width: 442px;
        }
    </style>
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
        CssClass="errormessage" ValidationGroup="vsErrorGroup"></asp:ValidationSummary>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Lease Rental Agreement Detail Report
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
                <table cellpadding="3" cellspacing="0" border="0" align="center" style="width: 60%">
                    <tr>
                        <td align="left">
                        </td>
                        <td width="28%" align="left" valign="top">
                            Region
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" class="style1">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Region"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstRegions" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                    <td align="left">
                    </td>
                    <td width="28%" align="left" valign="top">
                        Market
                    </td>
                    <td width="2%" align="center" valign="top">
                        :
                    </td>
                    <td align="left" class="style1">
                        <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                            AutoPostBack="false" Width="166px"></asp:ListBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Market"
                            Font-Bold="true" Display="none" Text="*" ControlToValidate="lstMarket" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" valign="top">
                            Location
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" class="style1">
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" ToolTip="Select Location"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlstLocation" runat="server" ErrorMessage="Please Select Location"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstLocation" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" valign="top">
                            Equipment Type
                        </td>
                        <td align="center" valign="top">
                            :</td>
                        <td align="left" class="style1">
                            <asp:ListBox ID="lstEquipmentType" runat="server" SelectionMode="Multiple" ToolTip="Select Equipment Type" AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlstEquipmentType" runat="server" ErrorMessage="Please Select Equipment Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstEquipmentType"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" valign="top">
                            Lease Rental Type
                        </td>
                        <td align="center" valign="top">
                            :</td>
                        <td align="left" class="style1">
                            <asp:ListBox ID="lstLRType" runat="server" SelectionMode="Multiple" ToolTip="Select Lease/Rental Type" AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlstLRType" runat="server" ErrorMessage="Please Select Lease/Rental Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstLRType"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            Start Date
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left" class="style1">
                            From&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtStartDateFromDate" Width="75px"
                                SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDateFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                            <%--<asp:RequiredFieldValidator ID="rfvtxtStartDateFromDate" runat="server" ControlToValidate="txtStartDateFromDate"
                                ErrorMessage="Please enter From Start Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true" />--%>
                            <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtStartDateFromDate"
                                MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="From Start Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            &nbsp;&nbsp;To&nbsp;&nbsp;
                            <asp:TextBox runat="server" ID="txtStartDateToDate" Width="75px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDateToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                           <%-- <asp:RequiredFieldValidator ID="rfvtxtStartDateToDate" runat="server" ControlToValidate="txtStartDateToDate"
                                ErrorMessage="Please enter To Start Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true"/>--%>
                            <asp:RangeValidator ID="revDate" ControlToValidate="txtStartDateToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="To Start Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvStartDate" runat="server" ControlToValidate="txtStartDateToDate"
                                ControlToCompare="txtStartDateFromDate" Type="Date" ErrorMessage="To Start Date must be greater than or equal to From Start Date"
                                Operator="GreaterThanEqual" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none"></asp:CompareValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            End Date
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left" class="style1">
                            From&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtEndDateFromDate" Width="75px"
                                SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDateFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                            <%--<asp:RequiredFieldValidator ID="rfvtxtEndDateFromDate" runat="server" ControlToValidate="txtEndDateFromDate"
                                ErrorMessage="Please enter From End Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true"/>--%>
                            <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txtEndDateFromDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="From End Date is not valid." runat="server"
                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            &nbsp;&nbsp;To&nbsp;&nbsp;
                            <asp:TextBox runat="server" ID="txtEndDateToDate" Width="75px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDateToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                           <%-- <asp:RequiredFieldValidator ID="rfvtxtEndDateToDate" runat="server" ControlToValidate="txtEndDateToDate"
                                ErrorMessage="Please enter To End Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true"/>--%>
                            <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtEndDateToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="To End Date is not valid." runat="server"
                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvEndDate" runat="server" ControlToValidate="txtEndDateToDate"
                                ControlToCompare="txtEndDateFromDate" Type="Date" ErrorMessage="To End Date must be greater than or equal to From End Date"
                                Operator="GreaterThanEqual" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none"></asp:CompareValidator>
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
                        <td align="left" class="style1">
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtScheduleDate"
                                ErrorMessage="Schedule Date must not be Blank." SetFocusOnError="true" Display="none"  ValidationGroup="vsErrorGroup"/>
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none"  ValidationGroup="vsErrorGroup"/>
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
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
                        <td align="left" class="style1">
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScheduleEndDate"
                                ErrorMessage="Schedule End Date must not be Blank." SetFocusOnError="true" Display="none"  ValidationGroup="vsErrorGroup"/>
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule End Date is not valid."
                                runat="server" SetFocusOnError="true" Display="none"  ValidationGroup="vsErrorGroup"/>
                            <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="txtScheduleEndDate"
                                ControlToCompare="txtScheduleDate" Display="None" ErrorMessage="Scheduled End Date must be greater than Scheduled Start Date"
                                SetFocusOnError="true" Type="date" Operator="GreaterThanEqual" ValidationGroup="vsErrorGroup" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Scheduled End Date must greater than current date."
                                Display="None" SetFocusOnError="true" Text="" ValidationGroup="vsErrorGroup"></asp:CustomValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" width="180px">
                            Recurring Period<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" class="style1">
                            <asp:DropDownList ID="drpRecurringPeriod" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                InitialValue="0" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" width="180px">
                            Recipient List<span class="mf">*</span>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" class="style1">
                            <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left" width="180px">
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" class="style1">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup"/>
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
