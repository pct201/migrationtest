<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PoliciesExpiringIn90Days.aspx.cs" Inherits="COIReports_PoliciesExpiringIn90Days" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                &nbsp;Policies Expiring within 90 Days (By Entity)
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
                            <asp:DropDownList ID="drpCOIType" runat="server" Width="215px" />
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
                                    <asp:GridView ID="gvReport" runat="server" Width="100%" EnableTheming="false" GridLines="none" AutoGenerateColumns="false" 
                                     EmptyDataText="No Record Found" ShowFooter="true" CellPadding="4" CellSpacing="0">   
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                        <FooterStyle ForeColor="White" Font-Bold="true" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                        <Columns>
                                            <asp:BoundField DataField="Entity Name" HeaderText="Entity Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Contact Name" HeaderText="Contact Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Telephone" HeaderText="Telephone" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Fax" HeaderText="Fax" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Region" HeaderText="Region" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Automobile Liability Expiration Date" HeaderText="Automobile Liability Expiration Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="140px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="General Liability Expiration Date" HeaderText="General Liability Expiration Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="130px" FooterStyle-BackColor="#507CD1" />
                                             <asp:BoundField DataField="Liquor Liability Expiration Date" HeaderText="Liquor Liability Expiration Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                              <asp:BoundField DataField="Excess Liability Expiration Date" HeaderText="Excess Liability Expiration Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                               <asp:BoundField DataField="Property Liability Expiration Date" HeaderText="Property Liability Expiration Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="WC/EL Expiration Date" HeaderText="WC/EL Expiration Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" FooterStyle-BackColor="#507CD1" />
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
