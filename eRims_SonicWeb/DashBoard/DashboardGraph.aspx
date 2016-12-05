<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="DashboardGraph.aspx.cs" Inherits="DashboardGraph" %>

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

        function ExpandNotes(bExpand, index) {
            var intMsgLen = document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_hdMessageLength").value;
            if (bExpand) {
                if (intMsgLen >= 3500)
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "400px";
                else
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "";
                document.getElementById("imgMinus" + index).style.display = "block";
                document.getElementById("imgPlus" + index).style.display = "none";
            }
            else {
                if (intMsgLen >= 2500)
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "200px";
                else
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "";
                document.getElementById("imgMinus" + index).style.display = "none";
                document.getElementById("imgPlus" + index).style.display = "block";
            }
        }

        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }
    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div align="center" style="width: 100%">
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td align="left" colspan="2">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="width: 30%" class="heading">Messages and Dashboard Scorecard
                            </td>
                            <td style="width: 40%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 48%" align="right">Year
                                        </td>
                                        <td style="width: 4%" align="center">:
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
                                <a href="<%=AppConfig.SiteURL%>DashBoard/DashBoardGraphACI.aspx">Page 3</a>&nbsp;&nbsp;
                                <a href="<%=AppConfig.SiteURL%>DashBoard\MaintenanceDashboardGraph.aspx">Maintenance DashBoard</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 50%">

                    <div style="border: solid 1px #666666; height: 410px; overflow-x: hidden; overflow-y: scroll;">
                        <asp:UpdatePanel runat="server" ID="updStatus">
                            <ContentTemplate>
                                <asp:Panel ID="pnlWall" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <%--<td>
                                            <img src ="../../Images/SLT_homepage_logo.jpg" alt="SLT_homepage" height="50px" width="100px"/>
                                        </td>--%>
                                            <td valign="top" align="left">
                                                <b>Posts Found :</b>&nbsp;<asp:Label ID="lblNumber" runat="server" Font-Bold="true"
                                                    Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                               <table width="98%">
                                                 <tr>
                                                     <td>
                                                        <uc:ctrlPaging ID="ctrlPageWallPost" runat="server" OnGetPage="GetPage"/>
                                                     </td>
                                                 </tr>
                                               </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table cellpadding="0" cellspacing="0" style="border-left: solid 1px Silver; border-right: solid 1px Silver; border-top: solid 1px Silver;"
                                                    width="99%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Repeater ID="rptPosts" runat="server" OnItemDataBound="rptPosts_ItemDataBound"
                                                                OnItemCommand="rptPosts_ItemCommand">
                                                                <ItemTemplate>
                                                                    <table width="100%" cellpadding="4" cellspacing="1" border="0" style="font-size: 11px; font-family: Verdana;">
                                                                        <tr>
                                                                            <td align="left" style="color: Gray; padding-left: 5px;">&nbsp;Posted By:
                                                            <%# Eval("First_Name") + ", " + Eval("Last_Name")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;On:&nbsp;<%#clsGeneral.FormatDBNullDateTimeToMilitaryDateTime(Eval("Update_Date"))%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="padding-left: 5px;">
                                                                                <table cellpadding="3" cellspacing="1" width="98%" id="tblNotes" runat="server">
                                                                                    <tr style="height: 20px;">
                                                                                        <td align="left" width="90%" style="font-weight: bold; word-wrap: normal; word-break: break-all;">Topic:
                                                                        <%#Eval("Topic") %>
                                                                                        </td>
                                                                                        <td align="right" valign="middle" runat="server" id="tdExpandControls">
                                                                                            <img id="imgPlus<%#Container.ItemIndex %>" alt="" src="../Images/plus.jpg" style="cursor: pointer;"
                                                                                                onclick='javascript:ExpandNotes(true,"<%#Container.ItemIndex %>");' />
                                                                                            <img id="imgMinus<%#Container.ItemIndex %>" alt="" src="../Images/minus.jpg" style="cursor: pointer; display: none;"
                                                                                                onclick='javascript:ExpandNotes(false,"<%#Container.ItemIndex %>");' />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="word-wrap: normal; word-break: break-all;">
                                                                                            <div id="dvMainMessage" runat="server" style="overflow-y: auto; font-size: 11px; font-family: Verdana;">
                                                                                                <%#Eval("Message") %>
                                                                                            </div>
                                                                                            <asp:HiddenField ID="hdMessageLength" runat="server" Value="0" />
                                                                                            <asp:HiddenField ID="hdnIndex" runat="server" Value="<%#Container.ItemIndex %>" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <table width="100%" cellpadding="2" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td align="left" width="60%">&nbsp;&nbsp;<asp:Label ID="lblAttchment" runat="server" Text="Attachment : "></asp:Label><asp:LinkButton
                                                                                            ID="lnkAttchment" runat="server" Visible="false"></asp:LinkButton><br />
                                                                                            <asp:Image ID="imgAttachment" runat="server" Width="150" Height="150" Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border-bottom: solid 3px #808080; height: 5px;">
                                                                                <asp:Repeater ID="rptPostsComments" runat="server" OnItemDataBound="rptPostsComments_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <table width="95%" cellpadding="4" cellspacing="1" border="0" style="font-size: 11px; font-family: Verdana; background-color: #EDF2F8;">
                                                                                            <tr>
                                                                                                <td align="left" style="color: Gray; padding-left: 5px; border-top: solid 1px Silver;">Posted By:
                                                                                <%# Eval("First_Name") + ", " + Eval("Last_Name")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;On:&nbsp;<%#clsGeneral.FormatDBNullDateTimeToDisplay(Eval("Update_Date"))%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="padding-left: 5px;">
                                                                                                    <table cellpadding="3" cellspacing="1" width="98%" id="Table1" runat="server">
                                                                                                        <tr style="height: 20px;">
                                                                                                            <td align="left" width="90%" style="font-weight: bold;">RE:
                                                                                            <%#Eval("Topic") %>
                                                                                                            </td>
                                                                                                            <td align="right" valign="middle" runat="server" id="trExpandControls">
                                                                                                                <img id="imgPlusComment<%#Container.ItemIndex %>" alt="" src="../Images/plus.jpg"
                                                                                                                    style="cursor: pointer;" onclick='javascript:ExpandNotesComment(true,"<%#Container.ItemIndex %>","<%#((HiddenField)Container.Parent.Parent.FindControl("hdnIndex")).Value%>");' />
                                                                                                                <img id="imgMinusComment<%#Container.ItemIndex %>" alt="" src="../Images/minus.jpg"
                                                                                                                    style="cursor: pointer; display: none;" onclick='javascript:ExpandNotesComment(false,"<%#Container.ItemIndex %>","<%#((HiddenField)Container.Parent.Parent.FindControl("hdnIndex")).Value%>");' />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="2">
                                                                                                                <div id="dvCommentMessage" runat="server" style="overflow-y: auto; font-size: 11px; font-family: Verdana;">
                                                                                                                    <%#Eval("Message") %>
                                                                                                                </div>
                                                                                                                <asp:HiddenField ID="hdCommentMsgLength" runat="server" Value="0" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left">&nbsp;<asp:Label ID="lblAttchmentComment" runat="server" Text="Attachment : "></asp:Label><asp:LinkButton
                                                                                                    ID="lnkAttchmentComment" runat="server" Visible="false"></asp:LinkButton><br />
                                                                                                    <asp:Image ID="imgAttachmentComment" runat="server" Width="150" Height="150" Visible="false" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <table width="100%" cellpadding="4" cellspacing="1" border="0" style="font-size: 11px; font-family: Verdana;">
                                                                    <tr id="trEmpty" runat="server" visible="false">
                                                                        <td colspan = "3" align = "center">
                                                                            No records found.
                                                                        </td>
                                                                    </tr>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search Posts" SkinID="btnGen" OnClick="btnSearch_Click" />
                                                &nbsp;&nbsp;
                                            <asp:Button ID="btnAdd" runat="server" Text="  Add Post " SkinID="btnGen" OnClick="btnAdd_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlSearch" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%" align="center">
                                        <tr>
                                            <td width="100%" class="Spacer" style="height: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td class="ghc" align="left">Wall Search
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table cellpadding="5" cellspacing="0" border="0" width="90%">
                                                    <tr>
                                                        <td align="left" width="20%">Poster Last Name
                                                        </td>
                                                        <td align="center" width="5%">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtPosterLastName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Poster First Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtPosterFirstName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date of Post From
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtDatePostFrom" runat="server" Width="150px" SkinID="txtDate"
                                                                MaxLength="10"></asp:TextBox>
                                                            <img onclick="return showCalendar('<%= txtDatePostFrom.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                                                align="middle" id="img2" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDatePostFrom"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="revtxtDatePostFrom" runat="server" ControlToValidate="txtDatePostFrom"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                ErrorMessage=" Date of Post From is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                                                SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date of Post To
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtDatePostTo" runat="server" Width="150px" SkinID="txtDate"
                                                                MaxLength="10"></asp:TextBox>
                                                            <img onclick="return showCalendar('<%= txtDatePostTo.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                                                align="middle" id="img1" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDatePostTo"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="rfvtxtDatePostTo" runat="server" ControlToValidate="txtDatePostTo"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                ErrorMessage="  Date of Post To is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                                                SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtDatePostTo"
                                                                ValidationGroup="vsErrorGroup" ErrorMessage="Date of Post From must be Less than or equal to Date of Post To"
                                                                Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDatePostFrom" Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Topic
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtTopic" runat="server" MaxLength="300" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Post Text
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtPostText" TextMode="MultiLine" Rows="4" runat="server" MaxLength="4000"
                                                                Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="6">
                                                            <asp:Button ID="btnSearchResult" runat="server" Text="Search" SkinID="btnGen" OnClick="btnSearchResult_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </td>
                <td align="left" style="width: 50%;">
                    <div style="border: solid 1px #666666;">
                        <%=GetAggregatePerformanceByRegion() %>
                        <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetChartSLTByRegion()%>
                         <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartFacilityInspectionByRegion()%>
                        <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartSabaTrainingByRegion()%>
                        <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartIncidentInvestigationByRegion()%>
                        <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%=GetChartWCCLaimMgmtByRegion() %>
                        <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
                <td align="left" style="width: 50%">
                    <div style="border: solid 1px #666666;">
                        <%= GetChartIncidentReductionByRegion()%>
                        <div style="color:grey;text-align:center;margin-left:90px;">
                            <b>T</b>-Tin &nbsp; <b>B</b>-Bronze&nbsp; <b>S</b>-Silver&nbsp; <b>G</b>-Gold&nbsp; <b>P</b>-Platinum 
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
