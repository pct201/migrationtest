<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExposuresTab.ascx.cs"
    Inherits="Controls_ExposuresTab_ExposuresTab" %>
<link href='<%=AppConfig.SiteURL%>Controls/SONICtab/SONICTab.css' rel="stylesheet"
    type="text/css" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td id="tab1" class="tab" onclick="RedirectTo(1);">Property
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">Franchise
        </td>
        <td id="tab3" class="tab" onclick="RedirectTo(3);">EHS
        </td>
        <td id="tab6" class="tab" onclick="RedirectTo(6);">Project Management
        </td>
        <td id="tab4" class="tab" onclick="RedirectTo(4);">Inspection
        </td>
        <td id="tab7" class="tab" onclick="RedirectTo(7);">Asset Protection
        </td>
        <td id="tab5" class="tab" onclick="RedirectTo(5);">Leases
        </td>
        <td id="tab8" class="tab" onclick="RedirectTo(8);">Construction
        </td>        
        <td id="tab9" class="tab" onclick="RedirectTo(9);">EHS Inspection
        </td>
        <td id="tab10" class="tab" onclick="RedirectTo(10);">Maintenance
        </td>
        <td>&nbsp;
        </td>
        <td>&nbsp;
        </td>
        <td>&nbsp;
        </td>
    </tr>
</table>
<script type="text/javascript">
    //set the tab style if tab is active than apply class name is "tabselected" else "tab".
    function SetTabStyle(index) {        
        for (var i = 1; i <= 10; i++) {
            var tb = document.getElementById("tab" + i);
            if (i == index)
                tb.className = "tabSelected";
            else
                tb.className = "tab";
        }
    }

    function RedirectTo(index, panel, mode) {
        var loc = '<%=Session["ExposureLocation"]%>';
        if (loc > 0) {
            loc = '<%=Encryption.Encrypt(Session["ExposureLocation"].ToString()) %>';

            switch (index) {
                case 1:                    
                    if (panel != undefined && panel != null && panel.toString() != '') {                        
                        window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyView.aspx?loc=' + loc + panel;
                    }
                    else {
                        window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyView.aspx?loc=' + loc;
                    }
                    break;
                case 2:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Franchise/FranchiseGrid.aspx?loc=' + loc;
                    break;
                case 3:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Pollution/BuildingList.aspx?op=view&loc=' + loc;
                    break;
                case 4:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Inspections.aspx?loc=' + loc;
                    break;
                case 5:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/RealEstate/Lease.aspx?loc=' + loc;
                    break;
                case 6:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Project_Management_Add.aspx?loc=' + loc;
                    break;
                case 7:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection.aspx?loc=' + loc;
                    break;
                case 8:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/ConstructionProjectManagement.aspx?loc=' + loc;
                    break;
                case 9:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/FacilityInspectionList.aspx?loc=' + loc;
                    break;
                case 10:
                    window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/FacilityMaintenance_ItemList.aspx?loc=' + loc;
                        break;
            }
        }
    }
</script>
