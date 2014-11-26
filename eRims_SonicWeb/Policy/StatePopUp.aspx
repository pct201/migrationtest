<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatePopUp.aspx.cs" Inherits="Policy_StatePopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>States</title>
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
        opener.document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtStates").value=m_strStates;
        self.close();
    }
    function set_value()
    {
        var m_strMain = opener.document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtStates").value;
        
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
                            States Covered
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:GridView ID="gvStates" runat="server" AutoGenerateColumns="false" 
                                Width="100%" AllowPaging="True" AllowSorting="false" OnRowDataBound="gvStates_RowDataBound"
                                >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" type="checkbox" value='<%# Eval("FLD_abbreviation")%>' runat="server" />
                                           
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FLD_state" HeaderText="State Name" SortExpression="FLD_state">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FLD_abbreviation" HeaderText="State Abbreviation" SortExpression="FLD_abbreviation">
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently There Is No Policy.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Button ID="btnAddState" runat="server" Text="Add State" OnClientClick="javascript:post_value();" />
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
