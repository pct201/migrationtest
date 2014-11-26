<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptFinancialPayTypeSummary.aspx.cs"
    Inherits="SONIC_ClaimInfo_rptFinancialPayTypeSummary" Title="eRIMS Sonic :: Financial Pay Type Summary Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="99%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Financial Pay Type Summary Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="40%" align="center">
                    <tr>
                        <td width="30%" align="left" valign="top">
                            Accident Year<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstAccidentYear" runat="server" SelectionMode="Multiple" ToolTip="Select Accident Year"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvAccidentYear" runat="server" ErrorMessage="Please Select Accident Year"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstAccidentYear"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Region<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Region"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstRegions" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Prior Valuation Date<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtValuationDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtValuationDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtValuationDate"
                                ErrorMessage="Please enter Prior Valuation Date" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="revDate" ControlToValidate="txtValuationDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Prior Valuation Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Show Report" OnClick="btnGenerateReport_Click"
                                ValidationGroup="vsErrorGroup" />&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="dvGrid" runat="server" style="display: none;">
                    <table cellpadding="0" cellspacing="0" width="95%" border="0">
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
                                            <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">                                
                                    <asp:GridView ID="gvReportOuter" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReportOuter_RowDataBound"
                                        DataKeyNames="AccidentYear" Width="100%" EnableTheming="false" HorizontalAlign="Left"
                                        CellPadding="4" GridLines="None" CssClass="GridClass" ShowFooter="true" EmptyDataText="No Record Found">
                                        <HeaderStyle CssClass="HeaderStyle" />
                                        <FooterStyle CssClass="FooterStyle" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="18px" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle HorizontalAlign="left" />
                                                <HeaderTemplate>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td width="100%">
                                                                                        <table width="100%" cellpadding="0" cellspacing="0" id="tblHeader" runat="server" style="font-weight: bold;">
                                                                                            <tr>
                                                                                                <td style="width: 20%">
                                                                                                    &nbsp;</td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    Indemnity/PD</td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    Medical/BI</td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    Expense</td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    Total
                                                                                                </td>
                                                                                                <td style="width: 16%;" align="center">
                                                                                                    Claim Count</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>          
                                                    </td>
                                                    </tr>
                                                    </table>                                          
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="100%" align="left">
                                                                <asp:Label ID="lblLossYear" runat="server" Text='<%# "Accident Year - " + Eval("AccidentYear")%>'
                                                                    Font-Bold="true" ForeColor="Chocolate">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="gvRegion" runat="server" AutoGenerateColumns="false" CellPadding="0"
                                                                    CssClass="GridClass" Width="100%" ShowHeader="False" HorizontalAlign="Left" EnableTheming="false"
                                                                    GridLines="None" ShowFooter="false" OnRowDataBound="gvRegion_RowDataBound" EmptyDataText="No Record Found">
                                                                    <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="100%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td class="Spacer" style="height: 5px;">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="100%" align="left">
                                                                                            <b>Region - <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region") %>'></asp:Label></b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Spacer" style="height: 3px;">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="Left">
                                                                                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="AccidentYear"
                                                                                                CellPadding="4" CssClass="GridClass" Width="100%" ShowHeader="False" HorizontalAlign="Left"
                                                                                                EnableTheming="false" GridLines="None" ShowFooter="true" OnRowDataBound="gvDetail_RowDataBound"
                                                                                                EmptyDataText="No Record Found">
                                                                                                <RowStyle CssClass="RowStyle" />
                                                                                                <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                                                                <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0" id="tblDetails" runat="server">
                                                                                                                <tr>
                                                                                                                    <td align="left" colspan="6">
                                                                                                                        <b>
                                                                                                                            <%# Eval("ClaimType")%>
                                                                                                                        </b>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 20%" align="left">
                                                                                                                        Incurred</td>
                                                                                                                    <td style="width: 16%" align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Indemnity_Incurred"))%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%" align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Medical_Incurred"))%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%" align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Expense_Incurred"))%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%" align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Total_Incurred"))%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%" valign="middle" align="center">
                                                                                                                        <%# String.Format("{0:0}", Eval("ClaimCount"))%>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        Paid</td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Indemnity_Paid"))%>
                                                                                                                    </td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Medical_Paid"))%>
                                                                                                                    </td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Expense_Paid"))%>
                                                                                                                    </td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Total_Paid"))%>
                                                                                                                    </td>
                                                                                                                    <td>&nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        Outstanding</td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Indemnity_Outstanding"))%>
                                                                                                                    </td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Medical_Outstanding"))%>
                                                                                                                    </td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Expense_Outstanding"))%>
                                                                                                                    </td>
                                                                                                                    <td align="right">
                                                                                                                        <%# String.Format("{0:C2}", Eval("Total_Outstanding"))%>
                                                                                                                    </td>
                                                                                                                    <td>&nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="tblFooter" runat="server">
                                                                                                                <tr>
                                                                                                                    <td align="left" colspan="6">
                                                                                                                        <b>Sub Total</b></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 20%;" align="left">
                                                                                                                        <b>Incurred</b></td>
                                                                                                                    <td style="width: 16%;" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalIncurredClaim" Font-Bold="true" Text="" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%;" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalIncurredMedical" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%;" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalIncurredExpenses" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="width: 16%;" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalofIncurred" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td valign="middle" align="center">
                                                                                                                        <asp:Label runat="server" ID="lblSubTotalClaimCount" Font-Bold="true" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="" align="left">
                                                                                                                        <b>Paid</b></td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalPaidClaim" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalPaidMedical" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalPaidExpenses" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalofPaid" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td>&nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="" align="left">
                                                                                                                        <b>Outstanding</b></td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalOutStandingClaim" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalOutStandingMedical" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalOutStandingExpenses" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="" align="right">
                                                                                                                        <asp:Label ID="lblSubTotalofOutStanding" Font-Bold="true" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td>&nbsp;
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
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <FooterStyle Wrap="true" />
                                                <FooterTemplate>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td width="100%">
                                                                                        <table width="100%" cellpadding="0" cellspacing="0" style="font-weight: bold; background-color: #507CD1;
                                                                                            color: White;" id="tblFooter" runat="server">
                                                                                            <tr>
                                                                                                <td align="left" colspan="6">
                                                                                                    <b>* Report Grand Total</b></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 20%;" align="left">
                                                                                                    <b>Incurred</b></td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalIncurredClaim" Text="" runat="server" />
                                                                                                </td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalIncurredMedical" runat="server" />
                                                                                                </td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalIncurredExpenses" runat="server" />
                                                                                                </td>
                                                                                                <td style="width: 16%;" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalofIncurred" runat="server" />
                                                                                                </td>
                                                                                                <td valign="middle" align="center">
                                                                                                    <asp:Label runat="server" ID="lblGrandClaimCount" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="" align="left">
                                                                                                    <b>Paid</b></td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalPaidClaim" runat="server" />
                                                                                                </td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalPaidMedical" runat="server" />
                                                                                                </td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalPaidExpenses" runat="server" />
                                                                                                </td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalofPaid" runat="server" />
                                                                                                </td>
                                                                                                <td>&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="" align="left">
                                                                                                    <b>Outstanding</b></td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalOutStandingClaim" runat="server" />
                                                                                                </td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalOutStandingMedical" runat="server" />
                                                                                                </td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalOutStandingExpenses" runat="server" />
                                                                                                </td>
                                                                                                <td style="" align="right">
                                                                                                    <asp:Label ID="lblGrandTotalofOutStanding" runat="server" />
                                                                                                </td>
                                                                                                <td>&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                </div>
            </td>
        </tr>
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
