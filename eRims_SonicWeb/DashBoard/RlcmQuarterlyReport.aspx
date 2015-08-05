<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="RlcmQuarterlyReport.aspx.cs" Inherits="DashBoard_RlcmQuarterlyReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/default.js"
        type="text/javascript"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionCharts.js"
        type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/scroll.js"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionChartsExportComponent.js"
        type="text/javascript"></script>
    <script type="text/javascript">

        /* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
        (function () {
            //for non IE modern browser
            if (window.addEventListener) {
                function loadFn() {
                    var currentX = window.pageXOffset, currentY = window.pageYOffset,
                    screenWidth = window.innerWidth, screenHeight = window.innerHeight,
                    scrollMaxX = window.scrollMaxX, scrollMaxY = window.scrollMaxY,
                    winMaxHeight = scrollMaxY + screenHeight, winMaxWidth = scrollMaxX + screenWidth, x, y;
                    if (scrollMaxX > 0 || scrollMaxY > 0) {
                        y = 0;
                        do {
                            x = 0;
                            do {
                                window.scrollTo(x, y);
                                x += screenWidth;
                            } while (x < winMaxWidth)
                            y += screenHeight;
                        } while (y < winMaxHeight)
                    }

                    //scroll to current position
                    window.scrollTo(currentX, currentY);
                }
                window.addEventListener('load', loadFn, false);
            }
        }())



        var initiateExport = false;
        function exportCharts(exportFormat) {            
            initiateExport = true;
            $("html, body").animate({ scrollTop: 0 }, 25000);
            for (var chartRef in FusionCharts.items) {
                if (FusionCharts.items[chartRef].exportChart) {
                    //document.getElementById("linkToExportedFile").innerHTML = "Exporting...";
                    FusionCharts.items[chartRef].exportChart({ "exportFormat": exportFormat });
                }
                else {
                    //document.getElementById("linkToExportedFile").innerHTML = "Please wait till the chart completes rendering...";
                }
            }
        }

        function FC_Exported(statusObj) {
            if (initiateExport) {
                initiateExport = false;
                document.getElementById("linkToExportedFile").innerHTML = "";
            }
            if (statusObj.statusCode == "1") {
                document.getElementById("linkToExportedFile").innerHTML += "Export successful. View it from <a target='_blank' href='" + statusObj.fileName + "'>here</a>.<br/>";
            }
            else {
                document.getElementById("linkToExportedFile").innerHTML += "Export unsuccessful. Notice from export handler : " + statusObj.notice + "<br/>";
            }
        }
    </script>
    <script type="text/javascript">
        //Initialize Batch Exporter with DOM Id as fcBatchExporter        
        function RenderExportComponent() {
            var myExportComponent = new FusionChartsExportObject("fcBatchExporter", "<%=AppConfig.SiteURL%>FusionCharts/FCExporter.swf");
            //Add the charts to queue. The charts are referred to by their DOM Id.
            //myExportComponent.sourceCharts = ['EastCoast', 'Midsouth', 'NCA'];
            //myExportComponent.sourceCharts = ['', '', ''];
            //------ Export Component Attributes ------//
            //Set the mode as full mode
            myExportComponent.componentAttributes.fullMode = '0';
            //Set saving mode as both. This allows users to download individual charts/ as well as download all charts as a single file.
            //myExportComponent.componentAttributes.saveMode = 'both';
            //Show allowed export format drop-down
            myExportComponent.componentAttributes.showAllowedTypes = '1';

            myExportComponent.componentAttributes.defaultExportFormat = 'PDF';
            myExportComponent.exportAttributes.exportFormat = 'PDF';
            //Cosmetics
            //Width and height
            myExportComponent.componentAttributes.width = '150';
            myExportComponent.componentAttributes.height = '100';
            //Message - caption of export component
            myExportComponent.componentAttributes.showMessage = '0';
            myExportComponent.componentAttributes.message = 'Click on button above to begin export of charts. Then save from here.';
            //Render the exporter SWF in our DIV fcexpDiv
            myExportComponent.Render("fcexpDiv");
        }
            
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
        <ProgressTemplate>
            <div class="UpdatePanelloading" id="divProgress" style="width: 100%; position: fixed;">
                <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                    height: 100%;">
                    <tr align="center" valign="middle">
                        <td class="LoadingText" align="center" valign="middle">
                            <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div align="center" style="width: 100%">
        <asp:Panel ID="pnlCriteria" runat="server">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="bandHeaderRow" align="left">
                        RLCM Quarterly Performance Report
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="2" width="80%">
                <tr>
                    <td align="left" class="lc" valign="top">
                        Region
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:ListBox ID="lstRegion" runat="server" Width="180px" AutoPostBack="true" SelectionMode="Multiple"
                            OnSelectedIndexChanged="lstRegion_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td align="left" class="lc" valign="top">
                        RLCM
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:ListBox ID="lstRLCM" runat="server" Width="180px" AutoPostBack="true" SelectionMode="Multiple"
                            OnSelectedIndexChanged="lstRLCM_SelectedIndexChanged"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc" valign="top">
                        Market
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:ListBox ID="lstMarket" runat="server" Width="180px" SelectionMode="Multiple"></asp:ListBox>
                    </td>                    
                    <td align="left" class="lc">
                        Sort By
                    </td>
                    <td align="right" class="lc" >
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:RadioButtonList id="rdoSortBy" runat="server">
                            <asp:ListItem Text="Region" Value ="Region" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="RLCM" Value ="RLCM"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>                    
                </tr>
                <tr>
                    <td align="left" class="lc">
                        State
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlState" runat="server" Width="180px" SkinID="ddlSONIC" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        Prior Year Begin &nbsp;<span id="Span8" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:TextBox ID="txtPriorFromDate" runat="server" ReadOnly="false" MaxLength="10"
                            Width="150px" SkinID="txtDate"></asp:TextBox>
                        <img onclick="return showCalendarControl(<%=txtPriorFromDate.ClientID %>, 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                            align="absmiddle" />
                        <asp:RequiredFieldValidator ID="RfvPriorfromDae" runat="server" ControlToValidate="txtPriorFromDate"
                            ErrorMessage="Please Enter Prior Year Start Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revIssueDateFrom" runat="server" ControlToValidate="txtPriorFromDate"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                            ErrorMessage="Please Enter Valid Prior Year Begin Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="PriorDateCompare" runat="server" ControlToValidate="txtPriorFromDate"
                            ControlToCompare="txtPriorToDate" Operator="LessThan" Type="Date" Display="None"
                            ErrorMessage=" Prior year begin is must precedes the prior year end date" SetFocusOnError="true"
                            ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                    </td>
                    <td align="left" class="lc">
                        Prior Year End &nbsp;<span id="Span1" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:TextBox ID="txtPriorToDate" runat="server" ReadOnly="false" MaxLength="10" Width="150px"
                            SkinID="txtDate"></asp:TextBox>
                        <img onclick="return showCalendarControl(<%=txtPriorToDate.ClientID %>, 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                            align="absmiddle" />
                        <asp:RequiredFieldValidator ID="RfvPriorEndDate" runat="server" ControlToValidate="txtPriorToDate"
                            ErrorMessage="Please Enter Prior Year End Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPriorToDate"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                            ErrorMessage="Please Enter Valid Prior Year End Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="PriorEndateCompare" runat="server" ControlToValidate="txtPriorToDate"
                            ControlToCompare="txtCurrentFromDate" Operator="LessThan" Type="Date" Display="None"
                            ErrorMessage="Prior year end is must precedes the current year begin date" SetFocusOnError="true"
                            ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        Current Year Begin &nbsp;<span id="Span2" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:TextBox ID="txtCurrentFromDate" runat="server" ReadOnly="false" MaxLength="10"
                            Width="150px" SkinID="txtDate"></asp:TextBox>
                        <img onclick="return showCalendarControl(<%=txtCurrentFromDate.ClientID %>, 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                            align="absmiddle" />
                        <asp:RequiredFieldValidator ID="RfvCurrentFromDate" runat="server" ControlToValidate="txtCurrentFromDate"
                            ErrorMessage="Please Enter Current Year Start Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCurrentFromDate"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                            ErrorMessage="Please Enter Valid Current Year Begin Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CurrentFromDateCompare" runat="server" ControlToValidate="txtCurrentFromDate"
                            ControlToCompare="txtCurrentToDate" Operator="LessThan" Type="Date" Display="None"
                            ErrorMessage="Current year begin is must precedes the current year end date"
                            SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                    </td>
                    <td align="left" class="lc">
                        Current Year End &nbsp;<span id="Span3" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:TextBox ID="txtCurrentToDate" runat="server" ReadOnly="false" MaxLength="10"
                            Width="150px" SkinID="txtDate"></asp:TextBox>
                        <img onclick="return showCalendarControl(<%=txtCurrentToDate.ClientID %>, 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                            align="absmiddle" />
                        <asp:RequiredFieldValidator ID="RfvCurrentToDate" runat="server" ControlToValidate="txtCurrentToDate"
                            ErrorMessage="Please Enter Current Year End Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCurrentToDate"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                            ErrorMessage="Please Enter Valid Current Year End Date" Display="none" ValidationGroup="vsErrorGroup"
                            SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnReport" runat="server" Text="Generate Report" ValidationGroup="vsErrorGroup"
                            OnClick="btnReport_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear Criteria" CausesValidation="false"
                            OnClick="btnclear_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlReport" runat="server">
            <table width="80%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" width="100%">
                        <asp:LinkButton ID="lnkBack" Text="Back" runat="server" CausesValidation="false"
                            Font-Bold="true" OnClick="btnBack_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <div class="bandHeaderRow" style="padding-bottom: 2px;">
                            <table width="100%" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <asp:ImageButton ID="imgCharts" ImageAlign="Right" runat="server" ImageUrl="~/Images/down-arrow.gif"
                                                ValidationGroup="vsErrorGroup" OnClientClick="ShowHideTR(); return false;" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--<asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pnlCharts"
							ExpandControlID="imgCharts" CollapseControlID="imgCharts" Collapsed="false" SuppressPostBack="true" />--%>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 100%" colspan="6">
                        <asp:Panel ID="pnlCharts" runat="server" >
                            <table width="100%" >
                                <tr>
                                    <td>
                                        <div id="divCharts" runat="server" style="width: 90%">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" >
                                <tr>
                                    <td align="right">
                                        <input value="Export to PDF" type="button" onclick="JavaScript:exportCharts('PDF')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <div id="fcexpDiv">
                                        </div>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>--%>
                            </table>
                        </asp:Panel>
                        <%--<div id="linkToExportedFile" style="margin-top: 10px; padding: 5px; width: 600px;
							background: #efefef; border: 1px dashed #cdcdcd; color: 666666;">
							Exported status.</div>--%>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="Upd1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div class="bandHeaderRow" style="padding-bottom: 2px;">
                                    <table width="100%" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblSLTScoring" runat="server" Text="SAFETY LEADERSHIP TEAMS"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Panel ID="ttpnlSLTScoring" runat="server">
                                                    <asp:ImageButton ID="imgSLTScoring" ImageAlign="Right" runat="server" ImageUrl="~/Images/down-arrow.gif"
                                                        ValidationGroup="vsErrorGroup" OnClick="imgSLTScoring_Click" OnClientClick="HideDiv(1);" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:CollapsiblePanelExtender ID="cpeSLTScoring" runat="server" TargetControlID="pnlSLTScoring"
                                        ExpandControlID="imgSLTScoring" CollapseControlID="imgSLTScoring" Collapsed="true"
                                        SuppressPostBack="false" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlSLTScoring" runat="server" Width="900px" ScrollBars="Auto" Height="400px">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td align="left" style="width: 30%" class="heading">
                                                SLT Scoring Current Year
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvSLTScoring" runat="server" AutoGenerateColumns="false" Width="100%"
                                                    OnRowDataBound="gvSLTScoring_RowDataBound" EmptyDataText="No Record Found.">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegion" runat="server" Text='<%# (rdoSortBy.SelectedValue == "RLCM") ? DataBinder.Eval(Container.DataItem, "RLCM") : DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location/DBA" SortExpression="dba" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba").ToString() == "Z" ? "" : Eval("dba") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ranking" SortExpression="Ranking" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRanking" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Ranking")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Current Points" SortExpression="SLT_Score">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSLT_Score" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SLT_Score")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Last Meeting Scored" SortExpression="Date_Scored"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateScored" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Date_Scored")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 30%" class="heading">
                                                RLCM SLT Participation
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvRLCMSLTParticipation" runat="server" AutoGenerateColumns="false"
                                                    OnRowDataBound="gvRLCMSLTParticipation_RowDataBound" EmptyDataText="No Record Found."
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Left"
                                                            ItemStyle-Width="11%" HeaderStyle-Width="11%">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblRegion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>--%>
                                                                <asp:Label ID="lblRegion" runat="server" Text='<%# (rdoSortBy.SelectedValue == "RLCM") ? DataBinder.Eval(Container.DataItem, "RLCM") : DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location/DBA" SortExpression="dba" ItemStyle-HorizontalAlign="Left"
                                                            ItemStyle-Width="15%" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba").ToString() == "Z" ? "" : Eval("dba") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Q1 %" SortExpression="Q1" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="7%" HeaderStyle-Width="7%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQ1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q1")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Q2 %" SortExpression="Q2" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="7%" HeaderStyle-Width="7%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQ2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q2")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Q3 %" SortExpression="Q3" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="7%" HeaderStyle-Width="7%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQ3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q3")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Q4 %" SortExpression="Q3" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="7%" HeaderStyle-Width="7%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQ4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q4")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Annual Participation %" SortExpression="Annual" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAnnual" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Annual")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 30%" class="heading">
                                                Quarterly Training Conducted by RLCM
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvTraining" runat="server" AutoGenerateColumns="false" Width="100%"
                                                    OnRowDataBound="gvTraining_RowDataBound" EmptyDataText="No Record Found.">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Left"
                                                            ItemStyle-Width="22%">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblRegion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>--%>
                                                                <asp:Label ID="lblRegion" runat="server" Text='<%# (rdoSortBy.SelectedValue == "RLCM") ? DataBinder.Eval(Container.DataItem, "RLCM") : DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Quarter" SortExpression="Quarter" ItemStyle-HorizontalAlign="Center"
                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuarter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quarter")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Scheduled" SortExpression="Scheduled" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="18%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScheduled" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Scheduled")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Completed" SortExpression="Completed" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCompleted" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Completed")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Percentage" SortExpression="Percentage" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPercentage" runat="server" Text='<%# String.Format("{0, 0:N2}",DataBinder.Eval(Container.DataItem, "Percentage"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 30%" class="heading">
                                                RLCM Lag Time
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvRLCMLagTime" runat="server" AutoGenerateColumns="false" Width="100%"
                                                    OnRowDataBound="gvRLCMLagTime_RowDataBound" EmptyDataText="No Record Found.">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblRegion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>--%>
                                                                <asp:Label ID="lblRegion" runat="server" Text='<%# (rdoSortBy.SelectedValue == "RLCM") ? DataBinder.Eval(Container.DataItem, "RLCM") : DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location/DBA" SortExpression="dba" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba").ToString() == "Z" ? "" : Eval("dba") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Quarter" SortExpression="Quarter" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuarter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quarter")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Average (Days)" SortExpression="Average_Days" ItemStyle-HorizontalAlign="right"
                                                            HeaderStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAverageDays" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Average_Days")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 100%;">
                                                <asp:Button ID="btnExport" Text="Export To Excel" runat="server" CausesValidation="false"
                                                    OnClick="btnExport_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upd3" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div class="bandHeaderRow" style="padding-bottom: 2px;">
                                    <table width="100%" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label4" runat="server" Text="FACILITY INSPECTIONS"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Panel ID="Panel3" runat="server">
                                                    <asp:ImageButton ID="imgFacilityInspection" ImageAlign="Right" runat="server" ImageUrl="~/Images/down-arrow.gif"
                                                        ValidationGroup="vsErrorGroup" OnClick="imgFacilityInspection_Click" OnClientClick="HideDiv(2);" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:CollapsiblePanelExtender ID="cpeFacility" runat="server" TargetControlID="pnlFacilityInspection"
                                        ExpandControlID="imgFacilityInspection" CollapseControlID="imgFacilityInspection"
                                        Collapsed="true" SuppressPostBack="false" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Panel ID="pnlFacilityInspection" runat="server" Width="91%" Style="text-align: left">
                                    <div style="width: 900px; overflow-y: hidden; overflow-x: scroll" runat="server"
                                        id="divFacility">
                                        <table border="0" cellpadding="2" cellspacing="2">
                                            <%--<tr>
												<td align="left" class="heading">
													FACILITY INSPECTIONS
												</td>
											</tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvFacilityInspection" runat="server" AutoGenerateColumns="false"
                                                        EmptyDataText="No Record Found." OnRowDataBound="gvFacilityInspection_RowDataBound"
                                                        Width="1920px">
                                                        <Columns>
                                                            <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Location/DBA" SortExpression="dba" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldba" runat="server" Text='<%# Eval("Location").ToString() == "Z" ? "" : Eval("Location") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location"
																HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px">
															</asp:BoundField>--%>
                                                            <asp:BoundField DataField="Quarter" HeaderText="Quarter" SortExpression="Quarter"
                                                                HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Percentage Completed by Quarter Prior Year/Running Total"
                                                                ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPercentagePre" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Percentage Completed by Quarter Current Year/Running Total"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPercentageCurr" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Number of Repeats by Quarter Prior Year/Running Total"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDefPrior" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Number of Repeats by Quarter Current Year/Running Total"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDefCurr" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Average Number of Days Open By Quarter Prior Year/Running Total"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDaysOpenPre" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Average Number of Days Open By Quarter Current Year/Running Total"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDaysOpenCurr" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DashboardScoreCurrentYear" HeaderText="Dashboard Score by Quarter Prior Year/Running Total"
                                                                HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                SortExpression="DashboardScoreCurrentYear" ControlStyle-Width="100%"></asp:BoundField>
                                                            <asp:BoundField DataField="DashboardScorePriorYear" HeaderText="Dashboard Score by Quarter Current Year/Running Total"
                                                                HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                SortExpression="DashboardScorePriorYear"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divFacilityMessgae" runat="server" style="width: 900px;">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="center" style="font-family: Tahoma; font-size: 8pt; background-color: rgb(234, 234, 234);">
                                                    No Record Found
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="text-align: right; width: 900px;">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnFacilityExport" Text="Export To Excel" runat="server" CausesValidation="false"
                                                        OnClick="btnFacilityExport_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnFacilityExport" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upd2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div class="bandHeaderRow" style="padding-bottom: 2px;">
                                    <table width="100%" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" Text="SONIC UNIVERSITY TRAINING"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Panel ID="Panel2" runat="server">
                                                    <asp:ImageButton ID="imgSonicUnitraining" ImageAlign="Right" runat="server" ImageUrl="~/Images/down-arrow.gif"
                                                        ValidationGroup="vsErrorGroup" OnClick="imgSonicUnitraining_Click" OnClientClick="HideDiv(3);" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:CollapsiblePanelExtender ID="cpeUni" runat="server" TargetControlID="pnlUniversity"
                                        ExpandControlID="imgSonicUnitraining" CollapseControlID="imgSonicUnitraining"
                                        Collapsed="true" SuppressPostBack="false" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlUniversity" runat="server" Width="100%">
                                    <div style="width: 900px; overflow-y: hidden; overflow-x: scroll" id="divUni" runat="server">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <%--<tr>
												<td align="left" style="width: 30%" class="heading">
													Sonic University Training
												</td>
											</tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvSabaTraining" runat="server" AutoGenerateColumns="false" Width="1200px"
                                                        OnRowDataBound="gvSabaTraining_RowDataBound" EmptyDataText="No Record Found.">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblRegion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>--%>
                                                                    <asp:Label ID="lblRegion" runat="server" Text='<%# (rdoSortBy.SelectedValue == "RLCM") ? DataBinder.Eval(Container.DataItem, "RLCM") : DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Location/DBA" SortExpression="dba" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba").ToString() == "Z" ? "" : Eval("dba") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quarter" SortExpression="Quarter" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuarter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quarter")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Number To Be Trained/Prior Year" SortExpression="To_Be_Trained_Prev"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTo_Be_Trained_Prev" runat="server" Text='<%# String.Format("{0, 0:N0}",DataBinder.Eval(Container.DataItem, "To_Be_Trained_Prev"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Number To Be Trained/Current Year" SortExpression="To_Be_Trained_Curr"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTo_Be_Trained_Curr" runat="server" Text='<%# String.Format("{0, 0:N0}",DataBinder.Eval(Container.DataItem, "To_Be_Trained_Curr"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Number Trained/Prior Year" SortExpression="Total_Trained_Prev"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotal_Trained_Prev" runat="server" Text='<%# String.Format("{0, 0:N0}",DataBinder.Eval(Container.DataItem, "Total_Trained_Prev"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Number Trained/Current Year" SortExpression="Total_Trained_Curr"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotal_Trained_Curr" runat="server" Text='<%# String.Format("{0, 0:N0}",DataBinder.Eval(Container.DataItem, "Total_Trained_Curr"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Score/Prior Year" SortExpression="Score_Prev" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblScore_Prev" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Score_Prev")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Score/Current Year" SortExpression="Score_Curr" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblScore_Curr" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Score_Curr")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Running Score/Prior Year" SortExpression="Run_Score_Prev"
                                                                ItemStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRun_Score_Prev" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Run_Score_Prev")  %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Running Score/Current Year" SortExpression="Run_Score_Curr"
                                                                ItemStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRun_Score_Curr" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Run_Score_Curr")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divUniMessage" runat="server" style="width: 900px;">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="center" style="font-family: Tahoma; font-size: 8pt; background-color: rgb(234, 234, 234);">
                                                    No Record Found
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="text-align: right; width: 900px;">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnUniExport" Text="Export To Excel" runat="server" CausesValidation="false"
                                                        OnClick="btnUniExport_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnUniExport" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="Upd4" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div class="bandHeaderRow" style="padding-bottom: 2px;">
                                    <table width="100%" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label5" runat="server" Text="INCIDENT INVESTIGATION"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Panel ID="Panel5" runat="server">
                                                    <asp:ImageButton ID="imgInvestigation" ImageAlign="Right" runat="server" ImageUrl="~/Images/down-arrow.gif"
                                                        ValidationGroup="vsErrorGroup" OnClick="imgInvestigation_Click" OnClientClick="HideDiv(4);" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:CollapsiblePanelExtender ID="cpeInvestigation" runat="server" TargetControlID="pnlInvestigation"
                                        ExpandControlID="imgInvestigation" CollapseControlID="imgInvestigation" Collapsed="true"
                                        SuppressPostBack="false" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlInvestigation" runat="server" Width="100%">
                                    <div style="width: 900px; overflow-y: hidden; overflow-x: scroll" id="divInvestigation"
                                        runat="server">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <%--<tr>
												<td align="left" style="width: 30%" class="heading">
													Sonic University Training
												</td>
											</tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvInvestigation" runat="server" AutoGenerateColumns="false" Width="1200px"
                                                        OnRowDataBound="gvInvestigation_RowDataBound" EmptyDataText="No Record Found.">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblRegion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>--%>
                                                                    <asp:Label ID="lblRegion" runat="server" Text='<%# (rdoSortBy.SelectedValue == "RLCM") ? DataBinder.Eval(Container.DataItem, "RLCM") : DataBinder.Eval(Container.DataItem, "Region")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Location/DBA" SortExpression="dba" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba").ToString() == "Z" ? "" : Eval("dba") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quarter" SortExpression="Quarter" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuarter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quarter")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Performance Level Score/Prior Year" SortExpression="Score_Prev_Year"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblScore_Prev_Year" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Score_Prev_Year")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Performance Level Score/Current Year" SortExpression="Score_Curr_Year"
                                                                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblScore_Curr_Year" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Score_Curr_Year")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Performance Level Score Running Total/Prior Year"
                                                                SortExpression="Run_Score_Prev_Year" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRun_Score_Prev_Year" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Run_Score_Prev_Year")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Performance Level Score Running Total/ Current Year"
                                                                SortExpression="Run_Score_Curr_Year" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Right"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRun_Score_Curr_Year" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Run_Score_Curr_Year")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Average Incident Review Lag Time (Days)/ Prior Year"
                                                                SortExpression="LagTime_Prev_Year" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="200px" 
                                                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLagTime_Prev_Year" runat="server" Text='<%#String.Format("{0, 0:N2}",DataBinder.Eval(Container.DataItem, "LagTime_Prev_Year"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Average Incident Review Lag Time (Days)/ Current Year"
                                                                SortExpression="LagTime_Curr_Year" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="200px"
                                                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLagTime_Curr_Year" runat="server" Text='<%#String.Format("{0, 0:N2}",DataBinder.Eval(Container.DataItem, "LagTime_Curr_Year"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Average Incident Review Lag Time (Days) Running Total/Prior Year"
                                                                SortExpression="Run_LagTime_Prev_Year" ItemStyle-Width="200px" HeaderStyle-Width="200px"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRun_LagTime_Prev_Year" runat="server" Text='<%#String.Format("{0, 0:N2}",DataBinder.Eval(Container.DataItem, "Run_LagTime_Prev_Year"))  %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Average Incident Review Lag Time (Days) Running Total/ Current Year"
                                                                SortExpression="Run_LagTime_Curr_Year" ItemStyle-Width="200px" HeaderStyle-Width="200px"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRun_LagTime_Curr_Year" runat="server" Text='<%# String.Format("{0, 0:N2}",DataBinder.Eval(Container.DataItem, "Run_LagTime_Curr_Year"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divInvestigationMessage" runat="server" style="width: 900px;">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="center" style="font-family: Tahoma; font-size: 8pt; background-color: rgb(234, 234, 234);">
                                                    No Record Found
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="text-align: right; width: 900px;">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnInvestigationExport" Text="Export To Excel" runat="server" CausesValidation="false"
                                                        OnClick="btnInvestigationExport_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnInvestigationExport" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="Upd5" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div class="bandHeaderRow" style="padding-bottom: 2px;">
                                    <table width="100%" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label3" runat="server" Text="WORKERS’ COMPENSATION CLAIMS MANAGEMENT & INCIDENT REDUCTION"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Panel ID="Panel4" runat="server">
                                                    <asp:ImageButton ID="imgWc" ImageAlign="Right" runat="server" ImageUrl="~/Images/down-arrow.gif"
                                                        ValidationGroup="vsErrorGroup" OnClick="imgWc_Click" OnClientClick="HideDiv(5);" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:CollapsiblePanelExtender ID="cpeWc" runat="server" TargetControlID="pnlWc" ExpandControlID="imgWc"
                                        CollapseControlID="imgWc" Collapsed="true" SuppressPostBack="false" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlWc" runat="server" Width="91%" Style="text-align: left">
                                    <div style="width: 900px; overflow-y: hidden; overflow-x: scroll" id="divWC" runat="server">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <%--<tr>
												<td align="left" style="width: 30%" class="heading">
													WORKERS’ COMPENSATION CLAIMS MANAGEMENT & INCIDENT REDUCTION
												</td>
											</tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvWc" runat="server" AutoGenerateColumns="false" Width="6000px"
                                                        OnRowDataBound="gvWc_RowDataBound" EmptyDataText="No Record Found.">
                                                        <Columns>
                                                            <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" HeaderStyle-Width="200px"
                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Location" SortExpression="dba" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldba" runat="server" Text='<%# Eval("dba").ToString() == "Z" ? "" : Eval("dba") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Quarter" HeaderText="Quarter" SortExpression="Quarter">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ClaimScore_Prev" HeaderText="Performance Level Score WC Claims/ Prior Year"
                                                                SortExpression="ClaimScore_Prev" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px"></asp:BoundField>
                                                            <asp:BoundField DataField="ClaimScore_Curr" HeaderText="Performance Level Score WC Claims/ Current Year"
                                                                SortExpression="ClaimScore_Curr" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px"></asp:BoundField>
                                                            <asp:BoundField DataField="Reduction_Prev" HeaderText="Performance Level Score Incident Reduction/ Prior Year"
                                                                SortExpression="Reduction_Prev" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px"></asp:BoundField>
                                                            <asp:BoundField DataField="Reduction_Curr" HeaderText="Performance Level Score Incident Reduction/ Current Year"
                                                                SortExpression="Reduction_Curr" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200px"></asp:BoundField>
                                                            <asp:BoundField DataField="LagTime_Prev" HeaderText="Average Lag Time (Days)/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="LagTime_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="LagTime_Curr" HeaderText="Average Lag Time (Days)/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="LagTime_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S1_Prev" HeaderText="Frequency By S1 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S1_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S1_Curr" HeaderText="Frequency By S1 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S1_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S2_Prev" HeaderText="Frequency By S2 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S2_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S2_Curr" HeaderText="Frequency By S2 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S2_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S3_Prev" HeaderText="Frequency By S3 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S3_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S3_Curr" HeaderText="Frequency By S3 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S3_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S4_Prev" HeaderText="Frequency By S4 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S4_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S4_Curr" HeaderText="Frequency By S4 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S4_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S5_Prev" HeaderText="Frequency By S5 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S5_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S5_Curr" HeaderText="Frequency By S5 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S5_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>                                                            
                                                            <asp:BoundField DataField="S0_1_Prev" HeaderText="Frequency By S0-1 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_1_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_1_Curr" HeaderText="Frequency By S0-1 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_1_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_2_Prev" HeaderText="Frequency By S0-2 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_2_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_2_Curr" HeaderText="Frequency By S0-2 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_2_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_3_Prev" HeaderText="Frequency By S0-3 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_3_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_3_Curr" HeaderText="Frequency By S0-3 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_3_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_4_Prev" HeaderText="Frequency By S0-4 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_4_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_4_Curr" HeaderText="Frequency By S0-4 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_4_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_5_Prev" HeaderText="Frequency By S0-5 Code/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_5_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="S0_5_Curr" HeaderText="Frequency By S0-5 Code/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="S0_5_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="Closure_Prev" HeaderText="Average Claim Closure Rate (Days)/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="Closure_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="Closure_Curr" HeaderText="Average Claim Closure Rate (Days)/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N2}" SortExpression="Closure_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="RepOnly_Prev" HeaderText="Severity Report Only/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="RepOnly_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="RepOnly_Curr" HeaderText="Severity Report Only/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="RepOnly_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="MedOnly_Prev" HeaderText="Severity Medical Only/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="MedOnly_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="MedOnly_Curr" HeaderText="Severity Medical Only/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="MedOnly_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="LTOnly_Prev" HeaderText="Severity Lost Time/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="LTOnly_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="LTOnly_Curr" HeaderText="Severity Lost Time/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:N0}" SortExpression="LTOnly_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="Incurred_Prev" HeaderText="Financials Total Incurred/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:C2}" SortExpression="Incurred_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="Incurred_Curr" HeaderText="Financials Total Incurred/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:C2}" SortExpression="Incurred_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="Paid_Prev" HeaderText="Financials Total Paid/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:C2}" SortExpression="Paid_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="Paid_Curr" HeaderText="Financials Total Paid/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:C2}" SortExpression="Paid_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="OutStand_Prev" HeaderText="Financials Total Outstanding/ Prior Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:C2}" SortExpression="OutStand_Prev"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                            <asp:BoundField DataField="OutStand_Curr" HeaderText="Financials Total Outstanding/ Current Year"
                                                                HeaderStyle-Width="200px" DataFormatString="{0:C2}" SortExpression="OutStand_Curr"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divWCMessage" runat="server" style="width: 900px;">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="center" style="font-family: Tahoma; font-size: 8pt; background-color: rgb(234, 234, 234);">
                                                    No Record Found
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="text-align: right; width: 900px;">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="bntWc" Text="Export To Excel" runat="server" CausesValidation="false"
                                                        OnClick="btnWc_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="bntWc" />
                </Triggers>
            </asp:UpdatePanel>
            <table width="100%">
                <tr>
                    <td style="width: 100%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnExportAll" Text="Export To Excel" runat="server" CausesValidation="false"
                            OnClick="btnExportAll_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <script type="text/javascript" language="javascript">
        function ShowHideTR() {
            var divID;
            divID = document.getElementById('<%= pnlCharts.ClientID%>');
            if (divID.style.display == "none")
            { divID.style.display = "block"; }
            else
            { divID.style.display = "none"; }
        }

        function HideDiv(i) {
            var divData;
            var divMessage;

            if (i == 1) {
                divData = document.getElementById('<%= pnlSLTScoring.ClientID%>');
                divData.style.display = "none";
            }
            else if (i == 2) {
                divData = document.getElementById('<%= divFacility.ClientID%>');
                divMessage = document.getElementById('<%= divFacilityMessgae.ClientID%>');
                divData.style.display = "none";
                divMessage.style.display = "none";
            }
            else if (i == 3) {
                divData = document.getElementById('<%= divUni.ClientID%>');
                divMessage = document.getElementById('<%= divUniMessage.ClientID%>');
                divData.style.display = "none";
                divMessage.style.display = "none";
            }
            else if (i == 4) {
                divData = document.getElementById('<%= divInvestigation.ClientID%>');
                divMessage = document.getElementById('<%= divInvestigationMessage.ClientID%>');
                divData.style.display = "none";
                divMessage.style.display = "none";
            }
            else if (i == 5) {
                divData = document.getElementById('<%= divWC.ClientID%>');
                divMessage = document.getElementById('<%= divWCMessage.ClientID%>');
                divData.style.display = "none";
                divMessage.style.display = "none";
            }
        } 

    </script>
</asp:Content>
