<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptInsurance.aspx.cs"
    Inherits="Policy_RptInsurance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Insurance Schedule
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="3" cellspacing="1" border="0" width="50%" align="center">
                    <tr>
                        <td width="35%" align="left">
                            Policy Year
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpPolicyYear" runat="server" Width="175px" SkinID="dropGen" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Program
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstProgram" runat="server" Width="225px" Rows="5" SelectionMode="Multiple"  AutoPostBack="true" OnSelectedIndexChanged="lstProgram_SelectedIndexChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Policy Type
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstPolicyType" runat="server" Width="225px" Rows="5" SelectionMode="Multiple" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>         
                    <tr>
                        <td colspan="3" align="center"> 
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>           
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="right" style="height: 30px">
                    <table id="tblUtility" runat="server" width="100%" align="center">
                        <tr valign="middle">
                            <td align="right" width="100%">
                                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <div id="dvReport" runat="server" width="990px" style="overflow-x:scroll;overflow-y:none">
                    <asp:GridView ID="gvPolicy" runat="server" CellPadding="2" GridLines="None" Width="2600px"
                        CssClass="GridClass" AutoGenerateColumns="false" EnableTheming="false" 
                        HorizontalAlign="Left" ShowFooter="true" EmptyDataText="No Record Found !">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <FooterStyle BackColor="white" ForeColor="black" Font-Bold="true" />
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                                        id="tblHeader" runat="server">
                                        <tr>
                                            <td align="left" colspan="2">Sonic Automotive</td>
                                            <td align="center" colspan="13">Insurance Schedule</td>
                                            <td align="right" colspan="3">&nbsp;<asp:Label ID="lblPolicyYear" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="125px">
                                                Program
                                            </td>
                                            <td align="left" width="200px">
                                                Policy Type
                                            </td>
                                            <td align="left" width="150px">
                                                Layer
                                            </td>
                                            <td align="left" width="150px">
                                                Insurance Carrier
                                            </td>
                                            <td align="left" width="150px">
                                                Policy Number
                                            </td>
                                            <td align="left" width="150px">
                                                Policy Effective Date
                                            </td>
                                            <td align="left" width="150px">
                                                Policy Expiration Date
                                            </td>
                                             <td align="left" width="100px">
                                                Policy Year
                                            </td>
                                            <td align="left" width="125px">
                                                Coverage Form
                                            </td>
                                            <td align="right" width="130px">
                                                Per Occurrence Limit $
                                            </td>
                                            <td align="right" width="125px">
                                                Aggregate Limit $
                                            </td>
                                            <td align="right" width="125px">
                                                Underlying Limit $
                                            </td>
                                            <td align="right" width="125px">
                                                Share Percentage $
                                            </td>
                                            <td align="right" width="125px">
                                                Share Limit $
                                            </td>
                                            <td align="right" width="125px">
                                                Deductible $
                                            </td>
                                            <td align="right" width="125px">
                                                Store Deductible $
                                            </td>
                                            <td align="right" width="125px">
                                                Annual Premium $
                                            </td>
                                            <td align="right" width="125px">
                                                S/L Fees $
                                            </td>
                                            <td align="right" width="125px">
                                                Total $
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%" cellpadding="4" cellspacing="0" border="0" id="tblDetails" runat="server">
                                        <tr>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblProgram" runat="server" Text='<%#Eval("Program") %>' Width="125px" />
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblPolicytype" runat="server" Text='<%# Eval("Policy_Type") %>' Width="200px" />
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblLayer" runat="server" Text='<%#Eval("Layer") %>' Width="150px" />
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblCarrier" runat="server" Text='<%#Eval("Carrier") %>' Width="150px" />
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblPolicyNumber" runat="server" Text='<%#Eval("Policy_Number") %>' Width="150px" />
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblPolicyEffective" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Policy_Effective_Date"))%>' Width="150px" />
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblPolicyExiration" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Policy_Expiration_Date"))%>' Width="150px" />
                                            </td>
                                             <td align="left" width="100px">
                                                <asp:Label ID="lblPloicy_Year" runat="server" Text='<%# Eval("Policy_Year")%>' Width="100px" />
                                            </td>
                                            <td align="left" width="125px">
                                                <asp:Label ID="lblCoverageFrom" runat="server" Text='<%#Eval("Coverage_Form") %>' Width="125px" />
                                            </td>
                                            <td align="right" width="130px">
                                                <asp:Label ID="lblPerOccurence" runat="server" Text='<%# string.Format("{0:N2}",Eval("Per_Occurrence_Limit")) %>' Width="130px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblAggregateLimit" runat="server" Text='<%# string.Format("{0:N2}", Eval("Aggregate_Limit"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblunderlying" runat="server" Text='<%# string.Format("{0:N2}", Eval("Underlying_Limit"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblSharePercent" runat="server" Text='<%# string.Format("{0:N2}", Eval("Share_Precentage"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblShareLimit" runat="server" Text='<%# string.Format("{0:N2}", Eval("Share_Limit"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblDeductible" runat="server" Text='<%# string.Format("{0:N2}", Eval("Deductible_Amount"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblStore" runat="server" Text='<%# string.Format("{0:N2}", Eval("Store_Deductible"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblAnnualPremium" runat="server" Text='<%# string.Format("{0:N2}", Eval("Annual_Premium"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblSurplus" runat="server" Text='<%# string.Format("{0:N2}", Eval("Surplus_Lines_Fees"))%>' Width="125px" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# string.Format("{0:N2}", Eval("Total"))%>' Width="125px" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold; background-color: #507CD1;color: White;"
                                        id="tblFooter" runat="server">
                                        <tr>
                                            <td align="left" width="125px">
                                                Total
                                            </td>
                                            <td align="left" width="200px">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="150px">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="150px">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="150px">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="150px">
                                                &nbsp;
                                            </td>
                                            
                                            <td align="left" width="150px">
                                                &nbsp;
                                            </td>
                                             <td align="left" width="100px">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="130px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblAnnualPremiumTotal" runat="server" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblSLFees" runat="server" />
                                            </td>
                                            <td align="right" width="125px">
                                                <asp:Label ID="lblTotal" runat="server" />
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
    </asp:Panel>
    <table width="100%">
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
