<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_DPDFirstReport.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_DPDFirstReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: DPD_FR Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divDPD_FR_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 180px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">PK_DPD_FR_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">FK_Contact</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">DPD_FR_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">FK_Loss_Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Loss_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Loss_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Loss_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Loss_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Loss_ZipCode</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Time_of_Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Reported_To_Sonic</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Of_Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">On_Company_Property</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft_Make</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft_Model</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft_Year</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Theft_VIN</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Vehicle_Invoice_Value</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Vehicle_Recovered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Theft_Vehicle_Damage_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Theft_Dealership_Wish_To_Take_Possession</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Partial_Theft</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Partial_Theft_Number_of_Vehicles_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Parial_Theft_Damage_Estimate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Vandalism</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Vandalism_Number_of_Vehicles_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Vandalism_Total_Estimate_of_Damages</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">MVA_Single</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">MVA_Multiple</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Hail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Hail_Number_Of_Vehicles_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Hail_Damage_Estimate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Flood</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Flood_Number_Of_Vehicles_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Flood_Damage_Estimate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Fire</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Fire_Number_Of_Vehicles_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Fire_Damage_Estimate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Wind</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 260px">Wind_Number_Of_Vehicles_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Wind_Damage_Estimate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">Fraud</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Complete</span>
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
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divDPD_FR_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvDPD_FR_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Label1" SortExpression="Label1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_DPD_FR_ID" SortExpression="PK_DPD_FR_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_DPD_FR_ID" runat="server" Text='<%# Eval("PK_DPD_FR_ID") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Contact" SortExpression="FK_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Contact" runat="server" Text='<%# Eval("FK_Contact") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DPD_FR_Number" SortExpression="DPD_FR_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="DPD_FR_Number" runat="server" Text='<%# Eval("DPD_FR_Number") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Loss_Location" SortExpression="FK_Loss_Location">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Loss_Location" runat="server" Text='<%# Eval("FK_Loss_Location") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loss_Address_1" SortExpression="Loss_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Loss_Address_1" runat="server" Text='<%# Eval("Loss_Address_1") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loss_Address_2" SortExpression="Loss_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Loss_Address_2" runat="server" Text='<%# Eval("Loss_Address_2") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loss_City" SortExpression="Loss_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Loss_City" runat="server" Text='<%# Eval("Loss_City") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loss_State" SortExpression="Loss_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Loss_State" runat="server" Text='<%# Eval("Loss_State") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loss_ZipCode" SortExpression="Loss_ZipCode">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Loss_ZipCode" runat="server" Text='<%# Eval("Loss_ZipCode") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time_of_Loss" SortExpression="Time_of_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Time_of_Loss" runat="server" Text='<%# Eval("Time_of_Loss") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Reported_To_Sonic" SortExpression="Date_Reported_To_Sonic">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Reported_To_Sonic" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Reported_To_Sonic"))) ? Convert.ToDateTime(Eval("Date_Reported_To_Sonic")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Of_Loss" SortExpression="Date_Of_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Of_Loss" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Of_Loss"))) ? Convert.ToDateTime(Eval("Date_Of_Loss")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="On_Company_Property" SortExpression="On_Company_Property">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="On_Company_Property" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("On_Company_Property")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft" SortExpression="Theft">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("Theft")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_Make" SortExpression="Theft_Make">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_Make" runat="server" Text='<%# Eval("Theft_Make") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_Model" SortExpression="Theft_Model">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_Model" runat="server" Text='<%# Eval("Theft_Model") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_Year" SortExpression="Theft_Year">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_Year" runat="server" Text='<%# Eval("Theft_Year") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_VIN" SortExpression="Theft_VIN">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_VIN" runat="server" Text='<%# Eval("Theft_VIN") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Invoice_Value" SortExpression="Vehicle_Invoice_Value">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Invoice_Value" runat="server" Text='<%# Eval("Vehicle_Invoice_Value") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Recovered" SortExpression="Vehicle_Recovered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Recovered" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Vehicle_Recovered")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_Vehicle_Damage_Amount" SortExpression="Theft_Vehicle_Damage_Amount">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_Vehicle_Damage_Amount" runat="server" Text='<%# Eval("Theft_Vehicle_Damage_Amount") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theft_Dealership_Wish_To_Take_Possession" SortExpression="Theft_Dealership_Wish_To_Take_Possession">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Theft_Dealership_Wish_To_Take_Possession" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Theft_Dealership_Wish_To_Take_Possession")) %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Partial_Theft" SortExpression="Partial_Theft">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Partial_Theft" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Partial_Theft")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Partial_Theft_Number_of_Vehicles_Damaged" SortExpression="Partial_Theft_Number_of_Vehicles_Damaged">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Partial_Theft_Number_of_Vehicles_Damaged" runat="server" Text='<%# Eval("Partial_Theft_Number_of_Vehicles_Damaged") %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parial_Theft_Damage_Estimate" SortExpression="Parial_Theft_Damage_Estimate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Parial_Theft_Damage_Estimate" runat="server" Text='<%# Eval("Parial_Theft_Damage_Estimate") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vandalism" SortExpression="Vandalism">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vandalism" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Vandalism")) %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vandalism_Number_of_Vehicles_Damaged" SortExpression="Vandalism_Number_of_Vehicles_Damaged">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vandalism_Number_of_Vehicles_Damaged" runat="server" Text='<%# Eval("Vandalism_Number_of_Vehicles_Damaged") %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vandalism_Total_Estimate_of_Damages" SortExpression="Vandalism_Total_Estimate_of_Damages">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vandalism_Total_Estimate_of_Damages" runat="server" Text='<%# Eval("Vandalism_Total_Estimate_of_Damages") %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MVA_Single" SortExpression="MVA_Single">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="MVA_Single" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("MVA_Single")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MVA_Multiple" SortExpression="MVA_Multiple">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="MVA_Multiple" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("MVA_Multiple")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hail" SortExpression="Hail">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Hail" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Hail")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hail_Number_Of_Vehicles_Damaged" SortExpression="Hail_Number_Of_Vehicles_Damaged">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Hail_Number_Of_Vehicles_Damaged" runat="server" Text='<%# Eval("Hail_Number_Of_Vehicles_Damaged") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hail_Damage_Estimate" SortExpression="Hail_Damage_Estimate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Hail_Damage_Estimate" runat="server" Text='<%# Eval("Hail_Damage_Estimate") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood" SortExpression="Flood">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Flood" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Flood")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Number_Of_Vehicles_Damaged" SortExpression="Flood_Number_Of_Vehicles_Damaged">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Flood_Number_Of_Vehicles_Damaged" runat="server" Text='<%# Eval("Flood_Number_Of_Vehicles_Damaged") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Damage_Estimate" SortExpression="Flood_Damage_Estimate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Flood_Damage_Estimate" runat="server" Text='<%# Eval("Flood_Damage_Estimate") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire" SortExpression="Fire">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Fire" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Fire")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Number_Of_Vehicles_Damaged" SortExpression="Fire_Number_Of_Vehicles_Damaged">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Fire_Number_Of_Vehicles_Damaged" runat="server" Text='<%# Eval("Fire_Number_Of_Vehicles_Damaged") %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Damage_Estimate" SortExpression="Fire_Damage_Estimate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Fire_Damage_Estimate" runat="server" Text='<%# Eval("Fire_Damage_Estimate") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wind" SortExpression="Wind">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Wind" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Wind")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wind_Number_Of_Vehicles_Damaged" SortExpression="Wind_Number_Of_Vehicles_Damaged">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Wind_Number_Of_Vehicles_Damaged" runat="server" Text='<%# Eval("Wind_Number_Of_Vehicles_Damaged") %>'
                                            Width="260px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wind_Damage_Estimate" SortExpression="Wind_Damage_Estimate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Wind_Damage_Estimate" runat="server" Text='<%# Eval("Wind_Damage_Estimate") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fraud" SortExpression="Fraud">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Fraud" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Fraud")) %>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Comments" runat="server" Text='<%# Eval("Comments") %>' Width="400px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Complete" SortExpression="Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Complete" runat="server" Text='<%# Eval("Complete") %>' Width="120px"></asp:Label>
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
