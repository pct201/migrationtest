<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PremiumAllocationFields.aspx.cs" Inherits="SONIC_Exposures_PremiumAllocationFields" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript"  language="javascript">

        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }
    </script>
    <div>
     <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsError"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
   </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow" align="left">
                Premium Allocation
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlEdit" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td  align="left" width="18%">
                                Year <span style="color: Red;">*</span>
                            </td>
                            <td align="center"  width="4%">
                                :
                            </td>
                            
                            <td>
                                <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="170px" onpaste="return false" AutoPostBack="true" SkinID="txtYearWithRange" OnTextChanged="txtYear_TextChanged">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="revtxtYear" runat="server" Display="None" ErrorMessage="Please Enter Year."
                                    ControlToValidate="txtYear" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvtxtYearBuilt" runat="server" ControlToValidate="txtYear"
                                    ValidationGroup="vsError" Type="Integer" MinimumValue="1"
                                    MaximumValue="2100" ErrorMessage="Year is not valid."
                                    Display="None"></asp:RangeValidator>
                            </td>
                            <td align="left" width="18%">
                                Property Valuation Date <span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            
                            <td align="left" style="width: 28%">
                                                    <asp:TextBox ID="txtProperty_Valuation_Date" runat="server"   SkinID="txtDate"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtPropertyValuationDate" runat="server" Display="None" ErrorMessage="Please Select Property Valuation Date."
                                    ControlToValidate="txtProperty_Valuation_Date" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                                                    <img  alt="Property Valuation Date"  onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtProperty_Valuation_Date', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" 
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revPropertyValuationDate" ControlToValidate="txtProperty_Valuation_Date"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Property Valuation Date is not valid."
                                                        runat="server" ValidationGroup="vsError" Display="none" />
                                                </td>
                        </tr>
                        <tr>
                             <td align="left" width="18%">
                                Total Number Of Locations
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtTotal_Locations" Enabled="false" runat="server" Width="170px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                onpaste="return false" />
                            </td>
                            <td align="left" width="18%">
                                Property Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtProperty_Premium" runat="server"   skinid="txtCurrency15w" Width="170px"
                                onpaste="return false" />
                            </td>
                            
                            
                        </tr>
                         <tr>
                             <td align="left" width="18%">
                                Worker's Compensation Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtWC_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                              <td align="left" width="18%" style="padding-left:20px;">
                             Total RS Means
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtPP_Total_RS_Means" runat="server" Width="170px" Enabled="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            
                            
                        </tr>
                        <tr>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Payroll
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtWC_Total_Payroll" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            <td align="left" width="18%" style="padding-left:20px;">
                              Total Business Interuption
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtPP_Total_Business_Interruption" runat="server" Enabled ="false" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                           
                        </tr>
                        <tr>
                            <td align="left" width="18%"  style="padding-left:20px;" >
                                 Total Headcount
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                
                                <asp:TextBox ID="txtWC_Total_Headcount" runat="server" Width="170px" Enabled ="false" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                onpaste="return false" />
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">

                               Total Contents
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtPP_Total_Contents" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                           
                        </tr>
                        <tr>
                           <td align="left" width="18%">
                                Texas Non-Subscription Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtTexas_WC_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">
                                Total Parts
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtPP_Total_Parts" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Payroll
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtTexas_WC_Payroll" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">
                                 Total Insurable Values
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtPPTotalInsurableValues" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            
                        </tr>
                         <tr>
                             <td align="left" width="18%" style="padding-left:20px;">
                              Total Headcount
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtTexas_NSP_Total_Headcount" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                              <td align="left" width="18%">
                                Earthquake Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEarthquake_Premium" runat="server" Width="170px"  skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                           <td align="left" width="18%">
                                Excess Umbrella Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtExcess_Umbrella_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">
                                Total RS Means
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEP_Total_RS_Means" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                           
                        </tr>
                        <tr> 
                           
                            <td align="left" width="18%">
                                EPLI Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEPL_Premium" runat="server" Width="170px"  skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Business Interuption
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEP_Total_Business_Interruption" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                           
                            </tr>
                        <tr>
                            
                           <td align="left" width="18%">
                                Garage Liability Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtGarage_Liability_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                             
                            <td align="left" width="18%" style="padding-left:20px;">
                               Total Contents
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEP_Total_Contents" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Crime Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtCrime_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                           <td align="left" width="18%" style="padding-left:20px;">
                                 Total Parts
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEP_Total_Parts" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Cyber Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtCyber_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Insurable Values
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtEPTotalInsurableValues" runat="server" Width="170px" Enabled ="false" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>

                        </tr>
                        <tr>
                             <td align="left" width="18%">
                               Directors and Officers Premium 
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtDirectors_Officers_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            <td align="left" width="18%">
                                Pollution Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtPollution_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                             <td align="left" width="18%">
                               Fiduciary Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtFiduciary_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            <td align="left" width="18%">
                               Dealers Physical Damage Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtDealers_Physical_Damage_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Kidnap and Ransom Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:TextBox ID="txtKidnap_Ransom_Premium" runat="server" Width="170px" skinid="txtCurrency15w"
                                onpaste="return false" />
                            </td>
                            
                        </tr>
                        <%--<tr>
                            <td align="left" width="18%">
                                Loss Fund Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtLoss_Fund_Premium" runat="server" Width="170px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                onpaste="return false" />
                            </td>
                             <td align="left" width="18%">
                                Umbrella Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtUmbrella_Premium" runat="server" Width="170px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                              <td align="left" width="18%">
                                2nd Layer Umbrella Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtSecond_Layer_Umbrella_Premium" runat="server" Width="170px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                onpaste="return false" />
                            </td>
                             <td align="left" width="18%">
                                Total Risk Management Fee
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtTotal_Risk_Management_Fee" runat="server" Width="170px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                onpaste="return false" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSave" Text=" Save " OnClick="btnSave_Click"
                                    ToolTip="Save" CausesValidation="true" ValidationGroup="vsError"  />
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnBackToSearch" Text="Back To Search" OnClick="btnBackToSearch_Click"
                                    ToolTip="Back To Search" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlView" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr valign="top">
                            <td>
                                Year
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblYear" runat="server">                                 
                                </asp:Label>
                            </td>
                            <td align="left" width="18%">
                                Property Valuation Date
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            
                            <td align="left" style="width: 28%">
                              <asp:Label ID="lblProperty_Valuation_Date" runat="server"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                             <td align="left" width="18%">
                                Total Number Of Locations
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                 <asp:Label ID="lblTotal_Locations" runat="server"></asp:Label>
                            </td>
                            <td align="left" width="18%">
                                Property Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                 <asp:Label ID="lblProperty_Premium" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                             <td align="left" width="18%">
                                Worker's Compensation Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $<asp:Label ID="lblWC_Premium" runat="server"></asp:Label>
                                
                            </td>
                              <td align="left" width="18%" style="padding-left:20px;">
                             Total RS Means
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblPP_Total_RS_Means" runat="server"></asp:Label>
                            </td>
                            
                            
                        </tr>
                        <tr>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Payroll
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                 <asp:Label ID="lblWC_Total_Payroll" runat="server"></asp:Label>
                            </td>
                            <td align="left" width="18%" style="padding-left:20px;">
                              Total Business Interruption
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblPP_Total_Business_Interruption" runat="server"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr>
                            <td align="left" width="18%"  style="padding-left:20px;" >
                                 Total Headcount
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                
                                <asp:Label ID="lblWC_Total_Headcount" runat="server"></asp:Label>
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">

                               Total Contents
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                 <asp:Label ID="lblPP_Total_Contents" runat="server"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr>
                           <td align="left" width="18%">
                                Texas Non-Subscription Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblTexas_WC_Premium" runat="server"></asp:Label>
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">
                                Total Parts
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblPP_Total_Parts" runat="server"></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Payroll
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                 <asp:Label ID="lblTexas_WC_Payroll" runat="server"></asp:Label>
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">
                                 Total Insurable Values
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblPP_Total_Insurable_Values" runat="server"></asp:Label>
                            </td>
                            
                        </tr>
                         <tr>
                             <td align="left" width="18%" style="padding-left:20px;">
                              Total Headcount
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblTexas_NSP_Total_Headcount" runat="server"></asp:Label>
                            </td>
                              <td align="left" width="18%">
                                Earthquake Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblEarthquake_Premium" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                           <td align="left" width="18%">
                                Excess Umbrella Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblExcess_Umbrella_Premium" runat="server" SkinID="lblDate"></asp:Label>
                            </td>
                             <td align="left" width="18%" style="padding-left:20px;">
                                Total RS Means
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblEP_Total_RS_Means" runat="server"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr> 
                           
                            <td align="left" width="18%">
                                EPLI Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label runat="server" ID="lblEPL_Premium"></asp:Label>
                            </td>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Business Interruption
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblEP_Total_Business_Interruption" runat="server"></asp:Label>
                            </td>
                           
                            </tr>
                        <tr>
                            
                           <td align="left" width="18%">
                                Garage Liability Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblGarage_Liability_Premium" runat="server" SkinID="lblDate"></asp:Label>
                                <br />
                            </td>
                             
                            <td align="left" width="18%" style="padding-left:20px;">
                               Total Contents
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblEP_Total_Contents" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Crime Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblCrime_Premium" runat="server"></asp:Label>
                            </td>
                           <td align="left" width="18%" style="padding-left:20px;">
                                 Total Parts
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                 <asp:Label ID="lblEP_Total_Parts" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Cyber Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                  <asp:Label ID="lblCyber_Premium" runat="server"> </asp:Label>

                            </td>
                            <td align="left" width="18%" style="padding-left:20px;">
                                Total Insurable Values
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                 <asp:Label ID="lblEP_Total_Insurable_Values" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                             <td align="left" width="18%">
                               Directors and Officers Premium 
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblDirectors_Officers_Premium" runat="server"></asp:Label>
                            </td>
                            <td align="left" width="18%">
                                Pollution Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblPollution_Premium" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                             <td align="left" width="18%">
                               Fiduciary Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                                <asp:Label ID="lblFiduciary_Premium" runat="server"></asp:Label>
                            </td>
                            <td align="left" width="18%">
                               Dealers Physical Damage Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblDealers_Physical_Damage_Premium" runat="server"></asp:Label> 
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Kidnap and Ransom Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                $
                               <asp:Label ID="lblKidnap_Ransom_Premium" runat="server"></asp:Label> 
                            </td>
                            
                        </tr>


                       <%-- <tr>
                            <td align="left" width="18%">
                                Worker's Compensation Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                
                            </td>
                            <td align="left" width="18%">
                               Texas Worker's Compensation Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Loss Fund Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblLoss_Fund_Premium" runat="server">
                                </asp:Label>
                            </td>
                            <td align="left" width="18%">
                                Garage Liability Premium
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Property Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                               
                            </td>
                            <td align="left">
                                Crime Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Umbrella Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblUmbrella_Premium" runat="server" onKeyPress="return FormatInteger(event);"></asp:Label>
                            </td>
                            <td align="left">
                                Excess Umbrella Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                               2nd Layer Umbrella Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label runat="server" ID="lblSecond_Layer_Umbrella_Premium"></asp:Label>
                            </td>
                            <td align="left">
                                EPL Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Cyber Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                              
                            </td>
                            <td align="left">
                                Total Risk Management Fee
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTotal_Risk_Management_Fee" runat="server" SkinID="lblDate"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                Pollution Premium
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnBackToEdit" Text=" Edit " OnClick="btnBackToEdit_Click"
                                    ToolTip="Edit" />
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnBack" Text="Back To Search" OnClick="btnBackToSearch_Click"
                                    ToolTip="Back To Search" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

