<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" Inherits="CheckWriting_Vendor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vendor</title>
    <link href="../App_Themes/Default/Default.css" type="text/css" />
    <script type="text/javascript">
    function fillPayto(arg,arg1)
    {   
        
        window.opener.document.getElementById("ctl00_ContentPlaceHolder1_txtPayTo").value = arg;
        window.opener.document.getElementById("ctl00_ContentPlaceHolder1_txtVendorId").value = arg1;
        
        self.close();
    }
    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
        <div>
            <table  width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;text-align:left;">
                <tr>
                    <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                        align="left" colspan="2">
                        Vendor
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
                                    Search
                                </td>
                                <td class="ic">
                                    <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                        <asp:ListItem Value="Vendor_Tax_Id">Vendor Tax Id</asp:ListItem>
                                        <asp:ListItem Value="Vendor_Name">Vendor Name</asp:ListItem>
                                        <asp:ListItem Value="Vendor_Type">Vendor Type</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td class="ic">
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                                <td class="ic">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvVendorDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Vendor_ID"
                            Width="100%" AllowPaging="false" AllowSorting="True" 
                            OnSorting="gvVendorDetails_Sorting" OnRowDataBound="gvVendorDetails_RowDataBound" OnRowCreated="gvVendorDetails_RowCreated">
                            <Columns>
                                <asp:TemplateField HeaderText="Vendor Tax Id" Visible="false" SortExpression="PK_Vendor_ID">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPKId" runat="server" Text='<%#Eval("PK_Vendor_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor Tax Id" SortExpression="Vendor_Tax_Id">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnVendorTaxId" runat="server" CommandArgument='<% #Eval("Vendor_Name") %>'
                                            Text='<% #Eval("Vendor_Tax_Id") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor Name" SortExpression="Vendor_Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnVendorName" runat="server" CommandArgument='<% #Eval("Vendor_Name") %>'
                                            Text='<% #Eval("Vendor_Name") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Vendor Type" SortExpression="Vendor_Type" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnVendorType" runat="server" CommandArgument='<% #Eval("Vendor_Name") %>'
                                            Text='<% #Eval("Vendor_Type") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently There Is No Vendor.
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
