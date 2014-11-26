<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Equipment_Tank.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Equipment_Tank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Tank Audit Trail</title>
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Equipment_Tank" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Manufacturer</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Ground Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Identification</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Tank Contents</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Other Contents</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Tank Material</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Other Material</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Tank Construction</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Other Construction</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Tank Capacity in Gallons</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Is Tank UL Certified?</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Is Tank Secure during Non-Business Hours?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Certificate Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Installation Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Installation Firm</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Last Maintenance Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Last Revision Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Tank In Use?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Last Inspection Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Closure Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Removal Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Revised Removal Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Permit Begin Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Permit End Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Registration Required?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Registration Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Leak Detection Required?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Leak Detection Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Overfill Protection?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Secondary Containment Adequate?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Secondary Containment Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Description of Other Reporting Requirements</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Plan Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Plan Identification</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Recommendations</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Effective Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Expiration Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Record keeping Requirements</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Inadvertent Release Control and Countermeasures Plan</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Maintenance Vendor</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Vendor Contact Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Vendor Contact Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Insurer</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Coverage Start Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Coverage End Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Multiple Event/Total Coverage</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Single Event Coverage</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Inspection Company</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Inspection Company Contact Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Inspection Company Contact Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Notes</span>
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
                <div style="overflow: scroll; width: 300px; height: 320px;" id="divPM_Equipment_Tank_Grid"
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
                             <asp:TemplateField HeaderText="Manufacturer">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblManufacturer" runat="server" Text='<%#Eval("Manufacturer")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ground_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGround_Location" runat="server" Text='<%#Eval("Ground_Location")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Identification">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIdentification" runat="server" Text='<%#Eval("Identification")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Tank_Contents">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Tank_Contents" runat="server" Text='<%#Eval("FK_Tank_Contents")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contents_Other">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblContents_Other" runat="server" Text='<%#Eval("Contents_Other")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Tank_Material">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Tank_Material" runat="server" Text='<%#Eval("FK_Tank_Material")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Material_Other">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMaterial_Other" runat="server" Text='<%#Eval("Material_Other")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Tank_Construction">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Tank_Construction" runat="server" Text='<%#Eval("FK_Tank_Construction")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Construction_Other">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblConstruction_Other" runat="server" Text='<%#Eval("Construction_Other")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Capcity">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCapcity" runat="server" Text='<%#Eval("Capcity")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="UL_Certified">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUL_Certified" runat="server" Text='<%#Eval("UL_Certified")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Secure_Non_Business">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSecure_Non_Business" runat="server" Text='<%#Eval("Secure_Non_Business")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certificate_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCertificate_Number" runat="server" Text='<%#Eval("Certificate_Number")%>'
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
                            <asp:TemplateField HeaderText="Installation_Firm">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallation_Firm" runat="server" Text='<%#Eval("Installation_Firm")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last_Maintenance_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Maintenance_Date" runat="server" Text='<%#Eval("Last_Maintenance_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Last_Maintenance_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last_Revision_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Revision_Date" runat="server" Text='<%#Eval("Last_Revision_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Last_Revision_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tank_In_Use">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTank_In_Use" runat="server" Text='<%#Eval("Tank_In_Use")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last_Inspection_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Inspection_Date" runat="server" Text='<%#Eval("Last_Inspection_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Last_Inspection_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Closure_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblClosure_Date" runat="server" Text='<%#Eval("Closure_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Closure_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Removal_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRemoval_Date" runat="server" Text='<%#Eval("Removal_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Removal_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Revised_Removal_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRevised_Removal_Date" runat="server" Text='<%#Eval("Revised_Removal_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Revised_Removal_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permit_Begin_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPermit_Begin_Date" runat="server" Text='<%#Eval("Permit_Begin_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Permit_Begin_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permit_End_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPermit_End_Date" runat="server" Text='<%#Eval("Permit_End_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Permit_End_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Registration_Required">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistration_Required" runat="server" Text='<%#Eval("Registration_Required")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Registration_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistration_Number" runat="server" Text='<%#Eval("Registration_Number")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leak_Detection_Required">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLeak_Detection_Required" runat="server" Text='<%#Eval("Leak_Detection_Required")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leak_Detection_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLeak_Detection_Type" runat="server" Text='<%#Eval("Leak_Detection_Type")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Overfill_Protection">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOverfill_Protection" runat="server" Text='<%#Eval("Overfill_Protection")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Secondary_Containment_Adequate">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSecondary_Containment_Adequate" runat="server" Text='<%#Eval("Secondary_Containment_Adequate")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Secondary_Containment_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Secondary_Containment_Type" runat="server" Text='<%#Eval("FK_LU_Secondary_Containment_Type")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description_Other_Reporting_Requirements">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription_Other_Reporting_Requirements" runat="server" Text='<%#Eval("Description_Other_Reporting_Requirements")%>' Width="300px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Plan_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPlan_Date" runat="server" Text='<%#Eval("Plan_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Plan_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Plan_Identification">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPlan_Identification" runat="server" Text='<%#Eval("Plan_Identification")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recommendations">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecommendations" runat="server" Text='<%#Eval("Recommendations")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Effective_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEffective_Date" runat="server" Text='<%#Eval("Effective_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Effective_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expiration_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblExpiration_Date" runat="server" Text='<%#Eval("Expiration_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Expiration_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recordkeeping_Requirements">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecordkeeping_Requirements" runat="server" Text='<%#Eval("Recordkeeping_Requirements")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Release_Control_Countermeasures_Plan">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRelease_Control_Countermeasures_Plan" runat="server" Text='<%#Eval("Release_Control_Countermeasures_Plan")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Maintenance_Vendor">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMaintenance_Vendor" runat="server" Text='<%#Eval("Maintenance_Vendor")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor_Contact_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_Contact_Name" runat="server" Text='<%#Eval("Vendor_Contact_Name")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor_Contact_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_Contact_Telephone" runat="server" Text='<%#Eval("Vendor_Contact_Telephone")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Insurer">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInsurer" runat="server" Text='<%#Eval("Insurer")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Coverage_Start_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCoverage_Start_Date" runat="server" Text='<%#Eval("Coverage_Start_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Coverage_Start_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Coverage_End_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCoverage_End_Date" runat="server" Text='<%#Eval("Coverage_End_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Coverage_End_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Multiple_Event_Total_Coverage">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMultiple_Event_Total_Coverage" runat="server" Text='<%#Eval("Multiple_Event_Total_Coverage")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Single_Event_Coverage">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSingle_Event_Coverage" runat="server" Text='<%#Eval("Single_Event_Coverage")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inspection_Company">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInspection_Company" runat="server" Text='<%#Eval("Inspection_Company")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inspection_Company_Contact_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInspection_Company_Contact_Name" runat="server" Text='<%#Eval("Inspection_Company_Contact_Name")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inspection_Company_Contact_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInspection_Company_Contact_Telephone" runat="server" Text='<%#Eval("Inspection_Company_Contact_Telephone")%>'
                                        Width="100px" CssClass="TextClip"></asp:Label>
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
