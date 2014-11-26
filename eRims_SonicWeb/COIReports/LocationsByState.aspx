<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="LocationsByState.aspx.cs" Inherits="COIReports_LocationsByState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                &nbsp;Locations by State
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
                                <asp:Panel ID="pnlGrid" runat="server" Width="990px" ScrollBars="Horizontal">
                                    <asp:GridView ID="gvReport" runat="server" Width="2500px" EnableTheming="false"
                                      ShowFooter="false"  GridLines="none" EmptyDataText="No Record Found" AutoGenerateColumns="false"
                                        OnRowDataBound="gvReport_RowDataBound" CellPadding="4" CellSpacing="0">
                                       <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" VerticalAlign="Top" />
                                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <FooterStyle ForeColor="White" Font-Bold="true" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                        <Columns>
                                            <asp:BoundField DataField="State" HeaderText="State" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-Width="120px"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Width="150px"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Zip" HeaderText="Zip" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Loc. No." HeaderStyle-HorizontalAlign="Left" HeaderText="Loc. No."
                                                ItemStyle-Width="100px" />
                                            <asp:BoundField DataField="County" HeaderText="County" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Tier" HeaderText="Tier" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="DIV" HeaderText="DIV" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="DIS" HeaderText="DIS" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Bldg. Type" HeaderText="Bldg. Type" ItemStyle-Width="100px"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Location Open Date" HeaderText="Location Open Date" ItemStyle-Width="100px"
                                                 DataFormatString="{0:MM/dd/yyyy}" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Date Leased From Landlord" HeaderText="Date Leased From Landlord"
                                                 DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Date Purchased from Landlord" HeaderText="Date Purchased from Landlord"
                                                 DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Location Close Date" HeaderText="Location Close Date"
                                                 DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Insured (Entity Name)" HeaderText="Insured (Entity Name)"
                                                ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Contact" HeaderText="Contact" ItemStyle-Width="150px"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Fax" HeaderText="Fax" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Address1" HeaderText="Address1" ItemStyle-Width="150px"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="City1" HeaderText="City" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="State1" HeaderText="State" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Zip1" HeaderText="Zip" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Insured Active" HeaderText="Insured Active" ItemStyle-Width="100px"
                                                HeaderStyle-HorizontalAlign="Left" />
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
