<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiaryUser.aspx.cs" Inherits="WorkerCompensation_DiaryUser"
    Title="Risk Insurance Management System" Theme="Default"    %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System</title>
</head>
<body style="background-color:Transparent;">
    <form id="form1" runat="server">

        <script type="text/javascript">
   function test(arg)
    { 
        var val = "<%=val%>";
        if(val !="insert")
        {
            var test = arg.split(",");            
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtAssignTo').value = test[0];
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtAssignToID').value = test[1];
        }
        else if(val !="edit")
        {
            var test = arg.split(",");
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIAssignTo').value = test[0];
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIAssignToID').value = test[1];
        }
        self.close();
    }
       
        </script>

        <div>
            <table  width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;text-align:left;">
                <tr>
                    <td class="ghc">
                        Diary User</td>
                </tr>
                
                <tr style="height:30px;">
                    <td align="center" class="ic" valign="middle">
                        <asp:GridView ID="dgUsers" runat="server" AutoGenerateColumns="false" OnRowDataBound="dgUsers_RowDataBound"
                             AllowSorting="true" OnSorting="dgUsers_Sorting" OnRowCreated="dgUsers_RowCreated" >
                            <HeaderStyle Font-Bold="true" Font-Size="Medium" />                                                                                    
                            <Columns>  
                                <asp:TemplateField HeaderText="" SortExpression="" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnUserID" runat="server" CommandArgument='<% #Eval("Pk_Security_ID") %>'
                                            Text='<% #Eval("Pk_Security_ID") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                <asp:TemplateField HeaderText="User Name" SortExpression="USER_NAME">
                                   <ItemTemplate>
                                        <asp:LinkButton ID="lbtnUserName" runat="server" CommandArgument='<% #Eval("USER_NAME") %>'
                                            Text='<% #Eval("USER_NAME") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="First Name"  SortExpression="First_Name">
                                     <ItemTemplate>
                                        <asp:LinkButton ID="lbtnFirstName" runat="server" CommandArgument='<% #Eval("USER_NAME") %>'
                                            Text='<% #Eval("First_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Last Name" SortExpression="Last_Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnLastName" runat="server" CommandArgument='<% #Eval("USER_NAME") %>'
                                            Text='<% #Eval("Last_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Cost Center" SortExpression="Cost_Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnCostCenter" runat="server" CommandArgument='<% #Eval("USER_NAME") %>'
                                            Text='<% #Eval("Cost_Center") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Division" SortExpression="Division_Name">
                                     <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDivision" runat="server" CommandArgument='<% #Eval("USER_NAME") %>'
                                            Text='<% #Eval("Division_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>                          
                                
                            </Columns>   
                            
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
