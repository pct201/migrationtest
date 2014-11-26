<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Waste_Removal.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Waste_Removal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Waste Generator Audit Trail</title>
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
        if (divheight > (window.screen.availHeight - 480) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 480;
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Waste_Removal_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                 <%--<th class="cols" align="left">
                                    <span style="display: inline-block; width: 160px;">PK_PM_Waste_Removal</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 160px;">FK_PM_Site_Information</span>
                                </th>--%>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Waste Type</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Waste Hauler</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Receiving TSDF</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 200px;">Amount of Hazardous Waste Generated Per Month – in Pounds</span>
                                </th>
                                <%--<th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Units</span>
                                </th>--%>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Hazardous Waste Codes</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Start Date of Hazardous Waste Accumulation</span>
                                </th>
                                  <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Date of Last Hazardous Waste Removal</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 180px;">Hazardous Waste Profile Complete and Maintained at Location</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 180px;">Facility Generator Status</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 180px;">Discharge Limits</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 180px;">California Business Plan</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Updated By</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Waste_Removal_Grid"
                    runat="server">
                    <asp:GridView ID="gvPMWasteRemoval" runat="server" AutoGenerateColumns="False"
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
                             <%--<asp:TemplateField HeaderText="PK_PM_Waste_Removal">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_PM_Waste_Removal" runat="server" Text='<%#Eval("PK_PM_Waste_Removal")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_PM_Site_Information">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_Site_Information" runat="server" Text='<%#Eval("FK_PM_Site_Information")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="FK_LU_Waste_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Waste_Type" runat="server" Text='<%#Eval("FK_LU_Waste_Type")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_PM_Waste_Hauler">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_Waste_Hauler" runat="server" Text='<%#Eval("FK_PM_Waste_Hauler")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Receiving_TSDF">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Receiving_TSDF" runat="server" Text='<%#Eval("FK_Receiving_TSDF")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount_HW_Generated_Per_Month">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount_HW_Generated_Per_Month" runat="server" Text='<%#Eval("Amount_HW_Generated_Per_Month")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Units">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units")%>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_PM_Hazardous_Waste_Codes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_PM_Hazardous_Waste_Codes" runat="server" Text='<%#Eval("FK_LU_PM_Hazardous_Waste_Codes")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="HW_Accumulation_Start">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHW_Accumulation_Start" runat="server" Text='<%#Eval("HW_Accumulation_Start") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("HW_Accumulation_Start"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Last_HW_Removal">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_HW_Removal" runat="server" Text='<%#Eval("Last_HW_Removal") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Last_HW_Removal"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HW_Profile_Complete_And_Maintained">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHW_Profile_Complete_And_Maintained" runat="server" Text='<%#(Eval("HW_Profile_Complete_And_Maintained").ToString() == "N" ? "No" : "Yes")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Facility_Generator_Status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Facility_Generator_Status" runat="server" Text='<%#Eval("FK_LU_Facility_Generator_Status")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discharge_Limits">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDischarge_Limits" runat="server" Text='<%#Eval("Discharge_Limits")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="California_Business_Plan">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCalifornia_Business_Plan" runat="server" Text='<%#Eval("California_Business_Plan")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="120px"></asp:Label>
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
