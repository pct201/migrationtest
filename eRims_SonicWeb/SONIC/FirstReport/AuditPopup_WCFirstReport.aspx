<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_WCFirstReport.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_WCFirstReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: WC_FR Audit Trail</title>
</head>

<script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        divHeader.style.width = window.screen.availWidth - 225 + "px";
        divGrid.style.width = window.screen.availWidth - 225 + "px";
        
        divheight = divGrid.style.height;        
        i = divheight.indexOf('px');        
        
        if(i > -1)        
            divheight = divheight.substring(0,i);
        if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "")
        {            
            divGrid.style.height = window.screen.availHeight - 350;
        }
    }
    
    function ChangeScrollBar(f,s)
    {
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
                    <div style="overflow: hidden; width: 600px;" id="divWC_FR_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">PK_WC_FR_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">WC_FR_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK_Contact</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK_Injured</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Supervisor_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Motor_Vehicle_Accident</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date_Of_Incident</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Time_Of_Incident</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Filing_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">InjuryOccurredOffsite</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Offsite_Address1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Offsite_Address2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Offsite_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Offsite_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Offsite_zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK_LU_Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">Description_Of_Incident</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Associate_Injured_Regular_Job</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px">FK_Department_Where_Occurred</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK_Nature_Of_Injury</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK_Body_Parts_Affected</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Safeguards_Provided</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Safeguards_Used</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Machine_Part_Involved</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Machine_Part_Defective</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Claim_Questionable</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Claim_Questionable_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date_Reported_To_Sonic</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">person_reported_to</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witnesses</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witness_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witness_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witness_3</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witness_1_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witness_2_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Witness_3_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Fatality</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Initial_Medical_Treatment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Date_of_Initial_Medical_Treatment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 240px">Taken_By_Emergency_Transportation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_Address1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_Address2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Medical_Facility_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Status_Out_Of_Work</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Status_Out_Of_Work_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 260px">Status_Return_To_Work_Unrestricted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Status_Return_To_Work_Unrestricted_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 260px">Status_Return_Tp_Work_Restricted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 280px">Status_Return_Tp_Work_Restricted_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Status_Unknown</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Next_Doctor_Visit</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Treating_Physician_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Admitted_to_Hospital</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Still_In_Hospital</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Referring_Physician</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_Address1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_Address2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Physician_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Complete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Alternate_Phone_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Employee_hrs_per_week</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Employee_Days_per_week</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Employee_Time_Shift_Begins</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Employee_Time_Shift_Ends</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">State_of_Hire</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Date_Reported_to_SRS</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 177px">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divWC_FR_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvWC_FR_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Label1" SortExpression="Label1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_WC_FR_ID" SortExpression="PK_WC_FR_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_WC_FR_ID" runat="server" Text='<%# Eval("PK_WC_FR_ID") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WC_FR_Number" SortExpression="WC_FR_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="WC_FR_Number" runat="server" Text='<%# Eval("WC_FR_Number") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Contact" SortExpression="FK_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Contact" runat="server" Text='<%# Eval("FK_Contact") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Injured" SortExpression="FK_Injured">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Injured" runat="server" Text='<%# Eval("FK_Injured") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supervisor_Phone" SortExpression="Supervisor_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Supervisor_Phone" runat="server" Text='<%# Eval("Supervisor_Phone") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motor_Vehicle_Accident" SortExpression="Motor_Vehicle_Accident">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Motor_Vehicle_Accident" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Motor_Vehicle_Accident")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Of_Incident" SortExpression="Date_Of_Incident">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Of_Incident" runat="server"  Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Of_Incident"))) ? Convert.ToDateTime(Eval("Date_Of_Incident")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time_Of_Incident" SortExpression="Time_Of_Incident">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Time_Of_Incident" runat="server" Text='<%# Eval("Time_Of_Incident") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Filing_State" SortExpression="Filing_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Filing_State" runat="server" Text='<%# Eval("Filing_State") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InjuryOccurredOffsite" SortExpression="InjuryOccurredOffsite">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="InjuryOccurredOffsite" runat="server" Text='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("InjuryOccurredOffsite"))) ? (Convert.ToString(Eval("InjuryOccurredOffsite")) == "True" ? "Offsite" : "Onsite") : "Onsite" %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offsite_Address1" SortExpression="Offsite_Address1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Offsite_Address1" runat="server" Text='<%# Eval("Offsite_Address1") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offsite_Address2" SortExpression="Offsite_Address2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Offsite_Address2" runat="server" Text='<%# Eval("Offsite_Address2") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offsite_City" SortExpression="Offsite_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Offsite_City" runat="server" Text='<%# Eval("Offsite_City") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offsite_State" SortExpression="Offsite_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Offsite_State" runat="server" Text='<%# Eval("Offsite_State") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offsite_zip" SortExpression="Offsite_zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Offsite_zip" runat="server" Text='<%# Eval("Offsite_zip") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location" SortExpression="FK_LU_Location">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_LU_Location" runat="server" Text='<%# Eval("FK_LU_Location") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description_Of_Incident" SortExpression="Description_Of_Incident">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Description_Of_Incident" runat="server" Text='<%# Eval("Description_Of_Incident") %>'
                                            Width="400px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associate_Injured_Regular_Job" SortExpression="Associate_Injured_Regular_Job">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Associate_Injured_Regular_Job" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Associate_Injured_Regular_Job")) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Department_Where_Occurred" SortExpression="FK_Department_Where_Occurred">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Department_Where_Occurred" runat="server" Text='<%# Eval("FK_Department_Where_Occurred") %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Nature_Of_Injury" SortExpression="FK_Nature_Of_Injury">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Nature_Of_Injury" runat="server" Text='<%# Eval("FK_Nature_Of_Injury") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Body_Parts_Affected" SortExpression="FK_Body_Parts_Affected">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Body_Parts_Affected" runat="server" Text='<%# Eval("FK_Body_Parts_Affected") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Safeguards_Provided" SortExpression="Safeguards_Provided">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Safeguards_Provided" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Safeguards_Provided")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Safeguards_Used" SortExpression="Safeguards_Used">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Safeguards_Used" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Safeguards_Used")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine_Part_Involved" SortExpression="Machine_Part_Involved">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Machine_Part_Involved" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Machine_Part_Involved")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine_Part_Defective" SortExpression="Machine_Part_Defective">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Machine_Part_Defective" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Machine_Part_Defective")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Questionable" SortExpression="Claim_Questionable">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Questionable" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Claim_Questionable")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Questionable_Description" SortExpression="Claim_Questionable_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Questionable_Description" runat="server" Text='<%# Eval("Claim_Questionable_Description") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Reported_To_Sonic" SortExpression="Date_Reported_To_Sonic">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Reported_To_Sonic" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Reported_To_Sonic"))) ? Convert.ToDateTime(Eval("Date_Reported_To_Sonic")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="person_reported_to" SortExpression="person_reported_to">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="person_reported_to" runat="server" Text='<%# Eval("person_reported_to") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witnesses" SortExpression="Witnesses">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witnesses" runat="server" Text='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("Witnesses"))) ? (Convert.ToString(Eval("Witnesses")) == "True" ? "Yes" : "No") : "" %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witness_1" SortExpression="Witness_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witness_1" runat="server" Text='<%# Eval("Witness_1") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witness_2" SortExpression="Witness_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witness_2" runat="server" Text='<%# Eval("Witness_2") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witness_3" SortExpression="Witness_3">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witness_3" runat="server" Text='<%# Eval("Witness_3") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witness_1_Phone" SortExpression="Witness_1_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witness_1_Phone" runat="server" Text='<%# Eval("Witness_1_Phone") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witness_2_Phone" SortExpression="Witness_2_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witness_2_Phone" runat="server" Text='<%# Eval("Witness_2_Phone") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Witness_3_Phone" SortExpression="Witness_3_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Witness_3_Phone" runat="server" Text='<%# Eval("Witness_3_Phone") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fatality" SortExpression="Fatality">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Fatality" runat="server" Text='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("Fatality"))) ? (Convert.ToString(Eval("Fatality")) == "True" ? "Yes" : "No") : "" %>'
                                         Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Initial_Medical_Treatment" SortExpression="Initial_Medical_Treatment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Initial_Medical_Treatment" runat="server" Text='<%# Eval("Initial_Medical_Treatment") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_of_Initial_Medical_Treatment" SortExpression="Date_of_Initial_Medical_Treatment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_of_Initial_Medical_Treatment" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_of_Initial_Medical_Treatment"))) ? Convert.ToDateTime(Eval("Date_of_Initial_Medical_Treatment")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Taken_By_Emergency_Transportation" SortExpression="Taken_By_Emergency_Transportation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Taken_By_Emergency_Transportation" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Taken_By_Emergency_Transportation")) %>'
                                            Width="240px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_Name" SortExpression="Medical_Facility_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_Name" runat="server" Text='<%# Eval("Medical_Facility_Name") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_Address1" SortExpression="Medical_Facility_Address1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_Address1" runat="server" Text='<%# Eval("Medical_Facility_Address1") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_Address2" SortExpression="Medical_Facility_Address2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_Address2" runat="server" Text='<%# Eval("Medical_Facility_Address2") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_City" SortExpression="Medical_Facility_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_City" runat="server" Text='<%# Eval("Medical_Facility_City") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_State" SortExpression="Medical_Facility_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_State" runat="server" Text='<%# Eval("Medical_Facility_State") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_Zip" SortExpression="Medical_Facility_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_Zip" runat="server" Text='<%# Eval("Medical_Facility_Zip") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medical_Facility_Phone" SortExpression="Medical_Facility_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Medical_Facility_Phone" runat="server" Text='<%# (Eval("Medical_Facility_Phone")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Out_Of_Work" SortExpression="Status_Out_Of_Work">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Out_Of_Work" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Status_Out_Of_Work")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Out_Of_Work_Date" SortExpression="Status_Out_Of_Work_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Out_Of_Work_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Status_Out_Of_Work_Date"))) ? Convert.ToDateTime(Eval("Status_Out_Of_Work_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Return_To_Work_Unrestricted" SortExpression="Status_Return_To_Work_Unrestricted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Return_To_Work_Unrestricted" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Status_Return_To_Work_Unrestricted")) %>'
                                            Width="260px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Return_To_Work_Unrestricted_Date" SortExpression="Status_Return_To_Work_Unrestricted_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Return_To_Work_Unrestricted_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Status_Return_To_Work_Unrestricted_Date"))) ? Convert.ToDateTime(Eval("Status_Return_To_Work_Unrestricted_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Return_Tp_Work_Restricted" SortExpression="Status_Return_Tp_Work_Restricted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Return_Tp_Work_Restricted" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Status_Return_Tp_Work_Restricted")) %>'
                                            Width="260px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Return_Tp_Work_Restricted_Date" SortExpression="Status_Return_Tp_Work_Restricted_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Return_Tp_Work_Restricted_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Status_Return_Tp_Work_Restricted_Date"))) ? Convert.ToDateTime(Eval("Status_Return_Tp_Work_Restricted_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Unknown" SortExpression="Status_Unknown">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status_Unknown" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Status_Unknown")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Next_Doctor_Visit" SortExpression="Next_Doctor_Visit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Next_Doctor_Visit" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Next_Doctor_Visit"))) ? Convert.ToDateTime(Eval("Next_Doctor_Visit")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Treating_Physician_Name" SortExpression="Treating_Physician_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Treating_Physician_Name" runat="server" Text='<%# Eval("Treating_Physician_Name") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admitted_to_Hospital" SortExpression="Admitted_to_Hospital">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Admitted_to_Hospital" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Admitted_to_Hospital")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Still_In_Hospital" SortExpression="Still_In_Hospital">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Still_In_Hospital" runat="server" Text='<%# clsGeneral.FormatYesNoUnknownToDisplayForView(Eval("Still_In_Hospital")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Referring_Physician" SortExpression="Referring_Physician">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Referring_Physician" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Referring_Physician")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_Name" SortExpression="Physician_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_Name" runat="server" Text='<%# Eval("Physician_Name") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_Address1" SortExpression="Physician_Address1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_Address1" runat="server" Text='<%# Eval("Physician_Address1") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_Address2" SortExpression="Physician_Address2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_Address2" runat="server" Text='<%# Eval("Physician_Address2") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_City" SortExpression="Physician_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_City" runat="server" Text='<%# Eval("Physician_City") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_State" SortExpression="Physician_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_State" runat="server" Text='<%# Eval("Physician_State") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_Zip" SortExpression="Physician_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_Zip" runat="server" Text='<%# Eval("Physician_Zip") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Physician_Phone" SortExpression="Physician_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Physician_Phone" runat="server" Text='<%# Eval("Physician_Phone") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Comments" runat="server" Text='<%# Eval("Comments") %>' Width="400px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Complete" SortExpression="Complete">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Complete" runat="server" Text='<%# Eval("Complete") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alternate_Phone_2" SortExpression="Alternate_Phone_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Alternate_Phone_2" runat="server" Text='<%# Eval("Alternate_Phone_2") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee_hrs_per_week" SortExpression="Employee_hrs_per_week">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Employee_hrs_per_week" runat="server" Text='<%# Eval("Employee_hrs_per_week") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee_Days_per_week" SortExpression="Employee_Days_per_week">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Employee_Days_per_week" runat="server" Text='<%# Eval("Employee_Days_per_week") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee_Time_Shift_Begins" SortExpression="Employee_Time_Shift_Begins">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Employee_Time_Shift_Begins" runat="server" Text='<%# Eval("Employee_Time_Shift_Begins") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee_Time_Shift_Ends" SortExpression="Employee_Time_Shift_Ends">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Employee_Time_Shift_Ends" runat="server" Text='<%# Eval("Employee_Time_Shift_Ends") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State_of_Hire" SortExpression="State_of_Hire">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="State_of_Hire" runat="server" Text='<%# Eval("State_of_Hire") %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Reported_to_SRS" SortExpression="Date_Reported_to_SRS">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Reported_to_SRS" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_Reported_to_SRS"))) ? Convert.ToDateTime(Eval("Date_Reported_to_SRS")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Updated_By" runat="server" Text='<%# Eval("Updated_By") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date" SortExpression="Updated_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Updated_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Updated_Date"))) ? Convert.ToDateTime(Eval("Updated_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="160px"></asp:Label>
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
