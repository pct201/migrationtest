<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptLeaseDetailReport.aspx.cs"
    Inherits="SONIC_RealEstate_rptLeaseDetailReport" Title="eRIMS Sonic :: Lease Details Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">
        jQuery(function ($) {
            $("#<%=txtLCDateFrom.ClientID%>").mask("99/99/9999");
            $("#<%=txtLCDateTo.ClientID%>").mask("99/99/9999");
            $("#<%=txtLEDateFrom.ClientID%>").mask("99/99/9999");
            $("#<%=txtLEDateTo.ClientID%>").mask("99/99/9999");
        });
    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                <table width="100%" cellpadding="1" cellspacing="0" border="0">
                    <tr>
                        <td align="left">
                            Lease Detail Report
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr runat="server">
            <td>
                <table cellpadding="3" cellspacing="1" border="0" width="70%" align="center">
                    <tr>
                        <td width="12%" align="left" valign="top">
                            Region
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="34%">
                            <asp:ListBox ID="lstRegion" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="166px" Height="140px"></asp:ListBox>
                        </td>
                        <td width="4%">
                            &nbsp;
                        </td>
                        <td width="12%" align="left" valign="top">
                            Lease Type
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="34%">
                            <asp:ListBox ID="lstLeaseType" runat="server" SelectionMode="Multiple" ToolTip="Select Lease Type"
                                AutoPostBack="false" Width="166px" Height="140px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            LCD From
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLCDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date From" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvtxtLCDateFrom" runat="server" ValidationGroup="vsErrorGroup"
                                ControlToValidate="txtLCDateFrom" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            To
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLCDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date To" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLCDateTo" runat="server" ControlToValidate="txtLCDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD To is Not Valid Date." Display="none" SetFocusOnError="true"> 
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLCD" runat="server" ValidationGroup="vsErrorGroup" ControlToCompare="txtLCDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtLCDateTo"
                                ErrorMessage="LCD From Date must be Less Than Or Equal To LCD To Date." SetFocusOnError="true"></asp:CompareValidator>
                           </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            LED From
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLEDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Lease Expiration Date From" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLEDateFrom" ValidationGroup="vsErrorGroup"
                                runat="server" ControlToValidate="txtLEDateFrom" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LED From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                           </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            To
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLEDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Lease Expiration Date To" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLEDateTo" ValidationGroup="vsErrorGroup"
                                runat="server" ControlToValidate="txtLEDateTo" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LED To is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLED" runat="server" ValidationGroup="vsErrorGroup" ControlToCompare="txtLEDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtLEDateTo"
                                ErrorMessage="LED From Date must be Less Than Or Equal LED To Date." SetFocusOnError="true"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="7" style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Show Report" CausesValidation="true"
                                ValidationGroup="vsErrorGroup" OnClick="btnGenerateReport_Click" />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trSearchResult" visible="false">
            <td align="left">
                <table width="100%" cellpadding="1" cellspacing="0" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" align="right">
                            <asp:LinkButton runat="server" ID="lnkExportToExcel" Text="Export To Excel" CausesValidation="false"
                                OnClick="lnkExportToExcel_Click">
                            </asp:LinkButton>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div style="overflow: scroll; text-align: left; width: 997px;">
                                <asp:GridView ID="gvRegion" EnableTheming="false" OnRowCreated="gvRegion_RowCreated"
                                    DataKeyNames="Region" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvRegion_RowDataBound"
                                    OnRowCommand="gvRegion_RowCommand" Width="997px" HorizontalAlign="Left" GridLines="None"
                                    ShowFooter="true" EmptyDataText="No Record Found !">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="ghc" />
                                    <RowStyle BackColor="White" HorizontalAlign="Left" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="2800px" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="left">
                                                            <table width="2800px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                                                                id="tblHeader" runat="server">
                                                                <tr style="font-weight: bold;">
                                                                    <td align="left" colspan="6">
                                                                        Sonic Automotive
                                                                    </td>
                                                                    <td align="left" colspan="8">
                                                                        Lease Detail Report
                                                                    </td>
                                                                    <td align="right" colspan="2">
                                                                        <%= DateTime.Now %>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 120px">
                                                                        Lease Code
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                        <%--<asp:LinkButton ID="lnkRegion" CommandName="Region" ForeColor="White" CommandArgument="1"
                                                                            runat="server">Region</asp:LinkButton>--%>
                                                                        Region
                                                                    </td>
                                                                    <td align="left" style="width: 180px">
                                                                        <%-- <asp:LinkButton ID="lnkLocation" CommandName="Location" CommandArgument="2" ForeColor="White"
                                                                            runat="server">Location</asp:LinkButton>--%>
                                                                        Location
                                                                    </td>
                                                                    <td align="left" style="width: 180px">
                                                                        Address
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                        City
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                        State
                                                                    </td>
                                                                    <td align="left" style="width: 120px">
                                                                        Zip
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                        Primary Use
                                                                    </td>
                                                                    <td align="right" style="width: 150px">
                                                                        Rentable Area&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                        Lease Type
                                                                    </td>
                                                                    <td align="left" style="width: 180px">
                                                                        Leasee
                                                                    </td>
                                                                    <td align="left" style="width: 100px">
                                                                        LCD
                                                                    </td>
                                                                    <td align="left" style="width: 100px">
                                                                        LED
                                                                    </td>
                                                                    <td align="left" style="width: 120px">
                                                                        Lease Term
                                                                    </td>
                                                                    <td align="left" style="width: 250px">
                                                                        Renew Option
                                                                    </td>
                                                                    <td align="left" style="width: 250px">
                                                                        Cancel Option
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="2800px" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="left">
                                                            <%-- <asp:HiddenField ID="hdGroupValue" runat="server" Value='<%# Eval("STRSORTFIELD") %>' />--%>
                                                            <asp:GridView ID="gvLeaseDetails" runat="server" AutoGenerateColumns="False" Width="2800px"
                                                                GridLines="None" EnableTheming="false" CssClass="GridClass" CellPadding="4" CellSpacing="0"
                                                                ShowHeader="false" ShowFooter="true">
                                                                <FooterStyle Font-Bold="true" VerticalAlign="top" BackColor="white" ForeColor="black" />
                                                                <RowStyle HorizontalAlign="Left" CssClass="RowStyle" VerticalAlign="Top" />
                                                                <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="AlterRowStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Lease Code" ItemStyle-Width="120px" FooterStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Lease_Codes")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Totals
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Region" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Region")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Location" ItemStyle-Width="180px" FooterStyle-Width="180px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Location")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="180px" FooterStyle-Width="180px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Address")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="City" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("City")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="State" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("State")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Zip" ItemStyle-Width="120px" FooterStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Zip_Code")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Primary Use" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("PrimaryUse")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rentable Are" FooterStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Total_Gross_Leaseable_Area","{0:N0}")%>&nbsp;&nbsp;
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lease Type" ItemStyle-Width="150px" FooterStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Lease_Type")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Leasee" ItemStyle-Width="180px" FooterStyle-Width="180px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Landlord")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LCD" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Lease_Commencement_Date") != DBNull.Value ? Convert.ToDateTime(Eval("Lease_Commencement_Date")) == System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Eval("Lease_Commencement_Date", "{0:MM/dd/yyyy}") : ""%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LED" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Lease_Expiration_Date") != DBNull.Value ? Convert.ToDateTime(Eval("Lease_Expiration_Date")) == System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Eval("Lease_Expiration_Date", "{0:MM/dd/yyyy}") : ""%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lease Term" ItemStyle-Width="120px" FooterStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Lease_Term_Months")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Renew Options" ItemStyle-Width="250px" FooterStyle-Width="250px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Renew_Options")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cancel Options" ItemStyle-Width="250px" FooterStyle-Width="250px">
                                                                        <ItemTemplate>
                                                                            <%# Eval("Cancel_Options")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <table width="2800px" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="left">
                                                            <table width="2800px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;
                                                                background-color: #507CD1; color: White;" id="tblFooter" runat="server">
                                                                <tr>
                                                                    <td align="left" style="width: 120px">
                                                                        Grand Total :
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                        <asp:Label ID="lblGrandTotal" runat="server" />
                                                                    </td>
                                                                    <td align="left" style="width: 180px">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" style="width: 180px">
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                    </td>
                                                                    <td align="left" style="width: 120px">
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                    </td>
                                                                    <td align="right" style="width: 150px">
                                                                        <asp:Label ID="lblTotalRentableArea" runat="server" />&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" style="width: 150px">
                                                                    </td>
                                                                    <td align="left" style="width: 180px">
                                                                    </td>
                                                                    <td align="left" style="width: 100px">
                                                                    </td>
                                                                    <td align="left" style="width: 100px">
                                                                    </td>
                                                                    <td align="left" style="width: 120px">
                                                                    </td>
                                                                    <td align="left" style="width: 250px">
                                                                    </td>
                                                                    <td align="left" style="width: 250px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No record found.
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
    </table>
</asp:Content>
