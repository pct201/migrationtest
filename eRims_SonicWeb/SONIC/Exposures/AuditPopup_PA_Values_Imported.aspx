<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PA_Values_Imported.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_PA_Values_Imported" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/jscript">
        function showAudit_Financial(divHeader, divGrid) {
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

        function ChangeScrollBar_Financial(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
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
                        <div style="overflow-x: hidden; width: auto;" id="dvHeader" runat="server">
                            <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                        align="left">
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px;">Audit DateTime</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 100px">Sonic Location Code</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 200px">Sonic Location DBA</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Year</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Non Texas Payroll</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Texas Payroll</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Total Head Count</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px;">Updated By</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 117px;">Update Date</span>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div style="overflow-y: scroll; width: auto; height: 395px;" id="dvGrid" runat="server">
                            <asp:GridView ID="gvAP_Property_Security_Financials" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Audit_DateTime">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                            <asp:TemplateField HeaderText="FK_AP_Property_Security">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_AP_Property_Security" runat="server" Text='<%#Eval("FK_AP_Property_Security")%>'
                                        Width="130px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Sonic_Location_Code">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblSonic_Location_Code" runat="server" Text='<%#Eval("Sonic_Location_Code")%>'
                                                Width="100px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="dba">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbldba" runat="server" Text='<%#Eval("dba")%>'
                                                Width="200px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Year">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year")%>'
                                                Width="160px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Non_Texas_Payroll">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblNon_Texas_Payroll" runat="server" Text='<%#clsGeneral.FormatCommaSeperatorCurrency(Eval("Non_Texas_Payroll"))%>' Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Texas_Payroll">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTexas_Payroll" runat="server" Text='<%#clsGeneral.FormatCommaSeperatorCurrency(Eval("Texas_Payroll"))%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Number_Of_Employees">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumber_Of_Employees" runat="server" Text='<%#Eval("Number_Of_Employees")%>'
                                                Width="160px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Updated_By">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="160px"></asp:Label>
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
        </div>

    </form>
</body>
</html>
