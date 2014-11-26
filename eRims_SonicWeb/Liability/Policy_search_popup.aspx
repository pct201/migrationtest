<%@ Page Language="C#" StylesheetTheme ="Default" AutoEventWireup="true" CodeFile="Policy_search_popup.aspx.cs" Inherits="Liability_Policy_search_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <table  width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;text-align:left;">
                <tr>
                    <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                        align="left" colspan="2">
                        Policy
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%;">
                        &nbsp;
                    </td>
                    <td style="width: 50%;" align="right">
                        <table width="80%">
                            <tr>
                                <td class="lc">
                                    <strong> Search </strong> 
                                </td>
                                <td class="ic">
                                    <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                        <asp:ListItem Value="Policy_Number">Policy No</asp:ListItem>
                                        <asp:ListItem Value="Policy_Prefix">Policy Prifix</asp:ListItem>
                                        <asp:ListItem Value="Carrier">Insurance Carrier</asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td class="ic">
                                    <asp:TextBox ID = "txtsearch" runat="server" ></asp:TextBox></td>
                                     <td class="ic">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click1"/></td>
                                    </tr>
                                    
                                                           
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Policy_Id"
                            Width="100%" AllowPaging="True" AllowSorting="True" 
                            OnSorting="gvEmployeeDetails_Sorting" OnRowDataBound="gvEmployeeDetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Policy Number"  Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblpkid"  runat="server" Text='<%#Eval("PK_Policy_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Policy Type" SortExpression="FK_Policy_Type" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnid"  runat="server" CommandArgument='<% #Eval("FK_Policy_Type") %>'
                                            Text='<% #Eval("FK_Policy_Type") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Policy Number" SortExpression="Policy_Number">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnpolicyno" runat="server" CommandArgument='<% #Eval("Policy_Number") %>'
                                            Text='<% #Eval("Policy_Number") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Policy Status"  SortExpression="FK_Policy_Status" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnpolicystatus" runat="server" CommandArgument='<% #Eval("FK_Policy_Status") %>'
                                            Text='<% #Eval("FK_Policy_Status") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Policy Carrier" SortExpression="Carrier"  >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtncarrier" runat="server" CommandArgument='<% #Eval("Carrier") %>'
                                            Text='<% #Eval("Carrier") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                              
                                                              
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently There Is No Policy.
                            </EmptyDataTemplate>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
