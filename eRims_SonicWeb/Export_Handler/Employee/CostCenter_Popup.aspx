<%@ Page Language="C#" AutoEventWireup="true"    CodeFile="CostCenter_Popup.aspx.cs" Inherits="WorkerCompensation_CostCenter_Popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Entity</title>
     <script type="text/javascript">
     
      function fillPayto1(arg1,arg2)
    {   
             
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtCostCenter').value = arg1;
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtDivisionName').value = arg2;
        self.close();
    }
     function fillEmpCC(arg1,arg2,arg3)
    {   
       
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvEmployee_txtCostCenter').value = arg1;
       //window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvEmployee_txtCCAddress').value = arg2;
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvEmployee_txtCCId').value = arg3;
      
        self.close();
    }
    
     function fillEmpCCPopup(arg1,arg2,arg3)
    {   
      
       window.opener.document.getElementById('fvEmployee_txtCostCenter').value = arg1;
       //window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvEmployee_txtCCAddress').value = arg2;
       window.opener.document.getElementById('fvEmployee_txtCCId').value = arg3;
      
        self.close();
    }
    
    
       function fill_cost_liability(arg1,arg2)
    {   
             
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtcosecenter').value = arg1;
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtbranchname').value = arg2;
        self.close();
    }
     function fillPropMainCC(arg1,arg2,arg3)
    {   
             
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvPropMain_lblCostCenter').value = arg1;
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvPropMain_txtBranch').value = arg2;
       window.opener.document.getElementById('ctl00_ContentPlaceHolder1_fvPropMain_txtBranchId').value = arg3;
        self.close();
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;text-align:left;">
                <tr>
                    <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                        align="left" colspan="2">
                        Entity
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
                                        <asp:ListItem Value="PK_Entity">Entity ID</asp:ListItem>
                                        <asp:ListItem Value="Description">Description</asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td class="ic">
                                    <asp:TextBox ID = "txtsearch" runat="server" ></asp:TextBox></td>
                                     <td class="ic">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                    </tr>
                                    
                                                           
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvCostCenterDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_ID"
                            Width="100%" AllowPaging="True" AllowSorting="True"  PageSize="10"
                            OnSorting="gvCostCenterDetails_Sorting" OnRowDataBound="gvCostCenterDetails_RowDataBound" OnPageIndexChanging="gvCostCenterDetails_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="PK ID Number" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblpkid" runat="server" Text='<%#Eval("PK_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entity" SortExpression = "Cost_Center" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtncostcenter" runat="server" CommandArgument='<% #Eval("Cost_Center") %>'
                                            Text='<% #Eval("Cost_Center") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression = "Division_Name" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDivisionname" runat="server" CommandArgument='<% #Eval("Division_Name") %>'
                                            Text='<% #Eval("Division_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Code" SortExpression = "Address" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnaddress" runat="server" CommandArgument='<% #Eval("Address") %>'
                                            Text='<% #Eval("Address") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                                             
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently There Is No Entity.
                            </EmptyDataTemplate>
                            <PagerSettings Visible="true" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
