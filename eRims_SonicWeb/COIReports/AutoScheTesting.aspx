<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="AutoScheTesting.aspx.cs" Inherits="COIReports_AutoScheTesting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="heading">
                Auto Schedule Testing
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="100%" align="center">
                    <tr>
                        <td class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td align="right">
                                        <b>
                                            <asp:LinkButton ID="btnExport1" runat="server" Text="Export To Excel" OnClick="btnExport1_Click" /></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 15px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="left">
                                        <asp:Panel ID="pnlGrid1" runat="server" Width="950px">
                                            <asp:GridView ID="gvVehicle" runat="server" Width="100%" EmptyDataText="No records found"
                                                SkinID="ReportGrid" EnableTheming="true" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                AlternatingRowStyle-HorizontalAlign="Left" ShowFooter="true" GridLines="none"
                                                AutoGenerateColumns="false">
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="DATE PURCHASED" HeaderText="Date Purchased" />
                                                    <asp:BoundField DataField="Year of Auto" HeaderText="Year of Auto" />
                                                    <asp:BoundField DataField="msg1G/MAKE" HeaderText="msg1G/MAKE" />
                                                    <asp:BoundField DataField="serial number" HeaderText="Serial Number" />
                                                    <asp:BoundField DataField="cost" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        HeaderText="Cost" />
                                                    <asp:BoundField DataField="GARAGED" HeaderText="GARAGED" />
                                                    <asp:BoundField DataField="plate number" HeaderText="Plate Number" />
                                                    <asp:BoundField DataField="INSURANCE CARRIER" HeaderText="Insurance Carrier" />
                                                    <asp:BoundField DataField="POLICY NUMBER" HeaderText="Policy Number" />
                                                    <asp:BoundField DataField="policy period" HeaderText="Policy Period" />
                                                    <asp:BoundField DataField="DATE AUTO DELETED" HeaderText="Date Auto Deleted" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 30px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <b>
                                            <asp:LinkButton ID="btnExport2" runat="server" Text="Export To Excel" OnClick="btnExport2_Click" /></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 15px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="left">
                                        <asp:Panel ID="pnlGrid2" runat="server" Width="950px">
                                            <asp:GridView ID="gvDriver" runat="server" Width="100%" EmptyDataText="No records found"
                                                SkinID="ReportGrid" EnableTheming="true" RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                AlternatingRowStyle-HorizontalAlign="Left" ShowFooter="true" GridLines="none"
                                                AutoGenerateColumns="false">
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="CO" HeaderText="CO" />
                                                    <asp:BoundField DataField="SCHEDULED DRIVER" HeaderText="SCHEDULED DRIVER" />
                                                    <asp:BoundField DataField="BIRTH DATE" HeaderText="BIRTH DATE" />
                                                    <asp:BoundField DataField="DRIVER LICENSE NO." HeaderText="DRIVER LICENSE" />
                                                    <asp:BoundField DataField="STATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        HeaderText="STATE" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 15px;">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
</asp:Content>
