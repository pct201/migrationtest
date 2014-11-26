<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_AP_FE_Notes.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_AP_FE_Notes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Fraud Event Notes Audit Trail</title>
    <script language="javascript" type="text/javascript">
        //        function showAudit(divHeader, divGrid) {
        //            var divheight, i;

        //            divHeader.style.width = window.screen.availWidth - 757 + "px";
        //            divGrid.style.width = window.screen.availWidth - 757 + "px";

        //            divheight = divGrid.style.height;
        //            i = divheight.indexOf('px');

        //            if (i > -1)
        //                divheight = divheight.substring(0, i);
        //            if (divheight > (window.screen.availHeight - 450) && divGrid.style.height != "") {
        //                divGrid.style.height = window.screen.availHeight - 450;
        //            }
        //        }

        //        function ChangeScrollBar(f, s) {
        //            s.scrollTop = f.scrollTop;
        //            s.scrollLeft = f.scrollLeft;
        //        }
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
                    <div style="overflow: hidden; width: 783px;" id="divAP_FE_Notes_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Note Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 230px;">Note</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Updated By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px;">Update Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow-y: scroll; width: 783px; height: 350px" id="divAP_FE_Notes_Audit_Grid" runat="server">
                        <asp:GridView ID="gvAP_AL_FROIs_Audit" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Note_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNote_Date" runat="server" Text='<%#Eval("Note_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Note_Date"))) : ""%>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Note">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNote" runat="server" Text='<%#Eval("Note")%>' Width="230px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="130px"></asp:Label>
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
