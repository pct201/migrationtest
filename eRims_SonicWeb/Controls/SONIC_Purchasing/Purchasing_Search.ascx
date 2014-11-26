<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Purchasing_Search.ascx.cs"
    Inherits="CtrlPurchasing_Search" %>
<link href="<%=AppConfig.SiteURL%>Controls/ExcecutiveRiskInfo/ExecutiveRiskTab.css"
    rel="stylesheet" />
<table cellpadding="0" cellspacing="0">
    <tr>
        <td id="tab1" class="tabSelected" onclick="RedirectTo(1);">
            Search
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">
            Purchasing
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>

<script type="text/javascript" language="javascript">

    function SetTabStyle(index)
    {      
        var i;
        for(i=1; i<=2 ;i++)
        {
            var tb=document.getElementById("tab"+i);
            if(i==index)
                tb.className="tabSelected";
            else
                tb.className="tab";
        }
    }
    
    function RedirectTo(index)
    {     
        var pred='<%=StrRedirectTo%>'  
        if(index == 1)
           window.location.href='<%=AppConfig.SiteURL%>SONIC/Purchasing/PurchasingSearch.aspx';           
        else
        {
         if(pred.trim() != '')
             window.location.href='<%=AppConfig.SiteURL%>SONIC/Purchasing/<%=StrRedirectTo%>';   
        }
    }
</script>

