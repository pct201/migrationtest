<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvestigationWzard.aspx.cs" Inherits="SONIC_Exposures_InvestigationWzard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
</head>
<body> 
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat='server' EnablePartialRendering="true" />
    <div>
    <table cellpadding="5" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height:30px;">
            </td>
        </tr>
        <tr>
            <td width="100%" align="left">
                <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblQuestion" runat="server" Text="Test" Font-Bold="True"/>
                    </ContentTemplate>                    
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height:30px;">
            </td>
        </tr>
        <tr>
            <td align="center">
            <asp:Button ID="btnYes" runat="server" Text ="Yes" OnClick="btnYes_Click" OnClientClick="return CheckForYesValue();" />&nbsp;&nbsp;
            <asp:Button ID="btnNo" runat="server" Text ="No" OnClick="btnNo_Click" OnClientClick="return CheckForNoValues();" />
            </td>
        </tr>
    </table>
    </div>
    </form>
    <script type="text/javascript">
        var ctrlID = '<%=Request.QueryString["ctrlid"]%>';
       
        function RedierctBack()
        {
            parent.parent.GB_hide();
            return false;      
        }
        
        function CheckForYesValue()
        {
            var intYesIndex = '<%=intYesIndex%>';           
            var intNoIndex = '<%=intNoIndex%>';      
               
            if (intYesIndex == 1 && intNoIndex == -1)
            {
                //alert('Not Recordable');
                parent.parent.document.getElementById(ctrlID).innerHTML = "No";
                parent.parent.document.getElementById(ctrlID.replace("lbl","hdn")).value = "No";
                return RedierctBack();               
            }
            else if ((intYesIndex == 2 && (intNoIndex == 3 || intYesIndex == 4)) || intYesIndex == 3 )
            {
                //alert('Recordable');
                parent.parent.document.getElementById(ctrlID).innerHTML = "Yes";
                parent.parent.document.getElementById(ctrlID.replace("lbl","hdn")).value = "Yes";
                return RedierctBack();  
            }
            else
                return true;
        }
        
        function CheckForNoValues()
        {
            var intYesIndex = '<%=intYesIndex%>';
            var intNoIndex = '<%=intNoIndex%>';
            if (intYesIndex == 1 && intNoIndex == -1)
            {
                return true;
            }
            else if ((intNoIndex == 2 && intYesIndex == 1) || intNoIndex == 4 || (intYesIndex == 1 && intNoIndex == -1))
            {
                //alert('Not Recordable');
                parent.parent.document.getElementById(ctrlID).innerHTML = "No";
                parent.parent.document.getElementById(ctrlID.replace("lbl","hdn")).value = "No";
                return RedierctBack();               
            }
            else
                return true;
        }
    </script>
</body>
</html>
