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
    <asp:validationsummary id="vsErrorGroup" runat="server" showsummary="false" showmessagebox="true"
        headertext="Verify the following fields:" borderwidth="1">
    </asp:validationsummary>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Workers Comp Allocation YTD Charge Report
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:label id="lblError" runat="server" text="" visible="false" forecolor="red" font-bold="true">
                </asp:label>
            </td>
        </tr>
        <tr>
            <td class="dvContent" align="left">
                <table cellpadding="5" cellspacing="0" border="0" align="center" style="width: 70%"
                    id="tblReport" runat="server">
                    <tr valign="top" align="left">
                        <td>
                            Location
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:listbox id="lstRegion" runat="server" selectionmode="Multiple" width="250px"></asp:listbox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Location
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:listbox id="lstLocation" runat="server" rows="4" selectionmode="Multiple" width="250px">
                            </asp:listbox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Accident Year
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:listbox id="lstYear" runat="server" rows="4" width="250px" selectionmode="Multiple">
                            </asp:listbox>
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
                            <asp:textbox runat="server" id="txtScheduleDate" width="140px" skinid="txtDate">
                            </asp:textbox>
                            <img onclick="return showCalendar('txtScheduleDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="txtScheduleDate"
                                errormessage="Schedule Date must not be Blank." setfocusonerror="true" display="none" />
                            <asp:rangevalidator id="RangeValidator1" controltovalidate="txtScheduleDate" minimumvalue="01/01/1753"
                                maximumvalue="12/31/9999" type="Date" errormessage="Schedule Date is not valid."
                                runat="server" setfocusonerror="true" display="none" />
                            <asp:customvalidator id="cstValidator" runat="server" errormessage="Scheduled Date must greater than current date."
                                clientvalidationfunction="CheckScheduleDate" display="None" setfocusonerror="true"
                                text="">
                            </asp:customvalidator>
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
                            <asp:textbox runat="server" id="txtScheduleEndDate" width="140px" skinid="txtDate">
                            </asp:textbox>
                            <img onclick="return showCalendar('txtScheduleEndDate', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtScheduleEndDate"
                                errormessage="Schedule End Date must not be Blank." setfocusonerror="true" display="none" />
                            <asp:rangevalidator id="RangeValidator2" controltovalidate="txtScheduleEndDate" minimumvalue="01/01/1753"
                                maximumvalue="12/31/9999" type="Date" errormessage="Schedule End Date is not valid."
                                runat="server" setfocusonerror="true" display="none" />
                            <asp:comparevalidator id="cvDate" runat="server" controltovalidate="txtScheduleEndDate"
                                controltocompare="txtScheduleDate" display="None" errormessage="Scheduled End Date must be greater than Scheduled Start Date"
                                setfocusonerror="true" type="date" operator="GreaterThanEqual" />
                            <asp:customvalidator id="CustomValidator1" runat="server" errormessage="Scheduled End Date must greater than current date."
                                display="None" setfocusonerror="true" text="">
                            </asp:customvalidator>
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
                            <asp:dropdownlist id="drpRecurringPeriod" runat="server" enabletheming="True" skinid="dropGen"
                                width="150px">
                                <asp:listitem value="0" text="--Select--">
                                </asp:listitem>
                                <asp:listitem value="1" text="Weekly">
                                </asp:listitem>
                                <asp:listitem value="2" text="Monthly">
                                </asp:listitem>
                                <asp:listitem value="3" text="Quarterly">
                                </asp:listitem>
                            </asp:dropdownlist>
                            <asp:requiredfieldvalidator id="rfvdrpRecurringPeriod" runat="server" errormessage="Please Select Recurring Period."
                                font-bold="true" display="none" text="*" controltovalidate="drpRecurringPeriod"
                                initialvalue="0" setfocusonerror="true">
                            </asp:requiredfieldvalidator>
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
                            <asp:dropdownlist id="drpRecipientList" runat="server" enabletheming="True" skinid="dropGen"
                                width="150px" />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="Please Select Recipient List"
                                font-bold="true" display="none" text="*" controltovalidate="drpRecipientList"
                                initialvalue="0" setfocusonerror="true">
                            </asp:requiredfieldvalidator>
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
                        <td align="left" colspan="8">
                            <asp:button id="btnSave" runat="server" text=" Save " onclick="btnSave_Click" />
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
