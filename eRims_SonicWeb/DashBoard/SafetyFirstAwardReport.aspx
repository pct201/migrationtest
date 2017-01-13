<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="SafetyFirstAwardReport.aspx.cs" Inherits="DashBoard_SafetyFirstAwardReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" border="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
                Risk Management Playbook Scorecard
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="60%" cellpadding="5" cellspacing="1" border="0">
                    <tr>
                        <td align="right" valign="top" width="25%">
                            Year
                        </td>
                        <td align="center" valign="top" width="5%">
                            :&nbsp;
                        </td>
                        <td align="left" width="65%">
                            <asp:DropDownList ID="ddlYear" runat="server" Width="245px" SkinID="dropGen">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="25%">
                            Regions
                        </td>
                        <td align="center" valign="top" width="5%">
                            :&nbsp;
                        </td>
                        <td align="left" width="65%">
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="250px"
                                Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="25%">
                            Market
                        </td>
                        <td align="center" valign="top" width="5%">
                            :&nbsp;
                        </td>
                        <td align="left" width="65%">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="250px"
                                Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" height="10px">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" ID="btnShowReport" Text="Generate Report" OnClick="btnShowReport_Click"
                    CausesValidation="true" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                    OnClick="btnClearCriteria_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr id="trGrid" runat="server" visible="false">
            <td align="left">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div style="overflow: scroll; width: 997px;" id="dvGrid" runat="server">
                                <asp:GridView ID="gvSafetyFirstAwardReport" EnableTheming="false" DataKeyNames="dba"
                                    runat="server" AutoGenerateColumns="false" Width="1700px" HorizontalAlign="Left"
                                    GridLines="None" ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found"
                                    CellPadding="4" CellSpacing="1" OnRowDataBound="gvSafetyFirstAwardReport_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                    <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="1700px" cellpadding="1" cellspacing="0" border="0">
                                                    <tr>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                        <td colspan="5" align="center">
                                                            <b>Risk Management Playbook Scorecard</b>
                                                        </td>
                                                        <td align="right" colspan="3">
                                                            <b><%= DateTime.Today.ToString("MM/dd/yyyy") %></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="200px">
                                                            Region
                                                        </td>
                                                        <td align="left" width="200px">
                                                            Location D/B/A
                                                        </td>
                                                        <td align="center" width="200px">
                                                            Safety Leadership Team Score
                                                        </td>
                                                        <td align="center" width="150px">
                                                            Facility Inspection Score
                                                        </td>
                                                        <td align="center" width="150px">
                                                            Safety Training Score
                                                        </td>
                                                        <td align="center" width="170px">
                                                            Incident Investigation Score
                                                        </td>
                                                        <td align="center" width="180px">
                                                            W.C. Claims Management Score
                                                        </td>
                                                        <td align="center" width="150px">
                                                            Incident Reduction Score
                                                        </td>
                                                        <td align="center" width="150px">
                                                            Total Aggregate Score
                                                        </td>
                                                        <%--<td align="center" width="150px">
                                                            Resulting Score
                                                        </td>--%>
                                                        <td align="center" width="150px">
                                                            Final Playbook Scorecard (100 Point Program)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="1700px" cellpadding="1" cellspacing="0" border="0" id="tblItem" runat="server">
                                                    <tr>
                                                        <td align="left" width="200px">
                                                            <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Region")%>'></asp:Label>
                                                        </td>
                                                        <td align="left" width="200px">
                                                            <%#Eval("DBA")%>
                                                        </td>
                                                        <td align="center" width="200px">
                                                            <%#Eval("SLT_Score")%>
                                                        </td>
                                                        <td align="center" width="150px">
                                                            <%#Eval("FI_Score")%>
                                                        </td>
                                                        <td align="center" width="150px">
                                                            <%#Eval("SUT_Score")%>
                                                        </td>
                                                        <td align="center" width="170px">
                                                            <%#Eval("II_Score")%>
                                                        </td>
                                                        <td align="center" width="180px">
                                                            <%#Eval("WM_Score")%>
                                                        </td>
                                                        <td align="center" width="150px">
                                                            <%#Eval("IR_Score")%>
                                                        </td>
                                                        <td align="center" width="150px">
                                                            <asp:Label ID="lblTotalAggregateScore" runat="server" Text='<%#Eval("TotalScore") %>'></asp:Label>
                                                        </td>
                                                       <%-- <td align="center" width="150px" id="tdResult" runat="server">
                                                            <asp:Label ID="lblResultingScore" runat="server" Text=''></asp:Label>
                                                        </td>--%>
                                                         <td align="center" width="150px" id="tdScoreCard" runat="server">
                                                            <asp:Label ID="lblFinal_ScoreCard" runat="server" Text=''></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
