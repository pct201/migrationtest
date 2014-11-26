<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DashBoardGraphACI.aspx.cs" Inherits="DashBoardGraphACI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionCharts.js"
        type="text/javascript"></script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table border="0" cellpadding="1" cellspacing="1" width="100%">
        <%--<tr>
            <td class="ghc" align="left" width="100%">
                eRIMS2 Dashboard
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td width="40%" align="right" style="padding-top: 5px">
                            <b>Year : </b>
                        </td>
                        <td width="60%" align="left" style="padding-top: 5px">
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                ID="ddlYear" runat="server" Width="100px" SkinID="dropGen">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right" style="padding-top: 5px">
                            <b>Month : </b>
                        </td>
                        <td width="60%" align="left" style="padding-top: 5px">
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                ID="ddlMonth" runat="server" Width="100px" SkinID="dropGen">
                                <asp:ListItem Text="January" Value="1" Selected="True" />
                                <asp:ListItem Text="February" Value="2" />
                                <asp:ListItem Text="March" Value="3" />
                                <asp:ListItem Text="April" Value="4" />
                                <asp:ListItem Text="May" Value="5" />
                                <asp:ListItem Text="June" Value="6" />
                                <asp:ListItem Text="July" Value="7" />
                                <asp:ListItem Text="August" Value="8" />
                                <asp:ListItem Text="September" Value="9" />
                                <asp:ListItem Text="October" Value="10" />
                                <asp:ListItem Text="November" Value="11" />
                                <asp:ListItem Text="December" Value="12" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
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
                                        <td  align="center" colspan="3">
                                            <b> Year</b>
                                         
                                         
                                            :
                                         
                                             <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                ID="ddlYear" runat="server" Width="100px" SkinID="dropGen">
                            </asp:DropDownList> 
                                            &nbsp; &nbsp;<b> Month</b> : &nbsp; &nbsp;
                                             <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                ID="ddlMonth" runat="server" Width="100px" SkinID="dropGen">
                                <asp:ListItem Text="January" Value="1" Selected="True" />
                                <asp:ListItem Text="February" Value="2" />
                                <asp:ListItem Text="March" Value="3" />
                                <asp:ListItem Text="April" Value="4" />
                                <asp:ListItem Text="May" Value="5" />
                                <asp:ListItem Text="June" Value="6" />
                                <asp:ListItem Text="July" Value="7" />
                                <asp:ListItem Text="August" Value="8" />
                                <asp:ListItem Text="September" Value="9" />
                                <asp:ListItem Text="October" Value="10" />
                                <asp:ListItem Text="November" Value="11" />
                                <asp:ListItem Text="December" Value="12" />
                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" style="width: 30%">
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoard.aspx">Sonic Dealership Map</a>&nbsp;&nbsp;
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraph.aspx">Page 1</a>&nbsp;&nbsp;
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraphCal.aspx">Page 2</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        <tr>
            <td width="100%" valign="top" style="border: 1px solid #666666;" colspan="2" align="center">
                <div id="divchart1" runat="server" style="width: 950px; height: 500px; margin:10px;" />
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top" style="border: 1px solid #666666;" colspan="2" align="center">
                <div id="divchart2" runat="server" style="width: 950px; height: 300px; margin:10px;" />
            </td>
        </tr>
     </table>
    <asp:Label ID="lblMessage" runat="server" />
</asp:Content>

