<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Chemical_Inventory.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Chemical_Inventory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Chemical Inventory Audit Trail</title>
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Permits_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>                                
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Compliance Reporting</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Chemical Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">CAS Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Pure Mixture</span>
                                </th>
                                <th class="cols" >
                                    <span style="display: inline-block; width: 300px;">Mixture Components</span>
                                </th>
                                <th class="cols" >
                                    <span style="display: inline-block; width: 100px;">Physical State</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Maximum Amount On-Site In Pounds</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Daily Maximum Amount On-Site in Pounds</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Average Amount On-Site in Pounds</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 110px;">Daily Average Amount On-Site in Pounds</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Storage Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Storage Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">State Local Fees</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Method</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Initial 6H Notification Submitted</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">6H Compliance Verification Submitted</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Notifications 6H Changes Reports Submitted</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Chemical Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                                
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Permits_Grid"
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
                            <%--<asp:TemplateField HeaderText="FK_PM_Compliance_Reporting">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_Compliance_Reporting" runat="server" Text='<%#Eval("FK_PM_Compliance_Reporting")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="FK_LU_Chemical_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Chemical_Type" runat="server" Text='<%#Eval("Chemical_Type")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CAS_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCAS_Number" runat="server" Text='<%#Eval("CAS_Number")%>' Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pure_Mixture">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPure_Mixture" runat="server" Text='<%#(Eval("Pure_Mixture").ToString() == "" ? "" : (Eval("Pure_Mixture").ToString() == "M" ? "Mixture":"Pure"))%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mixture_Components">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMixture_Components" runat="server" Text='<%#Eval("Mixture_Components")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Physical_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPhysical_State" runat="server" Text='<%#(Eval("Physical_State").ToString() == "" ? "" : (Eval("Physical_State").ToString() == "S" ? "Solid" : (Eval("Physical_State").ToString() == "L" ? "Liquid" : "Gas")))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Maximum_Pounds_On_Site">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblMaximum_Pounds_On_Site" runat="server" Text='<%# string.Format("{0:N2}", Eval("Maximum_Pounds_On_Site"))%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Daily_maximum_Pounds_On_Site">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblDaily_maximum_Pounds_On_Site" runat="server" Text='<%#string.Format("{0:N2}", Eval("Daily_maximum_Pounds_On_Site"))%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Average_Pounds_On_Site">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblAverage_Pounds_On_Site" runat="server" Text='<%#string.Format("{0:N2}", Eval("Average_Pounds_On_Site"))%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Daily_Average_Pounds_On_Site">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblDaily_Average_Pounds_On_Site" runat="server" Text='<%#string.Format("{0:N2}", Eval("Daily_Average_Pounds_On_Site"))%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Storage_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Storage_Type" runat="server" Text='<%#Eval("Storage_Type")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Storage_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Storage_Location" runat="server" Text='<%#Eval("Storage_Location")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State_Local_Fees">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right"/>
                                <ItemTemplate>
                                    <asp:Label ID="lblState_Local_Fees" runat="server" Text='<%#string.Format("{0:C2}", Eval("State_Local_Fees"))%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Method">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMethod" runat="server" Text='<%#Eval("Method")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Initial_6H_Notification_Submitted">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInitial_6H_Notification_Submitted" runat="server" Text='<%#(Eval("Initial_6H_Notification_Submitted").ToString() == "N" ? "No" : Eval("Initial_6H_Notification_Submitted").ToString() == "R"? "Not Required": "Yes")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SixH_Compliance_Verification_Submitted">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSixH_Compliance_Verification_Submitted" runat="server" Text='<%#(Eval("SixH_Compliance_Verification_Submitted").ToString() == "N" ? "No" : Eval("SixH_Compliance_Verification_Submitted").ToString()=="R"?"Not Required": "Yes")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notifications_6H_Changes_Reports_Submitted">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNotifications_6H_Changes_Reports_Submitted" runat="server" Text='<%#(Eval("Notifications_6H_Changes_Reports_Submitted").ToString() == "N" ? "No" : "Yes")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chemical_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblChemical_Name" runat="server" Text='<%#Eval("Chemical_Name")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By1")%>' Width="100px"></asp:Label>
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
