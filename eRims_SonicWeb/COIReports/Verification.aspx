<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="COIReports_Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width: 100%" id="contmain">
<table cellpadding="0" cellspacing="0" width="100%" align="left">
    <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                &nbsp;Verification of Insurance
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="30%" align="center"> 
                    <tr><td colspan="2" class="Spacer" style="height:15px;"></td></tr>
                    <tr>
                        <td width="10%" align="left">
                            Type
                        </td>
                        <td width="2%" align="center">:</td>
                        <td align="left">
                            <asp:DropDownList ID="drpCOIType" runat="server" Width="215px" />
                        </td>
                    </tr>                                        
                    <tr><td class="Spacer" colspan="3" style="height:10px;"></td></tr>                                 
                    <tr>
                        <td colspan="2">&nbsp;</td>    
                        <td align="left">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />
                        </td>
                    </tr>
                    <tr><td colspan="3" class="Spacer" style="height:15px;"></td></tr>
                </table>
            </td>
        </tr>
        <tr><td class="Spacer" style="height:15px;"></td></tr>
        <tr>
            <td align="center">
                <div id="dvGrid" runat="server" style="display:none;">
                   <table cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td align="right">
                                <b><asp:LinkButton ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" /></b>
                            </td>
                        </tr>
                        <tr><td class="Spacer" style="height:15px;"></td></tr>
                        <tr>
                            <td width="100%" align="left">
                                <asp:Panel ID="pnlGrid" runat="server" Width="990px" ScrollBars="Horizontal">
                                    <asp:GridView ID="gvReport" runat="server" Width="1150px" ShowFooter="true" EnableTheming="false" GridLines="none" AutoGenerateColumns="false" 
                                     EmptyDataText="No Record Found" CellPadding="4" CellSpacing="0">  
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                                        <FooterStyle ForeColor="White" Font-Bold="true" />
                                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                        <Columns>
                                                <asp:BoundField DataField="Certificate of Insurance Received" FooterStyle-BackColor="#507CD1" HeaderText="Certificate of Insurance Received" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                                                <asp:BoundField DataField="Region" HeaderText="Region" FooterStyle-BackColor="#507CD1"  HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px"/>
                                                <asp:BoundField DataField="Entity Name" HeaderText="Entity Name" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="Contact Name" HeaderText="Contact Name" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="City" HeaderText="City" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="State" HeaderText="State" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="Zip Code" HeaderText="Zip Code" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="Telephone" HeaderText="Telephone" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="Fax" HeaderText="Fax" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                <asp:BoundField DataField="E-Mail" HeaderText="E-Mail" FooterStyle-BackColor="#507CD1" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr><td class="Spacer" style="height:15px;"></td></tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
</table>
</div>
</asp:Content>

