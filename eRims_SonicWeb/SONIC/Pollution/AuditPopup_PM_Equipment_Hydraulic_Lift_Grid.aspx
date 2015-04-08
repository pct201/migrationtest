<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Equipment_Hydraulic_Lift_Grid.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Equipment_Hydraulic_Lift_Grid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Hydraulic Lift Grid Audit Trail</title>
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
        if (divheight > (window.screen.availHeight - 465) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 465;
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Equipment_Hydraulic_Lift"
                    runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Equipment Hydraulic Lift</span>
                                </th>--%>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Description</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Oil Type</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Above Ground?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Manufacturer</span>
                                </th>                                
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Number</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">As of Date (Number)</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Installation Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Last Inspection Date</span>
                                </th>                                
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 300px;">Notes</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Status</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; word-wrap:normal;word-break:break-all">Have Any Inground <span id="spnauditRemoved" runat="server">Lifts</span> Been Removed?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; word-wrap:normal;word-break:break-all">Documentation Related To Removed <span id="spnauditRemoval" runat="server">Lift</span></span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Description</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Oil Type</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Above Ground</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Manufacturer</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Installation Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Last Annual Inspection</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Replacement Notes</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px; ">Lift Number Replacement Indicator</span>
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
                <div style="overflow: scroll; width: 300px; height: 310px;" id="divPM_Equipment_Hydraulic_Lift_Grid"
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
                            <%-- <asp:TemplateField HeaderText="PK_PM_Equipment_Hydraulic_Lift">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_PM_Equipment_Hydraulic_Lift" runat="server" Text='<%#Eval("PK_PM_Equipment_Hydraulic_Lift")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Oil_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOil_Type" runat="server" Text='<%#Eval("Oil_Type")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Above_Ground">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAbove_Ground" runat="server" Text='<%#Eval("Above_Ground")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblManufacturer_Name" runat="server" Text='<%#Eval("Manufacturer_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number_Of_Lifts_At_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIs_Number_Of_Lifts_At_Location" runat="server" Text='<%#Eval("Is_Number_Of_Lifts_At_Location")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="As_Of_Date_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAs_Of_Date_Number" runat="server" Text='<%#Eval("As_Of_Date_Number")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("As_Of_Date_Number"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Installation_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallation_Date" runat="server" Text='<%#Eval("Installation_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Installation_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last_Inspection_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Inspection_Date" runat="server" Text='<%#Eval("Last_Inspection_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Last_Inspection_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Notes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                             <asp:TemplateField HeaderText="Status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#CheckStatus(Eval("Status")) %>'  Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Any_Inground_Lifts_Been_Removed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAny_Inground_Lifts_Been_Removed" runat="server" Text='<%#Eval("Any_Inground_Lifts_Been_Removed") != "Y" ? "No":"Yes" %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Documentation_Related_To_Removed_Lifts">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentation_Related_To_Removed_Lifts" runat="server" Text='<%#Eval("Documentation_Related_To_Removed_Lifts") != "Y" ? "No":"Yes"%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Description" runat="server" Text='<%#Eval("Replacement_Description")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Oil_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Oil_Type" runat="server" Text='<%#Eval("Replacement_Oil_Type")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Above_Ground">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Above_Ground" runat="server" Text='<%#Eval("Replacement_Above_Ground") != "Y" ? "No":"Yes"  %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Manufacturer">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Manufacturer" runat="server" Text='<%#Eval("Replacement_Manufacturer")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Installation_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Installation_Date" runat="server" Text='<%#Eval("Replacement_Installation_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Replacement_Installation_Date"))) : ""%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Last_Annual_Inspection">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Last_Annual_Inspection" runat="server" Text='<%#Eval("Replacement_Last_Annual_Inspection")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Replacement_Last_Annual_Inspection"))) : ""%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Replacement_Notes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacement_Notes" runat="server" Text='<%#Eval("Replacement_Notes")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Lift_Number_Replacement_Indicator">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLift_Number_Replacement_Indicator" runat="server" Text='<%#CheckLiftNumberReplacementIndicator(Eval("Lift_Number_Replacement_Indicator"))%>' Width="150px"></asp:Label>
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
