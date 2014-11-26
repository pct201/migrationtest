<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IncidentTab.ascx.cs" Inherits="Controls_IncidentTab_IncidentTab" %>
<link href="../../App_Themes/Default/ERIMS.css" rel="stylesheet" />
<table cellpadding="0" cellspacing="0">
    <tr>
        <td id="tab1" runat="server" class="tab" onclick="RedirectTo(1);">
            Search
        </td>
        <td id="tab2" runat="server" class="tab" onclick="RedirectTo(2);">
            Incident
        </td>
        <td id="tab3" runat="server" class="tab" onclick="RedirectTo(3);">
            Event
        </td>
        <td id="tab4" runat="server" class="tab" onclick="RedirectTo(4);">
            Alarm
        </td>
    </tr>
    <tr>
        <td class="Spacer" style="width: 15px">
            &nbsp;
            <asp:HiddenField ID="hdnCurrTabIndex" runat="server" />
            <asp:HiddenField ID="hdnNextTabIndex" runat="server" />
        </td>
    </tr>
</table>
<script type="text/javascript">
    function SetTabStyle(index, id) {
        var i;
        for (i = 1; i <= 5; i++) {
            var tb = document.getElementById(id + "_tab" + i);

            if (tb != null) {
                if (i == index) {
                    tb.className = "tabSelected";
                    document.getElementById('<%=hdnCurrTabIndex.ClientID %>').value = index.toString();
                }
                else
                    tb.className = "tab";
            }
        }
    }
    function RedirectTo(index) {
        // get current tab index
        var CurrIndex = document.getElementById('<%=hdnCurrTabIndex.ClientID %>').value;
        // set next tab index
        document.getElementById('<%=hdnNextTabIndex.ClientID %>').value = index.toString();
        var Incident_ID = '<%=Request.QueryString["iid"]%>';
        var Event_ID = '<%=Request.QueryString["eid"]%>';
        var Alarm_ID = '<%=Request.QueryString["aid"]%>';
        var isSearch = '<%=Request.QueryString["Search"]%>';
        var pgURL = '<%=Request.Url.ToString()%>';
        var Location = '<%=Request.QueryString["loc"]%>';
        if (index == 1)
            window.location.href = 'EventSearch.aspx?Event=1&loc=' + Location;
        else
            OpenPage(Incident_ID, Event_ID, Alarm_ID, isSearch, Location);
    }

    function OpenPage(pk_incident, pk_Event, pk_Alarm, isSearch, Location) {
        var index = Number(document.getElementById('<%=hdnNextTabIndex.ClientID %>').value);
        var addTo = '<%=Request.QueryString["mode"]%>';
        var Mode = "";
        if (addTo == 'add')
            Mode = "&mode=edit";
        else
            Mode = "&mode=" + addTo;

        if (index == 2) {
            if (pk_incident == 0) {
                //window.location.href = '<%=AppConfig.SiteURL%>Incident/IncidentSearch.aspx?criteria=1';
                return false;
            }
            else {
                window.location.href = 'Incident.aspx' + '?iid=' + pk_incident + '&loc=' + Location + Mode + '&Search=' + isSearch;
            }
        }
        else if (index == 3) {
            if (pk_incident == 0) {
                alert('Please select Incident first.');
                // window.location.href = '<%=AppConfig.SiteURL%>Incident/IncidentSearch.aspx?criteria=1';
            }
            else {
                window.location.href = 'Incident.aspx' + '?iid=' + pk_incident + '&loc=' + Location + Mode + '&Search=' + isSearch;
            }
        }
        else if (index == 4) {
            if (pk_incident == 0) {
                alert('Please select Incident first.');
                return false;
                // window.location.href = '<%=AppConfig.SiteURL%>Incident/IncidentSearch.aspx?criteria=1';
            }
            else if (pk_Event == 0) {
                alert('Please select Event first.');
                return false;
                // window.location.href = '<%=AppConfig.SiteURL%>Event/Event_Initial.aspx' + '?iid=' + pk_incident + Mode;
            }
            else {
                window.location.href = 'Alarm.aspx' + '?iid=' + pk_incident + '&eid=' + pk_Event + '&loc=' + Location + Mode + '&Search=' + isSearch;
            }
        }



    }
</script>
