<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptRiskManagementWorksheet.aspx.cs" Inherits="SONIC_ClaimInfo_rptRiskManagementWorksheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vsErrorGroup" />
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
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="250px"></asp:ListBox>
                        </td>
                        <td align="center" valign="top">&nbsp;
                        </td>
                        <td align="left" valign="top">DBA
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstDBAs" runat="server" SelectionMode="Multiple" ToolTip="Select DBA"
                                AutoPostBack="false" Width="250px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Market
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                                AutoPostBack="false" Width="250px"></asp:ListBox>
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
                            <asp:TextBox runat="server" ID="txtLossFromDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <%-- <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtLossFromDate"
                                ErrorMessage="Please enter Loss Date From" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />--%>
                            <asp:RangeValidator ID="revDateFrom" ControlToValidate="txtLossFromDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date From is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                        <td align="center" valign="top" width="4%">&nbsp;
                        </td>
                        <td valign="top" align="left" width="14%">To
                        </td>
                        <td align="left" valign="top" width="2%">:
                        </td>
                        <td align="left" width="33%">
                            <asp:TextBox runat="server" ID="txtLossToDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <%--   <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtLossToDate"
                                ErrorMessage="Please enter Loss Date To" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />--%>
                            <asp:RangeValidator ID="revDateTo" ControlToValidate="txtLossToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date To is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvDate" runat="server" Type="Date" ControlToValidate="txtLossToDate"
                                ControlToCompare="txtLossFromDate" Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date"
                                Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                        <td align="left"></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Part of Body
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstPartofBody" runat="server" SelectionMode="Multiple" ToolTip="Select Part of Body"
                                AutoPostBack="false" Width="250px"></asp:ListBox>
                        </td>
                        <td align="center" valign="top">&nbsp;
                        </td>
                        <td align="left" valign="top">Claim Status
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstClaimStatus" runat="server" SelectionMode="Multiple" ToolTip="Select Claim Status"
                                AutoPostBack="false" Width="250px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 10px;" colspan="7"></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7" valign="top">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
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
                            <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2"></td>
                    </tr>
                    <tr style="border: thin">
                        <td>
                            <div id="dvGrid" runat="server" style="width: 996px; overflow-x: scroll; overflow-y: hidden">
                                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                    CellSpacing="0" Width="1900px" GridLines="None" ShowFooter="false" EmptyDataText="No Record Found !">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="border: thin">
                                                    <tr style="border: thin">
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
                                                        <td width="265px" align="center" style="border: thin">
                                                            <table style="border: thin">
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
                                                    <tr style="border: thin">
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
                                                            <table width="100%" cellpadding="3" cellspacing="2" border="0">
                                                                <tr style="border: thin">
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
                                                                <tr style="border: thin">
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
                                                                <tr style="border: thin">
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
                                                                <tr style="border: thin">
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
                                                        <td width="60px" style="border: thin">
                                                            <%#Eval("Resignation")%>
                                                        </td>
                                                        <td width="120px" style="border: thin">
                                                            <%#clsGeneral.GetStringValue( Eval("Settled_Amount"))%>&nbsp;&nbsp;
                                                        </td>
                                                        <td width="100px" style="border: thin">
                                                            <%#Eval("Who_Approved")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
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
