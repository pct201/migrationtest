<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="NonCompliantSummary.aspx.cs" Inherits="COIReports_NonCompliantSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                &nbsp;Non Compliant Summary
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
                                <asp:Panel ID="pnlGrid" runat="server" ScrollBars="horizontal" Width="990px">
                                    <asp:GridView ID="gvReport" runat="server" Width="3500px" EnableTheming="false" GridLines="none" AutoGenerateColumns="false" 
                                     EmptyDataText="No Record Found" ShowFooter="true" CellPadding="4" CellSpacing="0">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                        <FooterStyle ForeColor="White" Font-Bold="true" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                        <Columns>
                                            <asp:BoundField DataField="Entity Name" HeaderText="Entity Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Contact Name" HeaderText="Contact Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Telephone" HeaderText="Telephone" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="DIV" HeaderText="DIV" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="DIS" HeaderText="DIS" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Location Number" HeaderText="Location Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Leased Property" HeaderText="Leased Property" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Certificate of Insurance Received" HeaderText="Certificate of Insurance Received" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Insured Name on Certificate The Same as Entity Name" HeaderText="Insured Name on Certificate The Same as Entity Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Additional Insured Provided" HeaderText="Additional Insured Provided" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Insurance is Primary & Non-Contributory" HeaderText="Insurance is Primary & Non-Contributory" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="All Locations are Listed on Certificate" HeaderText="All Locations are Listed on Certificate" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="AM Best Rating is A- or Better" HeaderText="AM Best Rating is A- or Better" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Notice of Cancellation Less than 30 Days" HeaderText="Notice of Cancellation Less than 30 Days" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="General Liability Insufficient Limits Occurrence" HeaderText="General Liability Insufficient Limits Occurrence" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="General Liability Insufficient Limits Aggregate" HeaderText="General Liability Insufficient Limits Aggregate" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Liquor Liability Insufficient Limits" HeaderText="Liquor Liability Insufficient Limits" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Waiver of Subrogation between Prime Lessor and Building Lessor Provided (Leased Property)"
                                                HeaderText="Waiver of Subrogation between Prime Lessor and Building Lessor Provided (Leased Property)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="250px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Excess Liability Insufficient Limits Occurrence" HeaderText="Excess Liability Insufficient Limits Occurrence" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right"  ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1"/>
                                            <asp:BoundField DataField="Excess Liability Insufficient Limits Aggregate" HeaderText="Excess Liability Insufficient Limits Aggregate" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Property (Leased Only) Insufficient Limits Building" HeaderText="Property (Leased Only) Insufficient Limits Building" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Ordinance or Law Included in (Leased Property) Verification"
                                                HeaderText="Ordinance or Law Included in (Leased Property) Verification" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="100% Replacement Cost Included in (leased Property) Verification"
                                                HeaderText="100% Replacement Cost Included in (leased Property) Verification" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Property (Leased Only) Building Limit Accepted" HeaderText="Property (Leased Only) Building Limit Accepted" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Insured Compliant" HeaderText="Insured Compliant" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" FooterStyle-BackColor="#507CD1" />
                                            <asp:BoundField DataField="Business Interruption Included in Property Verification" HeaderText="Business Interruption Included in Property Verification" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" FooterStyle-BackColor="#507CD1" />
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
