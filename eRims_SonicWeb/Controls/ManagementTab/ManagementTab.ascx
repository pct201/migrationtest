<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManagementTab.ascx.cs"
    Inherits="Controls_ManagementTab_ManagementTab" %>
<link href="../../App_Themes/Default/ERIMS.css" rel="stylesheet" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td id="tab1" class="tab" onclick="RedirectTo(1);">
            Search
        </td>
        <td id="tab2" class="tab" onclick="RedirectTo(2);">
            Management
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<br />
<table cellpadding="3" id="tblManagement" runat="server" cellspacing="1" border="0"
    width="100%" style="background-color: Black; display: none;">
    <tr class="PropertyInfoBG">
        <td>
            &nbsp;
        </td>
    </tr>
    <tr style="background-color: White;">
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<script type="text/javascript">
    var valid = true;
    function SaveContact() {
        return true;
    }
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
            if (window.location.href.indexOf("ManagementSearch.aspx") > 0) {
                if (SaveContact()) {
                    window.location.href = '<%=AppConfig.SiteURL%>Management/ManagementSearch.aspx?criteria=1';
                }
            }
            else {
                window.location.href = '<%=AppConfig.SiteURL%>Management/ManagementSearch.aspx?criteria=1';
            }
        }
        else if (index == 2) {

            if (window.location.href.indexOf("Management.aspx") > 0) {

                var pkmgmt = '<%=Request.QueryString["id"] %>'
                var mode = '<%=Request.QueryString["mode"] %>'
                window.location.href = '<%=AppConfig.SiteURL%>Management/Management.aspx?id=' + pkmgmt + '&mode=' + mode;
            }
            else
                window.location.href = '<%=AppConfig.SiteURL%>Management/Management.aspx';
        }

    }
</script>
