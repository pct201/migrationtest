<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="rptLeaseTerm.aspx.cs"
    Inherits="SONIC_RealEstate_rptLeaseTerm" Title="eRIMS Sonic :: Lease Term" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage"></asp:ValidationSummary>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="ghc">
                Lease Term
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
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"
                                    Visible="false"></asp:LinkButton>&nbsp;
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
                                    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                        Width="1150px" CellPadding="4" CellSpacing="0" OnRowCreated="gvReport_RowCreated"
                                        EnableTheming="false" GridLines="None">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="left" CssClass="HeaderStyle" />
                                        <RowStyle CssClass="RowStyle" VerticalAlign="Top" />
                                        <AlternatingRowStyle CssClass="AlterStyle" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" CssClass="FooterStyle" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="LL Notify Date" ItemStyle-VerticalAlign="Top" ItemStyle-Width="85px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLandlord_Notification_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Landlord_Notification_Date")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Grand Total
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location" ItemStyle-VerticalAlign="Top" ItemStyle-Width="130px"
                                                FooterStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# Eval("DBA") %>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Region" ItemStyle-VerticalAlign="Top" ItemStyle-Width="90px">
                                                <ItemTemplate>
                                                    <%# Eval("Region") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lease Type" ItemStyle-VerticalAlign="Top" ItemStyle-Width="125px">
                                                <ItemTemplate>
                                                    <%# Eval("LU_Lease_Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rentable Area" ItemStyle-VerticalAlign="Top" ItemStyle-Width="90px"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <%# string.Format("{0:N0}", Eval("Total_Gross_Leaseable_Area"))%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblLeaseable_Area" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LCD" ItemStyle-VerticalAlign="Top" ItemStyle-Width="75px">
                                                <ItemTemplate>
                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Commencement_Date"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Prior Lease Commencement Date" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Prior_Lease_Commencement_Date"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LED" ItemStyle-VerticalAlign="Top" ItemStyle-Width="75px">
                                                <ItemTemplate>
                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Expiration_Date"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lease Term" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# string.Format("{0:N0}",Eval("Lease_Term_Months"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Renew/ Cancel Option" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-Width="300px">
                                                <ItemTemplate>
                                                    <%# "<b>Cancel Options</b> " + Eval("Cancel_Options") + "<br style='mso-data-placement:same-cell;'>" + "<b>Renew Options</b> " + Eval("Renew_Options")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Records found!
                                        </EmptyDataTemplate>
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
