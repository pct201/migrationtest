<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptReportableClaims.aspx.cs"
    Inherits="ERReports_ReportableClaims" Title="eRIMS Sonic :: Immediately Reportable Claims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="ghc">
                &nbsp;&nbsp;Immediately Reportable Claims
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1" width="1000px">
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="lnkExport" runat="server" Text="Export To Excel" OnClick="lnkExport_Click"
                                Visible="false" /> &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="display: none; text-align: left;" id="divReport_Grid" runat="server" width="999px">
                                <asp:GridView ID="gvReport" runat="server" Width="100%" EmptyDataText="No Records Found"
                                    OnRowCreated="gvReport_RowCreated" EnableTheming="false" GridLines="None" ShowFooter="true"
                                    AutoGenerateColumns="false" OnRowDataBound="gvReport_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" VerticalAlign="top" />
                                    <RowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="top" />
                                    <FooterStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="left" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="top" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold;" id="tblHeader"
                                                                runat="server">
                                                                <tr>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="lblH1" runat="server" Width="120px" Text='Type of Allegation' />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label1" runat="server" Width="300px" Text='Claim Description' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label2" runat="server" Width="120px" Text='Carrier' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label3" runat="server" Width="120px" Text='Type of Claim' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label4" runat="server" Width="120px" Text='Policy Number' />
                                                                    </td>
                                                                    <td style="width: 120px;" align="right">
                                                                        <asp:Label ID="Label5" runat="server" Width="120px" Text='Deductible' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label6" runat="server" Width="120px" Text='Date of Alleged Wrongful Act' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label7" runat="server" Width="120px" Text='Date Claim Opened' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label8" runat="server" Width="120px" Text='Policy Effective Date' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label9" runat="server" Width="120px" Text='Policy Expiration Date' />
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                        <asp:Label ID="Label10" runat="server" Width="150px" Text='Estimated Demand Exposure' />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label11" runat="server" Width="300px" Text='Claim Status/Comments' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label12" runat="server" Width="120px" Text='Internal Counsel' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label13" runat="server" Width="120px" Text='Internal Counsel Phone' />
                                                                    </td>
                                                                     <td style="width: 120px;">
                                                                        <asp:Label ID="Label16" runat="server" Width="120px" Text='Location Code' />
                                                                    </td>
                                                                     <td style="width: 200px;">
                                                                        <asp:Label ID="Label17" runat="server" Width="200px" Text='Sonic Location Name' />
                                                                    </td>
                                                                     <td style="width: 200px;">
                                                                        <asp:Label ID="Label18" runat="server" Width="200px" Text='Location d/b/a' />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label14" runat="server" Width="200px" Text='Entity' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label15" runat="server" Width="120px" Text='Defense Attorney' />
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
                                                        <td align="left" style="background-color: White; height: 25px; color: Black;border:thin;" width="100%" colspan="19">
                                                            <b>
                                                                <asp:Label ID="lblRegion" runat="server"><%#Eval("Region")%></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvClaimData" runat="server" ShowHeader="false" Width="100%" OnRowDataBound="gvClaimData_RowDataBound"
                                                                CellPadding="4" GridLines="None" CssClass="GridClass" AutoGenerateColumns="false"
                                                                EnableTheming="false" ShowFooter="true">
                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="top" />
                                                                <FooterStyle BackColor="white" ForeColor="black" Font-Bold="true" />
                                                                <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                <AlternatingRowStyle CssClass="AlterRowStyle" VerticalAlign="top" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl1" runat="server" Width="120px" Text='<%#Eval("Type_of_Allegation")%>' />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Total
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl2" runat="server" Width="300px" Text='<%#Eval("Claim_Description")%>' />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotal" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl15" runat="server" Width="120px" Text='<%#Eval("Carrier")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl16" runat="server" Width="120px" Text='<%#Eval("Type_Of_Claim")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl3" runat="server" Width="120px" Text='<%#Eval("Primary_Insurance_Policy_Number")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl4" runat="server" Width="120px" Text='<%#clsGeneral.GetStringValue(Eval("Primary_Deductable"))%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl5" runat="server" Width="120px" Text='<%# Eval("Date_Alleged_Wrongful_Act") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Alleged_Wrongful_Act"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl6" runat="server" Width="120px" Text='<%# Eval("Claim_Open_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Claim_Open_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl7" runat="server" Width="120px" Text='<%# Eval("Primary_Policy_Effective_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Primary_Policy_Effective_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl8" runat="server" Width="120px" Text='<%# Eval("Primary_Policy_Expiration_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Primary_Policy_Expiration_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                                                        <FooterStyle Width="150px" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl9" runat="server" Width="150px" Text='<%# Eval("Estimated_Demand_Exposure") != DBNull.Value ? "$ " + clsGeneral.GetStringValue(Eval("Estimated_Demand_Exposure")) : "" %>' /></ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotalExposure" runat="server" Width="150px" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl10" runat="server" Width="300px" Text='<%#Eval("Claim_Status_Comments")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl11" runat="server" Width="120px" Text='<%#Eval("Internal_Counsel")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl12" runat="server" Width="120px" Text='<%#Eval("Legal_Telephone")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl13" runat="server" Width="120px" Text='<%#Eval("Sonic_Location_Code")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl131" runat="server" Width="200px" Text='<%#Eval("legal_entity")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl132" runat="server" Width="200px" Text='<%#Eval("dba")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl133" runat="server" Width="200px" Text='<%#Eval("Entity")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl14" runat="server" Width="120px" Text='<%#Eval("Firm")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold; color: White;"
                                                                id="tblFooter" runat="server">
                                                                <tr style="background-color:#507CD1;">
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="lblH1" runat="server" Width="120px" Text='Grand Total' />
                                                                    </td>
                                                                    <td style="width: 120px;" align="left">
                                                                        <asp:Label ID="lblFTotal" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label2" runat="server" Width="300px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label3" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label4" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label5" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label6" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label7" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label8" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label9" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                        <asp:Label ID="lblFTotalExposure" runat="server" Width="150px" />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label11" runat="server" Width="300px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label12" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label13" runat="server" Width="120px" />
                                                                    </td>
                                                                          <td style="width: 120px;">
                                                                        <asp:Label ID="Label19" runat="server" Width="120px" />
                                                                    </td>
                                                                     <td style="width: 200px;">
                                                                        <asp:Label ID="Label20" runat="server" Width="200px" />
                                                                    </td>
                                                                     <td style="width: 200px;">
                                                                        <asp:Label ID="Label21" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label14" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label15" runat="server" Width="120px" />
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
