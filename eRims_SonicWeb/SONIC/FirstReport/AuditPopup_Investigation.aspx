<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Investigation.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_Investigation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Investigation Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divInvestigation_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">PK_Investigation_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">FK_WC_FR_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">FK_LU_Location_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Operating equipment without authority</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to warn</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to secure </span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Operating at improper speed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Making safety devices inoperative</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Using defective equipment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to use Personal Protective Equipment(PPE)Properly</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Improper loading</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Improper placement</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Improper lifting</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Improper position for task</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Servicing equipment in operation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Horse Play</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Under the influence of alcohol and/or other drugs</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Using equipment improperly</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to follow procedure</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to identify hazard/risk</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to check/monitor</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to react/correct</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Failure to communicate/coordinate</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate guards or barriers</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate or improper protective equipment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Defective tools, equipment or materials</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Congestion or restricted action</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate warning system</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Fire and explosion hazards</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Poor housekeeping/disorder</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Noise exposure</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Radiation exposure</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Temperature extremes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate or excessive illumination</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate ventilation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Presences of harmful materials</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate instructions/procedures</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate information/data</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate preparation/planning</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate support/assistance</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate communication hardware/software/process</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Road conditions</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Weather conditions</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Mind off task</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Other - Describe</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Other - Describe - detail</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">What was the associate doing at the time of incident?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate physical capability</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate Mental/Psych. capability</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Physical/Physiological stress</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Mental/Physiological stress</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Lack of knowledge</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Lack of training/skill</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Improper motivation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Abuse or misuse</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate leader/supervision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate engineering</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate purchasing</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate maintenance</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate tools/equipment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate work standard</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Excessive wear/tear</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate communications</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Inadequate controls</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Poor housekeeping</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Other-Describe</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Other-Describe-Details</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Contributing Factor</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Contributing Factor - Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">What could the associate have done differently to avoid the incident? </span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">What is your Conclusion/Impression of how the situation occurred? </span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">OSHA_Recordable</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Sonic_Cause_Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Corrective_Action_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Assigned_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">AssignedBy</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">To_Be_Competed_by</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px">Status</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Lessons_Learned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Cause_Reviewed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Action_Reviewed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Investigation Complete – Ready for RCLM Scoring</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">RLCM Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Date Review Completed by RLCM</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Incident Review Lag Time (in days)</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Was the store’s investigation completed within 7 days of the Date of Loss?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Comment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Was the SLT involved in the investigation?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Comment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">If appropriate, were witness statements documented?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Comment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Was the scene of the accident visited by the SLT?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Comment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Were root cause(s) identified (who, what, where, when, why and how)?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Comment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Was the action plan implemented and shared with all affected associates?</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Comment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Investigative Quality Scoring Metric</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">RLCM_Complete</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 350px;" id="divInvestigation_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvInvestigation_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Investigation_ID" runat="server" Text='<%# Eval("PK_Investigation_ID") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_WC_FR_ID" runat="server" Text='<%# Eval("FK_WC_FR_ID") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_LU_Location_ID" runat="server" Text='<%# Eval("FK_LU_Location_ID") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_1" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_1")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_2" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_2")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_3" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_3")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_4" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_4")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_5" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_5")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_6" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_6")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_7" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_7")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_8" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_8")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_9" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_9")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_10" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_10")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_11" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_11")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_12" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_12")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_13" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_13")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_14" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_14")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_15" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_15")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_16" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_16")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_17" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_17")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_18" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_18")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_19" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_19")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_20" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_20")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_21" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_21")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_22" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_22")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_23" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_23")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_24" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_24")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_25" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_25")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_26" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_26")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_27" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_27")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_28" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_28")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_29" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_29")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_30" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_30")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_31" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_31")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_32" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_32")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_33" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_33")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_34" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_34")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_35" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_35")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_36" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_36")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_37" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_37")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_38" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_38")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_39" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_39")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_40" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_40")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_41" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_41")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_42" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Cause_42")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_42_detail" runat="server" Text='<%# Eval("Cause_42_detail") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_Comment" runat="server" Text='<%# Eval("Cause_Comment") %>' Width="400px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_1" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_1")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_2" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_2")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_3" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_3")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_4" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_4")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_5" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_5")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_6" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_6")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_7" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_7")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_8" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_8")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_9" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_9")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_10" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_10")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_11" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_11")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_12" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_12")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_13" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_13")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_14" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_14")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_15" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_15")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_16" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_16")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_17" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_17")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_18" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_18")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_19" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Personal_Job_Factors_19")) %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Factors_17_Details" runat="server" Text='<%# Eval("Personal_Job_Factors_17_Details") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="ContributingFactor" runat="server" Text='<%# Eval("FK_LU_Contributing_Factor") %>' CssClass="TextClip"
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="ContributingFactor_Other" runat="server" Text='<%# Eval("Contributing_Factor_Other") %>' CssClass="TextClip"
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Personal_Job_Comment" runat="server" Text='<%# Eval("Personal_Job_Comment") %>' CssClass="TextClip"
                                            Width="400px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Conclusions" runat="server" Text='<%# Eval("Conclusions") %>' Width="400px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="OSHA_Recordable" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("OSHA_Recordable")) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Sonic_Cause_Code" runat="server" Text='<%# Eval("Sonic_Cause_Code") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Corrective_Action_Description" runat="server" Text='<%# Eval("Corrective_Action_Description") %>' CssClass="TextClip"
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Assigned_To" runat="server" Text='<%# Eval("Assigned_To") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="AssignedBy" runat="server" Text='<%# Eval("AssignedBy") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="To_Be_Competed_by" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("To_Be_Competed_by"))) ? Convert.ToDateTime(Eval("To_Be_Competed_by")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Status" runat="server" Text='<%# Eval("Status") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Lessons_Learned" runat="server" Text='<%# Eval("Lessons_Learned") %>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Cause_Reviewed" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Cause_Reviewed"))) ? Convert.ToDateTime(Eval("Cause_Reviewed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Action_Reviewed" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Action_Reviewed"))) ? Convert.ToDateTime(Eval("Action_Reviewed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Location_Information_Complete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Location_Information_Complete")) %>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRLCMComment" runat="server" Text='<%# Eval("RLCM_Comments") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateReviewCompletedbyRLCM" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Date_RLCM_Review_Completed"))) ? Convert.ToDateTime(Eval("Date_RLCM_Review_Completed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIncidentReviewLagTime" runat="server" Text='<%# Eval("Lag_Time") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTiming" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplay(Eval("Timing")) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTimingComment" runat="server" Text='<%# Eval("Timing_Comment") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSLT" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplay(Eval("SLT_Involvement")) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSLTComment" runat="server" Text='<%# Eval("SLT_Involvement_Comment") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWitnesses" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplay(Eval("Witnesses")) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWitnessesComment" runat="server" Text='<%# Eval("Witnesses_Comment") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSLT_Visit" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplay(Eval("SLT_Visit")) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSLT_VisitComment" runat="server" Text='<%# Eval("SLT_Visit_Comment") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoot_Causes" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplay(Eval("Root_Causes")) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoot_CausesComment" runat="server" Text='<%# Eval("Root_Causes_Comment") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAction_Plan" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplay(Eval("Action_Plan")) %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAction_PlanComment" runat="server" Text='<%# Eval("Action_Plan_Comment") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAction_PlanComment" runat="server" Text='<%# Eval("Investigative_Quality") %>' Width="220px"></asp:Label>                                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="RLCM_Complete" runat="server" Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("RLCM_Complete")) %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Updated_By" runat="server" Text='<%# Eval("Updated_By") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Updated_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Updated_Date"))) ? Convert.ToDateTime(Eval("Updated_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' Width="100px"></asp:Label>
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

