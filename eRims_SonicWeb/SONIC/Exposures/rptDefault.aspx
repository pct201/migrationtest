<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptDefault.aspx.cs" MasterPageFile="~/Default.master"
    Inherits="SONIC_Exposures_rptDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function openWindowSchedule(PK_ReportID) {
            var schedulePopUp = '';
            var obj = '';
            if (PK_ReportID == 37) {
                schedulePopUp = "SchedulePropertyStatementofValues.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');

            }
            else if (PK_ReportID == 42) {
                schedulePopUp = "ScheduleThirdPartyOwned.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 43) {
                schedulePopUp = "ScheduleRptFacilityInspection.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 56) {
                schedulePopUp = "SchedulerptInspectionsByInspector.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 58) {
                schedulePopUp = "SchedulerptRM_Dealership_Facility_spec.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 59) {
                schedulePopUp = "SchedulerptInspectionLagTime.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 71) {
                schedulePopUp = "SchedulerptACI_Key_Contact_Report.aspx?PK_ReportID=" + PK_ReportID;
                obj = window.open(schedulePopUp, null, 'width=800,height=560,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 560) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }

            obj.focus();
        }

    </script>
    <table id="Table1" cellpadding="0" cellspacing="0" width="100%" runat="server">
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:GridView runat="server" Width="90%" ID="gvReports" OnRowDataBound="gvReportList_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Report Name">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle Width="30%" HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPrimaryID" Text='<%# Eval("PK_ReportID") %>' Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="lblReportName" Text='<%# Eval("Report_Name") %>' Visible="false"></asp:Label>
                                <a target="_blank" runat="server" href="javascript:Void();" id="rptLink">
                                    <%# Eval("Report_Name") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Description">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle Width="58%" HorizontalAlign="left" />
                            <ItemTemplate>
                                <%# Eval("Report_Description")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="12%" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Button ID="btnSchedule" runat="server" CssClass="btn" Text="Schedule" ToolTip="Schedule Report"
                                    OnClick="btnSchedule_Click" CommandArgument='<%# Eval("PK_ReportID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
    </table>
</asp:Content>
