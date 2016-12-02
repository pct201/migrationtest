<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptAllocationYTDChargeReport.aspx.cs"
    Inherits="SONIC_FirstReport_RptAllocationYTDChargeReport" Title="eRIMS Sonic :: Workers Comp Allocation YTD Charge Report" %>

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
            <td align="left" class="ghc">Workers Comp Allocation YTD Charge Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td class="spacer" style="width: 15%"></td>
                        <td align="left">
                            <table width="80%" style="text-align: left;" cellpadding="2" cellspacing="3" border="0">
                                <tr valign="top" align="left">
                                    <td>Region
                                    </td>
                                    <td align="right">:
                                    </td>
                                    <td>
                                        <asp:ListBox ID="lstRegion" runat="server" Rows="4" SelectionMode="Multiple" Width="300px"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td>Market
                                    </td>
                                    <td align="right">:
                                    </td>
                                    <td>
                                        <asp:ListBox ID="lstMarket" runat="server" Rows="4" SelectionMode="Multiple" Width="300px"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td style="width: 10%;">Location
                                    </td>
                                    <td align="right" style="width: 5%;">:
                                    </td>
                                    <td style="width: 85%;">
                                        <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="300px"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td style="width: 15%;">Accident Year
                                    </td>
                                    <td align="right" style="width: 5%;">:
                                    </td>
                                    <td style="width: 80%;">
                                        <asp:ListBox ID="lstYear" runat="server" SelectionMode="Multiple" Width="300px"></asp:ListBox>
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
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
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
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvGrid" runat="server" visible="false">
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click">
                                </asp:LinkButton>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;"></td>
                        </tr>
                        <tr>
                            <td>
                                <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden; text-align: left; width: 997px;">
                                    <asp:GridView ID="gvReport" runat="server" Width="100%" OnRowDataBound="gvReport_RowDataBound"
                                        AutoGenerateColumns="false" EnableTheming="false" HorizontalAlign="Left" CellPadding="0"
                                        GridLines="None" ShowFooter="true" EmptyDataText="No Record Found" CssClass="gridclass">
                                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                                        <HeaderStyle CssClass="HeaderStyle" />
                                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                                        <FooterStyle CssClass="FooterStyle" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="20px" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="4" cellspacing="0" width="100%" id="tblHeader" runat="server"
                                                                    style="font-weight: bold;">
                                                                    <tr>
                                                                        <td colspan="3">Sonic Automotive 
                                                                        </td>
                                                                        <td colspan="4">WC Allocation YTD Charge Report 
                                                                        </td>
                                                                        <td colspan="10" align="right">Accident Year :
                                                                            <asp:Label runat="server" ID="lblAccYear"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr >
                                                                        <td style="width: 90px;">First Report Number
                                                                        </td>
                                                                        <td style="width: 125px;">Date of Incident
                                                                        </td>
                                                                        <td align="right" style="width: 130px;">Date Reported To SRS
                                                                        </td>
                                                                        <td style="width: 120px;">Location
                                                                        </td>
                                                                        <td style="width: 120px;">Region
                                                                        </td>                                                                        
                                                                        <td style="width: 120px;">Market
                                                                        </td>
                                                                        <td style="width: 100px;">Department
                                                                        </td>
                                                                        <td style="width: 125px;">Employee
                                                                        </td>
                                                                        <td style="width: 400px;">Description of Incident
                                                                        </td>
                                                                        <td style="width: 125px;">Invst. Comp.
                                                                        </td>
                                                                        <td style="width: 80px;">Cause Code
                                                                        </td>
                                                                        <td style="width: 100px;">Rep. Only
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">Initial Charge
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">Total Credits
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">Total Penalties
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">SureGrip Discount
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">Total Charge Amount
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
                                                            <td align="left" colspan="17" style="background-color: White; height: 25px; color: Black;border:thin">
                                                                <b>&nbsp;Location :
                                                                    <asp:Label ID="lblRegion" runat="server"><%#Eval("DBA")%></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" ShowFooter="true" 
                                                                    ShowHeader="false" Width="1995px" CellPadding="4" EmptyDataText="No Record Found !"
                                                                    EnableTheming="false" GridLines="None" CellSpacing="0">
                                                                    <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                                    <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                    <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top" />
                                                                    <FooterStyle Font-Bold="true" VerticalAlign="top" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Region" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblWC_Fr_Number" runat="server" Text='<%# Eval("WC_Fr_Number") %>' Width="90px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMsg" runat="server" Text="Sub Total "></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date of Incident" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Date_Of_Incident" runat="server" Text='<%# Eval("Date_Of_Incident").ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Incident")) : "" %>' Width="125px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalCount" runat="server" Text=""></asp:Label>
                                                                            </FooterTemplate>
                                                                            <FooterStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date Reported To SRS" ItemStyle-VerticalAlign="Top"
                                                                            FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Date_Reported_to_SRS" runat="server" Text='<%# Eval("Date_Of_Incident").ToString() != "" ? clsGeneral.FormatDateToDisplay(clsGeneral.FormatDateToStore(Eval("Date_Reported_to_SRS"))) : "" %>'
                                                                                    Width="130px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblLeaseable_Area" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Location" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="DBA" runat="server" Text='<%# Eval("DBA") %>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Region" ItemStyle-VerticalAlign="Top" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Region" runat="server" Text='<%# Eval("Region") %>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Market" ItemStyle-VerticalAlign="Top" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Market" runat="server" Text='<%# Eval("Market") %>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Lease_Expiration_Date" runat="server" Text='<%# Eval("Description")%>'
                                                                                    Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Prior_Lease_Commencement_Date" runat="server" Text='<%# (Eval("Employee_Name"))%>'
                                                                                    Width="125px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Description_of_Incident" runat="server" Text='<%# (Eval("Description_of_Incident"))%>'
                                                                                    Width="400px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Inv_Comp" runat="server" Text='<%# Eval("Inv_Comp")%>'
                                                                                    Width="125px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Sonic_Cause_Code" runat="server" Text='<%# Eval("Sonic_Cause_Code")%>'
                                                                                    Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Options" runat="server" Width="100px"><%# Eval("Report_Only")%>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Initial_Charge" runat="server" Text='<%# string.Format("{0:C2}", Eval("Initial_Charge"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblInitialCharge" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Credits" runat="server" Text='<%# string.Format("{0:C2}", Eval("Total_Credits"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalCredits" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Penalties" runat="server" Text='<%# string.Format("{0:C2}", Eval("Total_Penalties"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalPanalties" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                           <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="SureGrip_Footwear" runat="server" Text='<%# string.Format("{0:C2}", Eval("SureGrip_Charge"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Charge" runat="server" Text='<%# string.Format("{0:C2}", Eval("SureGrip_Total_Charge"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No Records found!
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="4" cellspacing="0" width="100%" id="tblFooter" runat="server">
                                                                    <tr style="font-weight: bold; background-color: #507cd1; color: White">
                                                                        <td style="width: 90px;">Grand Total
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            <asp:Label ID="lblGCount" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 130px;"></td>
                                                                        <td style="width: 120px;"></td>
                                                                        <td style="width: 120px;"></td>
                                                                        <td style="width: 100px;"></td>
                                                                        <td style="width: 125px;"></td>
                                                                        <td style="width: 400px;"></td>
                                                                        <td style="width: 125px;"></td>
                                                                        <td style="width: 80px;"></td>
                                                                        <td style="width: 100px;"></td>
                                                                        <td style="width: 120px;"></td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label ID="lblGInitialCharge" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label ID="lblGTotalCredits" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label ID="lblGTotalPanalties" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 120px;"></td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label ID="lblGTotalAmount" runat="server"></asp:Label>
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
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
