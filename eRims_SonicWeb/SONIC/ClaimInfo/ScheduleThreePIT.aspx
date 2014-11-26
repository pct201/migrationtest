<%@ Page Language="C#" Title="eRIMS :: Three Points-In-Time Summary Report" MasterPageFile="~/Tatva_ScheduleMaster.master"
    AutoEventWireup="true" CodeFile="ScheduleThreePIT.aspx.cs" Inherits="ClaimDetailReport_ScheduleThreePIT" %>

<%@ Register Src="~/Controls/MonthSelector/MonthSelectControl.ascx" TagName="MonthSelectControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../Controls/MonthSelector/MonthSelector.js"></script>

    <script language="javascript" type="text/javascript">
        
        var ErrorMsg = '';
        
        /*******************************************************************************************
            this function Check that All filed limit ,loss from date and To date is enter or not.
            All three must be filled or All blank.            
        *********************************************************************************************/
        function CheckRow(asOf,fromdate,todate,rownum)
        {      
            // Check if asOf , loss from date and loss to date is blank then return true
            if((trim(asOf) == "") && (trim(fromdate) == "") && (trim(todate) == ""))                
            {
                return true;
            } 
            
            // Check if one of the three value Loss asOf , loss from date and loss to date enter then
            // set Error message and return false
            if((trim(asOf) == "") || (trim(fromdate) == "") || (trim(todate) == ""))
            {   
                if ( ErrorMsg != '') 
                    ErrorMsg = ErrorMsg + '- ';
                ErrorMsg = ErrorMsg + 'Please Fill All values for ' + rownum  + ' Date range \n'
                return false;
            }
            return true;
            
        }
        
        function CompareDate(firstDt,secondDt)    
        {
            var dt = firstDt.split("/");
            var dt1 = secondDt.split("/");
            
            return (dt[2] <= dt1[2] ? ( dt[1] <= (dt1[1] + 1) ? ( (dt[0] <= dt1[0]) ? true : false ) :false) : false);
            
        }
               
        function CheckAllRow(obj,args)
        {
            var retVal,i;
            ErrorMsg = '';                                                           
            Page_Validators[Page_Validators.length-1].errormessage = '';
            isFocusSet = false;
            retVal = true;

            var asOf1 = document.getElementById('<%=txtasOf1.ClientID%>' + '_txtMonthYear');
            var fromdate1 = document.getElementById('<%=txtLossFromDate1.ClientID %>');
            var todate1 = document.getElementById('<%=txtLossToDate1.ClientID %>');
            
            CheckRow(asOf1.value,fromdate1.value,todate1.value,'First');
            
            var asOf2 = document.getElementById('<%=txtasOf2.ClientID%>' + '_txtMonthYear');
            var fromdate2 = document.getElementById('<%=txtLossFromDate2.ClientID %>');
            var todate2 = document.getElementById('<%=txtLossToDate2.ClientID %>');
            
            CheckRow(asOf2.value,fromdate2.value,todate2.value,'Second');
            
            var asOf3 = document.getElementById('<%=txtasOf3.ClientID%>' + '_txtMonthYear');
            var fromdate3 = document.getElementById('<%=txtLossFromDate3.ClientID %>');
            var todate3 = document.getElementById('<%=txtLossToDate3.ClientID %>');
            
            CheckRow(asOf3.value,fromdate3.value,todate3.value,'third');
            
            if (ErrorMsg != '')
            {
                args.IsValid = false;
                Page_Validators[Page_Validators.length-1].isvalid = false;
                Page_Validators[Page_Validators.length-1].errormessage = ErrorMsg;
                retVal = false;
            }           
                        
            var dtFrom1 = new Date(fromdate1.value)
            var Tdto1 = new Date(todate1.value);

            var dtFrom2 = new Date(fromdate2.value);
            var Tdto2 = new Date(todate2.value);

            var dtFrom3 = new Date(fromdate3.value);
            var Tdto3 = new Date(todate3.value);
            /*
             * 
             *  For Compare First row with 2 & 3 row
             *  
             */
            if (fromdate2.value != '' && todate2.value != '')
            {
                if ((dtFrom2 >= dtFrom1 && dtFrom2 <= Tdto1 ) || (Tdto2 >= dtFrom1 && Tdto2 <= Tdto1 ) ||
                    (dtFrom1 >= dtFrom2 && dtFrom1 <= Tdto2 ) || (Tdto1 >= dtFrom2 && Tdto1 <= Tdto2 )  )
                {
                    if (Page_Validators[Page_Validators.length-1].errormessage != '') 
                        Page_Validators[Page_Validators.length-1].errormessage += '- '
                        
                    Page_Validators[Page_Validators.length-1].errormessage +=  'The date ranges for a second limit may not overlap with the date ranges for first limit, please reenter.\n';                    
                    args.IsValid = false;
                    retVal= false;
                }
            }
            
            if (fromdate3.value != '' && todate3.value != '')
            {
                if ((dtFrom3 >= dtFrom1 && dtFrom3 <= Tdto1 ) || (Tdto3 >= dtFrom1 && Tdto3 <= Tdto1 ) || 
                    (dtFrom1 >= dtFrom3 && dtFrom1 <= Tdto3 ) || (Tdto1 >= dtFrom3 && Tdto1 <= Tdto3 ) )
                {
                    if (Page_Validators[Page_Validators.length-1].errormessage != '') 
                        Page_Validators[Page_Validators.length-1].errormessage += '- '                
                    
                    Page_Validators[Page_Validators.length-1].errormessage +=  'The date ranges for a third limit may not overlap with the date ranges for first limit, please reenter.\n';                    
                    args.IsValid = false;
                    retVal= false;                    
                }            
            }
                            
            /*
             *   For Compare Second row with 3 row
             */ 
             
            if (fromdate3.value != '' && todate3.value != '')
            {
                if ((dtFrom3 >= dtFrom2 && dtFrom3 <= Tdto2 ) || (Tdto3 >= dtFrom2 && Tdto3 <= Tdto2 ) || 
                    (dtFrom2 >= dtFrom3 && dtFrom2 <= Tdto3 ) || (Tdto2 >= dtFrom3 && Tdto2 <= Tdto3 ) )
                {
                    if (Page_Validators[Page_Validators.length-1].errormessage != '') 
                        Page_Validators[Page_Validators.length-1].errormessage += '- '                
                    
                    Page_Validators[Page_Validators.length-1].errormessage +=  'The date ranges for a third limit may not overlap with the date ranges for second limit, please reenter.\n';
                    args.IsValid = false;
                    retVal= false;                    
                }            
            }
            return retVal;
        }
        
        function LTrim( value ) 
        {
            var re = /\s*((\S+\s*)*)/;
            return value.replace(re, "$1");
        }

        // Removes ending whitespaces
        function RTrim( value ) 
        {
            var re = /((\s*\S+)*)\s*/;
            return value.replace(re, "$1");
        }

        // Removes leading and ending whitespaces
        function trim( value ) 
        {
            return LTrim(RTrim(value));
        }        
        

        function CheckScheduleDate(obj,args)
        {
            var retVal = true;
            ErrorMsg = '';                                                           
                
            if(document.getElementById('<%=txtScheduleDate.ClientID %>').value != '')
            {
                var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>' ).value);
                var dateEnd = new Date(document.getElementById('<%=txtScheduleEndDate.ClientID %>' ).value);
                var dateToday =new Date();
                if(dateSelected < dateToday)
                {
                    args.IsValid = false;
                    retVal= false;
                }
            }
            return retVal;
        }
        
        function CheckScheduleEndDate(obj,args)
        {
            var retVal = true;
            ErrorMsg = '';                                                           
                
            if(document.getElementById('<%=txtScheduleDate.ClientID %>').value != '' && document.getElementById('<%=txtScheduleEndDate.ClientID %>').value != '')
            {
                var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>' ).value);
                var dateEnd = new Date(document.getElementById('<%=txtScheduleEndDate.ClientID %>' ).value);
                if(dateEnd < dateSelected)
                {
                    args.IsValid = false;
                    retVal= false;
                }
            }
            return retVal;
        }
    </script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Three Points-In-Time Summary Report
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
                <table width="80%" align="center" cellpadding="5" cellspacing="0">
                    <tr align="center">
                        <td width="100">
                            &nbsp;
                        </td>
                        <td width="4">
                            &nbsp;
                        </td>
                        <td valign="middle" width="120" align="left">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; As Of
                        </td>
                        <td width="150" align="left">
                            &nbsp; &nbsp; &nbsp; &nbsp;Loss Date From
                        </td>
                        <td width="150" align="left">
                            &nbsp; &nbsp; &nbsp; &nbsp; Loss Date To
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left" width="120">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(MM/YYYY)</td>
                        <td align="left">
                            &nbsp; &nbsp; &nbsp;&nbsp; (MM/DD/YYYY)
                        </td>
                        <td align="left">
                            &nbsp; &nbsp; &nbsp;&nbsp; (MM/DD/YYYY)
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            Dates of Loss<span class="mf">*</span>
                        </td>
                        <td align="right" valign="top">
                            :
                        </td>
                        <td align="left" width="120">
                            <uc1:MonthSelectControl ID="txtasOf1" runat="server" EmptyErrorMessage="As Of Date must not be Blank for first Date Range" />
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossFromDate1" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate1', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateFrom1" runat="server" ControlToValidate="txtLossFromDate1"
                                ErrorMessage="Loss From Date must not be Blank for first Date Range" SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="revDateFrom1" ControlToValidate="txtLossFromDate1" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date From for first date range is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossToDate1" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate1', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLossToDate1"
                                ErrorMessage="Loss To Date must not be Blank for first Date Range" SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtLossToDate1" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date To for first date range is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="compValidator1" runat="server" ControlToValidate="txtLossToDate1"
                                ControlToCompare="txtLossFromDate1" Type="Date" Operator="greaterThanEqual" SetFocusOnError="true"
                                ErrorMessage="Loss To Date must be greater than or equal to Loss From Date" Display="None" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td align="left" width="120">
                            <uc1:MonthSelectControl ID="txtasOf2" runat="server" EmptyErrorMessage="As Of Date must not be Blank for second Date Range" />
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossFromDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLossFromDate2"
                                ErrorMessage="Loss From Date must not be Blank for second Date Range" SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtLossFromDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date From for second date range is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossToDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLossToDate2"
                                ErrorMessage="Loss To Date must not be Blank for second Date Ranges" SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtLossToDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date To for second date range is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLossToDate2"
                                ControlToCompare="txtLossFromDate2" Type="Date" Operator="greaterThanEqual" SetFocusOnError="true"
                                ErrorMessage="Loss To Date must be greater than or equal to Loss From Date" Display="None" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td align="left" width="120">
                            <uc1:MonthSelectControl ID="txtasOf3" runat="server" EmptyErrorMessage="As Of Date must not be Blank for third Date Range" />
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossFromDate3" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate3', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLossFromDate3"
                                ErrorMessage="Loss From Date must not be Blank for third Date Range" SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txtLossFromDate3" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date From for third date range is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossToDate3" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate3', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLossToDate3"
                                ErrorMessage="Loss To Date must not be Blank for third Date Range" SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtLossToDate3" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date To for third date range is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtLossToDate3"
                                ControlToCompare="txtLossFromDate3" Type="Date" Operator="greaterThanEqual" SetFocusOnError="true"
                                ErrorMessage="Loss To Date must be greater than or equal to Loss From Date" Display="None" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            Claim Type<span class="mf">*</span>
                        </td>
                        <td align="right" valign="top">
                            :
                        </td>
                        <td colspan="3" valign="top" align="left">
                            <asp:ListBox ID="lsbClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip=""
                                AutoPostBack="false">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbClaimType" runat="server" ErrorMessage="Please Select Claim Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="1" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Scheduled Date<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtScheduleDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtScheduleDate"
                                ErrorMessage="Scheduled Date must not be Blank" SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator6" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Scheduled Date is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Scheduled End Date<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtScheduleEndDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtScheduleEndDate"
                                ErrorMessage="Scheduled End Date must not be Blank" SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator7" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Scheduled End Date is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="csvtxtScheduleEndDate" runat="server" ErrorMessage="Scheduled End Date must greater than Scheduled Date."
                                ClientValidationFunction="CheckScheduleEndDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Recurring Period<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left" colspan="3">
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
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Recipient List<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                        </td>
                        <td align="center" width="4">
                        </td>
                        <td align="left" colspan="3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:CustomValidator ID="cmvCheckAllRow" runat="server" ClientValidationFunction="CheckAllRow"
                                Display="None" SetFocusOnError="false">
                            </asp:CustomValidator>
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
            <td align="center">
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
