<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ACIEventCountByLocation.aspx.cs" Inherits="DashBoard_ACIEventCountByLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="100%" cellpadding="0" cellspacing="0" class="BorderWhite">
            <tr>
                <td align="left" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblLocation" runat="server" />
                            </td>
                       
                            <td align="left" valign="top">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblYear" runat="server" />
                            </td>
                            <td align="left" valign="top">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblMonth" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" height="10px">
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:GridView ID="gvEventData" runat="server" Width="100%" OnRowDataBound="gvEventData_OnRowDataBound"
                        EmptyDataText="No Record Exists">
                        <Columns>
                            <asp:TemplateField HeaderText="Event Type" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Type" Text='<%# Eval("Event_Type") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ACI Event Count" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblACI_Event" Text='<%# Eval("ACI_Event") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic Event Count" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Event" Text='<%# Eval("Sonic_Event") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ACI Event Percentage" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblACI_Event_Percent" Text='<%# Eval("ACI_Event_Percent") %>' runat="server" />%
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic Event Percentage" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Event_Percent" Text='<%# Eval("Sonic_Event_Percent") %>' runat="server" />%
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
