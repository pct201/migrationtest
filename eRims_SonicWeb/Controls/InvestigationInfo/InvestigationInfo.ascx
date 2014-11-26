<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvestigationInfo.ascx.cs" Inherits="Controls_InvestigationInfo_InvestigationInfo" %>
<table cellpadding="3" cellspacing="1" border="0"  style="background-color:Black;" width="100%">
    <tr class="PropertyInfoBG">
      
        <td align="left" style="width:12%">
            <asp:Label ID="lblHeaderInvestigation" runat="server" Text="Investigation ID" />
        </td>
        <td align="left" style="width:14%">
            <asp:Label ID="lblHeaderWCFrNumber" runat="server" Text="WC First Report ID" />
        </td>
          <td align="left" style="width:12%">
            <asp:Label ID="lblHeaderClaimNumber" runat="server" Text="Claim Number" />
        </td>
        <td align="left" style="width:17%">
            <asp:Label ID="lblHeaderRMLocationNumber" Text="RM Location Number" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:17%">
            <asp:Label ID="lblHeaderLocationdba" Text="SONIC Location d/b/a" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:15%" >
            <asp:Label ID="lblHeaderCity" Text="City" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:13%">
            <asp:Label ID="lblHeaderState" Text="State" runat="server"></asp:Label>
        </td>
        <td align="left" style="width:12%;">
            <asp:Label ID="lblHeaderZip" Text="Zip" runat="server"></asp:Label>
        </td>        
    </tr>    
    <tr style="background-color:White;">
       
        <td align="left">
            <asp:Label ID="lblInvestigationID" runat="server" />
        </td>
        <td align="left">
            <asp:LinkButton ID="lnkWCFrNumber" runat="server" />
        </td>
         <td align="left">
            <asp:LinkButton ID="lbtnClaimNumber" runat="server" />
        </td>
        <td align="left">
            <asp:Label ID="lblRMLocationNumber" runat="server"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="lblLocationdba"  runat="server"></asp:Label>
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