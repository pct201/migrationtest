<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptCriticalDates.aspx.cs" Inherits="SONIC_RealEstate_rptCriticalDates" %>

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
            <td align="left" class="ghc">Critical Dates
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table width="63%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                    border="0">
                    <tr valign="top" align="left">
                        <td>Region
                        </td>
                        <td align="right">:
                        </td>
                        <td>
                            <asp:ListBox ID="ddlRegion" runat="server" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>Market
                        </td>
                        <td align="right">:
                        </td>
                        <td>
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td style="width: 20%;">LCD From
                        </td>
                        <td align="right" style="width: 3%;">:
                        </td>
                        <td style="width: 37%;">
                            <asp:TextBox ID="txtLCDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date From" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvtxtLCDateFrom" runat="server" ControlToValidate="txtLCDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 7%;">&nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right" style="width: 3%;">:
                        </td>
                        <td style="width: 30%;">
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
                        <td>LED From
                        </td>
                        <td align="right">:
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
                        <td>&nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right">:
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
                    <tr>
                        <td align="left" valign="top">Building Status
                        </td>
                        <td align="right" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstBuildingStatus" runat="server" Width="170px" Rows="4" SelectionMode="Multiple">
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                            </asp:ListBox>
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
                <table cellpadding="0" cellspacing="0" width="90%" align="center">
                    <tr>
                        <td width="100%" align="left">
                            <div id="dvGrid" runat="server" visible="false">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td align="right">
                                            <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 15px;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden; text-align: left; width: 950px;">
                                                <asp:GridView ID="gvDBA" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                    Width="1825px" EnableTheming="false" HorizontalAlign="Left" CellPadding="0" CellSpacing="0"
                                                    GridLines="None" CssClass="GridClass" EmptyDataText="No Record Found" OnRowDataBound="gvDBA_RowDataBound"
                                                    OnRowCreated="gvDBA_RowCreated" Style="word-wrap: normal; word-break: break-all;">
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                    <FooterStyle CssClass="FooterStyle" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="18px" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold;" id="tblHeader"
                                                                    runat="server">
                                                                    <tr>
                                                                        <td width="100px" align="left">LED
                                                                        </td>
                                                                        <td width="180px" align="left">Location
                                                                        </td>
                                                                        <td width="560px" align="left">
                                                                            <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold;" id="tblBLHeader"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td width="40%" align="left">Building Address
                                                                                    </td>
                                                                                    <td width="30%" align="left">Building Number
                                                                                    </td>
                                                                                    <td width="30%" align="left">Building Landlord Name
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td width="100px" align="left">LCD
                                                                        </td>
                                                                        <td width="100px" align="left">LL Notify Date
                                                                        </td>
                                                                        <td width="100px" align="left">Reminder Date
                                                                        </td>
                                                                        <td width="100px" align="left">Review Date
                                                                        </td>
                                                                        <td width="100px" align="right">Monthly Rent
                                                                        </td>
                                                                        <td width="380px" align="left">Renewals
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table cellpadding="4" cellspacing="0" id="tblDetails" runat="server">
                                                                    <tr>
                                                                        <td align="left" style="width: 100px" valign="top">
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("LED"))%>
                                                                        </td>
                                                                        <td align="left" style="width: 180px" valign="top">
                                                                            <%# Eval("DBA") %>
                                                                        </td>
                                                                        <td align="left" style="width: 560px" valign="top">
                                                                            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                EmptyDataText="" GridLines="None" EnableTheming="false" CssClass="GridClass"
                                                                                CellPadding="4" ShowHeader="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="40%" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <%# (Eval("Address")) %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="30%" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblBUILDING_NUMBER" runat="server" Text='<%# Eval("Building_Number") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="30%" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLandlord_Name" runat="server" Text='<%# Eval("Landlord_Name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <td align="left" style="width: 100px" valign="top">
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("LCD"))%>
                                                                        </td>
                                                                        <td align="left" style="width: 100px" valign="top">
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("LLNotifyDate"))%>
                                                                        </td>
                                                                        <td align="left" style="width: 100px" valign="top">
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("ReminderDate"))%>
                                                                        </td>
                                                                        <td align="left" style="width: 100px" valign="top">
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("ReviewDate"))%>
                                                                        </td>
                                                                        <td align="right" style="width: 100px" valign="top">
                                                                            <%# string.Format("{0:N2}", Eval("MonthlyRent"))%>
                                                                        </td>
                                                                        <td align="left" style="width: 380px;" valign="top">
                                                                            <%#Eval("Renewals")%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold; background-color: #507CD1; color: White;"
                                                                    id="tblFooter" runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <table style="font-weight: bold; background-color: #507CD1; color: White;">
                                                                                <tr>
                                                                                    <td width="100px" align="left">Report Grand Totals
                                                                                    </td>
                                                                                    <td width="180px" align="left">
                                                                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td width="760px" align="left" colspan="3">&nbsp;
                                                                                    </td>
                                                                                    <td width="100px" align="left">&nbsp;
                                                                                    </td>
                                                                                    <td width="100px" align="left">&nbsp;
                                                                                    </td>
                                                                                    <td width="100px" align="left">&nbsp;
                                                                                    </td>
                                                                                    <td width="100px" align="left">&nbsp;
                                                                                    </td>
                                                                                    <td width="100px" align="right">
                                                                                        <asp:Label ID="lblMonthlyRent" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td width="340px" align="left">&nbsp;
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
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
