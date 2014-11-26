<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Equipment_Prep_Station.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Equipment_Prep_Station" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Prep Station Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 515 + "px";
        divGrid.style.width = window.screen.availWidth - 515 + "px";

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 495) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 495;
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Equipment_Spray_Booth" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Equipment Paint Booth</span>
                                </th>--%>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Description</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Manufacturer</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Installation Date</span>
                                </th>                                
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Configured for Water Borne Application?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Direct or Indirect Burners?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">BTU Rating</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Height In Feet</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Width In Feet</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Depth In Feet</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Filter System</span>
                                </th>
                                 <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Manual for Prep Station location in 6H Binder?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Capture Efficiency</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Control Efficiency</span>
                                </th>
                                 <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Capture Efficiency as of Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Control Efficiency as of Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Stack Height Above Grade in Feet</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Exit Flow Rate in Cubic Feet Per Minute</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Exit Temperature (Low) Degrees Farenheight</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Exit Temperature (High) Degrees Farenheight</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 300px;">Notes</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Updated By</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 320px;" id="divPM_Equipment_Spray_Booth_Grid"
                    runat="server">
                    <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="PK_PM_Equipment_Spray_Booth">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_PM_Equipment_Spray_Booth" runat="server" Text='<%#Eval("PK_PM_Equipment_Spray_Booth")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblManufacturer_Name" runat="server" Text='<%#Eval("Manufacturer_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Installation_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallation_Date" runat="server" Text='<%#Eval("Installation_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Installation_Date"))) : ""%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Configured_For_Water_Borne_Application">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblConfigured_For_Water_Borne_Application" runat="server" Text='<%#Eval("Configured_For_Water_Borne_Application")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direct_Indirect_Burners">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDirect_Indirect_Burners" runat="server" Text='<%#Eval("Direct_Indirect_Burners")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BTU_Rating">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBTU_Rating" runat="server" Text='<%#string.Format("{0:N2}", Eval("BTU_Rating"))%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Height_In_Feet">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHeight_In_Feet" runat="server" Text='<%#string.Format("{0:N2}", Eval("Height_In_Feet"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width_In_Feet">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWidth_In_Feet" runat="server" Text='<%#string.Format("{0:N2}", Eval("Width_In_Feet"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Depth_In_Feet">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDepth_In_Feet" runat="server" Text='<%#string.Format("{0:N2}", Eval("Depth_In_Feet"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Filter_System">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFilter_System" runat="server" Text='<%#Eval("Filter_System")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Manual_6H_Binder">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblManual_6H_Binder" runat="server" Text='<%#Eval("Manual_6H_Binder")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Capture_Efficiency">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCapture_Efficiency" runat="server" Text='<%#Eval("Capture_Efficiency")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Control_Efficiency">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblControl_Efficiency" runat="server" Text='<%#Eval("Control_Efficiency")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Capture_Efficieicny_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCapture_Efficieicny_Date" runat="server" Text='<%#Eval("Capture_Efficieicny_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Capture_Efficieicny_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Control_Efficiency_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblControl_Efficiency_Date" runat="server" Text='<%#Eval("Control_Efficiency_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Control_Efficiency_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stack_Height_In_Feet">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStack_Height_In_Feet" runat="server" Text='<%#string.Format("{0:N2}", Eval("Stack_Height_In_Feet"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exit_Flow_Rate_CFM">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblExit_Flow_Rate_CFM" runat="server" Text='<%#string.Format("{0:N2}", Eval("Exit_Flow_Rate_CFM"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exit_Temperature_Low">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblExit_Temperature_Low" runat="server" Text='<%#Eval("Exit_Temperature_Low")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exit_Temperature_High">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblExit_Temperature_High" runat="server" Text='<%#string.Format("{0:N2}", Eval("Exit_Temperature_High"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="300px" CssClass="TextClip"></asp:Label>
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
                                    <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
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
