<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PLFirstReport.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_PLFirstReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: PL_FR Audit Trail</title>
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
                <div style="overflow: hidden; width: 600px;" id="divPL_FR_Audit_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <td class="cols">
                                    <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                </td>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">PK_PL_FR_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">PL_FR_Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">FK_LU_Location_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">FK_Contact</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Claimant_State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Date_of_Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Time_of_Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Non_Sonic_Loss_Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Description_of_Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Date_Reported_To_Sonic</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Weather_Conditions</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Road_Conditions</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Were_Police_Notified</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Police_Organization</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Police_telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Case_Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Personal_Bodily_Injury</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Loss_Category</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Damage</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witnesses</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_Involved</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Type_of_Product</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Manufacturer_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_Address_1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_Address_2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_Zip_Code</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Product_Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Address_1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Address_2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_ZipCode</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Work_Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Injured_Alternate_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Home_Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">What_Was_Injured_Doing</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">body_part</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Treatment_Provided</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px">Injured_Taken_By_Emergency_Transportation</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_Address_1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_Address_2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_Zip_Code</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Medical_Facility_Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Airlifted_Medivac</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Citation_Issued</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Citation_Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Gender</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Date_of_Initial_Treatment</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Injury_Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Sought_Medical_Attention</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Admitted_to_Hospital</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Injured_Date_Admitted_to_Hospital</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Still_in_Hospital</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Injured_Physicians_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 240px">Property_Damage_Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Estimate_Available</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Estimator_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Business_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Address_1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Address_2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Property_Zip_Code</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 280px">Location_where_property_can_be_seen</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Estimate_Amount</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Estimator_Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Owner_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Owner_Work_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Owner_Home_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Owner_Alternate_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_Address_1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_Address_2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_Zip_Code</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Witness_Work_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px">Witness_Home_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Witness_Alternate_Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 400px">Comments</span>
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
                <div style="overflow: scroll; width: 600px; height: 425px;" id="divPL_FR_Audit_Grid"
                    runat="server">
                    <asp:GridView ID="gvPL_FR_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                            <asp:TemplateField HeaderText="PK_PL_FR_ID" SortExpression="PK_PL_FR_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="PK_PL_FR_ID" runat="server" Text='<%# Eval("PK_PL_FR_ID") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PL_FR_Number" SortExpression="PL_FR_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="PL_FR_Number" runat="server" Text='<%# Eval("PL_FR_Number") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Location_ID" SortExpression="FK_LU_Location_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="FK_LU_Location_ID" runat="server" Text='<%# Eval("FK_LU_Location_ID") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Contact" SortExpression="FK_Contact">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="FK_Contact" runat="server" Text='<%# Eval("FK_Contact") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Claimant_State" SortExpression="Claimant_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Claimant_State" runat="server" Text='<%# Eval("Claimant_State") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_of_Loss" SortExpression="Date_of_Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Date_of_Loss" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_of_Loss"))) ? Convert.ToDateTime(Eval("Date_of_Loss")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time_of_Loss" SortExpression="Time_of_Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Time_of_Loss" runat="server" Text='<%# Eval("Time_of_Loss") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Non_Sonic_Loss_Location" SortExpression="Non_Sonic_Loss_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Non_Sonic_Loss_Location" runat="server" Text='<%# Eval("Non_Sonic_Loss_Location") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description_of_Loss" SortExpression="Description_of_Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Description_of_Loss" runat="server" Text='<%# Eval("Description_of_Loss") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Reported_To_Sonic" SortExpression="Date_Reported_To_Sonic">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Date_Reported_To_Sonic" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Reported_To_Sonic"))) ? Convert.ToDateTime(Eval("Date_Reported_To_Sonic")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Weather_Conditions" SortExpression="Weather_Conditions">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Weather_Conditions" runat="server" Text='<%# Eval("Weather_Conditions") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Road_Conditions" SortExpression="Road_Conditions">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Road_Conditions" runat="server" Text='<%# Eval("Road_Conditions") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Were_Police_Notified" SortExpression="Were_Police_Notified">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Were_Police_Notified" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Were_Police_Notified")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Organization" SortExpression="Police_Organization">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Police_Organization" runat="server" Text='<%# Eval("Police_Organization") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_telephone" SortExpression="Police_telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Police_telephone" runat="server" Text='<%# Eval("Police_telephone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Case_Number" SortExpression="Case_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Case_Number" runat="server" Text='<%# Eval("Case_Number") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Personal_Bodily_Injury" SortExpression="Personal_Bodily_Injury">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Personal_Bodily_Injury" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Personal_Bodily_Injury")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loss_Category" SortExpression="Loss_Category">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Loss_Category" runat="server" Text='<%# Eval("Loss_Category") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Damage" SortExpression="Property_Damage">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Damage" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Property_Damage")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witnesses" SortExpression="Witnesses">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witnesses" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Witnesses")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Involved" SortExpression="Product_Involved">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_Involved" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Product_Involved")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type_of_Product" SortExpression="Type_of_Product">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Type_of_Product" runat="server" Text='<%# Eval("Type_of_Product") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer_Name" SortExpression="Manufacturer_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Manufacturer_Name" runat="server" Text='<%# Eval("Manufacturer_Name") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Address_1" SortExpression="Product_Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_Address_1" runat="server" Text='<%# Eval("Product_Address_1") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Address_2" SortExpression="Product_Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_Address_2" runat="server" Text='<%# Eval("Product_Address_2") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_City" SortExpression="Product_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_City" runat="server" Text='<%# Eval("Product_City") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_State" SortExpression="Product_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_State" runat="server" Text='<%# Eval("Product_State") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Zip_Code" SortExpression="Product_Zip_Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_Zip_Code" runat="server" Text='<%# Eval("Product_Zip_Code") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Location" SortExpression="Product_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Product_Location" runat="server" Text='<%# Eval("Product_Location") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Name" SortExpression="Injured_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Name" runat="server" Text='<%# Eval("Injured_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Address_1" SortExpression="Injured_Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Address_1" runat="server" Text='<%# Eval("Injured_Address_1") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Address_2" SortExpression="Injured_Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Address_2" runat="server" Text='<%# Eval("Injured_Address_2") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_City" SortExpression="Injured_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_City" runat="server" Text='<%# Eval("Injured_City") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_State" SortExpression="Injured_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_State" runat="server" Text='<%# Eval("Injured_State") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_ZipCode" SortExpression="Injured_ZipCode">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_ZipCode" runat="server" Text='<%# Eval("Injured_ZipCode") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Work_Phone" SortExpression="Injured_Work_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Work_Phone" runat="server" Text='<%# Eval("Injured_Work_Phone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Alternate_Telephone" SortExpression="Injured_Alternate_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Alternate_Telephone" runat="server" Text='<%# Eval("Injured_Alternate_Telephone") %>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Home_Phone" SortExpression="Injured_Home_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Home_Phone" runat="server" Text='<%# Eval("Injured_Home_Phone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="What_Was_Injured_Doing" SortExpression="What_Was_Injured_Doing">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="What_Was_Injured_Doing" runat="server" Text='<%# Eval("What_Was_Injured_Doing") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="body_part" SortExpression="body_part">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="body_part" runat="server" Text='<%# Eval("body_part") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Treatment_Provided" SortExpression="Injured_Medical_Treatment_Provided">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Treatment_Provided" runat="server" Text='<%# Eval("Injured_Medical_Treatment_Provided") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Taken_By_Emergency_Transportation" SortExpression="Injured_Taken_By_Emergency_Transportation">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Taken_By_Emergency_Transportation" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Injured_Taken_By_Emergency_Transportation")) %>'
                                        Width="300px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_Name" SortExpression="Injured_Medical_Facility_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_Name" runat="server" Text='<%# Eval("Injured_Medical_Facility_Name") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_Address_1" SortExpression="Injured_Medical_Facility_Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_Address_1" runat="server" Text='<%# Eval("Injured_Medical_Facility_Address_1") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_Address_2" SortExpression="Injured_Medical_Facility_Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_Address_2" runat="server" Text='<%# Eval("Injured_Medical_Facility_Address_2") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_City" SortExpression="Injured_Medical_Facility_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_City" runat="server" Text='<%# Eval("Injured_Medical_Facility_City") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_State" SortExpression="Injured_Medical_Facility_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_State" runat="server" Text='<%# Eval("Injured_Medical_Facility_State") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_Zip_Code" SortExpression="Injured_Medical_Facility_Zip_Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_Zip_Code" runat="server" Text='<%# Eval("Injured_Medical_Facility_Zip_Code") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Medical_Facility_Type" SortExpression="Injured_Medical_Facility_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Medical_Facility_Type" runat="server" Text='<%# Eval("Injured_Medical_Facility_Type") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Airlifted_Medivac" SortExpression="Injured_Airlifted_Medivac">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Airlifted_Medivac" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Injured_Airlifted_Medivac")) %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Citation_Issued" SortExpression="Injured_Citation_Issued">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Citation_Issued" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Injured_Citation_Issued")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Citation_Number" SortExpression="Injured_Citation_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Citation_Number" runat="server" Text='<%# Eval("Injured_Citation_Number") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Gender" SortExpression="Injured_Gender">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Gender" runat="server" Text='<%# Eval("Injured_Gender") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Date_of_Initial_Treatment" SortExpression="Injured_Date_of_Initial_Treatment">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Date_of_Initial_Treatment" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Injured_Date_of_Initial_Treatment"))) ? Convert.ToDateTime(Eval("Injured_Date_of_Initial_Treatment")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Injury_Description" SortExpression="Injured_Injury_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Injury_Description" runat="server" Text='<%# Eval("Injured_Injury_Description") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Sought_Medical_Attention" SortExpression="Injured_Sought_Medical_Attention">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Sought_Medical_Attention" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Injured_Sought_Medical_Attention")) %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Admitted_to_Hospital" SortExpression="Injured_Admitted_to_Hospital">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Admitted_to_Hospital" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Injured_Admitted_to_Hospital")) %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Date_Admitted_to_Hospital" SortExpression="Injured_Date_Admitted_to_Hospital">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Date_Admitted_to_Hospital" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Injured_Date_Admitted_to_Hospital"))) ? Convert.ToDateTime(Eval("Injured_Date_Admitted_to_Hospital")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Still_in_Hospital" SortExpression="Injured_Still_in_Hospital">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Still_in_Hospital" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Injured_Still_in_Hospital")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Injured_Physicians_Name" SortExpression="Injured_Physicians_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Injured_Physicians_Name" runat="server" Text='<%# Eval("Injured_Physicians_Name") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Description" SortExpression="Property_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Description" runat="server" Text='<%# Eval("Property_Description") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Damage_Description" SortExpression="Property_Damage_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Damage_Description" runat="server" Text='<%# Eval("Property_Damage_Description") %>'
                                        Width="240px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimate_Available" SortExpression="Estimate_Available">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Estimate_Available" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Estimate_Available")) %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Estimator_Name" SortExpression="Property_Estimator_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Estimator_Name" runat="server" Text='<%# Eval("Property_Estimator_Name") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Business_Name" SortExpression="Property_Business_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Business_Name" runat="server" Text='<%# Eval("Property_Business_Name") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Address_1" SortExpression="Property_Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Address_1" runat="server" Text='<%# Eval("Property_Address_1") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Address_2" SortExpression="Property_Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Address_2" runat="server" Text='<%# Eval("Property_Address_2") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_City" SortExpression="Property_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_City" runat="server" Text='<%# Eval("Property_City") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_State" SortExpression="Property_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_State" runat="server" Text='<%# Eval("Property_State") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Zip_Code" SortExpression="Property_Zip_Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Property_Zip_Code" runat="server" Text='<%# Eval("Property_Zip_Code") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location_where_property_can_be_seen" SortExpression="Location_where_property_can_be_seen">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Location_where_property_can_be_seen" runat="server" Text='<%# Eval("Location_where_property_can_be_seen") %>'
                                        Width="280px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimate_Amount" SortExpression="Estimate_Amount">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Estimate_Amount" runat="server" Text='<%# Eval("Estimate_Amount") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimator_Phone" SortExpression="Estimator_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Estimator_Phone" runat="server" Text='<%# Eval("Estimator_Phone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner_Name" SortExpression="Owner_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Owner_Name" runat="server" Text='<%# Eval("Owner_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner_Work_Telephone" SortExpression="Owner_Work_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Owner_Work_Telephone" runat="server" Text='<%# Eval("Owner_Work_Telephone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner_Home_Telephone" SortExpression="Owner_Home_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Owner_Home_Telephone" runat="server" Text='<%# Eval("Owner_Home_Telephone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner_Alternate_Telephone" SortExpression="Owner_Alternate_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Owner_Alternate_Telephone" runat="server" Text='<%# Eval("Owner_Alternate_Telephone") %>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Name" SortExpression="Witness_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Name" runat="server" Text='<%# Eval("Witness_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Address_1" SortExpression="Witness_Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Address_1" runat="server" Text='<%# Eval("Witness_Address_1") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Address_2" SortExpression="Witness_Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Address_2" runat="server" Text='<%# Eval("Witness_Address_2") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_City" SortExpression="Witness_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_City" runat="server" Text='<%# Eval("Witness_City") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_State" SortExpression="Witness_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_State" runat="server" Text='<%# Eval("Witness_State") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Zip_Code" SortExpression="Witness_Zip_Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Zip_Code" runat="server" Text='<%# Eval("Witness_Zip_Code") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Work_Telephone" SortExpression="Witness_Work_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Work_Telephone" runat="server" Text='<%# Eval("Witness_Work_Telephone") %>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Home_Telephone" SortExpression="Witness_Home_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Home_Telephone" runat="server" Text='<%# Eval("Witness_Home_Telephone") %>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Witness_Alternate_Telephone" SortExpression="Witness_Alternate_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Witness_Alternate_Telephone" runat="server" Text='<%# Eval("Witness_Alternate_Telephone") %>'
                                        Width="200px"></asp:Label>
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
                                    <asp:Label ID="Updated_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Updated_Date"))) ? Convert.ToDateTime(Eval("Updated_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="160px"></asp:Label>
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
