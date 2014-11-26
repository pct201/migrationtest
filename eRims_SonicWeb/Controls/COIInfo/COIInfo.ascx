<%@ Control Language="C#" AutoEventWireup="true" CodeFile="COIInfo.ascx.cs"
    Inherits="COIInfo" %>
<table cellpadding="3" cellspacing="1" border="0" style="background-color: Black;"
    width="100%">
    <tr class="PropertyInfoBG">
        <td align="left" style="width: 20%">
            D/B/A Location Name
        </td>
        <td align="left" style="width: 20%">
            Sonic Location Number
        </td>
        <td align="left" style="width: 20%">
            Insured Name
        </td>
        <td align="left" style="width: 20%">
            Issue Date
        </td>
        <td align="left" style="width: 20%;">
            Effective Date
        </td>
    </tr>
    <tr style="background-color: White;">
        <td align="left" valign="top" >
            <asp:Label ID="lblDBALocationName" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblSonicLocationNo" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblInsuredName" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblIssueDate" runat="server"></asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblEffectiveDate" runat="server"></asp:Label>
        </td>
    </tr>
</table>
