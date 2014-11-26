<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RealEstate.ascx.cs" Inherits="RealEstate" %>
<link href="../ExcecutiveRiskInfo/ExecutiveRiskTab.css"
    rel="stylesheet" />



<table cellpadding="0" cellspacing="0">
    <tr>
        <td id="tab1" class="tabSelected" onclick="RedirectTo(1);">
            Search
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">
            Real Estate
        </td>
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
           window.location.href='<%=AppConfig.SiteURL%>SONIC/RealEstate/RealEstateSearch.aspx';           
        else
        {
//             if(pred.trim() != '')
//                 window.location.href='<%=AppConfig.SiteURL%>SONIC/RealEstate/<%=StrRedirectTo%>'; 
//             else
//             {
                 var id = '<%=clsSession.Current_RE_Information_ID%>';
                 if(id == null || id == '0')                    
                    window.location.href='<%=AppConfig.SiteURL%>SONIC/RealEstate/RealEstateAddEdit.aspx?mode=Add';
             //}
        }
    }
</script>

