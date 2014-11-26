<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptInspectionLagTime.aspx.cs" Inherits="SONIC_Exposures_rptInspectionLagTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage" />
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 350;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                Inspection Distribution Lag Time
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr runat="server" id="trSearch">
            <td align="center">
                <table cellpadding="3" cellspacing="2" border="0" width="80%">
                    <tr>
                        <td align="left" valign="top" width="15%">
                            Region
                        </td>
                        <td align="center" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                        <td align="left" valign="top" width="15%">
                            Location D/B/A
                        </td>
                        <td align="center" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:ListBox ID="lstLocationDBA" runat="server" SelectionMode="Multiple" ToolTip="Select Location DBA"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Inspector Name
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top" colspan="4">
                            <asp:TextBox ID="txtInspectorName" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Inspection Date From
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtInspectionDateFrom" runat="server" SkinID="txtdate" MaxLength="10"
                                Width="190px">
                            </asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInspectionDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvStartDateFrom" runat="server" ControlToValidate="txtInspectionDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Inspection Date - From Is Not Valid" Display="none" ValidationGroup="vsErrorGroup">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td align="left" valign="top">
                            Inspection Date To
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtInspectionDateTo" runat="server" SkinID="txtdate" MaxLength="10"
                                Width="190px">
                            </asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInspectionDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:CompareValidator ID="cbDate" runat="server" ErrorMessage="Inspection Date - From  Must Be Less Than Inspection Date To."
                                ControlToCompare="txtInspectionDateFrom" Type="Date" ValidationGroup="vsErrorGroup"
                                Operator="GreaterThanEqual" ControlToValidate="txtInspectionDateTo" Display="none">
                            </asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="rvStartDateTo" runat="server" ControlToValidate="txtInspectionDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Inspection Date - To Is Not Valid" Display="none" ValidationGroup="vsErrorGroup">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                    <td align="left" valign="top" width="15%">
                            Inspection Area
                        </td>
                        <td align="center" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:ListBox ID="lstInspectionArea" runat="server" SelectionMode="Multiple" ToolTip="Select Inspection Area"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                        <td align="left" valign="top">
                            Lag Time in Days
                        </td>
                        <td align="center" valign="top">:</td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstLagTimeDays" runat="server" SelectionMode="Multiple" Width="220px" Rows="5">
                                <asp:ListItem Text="<=2" Value="1" />
                                <asp:ListItem Text="3 to 5" Value="2" />
                                <asp:ListItem Text="6 to 10" Value="3" />
                                <asp:ListItem Text="11 to 15" Value="4" />
                                <asp:ListItem Text=">15" Value="5" />
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trResult" visible="false">
            <td align="center">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr valign="middle">
                        <td align="right" width="100%">
                            <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr id="trGrid" runat="server">
                        <td align="left">
                            <asp:GridView ID="gvInspection" EnableTheming="false" runat="server" AutoGenerateColumns="false" Width="100%"
                                HorizontalAlign="Left" GridLines="None" EmptyDataText="No Record Found !" CellPadding="4"
                                CellSpacing="0">
                                <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                <FooterStyle ForeColor="Black" Font-Bold="true" />
                                <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" Font-Bold="true" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Region" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%#Eval("Region") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspector" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%#Eval("Inspector_Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location D/B/A" ItemStyle-Width="18%">
                                        <ItemTemplate>
                                            <%#Eval("DBA")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Inspection Area" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <%#Eval("Fld_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Date" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("date"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Inspection Report was Initially Distributed" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Report_Initially_Distibuted"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lag Time in Days" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <%# string.Format("{0:N0}", Eval("Lag_Time"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Found !
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
