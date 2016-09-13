<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCAllocationMonthlyDetailReport.aspx.cs"
    Inherits="SONIC_FirstReport_WCAllocationMonthlyDetailReport" Title="eRIMS Sonic :: WC Allocation Monthly Detail Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="bandHeaderRow" align="left">WC Allocation Monthly Detail Report
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" width="100%">
                <table cellpadding="3" cellspacing="1" border="0" style="text-align: right; width: 70%;">
                    <tr>
                        <td align="left" style="width: 11%">Year<span style="color: Red;">*</span></td>
                        <td align="center" style="width: 4%">:</td>
                        <td align="left" style="width: 35%">
                            <asp:DropDownList runat="Server" ID="ddlYear" SkinID="ddlExposure">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="ddlYear" Display="None"
                                runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year."></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 11%">Month<span style="color: Red;">*</span></td>
                        <td align="center" style="width: 4%">:</td>
                        <td align="left" style="width: 35%">
                            <asp:DropDownList runat="Server" ID="ddlMonth" SkinID="ddlExposure">
                                <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                <asp:ListItem Value="12" Text="December"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMonth" ControlToValidate="ddlMonth" Display="None"
                                runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Month."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 11%">Run report by
                        </td>
                        <td align="center" style="width: 4%">:</td>
                        <td align="left" style="width: 35%">
                            <asp:RadioButtonList ID="rdoRunBy" runat="server">
                                <asp:ListItem Text="Region" Value="Region" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Market" Value="Market"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                ValidationGroup="vsErrorGroup" CausesValidation="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-bottom: 5px;">
                <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click"
                    Text="Export To Excel" CausesValidation="false" Visible="false"></asp:LinkButton>
            </td>
        </tr>
        <tr id="trRegionReport" runat="server" visible="false">
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
                    <tr>
                        <td>
                            <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden; text-align: left; width: 997px;">
                                <asp:GridView ID="gvRegion" EnableTheming="false" DataKeyNames="ReportLabel" OnRowCreated="gvReport_RowCreated"
                                    runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReport_RowDataBound"
                                    Width="100%" HorizontalAlign="Left" GridLines="None" ShowFooter="true" EmptyDataText="No Record Found !">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                    <RowStyle BackColor="White" HorizontalAlign="Left" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                                    <FooterStyle CssClass="FooterStyle" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                                                                id="tblHeader" runat="server">
                                                                <tr valign="top">
                                                                    <td align="left" style="width: 150px;">Location</td>
                                                                    <td align="left" style="width: 100px;">Location Number</td>
                                                                    <td align="left" style="width: 120px;">First Report Number</td>
                                                                    <td align="left" style="width: 120px;">Claim Number</td>
                                                                    <td align="left" style="width: 120px;">Employee</td>
                                                                    <td align="left" style="width: 120px;">Cause of Incident</td>
                                                                    <td align="left" style="width: 100px;">Date of Incident</td>
                                                                    <td align="right" style="width: 100px;">Claim Charge</td>
                                                                    <td align="left" style="width: 130px;">&nbsp;Date Reported to SRS</td>
                                                                    <td align="right" style="width: 70px;">Report Lag</td>
                                                                    <td align="right" style="width: 100px;">Report Lag Credit</td>
                                                                    <td align="right" style="width: 110px;">Report Lag Charge</td>
                                                                    <td align="right" style="width: 110px;">Nurse Triage Credit</td>
                                                                    <td align="right" style="width: 150px;">Incident Investigation Credit</td>
                                                                    <td align="left" style="width: 110px;">&nbsp;Claim Closed Date
                                                                    </td>
                                                                    <td align="right" style="width: 110px;">Claim Closed Credit</td>
                                                                    <td align="left" style="width: 130px;">Claim Reopened Date
                                                                    </td>
                                                                    <td align="right" style="width: 140px;">Claim Reopened Charge</td>
                                                                    <td align="right" style="width: 100px;">Total Charge</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="left" style="background-color: White; height: 25px; color: Black;">
                                                            <b><%= ReportLabel %> :
                                                                <asp:Label ID="lblDescription" runat="server"><%#Eval("ReportLabel")%></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                EmptyDataText="No Record found !" GridLines="None" EnableTheming="false" CssClass="GridClass"
                                                                CellPadding="4" CellSpacing="0" ShowHeader="false" ShowFooter="true">
                                                                <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                                <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top" />
                                                                <FooterStyle Font-Bold="true" VerticalAlign="top" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Location">
                                                                        <FooterStyle Width="150px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("dba")%>' Width="150px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Totals
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Location Number">
                                                                        <FooterStyle Width="100px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="100px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSonic_Location_Code" runat="server" Text='<%# Eval("Sonic_Location_Code").ToString() %>'
                                                                                Width="100px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="First Report Number">
                                                                        <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFirstReportNum" runat="server" Text='<%# "WC-" + Eval("WC_FR_Number").ToString() %>'
                                                                                Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Number">
                                                                        <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOrigin_Claim_Number" runat="server" Text='<%# Eval("Origin_Claim_Number").ToString() %>'
                                                                                Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Employee">
                                                                        <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmployee_Name" runat="server" Text='<%# Eval("Employee_Name")%>'
                                                                                Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cause of Incident">
                                                                        <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSonic_Cause_Code" runat="server" Text='<%# Eval("Sonic_Cause_Code")%>'
                                                                                Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Incident">
                                                                        <FooterStyle Width="100px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="100px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDateofIncident" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Incident"))%>'
                                                                                Width="100px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Charge">
                                                                        <FooterStyle Width="100px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="100px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Initial_Charge"))%>'
                                                                                Width="100px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Reported to Sonic">
                                                                        <FooterStyle Width="130px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="130px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblDateReportedtoSonic" runat="server" Width="130px" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Reported_To_SRS"))%>'></asp:Label>
                                                                            <%-- <asp:Label ID="lblDateReportedtoSonic" runat="server" Width="80px" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Initial_Charge_Date"))%>'></asp:Label>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Lag">
                                                                        <FooterStyle Width="70px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="70px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReportlag" runat="server" Text='<%# Eval("Report_Lag")%>' Width="70px"></asp:Label>&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Lag Credit">
                                                                        <FooterStyle Width="100px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="100px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Late_Penalty_Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Lag_Credit"))%>'
                                                                                Width="100px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Performance Credit">
                                                                        <FooterStyle Width="110px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="110px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Early_Reporting_Performance_Credit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Lag_Charge"))%>'
                                                                                Width="110px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Nurse Triage Credit">
                                                                        <FooterStyle Width="110px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="110px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Nurse_Triage_Credit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Nurse_Triage_Credit"))%>'
                                                                                Width="110px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Incident Investigation Credit">
                                                                        <FooterStyle Width="150px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="150px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Incident_Investigation_Credit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Incident_Investigation_Credit"))%>'
                                                                                Width="150px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Closed Date">
                                                                        <FooterStyle Width="110px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="110px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            &nbsp;<asp:Label ID="lblClosed_Date" runat="server" Width="110px" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Early_Close_Credit_Date"))%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Closed Credit">
                                                                        <HeaderStyle HorizontalAlign="right" />
                                                                        <FooterStyle Width="110px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="110px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClaimClosedCredit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Early_Close_Credit"))%>'
                                                                                Width="110px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Closed Date">
                                                                        <FooterStyle Width="130px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="130px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReopen_Charge_Date" runat="server" Width="130px" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Reopen_Charge_Date"))%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Closed Credit">
                                                                        <HeaderStyle HorizontalAlign="right" />
                                                                        <FooterStyle Width="140px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="140px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReopen_Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Reopen_Charge"))%>'
                                                                                Width="140px"></asp:Label>&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Charge">
                                                                        <HeaderStyle HorizontalAlign="right" />
                                                                        <FooterStyle Width="100px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                            Wrap="true" />
                                                                        <ItemStyle Width="100px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Total_Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Total_Charge"))%>'
                                                                                Width="100px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    Currently there is No record found.
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold; background-color: #507CD1; color: White;"
                                                                id="tblFooter" runat="server">
                                                                <tr valign="top">
                                                                    <td align="left" style="width: 150px;">Report Grand Total</td>
                                                                    <td align="left" style="width: 100px;">&nbsp;</td>
                                                                    <td align="left" style="width: 120px;">&nbsp;</td>
                                                                    <td align="left" style="width: 120px;">&nbsp;</td>
                                                                    <td align="left" style="width: 120px;">&nbsp;</td>
                                                                    <td align="left" style="width: 120px;">&nbsp;</td>
                                                                    <td align="left" style="width: 100px;">&nbsp;</td>
                                                                    <td align="right" style="width: 100px;">
                                                                        <asp:Label ID="lblClaimCharge" runat="server" Width="90px" />
                                                                    </td>
                                                                    <td align="left" style="width: 130px;">&nbsp;
                                                                    </td>
                                                                    <td align="right" style="width: 70px;">
                                                                        <asp:Label ID="lblReportLag" runat="server" Width="60px" /></td>
                                                                    <td align="right" style="width: 100px;">
                                                                        <asp:Label ID="lblPerformanceCredit" runat="server" Width="90px" /></td>
                                                                    <td align="right" style="width: 110px;">
                                                                        <asp:Label ID="lblPenaltyCharge" runat="server" Width="100px" /></td>
                                                                    <td align="right" style="width: 110px;">
                                                                        <asp:Label ID="lblNurseTriageCredit" runat="server" Width="100px" /></td>
                                                                    <td align="right" style="width: 150px;">
                                                                        <asp:Label ID="lblIncidentInvestigationCredit" runat="server" Width="140px" /></td>
                                                                    <td align="left" style="width: 110px;">&nbsp;
                                                                    </td>
                                                                    <td align="right" style="width: 110px;">
                                                                        <asp:Label ID="lblClosedCredit" runat="server" Width="100px" /></td>
                                                                    <td align="left" style="width: 130px;">&nbsp;
                                                                    </td>
                                                                    <td align="right" style="width: 140px;">
                                                                        <asp:Label ID="lblReopenedCharge" runat="server" Width="130px" /></td>
                                                                    <td align="right" style="width: 100px;">
                                                                        <asp:Label ID="lblTotalCharge" runat="server" Width="90px" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trMarketReport" runat="server" visible="false">
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
                    <tr>
                        <td>
                            <div runat="server" id="Div1" style="overflow-x: hidden; overflow-y: hidden; text-align: left; width: 997px;">
                                <asp:GridView ID="gvMarketReport" EnableTheming="false" DataKeyNames="Region" OnRowCreated="gvMarketReport_RowCreated"
                                    runat="server" AutoGenerateColumns="false" OnRowDataBound="gvMarketReport_RowDataBound"
                                    Width="100%" HorizontalAlign="Left" GridLines="None" ShowFooter="true" EmptyDataText="No Record Found !">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                    <RowStyle BackColor="White" HorizontalAlign="Left" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                                    <FooterStyle CssClass="FooterStyle" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>

                                                                                    <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                                                                                        id="tblHeader" runat="server">
                                                                                        <tr valign="top">
                                                                                            <td align="left" style="width: 150px;">Location</td>
                                                                                            <td align="left" style="width: 100px;">Location Number</td>
                                                                                            <td align="left" style="width: 120px;">First Report Number</td>
                                                                                            <td align="left" style="width: 120px;">Claim Number</td>
                                                                                            <td align="left" style="width: 120px;">Employee</td>
                                                                                            <td align="left" style="width: 120px;">Cause of Incident</td>
                                                                                            <td align="left" style="width: 100px;">Date of Incident</td>
                                                                                            <td align="right" style="width: 100px;">Claim Charge</td>
                                                                                            <td align="left" style="width: 130px;">&nbsp;Date Reported to SRS</td>
                                                                                            <td align="right" style="width: 70px;">Report Lag</td>
                                                                                            <td align="right" style="width: 100px;">Report Lag Credit</td>
                                                                                            <td align="right" style="width: 110px;">Report Lag Charge</td>
                                                                                            <td align="right" style="width: 110px;">Nurse Triage Credit</td>
                                                                                            <td align="right" style="width: 150px;">Incident Investigation Credit</td>
                                                                                            <td align="left" style="width: 110px;">&nbsp;Claim Closed Date
                                                                                            </td>
                                                                                            <td align="right" style="width: 110px;">Claim Closed Credit</td>
                                                                                            <td align="left" style="width: 130px;">Claim Reopened Date
                                                                                            </td>
                                                                                            <td align="right" style="width: 140px;">Claim Reopened Charge</td>
                                                                                            <td align="right" style="width: 100px;">Total Charge</td>
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
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="left" colspan="19" style="background-color: White; height: 25px; color: Black;border:thin">
                                                            <b>Region :
                                                                <asp:Label ID="lblDescription" runat="server"><%#Eval("Region")%></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvReport_Market" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                EmptyDataText="No Record found !" GridLines="None" EnableTheming="false" CssClass="GridClass"
                                                                CellPadding="4" CellSpacing="0" ShowHeader="false" ShowFooter="true" OnRowDataBound="gvReport_Market_RowDataBound">
                                                                <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                                <%--<RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top" />--%>
                                                                <FooterStyle Font-Bold="true" VerticalAlign="top" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td align="left" style="background-color: White; height: 25px; color: Black;">
                                                                                        <b>Market :
                                                                                            <asp:Label ID="lblMarketDescription" runat="server"><%#Eval("Market")%></asp:Label>
                                                                                        </b>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                            EmptyDataText="No Record found !" GridLines="None" EnableTheming="false" CssClass="GridClass"
                                                                                            CellPadding="4" CellSpacing="0" ShowHeader="false" ShowFooter="true">
                                                                                            <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                                                            <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                                            <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top" />
                                                                                            <FooterStyle Font-Bold="true" VerticalAlign="top" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Location">
                                                                                                    <FooterStyle Width="150px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("dba")%>' Width="150px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <FooterTemplate>
                                                                                                        Totals
                                                                                                    </FooterTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Location Number">
                                                                                                    <FooterStyle Width="100px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="100px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblSonic_Location_Code" runat="server" Text='<%# Eval("Sonic_Location_Code").ToString() %>'
                                                                                                            Width="100px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="First Report Number">
                                                                                                    <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblFirstReportNum" runat="server" Text='<%# "WC-" + Eval("WC_FR_Number").ToString() %>'
                                                                                                            Width="120px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Claim Number">
                                                                                                    <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblOrigin_Claim_Number" runat="server" Text='<%# Eval("Origin_Claim_Number").ToString() %>'
                                                                                                            Width="120px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Employee">
                                                                                                    <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblEmployee_Name" runat="server" Text='<%# Eval("Employee_Name")%>'
                                                                                                            Width="120px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Cause of Incident">
                                                                                                    <FooterStyle Width="120px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblSonic_Cause_Code" runat="server" Text='<%# Eval("Sonic_Cause_Code")%>'
                                                                                                            Width="120px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Date of Incident">
                                                                                                    <FooterStyle Width="100px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="100px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblDateofIncident" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Of_Incident")))%>'
                                                                                                            Width="100px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Claim Charge">
                                                                                                    <FooterStyle Width="100px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="100px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Initial_Charge"))%>'
                                                                                                            Width="100px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Date Reported to Sonic">
                                                                                                    <FooterStyle Width="130px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="130px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        &nbsp;&nbsp;<asp:Label ID="lblDateReportedtoSonic" runat="server" Width="130px" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Reported_To_SRS"))%>'></asp:Label>
                                                                                                        <%-- <asp:Label ID="lblDateReportedtoSonic" runat="server" Width="80px" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Initial_Charge_Date"))%>'></asp:Label>--%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Report Lag">
                                                                                                    <FooterStyle Width="70px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="70px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblReportlag" runat="server" Text='<%# Eval("Report_Lag")%>' Width="70px"></asp:Label>&nbsp;
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Report Lag Credit">
                                                                                                    <FooterStyle Width="100px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="100px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Late_Penalty_Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Lag_Credit"))%>'
                                                                                                            Width="100px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Performance Credit">
                                                                                                    <FooterStyle Width="110px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="110px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Early_Reporting_Performance_Credit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Lag_Charge"))%>'
                                                                                                            Width="110px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Nurse Triage Credit">
                                                                                                    <FooterStyle Width="110px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="110px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Nurse_Triage_Credit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Nurse_Triage_Credit"))%>'
                                                                                                            Width="110px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Incident Investigation Credit">
                                                                                                    <FooterStyle Width="150px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="150px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Incident_Investigation_Credit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Incident_Investigation_Credit"))%>'
                                                                                                            Width="150px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Closed Date">
                                                                                                    <FooterStyle Width="110px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="110px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        &nbsp;<asp:Label ID="lblClosed_Date" runat="server" Width="110px" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Early_Close_Credit_Date"))%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Claim Closed Credit">
                                                                                                    <HeaderStyle HorizontalAlign="right" />
                                                                                                    <FooterStyle Width="110px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="110px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblClaimClosedCredit" runat="server" Text='<%# String.Format("{0:C2}",Eval("Early_Close_Credit"))%>'
                                                                                                            Width="110px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Closed Date">
                                                                                                    <FooterStyle Width="130px" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="130px" HorizontalAlign="left" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblReopen_Charge_Date" runat="server" Width="130px" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Reopen_Charge_Date"))%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Claim Closed Credit">
                                                                                                    <HeaderStyle HorizontalAlign="right" />
                                                                                                    <FooterStyle Width="140px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="140px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblReopen_Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Reopen_Charge"))%>'
                                                                                                            Width="140px"></asp:Label>&nbsp;
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Total Charge">
                                                                                                    <HeaderStyle HorizontalAlign="right" />
                                                                                                    <FooterStyle Width="100px" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                                                        Wrap="true" />
                                                                                                    <ItemStyle Width="100px" HorizontalAlign="right" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Total_Charge" runat="server" Text='<%# String.Format("{0:C2}",Eval("Total_Charge"))%>'
                                                                                                            Width="100px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                                            <EmptyDataTemplate>
                                                                                                Currently there is No record found.
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table width="100%" cellpadding="2" cellspacing="0" border="0" style="font-weight: bold; background-color: #66CCFF; color: White;"
                                                                                            id="tblFooter" runat="server">
                                                                                            <tr valign="top">
                                                                                                <td align="left" style="width: 150px;">Region Total</td>
                                                                                                <td align="left" style="width: 100px;">&nbsp;</td>
                                                                                                <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                                <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                                <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                                <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                                <td align="left" style="width: 100px;">&nbsp;</td>
                                                                                                <td align="right" style="width: 100px;">
                                                                                                    <asp:Label ID="lblClaimCharge" runat="server" Width="90px" />
                                                                                                </td>
                                                                                                <td align="left" style="width: 130px;">&nbsp;
                                                                                                </td>
                                                                                                <td align="right" style="width: 70px;">
                                                                                                    <asp:Label ID="lblReportLag" runat="server" Width="60px" /></td>
                                                                                                <td align="right" style="width: 100px;">
                                                                                                    <asp:Label ID="lblPerformanceCredit" runat="server" Width="90px" /></td>
                                                                                                <td align="right" style="width: 110px;">
                                                                                                    <asp:Label ID="lblPenaltyCharge" runat="server" Width="100px" /></td>
                                                                                                <td align="right" style="width: 110px;">
                                                                                                    <asp:Label ID="lblNurseTriageCredit" runat="server" Width="100px" /></td>
                                                                                                <td align="right" style="width: 150px;">
                                                                                                    <asp:Label ID="lblIncidentInvestigationCredit" runat="server" Width="140px" /></td>
                                                                                                <td align="left" style="width: 110px;">&nbsp;
                                                                                                </td>
                                                                                                <td align="right" style="width: 110px;">
                                                                                                    <asp:Label ID="lblClosedCredit" runat="server" Width="100px" /></td>
                                                                                                <td align="left" style="width: 130px;">&nbsp;
                                                                                                </td>
                                                                                                <td align="right" style="width: 140px;">
                                                                                                    <asp:Label ID="lblReopenedCharge" runat="server" Width="130px" /></td>
                                                                                                <td align="right" style="width: 100px;">
                                                                                                    <asp:Label ID="lblTotalCharge" runat="server" Width="90px" /></td>
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
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" cellpadding="4" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold; background-color: #507CD1; color: White;"
                                                                                        id="tblFooter" runat="server">
                                                                                        <tr valign="top">
                                                                                            <td align="left" style="width: 150px;">Report Grand Total</td>
                                                                                            <td align="left" style="width: 100px;">&nbsp;</td>
                                                                                            <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                            <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                            <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                            <td align="left" style="width: 120px;">&nbsp;</td>
                                                                                            <td align="left" style="width: 100px;">&nbsp;</td>
                                                                                            <td align="right" style="width: 100px;">
                                                                                                <asp:Label ID="lblClaimCharge" runat="server" Width="90px" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 130px;">&nbsp;
                                                                                            </td>
                                                                                            <td align="right" style="width: 70px;">
                                                                                                <asp:Label ID="lblReportLag" runat="server" Width="60px" /></td>
                                                                                            <td align="right" style="width: 100px;">
                                                                                                <asp:Label ID="lblPerformanceCredit" runat="server" Width="90px" /></td>
                                                                                            <td align="right" style="width: 110px;">
                                                                                                <asp:Label ID="lblPenaltyCharge" runat="server" Width="100px" /></td>
                                                                                            <td align="right" style="width: 110px;">
                                                                                                <asp:Label ID="lblNurseTriageCredit" runat="server" Width="100px" /></td>
                                                                                            <td align="right" style="width: 150px;">
                                                                                                <asp:Label ID="lblIncidentInvestigationCredit" runat="server" Width="140px" /></td>
                                                                                            <td align="left" style="width: 110px;">&nbsp;
                                                                                            </td>
                                                                                            <td align="right" style="width: 110px;">
                                                                                                <asp:Label ID="lblClosedCredit" runat="server" Width="100px" /></td>
                                                                                            <td align="left" style="width: 130px;">&nbsp;
                                                                                            </td>
                                                                                            <td align="right" style="width: 140px;">
                                                                                                <asp:Label ID="lblReopenedCharge" runat="server" Width="130px" /></td>
                                                                                            <td align="right" style="width: 100px;">
                                                                                                <asp:Label ID="lblTotalCharge" runat="server" Width="90px" /></td>
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
                            </div>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
