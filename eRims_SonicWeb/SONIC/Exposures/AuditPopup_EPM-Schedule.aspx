<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_EPM-Schedule.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_EPM_Schedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Schedule Audit Trail</title>
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
                    <table cellpadding="4" cellspacing="0" style="width: 1317px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Date to Consultant</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">RM Notification Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Estimated Project Start Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Actual Project Start Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Estimated Project Completion Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Actual Project Completion Date</span>
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
                <div style="overflow: scroll; width: 1317px; height: 400px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvSchedule" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                            <asp:TemplateField HeaderText="Date_To_Consultant">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_To_Consultant" runat="server" Text='<%#Eval("Date_To_Consultant") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_To_Consultant"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RM_Notification_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRM_Notification_Date" runat="server" Text='<%#Eval("RM_Notification_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("RM_Notification_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimated_Project_Start_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEstimated_Project_Start_Date" runat="server" Text='<%#Eval("Estimated_Project_Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estimated_Project_Start_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual_Project_Start_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblActual_Project_Start_Date" runat="server" Text='<%#Eval("Actual_Project_Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Project_Start_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimated_Project_Completion_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEstimated_Project_Completion_Date" runat="server" Text='<%#Eval("Estimated_Project_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estimated_Project_Completion_Date"))) : ""%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual_Project_Completion_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblActual_Project_Completion_Date" runat="server" Text='<%#Eval("Actual_Project_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Project_Completion_Date"))) : ""%>'
                                        Width="200px"></asp:Label>
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
