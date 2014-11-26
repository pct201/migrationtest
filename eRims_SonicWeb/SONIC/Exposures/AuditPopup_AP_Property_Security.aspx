<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_AP_Property_Security.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_AP_Property_Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: AP Property Security Audit Trail</title>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 325 + "px";
            divGrid.style.width = window.screen.availWidth - 325 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 450) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 450;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                    <div style="overflow: hidden; width: 650px;" id="divAP_Property_Security_Audit_Header"
                        runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 16157px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company Address 1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company Address 2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK CCTV Company State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company Contact Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Comapny Contact Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CCTV Company Contact EMail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ACI System</span>  <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Live Monitoring</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Hours Monitored From</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Hours Monitored To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Back</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Car Wash</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Front</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Satellite Parking</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Side</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Zero Lot Line</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ECC Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Exterior Camera Coverage Other Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Body Shop</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Cashier</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Computer Room</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Detail Bays</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Key Box Area</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Parts Receiving Area</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Service Department</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Service Lane</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Showroom</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Smart Safe Office</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ICC Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Interior Camera Coverage Other Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Buglar Alarm System</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Is System Active and Function Properly</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company Address 1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company Address 2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK Burglar Alarm Company State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company Contact Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Comapny Contact Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Company Contact EMail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ZD Collision Center</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ZD Office</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ZD Parts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ZD Sales Showroom</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ZD Sales</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ZD Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Coverage Other Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Burglar Alarm Coverage Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company Address 1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company Address 2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK Guard Company State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company Contact Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Comapny Contact Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Company Contact EMail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Hours Monitored From</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Guard Hours Monitored To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">OffDuty Officer Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">OffDuty Officer Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">OffDuty Officer Hours Monitored From</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">OffDuty Officer Hours Monitored To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC 1st Floor Only</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Business Area</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Cashier</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Computer Room</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Controller Office</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC EnterExit Building</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC F and I Office</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC GM Office</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Multiple Floors</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Parts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Smart Sales Office</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">AC Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Access Control Other Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FG EntranceExit Alarms</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FG EntranceExit Gate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">F Back</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">F Entire Perimeter</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">F Front</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">F Satellite Parking Lot</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">F Side</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">P Back</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">P Entire Perimeter</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">P Front</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">P Satellite Parking Lot</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">P Side</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">SITS Auto Tracks</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">SITS Key Tracks</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">SITS Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Security Inventory Tracking System
                                            Other Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Cap Index Crime Score</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Cap Index Risk Category</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Updated By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Update Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow-y: scroll; width: 16140px; height: 425px;" id="divAP_Property_Security_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvAP_Property_Security_Audit" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_Name" runat="server" Text='<%#Eval("CCTV_Company_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_Address_1" runat="server" Text='<%#Eval("CCTV_Company_Address_1")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_Address_2" runat="server" Text='<%#Eval("CCTV_Company_Address_2")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_City" runat="server" Text='<%#Eval("CCTV_Company_City")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_CCTV_Company_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_CCTV_Company_State" runat="server" Text='<%#Eval("FK_CCTV_Company_State")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_Zip" runat="server" Text='<%#Eval("CCTV_Company_Zip")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_Contact_Name" runat="server" Text='<%#Eval("CCTV_Company_Contact_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Comapny_Contact_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Comapny_Contact_Telephone" runat="server" Text='<%#Eval("CCTV_Comapny_Contact_Telephone")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCTV_Company_Contact_EMail">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCCTV_Company_Contact_EMail" runat="server" Text='<%#Eval("CCTV_Company_Contact_EMail")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cal_Atlantic_System">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCal_Atlantic_System" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Cal_Atlantic_System"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Live_Monitoring">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLive_Monitoring" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Live_Monitoring"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hours_Monitored_From">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHours_Monitored_From" runat="server" Text='<%#Eval("Hours_Monitored_From")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hours_Monitored_To">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHours_Monitored_To" runat="server" Text='<%#Eval("Hours_Monitored_To")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Back">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Back" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Back"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Car_Wash">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Car_Wash" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Car_Wash"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Front">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Front" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Front"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Satellite_Parking">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Satellite_Parking" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Satellite_Parking"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Side">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Side" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Side"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Zero_Lot_Line">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Zero_Lot_Line" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Zero_Lot_Line"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ECC_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblECC_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ECC_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exterior_Camera_Coverage_Other_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExterior_Camera_Coverage_Other_Description" runat="server" Text='<%#Eval("Exterior_Camera_Coverage_Other_Description")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Body_Shop">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Body_Shop" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Body_Shop"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Cashier">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Cashier" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Cashier"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Computer_Room">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Computer_Room" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Computer_Room"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Detail_Bays">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Detail_Bays" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Detail_Bays"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Key_Box_Area">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Key_Box_Area" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Key_Box_Area"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Parts_Receiving_Area">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Parts_Receiving_Area" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Parts_Receiving_Area"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Service_Department">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Service_Department" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Service_Department"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Service_Lane">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Service_Lane" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Service_Lane"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Showroom">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Showroom" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Showroom"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Smart_Safe_Office">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Smart_Safe_Office" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Smart_Safe_Office"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ICC_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblICC_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ICC_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interior_Camera_Coverage_Other_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInterior_Camera_Coverage_Other_Description" runat="server" Text='<%#Eval("Interior_Camera_Coverage_Other_Description")%>'
                                            Width="180px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Buglar_Alarm_System">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuglar_Alarm_System" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Buglar_Alarm_System"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Is_System_Active_and_Function_Properly">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIs_System_Active_and_Function_Properly" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Is_System_Active_and_Function_Properly"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_Name" runat="server" Text='<%#Eval("Burglar_Alarm_Company_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_Address_1" runat="server" Text='<%#Eval("Burglar_Alarm_Company_Address_1")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_Address_2" runat="server" Text='<%#Eval("Burglar_Alarm_Company_Address_2")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_City" runat="server" Text='<%#Eval("Burglar_Alarm_Company_City")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Burglar_Alarm_Company_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Burglar_Alarm_Company_State" runat="server" Text='<%#Eval("FK_Burglar_Alarm_Company_State")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_Zip" runat="server" Text='<%#Eval("Burglar_Alarm_Company_Zip")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_Contact_Name" runat="server" Text='<%#Eval("Burglar_Alarm_Company_Contact_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Comapny_Contact_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Comapny_Contact_Telephone" runat="server" Text='<%#Eval("Burglar_Alarm_Comapny_Contact_Telephone")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Company_Contact_EMail">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Company_Contact_EMail" runat="server" Text='<%#Eval("Burglar_Alarm_Company_Contact_EMail")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZD_Collision_Center">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZD_Collision_Center" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ZD_Collision_Center"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZD_Office">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZD_Office" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ZD_Office"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZD_Parts">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZD_Parts" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ZD_Parts"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZD_Sales_Showroom">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZD_Sales_Showroom" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ZD_Sales_Showroom"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZD_Sales">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZD_Sales" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ZD_Sales"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZD_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblZD_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ZD_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Coverage_Other_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Coverage_Other_Description" runat="server" Text='<%#Eval("Burglar_Alarm_Coverage_Other_Description")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Burglar_Alarm_Coverage_Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurglar_Alarm_Coverage_Comments" runat="server" Text='<%#Eval("Burglar_Alarm_Coverage_Comments")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_Name" runat="server" Text='<%#Eval("Guard_Company_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_Address_1" runat="server" Text='<%#Eval("Guard_Company_Address_1")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_Address_2" runat="server" Text='<%#Eval("Guard_Company_Address_2")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_City" runat="server" Text='<%#Eval("Guard_Company_City")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Guard_Company_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Guard_Company_State" runat="server" Text='<%#Eval("FK_Guard_Company_State")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_Zip" runat="server" Text='<%#Eval("Guard_Company_Zip")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_Contact_Name" runat="server" Text='<%#Eval("Guard_Company_Contact_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Comapny_Contact_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Comapny_Contact_Telephone" runat="server" Text='<%#Eval("Guard_Comapny_Contact_Telephone")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Company_Contact_EMail">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Company_Contact_EMail" runat="server" Text='<%#Eval("Guard_Company_Contact_EMail")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Hours_Monitored_From">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Hours_Monitored_From" runat="server" Text='<%#Eval("Guard_Hours_Monitored_From")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guard_Hours_Monitored_To">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard_Hours_Monitored_To" runat="server" Text='<%#Eval("Guard_Hours_Monitored_To")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OffDuty_Officer_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffDuty_Officer_Name" runat="server" Text='<%#Eval("OffDuty_Officer_Name")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OffDuty_Officer_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffDuty_Officer_Telephone" runat="server" Text='<%#Eval("OffDuty_Officer_Telephone")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OffDuty_Officer_Hours_Monitored_From">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffDuty_Officer_Hours_Monitored_From" runat="server" Text='<%#Eval("OffDuty_Officer_Hours_Monitored_From")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OffDuty_Officer_Hours_Monitored_To">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffDuty_Officer_Hours_Monitored_To" runat="server" Text='<%#Eval("OffDuty_Officer_Hours_Monitored_To")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_1st_Floor_Only">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_1st_Floor_Only" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_1st_Floor_Only"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Business_Area">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Business_Area" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Business_Area"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Cashier">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Cashier" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Cashier"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Computer_Room">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Computer_Room" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Computer_Room"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Controller_Office">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Controller_Office" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Controller_Office"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_EnterExit_Building">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_EnterExit_Building" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_EnterExit_Building"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_F_and_I_Office">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_F_and_I_Office" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_F_and_I_Office"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_GM_Office">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_GM_Office" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_GM_Office"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Multiple_Floors">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Multiple_Floors" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Multiple_Floors"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Parts">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Parts" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Parts"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Smart_Sales_Office">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Smart_Sales_Office" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Smart_Sales_Office"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AC_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAC_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("AC_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Access_Control_Other_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccess_Control_Other_Description" runat="server" Text='<%#Eval("Access_Control_Other_Description")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FG_EntranceExit_Alarms">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFG_EntranceExit_Alarms" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("FG_EntranceExit_Alarms"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FG_EntranceExit_Gate">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFG_EntranceExit_Gate" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("FG_EntranceExit_Gate"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F_Back">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblF_Back" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("F_Back"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F_Entire_Perimeter">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblF_Entire_Perimeter" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("F_Entire_Perimeter"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F_Front">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblF_Front" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("F_Front"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F_Satellite_Parking_Lot">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblF_Satellite_Parking_Lot" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("F_Satellite_Parking_Lot"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F_Side">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblF_Side" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("F_Side"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P_Back">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP_Back" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("P_Back"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P_Entire_Perimeter">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP_Entire_Perimeter" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("P_Entire_Perimeter"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P_Front">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP_Front" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("P_Front"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P_Satellite_Parking_Lot">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP_Satellite_Parking_Lot" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("P_Satellite_Parking_Lot"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P_Side">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP_Side" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("P_Side"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SITS_Auto_Tracks">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSITS_Auto_Tracks" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("SITS_Auto_Tracks"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SITS_Key_Tracks">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSITS_Key_Tracks" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("SITS_Key_Tracks"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SITS_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSITS_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("SITS_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Security_Inventory_Tracking_System_Other_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecurity_Inventory_Tracking_System_Other_Description" runat="server"
                                            Text='<%#Eval("Security_Inventory_Tracking_System_Other_Description")%>' Width="180px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Cap_Index_Crime_Score">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCap_Index_Crime_Score" runat="server" Text='<%#Eval("Cap_Index_Crime_Score")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cap_Index_Risk_Cateogory">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCap_Index_Risk_Cateogory" runat="server" Text='<%#Eval("Cap_Index_Risk_Cateogory")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="160px"></asp:Label>
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
    </div>
    </form>
</body>
</html>
