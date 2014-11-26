<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExposureInfo.ascx.cs" Inherits="ExposureInfo" %>
<table cellpadding="3" cellspacing="1" border="0"  style="background-color:Black;" width="100%">
    <tr class="PropertyInfoBG">
        <td align="left" style="width:18%">
            <asp:Label ID="lblHeaderRMLocationNumber" Text="Location Number" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:23%">
            <asp:Label ID="lblHeaderLocationdba" Text="SONIC Location d/b/a" runat="server"></asp:Label>
        </td>
         <td align="left" style="width:20%" >
            <asp:Label ID="lblHeaderAddress" Text="Address" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:15%" >
            <asp:Label ID="lblHeaderCity" Text="City" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:14%">
            <asp:Label ID="lblHeaderState" Text="State" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:10%;">
            <asp:Label ID="lblHeaderZip" Text="Zip" runat="server"></asp:Label>
        </td>        
    </tr>    
    <tr style="background-color:White;">
        <td align="left">
            <asp:Label ID="lblRMLocationNumber" runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblLocationdba"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblAddress"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblCity"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblState"  runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblZip" runat="server"></asp:Label>
        </td>        
    </tr>
</table>