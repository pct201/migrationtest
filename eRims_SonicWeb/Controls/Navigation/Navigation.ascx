<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Controls_Navigation_Navigation" %>
<asp:Panel ID="pnlnavigation" runat="server" DefaultButton="btnGo" Width="100%">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right" valign="middle" class="lc">
            No. of Records per page :
            <asp:DropDownList ID="drpRecords" runat="server" SkinID="dropGen" CssClass="pagingfields" ValidationGroup="Paging" AutoPostBack="true" OnSelectedIndexChanged="drpRecords_SelectedIndexChanged"></asp:DropDownList>&nbsp;
       </td>
       <td class="ic">
            <asp:Button ID="imgPrevious" runat="server" Text=" < "  OnClick="imgPrevious_Click"  />&nbsp;
       </td>
       <td class="ic">
            Page <asp:Label ID="lblCurrentPage" runat="server" Text="0"></asp:Label>&nbsp;of&nbsp;
            <asp:Label ID="lblTotalPage" runat="server" Text="0"></asp:Label>&nbsp;
       </td>
       <td class="ic">
            <asp:Button ID="imgNext" runat="server" Text=" > " OnClick="imgNext_Click" />&nbsp;
       </td>
       <td class="ic">
            Go to page :
        </td>
       <td class="ic">
            <asp:TextBox ID="txtPageNumber" runat="server" Width="20px" Text="1" MaxLength="8" CssClass="pagingfields"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPageNumber" runat="server" ErrorMessage="!!" ControlToValidate="txtPageNumber" Display="dynamic" ValidationGroup="Paging"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPageNumber" runat="server" ErrorMessage="!!" ControlToValidate="txtPageNumber" Display="dynamic" ValidationExpression="^([0-9]*|\d*\d{1}?\d*)$" ValidationGroup="Paging"></asp:RegularExpressionValidator>
       </td>
       <td class="ic">
            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" ValidationGroup="Paging"/>&nbsp;
        </td>
    </tr>
</table>
</asp:Panel>