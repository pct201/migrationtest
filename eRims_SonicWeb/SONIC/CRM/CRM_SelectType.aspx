<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="CRM_SelectType.aspx.cs" Inherits="SONIC_CRM_CRM_SelectType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td width="100%" align="left">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" class="bandHeaderRow">
            CRM Add
        </td>
    </tr>
    <tr>
        <td align="left" style="height:20px;">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left">
            <table cellpadding="4" cellspacing="4" width="50%" align="center">
                <tr>
                    <td align="right" width="30%">
                        Incident Type
                    </td>
                    <td align="center" width="10%">:</td>
                    <td align="left" >
                        <asp:DropDownList ID="drpIncidentType" runat="server" Width="200px" SkinID="dropGen" >
                            <asp:ListItem Text="Customer" Value="Customer" />
                            <asp:ListItem Text="Non-Customer" Value="Non-Customer" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text=" Add " OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left" style="height:20px;">
            &nbsp;
        </td>
    </tr>
</table>
</asp:Content>

