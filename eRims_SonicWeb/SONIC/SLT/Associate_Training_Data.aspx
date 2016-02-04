<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Associate_Training_Data.aspx.cs" Inherits="SONIC_SLT_Associate_Training_Data" %>
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
                       <%-- <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />--%>
                    </td>
                </tr>
                <tr></tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvEmployeeDetail" runat="server" EmptyDataText="No Records Found" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Employee Name">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="40%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("NAME") %> 
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Training Class">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle Width="60%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("Class_Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <%-- <asp:TemplateField HeaderText="Course">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle Width="30%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("Course") %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
