﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_ClaimNotesAP.aspx.cs"
    Inherits="SONIC_ClaimInfo_AuditPopup_ClaimNotesAP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System :: Notes Audit</title>
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
                <div style="overflow: hidden; width: 600px;" id="divPurchasing_Service_Contract_Header"
                    runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 100%; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">PK_AP_Notes</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Fk_Table</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Fk_Table_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Date of Note</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 430px;">Notes</span>
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
                <div style="overflow: scroll; width: 600px; height: 510px;" id="divPurchasing_Service_Contract_Grid"
                    runat="server">
                    <asp:GridView ID="gvPurchasing_Service_Contract" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="4" EnableTheming="True" EmptyDataText="No records found!"
                        ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime" SortExpression="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_AP_Notes" SortExpression="PK_AP_Notes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="PK_AP_Notes" runat="server" Text='<%# Bind("PK_AP_Notes") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fk_Table" SortExpression="Fk_Table">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Fk_Table" runat="server" Text='<%# Bind("Fk_Table") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fk_Table_Name" SortExpression="Fk_Table_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Fk_Table_Name" runat="server" Text='<%# Bind("Fk_Table_Name") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Note_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNote_Date" runat="server" Text='<%#Eval("Note_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Note_Date"))) : ""%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Note">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNote" runat="server" Text='<%#Eval("Note")%>' Width="430px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="User_Name" runat="server" Text='<%# Bind("USE_NAME") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date" SortExpression="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Update_Date"))) ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
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
