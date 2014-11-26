<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rpt_d_b_a_MainReport.aspx.cs" Inherits="SONIC_Exposures_rpt_d_b_a_MainReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                d/b/a Main Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="80%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                    border="0">
                    <tr valign="top" align="left">
                        <td style="width: 15%;">
                            Region
                        </td>
                        <td align="right" style="width: 2%;">
                            :
                        </td>
                        <td style="width: 24%;">
                            <asp:DropDownList ID="ddlRegion" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 5%;" rowspan="3">
                        </td>
                        <td style="width: 10%;">
                            State
                        </td>
                        <td align="right" style="width: 2%;">
                            :
                        </td>
                        <td style="width: 24%;">
                            <asp:DropDownList ID="ddlState" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Sonic Location Code
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSonicLocationCode" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            RLCM
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRLCM" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Show on Dashboard
                        </td>
                        <td align="right" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:RadioButtonList ID="rblShowOnDashboard" runat="server" SkinID="YesNoType">
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            Active
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblActive" runat="server" SkinID="YesNoType">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <table width="77%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" Text="Show Report" CausesValidation="true"
                                OnClick="btnShowReport_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear Criteria" CausesValidation="false"
                                OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="95%" align="center">
                    <tr>
                        <td width="100%" align="left">
                            <div id="dvGrid" runat="server" visible="false">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td align="right">
                                            <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 15px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden;
                                                text-align: left; width: 100%;">
                                                <asp:GridView ID="gvMainReport" runat="server" AutoGenerateColumns="false" ShowFooter="false"
                                                    Width="100%" EnableTheming="false" HorizontalAlign="Left" CellPadding="0" CellSpacing="0"
                                                    GridLines="None" CssClass="GridClass" EmptyDataText="No Record Found">
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="18px" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold;" id="tblHeader"
                                                                    runat="server">
                                                                    <tr>
                                                                        <td width="5%" colspan="5" align="left">
                                                                            Sonic Automotive
                                                                        </td>
                                                                        <td width="5%" colspan="5" align="center">
                                                                            d/b/a Main Report
                                                                        </td>
                                                                        <td width="5%" colspan="6" align="right">
                                                                           Date: <%=DateTime.Now.ToString()  %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="5%" align="left">
                                                                            Region
                                                                        </td>
                                                                        <td width="7%" align="left">
                                                                            Sonic Location Code
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            ADP DMS
                                                                        </td>
                                                                        <td width="10%" align="left">
                                                                            DBA
                                                                        </td>
                                                                        <td width="10%" align="left">
                                                                            Legal Entity
                                                                        </td>
                                                                        <td width="10%" align="left">
                                                                            Address 1
                                                                        </td>
                                                                        <td width="10%" align="left">
                                                                            Address 2
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            City
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            State
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            Zip Code
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            County
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            Dealership Telephone
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            Year of Acquisition
                                                                        </td>
                                                                        <td width="4%" align="left">
                                                                            Active
                                                                        </td>
                                                                        <td width="4%" align="left">
                                                                            Show On Dashboard
                                                                        </td>
                                                                        <td width="5%" align="left">
                                                                            RLCM
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%" cellpadding="4" cellspacing="0" id="tblDetails" runat="server">
                                                                    <tr>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%# Eval("Region")%>
                                                                        </td>
                                                                        <td align="left" style="width: 7%" valign="top">
                                                                            <%#Eval("Sonic_Location_Code")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%# Eval("ADP_DMS")%>
                                                                        </td>
                                                                        <td align="left" style="width: 10%" valign="top">
                                                                            <%#Eval("dba")%>
                                                                        </td>
                                                                        <td align="left" style="width: 10%" valign="top">
                                                                            <%# Eval("legal_entity")%>
                                                                        </td>
                                                                        <td align="left" style="width: 10%" valign="top">
                                                                            <%# Eval("Address_1")%>
                                                                        </td>
                                                                        <td align="left" style="width: 10%" valign="top">
                                                                            <%# Eval("Address_2")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%# Eval("City")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%#Eval("FLD_state")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%#Eval("Zip_Code")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%#Eval("County")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%#Eval("Dealership_Telephone")%>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%#Eval("Year_of_Acquisition")%>
                                                                        </td>
                                                                        <td align="left" style="width: 4%" valign="top">
                                                                            <%# (Eval("Active").ToString()=="Y") ? "Yes" : "No"%>
                                                                        </td>
                                                                        <td align="left" style="width: 4%" valign="top">
                                                                            <%# (Eval("Show_On_Dashboard").ToString()=="Y") ? "Yes" : "No" %>
                                                                        </td>
                                                                        <td align="left" style="width: 5%" valign="top">
                                                                            <%#Eval("Employee_Name")%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
