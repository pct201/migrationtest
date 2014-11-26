<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RealEstateInfo.ascx.cs"
    Inherits="RealEstateInfo" %>
<table cellpadding="3" cellspacing="1" border="0" style="background-color: Black;"
    width="100%">
    <tr class="PropertyInfoBG">
        <td align="left" style="width: 20%">
            Dealership
        </td>
        <td align="left" style="width: 8%">
            LCD
        </td>
        <td align="left" style="width: 8%">
            LED
        </td>
        <td align="left" style="width: 19%">
            Landlord
        </td>
        <td align="left" style="width: 15%;">
            Date Acquired
        </td>
        <td align="left" style="width: 15%">
            Lease Type
        </td>
        <td align="left" style="width: 15%;">
            Project Type
        </td>
    </tr>
    <tr style="background-color: White;">
        <td align="left" valign="top" >
            <asp:Label ID="lblDealership" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblLCD" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblLED" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblLandlord" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblDateAcquired" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblLeaseType" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblProjectType" runat="server"></asp:Label>
        </td>
    </tr>
</table>
