<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventInfo.ascx.cs" Inherits="Controls_EventInfo_EventInfo" %>
<table cellpadding="3" id="tblEventIdentification" runat="server" cellspacing="1"
    border="0" width="100%" style="background-color: Black;">
    <tr class="PropertyInfoBG" align="left" valign="top">
        <td style="width:20%">
            Event Number
        </td>
        <td style="width:20%">
            AL First Report #
        </td>
        <td style="width:20%">
            DPD First Report #
        </td>
        <td style="width:20%">
            PL First Report #
        </td>
        <td  style="width:20%">
            Property First Report #
        </td>
    </tr>
    <tr style="background-color: White;" valign="top" align="left">
        <td>
            <asp:Label ID="lblEventNumber" runat="server"></asp:Label>
        </td>
        <td>
            <asp:LinkButton ID="lnkALFirstReport_No" Text="" runat="server" />
        </td>
        <td>
            <asp:LinkButton ID="lnkDPDFirstReport_No" Text="" runat="server" />
        </td>
        <td>
            <asp:LinkButton ID="lnkPDFirstReport_No" Text="" runat="server" />
        </td>
        <td>
            <asp:LinkButton ID="lnkPLFirstReport_No" Text="" runat="server" />
        </td>
    </tr>
</table>

