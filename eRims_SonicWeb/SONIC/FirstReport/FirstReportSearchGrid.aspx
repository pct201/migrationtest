<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FirstReportSearchGrid.aspx.cs"
    Inherits="SONIC_FirstReportSearchGrid" Title="eRIMS Sonic :: First Report Search Result" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function ConfirmDelete() {
            return confirm("Are you sure to delete?");
        }
    </script>

    <table cellpadding="0" cellspacing="0" width="99%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <span class="heading">First Report Search Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;First Reports
                                        Found
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageFirstReport" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="groupHeaderBar">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" colspan="7" valign="top">
                            <asp:GridView ID="gvFirstReportSearchGrid" runat="server" DataKeyNames="Wizard_ID,Url,PK_ID,Prefix,Prefix_New"
                                AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnRowCommand="gvFirstReportSearchGrid_RowCommand"
                                OnRowCreated="gvFirstReportSearchGrid_RowCreated" OnRowDataBound="gvFirstReportSearchGrid_RowDataBound"
                                OnRowDeleting="gvFirstReportSearchGrid_RowDeleting" OnSorting="gvFirstReportSearchGrid_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="First Report Number" SortExpression="FR_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkView" CommandName="View">
                                    <%#Eval("Prefix") %>-<%#Eval("FR_Number")%>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="dba">
                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                        <ItemTemplate>
                                            <%#Eval("dba")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%#Eval("FullName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Incident" SortExpression="Date_Of_Incident">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label runat="Server" ID="lblDateOfIncident"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Investigation ID" SortExpression="InvestigationID"
                                        Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>                                           
                                            <asp:LinkButton ID="lnkInvestigation" runat="server" Text='<%#Eval("InvestigationID") %>' CommandName="GoToInvestigation" CommandArgument='<%#Eval("InvestigationID").ToString() + ":" + Eval("Wizard_ID").ToString()%>' />   
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TPA Claim Number" SortExpression="Origin_Claim_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkClaimNumber" runat="server" Text='<%#Eval("Origin_Claim_Number") %>' CommandName="GoToClaim" CommandArgument='<%# Convert.ToString(Eval("PK_Claim_ID")) + ":" + Convert.ToString(Eval("Prefix_New")) %>' />                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Complete">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkComplete" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disposition" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="center" style="width: 50%">
                                                        <asp:Button ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" ToolTip="Delete"
                                                            OnClientClick="return ConfirmDelete();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table cellpadding="4" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="48%" align="right">
                            <asp:Button ID="btnSearch" runat="server" Text="Search First Reports" OnClick="btnSearch_Click"
                                ToolTip="Search" />
                        </td>
                        <td width="4%">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add First Report" OnClick="btnAddNew_Click"
                                ToolTip="Add New" />&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;">
            </td>
        </tr>
    </table>
</asp:Content>
