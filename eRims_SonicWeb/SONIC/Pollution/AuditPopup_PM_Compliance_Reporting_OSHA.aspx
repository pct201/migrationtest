<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Compliance_Reporting_OSHA.aspx.cs" Inherits="SONIC_Pollution_AuditPopup_PM_Compliance_Reporting_OSHA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 510 + "px";
        divGrid.style.width = window.screen.availWidth - 510 + "px";

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 450) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 450;
        }
    }

    function ChangeScrollBar(f, s) {
        s.scrollTop = f.scrollTop;
        s.scrollLeft = f.scrollLeft;
    }
</script>
<body>
    <form id="form1" runat="server">
        <table width="100%" align="left">
            <tr>
                <td align="left">
                    <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">
                    <a href="javascript:window.close();">Close Window</a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="overflow: hidden; width: 650px;" id="divComplianceReportingOSHA_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 650px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Date Completed</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Feb 1 Log Posting</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Number of Osha Recordable</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Number of lost Work Days</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Number of Restricted Work Days</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Total Number of Associates</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Updated By</span>
                                    </th>
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 150px;">Updated Date</span>
                                    </th>

                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 650px; height: 420px;" id="divComplianceReportingOSHA_Grid"
                        runat="server">
                        <asp:GridView ID="gvPMComplianceReportingOSHA" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Completed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkDate_Completed" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Completed")) %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Feb 1 Log Posting">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkLog_Posted_Feb_1" runat="server" Text='<%# Eval("Log_Posted_Feb_1").ToString() == "N" ? "No" : "Yes" %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number of Osha Recordable">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkOSHA_Recordable" runat="server" Text='<%# Eval("OSHA_Recordable").ToString() %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number of lost Work Days">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkLost_Work_Days" runat="server" Text='<%# Eval("Lost_Work_Days").ToString() %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number of Restricted Work Days">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkRestsricted_Work_Days" runat="server" Text='<%# Eval("Restsricted_Work_Days").ToString() %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Number of Associates">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkTotal_Associates" runat="server" Text='<%# Eval("Total_Associates").ToString() %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Updated_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Updated_Date"))) : ""%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
