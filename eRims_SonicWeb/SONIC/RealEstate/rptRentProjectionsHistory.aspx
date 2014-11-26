<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptRentProjectionsHistory.aspx.cs"
    Inherits="SONIC_RealEstate_rptRentProjectionsHistory" Title="eRIMS Sonic :: Rent Projections/History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1"></asp:ValidationSummary>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="ghc">
                Rent Projections/History
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="77%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                    border="0">
                    <tr valign="top" align="left">
                        <td>
                            <asp:Label ID="lblRegion" runat="server" Text="Location"></asp:Label>
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td colspan="3">
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="100%">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Lease Type
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td colspan="3">
                            <asp:ListBox ID="ddlLeaseType" runat="server" Rows="4" SelectionMode="Multiple" Width="100%">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Escalation Type
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="lstEscalationType" runat="server" Rows="2" Width="100%" SelectionMode="Multiple">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td style="width: 12%;">
                            Rent Year From
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 30%;">
                            <asp:TextBox ID="txtRentYearFrom" runat="server" SkinID="txtYearWithRange" MaxLength="4"></asp:TextBox>
                            <asp:RangeValidator ID="rgvtxtRentYearFrom" runat="server" ErrorMessage="Rent year From is Not Valid Year"
                                Type="Integer" MaximumValue="9999" MinimumValue="1" Display="None" ControlToValidate="txtRentYearFrom"
                                SetFocusOnError="true"></asp:RangeValidator>
                        </td>
                        <td style="width: 7%;">
                            &nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 45%;">
                            <asp:TextBox ID="txtRentYearTo" runat="server" SkinID="txtYearWithRange" MaxLength="4"></asp:TextBox>
                            <asp:RangeValidator ID="rgvtxtRentYearTo" runat="server" ErrorMessage="Rent year From is Not Valid Year"
                                Type="Integer" MaximumValue="9999" MinimumValue="1" Display="None" ControlToValidate="txtRentYearTo"
                                SetFocusOnError="true"></asp:RangeValidator>
                            <asp:CompareValidator ID="cpvtxtRentYearTo" ControlToCompare="txtRentYearFrom" ControlToValidate="txtRentYearTo"
                                Display="None" runat="server" ErrorMessage="Rent Year From must be Less Than Or Equal To Rent year To."
                                Type="Integer" SetFocusOnError="true" Operator="GreaterThanEqual"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table width="77%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" Text="Show Report" CausesValidation="true"
                                OnClick="btnShowReport_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear Criteria" CausesValidation="false"
                                OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvGrid" runat="server" visible="false">
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" Width="100%"
                                    CellPadding="4" CellSpacing="0" EmptyDataText="No Record Found !" OnRowCreated="gvReport_RowCreated"
                                    EnableTheming="false" GridLines="None">
                                    <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="left" CssClass="HeaderStyle" />
                                    <RowStyle CssClass="RowStyle" VerticalAlign="Top" />
                                    <AlternatingRowStyle CssClass="AlterStyle" />
                                    <FooterStyle HorizontalAlign="Right" Font-Bold="true" CssClass="FooterStyle" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Location" ItemStyle-VerticalAlign="Top" ItemStyle-Width="">
                                            <ItemTemplate>
                                                <%# Eval("DBA") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year" ItemStyle-VerticalAlign="Top" ItemStyle-Width="">
                                            <ItemTemplate>
                                                <%# Eval("Year") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From" ItemStyle-VerticalAlign="Top" ItemStyle-Width="">
                                            <ItemTemplate>
                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To" ItemStyle-VerticalAlign="Top" ItemStyle-Width="">
                                            <ItemTemplate>
                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. of Month" ItemStyle-VerticalAlign="Top" ItemStyle-Width=""
                                            ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <%# string.Format("{0:N2}", Eval("Months"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Annual Rent" ItemStyle-VerticalAlign="Top" ItemStyle-Width=""
                                            ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <%# string.Format("{0:C2}", Eval("Monthly_Rent"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CPI Rate" ItemStyle-VerticalAlign="Top" ItemStyle-Width=""
                                            ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <%# string.Format("{0:N2}", Eval("Percentage_Rate"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Rent" ItemStyle-VerticalAlign="Top" ItemStyle-Width=""
                                            ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <%# string.Format("{0:C2}", Eval("Total_Rent"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Records found!
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
