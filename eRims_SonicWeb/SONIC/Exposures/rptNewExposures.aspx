<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptNewExposures.aspx.cs" Inherits="SONIC_Exposures_rptNewExposures" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vsErrorGroup" />

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 350;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>

    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
                Third Party Owned and Sonic Leased, Subleased to Third Party and Sonic Owned with Third Party Lease
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td width="20%">
                &nbsp;
            </td>
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Region
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="280px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="left" valign="top" width="28%">
                            Market
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                                AutoPostBack="false" Width="280px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Location Status
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="ddlStatus" SkinID="dropGen" Width="280px" Rows="3"
                                SelectionMode="Multiple">
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server"
        id="tblReport" visible="false">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton Visible="false" ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
            </td>
        </tr>
        <tr id="trGrid" runat="server">
            <td align="left">
                <div style="overflow: hidden; width: 997px;" id="dvHeader" runat="server">
                    <table width="4320px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                        id="tblHeader" runat="server">
                        <tr class="HeaderStyle">
                            <td align="left" colspan="2">
                                Sonic Automotive
                            </td>
                            <td align="center" colspan="22">
                            Third Party Owned and Sonic Leased, Subleased to Third Party and Sonic Owned with Third Party Lease
                            </td>
                            <td align="right" colspan="3">
                                <%=DateTime.Now.ToString()  %>
                            </td>
                        </tr>
                        <tr align="left" valign="bottom" class="HeaderStyle">
                            <td width="150px">                                
                                Region
                            </td>
                            <td width="150px">
                                Sonic Location D/B/A
                            </td>
                            <td width="150px">
                                Building Number
                            </td>
                            <td width="160px">
                                Building Street Address 1
                            </td>
                            <td width="160px">
                                Building Street Address 2
                            </td>
                            <td width="150px">
                                Building City
                            </td>
                            <td width="150px">
                                Building State
                            </td>
                            <td width="150px">
                                Building Zip Code
                            </td>
                            <td width="100px">
                                Status
                            </td>
                            <td width="200px">
                                Ownership
                            </td>
                            <td width="150px">
                                Landlord Name
                            </td>
                            <td width="150px">
                                Landlord Legal Entity
                            </td>
                            <td width="150px">
                                Address 1
                            </td>
                            <td width="150px">
                                Address 2
                            </td>
                            <td width="150px">
                                City
                            </td>
                            <td width="150px">
                                State
                            </td>
                            <td width="150px">
                                Zip Code
                            </td>
                            <td width="150px">
                                Lease ID
                            </td>
                            <td width="150px">
                                Commencement Date
                            </td>
                            <td width="150px">
                                Expiration Date
                            </td>
                            <td width="150px">
                                Sub-Lease Name
                            </td>
                            <td width="150px">
                                Sub-Lease Landlord
                            </td>
                            <td width="150px">
                                Address 1
                            </td>
                            <td width="150px">
                                Address 2
                            </td>
                            <td width="150px">
                                City
                            </td>
                            <td width="150px">
                                State
                            </td>
                            <td width="167px">
                                Zip
                            </td>
                            
                        </tr>
                    </table>
                </div>
                <div style="overflow: scroll; width: 997px; height: 398px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvDescription" EnableTheming="false" DataKeyNames="Region" runat="server"
                        AutoGenerateColumns="false" Width="100%" HorizontalAlign="Left" GridLines="None"
                        ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found !" CellPadding="0"
                        CellSpacing="0">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="4320px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;
                                        display: none;" id="tblHeader" runat="server">
                                        <tr class="HeaderStyle">
                                            <td align="left" colspan="2">
                                                Sonic Automotive
                                            </td>
                                            <td align="center" colspan="22">
                                                Third Party Owned and Sonic Leased and Subleased to Third Party
                                            </td>
                                            <td align="right" colspan="3">
                                                <%=DateTime.Now.ToString()  %>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="bottom">
                                            <td width="150px">
                                                <!-- LOCATION/ADDRESS INFORMATION  -->
                                                Region
                                            </td>
                                            <td width="150px">
                                                Sonic Location D/B/A
                                            </td>
                                            <td width="150px">
                                                Building Number
                                            </td>
                                            <td width="160px">
                                                Building Street Address 1
                                            </td>
                                            <td width="160px">
                                                Building Street Address 2
                                            </td>
                                            <td width="150px">
                                                Building City
                                            </td>
                                            <td width="150px">
                                                Building State
                                            </td>
                                            <td width="150px">
                                                Building Zip Code
                                            </td>
                                            <td width="100px">
                                                Status
                                            </td>
                                            <td width="200px">
                                                Ownership
                                            </td>
                                            <td width="150px">
                                                Landlord Name
                                            </td>
                                            <td width="150px">
                                                Landlord Legal Entity
                                            </td>
                                            <td width="150px">
                                                Address 1
                                            </td>
                                            <td width="150px">
                                                Address 2
                                            </td>
                                            <td width="150px">
                                                City
                                            </td>
                                            <td width="150px">
                                                State
                                            </td>
                                            <td width="150px">
                                                Zip Code
                                            </td>
                                            <td width="150px">
                                                Lease ID
                                            </td>
                                            <td width="150px">
                                                Commencement Date
                                            </td>
                                            <td width="150px">
                                                <!-- OCCUPANCY  -->
                                                Expiration Date
                                            </td>
                                            <td width="150px">
                                                Sub-Lease Name
                                            </td>
                                            <td width="150px">
                                                Sub-Lease Landlord
                                            </td>
                                            <td width="150px">
                                                Address 1
                                            </td>
                                            <td width="150px">
                                                Address 2
                                            </td>
                                            <td width="150px">
                                                City
                                            </td>
                                            <td width="150px">
                                                State
                                            </td>
                                            <td width="150px">
                                                Zip
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="4320px" cellpadding="4" cellspacing="0" border="0" id="tblHeader" runat="server">
                                        <tr align="left" valign="top">
                                            <td width="150px">
                                                <%# Eval("Region") %>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("dba")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("BUILDING_NUMBER")%>
                                            </td>
                                            <td width="160px">
                                                <%# Eval("Building_Address_1")%>
                                            </td>
                                            <td width="160px">
                                                <%# Eval("Building_Address_2")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("Building_City")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("Building_State")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("Building_Zip")%>
                                            </td>
                                            <td width="100px">
                                                <%# Eval("LOCATION_STATUS")%>
                                            </td>
                                            <td width="200px">
                                                <%# Eval("Ownership") %>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LANDLORD_NAME") %>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LANDLORD_LEGAL_ENTITY")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LANDLORD_ADDRESS_1") %>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LANDLORD_ADDRESS_2")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LANDLORD_CITY")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("Landlord_State") %>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LANDLORD_ZIP")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("LEASE_ID")%>
                                            </td>
                                            <td width="150px">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("COMMENCEMENT_DATE"))%>
                                            </td>
                                            <td width="150px">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("EXPIRATION_DATE"))%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("SUBLEASE_NAME")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("SUBLANDLORD")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("SUBLEASE_ADDRESS_1")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("SUBLEASE_ADDRESS_2")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("SUBLEASE_CITY")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("Sublease_State")%>
                                            </td>
                                            <td width="150px">
                                                <%# Eval("SUBLEASE_ZIP")%>
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
        <tr id="trMessage" runat="server" visible="false">
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td class="headerrow">
                            No Record Found !
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
                <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>
    </table>
</asp:Content>
