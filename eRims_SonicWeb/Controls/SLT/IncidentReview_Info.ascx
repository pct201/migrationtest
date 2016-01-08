<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IncidentReview_Info.ascx.cs"
    Inherits="SLT_IncidentReview_Info" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
<asp:ValidationSummary ID="valSummayIncident" runat="server" ValidationGroup="vsIncidentReview"
    ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
<script type="text/javascript">
    function AuditPopUp(FR_ID, name) {

        var winHeight = window.screen.availHeight - 380;
        var winWidth = window.screen.availWidth - 390;

        obj = window.open("../SLT/AuditPopup_IncidentReview.aspx?id=" + FR_ID + "&name=" + name, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
        obj.focus();
        return false;
    }

    //$(document).ready(function () {
    //    var op = '<=StrOperation%>';
    //    var rdoRoot_Cause = $("#<=rdoRoot_Cause.ClientID%> input[type='radio']:checked").val();

    //    if (rdoRoot_Cause == 'N')
    //        $("#<=trIncident_Review_Edit.ClientID%>").show();
    //    else
    //        $("#<=trIncident_Review_Edit.ClientID%>").hide();


    //    $("#<=rdoRoot_Cause.ClientID%>").change(function () {

    //        var rdoRoot_Cause = $("#<=rdoRoot_Cause.ClientID%> input[type='radio']:checked").val();

    //        if (rdoRoot_Cause == 'N')
    //            $("#<=trIncident_Review_Edit.ClientID%>").show();
    //        else
    //            $("#<=trIncident_Review_Edit.ClientID%>").hide();
    //    });
    //});

</script>
<table cellspacing="1" cellpadding="3" width="100%" border="0">
    <tr>
        <td align="left" valign="top" class="bandHeaderRow" width="100%">
            <asp:Label ID="lblHeading" runat="server" Text="Incident Review"></asp:Label>
        </td>
    </tr>
    <tr id="trFilterYearMonth" runat="server" visible="false">
        <td>
            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                <tr>
                    <td align="left" width="17%">
                        <%-- Year--%>
                    </td>
                    <td align="center" width="3%">&nbsp;&nbsp;
                    </td>
                    <td align="left" width="20%">
                        <asp:DropDownList ID="ddlYear" Visible="false" runat="server" Width="80px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="15%"></td>
                    <td align="right" width="16%">&nbsp;
                    </td>
                    <td align="center" width="4%"></td>
                    <td align="left" width="25%">
                        <asp:DropDownList ID="ddlMonth" Visible="false" runat="server" Width="170px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="trWC_Fr" runat="server" visible="false">
        <td>
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="gvWc_fr" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            PageSize="5" Width="100%" OnRowCommand="gvWc_fr_RowCommand" OnPageIndexChanging="gvWc_fr_PageIndexChanging"
                            EmptyDataText="No Records Found">
                            <Columns>
                                <asp:TemplateField HeaderText="First Report Number">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkWC_FR_Number" CommandName="ViewDetails" CommandArgument='<%#Eval("PK_WC_FR_ID")%>'
                                            runat="server" Text='<%#Eval("WC_FR_Number") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Investigation ID">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkInvestigation_ID" CommandName="ViewDetails" CommandArgument='<%#Eval("PK_WC_FR_ID")%>'
                                            runat="server" Text='<%#Eval("PK_Investigation_ID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <%#Eval("Department")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Incident">
                                    <ItemTemplate>
                                        <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Incident")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%#Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left" class="bandHeaderRow" style="height: 10px;">INCIDENT INFORMATION
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left">Incident Number
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblIncidentNumber_WC" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="left">Name
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblName_WC" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left">Date of Incident
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblDate_of_Incident_WC" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="left">Department
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblDepartment_WC" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left">Time of Incident
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblTime_of_Incident_WC" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="left">Nature of Injury
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblNature_of_Injury_WC" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left">Body part Effected
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblBodyPartEffected_WC" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="left"></td>
                    <td width="1%"></td>
                    <td width="29%"></td>
                </tr>
                <tr>
                    <td width="20%" align="left">Incident Description
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="79%" colspan="4"></td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <uc:ctrlMultiLineTextBox ID="txtDescription_Of_Incident_WC" runat="server" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left" class="bandHeaderRow" style="height: 10px;">CAUSES
                    </td>
                </tr>
                <%-- <tr>
                    <td width="20%" align="left">
                        Substandard Behaviors
                    </td>
                    <td width="1%">
                        :
                    </td>
                    <td width="79%" colspan="4">
                        <%--<asp:Label ID="lblSubs_Behaviors_WC" runat="server" Text=""></asp:Label>--%>
                <%--   </td>
                </tr>
                <tr>
                    <td colspan="6" align="left">--%>
                <%--<asp:Repeater ID="rptCauseBehaviours" runat="server">
                            <ItemTemplate>
                                <table cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="right" width="1%">
                                            <%# Container.ItemIndex+1  %>
                                        </td>
                                        <td align="left" width="1%">
                                            .
                                        </td>
                                        <td width="98%" align="left">
                                            <%# Eval("Description")%>
                                        </td>--%>
                <%--<td align="left">
                                            <%# Eval("Value") != DBNull.Value ? (Convert.ToBoolean(Eval("Value")) == true ? "Yes" : string.Empty) : string.Empty %>
                                        </td>--%>
                <%--</tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                <%-- </td>
                </tr>
                <tr>
                    <td width="20%" align="left">
                        Substandard Conditions
                    </td>
                    <td width="1%">
                        :
                    </td>
                    <td width="79%" colspan="4">--%>
                <%--<asp:Label ID="lblSubs_Conditions_WC" runat="server" Text=""></asp:Label>--%>
                <%--</td>
                </tr>--%>
                <tr>
                    <td width="20%" align="left">Cause of the Incident
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="79%" colspan="4">
                        <asp:Label ID="lblNatureOfTheIncident" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">How the event occurred :
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtEvent_Cause_Comment" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left">
                        <asp:Repeater ID="rptCauseConditions" runat="server">
                            <ItemTemplate>
                                <table cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="right" width="1%">
                                            <%#  Container.ItemIndex +1%>
                                        </td>
                                        <td align="left" width="1%">.
                                        </td>
                                        <td align="left" width="98%">
                                            <%# Eval("Description")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <%-- <tr>
                    <td align="left" colspan="6">
                        What was the associate doing at the time of incident?
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtCause_Comment" ControlType="Label" />
                    </td>
                </tr>--%>
                <tr>
                    <td align="left" width="20%">Contributing Factor
                    </td>
                    <td align="center" width="1%">:
                    </td>
                    <td align="left" width="29%">
                        <asp:Label ID="lblContributingFactor" runat="server" />
                    </td>
                    <td align="left" width="20%">Contributing Factor - Other
                    </td>
                    <td align="left" width="1%">:
                    </td>
                    <td align="left" width="29%">
                        <asp:Label ID="lblContributingFactor_Other" runat="server" />
                    </td>
                </tr>
                <%-- <tr>
                    <td align="left" colspan="6">
                        What could the associate have done differently to avoid the incident?
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtPersonal_Job_Comment" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left">
                        OSHA Recordable
                    </td>
                    <td width="1%">
                        :
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblOSHARecordable" runat="server" />
                    </td>
                    <td width="20%" align="left" valign="top">
                        Sonic Cause Code
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td width="29%" valign="top">
                        <asp:Label ID="lblSonicCauseCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left" valign="top">
                        Investigative Quality
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td width="29%" colspan="4" valign="top">
                        <asp:Label ID="lblInvestigative" runat="server" />
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="6" align="left" class="bandHeaderRow" style="height: 10px;">Root Cause Determination
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="20%">Root Cause Determination&nbsp;
                    </td>
                    <td align="center" valign="top" width="1%">:
                    </td>
                    <td colspan="4">
                        <asp:Repeater runat="server" ID="rptRootCauseDeterminationView">
                            <ItemTemplate>
                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td align="center" width="2%" valign="top">
                                            <%#Container.ItemIndex + 1%>
                                        </td>
                                        <td align="left" width="70%">
                                            <%#Eval("Question")%>
                                            <asp:HiddenField runat="server" ID="hdnFK_LU_Cause_Info" Value='<%#Eval("PK_LU_Cause_Code_Information")%>'></asp:HiddenField>
                                            <asp:HiddenField runat="server" ID="hdnPK_Investigation_Cause_Information" Value='<%#Eval("PK_Investigation_Cause_Information")%>'></asp:HiddenField>

                                        </td>
                                        <td align="center" width="2%">:
                                        </td>
                                        <td align="left" width="26%">
                                            <asp:Label ID="lblRootCauseTypeList" runat="server"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>

                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="20%">Recommendation(s) to Prevent Reoccurrence&nbsp;<span id="Span26"
                        style="color: Red; display: none;" runat="server">*</span>
                    </td>
                    <td align="center" valign="top" width="1%">:
                    </td>
                    <td colspan="4">
                        <asp:Repeater runat="server" ID="rptRootCauseDeterminationRecmndationView">
                            <ItemTemplate>
                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td align="center" width="2%" valign="top">
                                            <%#Container.ItemIndex + 1%>
                                        </td>
                                        <td align="left" width="98%">
                                            <%#Eval("Guidance")%>
                                        </td>

                                    </tr>
                                </table>

                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left" style="height: 10px;">What is your Impression/Conclusion on the how the event occurred? :
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblConclusions" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left">OSHA Recordable
                    </td>
                    <td width="1%">:
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblOSHARecordable_Root_Cause" runat="server" />
                    </td>
                    <td width="20%" align="left" valign="top">Cause Code Determination
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="29%" valign="top">
                        <asp:Label ID="lblSonicCauseCode_Root_Cause" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Allocation Charge
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblAllocation_Charge" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Reporting Credit
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblReporting_Credit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Nurse Triage Credit
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblNurse_Triage_Credit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Reporting Charge
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblReporting_Charge" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Investigation Quality Credit
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblInvestigation_Quality_Credit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Early Close Credit
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblEarly_Close_Credit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Re-Open Charge
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblRe_Open_Charge" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Total Charge
                    </td>
                    <td >:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblTotal_Charge" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td colspan="6" align="left" class="bandHeaderRow" style="height: 10px;">CORRECTIVE ACTIONS
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left" style="height: 10px;">What has been done to prevent a similar accident from happening again? :
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblLessons_Learned" ControlType="Label" />
                    </td>
                </tr>
                <%--<tr>
                    <td width="20%" align="left" valign="top">
                        Description
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td width="29%" valign="top">
                    </td>
                    <td width="20%" align="left">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="29%">
                    </td>
                </tr>--%>
                <%--<tr>
                    <td width="20%" colspan="6" align="left" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblDescription_Corrective" ControlType="Label" />
                    </td>--%>
                <%-- <td width="1%" valign="top">
                     
                    </td>
                    <td width="29%" valign="top">
                        
                    </td>
                    <td width="20%" align="left">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="29%">
                    </td>--%>
                <%--</tr>--%>
                <tr>
                    <td width="20%" align="left" valign="top">Assigned To
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="29%" valign="top" colspan="4">
                        <asp:Label ID="lblAssignedTo" runat="server"></asp:Label>
                    </td>
                    <%-- <td width="20%" align="left">
                        Assigned By
                    </td>
                    <td width="1%">
                        :
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblAssignedBy" runat="server"></asp:Label>
                    </td>--%>
                </tr>
                <tr>
                    <td width="20%" align="left" valign="top">Status
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="29%" valign="top" colspan="4">
                        <asp:Label ID="lblStatus_Corrective" runat="server"></asp:Label>
                    </td>
                    <%--<td width="20%" align="left">
                        Lesson Learned
                    </td>
                    <td width="1%">
                        :
                    </td>
                    <td width="29%">
                        <asp:Label ID="lblLessonLearned" runat="server"></asp:Label>
                    </td>--%>
                </tr>
                <tr>
                    <td width="79%" align="left" valign="top" colspan="4">
                        <%--Have the above changes been communicated to associates with similar job tasks? --%>
                        Have the corrective actions been communicated to associates with similar job tasks?
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="20%" valign="top">
                        <asp:Label ID="lblCommunicatedToAssociate" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td width="24%" align="left" valign="top">Does the SLT agree with the Root Cause Determination 
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="25%" valign="top" colspan="4">
                            <asp:RadioButtonList ID="rdoRoot_Cause" runat="server" SkinID="YesNoType" AutoPostBack="true" OnSelectedIndexChanged="rdoRoot_Cause_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        <asp:Label ID="lblSLT_Agree_Root_Cause" runat="server"></asp:Label>
                    </td>
                </tr>

                <%-- <tr>
                    <td width="20%" align="left" valign="top">
                        Incident Review LagTime
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td width="29%" colspan="4" valign="top">
                        <asp:Label ID="lblIncidentReview_LagTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left" valign="top">
                        RLCM Comments
                    </td>
                    <td width="1%" valign="top">
                    </td>
                    <td width="29%" colspan="4" valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="6">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblRLCMComments" ControlType="Label" />
                    </td>
                </tr>--%>
            </table>
        </td>
    </tr>
    <tr id="trIncident_Review_Edit" runat="server" visible="true">
        <td width="100%">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td colspan="6">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">What is the incident's root cause? &nbsp;<span id="Span1" runat="server" style="color: Red; display: none;">*</span> &nbsp;:
                    </td>
                    <%--<td width="1%">
                        :
                    </td>
                    <td colspan="4">
                    </td>--%>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtrootcause" ControlType="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">How can the incident be prevented from happening again? &nbsp;<span id="Span2" runat="server"
                        style="color: Red; display: none;">*</span>&nbsp;:
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtPreventedFromHappening" ControlType="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="3">Who has been tasked with implementing practices/procedures to prevent re-occurrence?
                        &nbsp; <span id="Span3" runat="server" style="color: Red; display: none;">*</span>&nbsp;:
                    </td>
                    <td valign="top" align="left">
                        <asp:TextBox runat="server" ID="txtConfirmation_Assign_To" Width="150px" MaxLength="30"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvConf" runat="server" ControlToValidate="txtConfirmation_Assign_To"
                            Display="None" ErrorMessage="Please Enter Confirmation of Practices/Procedures to Prevent Reoccurence Assign To" SetFocusOnError="true"
                            ValidationGroup="vsIncidentReview"></asp:RequiredFieldValidator>--%>
                        <%--<asp:RequiredFieldValidator ID="rfvJobFactor19Details" runat="server" ControlToValidate="txtConfirmation_Assign_To"
                            ValidationGroup="valCauses" SetFocusOnError="true" Display="None" ErrorMessage="Please enter Confirmation of Practices/Procedures to Prevent Reoccurence Assign To"
                            Enabled="false" />--%>
                    </td>
                    <td valign="top"></td>
                    <td valign="top"></td>
                </tr>
                <tr>
                    <td width="24%" align="left" valign="top">Target Date of Completion&nbsp;<span id="Span4" runat="server" style="color: Red; display: none;">*</span>
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="25%" valign="top">
                        <%--ctl00_ContentPlaceHolder1_Incident_Review1_txtTargetDateCompletion--%>
                        <asp:TextBox ID="txtTargetDateCompletion" runat="server" Width="150px" SkinID="txtDate"></asp:TextBox>
                        <img alt="Target Date of Completion" onclick="return showCalendar('<%=txtTargetDateCompletion.ClientID%>', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                            align="middle" /><br />
                        <asp:RegularExpressionValidator ID="revTargetDateCompletion" runat="server" ValidationGroup="vsIncidentReview"
                            Display="none" ErrorMessage="Target Date of Completion is not a valid date" SetFocusOnError="true"
                            ControlToValidate="txtTargetDateCompletion" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                        <%--<asp:RequiredFieldValidator ID="rfvTargetDateCompletion" runat="server" ControlToValidate="txtTargetDateCompletion"
                            Display="None" ErrorMessage="Please enter Target Date of Completion" SetFocusOnError="true"
                            ValidationGroup="vsIncidentReview" />--%>
                        <%--<asp:RangeValidator ID="revTo_Be_Competed_by" ControlToValidate="txtTargetDateCompletion"
                            MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Target Date of Completion is not valid."
                            runat="server" SetFocusOnError="true" ValidationGroup="valCauses" Display="none" /--%>
                    </td>
                    <td width="20%" align="center" valign="top">Status Due On&nbsp;<span id="Span5" runat="server" style="color: Red; display: none;">*</span>&nbsp;&nbsp;&nbsp;:
                    </td>
                    <%--<td width="1%" valign="top"> 
                        :
                    </td>--%>
                    <td width="36%" valign="top" align="left" colspan="2">
                        <%--ctl00_ContentPlaceHolder1_Incident_Review1_txtStatusDueOn--%>
                        <asp:TextBox ID="txtStatusDueOn" runat="server" Width="150px" SkinID="txtDate"></asp:TextBox>
                        <img alt="Status Due On" onclick="return showCalendar('<%=txtStatusDueOn.ClientID %>', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                            align="middle" /><br />
                        <asp:RegularExpressionValidator ID="revStatusDueOn" runat="server" ValidationGroup="vsIncidentReview"
                            Display="none" ErrorMessage="Status Due On is not a valid date" SetFocusOnError="true"
                            ControlToValidate="txtStatusDueOn" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                        <%--<asp:RequiredFieldValidator ID="rfvStatusDueOn" runat="server" ControlToValidate="txtStatusDueOn"
                            Display="None" ErrorMessage="Please enter Status Due On" SetFocusOnError="true"
                            ValidationGroup="vsIncidentReview" />--%>
                        <%-- <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtStatusDueOn"
                            MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Status Due On is not valid."
                            runat="server" SetFocusOnError="true" ValidationGroup="valCauses" Display="none" />--%>
                    </td>
                </tr>
                <%--<tr>
                    <td width="24%" align="left" valign="top">
                        Incident Investigation Reviewed &nbsp;<span id="Span8" runat="server" style="color: Red;
                            display: none;">*</span>
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td width="25%" valign="top">
                        <asp:RadioButtonList ID="rdoIncidentInvestigation" runat="server" SkinID="YesNoType">
                        </asp:RadioButtonList>
                    </td>
                    <td width="20%" align="center" valign="top">
                        Date Reviewed&nbsp;<span id="Span9" runat="server" style="color: Red; display: none;">*</span>
                        &nbsp;&nbsp;&nbsp;:
                    </td>
                    <td width="36%" valign="top" align="left" colspan="2">
                        <asp:TextBox ID="txtDateReviewed" runat="server" Width="150px" SkinID="txtDate"></asp:TextBox>
                        <img alt="Date Reviewed" onclick="return showCalendar('<%=txtDateReviewed.ClientID %>', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                            align="middle" /><br />
                        <asp:RegularExpressionValidator ID="revDateReviewed" runat="server" ValidationGroup="vsIncidentReview"
                            Display="none" ErrorMessage="Date Reviewed is not a valid date" SetFocusOnError="true"
                            ControlToValidate="txtDateReviewed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
               
                <tr>
                    <td width="20%" align="left" valign="top">
                        Item Status&nbsp;<span id="Span7" runat="server" style="color: Red; display: none;">*</span>
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td width="29%" valign="top">
                        <asp:DropDownList ID="drpItemStatus" runat="server" Width="60%">
                        </asp:DropDownList>
                        <%-- <asp:RequiredFieldValidator ID="rfvItemStatus" runat="server" ControlToValidate="drpItemStatus"
                            Display="None" ErrorMessage="Please select Item Status" InitialValue="0" SetFocusOnError="true"
                            ValidationGroup="vsIncidentReview" />
                    </td>
                    <td colspan="4">
                    </td>
                </tr>--%>
               
            </table>
        </td>
    </tr>

    <tr id="trIncident_Review_View" runat="server" visible="false">
        <td width="100%">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td colspan="6">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">What is the incidents root cause? &nbsp;:
                    </td>
                    <%--<td width="1%">
                        :
                    </td>
                    <td colspan="4">
                    </td>--%>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblRoot_Cause_View" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">How can the incident be prevented from happening again? &nbsp;&nbsp;:
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPreventedFromHappening_View" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="3">Who has been tasked with implementing practices/procedures to prevent re-occurrence?
                        &nbsp;&nbsp;:
                    </td>
                    <td valign="top" align="left">
                        <asp:Label ID="lblConfirmation_Assign_To_View" runat="server"></asp:Label>
                    </td>
                    <td valign="top"></td>
                    <td valign="top"></td>
                </tr>
                <tr>
                    <td width="24%" align="left" valign="top">Target Date of Completion&nbsp;
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="25%" valign="top">
                        <asp:Label ID="lblTargetCompletionDate_View" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="center" valign="top">Status Due On&nbsp;&nbsp;&nbsp;&nbsp;:
                    </td>
                    <td width="1%" valign="top"> 
                        :
                    </td>
                    <td width="36%" valign="top" align="left" colspan="2">
                        <asp:Label ID="lblStatusDueOn_View" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td width="24%" align="left" valign="top">Incident Investigation Reviewed &nbsp;
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="25%" valign="top">
                        <asp:Label ID="lblIncidentInvestigation_View" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="center" valign="top">Date Reviewed&nbsp;&nbsp;&nbsp;&nbsp;:
                    </td>
                    <td width="36%" valign="top" align="left" colspan="2">
                        <asp:Label ID="lblDateReceived_View" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left" valign="top">Comments&nbsp;
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="lblComments_View" ControlType="Label" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="left" valign="top">Item Status&nbsp;
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="29%" valign="top">
                        <asp:Label ID="lblItemStatus" runat="server"></asp:Label>
                    </td>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td width="20%" align="left"></td>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Save & Next" 
                            ValidationGroup="vsIncidentReview" onclick="btnSaveNext_Click"/>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSaveView" runat="server" Text="Save & View" />
                        <asp:Button ID="btnAuditTrail_View" runat="server" Text="View Audit Trail" />
                    </td>
                    <td colspan="3"></td>
                </tr>--%>
            </table>
        </td>
    </tr>

    <tr>
        <td>
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                     <td colspan="6" align="left" class="bandHeaderRow" style="height: 10px;">RISK MANAGEMENT REVIEW
                    </td>
                </tr>
                 <tr>
                    <td  align="left" valign="top">
                        Comments&nbsp;<span id="Span6" runat="server" style="color: Red; display: none;">*</span>
                    </td>
                    <td width="1%" valign="top">
                        :
                    </td>
                    <td colspan="4"> &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" valign="top">
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtComments" ControlType="TextBox" />
                        <uc:ctrlMultiLineTextBox runat="server" ID="txtComments_View" ControlType="Label" />
                    </td>
                </tr>
                 <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Was the investigation completed within 7 days of the Date of Loss?  
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="39%" valign="top">
                      <asp:Label runat="server" ID="lblTiming_View" ControlType="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Was a member of the SLT involved in the initial investigation? 
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="20%" valign="top">
                        <asp:Label ID="lblSLTinvolvedInIntialInv" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Were all the facts gathered and presented clearly?
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="39%" valign="top">
                        <asp:Label ID="lblAllFactsClearly" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Were the true root causes identified correctly?  
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="39%" valign="top">
                        <asp:Label ID="lblRootCauseIdentifyCorrect" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Was an action plan implemented to prevent similar incidents from reoccurring?  
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="39%" valign="top">
                        <asp:Label ID="lblActionPlanPreventReoccuring" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Was the action plan effectively communicated to the associates?  
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="39%" valign="top">
                        <asp:Label ID="lblActionPlanCommunicatedtoAssociate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" align="left" valign="top" colspan="4">Investigative Quality Score Metric 
                    </td>
                    <td width="1%" valign="top">:
                    </td>
                    <td width="39%" valign="top">
                        <asp:Label ID="lblInvestigatescoreMetric" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td width="20%" align="left"></td>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnSaveNext" runat="server" Text="Save" 
                            OnClick="btnSaveNext_Click" /> <%--ValidationGroup="vsIncidentReview"--%>
                        <asp:Button ID="btnSavennextHide" runat="server" Text="Save" ValidationGroup="vsIncidentReview"
                            OnClick="btnSavennextHide_Click" Style="display: none" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAuditTrail_Edit" runat="server" Text="View Audit Trail" />
                        <%--<asp:Button ID="btnSaveView" runat="server" Text="Save & View" />--%>
                    </td>
                    <td colspan="3"></td>
                </tr>
            </table>
        </td>
    </tr>


    
</table>
<asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
    Display="None" ValidationGroup="vsIncidentReview" />
<input id="hdnControlIDs" runat="server" type="hidden" />
<input id="hdnErrorMsgs" runat="server" type="hidden" />
