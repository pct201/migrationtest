<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUP_CostCenter.aspx.cs" Inherits="PopUP_CostCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cost Center</title>
    <link href="../App_Themes/Default/Default.css" type="text/css" />
    <script type="text/javascript" >
    function post_value()
    {
        var m_strStates="";
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if(document.forms[0].elements[i].type=='checkbox') 
            {
                if(document.forms[0].elements[i].checked  == true)
                {
                       if(m_strStates=="")
                            m_strStates=document.forms[0].elements[i].value;
                       else
                            m_strStates=m_strStates+","+document.forms[0].elements[i].value;
                }          
            }
        } 
        opener.document.getElementById("ctl00_ContentPlaceHolder1_fvsecurityDetails_txtCostCenter").value=m_strStates;
        self.close();
    }
    function set_value()
    {
        var m_strMain = opener.document.getElementById("ctl00_ContentPlaceHolder1_fvsecurityDetails_txtCostCenter").value;
        
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if(document.forms[0].elements[i].type=='checkbox') 
            {
                var myRegExp = document.forms[0].elements[i].value;
                var matchPos = m_strMain.search(myRegExp);
                if(matchPos != -1)
                    document.forms[0].elements[i].checked=true;   
                  
            }
        } 
        
    }
    </script>
</head>
<body  style="background-color: White;" onload="javascript:set_value();">
    <form id="form1" runat="server">        
            <div>
                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;text-align:left;">
                    <tr>
                        <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                            align="left">
                            Cost Center
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:GridView ID="gvCostCenter" runat="server" AutoGenerateColumns="false" 
                                Width="100%" AllowPaging="false" AllowSorting="false"  >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input id="Checkbox1" name="chkItem" type="checkbox" value='<%# Eval("Code")%>' runat="server" />
                                           
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PK_Entity" HeaderText="Entity Id" SortExpression="PK_Entity">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code">
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently there is no entity.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Button ID="btnAddCostCenter" runat="server" Text="Add Entity" OnClientClick="javascript:post_value();" />
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
