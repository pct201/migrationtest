<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Incident.aspx.cs" Inherits="Incident_Incident" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/IncidentTab/IncidentTab.ascx" TagName="IncidentTab"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentInfo/IncidentInfo.ascx" TagName="IncidentInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        var ActiveTabIndex = 1;
        function ShowPanel(index) {
            ActiveTabIndex = index;
            document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                ShowPanelView(index);
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_pnl1').style.display = "block";

            }
        }

        function onNextStep() {
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                if (Page_ClientValidate("vsErrorGroup"))
                    return true;
                else
                    return false;
            }
        }

        function ShowPanelView(index) {
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl1view").style.display = "block";
        }

        function CheckBeforeSave() {
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                var bValid = false;
                if (Page_ClientValidate("vsErrorGroup")) {
                    bValid = true;
                }
                if (bValid)
                    CallSave();
            }
        }

        function CallSave() {
            __doPostBack('ctl00$ContentPlaceHolder1$btnSave', '');
        }

        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 20;
            }
            var winWidth = window.screen.availWidth - 200;
            obj = window.open("AuditPopup_Incident.aspx?id=" + '<%=ViewState["PK_Incident"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorOtherVehicle" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:IncidentTab ID="ucIncidentTab" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:IncidentInfo ID="ucIncidentInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left" colspan="2">
                                Incident
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu" style="padding-left: 2px;">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuSelected">Incident</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <asp:HiddenField ID="hndScrollX" runat="server" />
                                        <asp:HiddenField ID="hndScrollY" runat="server" />
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Incident</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Incident Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblIncidentNo" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Incident Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblIncidentDate" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Incident Time
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIncidentTime" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Classification
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClassification" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Incident Description
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIncident_Desc" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Opened
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Opened" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                        <td colspan="4">
                                                            <uc:ctrlPaging ID="CtrlPaging" runat="server" OnGetPage="GetPage" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6" valign="top">
                                                            <asp:GridView ID="gvEvent" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" OnRowCommand="gvEvent_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Event Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Event_Number">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventNumber" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'>
                                                                            <%# Eval("Event_Number")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Investigation Report Date" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Investigation_Report_Date">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnInvestigationReportDate" runat="server" CommandName="ViewEvent"
                                                                                CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Investigation_Report_Date")) %>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Report Date" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Event_Report_Date">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventReportDate" runat="server" CommandName="ViewEvent"
                                                                                CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Event_Report_Date")) %>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Event_Type">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventType" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'>
                                                                            <%# Eval("Event_Type")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderText="Sonic Location D/B/A" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Event_Type">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnLocationdba" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'>
                                                                            <%# Eval("dba")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td width="100%" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnReturnToAPModule" runat="server" ToolTip="Return to Asset Protection Module"
                                                            Text="Return to Asset Protection Module" CausesValidation="false" OnClick="btnReturnToAPModule_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="pnl" runat="server" />
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
</asp:Content>
