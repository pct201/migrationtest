<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
 CodeFile="rptInsurerLagSummary.aspx.cs" Inherits="SONIC_ClaimInfo_rptInsurerLagSummary" Title="eRIMS Sonic :: Reported to Insurer Lag Summary Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsErrorGroup" />
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Reported to Insurer Lag Summary Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="65%" border="0">
                    <tr>
                        <td colspan="2" align="left" width="100">
                            &nbsp;
                        </td>
                        <td align="left" width="150">
                            &nbsp; &nbsp; &nbsp; Loss Date From
                        </td>
                        <td colspan="1" align="left" width="150">
                            &nbsp; &nbsp; &nbsp; Loss Date To
                        </td>
                        <td align="left" colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" width="100">
                            &nbsp;
                        </td>
                        <td colspan="1" align="left" width="150">
                            &nbsp; &nbsp; &nbsp; (MM/DD/YYYY)
                        </td>
                        <td colspan="1" align="left" width="150">
                            &nbsp; &nbsp; (MM/DD/YYYY)
                        </td>
                        <td align="left" colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" width="100">
                            Dates of Loss <span style="color: Red; font-weight: bold;">*</span>
                        </td>
                        <td align="left" valign="top" width="10">
                            :
                        </td>
                        <td align="left" width="200">
                            <asp:TextBox runat="server" ID="txtLossFromDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtLossFromDate"
                                ErrorMessage="Please enter Loss Date From" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="revDateFrom" ControlToValidate="txtLossFromDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date From is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            
                        </td>
                        <td align="left" width="200">
                            <asp:TextBox runat="server" ID="txtLossToDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtLossToDate"
                                ErrorMessage="Please enter Loss Date To" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="revDateTo" ControlToValidate="txtLossToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Loss Date To is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />  
                            <asp:CompareValidator ID="cvDate" runat="server" Type="Date" ControlToValidate="txtLossToDate" ControlToCompare="txtLossFromDate" 
                            Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                        <td align="left">
                        </td>
                    </tr>   
                    <tr>
                        <td align="left" valign="top">
                            Region<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left" colspan="2">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Region"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstRegions" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>                        
                    </tr> 
                     <tr>
                        <td align="left" valign="top">
                            Market<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left" colspan="2">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Market"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstMarket" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>                        
                    </tr>                 
                    <tr>
                        <td align="left" valign="top" width="100">
                        </td>
                        <td align="left" valign="top" width="10">
                        </td>
                        <td align="left" colspan="3" valign="top">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="80%" align="center" cellpadding="0" cellspacing="0" border="0">
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
                    <asp:GridView ID="gvDescription" EnableTheming="false" DataKeyNames="Region"
                        runat="server" AutoGenerateColumns="false" OnRowDataBound="gvDescription_RowDataBound"
                        Width="100%" HorizontalAlign="Left" GridLines="None" ShowFooter="true" EmptyDataText="No Record Found !">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px"/>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 26%">
                                                            Lag Period(Days)</td>
                                                        <td align="right" style="width: 14%">
                                                            No of Claims</td>
                                                        <td align="right" style="width: 14%">
                                                            Percentage To
                                                            <br />
                                                            Total Claim
                                                        </td>
                                                        <td align="right" style="width: 18%">
                                                            Total
                                                            <br />
                                                            Incurred Dollars
                                                        </td>
                                                        <td align="right" style="width: 14%">
                                                            Percentage To
                                                            <br />
                                                            Total Dollars
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
                                                    Region : <asp:Label ID="lblDescription" runat="server"><%#Eval("Region")%></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView Width="100%" ShowHeader="false" ID="gvLagSummaryReport" runat="server"
                                                    CellPadding="4" GridLines="None" CssClass="GridClass" AutoGenerateColumns="false"
                                                    EnableTheming="false" OnRowDataBound="gvLagSummaryReport_RowDataBound" HorizontalAlign="Left"
                                                    ShowFooter="true" EmptyDataText="No Record Found !">
                                                    <FooterStyle BackColor="white" ForeColor="black" Font-Bold="true" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <AlternatingRowStyle CssClass="AlterStyle" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="26%" HorizontalAlign="Left" />
                                                            <FooterStyle Width="26%" BackColor="white" ForeColor="black" Font-Bold="true" HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <%#Eval("StartLimit") + " To " + Eval("EndLimit")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                Total</FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="14%" HorizontalAlign="right" />
                                                            <FooterStyle Width="14%" BackColor="white" ForeColor="black" Font-Bold="true" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClaimCount" runat="server" Text='<%# String.Format("{0:N0}",Eval("ClaimCount"))%>' /></ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFooterClaimCount" runat="server" Text='<%#Eval("ClaimCount")%>' /></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="14%" HorizontalAlign="right" />
                                                            <FooterStyle Width="14%" BackColor="white" ForeColor="black" Font-Bold="true" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClaimPercent" runat="server" Text='<%# String.Format("{0:N2}",Eval("ClaimPercent"))%>' /></ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFooterClaimCountPercentage" runat="server" /></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="18%" HorizontalAlign="right" />
                                                            <FooterStyle Width="18%" BackColor="white" ForeColor="black" Font-Bold="true" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncurred" runat="server" Text='<%# String.Format("{0:C2}",Eval("Incurred"))%>' /></ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFooterIncurred" runat="server" Text='<%#Eval("Incurred")%>' /></FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="14%" HorizontalAlign="right" />
                                                            <FooterStyle Width="14%" BackColor="white" ForeColor="black" Font-Bold="true" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncurredPercent" runat="server" Text='<%# String.Format("{0:N2}",Eval("IncurredPercent"))%>' /></ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFooterIncurredPercentage" runat="server"/></FooterTemplate>
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
                                            <td valign="middle">
                                                <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold; background-color: #507CD1;
                                                                                            color: White;" id="tblFooter" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 26%">
                                                            Total</td>
                                                        <td align="right" style="width: 14%">
                                                            <asp:Label ID="lblTotalClaims" runat="server" /></td>
                                                        <td align="right" style="width: 14%">
                                                            <asp:Label ID="lblTotalClaimPercent" runat="server" />
                                                        </td>
                                                        <td align="right" style="width: 18%">
                                                            <asp:Label ID="lblTotalIncurred" runat="server" />
                                                        </td>
                                                        <td align="right" style="width: 14%">
                                                            <asp:Label ID="lblToalIncurredPercent" runat="server" />
                                                        </td>
                                                    </tr>                                                    
                                                </table>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="width: 30%" align="left"><asp:Label ID="lblMedian" runat="server" /></td>
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
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
</asp:Content>

