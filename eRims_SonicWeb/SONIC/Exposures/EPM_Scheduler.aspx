<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="EPM_Scheduler.aspx.cs" Inherits="SONIC_Exposures_EPM_Scheduler" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="print">
        .noPrint
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function printPage() {
            if (window.print) {
                window.print();
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function RedirectToProject(PK_Identification, LocationID) {
            window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Project_Management.aspx?loc=' + LocationID + '&id=' + PK_Identification + '&op=edit';
        }
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="spacer" style="height: 12px;">
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="1" cellspacing="3" border="0">
                    <tr>
                        <td align="right">
                            Region :&nbsp;
                        </td>
                        <td align="left" style="width: 250px;">
                            <asp:DropDownList ID="drpRegion" runat="server" Width="250px" AutoPostBack="true"
                                OnSelectedIndexChanged="drpRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Location :&nbsp;
                        </td>
                        <td align="left" style="width: 250px;">
                            <asp:DropDownList ID="drpLocationFilter" runat="server" Width="250px" AutoPostBack="true"
                                OnSelectedIndexChanged="drpLocationFilter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left" style="width: 250px;">
                            <asp:CheckBox ID="chkAllLocation" Text="All Locations" runat="server" AutoPostBack="true"
                                OnCheckedChanged="chkAllLocation_OnCheckedChanged" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="spacer" style="height: 12px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" align="left" width="100%" height="450">
                            <table width="100%" border="0" cellspacing="3" cellpadding="4">
                                <tr>
                                    <td align="center" class="calfont">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="right" style="padding-top: 3px;" width="62%">
                                                                <table width="230" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td width="31">
                                                                            <asp:ImageButton ID="imgPrevious" CssClass="nobg" runat="server" ImageUrl="~/Images/btn_prev.gif"
                                                                                OnClick="imgPrevious_Click" BorderStyle="None" />
                                                                        </td>
                                                                        <td valign="middle" align="center" style="font-size: 11pt; font-weight: bold; color: #333333;">
                                                                            <strong>
                                                                                <asp:Literal ID="lblMonth" runat="server"></asp:Literal></strong>
                                                                        </td>
                                                                        <td align="left" width="31">
                                                                            <asp:ImageButton ID="imgNext" CssClass="nobg" ImageUrl="~/Images/btn_next.gif" runat="server"
                                                                                BorderStyle="None" OnClick="imgNext_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="right">
                                                                <table width="" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="right" valign="top">
                                                                            <img src="../../images/printer.png" class="noPrint" style="cursor: hand;" onclick="javascript:printPage();"
                                                                                alt="" />&nbsp;
                                                                        </td>
                                                                        <td align="left">
                                                                            <a href="javascript:void(0);" style="cursor: hand;" onclick="javascript:printPage();">
                                                                                Print</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="right" valign="top">
                                                                            <asp:DropDownList ID="ddlMonth" Width="90px" SkinID="dropGen" runat="server" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                                                <asp:ListItem Text="January" Value="1">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="February" Value="2">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="March" Value="3">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="April" Value="4">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="May" Value="5">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="June" Value="6">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="July" Value="7">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="August" Value="8">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="September" Value="9">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="October" Value="10">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="November" Value="11">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="December" Value="12">
                                                                                </asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            &nbsp;
                                                                            <asp:DropDownList ID="ddlYear" Width="60px" SkinID="dropGen" runat="server" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Calendar ID="calMonth" BackColor="White" DayHeaderStyle-CssClass="PropertyInfoBG"
                                            SelectedDayStyle-BackColor="White" runat="server" DayStyle-Font-Underline="false"
                                            DayStyle-ForeColor="#315D84" TitleStyle-BackColor="White" DayNameFormat="Full"
                                            TodayDayStyle-BackColor="White" Width="100%" SelectionMode="None" Height="100%"
                                            ShowGridLines="True" ShowTitle="false" ShowNextPrevMonth="false" SelectedDayStyle-ForeColor="White"
                                            OnDayRender="calMonth_DayRender" DayHeaderStyle-Height="20" ToolTip="" DayStyle-VerticalAlign="Top">
                                            <SelectedDayStyle BackColor="White" ForeColor="#315D84" />
                                            <TodayDayStyle BackColor="#f4f3f3" />
                                            <DayStyle Font-Underline="False" ForeColor="#315D84" VerticalAlign="Top" />
                                            <DayHeaderStyle CssClass="PropertyInfoBG" Height="20px" />
                                            <TitleStyle BackColor="White" />
                                        </asp:Calendar>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="spacer" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_OnClick" />
                        </td>
                    </tr>
                    <tr>
                        <td class="spacer" style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
