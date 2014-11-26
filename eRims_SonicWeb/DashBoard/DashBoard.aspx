<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs"
    Inherits="DashBoard" Title="eRIMS Sonic :: DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
    </script>
    <script language="javascript" type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/FusionMaps.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <table width="100%" cellpadding="0" cellspacing="0" style="display: none;">
        <tr>
            <td>
                <input type="hidden" id="hdntext" name="hdntext" value="" />
                <asp:Button runat="server" ID="btnHdnStatusPage" Style="display: none;" OnClick="btnHdnStatusPage_Click" />
            </td>
        </tr>
    </table>
    <table align="center" style="width: 997px; height: 450px;" cellpadding="0" cellspacing="0"
        class="BorderWhite">
        <tr>
            <td align="right" style="padding-top: 5px; padding-bottom: 5px;">
                <a href="<%=AppConfig.SiteURL%>DashBoard/DashboardGraph.aspx">Dashboard Scorecard</a>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="blueTr" height="28" style="text-align: center;">
                <span class="textBoldLight" id="pmRootTitle">Sonic Dealerships By State</span>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Literal ID="USStateMap" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">    
    <!--
        function OpenRegionMap(val, mapname) {
            if (val == 'TX') {
                GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/DealershipsByCounty.aspx?state=' + val + '&mp_id=' + mapname.toString() + '&' + new Date().toString(), 550, 1000, '');
            }
            else {
                GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/DealershipsByCounty.aspx?state=' + val + '&mp_id=' + mapname.toString() + '&' + new Date().toString(), 500, 1000, '');
            }
        }
    //-->
    </script>
    <script type="text/javascript">

        function OpenWizardPopup() {
            GB_showCenter('', '<%=AppConfig.SiteURL%>SONIC/FirstReport/UncompleteFirstReportdialogue.aspx', 325, 500, ReturnFunction);
        }

        function ReturnFunction() {
            if (document.getElementById('hdntext').value == "false") {
                __doPostBack(document.getElementById('<%=btnHdnStatusPage.ClientID%>').name, '');
            }

        }
     
    </script>
</asp:Content>
