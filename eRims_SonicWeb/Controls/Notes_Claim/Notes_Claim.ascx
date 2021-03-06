<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Notes_Claim.ascx.cs" Inherits="Controls_Notes_Claim_Notes_Claim" %>
<script type="text/javascript" src="../../JavaScript/Validator.js"></script>
<script language="javascript" type="text/javascript">
function ExpandNotes(bExpand,imgPlusId,imgMinusId,txtId)
{
    if(bExpand)
    {
        document.getElementById(txtId).rows=30;
        document.getElementById(imgMinusId).style.display = "block";
        document.getElementById(imgPlusId).style.display = "none";
    }
    else
    {
        document.getElementById(txtId).rows=5;
        document.getElementById(imgMinusId).style.display = "none";
        document.getElementById(imgPlusId).style.display = "block";
    }
}
</script>
<table cellpadding="0" cellspacing="0" width="97%" id="tblNotes" runat="server">
        <tr style="height:20px;">
            <td align="left" valign="middle">
                <img id="imgPlus" runat="server" src="../../Images/plus.jpg" style="cursor:pointer;" />
                <img id="imgMinus" runat="server" src="../../Images/minus.jpg" style="cursor:pointer;display:none;" />                
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Rows="5" MaxLength="8000"></asp:TextBox>            
                <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtNote" Display="None" Enabled="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
</table>