<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Entity.aspx.cs" Inherits="COIReports_Entity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                &nbsp;Entity (Producer and Insurance Company)
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="30%" align="center">
                    <tr>
                        <td colspan="2" class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" align="left">
                            Type
                        </td>
                        <td width="2%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpCOIType" runat="server"  Width="215px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />
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
            <td align="center">
                <div id="dvGrid" runat="server" style="display: none;">
                    <table cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td align="right">
                                <b>
                                    <asp:LinkButton ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" /></b>
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="left">
                                <asp:Panel ID="pnlGrid" runat="server" Width="990px">
                                    <asp:GridView ID="gvReport" runat="server" Width="1050px" CssClass="GridClass" EmptyDataText="No Record Found" AutoGenerateColumns="false"
                                        EnableTheming="false" ShowFooter="true" GridLines="none" CellPadding="4" CellSpacing="0" >
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                        <FooterStyle ForeColor="White" Font-Bold="true" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                        <Columns>
                                            <asp:BoundField DataField="Entity Name" HeaderText="Entity Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="135px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Producer" HeaderText="Producer" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="135px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="General Liability  Insurance Company" HeaderText="General Liability Insurance Company" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="130px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Liquor Liability Insurance Company" HeaderText="Liquor Liability Insurance Company" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="130px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Auto Liability Insurance Company" HeaderText="Auto Liability Insurance Company" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="130px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Excess Liability Insurance Company" HeaderText="Excess Liability Insurance Company" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="130px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Work Comp/EL Insurance Company" HeaderText="Work Comp/EL Insurance Company" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="130px"  FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Property Insurance Company" HeaderText="Property Insurance Company" HeaderStyle-HorizontalAlign="Left"  ItemStyle-Width="130px"  FooterStyle-BackColor="#507CD1" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
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
</div>    
</asp:Content>
