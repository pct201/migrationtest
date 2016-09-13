<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCMonthlyAllocationSummaryReport.aspx.cs"
    Inherits="SONIC_FirstReport_WCMonthlyAllocationSummaryReport" Title="eRIMS Sonic :: Workers Comp Allocation YTD Charge Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="bandHeaderRow" colspan="4" align="left">
                WC Monthly Allocation Summary Report
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <table cellpadding="3" cellspacing="1" border="0" style="text-align: right; width: 100%;">
                    <tr>
                        <td align="right" style="width: 18%">
                            Year</td>
                        <td align="center" style="width: 4%">
                            :</td>
                        <td align="left" style="width: 28%">
                            <asp:DropDownList runat="Server" ID="ddlYear" SkinID="ddlExposure">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="ddlYear" Display="None"
                                runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 11%">Run report by
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
                    <tr>
                        <td colspan="6" align="right" style="padding-right: 10px;">
                            <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click"
                                Text="Export To Excel" CausesValidation="false" Visible="false"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trResult">
            <td colspan="4">
                <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden;
                    width: 995px;">
                    <asp:GridView ID="gvworkers_comp_summary" runat="server" AutoGenerateColumns="true"
                        CellPadding="4" CellSpacing="0" Width="100%" OnRowCreated="gvworkers_comp_summary_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="Location">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lbldba" runat="server" Text='<%#Eval("dba") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Code">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocationCode" runat="server" Text='<%#Eval("Sonic_Location_Code") %>' Width="95px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Region">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Region") %>' Width="95px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Market">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMarket" runat="server" Text='<%#Eval("Market") %>' Width="95px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JAN">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblJAN" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("JAN"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEB">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFEB" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("FEB"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAR">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMAR" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("MAR"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="APR">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAPR" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("APR"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAY">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMAY" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("MAY"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUN">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblJUN" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("JUN"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUL">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblJUL" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("JUL"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AUG">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAUG" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("AUG"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SEP">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSEP" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("SEP"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OCT">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOCT" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("OCT"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOV">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNOV" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("NOV"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEC">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDEC" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("DEC"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JAN">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNextJAN" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Next_JAN"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEB">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNextFEB" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Next_FEB"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAR">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNextMAR" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Next_MAR"))%>'
                                        Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Total"))%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            Currently there is No record found.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
