<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptMonthlyExpenseByLocation.aspx.cs"
    Inherits="SONIC_RealEstate_rptMonthlyExpenseByLocation" Title="eRIMS Sonic ::  Monthly Expense By Location" %>

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
                Monthly Expense By Location
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
                                                                        <td colspan="2" align="left">
                                                                            Sonic Automotive
                                                                        </td>
                                                                        <td colspan="4" align="center">
                                                                            Monthly Expense By Location
                                                                        </td>
                                                                        <td colspan="11" align="right">
                                                                            <%#System.DateTime.Now %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="HeaderStyle" valign="bottom" align="left">
                                                                        <td style="width: 130px">
                                                                            Location
                                                                        </td>
                                                                        <td style="width: 150px">
                                                                            Address
                                                                        </td>
                                                                        <td style="width: 130px">
                                                                            Region
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            Subtenant
                                                                        </td>
                                                                        <td align="right" style="width: 90px">
                                                                            Rentable Area
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.Month, true) + "-" + DateTime.Today.ToString("yy") %>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(1).Month, true) + "-" + DateTime.Now.AddMonths(1).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(2).Month, true) + "-" + DateTime.Now.AddMonths(2).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(3).Month, true) + "-" + DateTime.Now.AddMonths(3).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(4).Month, true) + "-" + DateTime.Now.AddMonths(4).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(5).Month, true) + "-" + DateTime.Now.AddMonths(5).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(6).Month, true) + "-" + DateTime.Now.AddMonths(6).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(7).Month, true) + "-" + DateTime.Now.AddMonths(7).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(8).Month, true) + "-" + DateTime.Now.AddMonths(8).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(9).Month, true) + "-" + DateTime.Now.AddMonths(9).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(10).Month, true) + "-" + DateTime.Now.AddMonths(10).ToString("yy")%>
                                                                        </td>
                                                                        <td align="right" style="width: 110px; mso-number-format: 'mmm\\-yy';">
                                                                            <%# Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(11).Month, true) + "-" + DateTime.Now.AddMonths(11).ToString("yy")%>
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
                                                                <b>&nbsp;Location :
                                                                    <asp:Label ID="lblRegion" runat="server"><%#Eval("DBA")%></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                                    Width="1920px" CellPadding="4" CellSpacing="0" EmptyDataText="No Record Found !"
                                                                    EnableTheming="false" GridLines="None" OnRowDataBound="gvDetail_RowDataBound"
                                                                    ShowHeader="false">
                                                                    <RowStyle CssClass="RowStyle" VerticalAlign="Top" />
                                                                    <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="Top" />
                                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                                    <Columns>
                                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("DBA") %>' Width="130px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotal" runat="server" Text="Sub Total"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAddress" runat="server" Width="150px"> </asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRegion" runat="server" Width="130px" Text='<%# Eval("Region") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Subtenant_DBA" runat="server" Width="100px" Text='<%# Eval("Subtenant_DBA")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Leaseable_Area" runat="server" Width="90px" Text='<%# string.Format("{0:N0}", Eval("Leaseable_Area"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblLeaseable_Area" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMonth_1" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_1"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth1" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_2" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_2"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth2" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_3" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_3"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth3" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_4" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_4"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth4" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_5" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_5"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth5" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_6" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_6"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth6" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_7" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_7"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth7" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_8" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_8"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth8" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_9" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_9"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth9" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_10" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_10"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth10" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_11" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_11"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth11" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Month_12" runat="server" Width="110px" Text='<%# string.Format("{0:C2}", Eval("Month_12"))%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalMonth12" runat="server"></asp:Label>
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
                                                                <table cellpadding="4" cellspacing="0" width="100%" id="tblFooter" runat="server"
                                                                    style="font-weight: bold; background-color: #507cd1; color: White">
                                                                    <tr align="left">
                                                                        <td style="width: 130px;">
                                                                            Grand Total
                                                                        </td>
                                                                        <td style="width: 150px">
                                                                            <asp:Label ID="lblTotalClaimCount" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 130px">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="right" style="width: 90px">
                                                                            <asp:Label ID="lblGrandTotalRentableArea" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth1" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth2" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth3" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth4" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth5" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth6" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth7" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth8" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth9" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth10" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth11" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="width: 110px">
                                                                            <asp:Label ID="lblGTotalMonth12" runat="server"></asp:Label>
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
