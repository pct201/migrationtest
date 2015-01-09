<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="rptSubspacesByLocation.aspx.cs"
    Inherits="SONIC_RealEstate_rptSubspacesByLocation" Title="eRIMS Sonic :: Subspaces By Location" %>

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
            <td align="left" class="ghc">
                Subspaces By Location
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="77%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                    border="0">
                    <tr valign="top" align="left">
                        <td>
                            Region
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="ddlRegion" runat="server" SelectionMode="Multiple" Width="100%">
                            </asp:ListBox>
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
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="100%">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Lease Type
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="ddlLeaseType" runat="server" Rows="4" SelectionMode="Multiple" Width="100%">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td style="width: 10%;">
                            LCD From
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 30%;">
                            <asp:TextBox ID="txtLCDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date From" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvtxtLCDateFrom" runat="server" ControlToValidate="txtLCDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 7%;">
                            &nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 47%;">
                            <asp:TextBox ID="txtLCDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date To" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLCDateTo" runat="server" ControlToValidate="txtLCDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD To is Not Valid Date." Display="none" SetFocusOnError="true"> 
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLCD" runat="server" ControlToCompare="txtLCDateFrom"
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
                            <asp:RegularExpressionValidator ID="revtxtLEDateFrom" runat="server" ControlToValidate="txtLEDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LED From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLEDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Lease Expiration Date To" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLEDateTo" runat="server" ControlToValidate="txtLEDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LED To is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLED" runat="server" ControlToCompare="txtLEDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtLEDateTo"
                                ErrorMessage="LED From Date must be Less Than Or Equal LED To Date." SetFocusOnError="true"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table width="77%" cellpadding="2" cellspacing="2">
                    <tr>
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
        <tr>
            <td>
                <div id="dvGrid" runat="server" visible="false">
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>&nbsp;
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
                                    <asp:GridView ID="gvReport" runat="server" Width="100%" OnRowDataBound="gvReport_RowDataBound"
                                        AutoGenerateColumns="false" EnableTheming="false" HorizontalAlign="Left" CellPadding="0"
                                        GridLines="None" ShowFooter="true" EmptyDataText="No Record Found" CssClass="gridclass">
                                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
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
                                                                        <td colspan="3" align="left">
                                                                            Sonic Automotive
                                                                        </td>
                                                                        <td colspan="4" align="center">
                                                                            Subspaces By Location
                                                                        </td>
                                                                        <td colspan="3" align="right">
                                                                            <%#System.DateTime.Now %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="left">
                                                                        <td style="width: 90px;">
                                                                            Region
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            Lease Type
                                                                        </td>
                                                                        <td align="right" style="width: 90px;">
                                                                            Rentable Area
                                                                        </td>
                                                                        <td style="width: 120px;">
                                                                            Subtenant DBA
                                                                        </td>
                                                                        <td style="width: 75px;">
                                                                            LED
                                                                        </td>
                                                                        <td style="width: 100px;">
                                                                            Prior Lease Commencement Date
                                                                        </td>
                                                                        <td style="width: 75px;">
                                                                            LCD
                                                                        </td>
                                                                        <td align="Right" style="width: 80px;">
                                                                            Subspaces Term
                                                                        </td>
                                                                        <td style="width: 300px;">
                                                                            Renew/ Cancel Option
                                                                        </td>
                                                                        <td style="width: 120px;">
                                                                            Landlord
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
                                                                <b> &nbsp;Location :
                                                                    <asp:Label ID="lblRegion" runat="server"><%#Eval("DBA")%></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                                    ShowHeader="false" Width="1175px" CellPadding="4" EmptyDataText="No Record Found !"
                                                                    EnableTheming="false" GridLines="None" CellSpacing="0" OnRowDataBound="gvDetail_RowDataBound">
                                                                    <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                                    <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                    <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top" />
                                                                    <FooterStyle Font-Bold="true" VerticalAlign="top" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Region" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region") %>' Width="90px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMsg" runat="server" Text="Sub Total "></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Lease Type" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LU_Lease_Type" runat="server" Text='<%# Eval("LU_Lease_Type")%>' Width="125px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalCount" runat="server" Text=""></asp:Label>
                                                                            </FooterTemplate>
                                                                            <FooterStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rentable Area" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right"
                                                                            FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Total_Gross_Leaseable_Area" runat="server" Text='<%# string.Format("{0:N0}", Eval("Total_Gross_Leaseable_Area"))%>'
                                                                                    Width="90px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblLeaseable_Area" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Subtenant DBA" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Subtenant_DBA" runat="server" Text='<%# Eval("Subtenant_DBA") %>'
                                                                                    Width="120px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="LED" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Lease_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Expiration_Date"))%>'
                                                                                    Width="75px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Prior Lease Commencement Date" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Prior_Lease_Commencement_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Prior_Lease_Commencement_Date"))%>'
                                                                                    Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="LCD" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Lease_Commencement_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Commencement_Date"))%>'
                                                                                    Width="75px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Subspaces Term" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Lease_Term_Months" runat="server" Text='<%# string.Format("{0:N0}", Eval("Lease_Term_Months"))%>'
                                                                                    Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Renew/ Cancel Option" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Options" runat="server" Width="300px"><%# "<b>Cancel Options</b> " + Eval("Cancel_Options") + "<br style='mso-data-placement:same-cell;'>" + "<b>Renew Options</b> " + Eval("Renew_Options")%>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Landlord" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLandlord" runat="server" Text='<%# Eval("Landlord") %>' Width="120px"></asp:Label>
                                                                            </ItemTemplate>
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
                                                                <table cellpadding="4" cellspacing="0" width="100%" id="tblFooter" runat="server"
                                                                    style="font-weight: bold; background-color: #507cd1; color: White">
                                                                    <tr align="left">
                                                                        <td style="width: 90px;">
                                                                            Grand Total
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            <asp:Label ID="lblTotalClaimCount" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 90px">
                                                                            <asp:Label ID="lblGrandTotalRentableArea" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td colspan="7">
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
