<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScorecardByLocation.aspx.cs"
    Inherits="ScorecardByLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta name="robots" content="noindex" />
</head>
<link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
    var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
</script>

<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>

<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>

<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>

<script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/default.js"
    type="text/javascript"></script>

<script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionCharts.js"
    type="text/javascript"></script>

<body>
    <form id="form1" runat="server">
    <div>
        <%= GetDetailChart()%>
    </div>
    </form>
</body>

<script type="text/javascript" language="javascript">    
    <!--

    // grey box is removed due to the problem in IE 9

    function OpenPopup(DBA, Code, year, MapID) {
        //GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?DBA=' + DBA.replace(/&/g, '%26') + '&Code=' + Code.toString() + '&year=' + year + '&MapID=' + MapID + '&' + new Date().toString(), 300, 400, '');
        var navUrl = '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?DBA=' + DBA.replace(/&/g, '%26') + '&Code=' + Code.toString() + '&year=' + year + '&MapID=' + MapID + '&' + new Date().toString();
        OpenWindow(navUrl);
    }

    function OpenPopupForWCClaim(DBA, AvgDays, Level, MapID) {
        //GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?DBA=' + DBA.replace(/&/g, '%26') + '&Avg=' + AvgDays.toString() + '&level=' + Level + '&MapID=' + MapID + '&' + new Date().toString(), 300, 400, '');
        var navUrl = '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?DBA=' + DBA.replace(/&/g, '%26') + '&Avg=' + AvgDays.toString() + '&level=' + Level + '&MapID=' + MapID + '&' + new Date().toString();
        OpenWindow(navUrl);
    }

    function OpenPopupForAggreage(Region, DBA, Code, Year, MapID) {
        //GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?Region=' + Region + '&DBA=' + DBA.replace(/&/g, '%26') + '&Code=' + Code.toString() + '&year=' + Year + '&MapID=' + MapID + '&' + new Date().toString(), 300, 400, '');
        var navUrl = '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?Region=' + Region + '&DBA=' + DBA.replace(/&/g, '%26') + '&Code=' + Code.toString() + '&year=' + Year + '&MapID=' + MapID + '&' + new Date().toString();
        OpenWindow(navUrl);
    }

    function OpenWindow(navUrl) {
        var w = 700, h = 550;

        if (document.all || document.layers) {
            w = screen.availWidth;
            h = screen.availHeight;
        }

        var leftPos, topPos;
        var popW = 400, popH = 300;
        if (document.all)
        { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
        else
        { leftPos = w / 2; topPos = h / 2; }
        
        window.open(navUrl, "popup2", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    }
    //-->
</script>

</html>
