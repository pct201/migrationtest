<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PropertyCOPE.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_PropertyCOPE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Property_COPE Audit Trail</title>
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
                                        <span style="display: inline-block; width: 150px">PK_Property_Cope_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">FK_LU_Location_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Status</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 150px">Status_As_Of_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Disposal_Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Union_shop</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px">Property_Boundary_Dimemsions</span>
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
                                        <span style="display: inline-block; width: 150px">State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px">Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px">Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Web_site</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Valuation_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 224px">Business_Interruption_Salaries</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 224px">Business_Interruption_Benefits</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 224px">Business_interruption_fixed_costs</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 224px">Business_interruption_net_profit</span>
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
                        <asp:GridView ID="gvProperty_COPE" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_Property_Cope_ID" >
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Property_COPE" runat="server" Text='<%# Eval("PK_Property_Cope_ID") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location_ID" >
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="dba" runat="server" Text='<%# Eval("dba") %>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" >
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status" runat="server" Text='<%# Eval("Status") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_As_Of_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_As_Of_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Status_As_Of_Date"))) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Disposal_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Disposal_Type" runat="server" Text='<%# Eval("Disposal_Type") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Union_shop">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Union_shop" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Union_shop")) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property_Boundary_Dimemsions">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Property_Boundary_Dimemsions" runat="server" Text='<%# Eval("Property_Boundary_Dimemsions") %>' Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Address_1" runat="server" Text='<%# Eval("Address_1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Address_2" runat="server" Text='<%# Eval("Address_2") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="City" runat="server" Text='<%# Eval("City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="State" runat="server" Text='<%# Eval("State") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Zip" runat="server" Text='<%# Eval("Zip") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Telephone" runat="server" Text='<%# Eval("Telephone") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Web_site">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Web_site" runat="server" Text='<%# Eval("Web_site") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valuation_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Valuation_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Valuation_Date"))) %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business_Interruption_Salaries">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Business_Interruption_Salaries" runat="server" Text='<%# Eval("Business_Interruption_Salaries") %>' Width="224px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business_Interruption_Benefits">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Business_Interruption_Benefits" runat="server" Text='<%# Eval("Business_Interruption_Benefits") %>' Width="224px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business_interruption_fixed_costs">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Business_interruption_fixed_costs" runat="server" Text='<%# Eval("Business_interruption_fixed_costs") %>' Width="224px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business_interruption_net_profit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Business_interruption_net_profit" runat="server" Text='<%# Eval("Business_interruption_net_profit") %>' Width="224px"></asp:Label>
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
