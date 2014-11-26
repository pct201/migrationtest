<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Business_Rule_List.aspx.cs"
    Inherits="Administrator_Business_Rule_List" Title="Risk Insurance Management System :: Business Rule" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
        
    <script language="javascript" type="text/javascript">
        function ConfirmDelete() {
            return confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?");
        }      

    </script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <asp:Panel ID="pnlSearchFilter" runat="server" Width="100%" DefaultButton="btnSearch">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc">
                    <b>Business Rule Search</b>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="100%" cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td style="padding-left: 40px;" align="left">
                    <table width="90%" cellpadding="3" cellspacing="1" border="0">
                        <tr>
                        <td width="16%">
                            Select Module
                        </td>
                        <td valign="top" width="2%">
                            :
                        </td>
                        <td width="32%">
                            <asp:DropDownList ID="drpModule" runat="server" AutoPostBack="True" 
                                Width="250px" onselectedindexchanged="drpModule_SelectedIndexChanged">
                            </asp:DropDownList>                            
                        </td>
                    
                        <td width="16%">
                            Select Screen
                        </td>
                        <td valign="top" width="2%">
                            :
                        </td>
                        <td width="32%">
                            <asp:DropDownList ID="drpScreen" runat="server" AutoPostBack="True" Width="250px">                            
                            </asp:DropDownList>                            
                        </td>
                    </tr>
                        <tr>
                            <td align="left" valign="top" width="16%">
                                Rule name
                            </td>
                            <td align="center" valign="top" width="2%">
                                :
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:TextBox ID="txtRuleName" runat="server" MaxLength="250" Width="250px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top" width="16%">
                                Action type
                            </td>
                            <td align="center" valign="top" width="2%">
                                :
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:DropDownList ID="drpAction_Type" Width="250px" runat="server">
                                <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                <asp:ListItem Text="Update" Value="Update"></asp:ListItem>
                                <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                <asp:ListItem Text="Diary" Value="Diary"></asp:ListItem>
                            </asp:DropDownList>
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
            <tr>
                <td colspan="2" align="center">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click"
                        ValidationGroup="vsErrorGroup" CausesValidation="true" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnClear" Text=" Clear " OnClick="btnSearchAgain_Click"
                        CausesValidation="false" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnAdd" Text="  Add  " CausesValidation="false" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>        
    </asp:Panel>    
    <asp:Panel ID="pnlSearchResult" runat="server" Width="100%" Visible="false">
        <br />
        <br />
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 45%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="Spacer" style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;<span class="heading">Business Rule Search Results</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Rules
                                Found
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" align="right">
                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;" align="left">
                                <%--<div style="overflow-x: scroll; overflow-y: none; text-align: left; width: 998px;"
                                    id="dvSearchResult" runat="server">--%>
                                    <asp:GridView ID="gvBusinessRule" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                        Width="998px" OnSorting="gvBusinessRule_Sorting" OnRowCreated="gvBusinessRule_RowCreated"
                                        OnRowCommand="gvBusinessRule_RowCommand" OnRowDataBound="gvBusinessRule_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Disposition" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="80px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="btnView" CommandName="View" CommandArgument='<%#Eval("PK_Business_Rules")%>'
                                                        runat="server" CausesValidation="false" Text="View" ToolTip="View Business Rule" />&nbsp;&nbsp;--%>
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" CommandArgument='<%#Eval("PK_Business_Rules")%>'
                                                        runat="server" CausesValidation="false" Text="Edit" ToolTip="Edit Business Rule" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRule"
                                                        ToolTip="Delete Business Rule" CommandArgument='<%#Eval("PK_Business_Rules")%>' CausesValidation="false"
                                                        OnClientClick="return ConfirmDelete();" />&nbsp;&nbsp;                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Rule_Name">
                                                <ItemStyle Width="130px" />
                                                <ItemTemplate>
                                                    <%# Eval("Rule_Name")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Module" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Module">
                                                <ItemStyle Width="120px" />
                                                <ItemTemplate>
                                                    <%# Eval("Module")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Screen" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Screen">
                                                <ItemStyle Width="120px" />
                                                <ItemTemplate>
                                                    <%# Eval("Screen")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Action type" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Action_Type">
                                                <ItemStyle Width="50px" />
                                                <ItemTemplate>
                                                    <%# Eval("Action_Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                           
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            <b>No Record found</b>
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                <%--</div>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSearchAgain" runat="server" Text="Search" OnClick="btnSearchAgain_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnAddNew" runat="server" Text="  Add  " OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
