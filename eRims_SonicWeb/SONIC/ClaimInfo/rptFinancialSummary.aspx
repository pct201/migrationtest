<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptFinancialSummary.aspx.cs" 
Inherits="SONIC_ClaimInfo_rptFinancialSummary" Title="eRIMS Sonic :: Financial Summary Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                Financial Summary Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="40%" align="center">
                    <tr>
                        <td width="30%" align="left" valign="top">
                            Accident Year<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstAccidentYear" runat="server" SelectionMode="Multiple" ToolTip="Select Accident Year"
                                AutoPostBack="false" Width="166px">                                    
                             </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvAccidentYear" runat="server" ErrorMessage="Please Select Accident Year"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstAccidentYear"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="left" valign="top">
                            Claim Type<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip="Select Claim Type"
                                AutoPostBack="false" Width="166px">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>                                
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Claim Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstClaimType" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false"></asp:RequiredFieldValidator>
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
                        <td align="left" valign="top">
                            Market<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market" AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvMarket" runat="server" ErrorMessage="Please Select Market"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstMarket"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Prior Valuation Date<span class="mf">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtValuationDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtValuationDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtValuationDate" ErrorMessage="Please enter Prior Valuation Date"
                            SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:RangeValidator ID="revDate" ControlToValidate="txtValuationDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                            ErrorMessage="Prior Valuation Date is not valid." runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                        <td align="left">
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
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="dvGrid" runat="server" style="display: none;">
                    <table cellpadding="0" cellspacing="0" width="95%" border="0">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
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
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:Panel ID="pnlGrid" runat="server">
                                    <asp:GridView ID="gvReportOuter" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReportOuter_RowDataBound"
                                        DataKeyNames="AccidentYear" Width="100%" EnableTheming="false" HorizontalAlign="Left"
                                        CellPadding="4" GridLines="None" CssClass="GridClass" ShowFooter="true" EmptyDataText="No Record Found">
                                        <HeaderStyle CssClass="HeaderStyle" />
                                        <FooterStyle CssClass="FooterStyle" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="18px"/>                 
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle HorizontalAlign="left" />
                                                <HeaderTemplate>    
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>                                                                                                         
                                                                        <table width="100%" cellpadding="0" cellspacing="0"> 
                                                                            <tr> 
                                                                                <td width="100%">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                                                                        <tr>
                                                                                            <td style="width: 25%;" align="left">
                                                                                                Financial Summary Report
                                                                                            </td>
                                                                                            <td style="width: 15%;" align="right">
                                                                                                Total Incurred Amount
                                                                                            </td>
                                                                                            <td style="width: 15%;" align="right">
                                                                                                Total Paid Amount
                                                                                            </td>
                                                                                            <td style="width: 20%;" align="right">
                                                                                                Total Outstanding Amount
                                                                                            </td>
                                                                                            <td style="width: 13%;" align="right">
                                                                                                Number Of Claims
                                                                                            </td>
                                                                                            <td style="width: 12%;" align="right">
                                                                                                Percent<br />
                                                                                                Paid/Inc
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                    
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                    
                                                </HeaderTemplate>
                                                <ItemTemplate>                                                                                                        
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="100%" align="left">
                                                                <asp:Label ID="lblLossYear" runat="server" Text='<%# "Accident Year - " + Eval("AccidentYear")%>'
                                                                    Font-Bold="true" ForeColor="Chocolate">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" >
                                                                <asp:GridView ID="gvRegion" runat="server" AutoGenerateColumns="false" CellPadding="0" CssClass="GridClass" Width="100%" ShowHeader="False" 
                                                                HorizontalAlign="Left" EnableTheming="false" GridLines="None" ShowFooter="false" OnRowDataBound="gvRegion_RowDataBound" EmptyDataText="No Record Found">                                                                    
                                                                    <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="100%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td class="Spacer" style="height:5px;"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="100%" align="left" >
                                                                                            <b>Region - <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Region") %>'></asp:Label></b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Spacer" style="height:3px;" ></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="Left">
                                                                                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="AccidentYear"
                                                                                                CellPadding="4" CssClass="GridClass" Width="100%" ShowHeader="False" HorizontalAlign="Left"
                                                                                                EnableTheming="false" GridLines="None" ShowFooter="true" OnRowDataBound="gvDetail_RowDataBound"
                                                                                                EmptyDataText="No Record Found">
                                                                                                <RowStyle CssClass="RowStyle" />
                                                                                                <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                                                                <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Left" />
                                                                                                        <FooterTemplate>
                                                                                                            Sub Totals For Region: <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemStyle Width="15%" HorizontalAlign="right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblinc" runat="server" Text='<%# string.Format("{0:C2}", Eval("Incurred") )%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblIncurred" runat="server" Text=""></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemStyle Width="15%" HorizontalAlign="right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblpaid" runat="server" Text='<%# string.Format("{0:C2}", Eval("Paid"))%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblPaid" runat="server" Text=""></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemStyle Width="20%" HorizontalAlign="right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblout" runat="server" Text='<%#string.Format("{0:C2}",  Eval("Outstanding"))%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblOutstanding" runat="server" Text=""></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemStyle Width="13%" HorizontalAlign="right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblclaim" runat="server" Text='<%# Eval("ClaimCount")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblNoOfClaim" runat="server" Text=""></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemStyle Width="12%" HorizontalAlign="right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblper" runat="server" Text='<%#string.Format("{0:N2}",  Eval("Percentage"))%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle BackColor="white" ForeColor="black" Wrap="true" HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblPercent" runat="server" Text=""></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>                                                                                
                                                                            </ItemTemplate>                                                                                                                                                
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>                                                        
                                                    </table>                                                                                                        
                                                </ItemTemplate>
                                                <FooterStyle Wrap="true" />
                                                <FooterTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>                                                            
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="100%">
                                                                                    <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold; background-color: #507CD1;
                                                                                        color: White;" id="tblFooter" runat="server">
                                                                                        <tr>
                                                                                            <td style="width: 25%;" align="Left">
                                                                                                <asp:Label ID="lblGrandTotal" runat="server" Text="Report Grand Totals - "></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 15%;" align="right">
                                                                                                <asp:Label ID="lblIncurred" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 15%;" align="right">
                                                                                                <asp:Label ID="lblPaid" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 20%;" align="right">
                                                                                                <asp:Label ID="lblOutstanding" runat="server"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 13%;" align="right">
                                                                                                <asp:Label ID="lblNoOfClaim" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 12%;" align="right">
                                                                                                <asp:Label ID="lblPercent" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                    
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
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
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

