<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_DPD_FR_Vehicle.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_DPD_FR_Vehicle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: DPD_FR_Vehicle Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divDPD_FR_Vehicle_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">PK_DPD_FR_Vehicle_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">FK_DPD_FR_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Incident_Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Make</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Model</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Year</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">VIN</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">TypeOfVehicle</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Present_Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Present_Address</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Present_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Present_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Damage_Estimate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Address</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Vehicle_Owner_Sonic</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Vehicle_Owner_Address</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Vehicle_Owner_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Driven_By_Associate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Associate_Cited</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px">Description_Of_Citation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Vehicle_Driven_By_Customer</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Not_Driven_By_Customer_Explain</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Cutomer_Injured</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Invoice_Value</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Vehicle_Recovered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Dealership_Wish_To_Take_Possession</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px">Loss_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Police_Notified</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Police_Report_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Vehicle_In_Storage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Storage_Contact</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Storage_phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">storage_cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">storage_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">storage_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">storage_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">storage_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">storage_Zip_Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Associate_injured</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">drug_test_performed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">drug_test_results</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">drug_test_explanation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Additional_passengers</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">seeking_subrogation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Notice_only_claim</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">TPI_Carrier_name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">TPI_Policy_number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_contact</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">tpi_Zip_Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">recovered_amount</span>
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
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divDPD_FR_Vehicle_Grid"
                        runat="server">
                        <asp:GridView ID="gvDPD_FR_Vehicle" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                                <asp:TemplateField HeaderText="PK_DPD_FR_Vehicle_ID" SortExpression="PK_DPD_FR_Vehicle_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_DPD_FR_Vehicle_ID" runat="server" Text='<%# Bind("PK_DPD_FR_Vehicle_ID") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_DPD_FR_ID" SortExpression="FK_DPD_FR_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_DPD_FR_ID" runat="server" Text='<%# Bind("FK_DPD_FR_ID") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Incident_Type" SortExpression="Incident_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Incident_Type" runat="server" Text='<%# clsGeneral.GetDPDIncidentType(Eval("Incident_Type")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Make" SortExpression="Make">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Make" runat="server" Text='<%# Bind("Make") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Model" runat="server" Text='<%# Bind("Model") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year" SortExpression="Year">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Year" runat="server" Text='<%# (Eval("Year")) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VIN" SortExpression="VIN">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="VIN" runat="server" Text='<%# Bind("VIN") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TypeOfVehicle" SortExpression="TypeOfVehicle">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="TypeOfVehicle" runat="server" Text='<%# Eval("TypeOfVehicle") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Present_Location" SortExpression="Present_Location">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Present_Location" runat="server" Text='<%# Eval("Present_Location") %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Present_Address" SortExpression="Present_Address">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Present_Address" runat="server" Text='<%# Eval("Present_Address") %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Present_State" SortExpression="Present_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Present_State" runat="server" Text='<%# Eval("Present_State") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Present_Zip" SortExpression="Present_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Present_Zip" runat="server" Text='<%# Eval("Present_Zip") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Estimate" SortExpression="Damage_Estimate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Damage_Estimate" runat="server" Text='<%# (Eval("Damage_Estimate")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Address" runat="server" Text='<%# Eval("Address") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone" SortExpression="Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Phone" runat="server" Text='<%# Eval("Phone") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Owner_Sonic" SortExpression="Vehicle_Owner_Sonic">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Owner_Sonic" runat="server" Text='<%# Eval("Vehicle_Owner_Sonic") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Owner_Address" SortExpression="Vehicle_Owner_Address">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Owner_Address" runat="server" Text='<%# Eval("Vehicle_Owner_Address") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Owner_Phone" SortExpression="Vehicle_Owner_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Owner_Phone" runat="server" Text='<%# Eval("Vehicle_Owner_Phone") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Driven_By_Associate" SortExpression="Driven_By_Associate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Driven_By_Associate" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Driven_By_Associate")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associate_Cited" SortExpression="Associate_Cited">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Associate_Cited" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Associate_Cited")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description_Of_Citation" SortExpression="Description_Of_Citation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Description_Of_Citation" runat="server" Text='<%# Bind("Description_Of_Citation") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Driven_By_Customer" SortExpression="Vehicle_Driven_By_Customer">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Driven_By_Customer" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Vehicle_Driven_By_Customer")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Not_Driven_By_Customer_Explain" SortExpression="Not_Driven_By_Customer_Explain">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Not_Driven_By_Customer_Explain" runat="server" Text='<%#Eval("Not_Driven_By_Customer_Explain") %>'
                                            Width="220px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cutomer_Injured" SortExpression="Cutomer_Injured">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cutomer_Injured" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cutomer_Injured")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Value" SortExpression="Invoice_Value">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Invoice_Value" runat="server" Text='<%# Eval("Invoice_Value")%>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_Recovered" SortExpression="Vehicle_Recovered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_Recovered" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Vehicle_Recovered")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dealership_Wish_To_Take_Possession" SortExpression="Dealership_Wish_To_Take_Possession">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Dealership_Wish_To_Take_Possession" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Dealership_Wish_To_Take_Possession")) %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loss_Description" SortExpression="Loss_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Loss_Description" runat="server" Text='<%# Bind("Loss_Description") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Police_Notified" SortExpression="Police_Notified">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Police_Notified" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Police_Notified")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Police_Report_Number" SortExpression="Police_Report_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Police_Report_Number" runat="server" Text='<%# Bind("Police_Report_Number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle_In_Storage" SortExpression="Vehicle_In_Storage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Vehicle_In_Storage" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Vehicle_In_Storage")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Storage_Contact" SortExpression="Storage_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Storage_Contact" runat="server" Text='<%# Eval("Storage_Contact") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Storage_phone" SortExpression="Storage_phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Storage_phone" runat="server" Text='<%# Eval("Storage_phone") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="storage_cost" SortExpression="storage_cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="storage_cost" runat="server" Text='<%# Eval("storage_cost") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="storage_Address_1" SortExpression="storage_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="storage_Address_1" runat="server" Text='<%# Eval("storage_Address_1") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="storage_Address_2" SortExpression="storage_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="storage_Address_2" runat="server" Text='<%# Eval("storage_Address_2") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="storage_City" SortExpression="storage_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="storage_City" runat="server" Text='<%# Eval("storage_City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="storage_State" SortExpression="storage_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="storage_State" runat="server" Text='<%# Eval("storage_State") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="storage_Zip_Code" SortExpression="storage_Zip_Code">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="storage_Zip_Code" runat="server" Text='<%# Eval("storage_Zip_Code") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associate_injured" SortExpression="Associate_injured">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Associate_injured" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Associate_injured")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="drug_test_performed" SortExpression="drug_test_performed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="drug_test_performed" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("drug_test_performed")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="drug_test_results" SortExpression="drug_test_results">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="drug_test_results" runat="server" Text='<%# Eval("drug_test_results") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="drug_test_explanation" SortExpression="drug_test_explanation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="drug_test_explanation" runat="server" Text='<%# Eval("drug_test_explanation") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Additional_passengers" SortExpression="Additional_passengers">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Additional_passengers" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Additional_passengers")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="seeking_subrogation" SortExpression="seeking_subrogation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="seeking_subrogation" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("seeking_subrogation")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notice_only_claim" SortExpression="Notice_only_claim">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Notice_only_claim" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Notice_only_claim")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TPI_Carrier_name" SortExpression="TPI_Carrier_name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="TPI_Carrier_name" runat="server" Text='<%# Eval("TPI_Carrier_name") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TPI_Policy_number" SortExpression="TPI_Policy_number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="TPI_Policy_number" runat="server" Text='<%# Eval("TPI_Policy_number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_phone" SortExpression="tpi_phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_phone" runat="server" Text='<%# Eval("tpi_phone") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_contact" SortExpression="tpi_contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_contact" runat="server" Text='<%# Eval("tpi_contact") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_Address_1" SortExpression="tpi_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_Address_1" runat="server" Text='<%# Eval("tpi_Address_1") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_Address_2" SortExpression="tpi_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_Address_2" runat="server" Text='<%# Eval("tpi_Address_2") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_City" SortExpression="tpi_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_City" runat="server" Text='<%# Eval("tpi_City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_State" SortExpression="tpi_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_State" runat="server" Text='<%# Eval("tpi_State") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tpi_Zip_Code" SortExpression="tpi_Zip_Code">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="tpi_Zip_Code" runat="server" Text='<%# Eval("tpi_Zip_Code") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="recovered_amount" SortExpression="recovered_amount">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="recovered_amount" runat="server" Text='<%# Eval("recovered_amount") %>'
                                            Width="150px"></asp:Label>
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
