<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Notes.ascx.cs" Inherits="Controls_LongDescription_LongDescription_SpellCheck" %>
<script type="text/javascript" src="../../JavaScript/Validator.js"></script>
<script src='<%=AppConfig.SiteURL%>/NetSpell/spell.js' type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function ExpandNotes(bExpand, imgPlusId, imgMinusId, txtId) {
        if (bExpand) {
            document.getElementById(txtId).rows = 30;
            document.getElementById(imgMinusId).style.display = "";
            document.getElementById(imgPlusId).style.display = "none";
        }
        else {
            document.getElementById(txtId).rows = 5;
            document.getElementById(imgMinusId).style.display = "none";
            document.getElementById(imgPlusId).style.display = "";
        }
    }

    spellURL = '<%=AppConfig.SiteURL%>/NetSpell/SpellCheck.aspx';

</script>
<table cellpadding="3" cellspacing="0" width="97%" id="tblNotes" runat="server" border="0">
    <tr style="height: 20px;">
        <td align="left" valign="baseline" width="100%">
            <img id="imgPlus" runat="server" alt="" src="../../Images/plus.jpg" style="cursor: pointer;" />
            <img id="imgMinus" runat="server" alt="" src="../../Images/minus.jpg" style="cursor: pointer;
                display: none;" />&nbsp;&nbsp;
            <img id="imgSpellCheck" runat="server" alt="Spell Check" height="20" src="../../Images/spellcheck.gif"
                style="padding-right: 0px; padding-left: 0px; filter: alplha(opactiy=100); padding-bottom: 0px;
                cursor: hand; padding-top: 0px" title="Spell Check" width="21" />&nbsp;&nbsp;
          <asp:LinkButton ID="btnExport" runat="server" Visible="false" Text="Export To Excel" OnClick="btnExport_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Rows="5" MaxLength="8000"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtNote"
                Display="None" Enabled="False"></asp:RequiredFieldValidator>
                <asp:Button runat="server" ID="btnHdn" Visible="false" OnClick="btnHdn_Click" />
        </td>
    </tr>     
</table>
