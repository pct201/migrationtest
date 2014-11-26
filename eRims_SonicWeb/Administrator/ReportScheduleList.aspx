<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ReportScheduleList.aspx.cs"
    Inherits="Administrator_ReportScheduleList" Title="eRIMS Sonic :: Report Schedule List" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        HeaderText="Please Verify the following fields:" />
    <table width="100%" cellpadding="2" cellspacing="1">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ghc">
                Report Schedule List</td>
        </tr>
        <tr>
            <td style="width: 100%;">
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%" colspan="2" class="Spacer" style="height: 6px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="45%">
                                        &nbsp;Total Records:&nbsp;<asp:Label ID="lblNumber" runat="server" Text="5"></asp:Label>
                                    </td>
                                    <td valign="top" align="right">
                                        <uc:ctrlPaging ID="ctrlPageSecurity" runat="server" OnGetPage="GetPage" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%;">
                            <asp:GridView ID="gvReportScheduleList" runat="server" AutoGenerateColumns="False"
                                Width="90%" EmptyDataText="No Records Found!" AllowSorting="true" DataKeyNames="PK_Schedule" OnRowDeleting="gvReportScheduleList_RowDeleting" OnSorting="gvReportScheduleList_Sorting" OnRowCreated="gvReportScheduleList_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="Report Name" HeaderStyle-HorizontalAlign="Left" SortExpression="Report_Name">
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblReportName" runat="server" Text='<%#Eval("Report_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Schedule Created Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Created_Date">
                                        <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scheduled Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Scheduled_Date">
                                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblScheduledDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Scheduled_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Scheduled End Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Schedule_End_Date">
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblScheduledEndDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Schedule_End_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recurring Period" HeaderStyle-HorizontalAlign="Left" SortExpression="Recurring_TypeName">
                                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecurringType" runat="server" Text='<%#Eval("Recurring_TypeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recipient List" HeaderStyle-HorizontalAlign="Left" SortExpression="ListName">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecipientList" runat="server" Text='<%# Convert.ToString(Eval("RecipientNameList")).Length > 400 ? Convert.ToString(Eval("ListName")).Substring(0,397) + "..." : Eval("RecipientNameList") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disposition">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Button ID="bntDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this schedule?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
