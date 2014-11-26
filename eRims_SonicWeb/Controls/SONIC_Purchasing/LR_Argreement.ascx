<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LR_Argreement.ascx.cs"
    Inherits="CtrlLRAgreement" %>
<link href="<%=AppConfig.SiteURL%>Controls/ExcecutiveRiskInfo/ExecutiveRiskTab.css"
    rel="stylesheet" />

<table cellpadding="3" cellspacing="1" border="0" width="100%" style="background-color: Black;">
    <tr class="PropertyInfoBG">
        <td align="left" width="18%">
            Supplier
        </td>
        <td align="left" width="16%" nowrap="nowrap">
            Equipment Type
        </td>
        <td align="left" width="14%" nowrap="nowrap">
            Start Date
        </td>
        <td align="left" width="14%" nowrap="nowrap">
            Expiration Date
        </td>
        <td align="left" width="16%" nowrap="nowrap">
            Department
        </td>
        <td align="left" width="22%" nowrap="nowrap">
            Location
        </td>
    </tr>
    <tr style="background-color: White;">
        <td align="left" valign="top">
            <asp:Label ID="lblSupplier" runat="server">
            </asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblEquipementType" runat="server">
            </asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblStartDate" runat="server" />
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblEnddate" runat="server">
            </asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblDepartment" runat="server">
            </asp:Label>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblLocation" runat="server">
            </asp:Label>
        </td>
    </tr>
</table>


