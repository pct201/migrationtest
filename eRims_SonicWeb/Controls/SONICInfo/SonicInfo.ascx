<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SonicInfo.ascx.cs" Inherits="Controls_SONICInfo_SonicInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">

    function ShowMessage(InvPk, wcId) {
        
        if (confirm("An Investigation for this First Report has been found, would you like to view it?")) {
            parent.location = '<%=AppConfig.SiteURL%>SONIC/FirstReport/Investigation.aspx?id=' + InvPk + "&wc=" + wcId;
        }
        else
            ShowPanel(1);
    }

</script>

<table cellpadding="3" cellspacing="1" border="0" style="background-color: Black;"
    width="100%">
    <tr class="PropertyInfoBG">      
        <td align="left" style="width: 15%">
            <asp:Label ID="lblHeaderFirstReportNumber" Text="First Report Number" runat="server"></asp:Label>
        </td>
        <td align="left" style="width: 15%">
            <asp:Label ID="lblHeaderLocationdba" Text="SONIC Location d/b/a" runat="server"></asp:Label>
        </td>
        <td align="left" style="width: 13%; display: none;" runat="server" id="tdHeaderName">
            <asp:Label ID="lblHeaderName" Text="Name" runat="server"></asp:Label>
        </td>
        <td align="left" style="width: 13%">
            <asp:Label ID="lblHeaderDateIncident" Text="Date of Incident" runat="server"></asp:Label>
        </td>
          <td align="left" style="width: 10%">
            <asp:Label ID="lblHeaderFirstClaimNumber" Text="Claim Number" runat="server"></asp:Label>
        </td>
        <td align="left" id="tdHeaderInvestigation" runat="server" style="width: 12%; display: none;">
            <asp:Label ID="lblHeaderInvestigation" Text="Investigation" runat="server"></asp:Label>
        </td>
        <td align="left" style="width: 21%">
            <asp:Label ID="lblHeaderCompanionFirstReport" Text="Companion First Report(s)" runat="server"></asp:Label>
        </td>
    </tr>
    <tr style="background-color: White;">
     
        <td align="left">
            <asp:Label ID="lblFirstReportNumber" runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
        </td>
        <td align="left" runat="Server" id="tdName" style="display: none;">
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblDateIncident" runat="server"></asp:Label>
        </td>
           <td align="left">
            <asp:LinkButton ID="lnkClaimNumber" Text="" runat="server" CausesValidation="false" />
        </td>
        <td align="left" id="tdDataInvestigation" runat="server" style="display: none;">
            <asp:LinkButton ID="lnkInvestigation" Text="" runat="server" />
            <asp:LinkButton ID="lnkAddInvestigation" runat='server' Text="Add New" OnClick="lnkAddInvestigation_Click" />
        </td>
        <td align="left">
            <asp:DropDownList runat="server" ID="ddlCompanionFirstReport"  AutoPostBack="true" Width="140px" SkinID="dropGen"
                OnSelectedIndexChanged="ddlCompanionFirstReport_SelectedIndexChanged" CausesValidation="false">
            </asp:DropDownList>
            &nbsp;<asp:LinkButton runat="server" ID="lnkAddNew" Text="Add New" OnClick="lnkAddNew_Click"
                CausesValidation="false"></asp:LinkButton>
        </td>
    </tr>
</table>