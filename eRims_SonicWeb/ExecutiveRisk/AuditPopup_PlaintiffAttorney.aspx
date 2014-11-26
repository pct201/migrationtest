<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PlaintiffAttorney.aspx.cs"
    Inherits="ExecutiveRisk_AuditPopup_PlaintiffAttorney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Plaintiff_Attorney Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divDefense_Attorney_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">PK_Plaintiff_Attorney</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">FK_Executive_Risk</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Firm</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Zip_Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">E_Mail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Notes</span>
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
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divDefense_Attorney_Grid"
                        runat="server">
                        <asp:GridView ID="gvDefense_Attorney" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_Defense_Attorney" SortExpression="PK_Defense_Attorney">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Defense_Attorney" runat="server" Text='<%# Bind("PK_Plaintiff_Attorney") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Executive_Risk" SortExpression="FK_Executive_Risk">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Executive_Risk" runat="server" Text='<%# Bind("Claim_Number") %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Firm" SortExpression="Firm">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Firm" runat="server" Text='<%# Bind("Firm") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address_1" SortExpression="Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Address_1" runat="server" Text='<%# Bind("Address_1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address_2" SortExpression="Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Address_2" runat="server" Text='<%# (Eval("Address_2")) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" SortExpression="City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="City" runat="server" Text='<%# Bind("City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="State" runat="server" Text='<%# Bind("State") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zip_Code" SortExpression="Zip_Code">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Zip_Code" runat="server" Text='<%# Bind("Zip_Code") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telephone" SortExpression="Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Telephone" runat="server" Text='<%# Bind("Telephone") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="E_Mail" SortExpression="E_Mail">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="E_Mail" runat="server" Text='<%# Bind("E_Mail") %>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Notes" runat="server" Text='<%# Bind("Notes") %>' CssClass="TextClip"
                                            Width="600px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Bind("User_Name") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date" SortExpression="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Update_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
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
