<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptDefault_WCAllocation.aspx.cs"
    Inherits="SONIC_FirstReport_RptDefault_WCAllocation" Title="eRIMS Sonic :: Reports :: WC Allocation"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">  
    function openWindowSchedule(PK_ReportID)
        {
            var schedulePopUp = '';
            var obj='';
            if (PK_ReportID == 19)
            {
                schedulePopUp = "ScheduleWCAllocationDetailReport.aspx?PK_ReportID="+PK_ReportID;
                obj= window.open(schedulePopUp,null,'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
                 
            }
            else if (PK_ReportID == 20)
            {
                schedulePopUp = "ScheduleWCAllocationSummaryReport.aspx?PK_ReportID="+PK_ReportID;
                obj=window.open(schedulePopUp,null,'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 21)
            {
                schedulePopUp = "ScheduleWCAllocationLocationReport.aspx?PK_ReportID="+PK_ReportID;
                obj=window.open(schedulePopUp,null,'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 22)
            {
                schedulePopUp = "ScheduleWCAllocationMonthlyDetailReport.aspx?PK_ReportID="+PK_ReportID;
                obj=window.open(schedulePopUp,null,'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 23)
            {
                schedulePopUp = "ScheduleWCMonthlyAllocationSummaryReport.aspx?PK_ReportID="+PK_ReportID;
                obj=window.open(schedulePopUp,null,'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 36)
            {
                schedulePopUp = "ScheduleWCAllocationYTDCharge.aspx?PK_ReportID="+PK_ReportID;
                obj=window.open(schedulePopUp,null,'width=800,height=500,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 500) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (PK_ReportID == 53) {
                schedulePopUp = "SchedulerSonicCauseCodeReclassification.aspx?PK_ReportID=" + PK_ReportID;
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
                                <a target="_blank" runat="server" href="javascript:void();" id="rptLink">
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
                                <input type="button" value="Schedule" title="Schedule Report" class="btn" onclick="return openWindowSchedule('<%# Eval("PK_ReportID") %>');" />
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
