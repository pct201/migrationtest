<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Investigation.aspx.cs"
    Inherits="Exposures_Investigation" Title="eRIMS Sonic :: Exposures :: Investigation" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/InvestigationInfo/InvestigationInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>


<%@ Register Src="~/Controls/Attachments/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>greybox/';
        //OPen Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Investigation.aspx?id=" + '<%=ViewState["PK_Investigation_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function CheckInvestigativeQuality(chkLocComplete) {
            var drpInvestigative = document.getElementById('<%=drpInvestigative.ClientID%>');
            if (drpInvestigative.selectedIndex == 0) {
                alert("Please select [Review]/Investigative Quality");
                return false;
            }
            else {
                return true;
            }
        }

        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "hidden":
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;

                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
        function ValidateFieldsCorrective(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnCorrectiveControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnCorrectiveErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnCorrectiveControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
        function ValidateFieldsReview(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnReviewIDs.ClientID%>').value.split('|');
            var Messages = document.getElementById('<%=hdnReviewErrorMsgs.ClientID%>').value.split('|');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnReviewIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                        default:
                            var Value = $('#' + ctrlIDs[i] + ' input[type=radio]:checked').val();
                            if (Value == "Y" || Value == "N") {
                                bEmpty = false;
                            }
                            else {
                                bEmpty = true;
                            }
                            break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }

        function SetContributioFactorOther() {
            var drpFk_LU_Contributing_Factor = document.getElementById('<%= drpFk_LU_Contributing_Factor.ClientID %>');
            var drpFk_LU_Contributing_Factor_Text = drpFk_LU_Contributing_Factor.options[drpFk_LU_Contributing_Factor.selectedIndex].innerHTML;
            if (drpFk_LU_Contributing_Factor_Text == "Other") {
                document.getElementById('<%= txtContributingFactor_Other.ClientID %>').disabled = false;
                if (document.getElementById('<%= hdnContributingFactor_Other.ClientID %>').value != "") {
                    document.getElementById('<%= txtContributingFactor_Other.ClientID %>').value = document.getElementById('<%= hdnContributingFactor_Other.ClientID %>').value;
                }
            }
            else {
                document.getElementById('<%= hdnContributingFactor_Other.ClientID %>').value = document.getElementById('<%= txtContributingFactor_Other.ClientID %>').value;
                document.getElementById('<%= txtContributingFactor_Other.ClientID %>').disabled = true;
                document.getElementById('<%= txtContributingFactor_Other.ClientID %>').value = "";
            }
        }

        function CheckContributingFactorOther(source, args) {
            var drpFk_LU_Contributing_Factor = document.getElementById('<%= drpFk_LU_Contributing_Factor.ClientID %>');
            var drpFk_LU_Contributing_Factor_Text = drpFk_LU_Contributing_Factor.options[drpFk_LU_Contributing_Factor.selectedIndex].innerHTML;
            if (drpFk_LU_Contributing_Factor_Text == "Other" && document.getElementById('<%= txtContributingFactor_Other.ClientID %>').value.length == 0) {
                args.IsValid = false;
                return;
            }
        }

    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <asp:ValidationSummary ID="valCorrectiveAction" runat="server" ValidationGroup="vsCorrectiveAction"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vsCorrectiveAction2"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="valReview" runat="server" ValidationGroup="vsReview" ShowMessageBox="true"
        ShowSummary="false" HeaderText="Verify the following fields" BorderWidth="1"
        BorderColor="DimGray" CssClass="errormessage" />
    <%--<asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vsReview2"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />--%>
    <asp:ValidationSummary ID="valCauses" runat="server" ValidationGroup="valCauses"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <%--<uc:CtlSonicInfo runat="server" ID="SonicInfo" />--%>
                            <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <asp:Menu ID="mnuProperty" runat="server" DataSourceID="dsPropertyMenu" StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="101%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="InvestigationMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>
                                                            </span>
                                                            <asp:Label ID="MenuAsterisk" runat="server" Text="*" Style="color: Red; display: none"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsPropertyMenu" runat="server" SiteMapProvider="EX-InvestigationMenuProvider"
                                            ShowStartingNode="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSubmitMessage" SkinID="lblError"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                                            <ProgressTemplate>
                                                <div class="UpdatePanelloading" id="divProgress" style="width: 100%; position: fixed;">
                                                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                                                        <tr align="center" valign="middle">
                                                            <td class="LoadingText" align="center" valign="middle">
                                                                <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 5px">&nbsp;
                                    </td>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <asp:Panel ID="pnlIncidentInformation" runat="server" Width="100%">
                                            <div class="bandHeaderRow">
                                                Incident Information
                                            </div>
                                            <asp:UpdatePanel runat="server" ID="updIncidentInfo">
                                                <ContentTemplate>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" runat="server" id="tblIncidentInfo">
                                                        <tr>
                                                            <td align="left" width="18%">Location d/b/a
                                                            </td>
                                                            <td align="center" width="4%">:
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:Label runat="server" ID="lblLocationdbaEdit" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%">Location RM Number
                                                            </td>
                                                            <td align="center" width="4%">:
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:Label runat="server" ID="lblRM_Location_NumberEdit" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Date of Incident
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label runat="server" ID="lblDate_Of_IncidentEdit" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left">Time of Incident
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label runat="server" ID="lblTime_Of_IncidentEdit" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Department
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label runat="server" ID="lblDepartment_Where_OccurredEdit" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left">&nbsp;
                                                            </td>
                                                            <td align="center">&nbsp;
                                                            </td>
                                                            <td align="left">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Date Reported to Sonic
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:Label runat="server" ID="lblDate_Reported_To_SonicEdit" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" width="100%">
                                                                <b>Associate Information</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Name
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblEmployee_NameEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left">Job Title
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblJob_TitleEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Date of Hire
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblHire_DateEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left">Nature of Injury
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblNature_Of_InjuryEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Body Part Affected
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:Label ID="lblBody_Parts_AffectedEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" width="100%">
                                                                <b>Incident Detail</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Incident Description
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td colspan="4">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" width="100%">
                                                                <uc:ctrlMultiLineTextBox runat="server" ID="lblDescription_Of_IncidentEdit" ControlType="label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Safeguards/Safety Equipment Provided
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblSafeguards_ProvidedEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left">Safeguards/Safety Equipment Used
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblSafeguards_UsedEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">Machine Part was involved
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblMachine_Part_InvolvedEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                            <td align="left">Machine Part was defective
                                                            </td>
                                                            <td align="center">:
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblMachine_Part_DefectiveEdit" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" class="Spacer" style="height: 10px;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" width="100%" align="center">
                                                                <asp:Button runat="server" ID="btnInvestigationSave" Text="Save & Next" OnClick="btnInvestigationSave_Click"
                                                                    CausesValidation="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" class="Spacer" style="height: 10px;"></td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlCauses" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Causes
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updCauses">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <b>What were the immediate causes of the accident?</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">SUBSTANDARD BEHAVIORS
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:Repeater ID="rptCauseBehavioursEdit" runat="server">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="50%" align="left">
                                                                                        <%# Container.DataItem.ToString() %>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:RadioButtonList ID="rdoValue" runat="server" SkinID="YesNoTypeNullSelection"
                                                                                            Width="100px" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">SUBSTANDARD CONDITIONS
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <asp:Repeater ID="rptCauseConditionsEdit" runat="server">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="50%" align="left">
                                                                                        <%# Container.DataItem.ToString() %>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:RadioButtonList ID="rdoValue" runat="server" SkinID="YesNoTypeNullSelection"
                                                                                            Width="100px" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="trOtherDesc" style="display: none;">
                                                                <td align="left" colspan="6">
                                                                    <asp:TextBox runat="server" ID="txtCause_42_detail" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCause42" runat="server" ControlToValidate="txtCause_42_detail"
                                                                        ErrorMessage="Please enter the Cause 42 Description" ValidationGroup="valCauses"
                                                                        Display="None" SetFocusOnError="true" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What was the associate doing at the time of incident?&nbsp;<span id="Span2" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtCause_Comment" ControlType="TextBox"
                                                                        MaxLength="4000" ValidationGroup="valCauses" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What are the basic causes that led to the immediate causes above?
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="left">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 50%">PERSONAL FACTORS
                                                                            </td>
                                                                            <td align="left" style="width: 50%">JOB FACTORS
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                <asp:Repeater ID="rptPersonalFactorsEdit" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td width="50%" align="left">
                                                                                                    <%# Container.DataItem.ToString() %>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="rdoValue" runat="server" SkinID="YesNoTypeNullSelection"
                                                                                                        Width="100px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Repeater ID="rptJobFactorsEdit" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td width="50%" align="left">
                                                                                                    <%# Container.DataItem.ToString() %>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="rdoValue" runat="server" SkinID="YesNoTypeNullSelection"
                                                                                                        Width="100px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="trPersonal_Job_Factors_Details" style="display: none;">
                                                                            <td align="left">&nbsp;
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:TextBox runat="server" ID="txtPersonal_Job_Factors_19_Detail" Width="170px"
                                                                                    MaxLength="50"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvJobFactor19Details" runat="server" ControlToValidate="txtPersonal_Job_Factors_19_Detail"
                                                                                    ValidationGroup="valCauses" SetFocusOnError="true" Display="None" ErrorMessage="Please enter Job Factor 19 Description"
                                                                                    Enabled="false" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="left">
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" width="24%">Contributing Factor&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" width="2%">:
                                                                            </td>
                                                                            <td align="left" width="24%">
                                                                                <asp:DropDownList ID="drpFk_LU_Contributing_Factor" runat="server" SkinID="ddlSONIC"
                                                                                    onchange="SetContributioFactorOther();">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" width="24%">Contributing Factor - Other
                                                                            </td>
                                                                            <td align="center" width="2%">:
                                                                            </td>
                                                                            <td align="left" width="24%">
                                                                                <asp:TextBox ID="txtContributingFactor_Other" runat="server" Enabled="false" MaxLength="50" />
                                                                                <asp:HiddenField ID="hdnContributingFactor_Other" runat="server" />
                                                                                <asp:CustomValidator ID="csmvtxtContributingFactor_Other" runat="server" ErrorMessage="Please enter [Causes]/Contributing Factor Other"
                                                                                    ControlToValidate="txtContributingFactor_Other" Display="None" SetFocusOnError="true"
                                                                                    ClientValidationFunction="CheckContributingFactorOther" ValidationGroup="valCauses"
                                                                                    ValidateEmptyText="true" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What could the associate have done differently to avoid the incident?&nbsp;<span
                                                                    id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPersonal_Job_Comment" ControlType="TextBox"
                                                                        MaxLength="4000" ValidationGroup="valCauses" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What is your Conclusion/Impression of how the situation occurred?&nbsp;<span id="Span1"
                                                                    style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtConclusions" ControlType="TextBox"
                                                                        MaxLength="4000" ValidationGroup="valCauses" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">OSHA Recordable&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    <input type="button" value="Start Wizard" onclick="OpenWizardPopup();" style="width: 85px;"
                                                                        class="btn" />
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:Label ID="lblOSHARecordable" runat="server" />
                                                                    <input type="hidden" id="hdnOSHARecordable" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Sonic Cause Code&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:DropDownList runat="server" ID="ddlSonic_Cause_Code">
                                                                                    <asp:ListItem Text="--SELECT--"></asp:ListItem>
                                                                                    <asp:ListItem Text="S0-1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"></asp:ListItem>
                                                                                    <asp:ListItem Text="S0-2-FALL SAME LEVEL OR ELEVATED SURFACE"></asp:ListItem>
                                                                                    <asp:ListItem Text="S0-3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"></asp:ListItem>
                                                                                    <asp:ListItem Text="S0-4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"></asp:ListItem>
                                                                                    <asp:ListItem Text="S0-5-OTHER - NOT CLASSIFIED"></asp:ListItem>
                                                                                    <asp:ListItem Text="S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"></asp:ListItem>
                                                                                    <asp:ListItem Text="S2-FALL SAME LEVEL OR ELEVATED SURFACE"></asp:ListItem>
                                                                                    <asp:ListItem Text="S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"></asp:ListItem>
                                                                                    <asp:ListItem Text="S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"></asp:ListItem>
                                                                                    <asp:ListItem Text="S5-OTHER - NOT CLASSIFIED IN ABOVE CODES"></asp:ListItem>
                                                                                    <asp:ListItem Text="S-1 Denied"></asp:ListItem>
                                                                                    <asp:ListItem Text="S-2 Denied"></asp:ListItem>
                                                                                    <asp:ListItem Text="S-3 Denied"></asp:ListItem>
                                                                                    <asp:ListItem Text="S-4 Denied"></asp:ListItem>
                                                                                    <asp:ListItem Text="S-5 Denied"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <input type="hidden" id="hdnOriginalSonicCode" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Original Sonic S0 Cause Code
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:TextBox ID="txtOriginalSonicCode" runat="server" MaxLength="100" Width="490px"
                                                                        Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Sonic S0 Cause Code Promoted?
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoSonicCodePromoted" runat="server" SkinID="YesNoType"
                                                                        Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Date Sonic S0 Cause Code Promoted
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:TextBox ID="txtDateSonicCodePromoted" runat="server" SkinID="txtDate" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:Button runat="server" ID="btnCausesSaveContinue" Text="Save & Next" OnClick="btnCausesSaveContinue_Click"
                                                                        CausesValidation="true" ValidationGroup="valCauses" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlCorrectiveActions" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Corrective Actions
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updCorrectiveActions">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">Description&nbsp;<span id="Span5" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtCorrective_Action_Description" ControlType="TextBox"
                                                                        MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="740" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">Assigned To&nbsp;<span id="Span6" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox ID="txtAssigned_To" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="18%">Assigned By&nbsp;<span id="Span7" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox ID="txtAssigned_By" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">To Be Completed by&nbsp;<span id="Span8" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtTo_Be_Competed_by" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                    <img alt="To Be Competed by" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTo_Be_Competed_by', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:RangeValidator ID="revTo_Be_Competed_by" ControlToValidate="txtTo_Be_Competed_by"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="To Be Competed by Date is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsCorrectiveAction" Display="none" />
                                                                    <asp:RangeValidator ID="revTo_Be_Competed_by1" ControlToValidate="txtTo_Be_Competed_by"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="To Be Competed by Date is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsCorrectiveAction2" Display="none" />
                                                                </td>
                                                                <td align="left">Status&nbsp;<span id="Span9" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlExposure">
                                                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                                                        <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                                                        <asp:ListItem Text="Pending Capital Approval" Value="Pending Capital Approval"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">Lessons Learned&nbsp;<span id="Span10" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtLessons_Learned" ControlType="TextBox"
                                                                        MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="740" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="3">
                                                                    <asp:CheckBox ID="chkLocInfoComplete" runat="server" Text="Investigation Complete � Ready for RLCM Scoring"
                                                                        onClick="CheckInvestigation();" Visible="false" />
                                                                    <%--onclick="return CheckInvestigativeQuality(this);" --%>
                                                                </td>
                                                                <td align="left">Date Investigation Submitted by Store
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDateInves_Submitted" runat="server" Width="175px" SkinID="txtDisabled"></asp:TextBox>
                                                                    <%--<img alt=" Date Investigation Submitted by Store" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateInves_Submitted', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtDateInves_Submitted"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage=" Date Investigation Submitted by Store is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsCorrectiveAction" Display="none" />
                                                                        <asp:RangeValidator ID="RangeValidator11" ControlToValidate="txtDateInves_Submitted"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage=" Date Investigation Submitted by Store is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsCorrectiveAction2" Display="none" /> --%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:Button ID="btnSave_And_Mail_RLCM" Text="Save & E-Mail to RLCM" runat="server"
                                                                        OnClick="btnSave_And_Mail_RLCM_OnClick" ValidationGroup="vsCorrectiveAction"
                                                                        Width="170px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlReview" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Review 
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updReview">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="25%">Regional Loss Control Manager
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="4%">Cause Codes Reviewed/Approved&nbsp;<span id="Span11" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCause_Reviewed" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                    <img alt="Cause Codes Reviewed/Approved" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCause_Reviewed', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:RangeValidator ID="revCause_Reviewed" ControlToValidate="txtCause_Reviewed"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="[Review]/Approved Date is not valid."
                                                                        runat="server" ValidationGroup="vsReview" Display="none" SetFocusOnError="true" />
                                                                    <asp:RangeValidator ID="revCause_Reviewed12" ControlToValidate="txtCause_Reviewed"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="[Review]/Approved Date is not valid."
                                                                        runat="server" ValidationGroup="vsReview1" Display="none" SetFocusOnError="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Corrective Actions Reviewed/Approved&nbsp;<span id="Span12" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:TextBox runat="server" ID="txtAction_Reviewed" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                    <img alt="Corrective Actions Reviewed/Approved" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAction_Reviewed', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:RangeValidator ID="revAction_Reviewed" ControlToValidate="txtAction_Reviewed"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="[Review]/Approved Date is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsReview" Display="none" />
                                                                    <asp:RangeValidator ID="revAction_Reviewed12" ControlToValidate="txtAction_Reviewed"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="[Review]/Approved Date is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsReview1" Display="none" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">RLCM Comments&nbsp;<span id="Span14" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCMComments" ControlType="TextBox"
                                                                        MaxLength="4000" ValidationGroup="vsReview" Width="740" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Review Completed by RLCM&nbsp;<span id="Span15" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDateReviewCompletedByRLCM" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                                    <%--<img alt="[Review]/Date Review Completed by RLCM" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateReviewCompletedByRLCM', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />--%>
                                                                    <%-- <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtDateReviewCompletedByRLCM" ErrorMessage="[Review]/Date Review Completed by RLCM  is Required"
                                                                        Display="None" SetFocusOnError="true" ValidationGroup="vsReview" ></asp:RequiredFieldValidator>--%>
                                                                    <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtDateReviewCompletedByRLCM"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="[Review]/Date Review Completed by RLCM is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsReview" Display="none" />
                                                                    <asp:RangeValidator ID="RangeValidator22" ControlToValidate="txtDateReviewCompletedByRLCM"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="[Review]/Date Review Completed by RLCM is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsReview1" Display="none" />
                                                                    <asp:CompareValidator ID="cmpReview" runat="server" ValidationGroup="vsReview" Display="None"
                                                                        ErrorMessage="[Review]/Date Review Completed by RLCM should be greater than or euqal to Date Investigation Submitted by Store"
                                                                        ControlToValidate="txtDateReviewCompletedByRLCM" ControlToCompare="txtDateInves_Submitted"
                                                                        SetFocusOnError="true" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                                                                    <asp:CompareValidator ID="cmpReview23" runat="server" ValidationGroup="vsReview1"
                                                                        Display="None" ErrorMessage="[Review]/Date Review Completed by RLCM should be greater than or euqal to Date Investigation Submitted by Store"
                                                                        ControlToValidate="txtDateReviewCompletedByRLCM" ControlToCompare="txtDateInves_Submitted"
                                                                        SetFocusOnError="true" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Incident Review Lag Time (in days)&nbsp;<span id="Span16" style="color: Red; display: none; position: absolute"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtIncidentReviewLagTime" runat="server" SkinID="txtDisabled" Width="170px"
                                                                        ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <b>Investigative Quality Scoring Guidelines</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" width="40%">Was the store�s investigation completed within 7 days of the Date of Loss?
                                                                                &nbsp;<span id="Span18" style="color: Red; position: absolute; display: none" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" width="2%">:
                                                                            </td>
                                                                            <td align="left" width="38%">
                                                                                <asp:RadioButtonList ID="rdbTime" runat="server" ValidationGroup="vsReview" SkinID="YesNoType" onclick="javascript:return CalculateInvestigationQuality();"></asp:RadioButtonList>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvrdlYesNo" runat="server" ControlToValidate="rdbTime"
                                                                                            Display="None" ErrorMessage="Please Select Was the store�s investigation completed within 7 days of the Date of Loss?." 
                                                                                            ValidationGroup="vsReview"></asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">Comments
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineTiming" ControlType="TextBox"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Was a member of the SLT involved in the initial investigation? 
                                                                                &nbsp;<span id="Span20" style="color: Red; position: absolute; display: none" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="rdbSLT" runat="server" ValidationGroup="vsReview" SkinID="YesNoType" onclick="javascript:return CalculateInvestigationQuality();"></asp:RadioButtonList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdbSLT"
                                                                                            Display="None" ErrorMessage="Please Select Was a member of the SLT involved in the initial investigation?" 
                                                                                            ValidationGroup="vsReview" ></asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">Comments
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineSLT" ControlType="TextBox"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Were all the facts of the incident gathered and presented clearly (i.e. incident description, work conditions, witness statements, etc.)? 
                                                                                &nbsp;<span id="Span21" style="color: Red; position: absolute; display: none" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="rdbWitness" runat="server" ValidationGroup="vsReview" SkinID="YesNoType" onclick="javascript:return CalculateInvestigationQuality();"></asp:RadioButtonList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdbWitness"
                                                                                            Display="None" ErrorMessage="Please Select Were all the facts of the incident gathered and presented clearly (i.e. incident description, work conditions, witness statements, etc.)? " 
                                                                                            ValidationGroup="vsReview" ></asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">Comments
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineWitness" ControlType="TextBox"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Were the true root cause(s) identified correctly? 
                                                                                &nbsp;<span id="Span22" style="color: Red; position: absolute; display: none" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="rdbSLTVisit" runat="server" ValidationGroup="vsReview" SkinID="YesNoType" onclick="javascript:return CalculateInvestigationQuality();"></asp:RadioButtonList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdbSLTVisit"
                                                                                            Display="None" ErrorMessage="Please Select Were the true root cause(s) identified correctly?" 
                                                                                            ValidationGroup="vsReview" ></asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">Comments
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineSLTVisit" ControlType="TextBox"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Was an action plan implemented to prevent similar incidents from reoccurring?
                                                                                &nbsp;<span id="Span23" style="color: Red; position: absolute; display: none" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="rdbRoot" runat="server" ValidationGroup="vsReview" SkinID="YesNoType" onclick="javascript:return CalculateInvestigationQuality();"></asp:RadioButtonList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rdbRoot"
                                                                                            Display="None" ErrorMessage="Please Select Was an action plan implemented to prevent similar incidents from reoccurring?" 
                                                                                            ValidationGroup="vsReview" ></asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">Comments
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineRoot" ControlType="TextBox"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Was the action plan effectively communicated to the associates?
                                                                                &nbsp;<span id="Span24" style="color: Red; position: absolute; display: none" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="rdbActionPlan" runat="server" ValidationGroup="vsReview" SkinID="YesNoType" onclick="javascript:return CalculateInvestigationQuality();"></asp:RadioButtonList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdbActionPlan" 
                                                                                            Display="None" ErrorMessage="Please Select Was the action plan effectively communicated to the associates?"
                                                                                            ValidationGroup="vsReview"></asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">Comments
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineActionPlan" ControlType="TextBox"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="left">Investigative Quality Scoring Metric&nbsp;<span id="Span13" style="color: Red; display: none; position: absolute" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpInvestigative" runat="server" SkinID="dropGen" Width="170px" Enabled="false">
                                                                        <asp:ListItem Text="--Select--" Value="" />
                                                                        <asp:ListItem Text="All Pro" Value="All Pro" />
                                                                        <asp:ListItem Text="Starter" Value="Starter" />
                                                                        <asp:ListItem Text="Second String" Value="Second String" />
                                                                        <asp:ListItem Text="Water boy" Value="Water boy" />
                                                                        <asp:ListItem Text="Spectator" Value="Spectator" />
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="3">
                                                                    <asp:CheckBox ID="chkRLCMComplete" runat="server" Text="RLCM Complete" onClick="CheckReview();" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="3">
                                                                    <asp:Button ID="btnSaveReview" Text="Save" runat="server" OnClick="btnSaveReview_OnClick" CausesValidation="true"
                                                                        ValidationGroup="vsReview" />
                                                                    <asp:Button runat="server" ID="btnReviewSave" Text="Save & View" OnClick="btnReviewSave_Click" CausesValidation="true"
                                                                        ValidationGroup="vsReview" />
                                                                    <asp:Button ID="btnEMailto_Distribution_List" Text="E-Mail to Distribution List" ValidationGroup="vsReview" CausesValidation="true"
                                                                        runat="server" OnClick="btnEMailto_Distribution_List_OnClick" Visible="false"
                                                                        Width="190px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlReviewView" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Review
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left">Regional Loss Control Manager
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="25%">Cause Codes Reviewed/Approved
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCause_Codes_Reviewed_Approved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Corrective Actions Reviewed/Approved
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblCorrective_Actions_Reviewed_Approved" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">RLCM Comments
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblRLCM_Comments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Review Completed by RLCM
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblDate_Review_Completed_by_RLCM" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Incident Review Lag Time (in days)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblIncident_Review_LagTime" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Investigative Quality Scoring Metric
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Investigative_Quality" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 5px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:CheckBox ID="chkRLCM_Complete" runat="server" Text="RLCM Complete" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 5px;"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAttachments" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Attachments
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" style="height: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Attachments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlAttachmentDetails ID="CtrlAttachDetails" runat="Server" ModeofPage="EditMode" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <uc:ctrlAttachment ID="CtrlAttachment" runat="Server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" style="width: 100%; display: none;">
                                            <asp:UpdatePanel runat="server" ID="updtview">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnlViewCauses" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Causes
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <b>What were the immediate causes of the accident?</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">SUBSTANDARD BEHAVIORS
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:Repeater ID="rptCauseBehaviours" runat="server">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="50%" align="left">
                                                                                        <%# Eval("Description")%>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <%# Eval("Value") != DBNull.Value ? (Convert.ToBoolean(Eval("Value")) == true ? "Yes" : string.Empty) : string.Empty %>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">SUBSTANDARD CONDITIONS
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <asp:Repeater ID="rptCauseConditions" runat="server">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="50%" align="left">
                                                                                        <%# Eval("Description")%>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <%# Eval("Value") != DBNull.Value ? (Convert.ToBoolean(Eval("Value")) == true ? "Yes" : string.Empty) : string.Empty %>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:Label runat="server" ID="lblCause_42_detail"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What was the associate doing at the time of incident?
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblCause_Comment" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What are the basic causes that led to the immediate causes above?
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="left">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" colspan="2" style="width: 50%">PERSONAL FACTORS
                                                                            </td>
                                                                            <td align="left" colspan="2" style="width: 50%">JOB FACTORS
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="2" valign="top">
                                                                                <asp:Repeater ID="rptPersonalFactors" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td width="70%" align="left">
                                                                                                    <%# Eval("Description")%>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <%# Eval("Value") != DBNull.Value ? (Convert.ToBoolean(Eval("Value")) == true ? "Yes" : string.Empty) : string.Empty %>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </td>
                                                                            <td align="left" colspan="2" valign="top">
                                                                                <asp:Repeater ID="rptJobFactors" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td width="70%" align="left">
                                                                                                    <%# Eval("Description")%>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <%# Eval("Value") != DBNull.Value ? (Convert.ToBoolean(Eval("Value")) == true ? "Yes" : string.Empty) : string.Empty %>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">&nbsp;
                                                                            </td>
                                                                            <td align="left">&nbsp;
                                                                            </td>
                                                                            <td align="left" colspan="2">
                                                                                <asp:Label runat="server" ID="lblPersonal_Job_Factors_19_Detail"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="24%">Contributing Factor
                                                                </td>
                                                                <td align="center" width="2%">:
                                                                </td>
                                                                <td align="left" width="24%">
                                                                    <asp:Label ID="lblContributingFactor" runat="server" />
                                                                </td>
                                                                <td align="left" width="24%">Contributing Factor - Other
                                                                </td>
                                                                <td align="center" width="2%">:
                                                                </td>
                                                                <td align="left" width="24%">
                                                                    <asp:Label ID="lblContributingFactor_Other" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What could the associate have done differently to avoid the incident?
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblPersonal_Job_Comment" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">What is your Conclusion/Impression of how the situation occurred?
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblConclusions" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">OSHA Recordable
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:Label ID="lblOSHARecordableView" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <%--<td align="left" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>--%>
                                                                <td align="left" style="width: 18%">Sonic Cause Code
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label runat="server" ID="lblSonic_Cause_Code">
                                            
                                                                    </asp:Label>
                                                                </td>
                                                                <%--  </tr>
                                                                    </table>
                                                                </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Original Sonic S0 Cause Code
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:Label ID="lblOriginalSonicCode" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Sonic S0 Cause Code Promoted?
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSonicCodePromoted" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Date Sonic S0 Cause Code Promoted
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:Label ID="lblDateSonicCodePromoted" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewCorrectiveActions" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Corrective Actions
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">Description
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblCorrective_Action_Description" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">Assigned To
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblAssigned_To" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%">Assigned By
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblAssigned_By" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">To Be Completed by
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblTo_Be_Competed_by" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">Status
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblStatus" runat="server">
                                        
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">Lessons Learned
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblLessons_Learned" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top"></td>
                                                                <td align="center" valign="top"></td>
                                                                <td align="left" valign="top"></td>
                                                                <td align="left">Date Investigation Submitted by Store
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDateInvestigation_Submitted_View" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewReview" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Review
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="3">Regional Loss Control Manager
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="25%">Cause Codes Reviewed/Approved
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label runat="server" ID="lblCause_Reviewed" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Corrective Actions Reviewed/Approved
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label runat="server" ID="lblAction_Reviewed" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">RLCM Comments
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblRLCMComments_view" ControlType="Label"
                                                                        MaxLength="4000" Width="740" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Review Completed by RLCM
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label ID="lblDateReviewCompletedByRLCM" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Incident Review Lag Time (in days)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label ID="lblIncidentReviewLagTime_View" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <b>Investigative Quality Scoring Guidelines</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" width="40%">Was the store�s investigation completed within 7 days of the Date of Loss?
                                                                            </td>
                                                                            <td align="center" width="2%">:
                                                                            </td>
                                                                            <td align="left" width="38%">
                                                                                <asp:Label ID="lblTiming_View" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="8%">Comments
                                                                                        </td>
                                                                                        <td align="center" width="2%">:
                                                                                        </td>
                                                                                        <td align="left" width="90%">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineTiming_view" ControlType="Label"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Was a member of the SLT involved in the initial investigation? 
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblSLT_View" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="8%">Comments
                                                                                        </td>
                                                                                        <td align="center" width="2% ">:
                                                                                        </td>
                                                                                        <td align="left" width="90%">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineSLT_View" ControlType="Label"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Were all the facts of the incident gathered and presented clearly (i.e. incident description, work conditions, witness statements, etc.)? 
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblWitness_View" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="8%">Comments
                                                                                        </td>
                                                                                        <td align="center" width="2%">:
                                                                                        </td>
                                                                                        <td align="left" width="90%">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineWitness_View" ControlType="Label"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Were the true root cause(s) identified correctly? 
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblSLTVisit_View" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="8%">Comments
                                                                                        </td>
                                                                                        <td align="center" width="2%">:
                                                                                        </td>
                                                                                        <td align="left" width="90%">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineSLTVisit_View" ControlType="Label"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Was an action plan implemented to prevent similar incidents from reoccurring?
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblRootCause_View" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="8%">Comments
                                                                                        </td>
                                                                                        <td align="center" width="2%">:
                                                                                        </td>
                                                                                        <td align="left" width="90%">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineRoot_View" ControlType="Label"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Was the action plan effectively communicated to the associates?
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblActionPlan_View" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" align="left">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="8%">Comments
                                                                                        </td>
                                                                                        <td align="center" width="2%">:
                                                                                        </td>
                                                                                        <td align="left" width="90%">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="CtrlMultiLineActionPlan_View" ControlType="Label"
                                                                                                MaxLength="4000" ValidationGroup="vsCorrectiveAction" Width="700" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Investigative Quality
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblInvestigative" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">RLCM Complete
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="6">
                                                                    <asp:Label ID="lblRLCMComplete" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center">
                                                                    <asp:Button ID="btnEMailto_DistributionView" Text="E-Mail to Distribution List" runat="server"
                                                                        OnClick="btnEMailto_Distribution_List_OnClick" Visible="false" Width="190px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 5px;"></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewAttachments" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Attachments
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" width="18%">Attachments
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4">
                                                                    <uc:ctrlAttachmentDetails ID="CtrlViewAttachDetails" runat="Server" ModeofPage="ViewMode" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%" class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />&nbsp;
                                        <asp:Button ID="btnBack" runat="server" Text="Edit" Visible="false" OnClick="btnBack_Click" />&nbsp;
                                        <asp:Button runat="server" ID="btnAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                            ToolTip="View Audit Trail" CausesValidation="false" />
                                        <asp:Button ID="btnClaimReview" runat="server" Text="Return to Claim Review Worksheet" OnClientClick="history.go(-1);return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        function OpenWizardPopup() {
            GB_showCenter('Investigation Wizard', '<%=AppConfig.SiteURL%>SONIC/FirstReport/InvestigationWzard.aspx?ctrlid=<%=lblOSHARecordable.ClientID%>', 300, 500);
        }

        //used to Hide/Display Perosnal job Fectors description
        function checkPersonal_Job_Fectors(chkID) {
            ctl = document.getElementById(chkID + "_0");
            if (ctl.checked == true) {
                document.getElementById('<%=trPersonal_Job_Factors_Details.ClientID %>').style.display = "block";
                ValidatorEnable(document.getElementById('<%=rfvJobFactor19Details.ClientID%>'), true);
            }
            else {
                document.getElementById('<%=trPersonal_Job_Factors_Details.ClientID %>').style.display = "none";
                ValidatorEnable(document.getElementById('<%=rfvJobFactor19Details.ClientID%>'), false);
            }
        }
        //used to check Other Description
        function checkOtherDesc(chkID) {
            ctl = document.getElementById(chkID + "_0");
            if (ctl.checked == true) {
                document.getElementById('<%=trOtherDesc.ClientID %>').style.display = "block";
                ValidatorEnable(document.getElementById('<%=rfvCause42.ClientID%>'), true);
            }
            else {
                document.getElementById('<%=trOtherDesc.ClientID %>').style.display = "none";
                ValidatorEnable(document.getElementById('<%=rfvCause42.ClientID%>'), false);
            }
        }
        //used to check Incident Information
        function checkIncidentInfo() {
            document.getElementById('<%=tblIncidentInfo.ClientID %>').style.display = "block";
        }
        //Used to set Menu Style
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 4; i++) {
                var tb = document.getElementById("InvestigationMenu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                }

            }
        }
        //Show panel
        function ShowPanel(index) {
            SetMenuStyle(index);
            var op = '<%=strOperation%>';
            var IsUserRegOfficer = '<%=ViewState["bIsUserRLCMOfficer"]%>';

            if (op == "view") {
                document.getElementById("<%=dvEdit.ClientID %>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvView.ClientID %>").style.display = "none";
                //check if index is 1 than display Property Cope Section.
                if (index == 1) {
                    document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlCauses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCorrectiveActions.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReview.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReviewView.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
                }
                //check if index is 2 than display Building Informaiton Section.
                if (index == 2) {
                    document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCauses.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlCorrectiveActions.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReview.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReviewView.ClientID%>").style.display = "none";

                    //if the Contrubuting Factor is other and set enable Disable of textbox according to that.
                    var drpFk_LU_Contributing_Factor = document.getElementById('<%= drpFk_LU_Contributing_Factor.ClientID %>');
                    var drpFk_LU_Contributing_Factor_Text = drpFk_LU_Contributing_Factor.options[drpFk_LU_Contributing_Factor.selectedIndex].innerHTML;
                    if (drpFk_LU_Contributing_Factor_Text == "Other") {
                        document.getElementById('<%= txtContributingFactor_Other.ClientID %>').disabled = false;
                    }
                    else {
                        document.getElementById('<%= txtContributingFactor_Other.ClientID %>').disabled = true;
                        document.getElementById('<%= txtContributingFactor_Other.ClientID %>').value = "";
                    }
                    document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
                }
                //check if index is 3 than display Owner ship Details Section.
                if (index == 3) {
                    document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCauses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCorrectiveActions.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlReview.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReviewView.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
                }
                //check if index is 4 than display CProperty Condition Section.
                if (index == 4) {
                    document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCauses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCorrectiveActions.ClientID%>").style.display = "none";
                    if (IsUserRegOfficer == "False") {
                        document.getElementById("<%=pnlReviewView.ClientID%>").style.display = "block";
                    }
                    else {
                        document.getElementById("<%=pnlReview.ClientID%>").style.display = "block";
                    }
                    document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
                }
                //check if index is 5 than display Attachment Section.
                if (index == 5) {
                    document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCauses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlCorrectiveActions.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReview.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlReviewView.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "block";
                }
            }
        }

        function ShowPanelView(index) {
            //check if index is 1 than display Property Cope Section.
            if (index == 1) {
                document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewCauses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCorrectiveActions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewReview.ClientID%>").style.display = "none";
            }
            //check if index is 2 than display Building Informaiton Section.
            if (index == 2) {
                document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCauses.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewCorrectiveActions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewReview.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAttachments.ClientID%>").style.display = "none";
            }
            //check if index is 3 than display Owner ship Details Section.
            if (index == 3) {
                document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCauses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCorrectiveActions.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewReview.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAttachments.ClientID%>").style.display = "none";
            }
            //check if index is 4 than display CProperty Condition Section.
            if (index == 4) {
                document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCauses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCorrectiveActions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewReview.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewAttachments.ClientID%>").style.display = "none";
            }
            //check if index is 5 than display Attachment Section.
            if (index == 5) {
                document.getElementById("<%=pnlIncidentInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCauses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewCorrectiveActions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewReview.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAttachments.ClientID%>").style.display = "block";
            }
        }

        function ConfirmDelete() {
            return confirm("Are you sure to delete?");
        }

        //        function valCorrectiveAction(bEnabled) {
        //            if (document.getElementById('<%=chkLocInfoComplete.ClientID%>').checked) {
        //                return Page_ClientValidate('vsCorrectiveAction');
        //            }
        //            else {
        //                return Page_ClientValidate('vsCorrectiveAction2');
        //            }
        //        }

        //function valReview()
        //{            
        //    return Page_ClientValidate('vsReview');            
        //}

        //check radiobutton list value. if it is true than related fields are displayed else remains Hidden
        function CheckInvestigation() {

            var ctl = document.getElementById('<%=chkLocInfoComplete.ClientID %>');
            if (ctl.checked == true) {
                document.getElementById('<%=Span5.ClientID %>').style.display = "block";
                document.getElementById('<%=Span6.ClientID %>').style.display = "block";
                document.getElementById('<%=Span7.ClientID %>').style.display = "block";
                document.getElementById('<%=Span8.ClientID %>').style.display = "block";
                document.getElementById('<%=Span9.ClientID %>').style.display = "block";
                document.getElementById('<%=Span10.ClientID %>').style.display = "block";
                if (document.getElementById('<%=txtDateInves_Submitted.ClientID %>').value == '') {
                    var today = new Date();
                    var dd = today.getDate();
                    var mm = today.getMonth() + 1; //January is 0!
                    var yyyy = today.getFullYear();
                    if (dd < 10) { dd = '0' + dd }
                    if (mm < 10) { mm = '0' + mm }
                    document.getElementById('<%=txtDateInves_Submitted.ClientID %>').value = mm + '/' + dd + '/' + yyyy;
                }
            }
            else {
                document.getElementById('<%=Span5.ClientID %>').style.display = "none";
                document.getElementById('<%=Span6.ClientID %>').style.display = "none";
                document.getElementById('<%=Span7.ClientID %>').style.display = "none";
                document.getElementById('<%=Span8.ClientID %>').style.display = "none";
                document.getElementById('<%=Span9.ClientID %>').style.display = "none";
                document.getElementById('<%=Span10.ClientID %>').style.display = "none";
            }
        }

        function CheckReview() {

            var ctl = document.getElementById('<%=chkRLCMComplete.ClientID %>');
            if (ctl.checked == true) {
                document.getElementById('<%=Span11.ClientID %>').style.display = "block";
                document.getElementById('<%=Span12.ClientID %>').style.display = "block";
                document.getElementById('<%=Span13.ClientID %>').style.display = "block";
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!
                var yyyy = today.getFullYear();
                if (dd < 10) { dd = '0' + dd }
                if (mm < 10) { mm = '0' + mm }
                document.getElementById('<%=txtDateReviewCompletedByRLCM.ClientID %>').value = mm + '/' + dd + '/' + yyyy;
            }
            else {
                document.getElementById('<%=Span11.ClientID %>').style.display = "none";
                document.getElementById('<%=Span12.ClientID %>').style.display = "none";
                document.getElementById('<%=Span13.ClientID %>').style.display = "none";

            }
        }
        function CalculateInvestigationQuality() {
            var radioButtons = new Array(6);
            radioButtons[0] = $('#<%=rdbTime.ClientID %> input[type=radio]:checked').val();
            radioButtons[1] = $('#<%=rdbSLT.ClientID %> input[type=radio]:checked').val();
            radioButtons[2] = $('#<%=rdbWitness.ClientID %> input[type=radio]:checked').val();
            radioButtons[3] = $('#<%=rdbSLTVisit.ClientID %> input[type=radio]:checked').val();
            radioButtons[4] = $('#<%=rdbRoot.ClientID %> input[type=radio]:checked').val();
            radioButtons[5] = $('#<%=rdbActionPlan.ClientID %> input[type=radio]:checked').val();
            var search = 'Y';
            var count = 0;
            for (var i = 0; i < radioButtons.length; ++i) {
                if (radioButtons[i] == 'Y')
                    count++;
            }
            switch (count) {
                case 1:
                case 2:
                default:
                    $('#<%=drpInvestigative.ClientID %>').val('Spectator')
                    break;
                case 3:
                    $('#<%=drpInvestigative.ClientID %>').val('Water boy')
                    break;
                case 4:
                    $('#<%=drpInvestigative.ClientID %>').val('Second String')
                    break;
                case 5:
                    $('#<%=drpInvestigative.ClientID %>').val('Starter')
                    break;
                case 6:
                    $('#<%=drpInvestigative.ClientID %>').val('All Pro')
                    break;
            }
        }
    </script>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="valCauses" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsCorrective"
        Display="None" ValidationGroup="vsCorrectiveAction" />
    <input id="hdnCorrectiveControlIDs" runat="server" type="hidden" />
    <input id="hdnCorrectiveErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsReview"
        Display="None" ValidationGroup="vsReview" />
    <input id="hdnReviewIDs" runat="server" type="hidden" />
    <input id="hdnReviewErrorMsgs" runat="server" type="hidden" />
</asp:Content>