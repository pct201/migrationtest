<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptRM_Dealership_Facility_Specs.aspx.cs" Inherits="SONIC_Exposures_rptRM_Dealership_Facility_Specs" %>

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
                RM Dealership and Facility Specs
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
                        <td align="left" valign="top">
                            Ownership
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="lstOwnership" SkinID="dropGen" Width="280px" Rows="3"
                                SelectionMode="Multiple">
                                <asp:ListItem Text="Sonic Owned with Internal Lease" Value="Internal"></asp:ListItem>
                                <asp:ListItem Text="Sonic Owned with Third Party Lease" Value="ThirdParty"></asp:ListItem>
                                <asp:ListItem Text="Sonic Owned" Value="Owned"></asp:ListItem>
                                <asp:ListItem Text="Third Party Owned and Sonic Leased" Value="ThirdPartyLease"></asp:ListItem>
                                <asp:ListItem Text="Third Party Owned and Sonic Leased and Subleased to Third Party"
                                    Value="ThirdPartySublease"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Brand
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="lstBrand" SkinID="dropGen" Width="280px" Rows="5"
                                SelectionMode="Multiple"></asp:ListBox>
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
            <td align="right" width="100%" valign="top" style="height: 25px">
                <asp:LinkButton Visible="false" ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
                <div id="dvGridHeader" runat="server" width="997px" style="overflow: hidden;">
                    <table width="997px" cellpadding="2" cellspacing="0" border="0" style="font-weight: bold;"
                        id="tblHeader" runat="server">
                        <tr class="HeaderStyle">
                            <td align="left">
                                Sonic Automotive
                            </td>
                            <td align="center">
                                RM Dealership and Facility Specs
                            </td>
                            <td align="right">
                                <%=DateTime.Now.ToString()  %>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr id="trGrid" runat="server">
            <td align="left">
                <div id="dvGrid" runat="server" width="997px" style="overflow-x: scroll">
                    <asp:GridView ID="gvDescription" EnableTheming="false" DataKeyNames="Region" runat="server"
                        AutoGenerateColumns="false" Width="2550px" HorizontalAlign="Left" GridLines="None"
                        ShowHeader="true" ShowFooter="false" EmptyDataText="No Record Found !" CellPadding="4">
                        <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField HeaderText="Region" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%#Eval("Region") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location D/B/A" ItemStyle-Width="180px">
                                <ItemTemplate>
                                    <%#Eval("DBA")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic Location Number" ItemStyle-Width="180px">
                                <ItemTemplate>
                                    <%#Eval("Sonic_Location_Code")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building Number" ItemStyle-Width="180px">
                                <ItemTemplate>
                                    <%#Eval("BUILDING_NUMBER")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <%#Eval("Address")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Square Footage" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <%# Eval("Square_Footage")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Occupancy" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#Eval("Occupancy").ToString().TrimStart(',').TrimEnd(',')%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Brand" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#Eval("Brand")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acreage" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%# string.Format("{0:N3}", Eval("Acreage"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number of Parking Spaces" ItemStyle-Width="180px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#string.Format("{0:N0}", Eval("Number_of_Parking_Spaces"))%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Number Of Bays" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#string.Format("{0:N0}", Eval("Number_Of_Bays"))%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Number Of Lifts" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#string.Format("{0:N0}", Eval("Number_Of_Lifts_Sc"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number Of Paint Booths" ItemStyle-Width="180px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#string.Format("{0:N0}", Eval("Number_Of_Paint_Booths"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            <asp:TemplateField HeaderText="Number of Prep Areas" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#string.Format("{0:N0}", Eval("Number_of_Prep_Areas"))%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Number of Car Wash Stations" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#string.Format("{0:N0}", Eval("Number_of_Car_Wash_Stations"))%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Ownership" ItemStyle-Width="450px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#Eval("Ownership")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Location Status" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                                    <%#Eval("LOCATION_STATUS")%>
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
