<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_AP_Cal_Atlantic.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_AP_Cal_Atlantic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: AP Cal Atlantic Audit Trail</title>
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
                    <div style="overflow: hidden; width: 650px;" id="divAP_Cal_Atlantic_Audit_Header"
                        runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 4437px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Audit DateTime</span>
                                    </th>
                                    
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Potential Risk</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Action Taken</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Was Law Enforcement Notified</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Officer Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Phone Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">EMail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Law Enforcement Agency</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Police Report Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Auto Liability</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">DPD</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Premises Liability</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Property Damage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Associated FROI Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Associated Claim Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Root Cause</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Event Prevention</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Person Tasked</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Target Date of Completion</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Status Due On</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Financial Loss</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Recovery</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Item Status</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Updated By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px;">Update Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow-y: scroll; width: 4420px; height: 425px;" id="divAP_Cal_Atlantic_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvAP_Cal_Atlantic_Audit" runat="server" AutoGenerateColumns="False"
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
                                
                                <asp:TemplateField HeaderText="Potential_Risk">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPotential_Risk" runat="server" Text='<%#Eval("Potential_Risk")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action_Taken">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAction_Taken" runat="server" Text='<%#Eval("Action_Taken")%>' Width="160px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Was_Law_Enforcement_Notified">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWas_Law_Enforcement_Notified" runat="server" Text= '<%#clsGeneral.FormatYesNoToDisplay(Eval("Was_Law_Enforcement_Notified"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Officer_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfficer_Name" runat="server" Text='<%#Eval("Officer_Name")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone_Number" runat="server" Text='<%#Eval("Phone_Number")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EMail">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEMail" runat="server" Text='<%#Eval("EMail")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Law_Enforcement_Agency">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLaw_Enforcement_Agency" runat="server" Text='<%#Eval("Law_Enforcement_Agency")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Police_Report_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPolice_Report_Number" runat="server" Text='<%#Eval("Police_Report_Number")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Auto_Liability">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAuto_Liability" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Auto_Liability"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DPD">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDPD" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("DPD"))%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Premises_Liability">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPremises_Liability" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Premises_Liability"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Property_Damage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblProperty_Damage" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Property_Damage"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associated_FROI_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssociated_FROI_Number" runat="server" Text='<%#Eval("Associated_FROI_Number")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associated_Claim_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssociated_Claim_Number" runat="server" Text='<%#Eval("Associated_Claim_Number")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Root_Cause">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoot_Cause" runat="server" Text='<%#Eval("Root_Cause")%>' Width="160px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event_Prevention">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEvent_Prevention" runat="server" Text='<%#Eval("Event_Prevention")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Person_Tasked">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPerson_Tasked" runat="server" Text='<%#Eval("Person_Tasked")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Target_Date_of_Completion">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTarget_Date_of_Completion" runat="server" Text='<%#Eval("Target_Date_of_Completion") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Date_of_Completion"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Due_On">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus_Due_On" runat="server" Text='<%#Eval("Status_Due_On") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Status_Due_On"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments")%>' Width="160px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Financial_Loss">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFinancial_Loss" runat="server" Text='<%#Eval("Financial_Loss")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recovery">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecovery" runat="server" Text='<%#Eval("Recovery")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_Status">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_Status" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Item_Status"))%>' Width="160px"></asp:Label>
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
