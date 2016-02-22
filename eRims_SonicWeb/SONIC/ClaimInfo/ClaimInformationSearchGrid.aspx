<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ClaimInformationSearchGrid.aspx.cs"
    Inherits="SONIC_ClaimInformationSearchGrid" Title="eRIMS Sonic :: Claim Information :: Search Result" %>

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
                                        <span class="heading">Claim Information Search Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Claim Informations
                                        Found
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageClaimInfo" runat="server" OnGetPage="GetPage" />
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
                            <asp:GridView ID="gvClaimInfoSearchGrid" runat="server" DataKeyNames="PK_ID,Claim_Type,Url,FK_First_Report_Wizard_ID"
                                AutoGenerateColumns="false" Width="100%"  AllowSorting="True" OnRowCommand="gvClaimInfoSearchGrid_RowCommand"
                                OnRowCreated="gvClaimInfoSearchGrid_RowCreated" OnRowDataBound="gvClaimInfoSearchGrid_RowDataBound"
                                OnSorting="gvClaimInfoSearchGrid_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="TPA Claim Number" SortExpression="Origin_Claim_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkView" CommandName="View">
                                                <%#Eval("Origin_Claim_Number")%>
                                            </asp:LinkButton>
                                            <asp:Label ID="lblClaimNumber" runat="server" Visible="false">
                                                <%#Eval("Origin_Claim_Number")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="dba">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%#Eval("dba")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" SortExpression="Employee_Name">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%#Eval("Employee_Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Incident" SortExpression="Date_of_Accident">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label runat="Server" ID="lblDate_of_Accident"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Claim Type" SortExpression="Claim_Type">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%# Eval("Claim_Type")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnView" runat="server" CommandName="ViewClaim" Text="View" />
                                        </ItemTemplate> 
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" CommandName="EditClaim" Text="Edit" />
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
                        <td align="center">
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
