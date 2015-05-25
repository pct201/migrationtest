<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="DashBoard_EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td align="left">
                        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
                    </td>
                </tr>
                <tr></tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvEmployeeDetail" runat="server" EmptyDataText="No Records Found">
                <Columns>
                    <asp:TemplateField HeaderText="Employee Name">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="30%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("EmployeeName") %> 
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Job Title">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle Width="40%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("Job_Title") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Program Completion Date" Visible="false">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle Width="30%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("ProgramCompletionDate") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
