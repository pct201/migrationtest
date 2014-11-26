<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClaimTab.ascx.cs" Inherits="Controls_ClaimTab_ClaimTab" %>
<link href='<%=AppConfig.SiteURL%>Controls/ClaimTab/SONICTab.css' rel="stylesheet" type="text/css" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td id="tab1" class="tab" onclick="javascript:NavigatePage('<%=AppConfig.SiteURL%>SONIC/ClaimInfo/WCClaimInfo.aspx',1,this);">
            WC
        </td>
        <td id="tab2" class="tab" onclick="javascript:NavigatePage('<%=AppConfig.SiteURL%>SONIC/ClaimInfo/ALClaimInfo.aspx',2,this);">
            AL
        </td>
        <td id="tab3" class="tab" onclick="javascript:NavigatePage('<%=AppConfig.SiteURL%>SONIC/ClaimInfo/DPDClaimInfo.aspx',3,this);">
            DPD
        </td>
        <td id="tab4" class="tab" onclick="javascript:NavigatePage('<%=AppConfig.SiteURL%>SONIC/ClaimInfo/PropertyClaimInfo.aspx',4,this);">
            Property
        </td>
        <td id="tab5" class="tab" onclick="javascript:NavigatePage('<%=AppConfig.SiteURL%>SONIC/ClaimInfo/PLClaimInfo.aspx',5,this);">
            PL
        </td>
        <td id="tab6" class="tab" onclick="javascript:NavigatePage('<%=AppConfig.SiteURL%>SONIC/ClaimInfo/MainDiary.aspx',6,this);">
            Diary
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

<script type="text/javascript">
    //set the tab style if tab is active than apply class name is "tabselected" else "tab".
    var Index;
    function SetTabStyle(index)
    {  
        var i,j;
        Index= index;
        var Temp = '<%=clsSession.AllowedTab %>';
        var Allow_Tab = Temp.split(",");
        if(index == 6)
        {
            document.getElementById('tab6').onclick='javascript:void(0);'
            document.getElementById('tab6').className="tabSelected";;
        }
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
                    tb.style.cursor="cursor";
                }
                else
                {
                    tb.className="tab";
                    tb.style.cursor="cursor";
                }
            }
        }
    }
    function NavigatePage(pgURL,Num,ctl)
    {
        if(Number(Num) < 6)
        {
            var Temp = '<%=clsSession.AllowedTab %>';
            var Allow_Tab = Temp.split(",");
            for(j=0;j<Allow_Tab.length;j++)
            {
                if(Allow_Tab[j] == Num)
                {
                    var id1 = '<%=clsSession.ClaimID_Diary %>';
                    var PageURL = pgURL + '?id=' + id1;
                    window.location.href= PageURL;
                }
            }
        }
        else
        {
            var id = '<%=clsSession.ClaimID_Diary %>';
            var PageURL = pgURL + '?id=' + id;
            if(Index == 1)
            {
                PageURL = PageURL + '&tbl=WC_Claim';
            }
            else if(Index == 2)
            {
                PageURL = PageURL + '&tbl=AL_Claim';
            }
            else if(Index == 3)
            {
                PageURL = PageURL + '&tbl=DPD_Claim';
            }
            else if(Index == 4)
            {
                PageURL = PageURL + '&tbl=Property_Claim';
            }
            else if(Index == 5)
            {
                PageURL = PageURL + '&tbl=PL_Claim';
            }
            window.location.href= PageURL;
        }
    }
</script>