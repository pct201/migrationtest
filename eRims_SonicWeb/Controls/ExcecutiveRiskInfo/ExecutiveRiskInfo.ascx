<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExecutiveRiskInfo.ascx.cs" Inherits="CtrlExecutiveRiskInfo" %>
<link href="<%=AppConfig.SiteURL%>Controls/ExcecutiveRiskInfo/ExecutiveRiskTab.css" rel="stylesheet" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td id="tab1" class="tab" onclick="RedirectTo(1);">
            Executive Risk
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">
            Diary
        </td>        
        <td id="tab3" class="tab" onclick="RedirectTo(3);">
            Adjustor Notes
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
<br />
<table cellpadding="3" cellspacing="1" border="0" width="100%" style="background-color:Black;">
    <tr class="PropertyInfoBG">
        <td align="left" width="20%">
            Claim Number
        </td>
        <td align="left" width="40%">
            Entity
        </td>
        
        <td align="left" width="20%">
            Date of Loss
        </td>
        <td align="left" width="20%">
            Claim Type
        </td>        
       
    </tr>       
    <tr style="background-color:White;">
        <td align="left">
            <asp:Label ID="lblClaimNumber"  runat="server">
            </asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblEntity" runat="server">
            </asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblDateOfLoss" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblClaimType" runat="server">
            </asp:Label>
        </td>        
    </tr>
  
</table>
<script type="text/javascript">
    function SetTabStyle(index)
    {
        var i;
        for(i=1; i<=3 ;i++)
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
        var eid = '<%=clsSession.Current_Executive_Risk_ID%>';
        if(eid > 0)
        {
            if(index == 1)
                window.location.href='<%=AppConfig.SiteURL%>ExecutiveRisk/ExecutiveRisk.aspx?id=' + eid;
            else if(index == 2)
                window.location.href='<%=AppConfig.SiteURL%>ExecutiveRisk/MainDiary.aspx';            
            else if(index == 3)
                window.location.href='<%=AppConfig.SiteURL%>ExecutiveRisk/Adjuster.aspx';
        }   
        
    }
</script>
