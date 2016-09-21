<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptThreePITSummary.aspx.cs" 
Inherits="SONIC_ClaimInfo_rptThreePITSummary" Title="eRIMS Sonic :: Three Points in Time Summary Report" %>

<%@ Register Src="../../Controls/MonthSelector/MonthSelectControl.ascx" TagName="MonthSelectControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        

        
    </script>
<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Three Points in Time Summary Report
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="65%">
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
                                runat="server" SetFocusOnError="true"  Display="none" />                            
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
                                runat="server" SetFocusOnError="true"  Display="none" />
                            <asp:CompareValidator ID="compValidator1" runat="server" ControlToValidate="txtLossToDate1" ControlToCompare="txtLossFromDate1" Type="Date" Operator="greaterThanEqual"
                                SetFocusOnError="true"  ErrorMessage="Loss To Date must be greater than or equal to Loss From Date" Display="None" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLossToDate2" ControlToCompare="txtLossFromDate2" Type="Date" Operator="greaterThanEqual"
                                SetFocusOnError="true"  ErrorMessage="Loss To Date must be greater than or equal to Loss From Date" Display="None" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />
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
                                runat="server" SetFocusOnError="true"  Display="none" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtLossToDate3" ControlToCompare="txtLossFromDate3" Type="Date" Operator="greaterThanEqual"
                                SetFocusOnError="true"  ErrorMessage="Loss To Date must be greater than or equal to Loss From Date" Display="None" />
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
                        <td>
                        </td>
                        <td align="right">
                        </td>
                        <td colspan="3" valign="top" align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" UseSubmitBehavior="true" />&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                            <asp:CustomValidator ID="cmvCheckAllRow" runat="server" ClientValidationFunction="CheckAllRow"
                                Display="None" SetFocusOnError="false" >
                            </asp:CustomValidator></td>
                        <td colspan="1" valign="top">
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
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="90%" align="center">
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
                                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click" CausesValidation="false"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    <asp:Label ID="lblHeader" Text="Three Points-In-Time Summary Report" runat="server">
                    </asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td width="100%" align="center" id="tdReport" runat="server">
                    <asp:GridView ID="gvRegion" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gvRegion_RowDataBound" OnRowCreated="gvReport_RowCreated" 
                        CellPadding="4" GridLines="None" CssClass="GridClass" ShowFooter="true" EmptyDataText="No Record found !" EnableTheming="false">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <FooterStyle CssClass="FooterStyle" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="4" cellspacing="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                                    <tr>
                                                        <td width="14%" align="left">
                                                            Location
                                                        </td>
                                                        <td width="10%" align="right">
                                                            Total Incurred Dollars
                                                        </td>
                                                        <td width="8%" align="right">
                                                            # of Claims
                                                        </td>
                                                        <td width="10%" align="right">
                                                            Total Incurred Dollars
                                                        </td>
                                                        <td width="8%" align="right">
                                                            Fin Chg Pd 1-2
                                                        </td>
                                                        <td width="8%" align="right">
                                                            # of Claims
                                                        </td>
                                                        <td width="8%" align="right">
                                                            Claims % Chg P 1-2
                                                        </td>
                                                        <td width="10%" align="right">
                                                            Total Incurred Dollars
                                                        </td>
                                                        <td width="8%" align="right">
                                                            Fin Chg Pd 2-3
                                                        </td>
                                                        <td width="8%" align="right">
                                                            # of Claims
                                                        </td>
                                                        <td width="8%" align="right">
                                                            Claims % chg P 2-3
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
                                            <td align="left" colspan="11" style="background-color: White; height: 25px; color: Black;border:thin">
                                                <b>
                                                    Region : <asp:Label ID="lblRegion" runat="server"><%#Eval("Region")%></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" GridLines="None" CssClass="GridClass" ShowFooter="true" EmptyDataText="No Record found !"
                                                EnableTheming="false" ShowHeader="false">                                                
                                                <RowStyle CssClass="RowStyle" />
                                                <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                 <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
                                                        <FooterStyle Width="14%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Left"/>
                                                        <ItemStyle Width="14%" />
                                                        <ItemTemplate>
                                                            <%# Eval("Location") %>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            Totals
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle Width="10%"  BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right" />
                                                        <ItemStyle Width="10%" HorizontalAlign="right"/>
                                                        <ItemTemplate>
                                                            <%# Eval("Incurred_1","{0:C2}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right" />
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("ClaimCount_1", "{0:N0}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle Width="10%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right"/>
                                                        <ItemStyle Width="10%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("Incurred_2","{0:C2}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right" />
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("FinChgPd2Inc_2", "{0:f}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right" />
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("ClaimCount_2", "{0:N0}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right" />
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("FinChgPd2Cnt_2", "{0:f}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="10%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("Incurred_3","{0:C2}")%>
                                                        </ItemTemplate>
                                                        <FooterStyle Width="10%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("FinChgPd2Inc_3", "{0:f}")%>
                                                        </ItemTemplate>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("ClaimCount_3", "{0:N0}")%>
                                                        </ItemTemplate>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="8%" HorizontalAlign="right" />
                                                        <ItemTemplate>
                                                            <%# Eval("FinChgPd2Cnt_3", "{0:f}")%>
                                                        </ItemTemplate>
                                                        <FooterStyle Width="8%" BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" style="font-weight: bold; background-color: #507CD1;color: White;" id="tblFooter" runat="server">
                                                    <tr>
                                                        <td style="width: 14%" align="left">
                                                            Report Grand Totals
                                                        </td>
                                                        <td width="10%" align="right">
                                                            <asp:Label ID="lblTotalIncurred1" runat="server" />
                                                        </td>
                                                        <td width="8%" align="right">
                                                            <asp:Label ID="lblClaims1" runat="server" />
                                                        </td>
                                                        <td width="10%" align="right">
                                                            <asp:Label ID="lblTotalIncurred2" runat="server" />
                                                        </td>
                                                        <td width="8%" align="right">
                                                            <asp:Label ID="lblFinChgPd21" runat="server" />
                                                        </td>
                                                        <td width="8%" align="right">
                                                             <asp:Label ID="lblClaims2" runat="server" />
                                                        </td>
                                                        <td width="8%" align="right">
                                                            <asp:Label ID="lblClaimsPercent12" runat="server" />                                                            
                                                        </td>
                                                        <td width="10%" align="right">
                                                            <asp:Label ID="lblTotalIncurred3" runat="server" />                                                            
                                                        </td>
                                                        <td width="8%" align="right">
                                                            <asp:Label ID="lblFinChgPd23" runat="server" />
                                                        </td>
                                                        <td width="8%" align="right">
                                                            <asp:Label ID="lblClaims3" runat="server" />                                                            
                                                        </td>
                                                        <td width="8%" align="right">
                                                            <asp:Label ID="lblClaimsPercentchg23" runat="server" />
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

