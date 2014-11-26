<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_EPM-ProjectMilestone.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_EPM_ProjectMilestone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Project Milestone Audit Trail</title>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 325 + "px";
            divGrid.style.width = window.screen.availWidth - 325 + "px";

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
</head>
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
                <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 1217px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">EPM Milestone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Milestone Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Email Reminder</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px;">Use E-Mail List from Milestone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 1217px; height: 400px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvProjectMilestone" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_EPM_Milestone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_EPM_Milestone" runat="server" Text='<%#Eval("FK_LU_EPM_Milestone")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Width="300px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Milestone_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMilestone_Date" runat="server" Text='<%#Eval("Milestone_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Milestone_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email_Reminder">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail_Reminder" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("Email_Reminder"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_EPM_Milestone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_EPM_Milestone" runat="server" Text='<%#Eval("FK_EPM_Milestone")%>'
                                        Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
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
