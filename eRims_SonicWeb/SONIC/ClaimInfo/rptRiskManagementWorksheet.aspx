<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptRiskManagementWorksheet.aspx.cs" Inherits="SONIC_ClaimInfo_rptRiskManagementWorksheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:validationsummary id="valSummary" runat="server" showmessagebox="true" showsummary="false"
        validationgroup="vsErrorGroup" />
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <table width="100%" cellpadding="1" cellspacing="0" border="0">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td align="left" class="ghc">Risk Management Worksheet
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table width="85%" border="0" cellpadding="3" cellspacing="2">
                    <tr>
                        <td align="left" valign="top">Region
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:listbox id="lstRegions" runat="server" selectionmode="Multiple" tooltip="Select Region"
                                autopostback="false" width="250px"></asp:listbox>
                        </td>
                        <td align="center" valign="top">&nbsp;
                        </td>
                        <td align="left" valign="top">DBA
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:listbox id="lstDBAs" runat="server" selectionmode="Multiple" tooltip="Select DBA"
                                autopostback="false" width="250px"></asp:listbox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Market
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:listbox id="lstMarket" runat="server" selectionmode="Multiple" tooltip="Select Market"
                                autopostback="false" width="250px"></asp:listbox>
                        </td>
                        <td align="center" valign="top">&nbsp;
                        </td>
                        <td align="left" valign="top">&nbsp;
                        </td>
                        <td align="center" valign="top">&nbsp; 
                        </td>
                        <td align="left">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" width="15%">Dates of Incident From
                        </td>
                        <td align="left" valign="top" width="2%">:
                        </td>
                        <td align="left" width="30%">
                            <asp:textbox runat="server" id="txtLossFromDate" width="140px" skinid="txtDate"></asp:textbox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <%-- <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtLossFromDate"
                                ErrorMessage="Please enter Loss Date From" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />--%>
                            <asp:rangevalidator id="revDateFrom" controltovalidate="txtLossFromDate" minimumvalue="01/01/1753"
                                maximumvalue="12/31/9999" type="Date" errormessage="Loss Date From is not valid."
                                runat="server" setfocusonerror="true" validationgroup="vsErrorGroup" display="none" />
                        </td>
                        <td align="center" valign="top" width="4%">&nbsp;
                        </td>
                        <td valign="top" align="left" width="14%">To
                        </td>
                        <td align="left" valign="top" width="2%">:
                        </td>
                        <td align="left" width="33%">
                            <asp:textbox runat="server" id="txtLossToDate" width="140px" skinid="txtDate"></asp:textbox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <%--   <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtLossToDate"
                                ErrorMessage="Please enter Loss Date To" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />--%>
                            <asp:rangevalidator id="revDateTo" controltovalidate="txtLossToDate" minimumvalue="01/01/1753"
                                maximumvalue="12/31/9999" type="Date" errormessage="Loss Date To is not valid."
                                runat="server" setfocusonerror="true" validationgroup="vsErrorGroup" display="none" />
                            <asp:comparevalidator id="cvDate" runat="server" type="Date" controltovalidate="txtLossToDate"
                                controltocompare="txtLossFromDate" operator="GreaterThanEqual" errormessage="End Date must be greater than Start Date"
                                display="None" setfocusonerror="true" validationgroup="vsErrorGroup" />
                        </td>
                        <td align="left"></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Part of Body
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:listbox id="lstPartofBody" runat="server" selectionmode="Multiple" tooltip="Select Part of Body"
                                autopostback="false" width="250px"></asp:listbox>
                        </td>
                        <td align="center" valign="top">&nbsp;
                        </td>
                        <td align="left" valign="top">Claim Status
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:listbox id="lstClaimStatus" runat="server" selectionmode="Multiple" tooltip="Select Claim Status"
                                autopostback="false" width="250px"></asp:listbox>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 10px;" colspan="7"></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7" valign="top">
                            <asp:button runat="server" id="btnShowReport" text="Show Report" onclick="btnShowReport_Click"
                                causesvalidation="true" validationgroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:button id="btnClearCriteria" runat="server" text="Clear Criteria" tooltip="Clear All"
                                onclick="btnClearCriteria_Click" causesvalidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 10px;" colspan="7"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trReport" visible="false">
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right" style="height: 30px">
                            <asp:linkbutton id="lbtExportToExcel" runat="server" text="Export To Excel" onclick="lbtExportToExcel_Click"></asp:linkbutton>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2"></td>
                    </tr>
                    <tr >
                        <td>
                            <div id="dvGrid" runat="server" style="width: 996px; overflow-x: scroll; overflow-y: hidden">
                                <asp:gridview id="gvReport" runat="server" autogeneratecolumns="false" cellpadding="5"
                                    cellspacing="0" width="1900px" gridlines="None" showfooter="false" emptydatatext="No Record Found !">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%" >
                                                    <tr >
                                                        <td width="100px">Region
                                                        </td>
                                                        <td width="95px">D/B/A
                                                        </td>
                                                        <td width="125px">Associate Name
                                                        </td>
                                                        <td width="95px">Claim Number
                                                        </td>
                                                        <td width="95px">Date of Incident
                                                        </td>
                                                        <td width="155px">Part of Body
                                                        </td>
                                                        <td width="100px">Claim Status
                                                        </td>
                                                        <td width="265px" align="center" >
                                                            <table>
                                                                <tr>
                                                                    <td colspan="5" align="center">Reserves and Payments
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="60px">Resignation
                                                        </td>
                                                        <td width="120px">Settlement Amount
                                                        </td>
                                                        <td width="100px">Who Approved
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr >
                                                        <td width="100px">
                                                            <%#Eval("Region")%>
                                                        </td>
                                                        <td width="100px">
                                                            <%#Eval("DBA")%>
                                                        </td>
                                                        <td width="130px">
                                                            <%#Eval("Employee_Name")%>
                                                        </td>
                                                        <td width="100px">
                                                            <%#Eval("Origin_Claim_Number")%>
                                                        </td>
                                                        <td width="100px">
                                                            <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Accident"))%>
                                                        </td>
                                                        <td width="160px">
                                                            <%#Eval("Part_of_Body")%>
                                                        </td>
                                                        <td width="90px">
                                                            <%#Eval("Claim_Status")%>
                                                        </td>
                                                        <td width="260px">
                                                            <table width="100%" cellpadding="3" cellspacing="2">
                                                                <tr >
                                                                    <td width="16%" align="left">&nbsp;
                                                                    </td>
                                                                    <td width="21%" align="right">
                                                                        <b>Indemnity $</b>
                                                                    </td>
                                                                    <td width="21%" align="right">
                                                                        <b>Medical $</b>
                                                                    </td>
                                                                    <td width="21%" align="right">
                                                                        <b>Expenses $</b>
                                                                    </td>
                                                                    <td width="21%" align="right">
                                                                        <b>Total $</b>
                                                                    </td>
                                                                </tr>
                                                                <tr >
                                                                    <td align="left">
                                                                        <b>Reserve</b>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Reserve_Indemnity"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Resrve_Medical"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Reserve_Expense"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Reserve_Total"))%>
                                                                    </td>
                                                                </tr>
                                                                <tr >
                                                                    <td align="left">
                                                                        <b>Paid</b>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Paid_Indemnity"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Paid_Medical"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Paid_Expense"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Paid_Total"))%>
                                                                    </td>
                                                                </tr>
                                                                <tr >
                                                                    <td align="left">
                                                                        <b>Outstanding</b>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Out_Indemnity"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Out_Medical"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Out_Expense"))%>
                                                                    </td>
                                                                    <td align="right">
                                                                        <%#clsGeneral.GetStringValue(Eval("Out_Total"))%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="60px" >
                                                            <%#Eval("Resignation")%>
                                                        </td>
                                                        <td width="120px" >
                                                            <%#clsGeneral.GetStringValue( Eval("Settled_Amount"))%>&nbsp;&nbsp;
                                                        </td>
                                                        <td width="100px">
                                                            <%#Eval("Who_Approved")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:gridview>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
    </table>
</asp:Content>
