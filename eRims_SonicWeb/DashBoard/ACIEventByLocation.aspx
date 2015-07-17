<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ACIEventByLocation.aspx.cs" Inherits="DashBoard_ACIEventByLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>
</head>

<script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionCharts.js" type="text/javascript"></script>

<body>
    <form id="form1" runat="server">
        <div id="divchart2" runat="server" />
    </form>
</body>

<script type="text/javascript" language="javascript">    
    function OpenPopup(FK_LU_Location, Year, Month) {
        var navUrl = '<%=AppConfig.SiteURL%>DashBoard/ACIEventCountByLocation.aspx?FK_LU_Location=' + FK_LU_Location + '&Year=' + Year + '&Month=' + Month;
        OpenWindow(navUrl);
    }

    function OpenWindow(navUrl) {
        var w = 700, h = 550;

        if (document.all || document.layers) {
            w = screen.availWidth;
            h = screen.availHeight;
        }

        var leftPos, topPos;
        var popW = 800, popH = 400;
        if (document.all)
        { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
        else
        { leftPos = w / 2; topPos = h / 2; }

        window.open(navUrl, "popup2", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    }
    //-->
</script>

</html>
