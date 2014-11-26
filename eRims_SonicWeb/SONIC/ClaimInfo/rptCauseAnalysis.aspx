<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptCauseAnalysis.aspx.cs"
 Inherits="SONIC_ClaimInfo_rptCauseAnalysis" Title="eRIMS Sonic :: WC Cause Analysis Report" %>
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
                WC Cause Analysis Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="65%" align="center">
                    <tr>
                        <td colspan="3" align="center">
                            <table width="100%" border="0">
                                <tr>
                                    <td colspan="2" align="left" width="100">
                                        &nbsp;
                                    </td>
                                    <td align="left" width="200">
                                        &nbsp; &nbsp; &nbsp; Accident Date From
                                    </td>
                                    <td colspan="1" align="left" width="200">
                                        &nbsp; &nbsp; &nbsp; Accident Date To
                                    </td>
                                    <td align="left" >&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" width="100">
                                        &nbsp;
                                    </td>
                                    <td colspan="1" align="left" width="200">
                                        &nbsp; &nbsp; &nbsp; (MM/DD/YYYY)
                                    </td>
                                    <td colspan="1" align="left" width="200">
                                        &nbsp; &nbsp; (MM/DD/YYYY)
                                    </td>
                                    <td align="left">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="left" width="100">
                                        Dates of Accident <span style="color: Red; font-weight: bold;">*</span>
                                    </td>
                                    <td align="left" valign="top" width="10">
                                        :
                                    </td>
                                    <td align="left" width="200">
                                        <asp:TextBox runat="server" ID="txtAccidentFromDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                                        <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAccidentFromDate', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" /><br />
                                        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtAccidentFromDate"
                                            ErrorMessage="Please enter Accident Date From" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            Display="none" />
                                        <asp:RangeValidator ID="revDateFrom" ControlToValidate="txtAccidentFromDate" MinimumValue="01/01/1753"
                                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid."
                                            runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                                        
                                    </td>
                                    <td align="left" width="200">
                                        <asp:TextBox runat="server" ID="txtAccidentToDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                                        <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAccidentToDate', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" /><br />
                                        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtAccidentToDate"
                                            ErrorMessage="Please enter Accident Date To" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            Display="none" />
                                        <asp:RangeValidator ID="revDateTo" ControlToValidate="txtAccidentToDate" MinimumValue="01/01/1753"
                                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date To is not valid."
                                            runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />  
                                        <asp:CompareValidator ID="cvDate" runat="server" Type="Date" ControlToValidate="txtAccidentToDate" ControlToCompare="txtAccidentFromDate" 
                                        Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
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
     </table>
     <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="90%" align="center" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="right" style="height: 30px">
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
                <td align="center">
                    <asp:GridView ID="gvRegions" runat="server" EnableTheming="false" AutoGenerateColumns="false" Width="100%" 
                     OnRowDataBound="gvRegions_RowDataBound" ShowFooter="true" GridLines="None" HorizontalAlign="Left" 
                     EmptyDataText="No Record Found !">
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
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                                    <tr>
                                                        <td style="width: 20%" align="left">
                                                            Cause of Claim
                                                        </td>
                                                        <td style="width: 10%" align="right">
                                                            Number of Claims
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            Percent to Total<br />Claims
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            Total Incurred<br />Dollars
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            Percent to Total<br />Dollars
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            Average Cost Per<br />Claim
                                                        </td>
                                                        <td style="width: 10%" align="right">
                                                            Largest Loss
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
                                            <td align="left" style="background-color: White; height: 25px; color: Black;">
                                                <b>
                                                    Region : <asp:Label ID="lblRegion" runat="server"><%#Eval("Region")%></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvDetails" runat="server" EnableTheming="false" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                 CellPadding="4" ShowHeader="false" OnRowDataBound="gvDetails_RowDataBound" ShowFooter="true" HorizontalAlign="Left" CssClass="GridClass">
                                                    <FooterStyle BackColor="white" ForeColor="black" Font-Bold="true" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <%# Eval("Description")%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="20%" HorizontalAlign="Left" />
                                                            <FooterTemplate>
                                                                Totals
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:N0}",Eval("ClaimCount"))%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="10%" HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalClaimCount" runat="server" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:N2}", Eval("ClaimPercent"))%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="15%" HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                &nbsp;
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:C2}", Eval("Incurred"))%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="15%" HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalIncurred" runat="server" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:N2}", Eval("IncurredPercent"))%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="15%" HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                &nbsp;
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:C2}", Eval("AvgCostPerClaim"))%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="15%" HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalAvgCost" runat="server" />
                                                            </FooterTemplate>                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:C2}", Eval("Largest_Loss"))%>
                                                            </ItemTemplate>
                                                            <FooterStyle Width="10%" HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                &nbsp;
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
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" style="font-weight: bold; background-color: #507CD1;color: White;" id="tblFooter" runat="server">
                                                    <tr>
                                                        <td style="width: 20%" align="left">
                                                            Report Grand Totals
                                                        </td>
                                                        <td style="width: 10%" align="right">
                                                            <asp:Label ID="lblTotalClaimCount" runat="server" />
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            <asp:Label ID="lblTotalIncurred" runat="server" />
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 15%" align="right">
                                                            <asp:Label ID="lblTotalAvgCost" runat="server" />
                                                        </td>
                                                        <td style="width: 10%" align="right">
                                                            &nbsp;
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
     </asp:Panel>
     <table width="100%">        
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
</asp:Content>

