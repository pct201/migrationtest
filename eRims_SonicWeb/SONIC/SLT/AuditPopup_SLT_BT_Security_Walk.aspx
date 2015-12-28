<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_SLT_BT_Security_Walk.aspx.cs"
    Inherits="SONIC_SLT_AuditPopup_SLTBTSecurityWalk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: SLT Meeting Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 419 + "px";
        divGrid.style.width = window.screen.availWidth - 419 + "px";

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
<body>
    <form id="form1" runat="server">
    <table width="100%" align="left">
        <tr>
            <td align="left">
                <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">
                <a href="javascript:window.close();">Close Window</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="overflow: hidden; width: 675px;" id="divSLTMeetingHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 625px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">BT Security Walk Comp</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">BT Security Walk Comp Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Sales Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Sales Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Sales Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Parts Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Parts Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Parts Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Service Facility Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Service Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Service Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Body Shop Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Body Shop Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Body Shop Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Bus Off Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Bus Off Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Bus Off Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Detail Area Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Detail Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Detail Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Car Wash Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Car Wash Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Car Wash Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Parking Lot Reviewed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Parking Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Parking Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 625px; height: 425px;" id="divSLTMeeting_Grid"
                    runat="server">
                    <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="BT_Security_Walk_Comp">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBTSecurity_Walk_Comp" runat="server" Text='<%# Eval("BT_Security_Walk_Comp")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BTSecurity_Walk_Comp_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBTSecurity_Walk_Comp_Date" runat="server" Text='<%#Eval("BT_Security_Walk_Comp_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("BT_Security_Walk_Comp_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSales_Reviewed" runat="server" Text='<%#Eval("Sales_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSales_Deficiencies" runat="server" Text='<%#Eval("Sales_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSales_Comments" runat="server" Text='<%#Eval("Sales_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parts_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParts_Reviewed" runat="server" Text='<%#Eval("Parts_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parts_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParts_Deficiencies" runat="server" Text='<%#Eval("Parts_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parts_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParts_Comments" runat="server" Text='<%#Eval("Parts_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service_Facility_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblService_Facility_Reviewed" runat="server" Text='<%#Eval("Service_Facility_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblService_Deficiencies" runat="server" Text='<%#Eval("Service_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblService_Comments" runat="server" Text='<%#Eval("Service_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Body_Shop_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBody_Shop_Reviewed" runat="server" Text='<%#Eval("Body_Shop_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Body_Shop_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBody_Shop_Deficiencies" runat="server" Text='<%#Eval("Body_Shop_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Body_Shop_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBody_Shop_Comments" runat="server" Text='<%#Eval("Body_Shop_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bus_Off_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBus_Off_Reviewed" runat="server" Text='<%#Eval("Bus_Off_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bus_Off_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBus_Off_Deficiencies" runat="server" Text='<%#Eval("Bus_Off_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bus_Off_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBus_Off_Comments" runat="server" Text='<%#Eval("Bus_Off_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail_Area_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDetail_Area_Reviewed" runat="server" Text='<%#Eval("Detail_Area_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDetail_Deficiencies" runat="server" Text='<%#Eval("Detail_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDetail_Comments" runat="server" Text='<%#Eval("Detail_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Car_Wash_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCar_Wash_Reviewed" runat="server" Text='<%#Eval("Car_Wash_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Car_Wash_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCar_Wash_Deficiencies" runat="server" Text='<%#Eval("Car_Wash_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Car_Wash_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCar_Wash_Comments" runat="server" Text='<%#Eval("Car_Wash_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parking_Lot_Reviewed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParking_Lot_Reviewed" runat="server" Text='<%#Eval("Parking_Lot_Reviewed")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parking_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParking_Deficiencies" runat="server" Text='<%#Eval("Parking_Deficiencies")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parking_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParking_Comments" runat="server" Text='<%#Eval("Parking_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
