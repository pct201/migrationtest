<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SonicTab.ascx.cs" Inherits="Controls_SONICtab_SonicTab" %>
<link href='<%=AppConfig.SiteURL%>Controls/SONICtab/SONICTab.css' rel="stylesheet"
    type="text/css" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td id="tab1" class="tab">
            WC
        </td>
        <td id="tab2" class="tab">
            AL
        </td>
        <td id="tab3" class="tab">
            DPD
        </td>
        <td id="tab4" class="tab">
            Property
        </td>
        <td id="tab5" class="tab">
            PL
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

<script type="text/javascript">
    //set the tab style if tab is active than apply class name is "tabselected" else "tab".
    function SetTabStyle(index) {
        var i,j;
        var Temp = '<%=clsSession.AllowedTab %>';
        var Allow_Tab = Temp.split(",");
        for(i=1; i<=5 ;i++)
        {
            var bool = false;
            var tbName="tab" + i;
            var tb=document.getElementById(tbName);
            for(j=0;j<Allow_Tab.length;j++)
            {
                if("tab" + i == "tab" + Allow_Tab[j])
                {
                    bool = true;
                    break;
                }
            }
            if(bool==false)
            {
                tb.className="tabNotAllowed";
                tb.style.cursor="default";
            }
            else
            {
                if(i==index)
                {
                    tb.className="tabSelected";
                    tb.style.cursor="default";
                }
                else
                {
                    tb.className="tab";
                    tb.style.cursor="default";
                }
            }
        }
    }
</script>
