<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_AP_FE_Transactions.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_AP_FE_Transactions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Fraud Event Transactions Audit Trail</title>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

//            divHeader.style.width = window.screen.availWidth - 325 + "px";
//            divGrid.style.width = window.screen.availWidth - 325 + "px";
            divHeader.style.width = "1141px";
            divGrid.style.width = "1141px";

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
    <div>
        <table width="100%" align="left">        
            <tr>
                <td align="left">
                    <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true" Text="Fraud Event Transactions Audit Trail"></asp:Label>
                </td>
                <td align="right">
                    <a href="javascript:window.close();">Close Window</a>
                </td>
            </tr>        
            <tr>
                <td colspan="2" >
                    <div style="overflow: hidden; width: 1141px;" id="divAP_FE_Transaction_Audit_Header" runat="server">                      
                        <table cellpadding="4" cellspacing="0" style="width: 1077px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Transaction Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Transaction Category</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Transaction Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Transaction Amount</span>
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
                    <div style="overflow: scroll; width: 1141; height: 400px;" id="divAP_FE_Transaction_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvAP_AL_FROIs_Audit" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Transaction_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Transaction_Type" runat="server" Text='<%#Eval("FK_LU_Transaction_Type")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Transaction_Category">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Transaction_Category" runat="server" Text='<%#Eval("FK_LU_Transaction_Category")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTransaction_Date" runat="server" Text='<%#Eval("Transaction_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Transaction_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction_Amount">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTransaction_Amount" runat="server" Text='<%#string.Format("{0:C2}",Eval("Transaction_Amount"))%>'
                                            Width="160px"></asp:Label>
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
