<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="MaintenanceDashboardGraph.aspx.cs" Inherits="DashBoard_MaintenanceDashboardGraph" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/default.js"
        type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts_New/FusionCharts.js"
        type="text/javascript"></script>
    <div align="center" style="width: 100%">

    </div>
    <table cellpadding="3" cellspacing="3" width="100%" border="0" align="center">
            <tr>
                <td align="left" style="width: 20%" class="heading">Maintenance Dashboard
                </td>
                <td align="right" style="width: 10%">Sonic Location Code
                </td>
                <td align="center" style="width: 4%">:
                </td>
                <td align="left" style="width: 30%">
                   <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="Default" Width="90%"
                     runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged"> </asp:DropDownList>
                </td>
                <td align="right" style="width: 30%">
                    <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoard.aspx">Sonic Dealership Map</a>&nbsp;&nbsp;
                    <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraph.aspx">Page 1</a>&nbsp;&nbsp;
                    <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraphCal.aspx">Page 2</a>&nbsp;&nbsp;
                    <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraphACI.aspx">Page 3</a>                               
               </td>
            </tr>
        </table>
       <div align="center" style="width: 100%">
        <table border="0" cellpadding="2" cellspacing="2" width="100%">l
            <tr>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetPriorityWiseActiveUsers() %>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetAssigneeWiseActiveUsers() %>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetTop10CustomersWiseActiveUsers() %>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
