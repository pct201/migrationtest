<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExposuresTab.ascx.cs"
    Inherits="Controls_ExposuresTab_ExposuresTab" %>
<link href='<%=AppConfig.SiteURL%>Controls/SONICtab/SONICTab.css' rel="stylesheet"
    type="text/css" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td id="tab1" class="tab" onclick="RedirectTo(1);">
            Property
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">
            Franchise
        </td>
        <td id="tab3" class="tab" onclick="RedirectTo(3);">
            EHS
        </td>
        <td id="tab6" class="tab" onclick="RedirectTo(6);">
            Project Management
        </td>
        <td id="tab4" class="tab" onclick="RedirectTo(4);">
            Inspection
        </td>
        <td id="tab7" class="tab" onclick="RedirectTo(7);">
            Asset Protection
        </td>
        <td id="tab5" class="tab" onclick="RedirectTo(5);">
            Leases
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<script type="text/javascript">
    //set the tab style if tab is active than apply class name is "tabselected" else "tab".
    function SetTabStyle(index) {
        var i;
        for (i = 1; i <= 7; i++) {
            var tb = document.getElementById("tab" + i);
            if (i == index)
                tb.className = "tabSelected";
            else
                tb.className = "tab";
        }
    }

    function RedirectTo(index) {
        var loc = '<%=Session["ExposureLocation"]%>';
        if (loc > 0) {
            loc = '<%=Encryption.Encrypt(Session["ExposureLocation"].ToString()) %>';
            if (index == 1)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyView.aspx?loc=' + loc;
            else if (index == 2)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Franchise/FranchiseGrid.aspx?loc=' + loc;
            else if (index == 3)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Pollution/BuildingList.aspx?op=view&loc=' + loc;
            else if (index == 4)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Inspections.aspx?loc=' + loc;
            else if (index == 5)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/RealEstate/Lease.aspx?loc=' + loc;
            else if (index == 6)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Project_Management_Add.aspx?loc=' + loc;
            else if (index == 7)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection.aspx?loc=' + loc;

        }
    }
</script>
