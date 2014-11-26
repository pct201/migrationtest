<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCAllocationDetailReport.aspx.cs" Inherits="SONIC_FirstReport_WCAllocationDetailReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td class="bandHeaderRow" colspan="4" align="left">WC Allocation Detail Report (First Report Only) 
    </td>
</tr>
<tr>
    <td colspan="4">&nbsp;</td>
</tr>
<tr>
    <td colspan="4" align="center">
        <table cellpadding="3" cellspacing="1" border="0" style="text-align: right;width:100%;">
        <tr>
            <td align="left" style="width:18%">Year<span style="color: Red;">*</span></td>
            <td align="center" style="width:4%">:</td>
            <td align="left" style="width:28%"><asp:DropDownList runat="Server" ID="ddlYear" SkinID="ddlExposure"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="ddlYear" Display="None" 
                    runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year."></asp:RequiredFieldValidator>
            </td>
            <td align="left" style="width:18%">Month<span style="color: Red;">*</span></td>
            <td align="center" style="width:4%">:</td>
            <td align="left" style="width:28%">
                <asp:DropDownList runat="Server" ID="ddlMonth" SkinID="ddlExposure">
                <asp:ListItem Value="0" Text = "-- Select --"></asp:ListItem>
                <asp:ListItem Value="1" Text = "January"></asp:ListItem>
                <asp:ListItem Value="2" Text = "February"></asp:ListItem>
                <asp:ListItem Value="3" Text = "March"></asp:ListItem>
                <asp:ListItem Value="4" Text = "April"></asp:ListItem>
                <asp:ListItem Value="5" Text = "May"></asp:ListItem>
                <asp:ListItem Value="6" Text = "June"></asp:ListItem>
                <asp:ListItem Value="7" Text = "July"></asp:ListItem>
                <asp:ListItem Value="8" Text = "August"></asp:ListItem>
                <asp:ListItem Value="9" Text = "September"></asp:ListItem>
                <asp:ListItem Value="10" Text = "October"></asp:ListItem>
                <asp:ListItem Value="11" Text = "November"></asp:ListItem>
                <asp:ListItem Value="12" Text = "December"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvMonth" ControlToValidate="ddlMonth" Display="None" 
                    runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Month."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
                        <td align="left" valign="top">
                            Region<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region" AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Region"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstRegions"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" ValidationGroup="vsErrorGroup" CausesValidation="true" />
            </td>
        </tr>
        <tr>
            <td colspan="6" align="right" style="padding-right:10px;">
                <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click" Text="Export To Excel" CausesValidation="false" Visible="false"></asp:LinkButton>
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr>
    <td colspan="4" align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
    <tr>
        <td>
            <div style="overflow:auto;text-align:left;">
             <asp:GridView ID="gvRegion" EnableTheming="false" DataKeyNames="Region" OnRowCreated="gvReport_RowCreated"
                        runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReport_RowDataBound"
                        Width="100%" HorizontalAlign="Left" GridLines="None" ShowFooter="true" EmptyDataText="No Record Found !">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle CssClass="FooterStyle" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px"/>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 12%">Location</td>
                                                        <td align="left" style="width: 10%">First Report Number</td>
                                                        <td align="left" style="width: 10%">Employee</td>
                                                        <td align="left" style="width: 12%">Cause of Incident</td>
                                                        <td align="left" style="width: 8%">Date of Incident</td>
                                                        <td align="left" style="width: 8%">Date Reported to Sonic</td>
                                                        <td align="right" style="width: 6%">Report<br />Lag</td>
                                                        <td align="right" style="width: 8%">Claim<br />Charge</td>
                                                        <td align="right" style="width: 8%">Penalty<br />Charge</td>
                                                        <td align="right" style="width: 10%">Performance<br />Credit</td>
                                                        <td align="right" style="width: 8%">Total<br />Charge</td>
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
                                                <b>
                                                    Region : <asp:Label ID="lblDescription" runat="server"><%#Eval("Region")%></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" 
                                                    EmptyDataText="No Record found !" GridLines="None" EnableTheming="false" CssClass="GridClass" 
                                                    CellPadding="4" ShowHeader="false" ShowFooter="true">
                                                    <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                    <RowStyle CssClass="RowStyle" VerticalAlign="top"/>
                                                    <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top"/>            
                                                    <FooterStyle Font-Bold="true" VerticalAlign="top"/>
                                                    <Columns>                
                                                        <asp:TemplateField HeaderText="Location"> 
                                                            <FooterStyle Width="12%" HorizontalAlign="Left" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="12%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("dba")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                Totals
                                                            </FooterTemplate>
                                                        </asp:TemplateField>                                                        
                                                        <asp:TemplateField HeaderText="First Report Number">
                                                            <FooterStyle Width="10%" HorizontalAlign="Left" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="10%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFirstReportNum" runat="server" Text='<%# "WC-" + Eval("WC_FR_Number").ToString() %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee">
                                                            <FooterStyle Width="10%" HorizontalAlign="Left" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="10%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmployee_Name" runat="server" Text='<%# Eval("Employee_Name")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cause of Incident">
                                                            <FooterStyle Width="12%" HorizontalAlign="Left" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="12%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSonic_Cause_Code" runat="server" Text='<%# Eval("Sonic_Cause_Code")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Incident">
                                                            <FooterStyle Width="8%" HorizontalAlign="Left" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateofIncident" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Of_Incident")))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Reported to Sonic">
                                                            <FooterStyle Width="8%" HorizontalAlign="Left" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateReportedtoSonic" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Reported_To_Sonic")))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Report Lag">
                                                            <FooterStyle Width="6%" HorizontalAlign="right" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="6%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReportlag" runat="server" Text='<%# Eval("Report_Lag")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Claim Charge">
                                                            <FooterStyle Width="8%" HorizontalAlign="right" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Charge" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("claimCharge"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Penalty Charge">
                                                            <FooterStyle Width="8%" HorizontalAlign="right" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Late_Penalty_Charge" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("PenaltyCharge"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Performance Credit">
                                                            <FooterStyle Width="10%" HorizontalAlign="right" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="10%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Early_Reporting_Performance_Credit" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("PerformanceCredit"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Charge">
                                                        <HeaderStyle HorizontalAlign="right" />
                                                            <FooterStyle Width="8%" HorizontalAlign="right" BackColor="white" ForeColor="black" Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Total_Charge" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("TotalCharge"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center"  />
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
                                            <td valign="middle">
                                                <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold; background-color: #507CD1;
                                                                                            color: White;" id="tblFooter" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 12%">Report Grand Total</td>
                                                        <td align="left" style="width: 10%">&nbsp;</td>
                                                        <td align="left" style="width: 10%">&nbsp;</td>
                                                        <td align="left" style="width: 12%">&nbsp;</td>
                                                        <td align="left" style="width: 8%">&nbsp;</td>
                                                        <td align="left" style="width: 8%">&nbsp;</td>
                                                        <td align="right" style="width: 6%"><asp:Label ID="lblReportLag" runat="server" /></td>
                                                        <td align="right" style="width: 8%"><asp:Label ID="lblClaimCharge" runat="server" /></td>
                                                        <td align="right" style="width: 8%"><asp:Label ID="lblPenaltyCharge" runat="server" /></td>
                                                        <td align="right" style="width: 10%"><asp:Label ID="lblPerformanceCredit" runat="server" /></td>
                                                        <td align="right" style="width: 8%"><asp:Label ID="lblTotalCharge" runat="server" /></td>
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
            <br /><br /><br />
        </td>
    </tr>
    </table>
    </td>
</tr>
</table>
</asp:Content>

