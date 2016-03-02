<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Repair_And_Maint.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Repair_And_Maint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Repair_Maintenance Audit Trail</title>
</head>
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
                    <div style="overflow: hidden; width: 600px;" id="dvHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:250px;">PK_RE_Repair_Maintenance</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">FK_RE_Information</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:300px;">FK_LU_Responsibilie_Party_HVAC_Repairs</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:300px;">FK_LU_Responsibilie_Party_HVAC_Capital</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:300px;">FK_LU_Responsibilie_Party_Roof_Capital</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:300px;">FK_LU_Responsibilie_Party_Roof_Repairs</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:300px;">FK_LU_Responsibilie_Party_Other_Repairs</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:200px;">Maintenance_Notes</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Updated_By</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvRepair_Maintenance" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" >
	                                <ItemStyle CssClass="cols" Width="150px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="150px"></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_RE_Repair_Maintenance" >
	                                <ItemStyle CssClass="cols" Width="250px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblPK_RE_Repair_Maintenance" runat="server" Text='<%#Eval("PK_RE_Repair_Maintenance")%>' Width="250px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_RE_Information" >
	                                <ItemStyle CssClass="cols" width="150px"/>
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_RE_Information" runat="server" Text='<%#Eval("FK_RE_Information")%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Responsibilie_Party_HVAC_Repairs" >
	                                <ItemStyle CssClass="cols" width="300px"/>
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_LU_Responsibilie_Party_HVAC_Repairs" runat="server" Text='<%#Eval("FK_LU_Responsibilie_Party_HVAC_Repairs")%>' Width="300px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Responsibilie_Party_HVAC_Capital" >
	                                <ItemStyle CssClass="cols" width="300px"/>
	                                <ItemTemplate>
		                                <asp:Label ID="lbFK_LU_Responsibilie_Party_HVAC_Capital" runat="server" Text='<%#Eval("FK_LU_Responsibilie_Party_HVAC_Capital") %>' Width="300px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Responsibilie_Party_Roof_Capital" >
	                                <ItemStyle CssClass="cols" width="300px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_LU_Responsibilie_Party_Roof_Capital" runat="server" Text='<%#Eval("FK_LU_Responsibilie_Party_Roof_Capital") %>' Width="300px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Responsibilie_Party_Roof_Repairs" >
	                                <ItemStyle CssClass="cols" width="300px"/>
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_LU_Responsibilie_Party_Roof_Repairs" runat="server" Text='<%#Eval("FK_LU_Responsibilie_Party_Roof_Repairs")%>' Width="300px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Responsibilie_Party_Other_Repairs" >
	                                <ItemStyle CssClass="cols" width="300px"/>
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_LU_Responsibilie_Party_Other_Repairs" runat="server" Text='<%#Eval("FK_LU_Responsibilie_Party_Other_Repairs")%>' Width="300px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Maintenance_Notes" >
	                                <ItemStyle CssClass="cols" width="200px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblMaintenance_Notes" runat="server" Text='<%#Eval("Maintenance_Notes")%>' Width="200px" style="word-break:break-all;" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" >
	                                <ItemStyle CssClass="cols" Width="150px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("user_Name")%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date" >
	                                <ItemStyle CssClass="cols" Width="133px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>' Width="133px" ></asp:Label>
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

