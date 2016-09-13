<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptLossLimitation.aspx.cs"
 Inherits="SONIC_ClaimInfo_rptLossLimitation" Title="eRIMS Sonic :: Loss Limitation Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        
    </script>

    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Loss Limitation Report
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="65%" cellpadding="3" cellspacing="0">
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
                    </tr>
                    <tr>
                        <td valign="top" style="width: 100px;">
                            &nbsp;
                        </td>
                        <td align="right" valign="top" style="width: 50px;">
                            &nbsp;
                        </td>
                        <td style="width: 140px;" align="left">
                            <asp:TextBox ID="txtLimit1" runat="server" MaxLength="10" Width="100px"></asp:TextBox><span
                                style="color: Red; font-weight: bold;">*</span>
                            <asp:RequiredFieldValidator ID="valLimit1" runat="server" Text="*" ControlToValidate="txtLimit1"
                                ErrorMessage="Limit value must not be blank for first Date Range." Display="None"
                                ToolTip="Limit value must not be blank for first Date Range." SetFocusOnError="true" >
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvalLimit1" runat="server" ControlToValidate="txtLimit1" Text="" ErrorMessage="Limit value for first Date Range must be numeric or greater than 0"
                                    Display="None" Type="Double" MinimumValue="0" MaximumValue="999999999" SetFocusOnError="true" ></asp:RangeValidator>
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
                                runat="server" SetFocusOnError="true"  Display="none" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />  
                            <asp:CompareValidator ID="cvDate1" runat="server" Type="Date" ControlToValidate="txtLossToDate1" ControlToCompare="txtLossFromDate1" 
                            Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date for first Date Range." Display="None" SetFocusOnError="true"  />
                        </td>
                        <td valign="middle" align="left">
                            <span style="color: Red; font-weight: bold;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLimit2" runat="server" Width="100px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtLimit2"
                                Text="*" ErrorMessage="Limit value for second Date Range must be numeric or greater than 0" Display="static"
                                Type="Double" MinimumValue="0" MaximumValue="999999999" SetFocusOnError="true" ></asp:RangeValidator>
                        </td>
                        <td style="width: 130px;">
                            <asp:TextBox runat="server" ID="txtLossFromDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RangeValidator ID="revDateFrom2" ControlToValidate="txtLossFromDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid for second Date Range."
                                runat="server" SetFocusOnError="true"  Display="none" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />  
                            <asp:CompareValidator ID="cvDate2" runat="server" Type="Date" ControlToValidate="txtLossToDate2" ControlToCompare="txtLossFromDate2" 
                            Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date for second Date Range" Display="None" SetFocusOnError="true"  />
                        </td>
                        <td valign="middle" align="left">
                            <span style="color: Red; font-weight: bold;">&nbsp;</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLimit3" runat="server" Width="100px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtLimit3"
                                Text="*" ErrorMessage="Limit value must be numeric or greater than 0 for third Date Range" Display="static"
                                Type="Double" MinimumValue="0" MaximumValue="999999999" SetFocusOnError="true" ></asp:RangeValidator>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLossFromDate3" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate3', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RangeValidator ID="revDateFrom3" ControlToValidate="txtLossFromDate3" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid for third Date Range."
                                runat="server" SetFocusOnError="true"  Display="none" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />  
                            <asp:CompareValidator ID="cvDate3" runat="server" Type="Date" ControlToValidate="txtLossToDate3" ControlToCompare="txtLossFromDate3" 
                            Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date for third Date Range" Display="None" SetFocusOnError="true"  />
                        </td>
                        <td valign="middle">
                            <span style="color: Red; font-weight: bold;">&nbsp;</span>
                        </td>
                    </tr>                   
                    <tr>
                        <td valign="top">
                            &nbsp; Claim Type <span style="color: Red;">*</span>
                        </td>
                        <td align="right" valign="top">
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
                                Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                        <td>
                        </td>
                        <td align="left" colspan="5">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" UseSubmitBehavior="true" OnClick="btnShowReport_Click" />
                            &nbsp;<asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                            <asp:CustomValidator ID="cmvCheckAllRow" runat="server" ClientValidationFunction="CheckAllRow"
                                Display="None" SetFocusOnError="false">
                            </asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="80%" align="center">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <table id="tblUtility" runat="server" width="100%" align="center">
                        <tr valign="middle">
                            <td align="right" width="100%">
                                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHeader" Text="" runat="server" Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvRegion" runat="server" Width="100%" OnRowDataBound="gvRegion_RowDataBound" AutoGenerateColumns="false" OnRowCreated="gvRegion_RowCreated" 
                    EnableTheming="false" HorizontalAlign="Left" CellPadding="0" GridLines="None" CssClass="GridClass" ShowFooter="true" EmptyDataText="No Record Found">
                    <HeaderStyle CssClass="HeaderStyle" />
                    <FooterStyle CssClass="FooterStyle" />
                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="20px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                     <table cellpadding="0" cellspacing="0" width="100%" style='background-color:White;font-weight:bold;color:Black;' style="display:none;">
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%" style="background-color:White;font-weight:bold;color:Black;" id="tblMainHeader" runat="server">
                                                    <tr>
                                                        <td width="100%" align="left" id="tdHeader1" runat="server" colspan="5">&nbsp;
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                             </td>
                                         </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="0" width="100%" id="tblHeader" runat="server" style="font-weight: bold;">
                                                    <tr>
                                                        <td width="30%" align="left">
                                                            Location
                                                        </td>
                                                        <td width="15%" align="right">
                                                            Claim Count
                                                        </td>
                                                        <td width="20%" align="right">
                                                            Total Incurred Dollars
                                                        </td>
                                                        <td width="20%" align="right">
                                                            Limited Incurred
                                                        </td>
                                                        <td width="15%" align="right">
                                                            Excess
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </td>
                                        </tr>
                                    </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left" colspan="5" style="background-color: White; height: 25px; color: Black; border:thin">
                                                <b>
                                                    Region : <asp:Label ID="lblRegion" runat="server"><%#Eval("Region")%></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:GridView ID="gvLossLimitation" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" GridLines="None" ShowHeader="false" ShowFooter="true" EmptyDataText="No Record found !"
                                                EnableTheming="false" CssClass="GridClass" OnRowDataBound="gvLossLimitation_RowDataBound">
                                                <RowStyle CssClass="RowStyle" />
                                                <AlternatingRowStyle CssClass="AlterStyle" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemStyle HorizontalAlign="Left" Width="30%"/>
                                                        <FooterStyle HorizontalAlign="left" Font-Bold="true" ForeColor="black" BackColor="white" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEntityCode" runat="server" Text='<%#Convert.ToString(Eval("dba"))%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalEnityCode" runat="server" Text="Sub Totals"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle HorizontalAlign="Right" Width="15%"/>
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" ForeColor="black" BackColor="white" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClaimCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ClaimCount","{0:n0}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalClaimCount" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" ForeColor="black" BackColor="white" />
                                                        <ItemStyle HorizontalAlign="Right" Width="20%"/>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncurred" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TotalIncurred","{0:c2}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalIncurred" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" ForeColor="black" BackColor="white" />
                                                        <ItemStyle HorizontalAlign="Right" Width="20%"/>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLimitedIncurred" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LimitedIncurred","{0:c2}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalLimitedIncurred" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle HorizontalAlign="Right" Width="15%"/>
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" ForeColor="black" BackColor="white" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExcess" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Excess","{0:c2}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblExcess" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold; background-color: #507CD1;
                                                                                            color: White;" id="tblFooter" runat="server">
                                                    <tr>
                                                        <td width="30%" align="left">
                                                            Report Grand Total
                                                        </td>
                                                        <td width="15%" align="right">
                                                            <asp:Label ID="lblTotalClaimCount" runat="server" />
                                                        </td>
                                                        <td width="20%" align="right">
                                                            <asp:Label ID="lblTotalIncurred" runat="server" />
                                                        </td>
                                                        <td width="20%" align="right">
                                                            <asp:Label ID="lblLimitedIncurred" runat="server" />
                                                        </td>
                                                        <td width="15%" align="right">
                                                            <asp:Label ID="lblExcess" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
</asp:Content>

