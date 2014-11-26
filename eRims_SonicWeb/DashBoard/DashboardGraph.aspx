<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="DashboardGraph.aspx.cs" Inherits="DashboardGraph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/default.js"
        type="text/javascript"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionCharts.js"
        type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function OpenPopup(region, Year, MapID, CompAvg) {
            var w = 700, h = 550;

            var navigationurl;
            navigationurl = 'ScorecardByLocation.aspx?region=' + region + "&year=" + Year + "&map=" + MapID + '&' + new Date().toString() + "&CompAvg=" + CompAvg;

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 850, popH = 575;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navigationurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
        }
    </script>
    <div align="center" style="width: 100%">
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td align="left" colspan="2">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="width: 30%" class="heading">
                                Dashboard Scorecard
                            </td>
                            <td style="width: 40%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 48%" align="right">
                                            Year
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" style="width: 48%" valign="top">
                                            <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                                AutoPostBack="true" SkinID="dropGen">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" style="width: 30%">
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoard.aspx">Sonic Dealership Map</a>&nbsp;&nbsp;
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraphCal.aspx">Page 2</a>&nbsp;&nbsp;
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraphACI.aspx">Page 3</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetAggregatePerformanceByRegion() %>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetChartSLTByRegion()%>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartFacilityInspectionByRegion()%>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartSabaTrainingByRegion()%>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartIncidentInvestigationByRegion()%>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetChartWCCLaimMgmtByRegion() %>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartIncidentReductionByRegion()%>
                    </div>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
