<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PropertyFirstReport.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_PropertyFirstReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Property_FR Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divProperty_FR_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">PK_Property_FR_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Property_FR_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">FK_Location_Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">FK_Contact</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Reported_to_Sonic</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Fire</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Wind_Damage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Hail_Damage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Earth_Movement</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Flood</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Third_Party_Property_Damage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Property_Damage_by_Sonic_Associate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Environmental_Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Vandalism_To_The_Property</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft_Associate_Tools</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft_All_Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Of_Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Time_Of_Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Description_of_Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Damage_Building_Facilities_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Damage_Building_Facilities_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Damage_Equipment_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Damage_Equipment_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Product_Damage_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Damage_Product_Damage_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Damage_Parts_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Damage_Parts_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Salvage_Cleanup_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Damage_Salvage_Cleanup_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Decontamination_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Damage_Decontamination_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Electronic_Data_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Electronic_Data_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 270px">Damage_Service_Interruption_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 270px">Damage_Service_Interruption_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Damage_Payroll_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Damage_Payroll_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Loss_of_Sales_Est_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Damage_Loss_of_Sales_Actual_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Date_Cleanup_Complete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Date_Repairs_Complete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Date_Full_Service_Resumed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Date_Fire_Protection_Services_Resumed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Report_Complete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Claim_Closed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Complete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 177px">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divProperty_FR_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvProperty_FR_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Label1" SortExpression="Label1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Property_FR_ID" SortExpression="PK_Property_FR_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Property_FR_ID" runat="server" Text='<%# Eval("PK_Property_FR_ID") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property_FR_Number" SortExpression="Property_FR_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Property_FR_Number" runat="server" Text='<%# Eval("Property_FR_Number") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Location_Code" SortExpression="FK_Location_Code">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Location_Code" runat="server" Text='<%# Eval("FK_Location_Code") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Contact" SortExpression="FK_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Contact" runat="server" Text='<%# Eval("FK_Contact") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Reported_to_Sonic" SortExpression="Date_Reported_to_Sonic">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Reported_to_Sonic" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Reported_to_Sonic"))) ? Convert.ToDateTime(Eval("Date_Reported_to_Sonic")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire" SortExpression="Fire">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Fire" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Fire")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wind_Damage" SortExpression="Wind_Damage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Wind_Damage" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Wind_Damage")) %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hail_Damage" SortExpression="Hail_Damage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Hail_Damage" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Hail_Damage")) %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Earth_Movement" SortExpression="Earth_Movement">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Earth_Movement" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Earth_Movement")) %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood" SortExpression="Flood">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Flood" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Flood")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Third_Party_Property_Damage" SortExpression="Third_Party_Property_Damage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Third_Party_Property_Damage" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Third_Party_Property_Damage")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property_Damage_by_Sonic_Associate" SortExpression="Property_Damage_by_Sonic_Associate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Property_Damage_by_Sonic_Associate" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Property_Damage_by_Sonic_Associate")) %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Environmental_Loss" SortExpression="Environmental_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Environmental_Loss" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Environmental_Loss")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vandalism_To_The_Property" SortExpression="Vandalism_To_The_Property">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vandalism_To_The_Property" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Vandalism_To_The_Property")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_Associate_Tools" SortExpression="Theft_Associate_Tools">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_Associate_Tools" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Theft_Associate_Tools")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_All_Other" SortExpression="Theft_All_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_All_Other" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Theft_All_Other")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other" SortExpression="Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Other" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Other")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Of_Loss" SortExpression="Date_Of_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Of_Loss" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Of_Loss"))) ? Convert.ToDateTime(Eval("Date_of_Loss")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time_Of_Loss" SortExpression="Time_Of_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Time_Of_Loss" runat="server" Text='<%# Eval("Time_Of_Loss") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description_of_Loss" SortExpression="Description_of_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Description_of_Loss" runat="server" Text='<%# Eval("Description_of_Loss") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Building_Facilities_Est_Cost" SortExpression="Damage_Building_Facilities_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Building_Facilities_Est_Cost" runat="server" Text='<%# Eval("Damage_Building_Facilities_Est_Cost") %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Building_Facilities_Actual_Cost" SortExpression="Damage_Building_Facilities_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Building_Facilities_Actual_Cost" runat="server" Text='<%# Eval("Damage_Building_Facilities_Actual_Cost") %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Equipment_Est_Cost" SortExpression="Damage_Equipment_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Equipment_Est_Cost" runat="server" Text='<%# Eval("Damage_Equipment_Est_Cost") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Equipment_Actual_Cost" SortExpression="Damage_Equipment_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Equipment_Actual_Cost" runat="server" Text='<%# Eval("Damage_Equipment_Actual_Cost") %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Product_Damage_Est_Cost" SortExpression="Damage_Product_Damage_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Product_Damage_Est_Cost" runat="server" Text='<%# Eval("Damage_Product_Damage_Est_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Product_Damage_Actual_Cost" SortExpression="Damage_Product_Damage_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Product_Damage_Actual_Cost" runat="server" Text='<%# Eval("Damage_Product_Damage_Actual_Cost") %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Parts_Est_Cost" SortExpression="Damage_Parts_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Parts_Est_Cost" runat="server" Text='<%# Eval("Damage_Parts_Est_Cost") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Parts_Actual_Cost" SortExpression="Damage_Parts_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Parts_Actual_Cost" runat="server" Text='<%# Eval("Damage_Parts_Actual_Cost") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Salvage_Cleanup_Est_Cost" SortExpression="Damage_Salvage_Cleanup_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Salvage_Cleanup_Est_Cost" runat="server" Text='<%# Eval("Damage_Salvage_Cleanup_Est_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Salvage_Cleanup_Actual_Cost" SortExpression="Damage_Salvage_Cleanup_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Salvage_Cleanup_Actual_Cost" runat="server" Text='<%# Eval("Damage_Salvage_Cleanup_Actual_Cost") %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Decontamination_Est_Cost" SortExpression="Damage_Decontamination_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Decontamination_Est_Cost" runat="server" Text='<%# Eval("Damage_Decontamination_Est_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Decontamination_Actual_Cost" SortExpression="Damage_Decontamination_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Decontamination_Actual_Cost" runat="server" Text='<%# Eval("Damage_Decontamination_Actual_Cost") %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Electronic_Data_Est_Cost" SortExpression="Damage_Electronic_Data_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Electronic_Data_Est_Cost" runat="server" Text='<%# Eval("Damage_Electronic_Data_Est_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Electronic_Data_Actual_Cost" SortExpression="Damage_Electronic_Data_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Electronic_Data_Actual_Cost" runat="server" Text='<%# Eval("Damage_Electronic_Data_Actual_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Service_Interruption_Est_Cost" SortExpression="Damage_Service_Interruption_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Service_Interruption_Est_Cost" runat="server" Text='<%# Eval("Damage_Service_Interruption_Est_Cost") %>'
                                            Width="270px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Service_Interruption_Actual_Cost" SortExpression="Damage_Service_Interruption_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Service_Interruption_Actual_Cost" runat="server" Text='<%# Eval("Damage_Service_Interruption_Actual_Cost") %>'
                                            Width="270px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Payroll_Est_Cost" SortExpression="Damage_Payroll_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Payroll_Est_Cost" runat="server" Text='<%# Eval("Damage_Payroll_Est_Cost") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Payroll_Actual_Cost" SortExpression="Damage_Payroll_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Payroll_Actual_Cost" runat="server" Text='<%# Eval("Damage_Payroll_Actual_Cost") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Loss_of_Sales_Est_Cost" SortExpression="Damage_Loss_of_Sales_Est_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Loss_of_Sales_Est_Cost" runat="server" Text='<%# Eval("Damage_Loss_of_Sales_Est_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Loss_of_Sales_Actual_Cost" SortExpression="Damage_Loss_of_Sales_Actual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Loss_of_Sales_Actual_Cost" runat="server" Text='<%# Eval("Damage_Loss_of_Sales_Actual_Cost") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Cleanup_Complete" SortExpression="Date_Cleanup_Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Cleanup_Complete" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Cleanup_Complete")))  ? Convert.ToDateTime(Eval("Date_Cleanup_Complete")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Repairs_Complete" SortExpression="Date_Repairs_Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Repairs_Complete" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Repairs_Complete")))  ? Convert.ToDateTime(Eval("Date_Repairs_Complete")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Full_Service_Resumed" SortExpression="Date_Full_Service_Resumed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Full_Service_Resumed" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Full_Service_Resumed"))) ? Convert.ToDateTime(Eval("Date_Full_Service_Resumed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Fire_Protection_Services_Resumed" SortExpression="Date_Fire_Protection_Services_Resumed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Fire_Protection_Services_Resumed" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Fire_Protection_Services_Resumed")))  ? Convert.ToDateTime(Eval("Date_Fire_Protection_Services_Resumed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Comments" runat="server" Text='<%# Eval("Comments") %>' Width="400px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Report_Complete" SortExpression="Date_Report_Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Report_Complete" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Report_Complete"))) ? Convert.ToDateTime(Eval("Date_Report_Complete")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Claim_Closed" SortExpression="Date_Claim_Closed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Claim_Closed" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Claim_Closed")))  ? Convert.ToDateTime(Eval("Date_Claim_Closed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Complete" SortExpression="Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Complete" runat="server" Text='<%# Eval("Complete") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Updated_By" runat="server" Text='<%# Eval("Updated_By") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date" SortExpression="Updated_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Updated_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Updated_Date"))) ? Convert.ToDateTime(Eval("Updated_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="160px"></asp:Label>
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
