<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptSecurity.aspx.cs" Inherits="Administrator_rptSecurity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>

    <asp:ValidationSummary ID="vsLogAudit" runat="server" ValidationGroup="vsLogAudit"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td align="left" class="ghc">User Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlFilters" runat="server" Visible="false">
                    <table align="center" width="70%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" valign="top">User :
                            </td>
                            <td align="left">
                                <asp:ListBox ID="drpUser" Rows="7" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                                <%--<asp:DropDownList ID="drpUser" runat="server" Width="170px">
                                </asp:DropDownList>--%>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Location D/B/A :
                            </td>
                            <td align="left">
                                <asp:ListBox ID="drpLocation" Rows="7" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                                <%--<asp:DropDownList ID="drpUser" runat="server" Width="170px">
                                </asp:DropDownList>--%>
                            </td>
                            <td align="right" valign="top">Region :
                            </td>
                            <td align="left">
                                <asp:ListBox ID="drpRegion" Rows="7" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Market :
                            </td>
                            <td align="left">
                                <asp:ListBox ID="lstMarket" Rows="7" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                            </td>
                            <td align="right" valign="top"></td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center" height="40px" valign="bottom">
                                <asp:Button ID="btnReport" runat="server" ValidationGroup="vsLogAudit" Text="Generate Report"
                                    OnClick="btnReport_Click" />
                                &nbsp;<asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                    CausesValidation="false" OnClick="btnClearCriteria_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlReport" runat="server" Visible="false">
                    <table width="99%" align="center" cellpadding="2" cellspacing="1" border="0">
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="btnExcel" Text="Export To Excel" runat="server" OnClick="btnExcel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrReport" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td class="Spacer" style="height: 15px;"></td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 50px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

