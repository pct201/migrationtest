<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="NationalPremiumAllocation.aspx.cs" Inherits="SONIC_Exposures_NationalPremiumAllocation" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>

    <script type="text/javascript" language="javascript">

        function showCalendarEquipment(id, format, AfterSelect, AfterSelArgs) {
            //hardik            
            var el = document.getElementById(id);
            if (calendar != null) {

                calendar.hide();

            } else {

                var cal = new Calendar(false, null, selected, closeHandler, AfterSelect, AfterSelArgs);

                calendar = cal;

                cal.setRange(1900, 2070);

                cal.create();
            }


            calendar.setDateFormat(format);

            calendar.parseDate(el.value);

            calendar.sel = el;

            calendar.showAtElement(el);
            $(calendar.element).find('td.day').click(function () {
                var date = calendar.date;
                var newDate = new Date(parseInt(date.getFullYear()), date.getMonth(), date.getDate());
                $('#<%=txtProperty_Valuation_Date.ClientID%>').val(("0" + parseInt(newDate.getMonth() + 1)).slice(-2) + "/" + ("0" + newDate.getDate()).slice(-2) + "/" + newDate.getFullYear());
            });
            return true;


        }


        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }

        function OpenPopup() {

            var navUrl = '<%=AppConfig.SiteURL%>/Sonic/Exposures/RiskManagementServiceGrid.aspx?FK_PA_National_Allocation=' + '<%= Convert.ToString(PK_PA_National_Allocation) %>' + '&strOperation=' + 'add'
            OpenWindow(navUrl);
            return false;
            //alert("Please Save Premium Allocation Data First.");

        }

        function CheckYear() {
            if (document.getElementById('<%=txtYear.ClientID%>').value != undefined && document.getElementById('<%=txtYear.ClientID%>').value != null && document.getElementById('<%=txtYear.ClientID%>').value != "") {
                return confirm('Are you sure that you want to remove the record?');
            }
            else {
                alert("Please Enter Year and Save the Data.");
                return false;
            }

        }

        function CheckYearupdate() {
            if (document.getElementById('<%=txtYear.ClientID%>').value != undefined && document.getElementById('<%=txtYear.ClientID%>').value != null && document.getElementById('<%=txtYear.ClientID%>').value != "") {
                return true;
            }
            else {
                alert("Please Enter Year and Save the Data.");
                return false;
            }

        }

        function OpenWindow(navUrl) {
            var w = 700, h = 400;

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 400, popH = 300;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navUrl, "popup2", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
        }

        function valueSave(mon) {
            var retVal = true;
            retVal = confirm("Updating National Premium Allocation data will erase and regenerate Location premium allocation data. Are you sure want to continue?");
            if (retVal == true)
                __doPostBack(document.getElementById('<%=btnSave.ClientID%>').name, "UpdateDetails");

        }

    </script>
    <style>
        .InnerContent {
            padding-left: 25px;
        }
    </style>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsError"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <div>
        <asp:ValidationSummary ID="vsErrorGroup" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow" align="left">National Premium Allocation
            </td>
        </tr>
        <tr>
            <td>&nbsp;
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
                        <tr>
                            <td>Year <span style="color: Red;">*</span>
                            </td>
                            <td align="center">:
                            </td>
                            <td>
                                <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="170px" onpaste="return false" SkinID="txtYearWithRange">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="revtxtYear" runat="server" Display="None" ErrorMessage="Please Enter Year."
                                    ControlToValidate="txtYear" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvtxtYearBuilt" runat="server" ControlToValidate="txtYear"
                                    ValidationGroup="vsError" Type="Integer" MinimumValue="1"
                                    MaximumValue="2100" ErrorMessage="Year is not valid."
                                    Display="None"></asp:RangeValidator>
                            </td>
                            <td>Property Valuation Date<span style="color: Red;">*</span>
                            </td>
                            <td align="center">:
                            </td>
                            <td>
                                <asp:TextBox ID="txtProperty_Valuation_Date" runat="server" Width="170px" onpaste="return false" SkinID="txtDate">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Please Enter Property Valuation Date."
                                    ControlToValidate="txtProperty_Valuation_Date" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                                <img alt="PV Date" onclick="showCalendar('ctl00_ContentPlaceHolder1_txtProperty_Valuation_Date', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                    align="middle" /><br />
                                <asp:RegularExpressionValidator ID="revReport_Date" runat="server" ValidationGroup="vsError"
                                    Display="none" ErrorMessage="Property Valuation Date is not a valid date" SetFocusOnError="true"
                                    ControlToValidate="txtProperty_Valuation_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Number of Locations
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtTotal_Locations" runat="server" Enabled="false" Width="170px" onpaste="return false" MaxLength="5" onKeyPress="javascript:return FormatInteger(event);" />
                            </td>
                            <td align="left" width="18%">Total Headcount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtTotal_Headcount" runat="server" Enabled="false" Width="170px" onpaste="return false" MaxLength="5" onKeyPress="javascript:return FormatInteger(event);" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Worker's Compensation Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtWC_Premium" runat="server" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%">Property Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtProperty_Premium" runat="server" SkinID="txtCurrency12w" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Payroll
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtWCTotal_Payroll" runat="server" SkinID="txtCurrency12w" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total RS Means
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPropertyRS_Means" runat="server" Width="170px" onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Headcount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtWCTotalHeadcount" runat="server" SkinID="txtCurrency15w" Enabled="false"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Business Interruption
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPropertyTotalBusinessInterruption" runat="server" SkinID="txtCurrency15w" Enabled="false"
                                    onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Workers’ Compensation Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtWorkersCompensationRate" runat="server" SkinID="txtCurrency15w" onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Texas Non-Subscription Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTexasNonSubscriptionPremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Contents
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPropertyTotalContents" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Payroll
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTXTotalPayroll" runat="server" Width="170px" onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Parts
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPropertyTotalParts" runat="server" Width="170px" onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Headcount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTXTotalHeadcount" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Insurable Values
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPropertyTotalInsurableValues" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Texas Non-Subscription Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTexasNonSubscriptionRate" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Property Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPropertyRate" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Excess Umbrella Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtExcessUmbrellaPremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%">Earthquake Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakePremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Excess Umbrella Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtExcessUmbrellaRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total RS Means
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakeTotalRSMeans" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">EPLI Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEPLIPremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Business Interruption
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakeTotalBusinessInterruption" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">EPLI Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEPLIRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Contents
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakeTotalContents" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Garage Liability Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtGarageLiabilityPremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Parts
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakeTotalParts" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Garage Liability Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtGarageLiabilityRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Insurable Values
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakeTotalInsurableValues" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Crime Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtCrimePremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Earthquake Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtEarthquakeRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Crime Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtCrimeRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%">Pollution Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPollutionPremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Cyber Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtCyberPremium" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Pollution Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtPollutionRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Cyber Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtCyberRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                            </td>
                            <td align="left" width="18%">&nbsp;
                            </td>
                            <td align="center" width="4%">&nbsp;
                            </td>
                            <td align="left" width="28%">&nbsp;
                            </td>
                        </tr>
                        <tr runat="server" id="trstoreGrid">
                            <td align="left" valign="top">
                                <b>Risk Management Service Grid</b>
                            </td>
                            <td align="center" valign="top">
                                <b>:</b>
                            </td>
                            <td align="left" valign="top" colspan="4">
                                <asp:UpdatePanel ID="upd" runat="server">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr id="trStatusGrid" runat="server">
                                                <td align="left">
                                                    <asp:GridView ID="gvRiskManagementServiceGrid" runat="server" Width="90%" AutoGenerateColumns="false" OnRowDataBound="gvRiskManagementServiceGrid_RowDataBound"
                                                        EmptyDataText="No Record Exists" OnRowCommand="gvRiskManagementServiceGrid_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Service" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle Width="35%" HorizontalAlign="center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkService" runat="server" Text='<%# Eval("Field_Description") %>'
                                                                        CommandName="EditDetails" CommandArgument='<%# Eval("PK_PA_National_Allocation_Service_Grid") %>' OnClientClick="return CheckYearupdate();" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Service Amount ($)" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle Width="45%" HorizontalAlign="center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkServiceAmount" runat="server" Text='<%# clsGeneral.FormatCommaSeperatorCurrency(Eval("Service_Amount")) %>'
                                                                        CommandName="EditDetails" CommandArgument='<%# Eval("PK_PA_National_Allocation_Service_Grid") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle Width="10%" HorizontalAlign="center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                        CommandArgument='<%# Eval("PK_PA_National_Allocation_Service_Grid") %>' OnClientClick="return CheckYear();" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-bottom: 5px;">
                                                    <asp:LinkButton ID="lnkAddRiskServiceNew" OnClick="lnkAddRiskServiceNew_Click" OnClientClick="return CheckYearupdate();"
                                                        runat="server" Text="Add New"></asp:LinkButton>&nbsp;                                                                           
                                                </td>
                                            </tr>
                                            <tr id="trStatusAdd" runat="server" display="none">
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td width="70%">
                                                                <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                                                                    <tr>
                                                                        <td align="left" valign="top">Service<span style="color: red">*</span></td>
                                                                        <td align="center" valign="top">:</td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlService" runat="server" Width="170px" />
                                                                            <asp:RequiredFieldValidator ID="rfvService" runat="server" Display="None" ErrorMessage="Please Enter Service."
                                                                                ControlToValidate="ddlService" SetFocusOnError="true" ValidationGroup="vsErrorGroup" InitialValue="0"></asp:RequiredFieldValidator>
                                                                        </td>

                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Service Amount $</td>
                                                                        <td align="center" valign="top">:</td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtServiceAmount" runat="server"
                                                                                SkinID="txtCurrency12w" onpaste="return false" /></td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="40%"></td>
                                                                        <td colspan="2">
                                                                            <asp:Button ID="btnSaveGrid" Text="Add" runat="server" OnClick="btnSaveGrid_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />&nbsp;
                                            <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="6">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td align="left" width="26%">Total Risk Management Fee
                                                </td>
                                                <td align="center" width="4%">:
                                                </td>
                                                <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTotalRiskManagementFee" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                                                </td>
                                                <td align="left" width="18%"></td>
                                                <td align="center" width="4%"></td>
                                                <td align="left" width="28%"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="18%">Total Risk Management Rate
                                                </td>
                                                <td align="center" width="4%">:
                                                </td>
                                                <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTotalRiskManagementRate" runat="server" Width="170px" SkinID="txtCurrency12w"
                                    onpaste="return false" Enabled="false" />
                                                </td>
                                                <td align="left" width="18%"></td>
                                                <td align="center" width="4%"></td>
                                                <td align="left" width="28%"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="18%">Total Actual Cost
                                                </td>
                                                <td align="center" width="4%">:
                                                </td>
                                                <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTotal_Actual_Cost" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                                                </td>
                                                <td align="left" width="18%"></td>
                                                <td align="center" width="4%"></td>
                                                <td align="left" width="28%"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="18%">Total Store Cost
                                                </td>
                                                <td align="center" width="4%">:
                                                </td>
                                                <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTotal_Store_Cost" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                                                </td>
                                                <td align="left" width="18%"></td>
                                                <td align="center" width="4%"></td>
                                                <td align="left" width="28%"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="18%">Total Surcharge Amount
                                                </td>
                                                <td align="center" width="4%">:
                                                </td>
                                                <td align="left" width="28%">$&nbsp;
                                <asp:TextBox ID="txtTotal_Surcharge_Amount" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" Enabled="false" />
                                                </td>
                                                <td align="left" width="18%"></td>
                                                <td align="center" width="4%"></td>
                                                <td align="left" width="28%"></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSave" Text=" Save " OnClick="btnSave_Click"
                                    ToolTip="Save" CausesValidation="true" ValidationGroup="vsError" />
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnBackToSearch" Text="Back To Search" OnClick="btnBackToSearch_Click"
                                    ToolTip="Back To Search" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlView" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label1" runat="server" Visible="False" Font-Bold="True" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Year    
                            </td>
                            <td align="center">:
                            </td>
                            <td>
                                <asp:Label ID="lblYear" runat="server">
                                </asp:Label>
                            </td>
                            <td>Property Valuation Date<span style="color: Red;"></span>
                            </td>
                            <td align="center">:
                            </td>
                            <td>
                                <asp:Label ID="lblPropertyValuationDate" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Number of Locations
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblTotalNumberofLocations" runat="server" />
                            </td>
                            <td align="left" width="18%">Total Headcount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblTotalHeadcount" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Worker's Compensation Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblWorkerCompensationPremium" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%">Property Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyPremium" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Payroll
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblWCTotalPayroll" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total RS Means
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyTotalRSMeans" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Headcount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblWCTotalHeadcount" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Business Interruption
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyTotalBusinessInterruption" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Workers’ Compensation Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblWorkersCompensationRate" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Texas Non-Subscription Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTexasNonSubscriptionPremium" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Contents
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyTotalContent" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Payroll
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTXTotalPayroll" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Parts
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyTotalParts" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Total Headcount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTXTotalHeadCount" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Insurable Values
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyTotalInsurableValues" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Texas Non-Subscription Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTexasNonSubscriptionRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Property Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPropertyRate" runat="server" Width="170px" SkinID="txtCurrency15w"
                                    onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Excess Umbrella Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblExcessUmbrellaPremium" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%">Earthquake Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakePremium" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Excess Umbrella Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblExcessUmbrellaRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total RS Means
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakeTotalRSMeans" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">EPLI Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEPLIPremium" runat="server" Width="170px" SkinID="txtCurrency15w" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Business Interruption
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakeTotalBusinessInterruption" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">EPLI Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEPLIRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Contents
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakeTotalContents" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Garage Liability Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblGarageLiabilityPremium" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Parts
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakeTotalParts" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Garage Liability Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblGarageLiabilityRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Total Insurable Values
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakeTotalInsurableValues" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Crime Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblCrimePremium" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Earthquake Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblEarthquakeRate" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Crime Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblCrimeRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%">Pollution Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPollutionPremium" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Cyber Premium
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblCyberPremium" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%" class="InnerContent">Pollution Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblPollutionRate" runat="server" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" class="InnerContent">Cyber Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblCyberRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%">&nbsp;
                            </td>
                            <td align="center" width="4%">&nbsp;
                            </td>
                            <td align="left" width="28%">&nbsp;
                            </td>
                        </tr>
                        <tr runat="server" id="tr1">
                            <td align="left" valign="top">
                                <b>Risk Management Service Grid</b>
                            </td>
                            <td align="center" valign="top">
                                <b>:</b>
                            </td>
                            <td align="left" valign="top" colspan="4">
                                <table width="100%">
                                    <tr id="tr2" runat="server">
                                        <td align="left">
                                            <asp:GridView ID="gvRiskManagementServiceGridView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                EmptyDataText="No Record Exists">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Service" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="35%" HorizontalAlign="center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lnkService" runat="server" Text='<%# Eval("Field_Description") %>'
                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PA_National_Allocation_Service_Grid") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Service Amount ($)" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="45%" HorizontalAlign="center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lnkServiceAmount" runat="server" Text='<%# clsGeneral.FormatCommaSeperatorCurrency(Eval("Service_Amount")) %>'
                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PA_National_Allocation_Service_Grid") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Risk Management Fee
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTotalRiskManagementFee" runat="server" Width="170px"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%"></td>
                            <td align="center" width="4%"></td>
                            <td align="left" width="28%"></td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Risk Management Rate
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTotalRiskManagementRate" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%"></td>
                            <td align="center" width="4%"></td>
                            <td align="left" width="28%"></td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Actual Cost
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTotalActualCost" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%"></td>
                            <td align="center" width="4%"></td>
                            <td align="left" width="28%"></td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Store Cost
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTotalStoreCost" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%"></td>
                            <td align="center" width="4%"></td>
                            <td align="left" width="28%"></td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">Total Surcharge Amount
                            </td>
                            <td align="center" width="4%">:
                            </td>
                            <td align="left" width="28%">$&nbsp;
                                <asp:Label ID="lblTotalSurchargeAmount" runat="server" Width="170px" />
                            </td>
                            <td align="left" width="18%"></td>
                            <td align="center" width="4%"></td>
                            <td align="left" width="28%"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnEdit" Text=" Edit " OnClick="btnEdit_Click"
                                    ToolTip="Edit" CausesValidation="true" ValidationGroup="vsError" />
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="Button2" Text="Back To Search" OnClick="btnBackToSearch_Click"
                                    ToolTip="Back To Search" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

