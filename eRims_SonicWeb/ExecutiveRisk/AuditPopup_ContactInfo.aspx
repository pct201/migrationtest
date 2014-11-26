<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_ContactInfo.aspx.cs" Inherits="ExecutiveRisk_AuditPopup_ContactInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Executive_Risk_Contacts Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divExecutive_Risk_Contacts_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">PK_Executive_Risk_Contacts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">FK_Executive_Risk</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Contact_Type</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 150px">Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Tel_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Addtess1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Address2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">FK_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Zip_Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Email</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">Cell_Phone</span>
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
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divExecutive_Risk_Contacts_Grid"
                        runat="server">
                        <asp:GridView ID="gvExecutive_Risk_Contacts" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_Executive_Risk_Contacts" SortExpression="PK_Executive_Risk_Contacts">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Executive_Risk_Contacts" runat="server" Text='<%# Bind("PK_Executive_Risk_Contacts") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Executive_Risk" SortExpression="FK_Executive_Risk">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Executive_Risk" runat="server" Text='<%# Bind("Claim_Number") %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact_Type" SortExpression="Contact_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Contact_Type" runat="server" Text='<%# Bind("Contact_Type") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact_Name" SortExpression="Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Contact_Name" runat="server" Text='<%# Bind("Contact_Name") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tel_Number" SortExpression="Tel_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Tel_Number" runat="server" Text='<%# Bind("Tel_Number") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Addtess1" SortExpression="Addtess1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Addtess1" runat="server" Text='<%# (Eval("Addtess1")) %>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address2" SortExpression="Address2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Address2" runat="server" Text='<%# Bind("Address2") %>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" SortExpression="City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="City" runat="server" Text='<%# Bind("City") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_State" SortExpression="FK_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_State" runat="server" Text='<%# Bind("FK_State") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zip_Code" SortExpression="Zip_Code">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Zip_Code" runat="server" Text='<%# Bind("Zip_Code") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Email" runat="server" Text='<%# Bind("Email") %>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cell_Phone" SortExpression="Cell_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cell_Phone" runat="server" Text='<%# Eval("Cell_Phone") %>'
                                            Width="90px"></asp:Label>
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
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Updated_Date"))) ? Convert.ToDateTime(Eval("Updated_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
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
