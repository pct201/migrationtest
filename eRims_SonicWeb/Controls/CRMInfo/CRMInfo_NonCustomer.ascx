<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CRMInfo_NonCustomer.ascx.cs" Inherits="CRMInfo_NonCustomer" %>
<table cellpadding="3" cellspacing="1" border="0"  style="background-color:Black;" width="100%">
    <tr class="PropertyInfoBG">
        <td align="left" style="width:12%">
            Incident Type
        </td>
        <td align="left" style="width:14%">
            Contact Number
        </td>
        <td align="left" style="width:23%">
            Location D/B/A
        </td>
        <td align="left" style="width:12%">
            Date of Contact
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
            <asp:Label ID="lblContactNumber" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblDBA" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblDateOfContact"  runat="server"></asp:Label>
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