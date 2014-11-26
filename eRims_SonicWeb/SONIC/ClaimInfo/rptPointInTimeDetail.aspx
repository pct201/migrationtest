<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptPointInTimeDetail.aspx.cs" 
Inherits="SONIC_ClaimInfo_rptPointInTimeDetail" Title="eRIMS Sonic :: Point-in-Time Detail Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    
 <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsErrorGroup"/>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Point-in-Time Detail Report
            </td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" width="70%" cellpadding="5" cellspacing="0">
                    <tr>
                        <td width="150" align="left">
                            Comparison Dates<span class="mf">*</span>
                        </td>
                        <td width="4" align="left">
                            :</td>
                        <td align="left" style="width: 5px">
                            First
                        </td>
                        <td width="4">
                            :</td>
                        <td width="130px">
                            <asp:TextBox runat="server" ID="txtCompDate1" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCompDate1', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateFrom1" runat="server" ControlToValidate="txtCompDate1"
                                ErrorMessage="Please enter First Comparison Date" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="revDateFrom1" ControlToValidate="txtCompDate1" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="First Comparison Date is not valid"
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                        <td width="5" align="left">
                            Second
                        </td>
                        <td width="4">
                            :</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtCompDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCompDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompDate2"
                                ErrorMessage="Please enter Second Comparison Date" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtCompDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Second Comparison Date is not valid"
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ControlToValidate="txtCompDate2" ControlToCompare="txtCompDate1" 
                            Operator="GreaterThanEqual" ErrorMessage="Comparison Date Second must be greater than Comparison Date First" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />    
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Accident Date<span class="mf">*</span></td>
                        <td>
                            :</td>
                        <td align="left">
                            From
                        </td>
                        <td>
                            :</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLossFromDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLossFromDate"
                                ErrorMessage="Please enter Accident Date From" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtLossFromDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date From is not valid"
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                        <td align="left">
                            To
                        </td>
                        <td>
                            :</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtLossToDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateTo1" runat="server" ControlToValidate="txtLossToDate"
                                ErrorMessage="Please enter Accident Date To" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="revDateTo1" ControlToValidate="txtLossToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Accident Date To is not valid"
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />  
                            <asp:CompareValidator ID="cvDate1" runat="server" Type="Date" ControlToValidate="txtLossToDate" ControlToCompare="txtLossFromDate" 
                            Operator="GreaterThanEqual" ErrorMessage="Accident Date To must be greater than Accident Date From" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td width="150" valign="top" align="left">
                            Claim Type<span class="mf">*</span></td>
                        <td width="4" valign="top">
                            :</td>
                        <td colspan="6" style="text-align: left;">
                            <asp:ListBox ID="lsbClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip=""
                                AutoPostBack="false">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>                                
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbClaimType" runat="server" ErrorMessage="Please Select Claim Type" ValidationGroup="vsErrorGroup"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="150" align="left">
                        </td>
                        <td valign="top" width="4">
                        </td>
                        <td colspan="6" align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="90%" align="center">
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
                                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    <asp:Label ID="lblHeader" Text="Detail Point-In-Time Comparison Report" runat="server">
                    </asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td align="left" colspan="2">
                    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="gvReport_RowCreated"
                        EmptyDataText="No Record found !" GridLines="None" EnableTheming="false" CssClass="GridClass"
                        CellPadding="4">
                        <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" VerticalAlign="Middle" />
                        <AlternatingRowStyle CssClass="AlterStyle" />
                        <FooterStyle BackColor="#507CD1" ForeColor="white" />
                        <Columns>
                            <asp:TemplateField HeaderText="Claim Number/Name">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblClaimNumber" runat="server" Font-Underline="true" Text='<%# Eval("origin_claim_number") %>'></asp:Label><br />
                                    <%# Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Accident Date">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="12%" HorizontalAlign="Center" VerticalAlign="middle" />
                                <ItemTemplate>
                                    <br />
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date_Of_Accident","{0:MM/dd/yyyy}") %>'></asp:Label><br />
                                    <br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="right" Width="12%" />
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemTemplate>
                                    Incurred:<br />
                                    Paid:<br />
                                    Outstandings:<br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" Width="12%" />
                                <HeaderTemplate>
                                    <asp:Label ID="lblDate1" runat="server" Text="Date 1"></asp:Label><br />
                                    Total Dollars
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblInc" runat="server" Text='<%# Eval("Incurred_1","{0:C2}") %>'></asp:Label><br />
                                    <asp:Label ID="lblPaid" runat="server" Text='<%# Eval("Paid_1","{0:C2}") %>'></asp:Label><br />
                                    <asp:Label ID="lblOutS" runat="server" Text='<%# Eval("Outstanding_1","{0:C2}") %>'></asp:Label><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" Width="12%" />
                                <HeaderTemplate>
                                    <asp:Label ID="lblDate2" runat="server" Text="Date 2"></asp:Label><br />
                                    Total Dollars
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblInc2" runat="server" Text='<%# Eval("Incurred_2","{0:C2}") %>'></asp:Label><br />
                                    <asp:Label ID="lblPaid2" runat="server" Text='<%# Eval("Paid_2","{0:C2}") %>'></asp:Label><br />
                                    <asp:Label ID="lblOutS2" runat="server" Text='<%# Eval("Outstanding_2","{0:C2}") %>'></asp:Label><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Difference">
                                <HeaderStyle HorizontalAlign="right" />
                                <ItemStyle HorizontalAlign="right" Width="12%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIncD" runat="server" Text='<%# Eval("Diff_Inc","{0:C2}") %>'></asp:Label><br />
                                    <asp:Label ID="lblPaidD" runat="server" Text='<%# Eval("Diff_Paid","{0:C2}") %>'></asp:Label><br />
                                    <asp:Label ID="lblOutSD" runat="server" Text='<%# Eval("Diff_Out","{0:C2}") %>'></asp:Label><br />
                                </ItemTemplate>
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

