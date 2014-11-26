<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_PI_Inventory.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_PI_Inventory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Paint Inventory Grid Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 515 + "px";
        divGrid.style.width = window.screen.availWidth - 515 + "px";

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 465) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 465;
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Permits_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>                                
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK Paint Inventory</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Supplier</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Date Purchased</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Amount Purchased</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Units</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Start Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">End Date</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Amount Used</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Ending Inventory</span>
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
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Permits_Grid"
                    runat="server">
                    <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                            <%--<asp:TemplateField HeaderText="FK_PM_CR_Paint_Inventory">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_CR_Paint_Inventory" runat="server" Text='<%#Eval("FK_PM_CR_Paint_Inventory")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Supplier">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("Supplier")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Purchased">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Purchased" runat="server" Text='<%#Eval("Date_Purchased") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Purchased"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount_Purchased">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount_Purchased" runat="server" Text='<%# string.Format("{0:N2}", Eval("Amount_Purchased"))%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Units">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Units" runat="server" Text='<%#Eval("Units")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStart_Date" runat="server" Text='<%#Eval("Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Start_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEnd_Date" runat="server" Text='<%#Eval("End_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("End_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount_Used">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount_Used" runat="server" Text='<%#string.Format("{0:N2}", Eval("Amount_Used"))%>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ending_Inventory">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnding_Inventory" runat="server" Text='<%#string.Format("{0:N2}", Eval("Ending_Inventory"))%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By1")%>' Width="100px"></asp:Label>
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
