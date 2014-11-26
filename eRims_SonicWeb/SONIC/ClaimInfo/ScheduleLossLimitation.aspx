<%@ Page Language="C#" Title="eRIMS :: Loss Limitation Report" MasterPageFile="~/Tatva_ScheduleMaster.master"
    AutoEventWireup="true" CodeFile="ScheduleLossLimitation.aspx.cs" Inherits="ClaimDetailReport_ScheduleLossLimitation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script language="javascript" type="text/javascript">
        
        var ErrorMsg = '';
        var isFocusSet = false;
        /*******************************************************************************************
            this function Check that All filed limit ,loss from date and To date is enter or not.
            All three must be filled or All blank.            
        *********************************************************************************************/
        function CheckRow(limit,fromdate,todate,rownum)
        {      
            
            // Check if limit , loss from date and loss to date is blank then return true
            if((trim(limit.value) != "") && (trim(fromdate.value) != "") && (trim(todate.value) != ""))                
            {
                return true;
            } 
            
            // Check if one of the three value Loss Limit , loss from date and loss to date enter then
            // set Error message and return false
            if((trim(limit.value) != "") || (trim(fromdate.value) != "") || (trim(todate.value) != ""))
            {   
                // check if Error Message is not blank then append  '-' field for display.
                if (ErrorMsg != '') 
                    ErrorMsg = ErrorMsg + '- ';
                    
                ErrorMsg = ErrorMsg + 'Please Fill All values for ' + rownum  + ' Date range \n'
                
                // Check if focus is not set for any row
                if (isFocusSet == false)
                {
                    if (trim(limit.value) == "")
                    {
                        limit.focus();
                    }
                    else if(trim(fromdate.value) == "")
                    {
                        fromdate.focus();
                    }
                    else if(trim(todate.value) == "")
                    {
                        todate.focus();
                    }
                    isFocusSet = true;
                }
                return false;
            }
            return true;            
        }
        
        /*
            This function is Check All Loss Limits 
        */           
        function CheckAllRow(obj,args)//
        {
            var retVal,i;
            ErrorMsg = '';                                                           
            Page_Validators[Page_Validators.length-1].errormessage = '';
            isFocusSet = false;
            retVal = true;

            var limit1 = document.getElementById('<%=txtLimit1.ClientID%>');
            var fromdate1 = document.getElementById('<%=txtLossFromDate1.ClientID %>');
            var todate1 = document.getElementById('<%=txtLossToDate1.ClientID %>');
            
            var limit2 = document.getElementById('<%=txtLimit2.ClientID%>');
            var fromdate2 = document.getElementById('<%=txtLossFromDate2.ClientID %>');
            var todate2 = document.getElementById('<%=txtLossToDate2.ClientID %>');
            
            CheckRow(limit2,fromdate2,todate2,'Second');
            
            var limit3 = document.getElementById('<%=txtLimit3.ClientID%>');
            var fromdate3 = document.getElementById('<%=txtLossFromDate3.ClientID %>');
            var todate3 = document.getElementById('<%=txtLossToDate3.ClientID %>');
            
            CheckRow(limit3,fromdate3,todate3,'third');
            
            if (ErrorMsg != '')
            {
                args.IsValid = false;
                Page_Validators[Page_Validators.length-1].isvalid = false;
                Page_Validators[Page_Validators.length-1].errormessage = ErrorMsg;
                retVal = false;
                //Page_IsValid = true;
                //Page_ValidationSummaries[0].showmessagebox = false;
            }           
                        
            var dtFrom1 = new Date(fromdate1.value)
            var Tdto1 = new Date(todate1.value);

            var dtFrom2 = new Date(fromdate2.value);
            var Tdto2 = new Date(todate2.value);

            var dtFrom3 = new Date(fromdate3.value);
            var Tdto3 = new Date(todate3.value);

            /*
             * 
             *  For Compare First row with 2 to 5 row
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
             *   For Compare Second row with 3 to 5 row
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
                Loss Limitation Report
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
                <table width="80%" align="center" cellpadding="3" cellspacing="0">
                    <tr align="left">
                        <td colspan="2" style="width: 150px;">
                            &nbsp;
                        </td>
                        <td rowspan="2" valign="middle" style="padding-left: 40px;">
                            Limit
                        </td>
                        <td colspan="2" style="padding-left: 25px;">
                            Accident Date From
                        </td>
                        <td colspan="2" style="padding-left: 25px;">
                            Accident Date To
                        </td>
                        <td colspan="1" style="padding-left: 25px">
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td colspan="2" style="padding-left: 25px;">
                            (MM/DD/YYYY)
                        </td>
                        <td colspan="2" style="padding-left: 25px;">
                            (MM/DD/YYYY)
                        </td>
                        <td colspan="1" style="padding-left: 25px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 100px;">
                            &nbsp;
                        </td>
                        <td align="right" valign="top" width="4">
                            &nbsp;
                        </td>
                        <td style="width: 140px;" align="left">
                            <asp:TextBox ID="txtLimit1" runat="server" MaxLength="10" Width="100px"></asp:TextBox><span
                                style="color: Red; font-weight: bold;">*</span>
                            <asp:RequiredFieldValidator ID="valLimit1" runat="server" Text="*" ControlToValidate="txtLimit1"
                                ErrorMessage="Limit value must not be blank for first Date Range." Display="None"
                                ToolTip="Limit value must not be blank for first Date Range." SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvalLimit1" runat="server" ControlToValidate="txtLimit1"
                                Text="" ErrorMessage="Limit value for first Date Range must be numeric or greater than 0"
                                Display="None" Type="Double" MinimumValue="0" MaximumValue="999999999" SetFocusOnError="true"></asp:RangeValidator>
                        </td>
                        <td style="width: 130px;">
                            <asp:TextBox runat="server" ID="txtLossFromDate1" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate1', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateFrom1" runat="server" ControlToValidate="txtLossFromDate1"
                                ErrorMessage="Please enter Accident Date From for first Date Range." SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="revDateFrom1" ControlToValidate="txtLossFromDate1" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid for first Date Range."
                                runat="server" SetFocusOnError="true" Display="none" />
                        </td>
                        <td valign="middle" align="left">
                            <span style="color: Red; font-weight: bold;">*</span>
                        </td>
                        <td style="width: 130px;">
                            <asp:TextBox runat="server" ID="txtLossToDate1" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate1', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateTo1" runat="server" ControlToValidate="txtLossToDate1"
                                ErrorMessage="Please enter Accident Date To for first Date Range." SetFocusOnError="true"
                                Display="none" />
                            <asp:RangeValidator ID="revDateTo1" ControlToValidate="txtLossToDate1" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date To is not valid for first Date Range."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="cvDate1" runat="server" Type="Date" ControlToValidate="txtLossToDate1"
                                ControlToCompare="txtLossFromDate1" Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date for first Date Range."
                                Display="None" SetFocusOnError="true" />
                        </td>
                        <td valign="middle" align="left">
                            <span style="color: Red; font-weight: bold;">*</span>
                        </td>
                        <td align="left" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLimit2" runat="server" Width="100px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtLimit2"
                                Text="*" ErrorMessage="Limit value for second Date Range must be numeric or greater than 0"
                                Display="static" Type="Double" MinimumValue="0" MaximumValue="999999999" SetFocusOnError="true"></asp:RangeValidator>
                        </td>
                        <td style="width: 130px;">
                            <asp:TextBox runat="server" ID="txtLossFromDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RangeValidator ID="revDateFrom2" ControlToValidate="txtLossFromDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid for second Date Range."
                                runat="server" SetFocusOnError="true" Display="none" />
                        </td>
                        <td valign="middle">
                            <span style="color: Red; font-weight: bold;">&nbsp;</span>
                        </td>
                        <td style="width: 130px;">
                            <asp:TextBox runat="server" ID="txtLossToDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RangeValidator ID="revDateTo2" ControlToValidate="txtLossToDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date To is not valid for second Date Range."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="cvDate2" runat="server" Type="Date" ControlToValidate="txtLossToDate2"
                                ControlToCompare="txtLossFromDate2" Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date for second Date Range"
                                Display="None" SetFocusOnError="true" />
                        </td>
                        <td valign="middle" align="left">
                            <span style="color: Red; font-weight: bold;">&nbsp;</span>
                        </td>
                        <td align="left" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLimit3" runat="server" Width="100px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtLimit3"
                                Text="*" ErrorMessage="Limit value must be numeric or greater than 0 for third Date Range"
                                Display="static" Type="Double" MinimumValue="0" MaximumValue="999999999" SetFocusOnError="true"></asp:RangeValidator>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLossFromDate3" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate3', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RangeValidator ID="revDateFrom3" ControlToValidate="txtLossFromDate3" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid for third Date Range."
                                runat="server" SetFocusOnError="true" Display="none" />
                        </td>
                        <td valign="middle">
                            <span style="color: Red; font-weight: bold;">&nbsp;</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLossToDate3" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate3', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RangeValidator ID="revDateTo3" ControlToValidate="txtLossToDate3" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date To is not valid for third Date Range."
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CompareValidator ID="cvDate3" runat="server" Type="Date" ControlToValidate="txtLossToDate3"
                                ControlToCompare="txtLossFromDate3" Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date for third Date Range"
                                Display="None" SetFocusOnError="true" />
                        </td>
                        <td valign="middle">
                            <span style="color: Red; font-weight: bold;">&nbsp;</span>
                        </td>
                        <td valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            Claim Type <span style="color: Red;">*</span>
                        </td>
                        <td align="left" valign="top" width="4">
                            :
                        </td>
                        <td colspan="5" valign="top" align="left">
                            <asp:ListBox ID="lsbClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip=""
                                AutoPostBack="false">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbClaimType" runat="server" ErrorMessage="Please Select Claim Type"
                                Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Scheduled Date<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left" colspan="4">
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
                        <td align="left" colspan="4">
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
                        <td align="left" colspan="4">
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
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150" style="height: 28px">
                            Recipient List<span class="mf">*</span>
                        </td>
                        <td align="center" width="4" style="height: 28px">
                            :
                        </td>
                        <td align="left" colspan="4" style="height: 28px">
                            <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="height: 28px">
                        </td>
                        <td align="left" style="height: 28px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                        </td>
                        <td align="center" width="4">
                        </td>
                        <td align="left" colspan="4">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:CustomValidator ID="cmvCheckAllRow" runat="server" ClientValidationFunction="CheckAllRow"
                                Display="None" SetFocusOnError="false">
                            </asp:CustomValidator>
                            &nbsp;
                            <input type="button" class="btn" value="Close" onclick="javascript:window.close();" />
                        </td>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
