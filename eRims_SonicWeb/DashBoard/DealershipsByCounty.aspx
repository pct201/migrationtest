<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealershipsByCounty.aspx.cs"
    Inherits="DashBoard_DealershipsByCounty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sonic Dealerships By County</title>
</head>
<script language="javascript" type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/FusionMaps.js"></script>
<link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
</script>
<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
<script type="text/javascript" language="javascript">
    function OpenSonicLocation(Pk_State, FIPS_county, StateName, CountyName) {
        //GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/SonicLocationByDealership.aspx?state=' + Pk_State, 500, 1000, '');
        //window.open('<%=AppConfig.SiteURL%>DashBoard/SonicLocationByDealership.aspx?state=' + Pk_State + "&county=" + FIPS_county, '', 'toolbar=0, status=0, menubar=0,title bar=no, scrollbars=1, resizable=0,top=200,left=250, width=1000, height=500');        

        var w = 480, h = 340;

        if (document.all || document.layers) {
            w = screen.availWidth;
            h = screen.availHeight;
        }

        var leftPos, topPos;
        var popW = 1000, popH = 500;
        if (document.all)
        { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
        else
        { leftPos = w / 2; topPos = h / 2; }

        window.open("<%=AppConfig.SiteURL%>DashBoard/SonicLocationByDealership.aspx?state=" + Pk_State + "&county=" + FIPS_county + "&Sname=" + StateName + "&Cname=" + CountyName, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    }   
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" style="width: 997px; height: 450px;" cellpadding="0" cellspacing="0"
            class="BorderWhite">
            <tr>
                <td class="blueTr" height="28" style="text-align: center;">
                    <asp:Label ID="lblheader" runat="server" CssClass="textBoldLight"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Literal ID="USStateMap" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
