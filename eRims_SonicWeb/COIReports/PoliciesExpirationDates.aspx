<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PoliciesExpirationDates.aspx.cs" Inherits="COIReports_PoliciesExpirationDates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                &nbsp;Policy Expiration Dates (By Entity Name)
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
                                    <asp:LinkButton ID="btnExport" runat="server" Text="Export To Excel " OnClick="btnExport_Click" /></b>&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <%--<tr>
                            <td width="100%" align="left">
                                <asp:Panel ID="pnlGrid" runat="server" Width="990px" ScrollBars="Horizontal">
                                    <asp:GridView ID="gvReport" runat="server" Width="2200px" EnableTheming="false" GridLines="none" 
                                     EmptyDataText="No Record Found"  AutoGenerateColumns="false" ShowFooter="true" CellPadding="4" CellSpacing="0">  
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                        <FooterStyle ForeColor="White" Font-Bold="true" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                        <Columns>
                                            <asp:BoundField DataField="Entity Name" HeaderText="Entity Name" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Contact Name" HeaderText="Contact Name" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Office Address" HeaderText="Office Address" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="State" HeaderText="State" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Zip Code" HeaderText="Zip Code" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Region" HeaderText="Region" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="E-Mail Address" HeaderText="E-Mail Address" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Date Activated" HeaderText="Date Activated" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Date Closed" HeaderText="Date Closed" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="GL Policy Cancelled" HeaderText="GL Policy Cancelled" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="GL Policy Expiration" HeaderText="GL Policy Expiration" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Liquor Cancelled" HeaderText="Liquor Cancelled" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Liquor Expiration" HeaderText="Liquor Expiration" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Auto Policy Cancelled" HeaderText="Auto Policy Cancelled" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Auto Policy Expiration" HeaderText="Auto Policy Expiration" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="EX Policy Cancelled" HeaderText="EX Policy Cancelled" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="EX Policy Expiration" HeaderText="EX Policy Expiration" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="WC/EL Policy Cancelled" HeaderText="WC/EL Policy Cancelled" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="WC/EL Policy Expiration" HeaderText="WC/EL Policy Expiration" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Prop Policy Cancelled" HeaderText="Prop Policy Cancelled" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Prop Policy Expiration" HeaderText="Prop Policy Expiration" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" FooterStyle-BackColor="#507CD1" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>--%>
                         <tr id="trGrid" runat="server">
                            <td align="left">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <div id="divReportData" runat="server" style="width: 995px; overflow-x: scroll; overflow-y: none;">
                                                <asp:Label ID="lblReport" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
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
