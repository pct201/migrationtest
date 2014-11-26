<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="InvestigationSearchResult.aspx.cs"
 Inherits="SONIC_FirstReport_InvestigationSearchResult" Title="eRIMS Sonic :: Investigation Results" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    function ConfirmDelete()
    {
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
                                        <span class="heading">Investigation Results Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Found
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageExposure" runat="server" OnGetPage="GetPage" />
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
                            <asp:GridView ID="gvExposure" runat="server" AutoGenerateColumns="false" Width="100%"
                                AllowSorting="True" OnSorting="gvExposure_Sorting" OnRowCreated="gvExposure_RowCreated"
                                OnRowDataBound="gvExposure_RowDataBound" OnRowCommand="gvExposure_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Investigation ID" SortExpression="PK_Investigation_ID">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="center" Width="12%" />
                                        <ItemTemplate>
                                            <%#Eval("PK_Investigation_ID")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Report Number" SortExpression="W.WC_FR_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%#Eval("FirstReportNumber")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RM Location Number" SortExpression="RM_Location_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                        <ItemTemplate>
                                            <%#Eval("RM_Location_Number") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="dba">
                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                        <ItemTemplate>
                                            <%#Eval("dba")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Corrective Action Status" SortExpression="Status">                                        
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%#Eval("Status")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location Information Complete">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="center" Width="13%" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkLocInfoComp" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RLCM Complete">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="center" Width="11%" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRLCMComp" runat="server" Enabled="false"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="10%" HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditInvestigation" CommandArgument='<%#Eval("PK_Investigation_ID").ToString() + ":" + Eval("FK_First_Report_Wizard_ID").ToString()%>' />&nbsp;/&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewInvestigation" CommandArgument='<%#Eval("PK_Investigation_ID").ToString() + ":" + Eval("FK_First_Report_Wizard_ID").ToString()%>' />&nbsp;/&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteInvestigation" CommandArgument='<%#Eval("PK_Investigation_ID")%>' OnClientClick="return confirm('Are you sure to delete?');" />            
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
                        <td width="100%" align="center">
                            <asp:Button ID="btnSearch" runat="server" Text="Search Again" OnClick="btnSearch_Click"
                                ToolTip="Search Again" />
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

