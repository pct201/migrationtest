<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="SONIC_Exposures_Administrator_Test" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function getName1()
{    
    var chkText = '';
    var chktable = document.getElementById('<%=chklistInterests.ClientID %>');
    alert(chktable);
    var chktr = chktable.getElementsByTagName('tr');
    alert(chktr);
    for(var i=0; i<chktr.length; i++)
    {
        var chktd = chktr[i].getElementsByTagName('td');
        for(var j=0; j<chktd.length; j++)
        {
           var chkinput = chktd[j].getElementsByTagName('input');
           var chklabel= chktd[j].getElementsByTagName('label');                             
           for(k=0;k<chkinput.length;k++)
            {                    
                var chkopt = chkinput[k];                    
                if(chkopt.checked)
                {
                    chkText = chkText + chklabel[k].innerText + ',';
                }
            } 
        }            
    }        
   alert(chkText);
}
</script>
<div>
            <asp:CheckBoxList ID="chklistInterests" runat="server" RepeatColumns="2" CellSpacing="5"
                CellPadding="2">
                <asp:ListItem Text="A" Value="A"></asp:ListItem>
                <asp:ListItem Text="B" Value="B"></asp:ListItem>
                <asp:ListItem Text="C" Value="C"></asp:ListItem>
                <asp:ListItem Text="D" Value="D"></asp:ListItem>
                <asp:ListItem Text="E" Value="E"></asp:ListItem>
                <asp:ListItem Text="F" Value="F"></asp:ListItem>
                <asp:ListItem Text="G" Value="G"></asp:ListItem>
                <asp:ListItem Text="H" Value="H"></asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <input type="button" value="Get" title="Get" id="btnGet" onclick="getName1()" />
        </div>
</asp:Content>

