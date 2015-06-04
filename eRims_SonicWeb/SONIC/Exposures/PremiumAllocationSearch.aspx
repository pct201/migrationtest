<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PremiumAllocationSearch.aspx.cs" Inherits="SONIC_Exposures_PremiumAllocationSearch" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript"> 
    function ConfirmDelete() {
            return confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?");
        }
    </script>

    <br />
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsError"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnMode" runat="server" Value="0"></asp:HiddenField>
            <div runat="Server" id="divViewAdminList">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="bandHeaderRow" colspan="4" align="left">
                            Premium Allocation Search
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table cellpadding="2" cellspacing="3" border="0" width="100%">
                                <tr>
                                    <td align="left">
                                        Year
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                       <asp:TextBox ID="txtYear" runat="server" MaxLength="4" onpaste="return false">
                                         </asp:TextBox>
                                         <asp:RangeValidator ID="rvtxtYearBuilt" runat="server" ControlToValidate="txtYear"
                                             ValidationGroup="vsError" Type="Integer" MinimumValue="1"
                                                MaximumValue="2100" ErrorMessage="Year is not valid." Display="None"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" align="right">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="vsError" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 44%">
                            &nbsp;
                        </td>
                        <td align="right" valign="top" colspan="3">
                            <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Premium Allocation Fields"
                                            OnClick="btnAddNew_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:GridView ID="gvPAFields" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPAFields_RowCommand"
                                            OnRowCreated="gvPAFields_RowCreated" AllowSorting="true" OnSorting="gvPAFields_Sorting"
                                            DataKeyNames="PK_PA_Screen_Fields" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Year" SortExpression="Year">
                                                    <ItemStyle Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Property Valuation Date" SortExpression="Property_Valuation_Date">
                                                    <ItemStyle Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProperty_Valuation_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Property_Valuation_Date"))) ? Convert.ToDateTime(Eval("Property_Valuation_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Locations" SortExpression="Total_Locations">
                                                    <ItemStyle Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal_Locations" runat="server" Text='<%# Eval("Total_Locations")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle/>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_PA_Screen_Fields")%>'
                                                            runat="server" Text="Edit" ToolTip="Edit the Premium Allocation Fields" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_PA_Screen_Fields")%>'
                                                            ToolTip="View the Premium Allocation Fields" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteItem" CommandArgument='<%#Eval("PK_PA_Screen_Fields")%>'
                                                            ToolTip="Delete the Premium Allocation Fields"  OnClientClick="return ConfirmDelete();" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                            <EmptyDataTemplate>
                                                No Record found.
                                            </EmptyDataTemplate>
                                            <PagerSettings Visible="False" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

