<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PurchasingAsset.ascx.cs" Inherits="Controls_SONIC_Purchasing_PurchasingAsset" %>

<table cellpadding="3" cellspacing="1" border="0" width="100%" style="background-color: Black;">
    <tr class="PropertyInfoBG">
        <td align="left" width="18%">
            Type
        </td>
        <td align="left" width="16%" nowrap="nowrap">
            Manufacturer
        </td>
        <td align="left" width="14%" nowrap="nowrap">
            Supplier
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
            <asp:Label ID="lblType" runat="server">
            </asp:Label>
        </td>
        <td align="left" valign="top">
             <asp:Repeater runat="server" ID="rptManufacturer">
                <ItemTemplate>
                    <table width="100%" cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td align="left">
                                <%#Eval("Fld_Desc")%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </td>
        <td align="left" valign="top">
            <asp:Label ID="lblSupplier" runat="server" />
        </td>       
        <td align="left" valign="top">
            <asp:Repeater runat="server" ID="rptDepartment">
                <ItemTemplate>
                    <table width="100%" cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td align="left">
                                <%#Eval("Fld_Desc")%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </td>
        <td align="left" valign="top">
            <asp:Repeater runat="server" ID="rptLocation">
                <ItemTemplate>
                    <table width="100%" cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td align="left">
                                <%#Eval("dba")%>
                                 - 
                                <%#Eval("city")%>
                                , 
                                <%#Eval("state")%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>


