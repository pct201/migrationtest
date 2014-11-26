<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PropertySchedule.aspx.cs" Inherits="COIReports_PropertySchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="heading">
                Property Schedule Testing
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
                                            <asp:LinkButton ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" /></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 15px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="left">
                                        <asp:Panel ID="pnlGrid1" runat="server" Width="980px" ScrollBars="horizontal">
                                            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="true" Width="100%"
                                                SkinID="ReportGrid" EmptyDataText="No records found">
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="SUBSIDIARY" HeaderText="SUBSIDIARY" />
                                                    <asp:BoundField DataField="STATUS OF LOCATION" HeaderText="STATUS OF LOCATION" />
                                                    <asp:BoundField DataField="REST. LOC. NO." HeaderText="REST. LOC. NO." />
                                                    <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                                    <asp:BoundField DataField="ST" HeaderText="ST" />
                                                    <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" />
                                                    <asp:BoundField DataField="ZIP" HeaderText="ZIP" />
                                                    <asp:BoundField DataField="COUNTY" HeaderText="COUNTY" />
                                                    <asp:BoundField DataField="FLOOD ZONE" HeaderText="FLOOD ZONE" />
                                                    <asp:BoundField DataField="TIER 1" HeaderText="TIER 1" />
                                                    <asp:BoundField DataField="Owner" HeaderText="Owner" />
                                                    <asp:BoundField DataField="YEAR BUILT" HeaderText="YEAR BUILT" />
                                                    <asp:BoundField DataField="BLDG TYPE" HeaderText="BLDG TYPE" />
                                                    <asp:BoundField DataField="CONSTR. TYPE" HeaderText="CONSTR. TYPE" />
                                                    <asp:BoundField DataField="SQ. FEET" HeaderText="SQ. FEET" />
                                                    <asp:BoundField DataField="NO. FLOORS" HeaderText="NO. FLOORS" />
                                                    <asp:BoundField DataField="SPRINKLER SYSTEM" HeaderText="SPRINKLER SYSTEM" />
                                                    <asp:BoundField DataField="ALARM SYSTEM" HeaderText="ALARM SYSTEM" />
                                                    <asp:BoundField DataField="CURRENT EST. BLDG. REPLACE. COST" HeaderText="CURRENT EST. BLDG. REPLACE. COST" />
                                                    <asp:BoundField DataField="INVENTORY VALUE" HeaderText="INVENTORY VALUE" />
                                                    <asp:BoundField DataField="ESTIMATED EQUIPMENT REPLACEMENT" HeaderText="ESTIMATED EQUIPMENT REPLACEMENT" />
                                                    <asp:BoundField DataField="BUSINESS INTERRUPTION" HeaderText="BUSINESS INTERRUPTION" />
                                                    <asp:BoundField DataField="EXTRA EXPENSE" HeaderText="EXTRA EXPENSE" />
                                                    <asp:BoundField DataField="LEASEHOLD IMPROVEMENTS" HeaderText="LEASEHOLD IMPROVEMENTS" />
                                                    <asp:BoundField DataField="TOTAL UNIT REPLACEMENT VALUE" HeaderText="TOTAL UNIT REPLACEMENT VALUE" />
                                                    <asp:BoundField DataField="INSURANCE RESPONSIBILITY" HeaderText="INSURANCE RESPONSIBILITY" />
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
</div>    
</asp:Content>
