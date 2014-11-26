<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EmployeeSearchResult.aspx.cs"
    Inherits="Administrator_EmployeeSearchResult" Title="eRIMS Sonic :: Employee Search Result" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>

    <br />
    <div>
        <asp:UpdateProgress runat="server" Visible="true" DynamicLayout="true" AssociatedUpdatePanelID="pnlBankDetail"
            ID="upProgress">
            <ProgressTemplate>
                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                        height: 100%;">
                        <tr align="center" valign="middle">
                            <td class="LoadingText" align="center" valign="middle">
                                <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnMode" runat="server" Value="0"></asp:HiddenField>
            <div runat="Server" id="divViewAdminList">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="bandHeaderRow" colspan="4" align="left">
                            Employee
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;<asp:HiddenField runat="server" ID="HdnEmployeeID" />
                            <input type="hidden" id="hdnEmpval" name="hdnEmpval" />
                            <input type="hidden" id="hdnEmpName" name="hdnEmpName" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table cellpadding="2" cellspacing="3" border="0" width="100%">
                                <tr>
                                    <td align="left">
                                        Employee ID
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        First Name
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Last Name
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" align="right">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />&nbsp;
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
                                        <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Employee Details"
                                            OnClick="btnAddNew_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" OnRowCommand="gvEmployee_RowCommand"
                                            OnRowCreated="gvEmployee_RowCreated" AllowSorting="true" OnSorting="gvEmployee_Sorting"
                                            DataKeyNames="PK_Employee_ID" Width="100%">
                                            <Columns>
                                                <%--<asp:TemplateField>
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Employee_ID")%>' onclick="javascript:UnCheckHeader('gvEmployee')" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Employee ID" SortExpression="Employee_Id">
                                                    <ItemStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("Employee_Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="First Name" SortExpression="First_Name">
                                                    <ItemStyle Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("First_Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Last Name" SortExpression="Last_Name">
                                                    <ItemStyle Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("Last_Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Address" SortExpression="Employee_Address_1">
                                                    <ItemStyle Width="45%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserRole" runat="server" Text='<%# Eval("Employee_Address_1")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Employee_ID")%>'
                                                            runat="server" Text="Edit" ToolTip="Edit the Employee Details" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Employee_ID")%>'
                                                            ToolTip="View the Employee Details" />
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
