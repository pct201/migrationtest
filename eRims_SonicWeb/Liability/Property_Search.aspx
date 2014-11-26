<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Property_Search.aspx.cs" Inherits="Liability_Property_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
   
    function fillPayto(arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8,arg9,arg10,arg11,arg12,arg13,arg14,arg15,arg16,arg17,arg18,arg19)
    {   
        
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtproperty').value = arg1;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtadd1').value = arg2;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtadd2').value = arg3;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtentity').value = arg4;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtcityproperty').value = arg5;
         window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtstate').value = arg6;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtzipproperty').value = arg7;
         window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtcounty').value = arg8;
        
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtowenership').value = arg9;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtwhatfood').value = arg10;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtnoofemployee').value = arg11;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtbuilding').value = arg12;
         window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtcontents').value = arg13;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtATMS').value = arg14;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtSigns').value = arg15;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtcomputers').value = arg16;
        
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtleaseimprovements').value = arg17;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txttotel').value = arg18;
        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtpropertyid').value = arg19;
             
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
                       Property
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
                                        <asp:ListItem Value="FK_Entity">Entity</asp:ListItem>
                                        <asp:ListItem Value="Stationary_Type">Property Type</asp:ListItem>
                                        <asp:ListItem Value="Property_Name">Property Name</asp:ListItem>
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
                        <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Property_ID"
                            Width="100%" AllowPaging="True" AllowSorting="True" 
                            OnSorting="gvEmployeeDetails_Sorting" OnRowDataBound="gvEmployeeDetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText=" Id Number"  Visible="false"  >
                                    <ItemTemplate>
                                    <%--<asp:Label ID="lblpkid"  runat="server" Text='<%#Eval("PK_Property_ID")%>'></asp:Label>--%>
                                    <asp:LinkButton ID="lblpkid"  runat="server" CommandArgument='<% #Eval("PK_Property_ID") %>'
                                            Text='<% #Eval("PK_Property_ID") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entity" SortExpression="Claimant_Id" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEntity"  runat="server" CommandArgument='<% #Eval("FK_Entity") %>'
                                            Text='<% #Eval("FK_Entity") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property Type" SortExpression="Stationary_Type">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnStationary" runat="server" CommandArgument='<% #Eval("Stationary_Type") %>'
                                            Text='<% #Eval("Stationary_Type") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Name"  SortExpression="Property_Name" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnProperty" runat="server" CommandArgument='<% #Eval("Property_Name") %>'
                                            Text='<% #Eval("Property_Name") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Location" SortExpression="ATM_Location"  >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnLocation" runat="server" CommandArgument='<% #Eval("ATM_Location") %>'
                                            Text='<% #Eval("ATM_Location") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                     
                                     <asp:TemplateField HeaderText="Address_1"  Visible="false" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnadd1" runat="server" CommandArgument='<% #Eval("Stationary_Address_1") %>'
                                            Text='<% #Eval("Stationary_Address_1") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                     <asp:TemplateField HeaderText="Address_2"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnadd2" runat="server" CommandArgument='<% #Eval("Stationary_Address_2") %>'
                                            Text='<% #Eval("Stationary_Address_2") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="City"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnCity" runat="server" CommandArgument='<% #Eval("Stationary_City") %>'
                                            Text='<% #Eval("Stationary_City") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="State"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnState" runat="server" CommandArgument='<% #Eval("Stationary_State") %>'
                                            Text='<% #Eval("Stationary_State") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                              
                               <asp:TemplateField HeaderText="Zip"  Visible = "false" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnZip" runat="server" CommandArgument='<% #Eval("Stationary_Zip") %>'
                                            Text='<% #Eval("Stationary_Zip") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                     
                               <asp:TemplateField HeaderText="County"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnCounty" runat="server" CommandArgument='<% #Eval("FK_County") %>'
                                            Text='<% #Eval("FK_County") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                     
                                           
                               <asp:TemplateField HeaderText="Ownership"  Visible="false"  >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnOwnership" runat="server" CommandArgument='<% #Eval("Ownership") %>'
                                            Text='<% #Eval("Ownership") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                           
                               <asp:TemplateField HeaderText="Zone"  Visible = "false" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnZone" runat="server" CommandArgument='<% #Eval("Flood_Zone") %>'
                                            Text='<% #Eval("Flood_Zone") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                           
                               <asp:TemplateField HeaderText="Employees"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnEmployees" runat="server" CommandArgument='<% #Eval("Number_Of_Employees") %>'
                                            Text='<% #Eval("Number_Of_Employees") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                                  
                               <asp:TemplateField HeaderText="Building"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnBuilding" runat="server" CommandArgument='<% #Eval("Building") %>'
                                            Text='<% #Eval("Building") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                              
                              
                                           
                               <asp:TemplateField HeaderText="Contents"   Visible="false" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnContents" runat="server" CommandArgument='<% #Eval("Contents") %>'
                                            Text='<% #Eval("Contents") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                              
                              
                                           
                               <asp:TemplateField HeaderText="ATMs"  Visible="false" >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnATMs" runat="server" CommandArgument='<% #Eval("ATMs") %>'
                                            Text='<% #Eval("ATMs") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                              
                                           
                               <asp:TemplateField HeaderText="Signs"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnSigns" runat="server" CommandArgument='<% #Eval("Signs") %>'
                                            Text='<% #Eval("Signs") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                                  
                               <asp:TemplateField HeaderText="Computers"  Visible="false"   >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnComputers" runat="server" CommandArgument='<% #Eval("Computers") %>'
                                            Text='<% #Eval("Computers") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                              
                               <asp:TemplateField HeaderText="Computers"  Visible="false"  >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnImprovements" runat="server" CommandArgument='<% #Eval("Lease_Improvements") %>'
                                            Text='<% #Eval("Lease_Improvements") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="Total" Visible="false"  >
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lbtnTotal" runat="server" CommandArgument='<% #Eval("Total") %>'
                                            Text='<% #Eval("Total") %>' CssClass="acher"></asp:LinkButton>
                                    </ItemTemplate>
                                     </asp:TemplateField>
                              
                                
                                                              
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently There Is No Property.
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
