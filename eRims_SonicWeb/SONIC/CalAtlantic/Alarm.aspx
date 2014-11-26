<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Alarm.aspx.cs" Inherits="Alarm_Alarm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentTab/IncidentTab.ascx" TagName="IncidentTab"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/IncidentInfo/IncidentInfo.ascx" TagName="IncidentInfo"
    TagPrefix="uc" %>
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
            var bValid = false;
            if (Page_ClientValidate("vsErrorGroup")) {
                bValid = true;
            }
            if (bValid)
                CallSave();
        }

        function CallSave() {
            __doPostBack('ctl00$ContentPlaceHolder1$btnSave', '');
        }

        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }

        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 20;
            }
            var winWidth = window.screen.availWidth - 200;
            obj = window.open("AuditPopup_Alarm.aspx?id=" + '<%=ViewState["PK_Exposure_Alarms"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                <uc:IncidentInfo ID="ucIncidentInfo" runat="server"  />
            </td>
        </tr>
        <tr>
            <td align="left">
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
                            <td align="left">
                                Alarm
                            </td>
                            <td align="right">
                                <asp:Label ID="lblLastModifiedDateTime" runat="server"></asp:Label>
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuSelected">Alarm</span>
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
                                                    Alarm Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <uc2:ctrlPaging ID="CtrlPaging" runat="server" OnGetPage="GetPage" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6" valign="top">
                                                            <asp:GridView ID="gvAlarm" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" OnRowCommand="gvAlarm_RowCommand">
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
                                                                    <asp:TemplateField HeaderText="Alarm Number" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="180px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventNumber" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            <%--<%# Eval("Event_Number")%>--%>
                                                                            <%# Eval("Alarm_Number")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Alarm Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Alarm_Date">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnAlarmDate" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Alarm_Date"))%>
                                                                            
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Alarm Time" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Alarm_Time">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnAlarmTime" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            <%# Eval("Time_Of_Alarm")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Event_Type">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lntbtnEventType" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            <%# Eval("Event_Type")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Number" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Camara_Number">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnCamaraNumber" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            <%# Eval("Camara_Number")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Camara_Name">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnCamaraName" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            <%# Eval("Camara_Name")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Operator" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Operator">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnOperator" runat="server" CommandName="ViewAlarm" CommandArgument='<%#Eval("FK_Event") + "," +Eval("FK_Incident") + "," +Eval("PK_Exposure_Alarms") %>'>
                                                                            <%# Eval("Operator")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <b>Alarm</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Alarm Number<span class="mf">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblAlarmNo" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Alarm Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblAlarmType" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Alarm Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAlarmDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Alarm Time
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAlarmTime" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Operator
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOperator" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Camera Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCamaraName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Is FalsePoisitive
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:CheckBox ID="chkIsfaultPositive_View" runat="server" Enabled="false" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Camera Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCamaraNo" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Camera Type
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCamaraType" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Image Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:LinkButton ID="lnkbtnImageView" runat="server" Visible="false" Text="View Image"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Description
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblImageDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Alarm Sub Type</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Action Type
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblActionType" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Actions
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblActions" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Person
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPerson" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vehicle
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVehicle" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Environmental
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEnvironmental" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Client Caused
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClientCaused" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Equipment Malfuncation
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEquipmentMalfunction" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Other
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblOther" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Company Contact</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Location
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lbllocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblState" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Country
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Building
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBuilding" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Site Code
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSiteCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContactName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContactPhone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contact Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
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
                                                        <asp:Button ID="btnPreviousStep" ToolTip="Previous Step" runat="server" Text="Previous Step"
                                                            OnClick="btnPreviousStep_Click" CausesValidation="false" />
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
