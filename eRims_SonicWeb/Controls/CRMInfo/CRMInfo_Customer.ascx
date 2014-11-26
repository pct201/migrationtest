<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CRMInfo_Customer.ascx.cs" Inherits="CRMInfo_Customer" %>
<table cellpadding="3" cellspacing="1" border="0"  style="background-color:Black;" width="100%">
    <tr class="PropertyInfoBG">
        <td align="left" style="width:12%">
            Incident Type
        </td>
        <td align="left" style="width:14%">
            Complaint Number
        </td>
        <td align="left" style="width:23%">
            Location D/B/A
        </td>
        <td align="left" style="width:12%">
            Date of Incident
        </td>
        <td align="left" style="width:14%" >
            Date of Last Update
        </td>
        <td align="left" style="width:13%">
            Last Name
        </td>
        <td align="left" style="width:13%;">
            First Name
        </td>        
    </tr>    
    <tr style="background-color:White;">
        <td align="left">
            <asp:Label ID="lblIncidentType" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblComplaintNumber" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblDBA" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblDateOfIncident"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblDateOfLastUpdate"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblLastName"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
        </td>        
    </tr>
</table>