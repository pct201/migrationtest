<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Audit_Popup_AP_DPD_FROIs.aspx.cs"
    Inherits="Audit_Popup_AP_DPD_FROIs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asset Protection Module – DPD FROIs</title>
</head>
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
                <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 7047px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px">Incident Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Cause of Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">VIN#</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">3rd Party Vendor Related Theft</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Access Control Failures</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Breaking and Entering</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Burglar Alarm Failure</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Camera Dead Spot</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">CCTV Monitoring Failure (Equipment)</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">CCTV Monitoring Failure by Operator</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Design weakness – Property Protection</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px">Environmental Obstruction/Condition
                                        – Camera</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Failure to Report/Late Report</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px">Key Swap</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Lighting Deficiencies</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Lock Box Not Properly Secured</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px;">Negligence Lack of key Control Program
                                        Unattended Keys</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Non Permissible User of Taking Vehicle</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Power Outage</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Security Guard Failure</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Stolen Id</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Theft By Deception</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Unauthorized Building Entry Forcible</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Unauthorized Building Entry Unlocked</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Unauthorized Vehicle Entry Forcible</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Unauthorized Vehicle Entry Unlocked</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Vehicle Taken By Tow Truck</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Weather Related Damage and or Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Other Describe</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px;">Investigation Finding – Other Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">What is the incident’s root cause?
                                    </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px;">How can the incident be prevented
                                        from happening again?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px;">Who has been tasked with implementing
                                        practices/procedures to prevent re-occurrence?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Target Date of Completion</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Status Due On</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px;">Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Financial Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Recovery</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Item Status</span>
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
                <div style="overflow: scroll; width: 7030px; height: 395px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvAP_DPD_FROIs" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incident Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIncident_Number" runat="server" Text='<%#Eval("DPD_FR_Number")%>'
                                        Width="130px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cause of Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCause_of_Loss" runat="server" Text='<%#Eval("Cause_Of_Loss")%>'
                                        Width="150px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VIN#">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVIN" runat="server" Text='<%#Eval("VIN")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Third_Party_Vendor_Related_Theft">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblThird_Party_Vendor_Related_Theft" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Third_Party_Vendor_Related_Theft"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Access_Control_Failures">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAccess_Control_Failures" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Access_Control_Failures"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Breaking_And_Entering">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBreaking_And_Entering" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Breaking_And_Entering"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Burglar_Alarm_Failure">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBurglar_Alarm_Failure" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Burglar_Alarm_Failure"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Dead_Spot">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCamera_Dead_Spot" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Camera_Dead_Spot"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CCTV_Monitoring_Failure">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCCTV_Monitoring_Failure" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("CCTV_Monitoring_Failure"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CCTV_Monitoring_Failure_By_Operator">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCCTV_Monitoring_Failure_By_Operator" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("CCTV_Monitoring_Failure_By_Operator"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Design_Weakness_Property_Protection">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDesign_Weakness_Property_Protection" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Design_Weakness_Property_Protection"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Environmental_Obstruction_and_or_Condition_Camera">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEnvironmental_Obstruction_and_or_Condition_Camera" runat="server"
                                        Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Environmental_Obstruction_and_or_Condition_Camera"))%>'
                                        Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Failure_to_Report_and_or_Late_Report">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFailure_to_Report_and_or_Late_Report" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Failure_to_Report_and_or_Late_Report"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Key_Swap">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblKey_Swap" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Key_Swap"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lighting_Deficiencies">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLighting_Deficiencies" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Lighting_Deficiencies"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lock_Box_Not_Properly_Secured">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLock_Box_Not_Properly_Secured" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Lock_Box_Not_Properly_Secured"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Negligence_Lack_of_key_Control_Program_Unattended_Keys">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNegligence_Lack_of_key_Control_Program_Unattended_Keys" runat="server"
                                        Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Negligence_Lack_of_key_Control_Program_Unattended_Keys"))%>'
                                        Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Non_Permissible_User_of_Taking_Vehicle">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNon_Permissible_User_of_Taking_Vehicle" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Non_Permissible_User_of_Taking_Vehicle"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Power_Outage">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPower_Outage" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Power_Outage"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Security_Guard_Failure">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSecurity_Guard_Failure" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Security_Guard_Failure"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stolen_Id">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStolen_Id" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Stolen_Id"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Theft_By_Deception">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTheft_By_Deception" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Theft_By_Deception"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unauthorized_Building_Entry_Forcible">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUnauthorized_Building_Entry_Forcible" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Unauthorized_Building_Entry_Forcible"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unauthorized_Building_Entry_Unlocked">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUnauthorized_Building_Entry_Unlocked" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Unauthorized_Building_Entry_Unlocked"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unauthorized_Vehicle_Entry_Forcible">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUnauthorized_Vehicle_Entry_Forcible" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Unauthorized_Vehicle_Entry_Forcible"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unauthorized_Vehicle_Entry_Unlocked">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUnauthorized_Vehicle_Entry_Unlocked" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Unauthorized_Vehicle_Entry_Unlocked"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vehicle_Taken_By_Tow_Truck">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVehicle_Taken_By_Tow_Truck" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Vehicle_Taken_By_Tow_Truck"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Weather_Related_Damage_and_or_Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWeather_Related_Damage_and_or_Loss" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Weather_Related_Damage_and_or_Loss"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other_Describe">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOther_Describe" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Other_Describe"))%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Investigation_Finding_Other_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInvestigation_Finding_Other_Description" runat="server" Text='<%#Eval("Investigation_Finding_Other_Description")%>'
                                        Width="250px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Root_Cause">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRoot_Cause" runat="server" Text='<%#Eval("Root_Cause")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incident_Prevention">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIncident_Prevention" runat="server" Text='<%#Eval("Incident_Prevention")%>'
                                        Width="250px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Person_Tasked">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPerson_Tasked" runat="server" Text='<%#Eval("Person_Tasked")%>'
                                        Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Target_Date_of_Completion">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTarget_Date_of_Completion" runat="server" Text='<%#Eval("Target_Date_of_Completion") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Date_of_Completion"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status_Due_On">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus_Due_On" runat="server" Text='<%#Eval("Status_Due_On") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Status_Due_On"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments")%>' Width="250px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Financial_Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFinancial_Loss" runat="server" Text='<%#string.Format("{0:C2}",Eval("Financial_Loss"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recovery">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecovery" runat="server" Text='<%#string.Format("{0:C2}",Eval("Recovery"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item_Status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblItem_Status" runat="server" Text='<%#Eval("Item_Status1")%>' Width="100px"></asp:Label>
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
