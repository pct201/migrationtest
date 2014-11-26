<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Purchasing.ascx.cs" Inherits="CtrlPurchasing" %>
<link href="<%=AppConfig.SiteURL%>Controls/ExcecutiveRiskInfo/ExecutiveRiskTab.css"
    rel="stylesheet" />

<table cellpadding="3" cellspacing="1" border="0" width="100%" style="background-color: Black;">
    <tr class="PropertyInfoBG">
        <td align="left" width="18%">
            Supplier
        </td>
        <td align="left" width="16%" nowrap="nowrap">
            Service Type
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
            <asp:Label ID="lblServiceType" runat="server">
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



