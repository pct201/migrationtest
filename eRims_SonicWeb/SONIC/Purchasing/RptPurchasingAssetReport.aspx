<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptPurchasingAssetReport.aspx.cs"
    Inherits="SONIC_Purchasing_RptPurchasingAssetReport" Title="eRIMS Sonic :: Asset Detail Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="vsErrSum" ValidationGroup="vsError" runat="server" ShowMessageBox="true"
        ShowSummary="false" HeaderText="Verify the following fields" BorderWidth="1"
        BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="ghc">
                &nbsp;&nbsp;Asset Detail
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="3" cellspacing="0" width="50%" align="center">
                    <tr>
                        <td align="left" valign="top">
                            Region
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstRegion" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="28%" align="left" valign="top">
                            Location
                        </td>
                        <td width="4%" align="center" valign="top">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" ToolTip="Select Location"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="28%" align="left" valign="top">
                            Type
                        </td>
                        <td width="4%" align="center" valign="top">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="lstType" runat="server" SelectionMode="Multiple" ToolTip="Select Type"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="28%" align="left" valign="top">
                            Manufacturer
                        </td>
                        <td width="4%" align="center" valign="top">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="lstManufacturer" runat="server" SelectionMode="Multiple" ToolTip="Select Manufacturer"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" CausesValidation="true"
                                ValidationGroup="vsError" OnClick="btnGenerateReport_Click" />
                            &nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="lnkExport" runat="server" Text="Export To Excel" Visible="false"
                                OnClick="lnkExport_Click" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="display: none; text-align: left;" id="divReport_Grid" runat="server">
                                <asp:GridView ID="gvReport" runat="server" Width="2100px" EmptyDataText="No Records Found"
                                    OnRowCreated="gvReport_RowCreated" EnableTheming="false" GridLines="None" ShowFooter="true"
                                    AutoGenerateColumns="false" OnRowDataBound="gvReport_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" VerticalAlign="top" />
                                    <RowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="top" />
                                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="true" HorizontalAlign="left" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="top" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table cellpadding="0" cellspacing="0" width="2100px">
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="4" cellspacing="0" width="2100px" style="font-weight: bold;"
                                                                id="tblHeader" runat="server">
                                                                <tr>
                                                                    <td style="width: 150px;">
                                                                        Type
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Region
                                                                    </td>                                                                    
                                                                    <td style="width: 150px;">
                                                                        Manufacturer
                                                                    </td>                                                                    
                                                                    <td style="width: 150px;">
                                                                        Location
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Dealership Department
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Serial Number
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Model Number
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Acquisition Date
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                        Acquisition Cost
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Amortization Months Remaining
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Service Supplier
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        Lease/Rental Supplier
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="2100px" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvAssetData" runat="server" ShowHeader="false" Width="2100px" OnRowDataBound="gvAssetData_RowDataBound"
                                                                CellPadding="4" GridLines="None" CssClass="GridClass" AutoGenerateColumns="false"
                                                                EnableTheming="false" HorizontalAlign="Left" ShowFooter="true">
                                                                <FooterStyle BackColor="white" ForeColor="Black" Font-Bold="true" HorizontalAlign="left" />
                                                                <RowStyle HorizontalAlign="Left" CssClass="RowStyle" VerticalAlign="top" />
                                                                <AlternatingRowStyle HorizontalAlign="left" CssClass="AlterRowStyle" VerticalAlign="top" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Type")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Totals For Region :
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Region")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotal" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>                                                                    
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Manufacturer")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>                                                                    
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Location")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Dealership_Department")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Serial_Number")%></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Model_Number")%></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Acquisition_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Acquisition_Date"))) : ""%></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <%# string.Format("{0:C2}", Eval("Acquisition_Cost") )%></ItemTemplate>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblAcquisition_Cost" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("AmortizationMonthsRemaining")%></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <FooterStyle Width="150px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("SCSupplier")%></ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotalExposure" runat="server" Width="150px" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("LRSupplier")%></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" width="2100px">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <table cellpadding="4" cellspacing="0" width="2100px" style="font-weight: bold; color: White;"
                                                                id="tblFooter" runat="server">
                                                                <tr>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="lblH1" runat="server" Text='Grand Total' />
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="lblFTotal" runat="server" />
                                                                    </td>                                                                   
                                                                    <td style="width: 150px;" align="left">
                                                                    </td>
                                                                    <td style="width: 150px;" >
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                    </td>                                                                   
                                                                    <td style="width: 150px;">
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                        <asp:Label ID="lblAcquisitionCost" runat="server" /></td>
                                                                    <td style="width: 150px;">
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                    </td>
                                                                    <td style="width: 150px;">
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
    </table>
</asp:Content>
