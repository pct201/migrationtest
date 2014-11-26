<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IncidentInfo.ascx.cs"
    Inherits="Controls_IncidentInfo_IncidentInfo" %>
<table cellpadding="3" id="tblClaimIdentification" runat="server" cellspacing="1"
    border="0" width="100%" style="background-color: Black;">
    <tr class="PropertyInfoBG" align="left" valign="top">
        <td width="15%">
            Incident Number
        </td>
        <td width="25%">
            Classification
        </td>
        <td width="15%">
            Incident Date
        </td>
        <td width="15%">
            Incident Time
        </td>
        <td>
            Event Number
        </td>
        <td>
            Location
        </td>
    </tr>
    <tr style="background-color: White;" valign="top" align="left">
        <td>
            <asp:Label ID="lblIncidentNumber" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblIncidentClassification" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblIncidentDate" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblIncidentTime" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblEventNumber" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblLocation" runat="server"></asp:Label>
        </td>
    </tr>
</table>
