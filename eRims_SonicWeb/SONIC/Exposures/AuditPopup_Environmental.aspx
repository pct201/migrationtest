<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Environmental.aspx.cs"
    Inherits="SONIC_Exposures_AuditTrail_Environmental" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Equipment Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divEquipment_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">PK_Enviro_Equipment_ID</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px">FK_LU_Location_ID</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Identification</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Type</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Contents</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Contents_Other</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Capacity</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Status</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Material</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Material_Other</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Construction</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Construction_Other</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Release_Equipment_Present</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Release_Equipment_Description</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Overfill_Protection</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Leak_Detection</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Leak_Detection_Type</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Insurer</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Single_Event_Coverage</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 225px">Multiple_Event_Total_Coverage</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Coverage_Start_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Coverage_End_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Flows_to_POTW</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 145px">Date_of_Last_Service</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">TCLP_on_File</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">Date_of_Last_TCLP</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">Installation_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Removal_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Closure_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">Last_Inspection_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">Next_Inspection_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Insurance_Company</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Inspection_Contact</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Inspection_Phone</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 145px">Registration_Required</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Registration_Number</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Certificate_Number</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Permit_Begin_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Permit_End_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Other_Req</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Other_Req_Descr</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Next_Report_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Notes</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Plan_ID</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Plan_Effective_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Plan_Expiration_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Plan_Revision_Date</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Plan_Vendor</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Plan_Vendor_Contact</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Plan_Phone</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Updated_by</span></th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 127px">Update_Date</span></th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divEquipment_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvEquipment_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            CellSpacing="0" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" SortExpression="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Enviro_Equipment_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PK_Enviro_Equipment_ID") %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sonic_location_Code") %>' Width="135px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Identification">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Identification") %>' Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("type") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contents">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Contents") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contents_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Contents_Other") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Capacity") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="status">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("status") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Material") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Material_Other") %>' Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Construction">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Construction") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Construction_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Construction_Other") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Release_Equipment_Present">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label55" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Release_Equipment_Present")) %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Release_Equipment_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelease_Equipment_Description" runat="server" Text='<%# Bind("Release_Equipment_Description") %>'
                                            Width="600px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Overfill_Protection">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOverfill_Protection" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Overfill_Protection")) %>'
                                            Width="125px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leak_Detection">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeak_Detection" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Leak_Detection")) %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leak_Detection_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Leak_Detection_Type") %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insurer">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Insurer") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Single_Event_Coverage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("Single_Event_Coverage") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Multiple_Event_Total_Coverage">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("Multiple_Event_Total_Coverage") %>'
                                            Width="225px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Coverage_Start_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Coverage_Start_Date")) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Coverage_End_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label19" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Coverage_End_Date")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flows_to_POTW">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label57" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Flows_to_POTW")) %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_of_Last_Service">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label20" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Last_Service")) %>'
                                            Width="145px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TCLP_on_File">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label58" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("TCLP_on_File")) %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_of_Last_TCLP">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label21" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Last_TCLP")) %>'
                                            Width="140px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Installation_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Installation_Date")) %>'
                                            Width="140px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Removal_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Removal_Date")) %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Closure_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label24" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Closure_Date")) %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last_Inspection_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label25" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Last_Inspection_Date")) %>'
                                            Width="140px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Next_Inspection_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label26" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Next_Inspection_Date")) %>'
                                            Width="140px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insurance_Company">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label27" runat="server" Text='<%# Bind("Insurance_Company") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inspection_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label28" runat="server" Text='<%# Bind("Inspection_Contact") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inspection_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Inspection_Phone" runat="server" Text='<%# Bind("Inspection_Phone") %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registration_Required">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Registration_Required" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Registration_Required")) %>'
                                            Width="145px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registration_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label30" runat="server" Text='<%# Bind("Registration_Number") %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Certificate_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label31" runat="server" Text='<%# Bind("Certificate_Number") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Permit_Begin_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label32" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Permit_Begin_Date")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Permit_End_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label33" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Permit_End_Date")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other_Req">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label29" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Other_Req")) %>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other_Req_Descr">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label34" runat="server" Text='<%# Bind("Other_Req_Descr") %>' Width="600px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Next_Report_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label35" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Next_Report_Date")) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label36" runat="server" Text='<%# Bind("Notes") %>' Width="600px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label37" runat="server" Text='<%# Bind("Plan_ID") %>' Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_Effective_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label38" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Plan_Effective_Date")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label39" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Plan_Expiration_Date")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_Revision_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label40" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Plan_Revision_Date")) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_Vendor">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label41" runat="server" Text='<%# Bind("Plan_Vendor") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_Vendor_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label42" runat="server" Text='<%# Bind("Plan_Vendor_Contact") %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label43" runat="server" Text='<%# Bind("Plan_Phone") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="USER_NAME">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label45" runat="server" Text='<%# Bind("USER_NAME") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label46" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date")) %>'
                                            Width="110px"></asp:Label>
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
