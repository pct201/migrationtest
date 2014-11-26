<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptDefault.aspx.cs"
    Inherits="SONIC_RealEstate_rptDefault" Title="eRIMS Sonic :: Lease Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function openWindowSchedule(PK_ReportID, strTitle) {
            var schedulePopUp = '';
            var obj = '';
            if (PK_ReportID == 27 || PK_ReportID == 29 || PK_ReportID == 30 || PK_ReportID == 31 || PK_ReportID == 32 || PK_ReportID == 33 || PK_ReportID == 34 || PK_ReportID == 35 || PK_ReportID == 40) {
                schedulePopUp = "ScheduleRealEstateReport.aspx?PK_ReportID=" + PK_ReportID + "&rptTitle=" + strTitle;
                obj = window.open(schedulePopUp, null, 'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 28) {
                schedulePopUp = "ScheduleRentProjectionsHistory.aspx?PK_ReportID=" + PK_ReportID + "&rptTitle=" + strTitle;
                obj = window.open(schedulePopUp, null, 'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 38 || PK_ReportID==51) {
                schedulePopUp = "ScheduleRentCriticalDates.aspx?PK_ReportID=" + PK_ReportID + "&rptTitle=" + strTitle;
                obj = window.open(schedulePopUp, null, 'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 39) {
                schedulePopUp = "ScheduleMasterDealership.aspx?PK_ReportID=" + PK_ReportID + "&rptTitle=" + strTitle;
                obj = window.open(schedulePopUp, null, 'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 52) {
                schedulePopUp = "ScheduleSubLeaseReport.aspx?PK_ReportID=" + PK_ReportID + "&rptTitle=" + strTitle;
                obj = window.open(schedulePopUp, null, 'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 55) {
                schedulePopUp = "ScheduleRentCriticalDates.aspx?PK_ReportID=" + PK_ReportID + "&rptTitle=" + strTitle;
                obj = window.open(schedulePopUp, null, 'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                                <a target="_blank" runat="server" href="javascript:void(0);" id="rptLink">
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
                                <input type="button" value="Schedule" title="Schedule Report" class="btn" onclick="return openWindowSchedule('<%# Eval("PK_ReportID") %>','<%# Eval("Report_Name") %>');" />
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
