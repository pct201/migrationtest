<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CRMTab.ascx.cs" Inherits="CRMTab" %>
<link href="../ExcecutiveRiskInfo/ExecutiveRiskTab.css" rel="stylesheet" />
<table cellpadding="0" cellspacing="0">
    <tr>
        <td id="tab1" class="tabSelected" onclick="RedirectTo(1);">
            Search
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">
            <asp:Label ID="lblCustomerType" runat="server" Text="Customer" />
        </td>
    </tr>
</table>
<script type="text/javascript" language="javascript">

    function SetTabStyle(index) {
        var i;
        for (i = 1; i <= 2; i++) {
            var tb = document.getElementById("tab" + i);
            if (i == index)
                tb.className = "tabSelected";
            else
                tb.className = "tab";
        }
    }

    function RedirectTo(index) {
        if (index == 1) {
            if (document.location.pathname.indexOf('CRM/CRM_Customer.aspx') > -1)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/CRM/CRMSearch.aspx?typ=1';
            else if (document.location.pathname.indexOf('CRM_NonCustomer.aspx') > -1)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/CRM/CRMSearch.aspx?typ=2';
            else
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/CRM/CRMSearch.aspx';
        }
        else if (index == 2) {
            var IsNonCustomer = '<%=IsNonCustomer %>';
            if (IsNonCustomer.toLowerCase() == "true")
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/CRM/CRM_NonCustomer.aspx';
            else
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/CRM/CRM_Customer.aspx';
        }
    }
</script>
