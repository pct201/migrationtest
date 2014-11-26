<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PropetySelectYear.aspx.cs" Inherits="SONIC_Exposures_PropetySelectYear" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height:10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvYears" runat="server" Width="30%" EmptyDataText="No Records Found">
                    <Columns>                        
                        <asp:TemplateField HeaderText="Click To View Details">
                            <ItemStyle Width="100%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <a href='#' onclick="OpenDocument('<%# Eval("Path")%>','<%# Eval("Filename")%>');"><%#Eval("Year")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height:30px;">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="parent.parent.GB_hide();" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height:10px;">
            </td>
        </tr>
    </table>
    </div>
    </form>
    <script type="text/javascript">
     function OpenDocument(strPath, strFileName)
     {
        if(strPath != '' && strFileName != '')        
            window.open(strPath + "/" + strFileName, "Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        else
            alert('No document exists for this year');
     }
    </script>
</body>
</html>
