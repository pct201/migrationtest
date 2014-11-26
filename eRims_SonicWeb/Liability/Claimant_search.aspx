<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Claimant_search.aspx.cs" Inherits="Liability_Claimant_search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Risk Management Insurance System</title>
      <script type="text/javascript">
    
    function fillPayto(arg1,arg2,arg3,arg4)
    {   
      
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtfirstname').value = arg1;
       
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtmiddlename').value = arg2;
       
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtlastname').value = arg3;
       
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtidclaimant').value = arg4;
        self.close();
        
   }
    function fillClaimSearch(arg1,arg2,arg3,arg4)
    {   
      
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtFirstName').value = arg1;
       
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtMiddleName').value = arg2;
       
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtLastName').value = arg3;
       
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtEmpID').value = arg4;
        self.close();
        
   }
    </script> 
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;text-align:left;">
                <tr>
                    <td class="ghc" 
                        align="left" colspan="2">
                        Claimant
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
                                        <asp:ListItem Value="First_Name">First Name</asp:ListItem>
                                        <asp:ListItem Value="Last_Name">Last Name</asp:ListItem>
                                        <asp:ListItem Value="Claimant_Id">Claimant Id</asp:ListItem>
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
                        <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Claimant_Id"
                            Width="100%" AllowPaging="True" AllowSorting="True" 
                            OnSorting="gvEmployeeDetails_Sorting" OnRowDataBound="gvEmployeeDetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Tax Id Number"  Visible="false">
                                    <ItemTemplate>
                                     <asp:LinkButton ID="lblpkid"  runat="server" CommandArgument='<% #Eval("PK_Claimant_Id") %>'
                                          Text='<% #Eval("PK_Claimant_Id") %>' CssClass="acher"></asp:LinkButton>
                                   <%-- <asp:Label ID="lblpkid"  runat="server" Text='<%#Eval("PK_Claimant_Id")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claimant ID" SortExpression="Claimant_Id" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnid"  runat="server" CommandArgument='<% #Eval("Claimant_Id") %>'
                                            Text='<% #Eval("Claimant_Id") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name" SortExpression="Last_Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnLastName" runat="server" CommandArgument='<% #Eval("Last_Name") %>'
                                            Text='<% #Eval("Last_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="First Name"  SortExpression="First_Name" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnFirstName" runat="server" CommandArgument='<% #Eval("First_Name") %>'
                                            Text='<% #Eval("First_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Middle Name" SortExpression="Middle_Name"  >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnMiddle" runat="server" CommandArgument='<% #Eval("Middle_Name") %>'
                                            Text='<% #Eval("Middle_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SSN" SortExpression="Social_Security_Number"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnSocialSeco" runat="server" CommandArgument='<% #Eval("Social_Security_Number") %>'
                                            Text='<% #Eval("Social_Security_Number") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                                              
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently There Is No Claimant.
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
