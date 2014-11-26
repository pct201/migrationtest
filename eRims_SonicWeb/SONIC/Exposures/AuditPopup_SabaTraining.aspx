<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_SabaTraining.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_SabaTraining" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            if ((window.screen.availWidth - 225) < 1082) {
                var wd;
                divHeader.style.width = window.screen.availWidth - 225 + "px";
                divGrid.style.width = window.screen.availWidth - 225 + "px";
                wd = document.getElementById('lblUpdated_By').style.width;
                wd = wd.substring(0, wd.indexOf('px'))
                document.getElementById('lblUpdated_By').style.width = wd + 17;
            }

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
                <div style="overflow: hidden; width: 900px;" id="divSabaTraining_Audit_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 1240px; border-collapse: collapse;"
                        align="left">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">PK_Saba_Training</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px">FK_Property_COPE</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px">Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 90px">Year</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 90px">Quarter</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px">Number of Associates To Train</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px">Number of Associates Trained</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Update_Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span id="lblUpdated_By" style="display: inline-block; width: 167px">Updated_By</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 900px; height: 425px;" id="divSabaTraining_Audit_Grid"
                    runat="server">
                    <asp:GridView ID="gvSabaTraining_Audit" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false"
                        HorizontalAlign="Left">
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
                            <asp:TemplateField HeaderText="PK_Enviro_SabaTraining_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("PK_Property_COPE_Saba_Training") %>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Location_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("FK_Property_COPE") %>' Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date")) %>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Year") %>'
                                        Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quarter">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQuarter" runat="server" Text='<%# Eval("Quarter") %>'
                                        Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Number_of_Employees") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNumber_Trained" runat="server" Text='<%# Bind("Number_Trained") %>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date")) %>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("Updated_By") %>' Width="110px"></asp:Label>
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
