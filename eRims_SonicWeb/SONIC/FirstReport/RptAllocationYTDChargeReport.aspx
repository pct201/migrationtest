<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptAllocationYTDChargeReport.aspx.cs"
    Inherits="SONIC_FirstReport_RptAllocationYTDChargeReport" Title="eRIMS Sonic :: Workers Comp Allocation YTD Charge Report" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <asp:validationsummary id="vsError" runat="server" showsummary="false" showmessagebox="true"
        headertext="Verify the following fields:" borderwidth="1">
    </asp:validationsummary>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="ghc">
                Workers Comp Allocation YTD Charge Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td class="spacer" style="width: 15%">
                        </td>
                        <td align="left">
                            <table width="80%" style="text-align: left;" cellpadding="2" cellspacing="3" border="0">
                                <tr valign="top" align="left">
                                    <td>
                                        Region
                                    </td>
                                    <td align="right">
                                        :
                                    </td>
                                    <td>
                                        <asp:listbox id="lstRegion" runat="server" rows="4" selectionmode="Multiple" width="300px">
                                        </asp:listbox>
                                    </td>
                                </tr>
                                 <tr valign="top" align="left">
                                    <td>
                                        Market
                                    </td>
                                    <td align="right">
                                        :
                                    </td>
                                    <td>
                                        <asp:listbox id="lstMarket" runat="server" rows="4" selectionmode="Multiple" width="300px">
                                        </asp:listbox>
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td style="width: 10%;">
                                        Location
                                    </td>
                                    <td align="right" style="width: 5%;">
                                        :
                                    </td>
                                    <td style="width: 85%;">
                                        <asp:listbox id="lstLocation" runat="server" selectionmode="Multiple" width="300px">
                                        </asp:listbox>
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td style="width: 15%;">
                                        Accident Year
                                    </td>
                                    <td align="right" style="width: 5%;">
                                        :
                                    </td>
                                    <td style="width: 80%;">
                                        <asp:listbox id="lstYear" runat="server" selectionmode="Multiple" width="300px"></asp:listbox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td>
                                        <asp:button id="btnShowReport" runat="server" text="Show Report" causesvalidation="true"
                                            onclick="btnShowReport_Click" />
                                        <asp:button id="btnClear" runat="server" text="Clear Criteria" causesvalidation="false"
                                            onclick="btnClear_Click" />
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
                                <asp:linkbutton id="lnkExportToExcel" runat="server" text="Export To Excel" onclick="lnkExportToExcel_Click">
                                </asp:linkbutton>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden;
                                    text-align: left; width: 997px;">
                                    <asp:gridview id="gvReport" runat="server" width="100%" onrowdatabound="gvReport_RowDataBound"
                                        autogeneratecolumns="false" enabletheming="false" horizontalalign="Left" cellpadding="0"
                                        gridlines="None" showfooter="true" emptydatatext="No Record Found" cssclass="gridclass">
                                        <rowstyle backcolor="White" horizontalalign="Left" />
                                        <headerstyle cssclass="HeaderStyle" />
                                        <alternatingrowstyle backcolor="White" horizontalalign="Left" />
                                        <footerstyle cssclass="FooterStyle" />
                                        <emptydatarowstyle backcolor="#EAEAEA" horizontalalign="Center" height="20px" />
                                        <columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="4" cellspacing="0" width="100%" id="tblHeader" runat="server"
                                                                    style="font-weight: bold;">
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            Sonic Automotive 
                                                                        </td>
                                                                        <td colspan="4">
                                                                            WC Allocation YTD Charge Report 
                                                                        </td>
                                                                        <td colspan="8" align="right">
                                                                          Accident Year : <asp:Label runat="server" id="lblAccYear"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="left">
                                                                        <td style="width: 90px;">
                                                                            First Report Number
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            Date of Incident
                                                                        </td>
                                                                        <td align="right" style="width: 130px;">
                                                                            Date Reported To SRS
                                                                        </td>
                                                                        <td style="width: 120px;">
                                                                            Location
                                                                        </td>
                                                                        <td style="width: 120px;">
                                                                            Region
                                                                        </td>
                                                                        <td style="width: 100px;">
                                                                            Department
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            Employee
                                                                        </td>
                                                                        <td style="width: 400px;">
                                                                            Description of Incident
                                                                        </td>
                                                                        <td  style="width: 125px;">
                                                                            Invst. Comp.
                                                                        </td>
                                                                        <td   style="width: 80px;">
                                                                            Cause Code
                                                                        </td>                                                                        
                                                                        <td style="width: 100px;">
                                                                            Rep. Only
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            Initial Charge
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            Total Credits
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            Total Penalties
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            Total Charge Amount
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
                                                            <td align="left" style="background-color: White; height: 25px; color: Black;" >
                                                                <b> &nbsp;Location :
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
                                                                        <asp:TemplateField HeaderText="Region" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Region" runat="server" Text='<%# Eval("Region") %>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Lease_Expiration_Date" runat="server" Text='<%# Eval("Description")%>'
                                                                                    Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField  ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Prior_Lease_Commencement_Date" runat="server" Text='<%# (Eval("Employee_Name"))%>'
                                                                                    Width="125px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField  ItemStyle-VerticalAlign="Top">
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
                                                                                <asp:Label id="lblInitialCharge" runat="server" ></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Credits" runat="server" Text='<%# string.Format("{0:C2}", Eval("Total_Credits"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label id="lblTotalCredits" runat="server" ></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Penalties" runat="server" Text='<%# string.Format("{0:C2}", Eval("Total_Penalties"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label id="lblTotalPanalties" runat="server" ></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Charge" runat="server" Text='<%# string.Format("{0:C2}", Eval("Total_Charge"))%>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label id="lblTotalAmount" runat="server" ></asp:Label>
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
                                                                    <tr align="left" style="font-weight: bold; background-color: #507cd1; color: White">
                                                                        <td style="width: 90px;">
                                                                            Grand Total
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            <asp:Label id="lblGCount" runat="server" ></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 130px;">                                                                            
                                                                        </td>
                                                                        <td style="width: 120px;">
                                                                        </td>
                                                                        <td style="width: 120px;">
                                                                        </td>
                                                                        <td style="width: 100px;">
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                        </td>
                                                                        <td style="width: 400px;">
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                        </td>
                                                                        <td style="width: 80px;">
                                                                        </td>                                                                        
                                                                        <td style="width: 100px;">
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label id="lblGInitialCharge" runat="server" ></asp:Label>
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label id="lblGTotalCredits" runat="server" ></asp:Label>
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label id="lblGTotalPanalties" runat="server" ></asp:Label>
                                                                        </td>
                                                                        <td style="width: 120px;" align="Right">
                                                                            <asp:Label id="lblGTotalAmount" runat="server" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </columns>
                                    </asp:gridview>
                                </div>
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
</asp:content>
