<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_OwnershipDetail_Owned.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_OwnershipDetail_Leased" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Building_Ownership Audit Trail</title>
</head>

<script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        divHeader.style.width = window.screen.availWidth - 225 + "px";
        divGrid.style.width = window.screen.availWidth - 225 + "px";
        
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
                    <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">PK_Building_Ownership_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">FK_Building_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Owner_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Owner_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Owner_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Owner_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Owner_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Owner_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvOwnershipDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                                <asp:TemplateField HeaderText="PK_Building_Ownership_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Building_Ownership_ID" runat="server" Text='<%# Eval("PK_Building_Ownership_ID") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Building_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Building_ID" runat="server" Text='<%# Eval("Building_Number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_Name" runat="server" Text='<%# Eval("Owner_Name") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_Address_1" runat="server" Text='<%# Eval("Owner_Address_1") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_Address_2" runat="server" Text='<%# Eval("Owner_Address_2") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_City" runat="server" Text='<%# Eval("Owner_City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_State" runat="server" Text='<%# Eval("Owner_State") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_Zip" runat="server" Text='<%# Eval("Owner_Zip") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Eval("User_Name") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Updated_Date"))) %>'
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
