<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PurchasingAssetInformation.aspx.cs" Inherits="SONIC_Purchasing_AuditPopup_PurchasingAssetInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Purchasing_Asset Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divPurchasingAssetInformation_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">PK_Purchasing_Asset</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Manufacturer</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Dealership Department </span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Serial Number</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 150px">Model Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Supplier</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Acquisition Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Useful Life in Months</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Acquisition Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divPurchasingAssetInformation_Grid"
                        runat="server">
                        <asp:GridView ID="gvPurchasingAssetInformation" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" SortExpression="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Purchasing_Asset" SortExpression="PK_Purchasing_Asset">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Purchasing_Asset" runat="server" Text='<%# Bind("PK_Purchasing_Asset") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Type" runat="server" Text='<%# Bind("Type") %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Manufacturer" SortExpression="FK_LU_Manufacturer">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_LU_Manufacturer" runat="server" Text='<%# Bind("FK_LU_Manufacturer") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Dealership_Department" SortExpression="FK_LU_Dealership_Department">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_LU_Dealership_Department" runat="server" Text='<%# Bind("FK_LU_Dealership_Department") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Serial_Number" SortExpression="Serial_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Serial_Number" runat="server" Text='<%# Bind("Serial_Number") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model_Number" SortExpression="Model_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Model_Number" runat="server" Text='<%# Bind("Model_Number") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier" SortExpression="Supplier">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Supplier" runat="server" Text='<%# Bind("Supplier") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acquisition_Date" SortExpression="Acquisition_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Acquisition_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Acquisition_Date"))) ? Convert.ToDateTime(Eval("Acquisition_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Useful_Life" SortExpression="Useful_Life">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Useful_Life" runat="server" Text='<%# Bind("Useful_Life") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acquisition_Cost" SortExpression="Acquisition_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Acquisition_Cost" runat="server" Text='<%# Bind("Acquisition_Cost") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location" SortExpression="FK_LU_Location">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_LU_Location" runat="server" Text='<%# (Eval("FK_LU_Location")) %>' Width="400px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Notes" runat="server" Text='<%# (Eval("Notes")) %>' Width="250px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Bind("Updated_By") %>' Width="110px"></asp:Label>
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
