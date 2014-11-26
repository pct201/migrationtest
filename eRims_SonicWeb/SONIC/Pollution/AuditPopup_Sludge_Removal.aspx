<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Sludge_Removal.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_EPA_Inspections" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: PM Sludge Removal Audit Trail</title>
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
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Sludge Removal Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Sludge Removed By</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">TCLP Performed?</span>
                                </th>
                                 <th class="cols">
	                                <span style="display: inline-block;width:120px;">TCLP Conducted Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">TCLP On File?</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Notes</span>
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
                            <asp:TemplateField HeaderText="Sludge_Removal_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSludge_Removal_Date" runat="server" Text='<%#Eval("Sludge_Removal_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Sludge_Removal_Date"))) : ""%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sludge_Removed_By" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSludge_Removed_By" runat="server" Text='<%#Eval("Sludge_Removed_By")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="TCLP" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTCLP" runat="server" Text='<%#Eval("TCLP")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="TCLP_Conducted" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTCLP_Conducted" runat="server" Text='<%#Eval("TCLP_Conducted") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("TCLP_Conducted"))) : ""%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TCLP_On_File" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTCLP_On_File" runat="server" Text='<%#Eval("TCLP_On_File")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notes" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="300" CssClass="TextClip"></asp:Label>
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
