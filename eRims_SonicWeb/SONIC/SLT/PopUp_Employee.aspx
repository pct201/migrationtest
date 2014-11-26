<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp_Employee.aspx.cs" Inherits="SONIC_SLT_PopUp_Employee" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management : Employee</title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 25%">
                    &nbsp;
                </td>
                <td width="10%">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:HiddenField runat="server" ID="HdnEmployeeID" />
                    <input type="hidden" id="hdnEmpval" name="hdnEmpval" />
                    <input type="hidden" id="hdnEmpName" name="hdnEmpName" />
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    &nbsp;&nbsp;<span class="NormalFontBold">Find Employee</span>
                </td>
                <td align="right" valign="top" colspan="2">
                    <table cellpadding="2" cellspacing="3" border="0" width="60%" align="right">
                        <tr>
                            <td align="left" width="16%">
                                Employee ID
                            </td>
                            <td width="4%">
                                :
                            </td>
                            <td align="left" width="32%">
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
                            <td align="left">
                                Location
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                              <asp:DropDownList ID="ddlRMLocationNumber" runat="server" AutoPostBack="True" 
                                    Height="16px" onselectedindexchanged="ddlRMLocationNumber_SelectedIndexChanged" 
                                    Width="131px" >
                                </asp:DropDownList>  
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 5px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                   &nbsp;
                </td>
                <td align="right" valign="top" colspan="2">
                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 5px">
                <table width="100%">
                    <tr>
                    <td align="right">show</td>
                    <td align="center">:</td>
                    <td align="left"><asp:RadioButton ID="rdoAllEmployees" runat="server" GroupName="aa" Checked="true" Text="All Employees" />  &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoEmployeeSelectedLocation" runat="server" GroupName="aa"  Text="Empoloyees Only at Seleted Location" /></td>
                    </tr>
                   </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 5px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" OnRowCreated="gvEmployee_RowCreated"
                                    AllowSorting="true" OnSorting="gvEmployee_Sorting" DataKeyNames="PK_Employee_ID"
                                    Width="100%" OnRowDataBound="gvEmployee_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee ID" SortExpression="Employee_Id" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkUserName" runat="server" Text='<%# Eval("Employee_Id")%>'
                                                    CommandArgument='<%#Eval("PK_Employee_ID")%>' CssClass="acher"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="First Name" SortExpression="First_Name" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkFirstName" runat="server" Text='<%# Eval("First_Name")%>'
                                                    CommandArgument='<%#Eval("PK_Employee_ID")%>' CssClass="acher"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name" SortExpression="Last_Name" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkLastName" runat="server" Text='<%# Eval("Last_Name")%>' CommandArgument='<%#Eval("PK_Employee_ID")%>'
                                                    CssClass="acher"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Address" SortExpression="Employee_Address_1"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEmployee_Address_1" runat="server" Text='<%# Eval("Employee_Address_1")%>'
                                                    CommandArgument='<%#Eval("PK_Employee_ID")%>' CssClass="acher"></asp:LinkButton>
                                            </ItemTemplate>
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
    <script type="text/javascript" language="javascript">
        function SelectValue(pk_Contact, first_name, Middle_name, Last_Name) {
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnPK_Employee').value = pk_Contact;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtMembersFirst_Name').value = first_name;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtMembersMiddle_Name').value = Middle_name;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtMemberLast_Name').value = Last_Name;
            self.close();
            return false;
        }
    </script>
    </form>
</body>
</html>
