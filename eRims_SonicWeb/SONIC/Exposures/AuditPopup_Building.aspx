<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Building.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_Building" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Building Audit Trail</title>
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

        if (document.getElementById("<%=hdnTotalInsuranceRecord.ClientID%>").value != '0')
            showAuditInsurance();
    }

    function showAuditInsurance() {
        var divheight, i;
        var divHeader = document.getElementById("<%=divInsuranceHeader.ClientID %>");
        var divGrid = document.getElementById("<%=divInsuranceGrid.ClientID %>");

        divHeader.style.width = window.screen.availWidth - 225 + "px";
        divGrid.style.width = window.screen.availWidth - 225 + "px";
       
        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 350;
        }
    }
    
    function ChangeScrollBar(f,s)
    {
        s.scrollTop = f.scrollTop;
        s.scrollLeft = f.scrollLeft;
    }

    function ChangeScrollBar_Insurance(f, s) {
        s.scrollTop = f.scrollTop;
        s.scrollLeft = f.scrollLeft;
    }
</script>

<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdnTotalInsuranceRecord" runat="server" />
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
                <td colspan="2" align="left">
                    <div style="overflow: hidden; width: 600px;" id="dvHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px;">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px;">PK_Building_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">FK_LU_Location_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Building_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Ownership</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Sales_New</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Body_Shop</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Parking_Lot</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Sales_Used</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Parts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Raw_Land</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Service</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Ofifce</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Building_Limit</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 255px;">Number_Of_Parking_Spaces</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 185px;">Acreage</span>
                                    </th>
                                    <%--<th class="cols">
                                        <span style="display: inline-block; width: 245px;">Leasehold_Interests_Limit_Expansion</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Expansion_Date_Complete</span>
                                    </th>--%>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Associate_Tools_Limit</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Contents_Limit</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Parts_Limit</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">RS_Means_Building_Value</span>
                                    </th>
                                    <th class="cols">                                    
                                        <span style="display: inline-block; width: 150px;">Inventory_Levels</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Year_Built</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Square_Footage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Number_of_Stories</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Roof_Reinforced_Concrete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px;">Roof_Concrete_Panels</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">Roof_Steel_Deck_with_Fasteners</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px;">Roof_Poured_Concrete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px;">Roof_Steel_Deck</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Roof_Wood_Joists</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 185px;">Floors_Reinforced_Concrete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 165px;">Floors_Poured_Concrete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Floors_Wood_Timber</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px;">Ext_Walls_Reinforced_Concrete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Ext_Walls_Masonry</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px;">Ext_Walls_Corrugated_Metal_Panels</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Ext_Walls_Tilt_up_Concrete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px;">Ext_Walls_Glass_and_Steel_Curtain</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Ext_Walls_Wood_Frame</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Int_Walls_Masonry_With_Fire_Doors</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Int_Walls_Masonry_with_Openings</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Int_Walls_No_Interior_Walls</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px;">Int_Walls_Masonry</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Int_Walls_Gypsum_Board</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Int_wall_extend_above_roof</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Number_of_Paint_Booths</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Number_of_Lifts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Sales_New_Sprinklered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Sales_Used_Sprinklered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Service_Sprinklered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Body_Shop_Sprinklered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Parts_Sprinklered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Office_Sprinklered</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Water_Public</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Water_Private</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Water_Boosted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">Design_Densities_for_each_area</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 175px;">Hydrants_within_500_ft</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 185px;">Alarm_UL_Central_Station</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 185px;">Alarm_Constant_Attended</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px;">Alarm_Sprinkler_Valve_Tamper</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px;">Alarm_Non_UL_Central_Station</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Alarm_Local</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Alarm_Smoke_Detectors</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Alarm_Proprietary</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 185px;">Alarm_Sprinkler_Waterflow</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 175px;">Alarm_Dry_Pipe_Air</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Alarm_Remote</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Alarm_Fire_Pump_Alarms</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Alarm_Auto_Fire_Alarms</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Alarm_Security_Cameras</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">SecuCam_System</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SecuCam_Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SecuCam_Vendor_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">SecuCam_Contact_Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SecuCam_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SecuCam_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">SecuCam_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">SecuCam_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">SecuCam_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">SecuCam_Telephone_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">SecuCam_Alternate_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SecuCam_Email</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">SecuCam_Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px;">Guard_System</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_System_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_Vendor_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">Guard_Contact_Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Guard_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">Guard_Telephone_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">Guard_Alternate_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Guard_Email</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Guard_Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Intru_System</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Intru_System_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Intru_Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Intru_Vendor_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 215px;">Intru_Contact_Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Intru_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Intru_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Intru_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Intru_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Intru_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Intru_Telephone_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Intru_Alternate_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Intru_Email</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Intru_Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Intru_Contact_Alarm_Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 50px;">Fence</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fence_Razor_Wire</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fence_Electrified</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Generator</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Generator_Make</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Generator_Model</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Generator_Size</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Fire_Department_Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Fire_Department_Distance</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Number_of_Bays</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Number_of_Lifts_SC</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">Number_of_Prep_Areas</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Number_of_Car_Wash_Stations</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Tier_1_County</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Earthquake_Zone_Fault_Line</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Neighboring_Buildings_within_100_ft</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Neighbor_Occupancy</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Distance_from_body_of_water</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Prior_Flood_History</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Flood_History_Descr</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Lowest_finish_floor_elevation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 310px;">Property_Damage_Losses_in_the_Past_5_years</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Property_Loss_Descr</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Flood_Zone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">National_Flood_Policy</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Flood_Carrier</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Flood_Policy_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Flood_Premium</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Flood_Polciy_Limits_Contents</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Flood_Policy_Inception_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Flood_Policy_Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Flood_Deductible</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Flood_Policy_Limits_Building</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Vendor_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Contact_Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Telephone_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Alternate_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Fire_Email</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Fire_Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Car_Wash</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Occupancy_Photo_Booth</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px;">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">                        
                        <asp:GridView ID="gvBuilding" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                <asp:TemplateField HeaderText="PK_Building_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Building_ID" runat="server" Text='<%# Eval("PK_Building_ID") %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Location_ID" runat="server" Text='<%# Eval("dba") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Building_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuilding_Number" runat="server" Text='<%# Eval("Building_Number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ownership">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnership" runat="server" Text='<%# Eval("Ownership") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Sales_New">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Sales_New" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Sales_New")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Body_Shop">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Body_Shop" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Body_Shop")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Parking_Lot">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Parking_Lot" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Parking_Lot")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Sales_Used">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Sales_Used" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Sales_Used")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Parts">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Parts" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Parts")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Raw_Land">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Raw_Land" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Raw_Land")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Service">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Service" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Service")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Ofifce">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Ofifce" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Ofifce")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress_1" runat="server" Text='<%# Eval("Address_1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress_2" runat="server" Text='<%# Eval("Address_2") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZip" runat="server" Text='<%# Eval("Zip") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Building_Limit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuilding_Limit" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Building_Limit")) %>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_Of_Parking_Spaces">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeasehold_Interests_Limit_Betterment" runat="server" Text='<%# string.Format("{0:N0}",Eval("Number_Of_Parking_Spaces")) %>'
                                            Width="255px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acreage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBetterment_Date_Complete" runat="server" Text='<%# string.Format("{0:C3}",Eval("Acreage"))%>'
                                            Width="185px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Leasehold_Interests_Limit_Expansion">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeasehold_Interests_Limit_Expansion" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Leasehold_Interests_Limit_Expansion")) %>'
                                            Width="245px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expansion_Date_Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpansion_Date_Complete" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Expansion_Date_Complete"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Associate_Tools_Limit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssociate_Tools_Limit" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Associate_Tools_Limit")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contents_Limit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblContents_Limit" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Contents_Limit")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parts_Limit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblParts_Limit" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Parts_Limit")) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RS_Means_Building_Value">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRS_Means_Building_Value" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("RS_Means_Building_Value")) %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inventory_Levels">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInventory_Levels" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Inventory_Levels")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year_Built">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear_Built" runat="server" Text='<%# Eval("Year_Built") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Square_Footage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSquare_Footage" runat="server" Text='<%# Eval("Square_Footage") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Stories">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Stories" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Stories")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Reinforced_Concrete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Reinforced_Concrete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Roof_Reinforced_Concrete")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Concrete_Panels">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Concrete_Panels" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Roof_Concrete_Panels")) %>'
                                            Width="155px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Steel_Deck_with_Fasteners">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Steel_Deck_with_Fasteners" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Roof_Steel_Deck_with_Fasteners")) %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Poured_Concrete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Poured_Concrete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Roof_Poured_Concrete")) %>'
                                            Width="155px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Steel_Deck">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Steel_Deck" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Roof_Steel_Deck")) %>'
                                            Width="117px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Wood_Joists">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Wood_Joists" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Roof_Wood_Joists")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Floors_Reinforced_Concrete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFloors_Reinforced_Concrete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Floors_Reinforced_Concrete")) %>'
                                            Width="185px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Floors_Poured_Concrete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFloors_Poured_Concrete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Floors_Poured_Concrete")) %>'
                                            Width="165px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Floors_Wood_Timber">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFloors_Wood_Timber" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Floors_Wood_Timber")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ext_Walls_Reinforced_Concrete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExt_Walls_Reinforced_Concrete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Ext_Walls_Reinforced_Concrete")) %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ext_Walls_Masonry">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExt_Walls_Masonry" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Ext_Walls_Masonry")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ext_Walls_Corrugated_Metal_Panels">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExt_Walls_Corrugated_Metal_Panels" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Ext_Walls_Corrugated_Metal_Panels")) %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ext_Walls_Tilt_up_Concrete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExt_Walls_Tilt_up_Concrete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Ext_Walls_Tilt_up_Concrete")) %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ext_Walls_Glass_and_Steel_Curtain">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExt_Walls_Glass_and_Steel_Curtain" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Ext_Walls_Glass_and_Steel_Curtain")) %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ext_Walls_Wood_Frame">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExt_Walls_Wood_Frame" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Ext_Walls_Wood_Frame")) %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Int_Walls_Masonry_With_Fire_Doors">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInt_Walls_Masonry_With_Fire_Doors" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Int_Walls_Masonry_With_Fire_Doors")) %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Int_Walls_Masonry_with_Openings">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInt_Walls_Masonry_with_Openings" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Int_Walls_Masonry_with_Openings")) %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Int_Walls_No_Interior_Walls">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInt_Walls_No_Interior_Walls" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Int_Walls_No_Interior_Walls")) %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Int_Walls_Masonry">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInt_Walls_Masonry" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Int_Walls_Masonry")) %>'
                                            Width="135px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Int_Walls_Gypsum_Board">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInt_Walls_Gypsum_Board" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Int_Walls_Gypsum_Board")) %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Int_wall_extend_above_roof">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInt_wall_extend_above_roof" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Int_wall_extend_above_roof")) %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Paint_Booths">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Paint_Booths" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Paint_Booths")).Replace(".00", "") %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Lifts">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Lifts" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Lifts")).Replace(".00", "") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sales_New_Sprinklered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSales_New_Sprinklered" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Sales_New_Sprinklered")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sales_Used_Sprinklered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSales_Used_Sprinklered" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Sales_Used_Sprinklered")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service_Sprinklered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblService_Sprinklered" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Service_Sprinklered")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Body_Shop_Sprinklered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBody_Shop_Sprinklered" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Body_Shop_Sprinklered")) %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parts_Sprinklered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblParts_Sprinklered" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Parts_Sprinklered")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Office_Sprinklered">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffice_Sprinklered" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Office_Sprinklered")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Water_Public">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWater_Public" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Water_Public")) %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Water_Private">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWater_Private" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Water_Private")) %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Water_Boosted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWater_Boosted" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Water_Boosted")) %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Design_Densities_for_each_area">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesign_Densities_for_each_area" runat="server" Text='<%# Eval("Design_Densities_for_each_area") %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hydrants_within_500_ft">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHydrants_within_500_ft" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Hydrants_within_500_ft")) %>'
                                            Width="175px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_UL_Central_Station">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_UL_Central_Station" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_UL_Central_Station")) %>'
                                            Width="185px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Constant_Attended">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Constant_Attended" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Constant_Attended")) %>'
                                            Width="185px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Sprinkler_Valve_Tamper">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Sprinkler_Valve_Tamper" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Sprinkler_Valve_Tamper")) %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Non_UL_Central_Station">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Non_UL_Central_Station" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Non_UL_Central_Station")) %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Local">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Local" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Local")) %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Smoke_Detectors">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Smoke_Detectors" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Smoke_Detectors")) %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Proprietary">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Proprietary" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Proprietary")) %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Sprinkler_Waterflow">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Sprinkler_Waterflow" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Sprinkler_Waterflow")) %>'
                                            Width="185px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Dry_Pipe_Air">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Dry_Pipe_Air" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Dry_Pipe_Air")) %>'
                                            Width="175px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Remote">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Remote" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Remote")) %>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Fire_Pump_Alarms">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Fire_Pump_Alarms" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Fire_Pump_Alarms")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Auto_Fire_Alarms">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Auto_Fire_Alarms" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Auto_Fire_Alarms")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alarm_Security_Cameras">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAlarm_Security_Cameras" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Alarm_Security_Cameras")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_System">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_System" runat="server" Text='<%# Eval("SecuCam_System") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Contact_Name" runat="server" Text='<%# Eval("SecuCam_Contact_Name") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Vendor_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Vendor_Name" runat="server" Text='<%# Eval("SecuCam_Vendor_Name") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Contact_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Contact_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("SecuCam_Contact_Expiration_Date")) %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Address_1" runat="server" Text='<%# Eval("SecuCam_Address_1") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Address_2" runat="server" Text='<%# Eval("SecuCam_Address_2") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_City" runat="server" Text='<%# Eval("SecuCam_City") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_State" runat="server" Text='<%# Eval("SecuCam_State") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Zip" runat="server" Text='<%# Eval("SecuCam_Zip") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Telephone_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Telephone_Number" runat="server" Text='<%# Eval("SecuCam_Telephone_Number") %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Alternate_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Alternate_Number" runat="server" Text='<%# Eval("SecuCam_Alternate_Number") %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Email" runat="server" Text='<%# Eval("SecuCam_Email") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SecuCam_Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuCam_Comments" runat="server" Text='<%# Eval("SecuCam_Comments") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_System">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_System" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Guard_System"))%>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_System_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_System_Name" runat="server" Text='<%# Eval("Guard_System_Name") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Contact_Name" runat="server" Text='<%# Eval("Guard_Contact_Name") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Vendor_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Vendor_Name" runat="server" Text='<%# Eval("Guard_Vendor_Name") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Contact_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Contact_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Guard_Contact_Expiration_Date")) %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Address_1" runat="server" Text='<%# Eval("Guard_Address_1") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Address_2" runat="server" Text='<%# Eval("Guard_Address_2") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_City" runat="server" Text='<%# Eval("Guard_City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_State" runat="server" Text='<%# Eval("Guard_State") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Zip" runat="server" Text='<%# Eval("Guard_Zip") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Telephone_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Telephone_Number" runat="server" Text='<%# Eval("Guard_Telephone_Number") %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Alternate_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Alternate_Number" runat="server" Text='<%# Eval("Guard_Alternate_Number") %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Email" runat="server" Text='<%# Eval("Guard_Email") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Comments" runat="server" Text='<%# Eval("Guard_Comments") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_System">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_System" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Intru_System")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_System_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_System_Name" runat="server" Text='<%# Eval("Intru_System_Name") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Contact_Name" runat="server" Text='<%# Eval("Intru_Contact_Name") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Vendor_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Vendor_Name" runat="server" Text='<%# Eval("Intru_Vendor_Name") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Contact_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Contact_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Intru_Contact_Expiration_Date")) %>'
                                            Width="215px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Address_1" runat="server" Text='<%# Eval("Intru_Address_1") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Address_2" runat="server" Text='<%# Eval("Intru_Address_2") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_City" runat="server" Text='<%# Eval("Intru_City") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_State" runat="server" Text='<%# Eval("Intru_State") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Zip" runat="server" Text='<%# Eval("Intru_Zip") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Telephone_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Telephone_Number" runat="server" Text='<%# Eval("Intru_Telephone_Number") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Alternate_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Alternate_Number" runat="server" Text='<%# Eval("Intru_Alternate_Number") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Email" runat="server" Text='<%# Eval("Intru_Email") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Comments" runat="server" Text='<%# Eval("Intru_Comments") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intru_Contact_Alarm_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntru_Contact_Alarm_Type" runat="server" Text='<%# Eval("Intru_Contact_Alarm_Type") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fence">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFence" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Fence"))%>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fence_Razor_Wire">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFence_Razor_Wire" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Fence_Razor_Wire")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fence_Electrified">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFence_Electrified" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Fence_Electrified")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Generator">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGenerator" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Generator")) %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Generator_Make">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGenerator_Make" runat="server" Text='<%# Eval("Generator_Make") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Generator_Model">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGenerator_Model" runat="server" Text='<%# Eval("Generator_Model") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Generator_Size">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGenerator_Size" runat="server" Text='<%# Eval("Generator_Size") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Department_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Department_Type" runat="server" Text='<%# Eval("Fire_Department_Type") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Department_Distance">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Department_Distance" runat="server" Text='<%# Eval("Fire_Department_Distance") %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Bays">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Bays" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Bays")).Replace(".00","") %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Lifts_SC">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Lifts_SC" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Lifts_SC")).Replace(".00","") %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Prep_Areas">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Prep_Areas" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Prep_Areas")).Replace(".00","") %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Car_Wash_Stations">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Car_Wash_Stations" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Car_Wash_Stations")).Replace(".00","") %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tier_1_County">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTier_1_County" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Tier_1_County")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Earthquake_Zone_Fault_Line">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEarthquake_Zone_Fault_Line" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Earthquake_Zone_Fault_Line")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Neighboring_Buildings_within_100_ft">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNeighboring_Buildings_within_100_ft" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Neighboring_Buildings_within_100_ft")) %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Neighbor_Occupancy">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNeighbor_Occupancy" runat="server" Text='<%# Eval("Neighbor_Occupancy") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Distance_from_body_of_water">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistance_from_body_of_water" runat="server" Text='<%# Eval("Distance_from_body_of_water") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prior_Flood_History">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrior_Flood_History" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Prior_Flood_History")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_History_Descr">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_History_Descr" runat="server" Text='<%# Eval("Flood_History_Descr") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lowest_finish_floor_elevation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLowest_finish_floor_elevation" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Lowest_finish_floor_elevation")).Replace(".00", "") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property_Damage_Losses_in_the_Past_5_years">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblProperty_Damage_Losses_in_the_Past_5_years" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Property_Damage_Losses_in_the_Past_5_years")) %>'
                                            Width="310px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property_Loss_Descr">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblProperty_Loss_Descr" runat="server" Text='<%# Eval("Property_Loss_Descr") %>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Zone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Zone" runat="server" Text='<%# Eval("Flood_Zone") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="National_Flood_Policy">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNational_Flood_Policy" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("National_Flood_Policy")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Carrier">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Carrier" runat="server" Text='<%# Eval("Flood_Carrier") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Policy_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Policy_Number" runat="server" Text='<%# Eval("Flood_Policy_Number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Premium">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Premium" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Flood_Premium")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Polciy_Limits_Contents">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Polciy_Limits_Contents" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Flood_Polciy_Limits_Contents")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Policy_Inception_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Policy_Inception_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Flood_Policy_Inception_Date")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Policy_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Policy_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Flood_Policy_Expiration_Date")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Deductible">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Deductible" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Flood_Deductible")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flood_Policy_Limits_Building">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlood_Policy_Limits_Building" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Flood_Policy_Limits_Building")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>' Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="Fire_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Contact_Name" runat="server" Text='<%# Eval("Fire_Contact_Name") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Vendor_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Vendor_Name" runat="server" Text='<%# Eval("Fire_Vendor_Name") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Contact_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Contact_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Fire_Contact_Expiration_Date")) %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Address_1" runat="server" Text='<%# Eval("Fire_Address_1") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="Fire_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Address_2" runat="server" Text='<%# Eval("Fire_Address_2") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_City" runat="server" Text='<%# Eval("Fire_City") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_State" runat="server" Text='<%# Eval("Fire_State") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Zip" runat="server" Text='<%# Eval("Fire_Zip") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Telephone_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Telephone_Number" runat="server" Text='<%# Eval("Fire_Telephone_Number") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Fire_Alternate_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alternate_Number" runat="server" Text='<%# Eval("Fire_Alternate_Number") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Email" runat="server" Text='<%# Eval("Fire_Email") %>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Comments" runat="server" Text='<%# Eval("Fire_Comments") %>' Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                              
                                 <asp:TemplateField HeaderText="Occupancy_Car_Wash">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Car_Wash" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Car_Wash")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupancy_Photo_Booth">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOccupancy_Photo_Booth" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Occupancy_Photo_Booth")) %>'
                                            Width="150px"></asp:Label>
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
                    <br />
                    <br />                   
                    <asp:Label ID="lblBuildingInsuranceCope" runat="server" style="font-weight:bold"></asp:Label><br /><br />
                    <div style="overflow: hidden; width: 600px;" id="divInsuranceHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">PK_Building_Insurance_COPE</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">FK_Building</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 3</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 4</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 5</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 6</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 7</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 8</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 9</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 10</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 11</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 12</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 13</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 14</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 15</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 16</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 17</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 18</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 19</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 20</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 21</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 22</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 23</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 24</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Item 25</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Updated by</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Updated Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divInsuranceGrid" runat="server">
                        <asp:GridView ID="gvInsurance" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsuranceAuditTime" runat="server" Width="100px" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm") %>' ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Building_Insurance_COPE">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPKBuildingInsuranceCOPE" runat="server" Width="180px" Text='<%# Eval("PK_Building_Insurance_COPE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Building">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Building" runat="server" Width="100px" Text='<%# Eval("FK_Building") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_1" runat="server" Width="150px" Text='<%# Eval("Item_1") %>' ToolTip='<%# Eval("Item_1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_2" runat="server" Width="150px" Text='<%# Eval("Item_2") %>' ToolTip='<%# Eval("Item_2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 3">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_3" runat="server" Width="150px" Text='<%# Eval("Item_3") %>' ToolTip='<%# Eval("Item_3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 4">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_4" runat="server" Width="150px" Text='<%# Eval("Item_4") %>' ToolTip='<%# Eval("Item_4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 5">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_5" runat="server" Width="150px" Text='<%# Eval("Item_5") %>' ToolTip='<%# Eval("Item_5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 6">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_6" runat="server" Width="150px" Text='<%# Eval("Item_6") %>' ToolTip='<%# Eval("Item_6") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 7">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_7" runat="server" Width="150px" Text='<%# Eval("Item_7") %>' ToolTip='<%# Eval("Item_7") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 8">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_8" runat="server" Width="150px" Text='<%# Eval("Item_8") %>' ToolTip='<%# Eval("Item_8") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 9">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_9" runat="server" Width="150px" Text='<%# Eval("Item_9") %>' ToolTip='<%# Eval("Item_9") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 10">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_10" runat="server" Width="150px" Text='<%# Eval("Item_10") %>' ToolTip='<%# Eval("Item_10") %>'></asp:Label>
                                    </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 11">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_11" runat="server" Width="150px" Text='<%# Eval("Item_11") %>' ToolTip='<%# Eval("Item_11") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 12">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_12" runat="server" Width="150px" Text='<%# Eval("Item_12") %>' ToolTip='<%# Eval("Item_12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 13">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_13" runat="server" Width="150px" Text='<%# Eval("Item_13") %>' ToolTip='<%# Eval("Item_13") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 14">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_14" runat="server" Width="150px" Text='<%# Eval("Item_14") %>' ToolTip='<%# Eval("Item_14") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 15">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_15" runat="server" Width="150px" Text='<%# Eval("Item_15") %>' ToolTip='<%# Eval("Item_15") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 16">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_16" runat="server" Width="150px" Text='<%# Eval("Item_16") %>' ToolTip='<%# Eval("Item_16") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 17">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_17" runat="server" Width="150px" Text='<%# Eval("Item_17") %>' ToolTip='<%# Eval("Item_17") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 18">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_18" runat="server" Width="150px" Text='<%# Eval("Item_18") %>' ToolTip='<%# Eval("Item_18") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 19">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_19" runat="server" Width="150px" Text='<%# Eval("Item_19") %>' ToolTip='<%# Eval("Item_19") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 20">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_20" runat="server" Width="150px" Text='<%# Eval("Item_20") %>' ToolTip='<%# Eval("Item_20") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 21">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_21" runat="server" Width="150px" Text='<%# Eval("Item_21") %>' ToolTip='<%# Eval("Item_21") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 22">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_22" runat="server" Width="150px" Text='<%# Eval("Item_22") %>' ToolTip='<%# Eval("Item_22") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 23">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_23" runat="server" Width="150px" Text='<%# Eval("Item_23") %>' ToolTip='<%# Eval("Item_23") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item 24">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_24" runat="server" Width="150px" Text='<%# Eval("Item_24") %>' ToolTip='<%# Eval("Item_24") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item 25">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_25" runat="server" Width="150px" Text='<%# Eval("Item_25") %>' ToolTip='<%# Eval("Item_25") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Updated By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" runat="server" Width="100px" Text='<%# Eval("USER_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Updated Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdatedDate" runat="server" Width="100px" Text='<%#  clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) %>'></asp:Label>
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
