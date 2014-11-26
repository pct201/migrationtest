<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_EPA.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_EPA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS :: EPA Audit Trail</title>

    <script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        if( (window.screen.availWidth - 225) < 1072)
        {
            var wd;
            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";
            wd = document.getElementById('lblUpdated_By').style.width;
            wd = wd.substring(0,wd.indexOf('px'))            
            document.getElementById('lblUpdated_By').style.width = wd + 17;
        }
        
        divheight = divGrid.style.height;        
        i = divheight.indexOf('px');        
        
        if(i > -1)        
            divheight = divheight.substring(0,i);
        if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "")
        {            
            divGrid.style.height = window.screen.availHeight - 350;
        }
    }
    
    function ChangeScrollBar(f,s)
    {
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
                    <div style="overflow: hidden; width: 1072px;" id="divEPA_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 1050px; border-collapse: collapse;"
                            align="left">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">PK_Enviro_EPA_ID</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">FK_LU_Location_ID</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Type</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">ID_Number</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Update_Date</span></th>
                                    <th class="cols">
                                        <span id="lblUpdated_By" style="display: inline-block; width: 110px">Updated_By</span></th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 1072px; height: 425px;" id="divEPA_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvEPA_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false" HorizontalAlign="Left">
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
                                <asp:TemplateField HeaderText="PK_Enviro_EPA_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PK_Enviro_Permit_ID") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("FK_LU_Location_ID") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Type") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ID_Number") %>' Width="180px"></asp:Label>
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
