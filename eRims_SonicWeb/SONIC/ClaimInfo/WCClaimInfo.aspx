<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCClaimInfo.aspx.cs"
    Inherits="SONIC_WCClaimInfo" Title="eRIMS Sonic :: Claim Information :: Worker's Compensation"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes_Claim/Notes_Claim.ascx" TagName="CtrlMultiLineText_Claim"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICtab/SonicTab.ascx" TagName="CtlSonicTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimTab/ClaimTab.ascx" TagName="CtlClaimTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Claim/Attachment.ascx" TagName="ctlAttchment"
    TagPrefix="Attchment" %>
<%@ Register Src="~/Controls/Attachment_Claim_Details/AttachmentDetails.ascx" TagName="ctlAttchmentDetails"
    TagPrefix="AttchmentDetails" %>
<%@ Register Src="~/Controls/ClaimAttachment/Attachment.ascx" TagName="CtlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimAttachment/AttachmentDetails.ascx" TagName="CtlAttachmentDetail"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicClaimNotes/AdjusterNotes.ascx" TagName="CtrlAdjusterNotes"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicClaimNotes/SonicNotes.ascx" TagName="ctrlSonicNotes"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">
        var CheckChangeVal = false;
        var currIndex = 1;
        function FireAll() {
            if (ValidateRMW())
                return true;
            else
                return false;
        }
        function ValidateRMW() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtDefense_Council_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtDefense_Council_Telephone.ClientID%>').value = "";
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtClaimant_Attorney_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtClaimant_Attorney_Telephone.ClientID%>').value = "";

            //validate page for passed validation group.
            if (Page_ClientValidate("vsWorkSheetGroup")) {
                return true;
            }
            else
                return false;
        }
        function CheckNumericVal(Ctl) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = 0;
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        function OpenWizardPopup(claimId, num) {
            document.getElementById('<%=hdnApprovalVal.ClientID %>').value = num;
            document.getElementById('<%=hdnEmailList.ClientID %>').value = '';
            document.getElementById('<%=hdnEmailDate.ClientID %>').value = '';
            GB_showCenter('', '<%=AppConfig.SiteURL%>SONIC/ClaimInfo/EmailAttachment.aspx?claimId=' + claimId + '&Tbl=wc', 500, 950, ReturnFunction);
        }
        function ReturnFunction() {
            var Ctl = document.getElementById('<%=hdnApprovalVal.ClientID %>').value;
            var EmailList = document.getElementById('<%=hdnEmailList.ClientID %>').value;
            var EMailDate = document.getElementById('<%=hdnEmailDate.ClientID %>').value;
            if (Ctl == 0) {
                if (EmailList != '' && EMailDate != '') {
                    //GM
                    document.getElementById('<%=txtGM_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtGM_Last_Email_Date.ClientID %>').value = EMailDate;
                    //CRM
                    document.getElementById('<%=txtCRM_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtCRM_Last_Email_Date.ClientID %>').value = EMailDate;
                    //RVP
                    document.getElementById('<%=txtRVP_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtRVP_Last_Email_Date.ClientID %>').value = EMailDate;
                    //Corporate Controller
                    document.getElementById('<%=txtCC_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtCC_Last_Email_Date.ClientID %>').value = EMailDate;
                    //DRM
                    document.getElementById('<%=txtDRM_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtDRM_Last_Email_Date.ClientID %>').value = EMailDate;
                    //CFO
                    document.getElementById('<%=txtCFO_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtCFO_Last_Email_Date.ClientID %>').value = EMailDate;
                    //COO
                    document.getElementById('<%=txtCOO_Email_To.ClientID %>').value = EmailList;
                    document.getElementById('<%=txtCOO_Last_Email_Date.ClientID %>').value = EMailDate;

                    if (CheckChangeVal == false)
                        CheckChangeVal = true;
                }
            }
            else {
                var ListCtrl = 'ctl00_ContentPlaceHolder1_txt' + Ctl + '_Email_To';
                var DateCtrl = 'ctl00_ContentPlaceHolder1_txt' + Ctl + '_Last_Email_Date';
                if (EmailList != '') {
                    document.getElementById(ListCtrl).value = EmailList;
                    if (CheckChangeVal == false)
                        CheckChangeVal = true;
                }
                if (EMailDate != '') {
                    document.getElementById(DateCtrl).value = EMailDate;
                    if (CheckChangeVal == false)
                        CheckChangeVal = true;
                }
            }

        }

        function CheckSelectedSonicNotes(buttonType) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicNotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Note(s) to View");
                else
                    alert("Please select Note(s) to Print");

                return false;
            }
            else {
                return true;
            }
        }

        function OnChangeFunction() {
            if (CheckChangeVal == false)
                CheckChangeVal = true;
        }
        function CheckValueChange(Panelid, IndexVal) {
            if (CheckChangeVal == true) {
                if (confirm('Do you want to save your changes before leaving this screen?')) {
                    CheckChangeVal = false;
                    //alert('<%=btnSave.UniqueID %>');
                    document.getElementById('<%=btnSave.ClientID %>').click();
                    //__doPostBack('<%=btnSave.UniqueID %>','OnClick');
                }
                else {
                    CheckChangeVal = false;
                    if (Panelid != null)
                        ShowPanel(Panelid);
                    if (IndexVal != null)
                        ShowPrevNext(IndexVal);
                }
            }
            else {
                if (Panelid != null)
                    ShowPanel(Panelid);
                if (IndexVal != null)
                    ShowPrevNext(IndexVal);
            }
        }
        function TextChange() {
            var arrElements = document.getElementsByTagName('input');
            for (i = 0; i < arrElements.length; i++) {
                if (arrElements[i].type == 'text' && arrElements[i].id.indexOf('txtPageNumber') <= -1)
                    arrElements[i].onchange = OnChangeFunction;
                if (arrElements[i].type == 'textarea')
                    arrElements[i].onchange = OnChangeFunction;
                if (arrElements[i].type == 'radio')
                    arrElements[i].onchange = OnChangeFunction;
            }
            var arrElements_Select = document.getElementsByTagName('select');
            for (i = 0; i < arrElements_Select.length; i++) {
                if (arrElements_Select[i].id.indexOf('CtrlAttachment_Cliam') <= -1 && arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                    arrElements_Select[i].onchange = OnChangeFunction;

            }
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("WCClaimInfoAuditPopup.aspx?id=" + '<%=ViewState["PK_Workers_Comp_RMW"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=0,menubar=0');
            obj.focus();
            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function ShowPrevNext(index) {
            ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
        }

        function ShowPanel(index) {
            currIndex = index;
            SetMenuStyle(index);
            if (index == 1) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "none";
                document.getElementById("btnNext").style.display = "";
            }
            if (index == 2) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "";
            }
            if (index == 3) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "";
            }
            if (index == 4) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "";
            }
            if (index == 5) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "";
                TextChange();
            }
            if (index == 6) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "";
                TextChange();
            }
            if (index == 7) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "none";
                TextChange();
            }
            if (index == 8) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReturnToWork.ClientID%>").style.display = "block";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "none";
                TextChange();
            }
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 8; i++) {
                var tb = document.getElementById("WCMenu" + i);
                if (i == index) {
                    tb.className = "C_LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuSelected'; }
                }
                else {
                    tb.className = "C_LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuStatic'; }
                }

            }
        }
        function ExpandNotes(bExpand, imgPlusId, imgMinusId, txtId) {
            if (bExpand) {
                document.getElementById(txtId).rows = 30;
                document.getElementById(imgMinusId).style.display = "block";
                document.getElementById(imgPlusId).style.display = "none";
            }
            else {
                document.getElementById(txtId).rows = 5;
                document.getElementById(imgMinusId).style.display = "none";
                document.getElementById(imgPlusId).style.display = "block";
            }
        }

        function ValidateFieldsClaimInfo(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsClaimInfo.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsClaimInfo.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsClaimInfo.ClientID%>').value != "") {
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

        function ValidateFieldsRMW(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsRMW.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsRMW.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsRMW.ClientID%>').value != "") {
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

        jQuery(function ($) {
            $("#<%=txtDateRestrictedWorkBegan.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateRestrictedWorkEnd.ClientID%>").mask("99/99/9999");
            $("#<%=txtResignation_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtTrial_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtGM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtGM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCRM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCRM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtRVP_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtRVP_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCC_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCC_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtDRM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtDRM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCFO_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCFO_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCOO_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCOO_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtMediation_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtClaimant_Attorney_Telephone.ClientID%>").mask("999-999-9999");
            $("#<%=txtDefense_Council_Telephone.ClientID%>").mask("999-999-9999");
        });
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Risk Management Worksheet Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsWorkSheetGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Attachment:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="AddAttachment1" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Attachment:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Comments/Attachment Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="AddClaimAttachment" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="valWCClaim" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsWCClaimGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlClaimTab runat="server" ID="ClaimTab" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                            <asp:HiddenField runat="Server" ID="hdnApprovalVal" />
                            <asp:HiddenField runat="Server" ID="hdnEmailList" />
                            <asp:HiddenField runat="Server" ID="hdnEmailDate" />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel runat="Server" ID="updSonic" UpdateMode="Always">
                                <ContentTemplate>
                                    <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                        border="0">
                                        <tbody>
                                            <tr class="PropertyInfoBG">
                                                <td style="width: 13%" align="left">
                                                    <asp:Label ID="lblHeaderClaimNumber" runat="server" Text="Claim Number"></asp:Label>
                                                </td>
                                                <td style="width: 16%" align="left">
                                                    <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                                </td>
                                                <td style="width: 13%" id="tdHeaderName" align="left" runat="server">
                                                    <asp:Label ID="lblHeaderName" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td style="width: 13%" align="left">
                                                    <asp:Label ID="lblHeaderDateIncident" runat="server" Text="Date of Incident"></asp:Label>
                                                </td>
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderAssociatedFirstReport" runat="server" Text="Associated First Report"></asp:Label>
                                                </td>
                                                <td style="width: 10%" align="left">
                                                    <asp:Label ID="lblHeaderInvestigation" runat="server" Text="Investigation"></asp:Label>
                                                </td>
                                                <td style="width: 17%" align="left">
                                                    <asp:Label ID="lblCompanionClaim" runat="server" Text="Companion Claim(s)"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: white">
                                                <td align="left">
                                                    <asp:Label ID="lblClaimNumber" runat="server">&nbsp;</asp:Label>
                                                    <asp:LinkButton ID="lnkClaimReviewNumber" runat="server" Visible="false" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                                                </td>
                                                <td id="tdName" align="left" runat="Server">
                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDateIncident" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkAssociatedFirstReport" runat="server" OnClick="lnkAssociatedFirstReport_Click"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkInvestigation" runat="server" /><asp:LinkButton ID="lnkAddInvestigation"
                                                        runat="server" Text="Add New" />
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlCompanionClaim">
                                                    </asp:DropDownList>
                                                    <a id="lnkClaim" runat="server"></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <span id="WCMenu1" onclick="javascript:CheckValueChange(1,null);">Claim Identification</span>&nbsp;<span
                                                        id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu2" href="#" onclick="javascript:CheckValueChange(2,null);">Financial</span>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu3" href="#" onclick="javascript:CheckValueChange(3,null);">Transactions</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu8" href="#" onclick="javascript:CheckValueChange(8,null);">Return To
                                                        Work</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu4" href="#" onclick="javascript:CheckValueChange(4,null);">Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td nowrap="nowrap">
                                                    <span id="WCMenu5" href="#" onclick="javascript:CheckValueChange(5,null);">Risk Management
                                                        Worksheet</span>&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red; display: none">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu6" href="#" onclick="javascript:CheckValueChange(6,null);">Sonic Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu7" href="#" onclick="javascript:CheckValueChange(7,null);">Attachment</span>
                                                </td>
                                            </tr>
                                        </table>
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
                                                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
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
                                    <td width="5px">&nbsp;
                                    </td>
                                    <td width="794px" valign="top" class="dvContainer" style="height: 205px;">
                                        <div id="dvView" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlClaimIdentification" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Date of Update
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblDateofUpdate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">Data Source
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblDataSource" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Employee Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claim Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimNumber2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Claimant First Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimantFirstName" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Associated First Report
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAssociatedFirstReport" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Claimant Last Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimantLastName" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Key Claim Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblKeyClaimNumber" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Employee Street
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeStreet" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claimant Sequence Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimantSequenceNumber" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Employee City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeCity" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Employee Gender
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeGender" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Employee State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeState" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Employee SSN
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeSSN" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Employee Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeZip" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Employee Marital Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeMaritalStatus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofBirth" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>State of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStateofAccident" runat="server"></asp:Label>
                                                        </td>
                                                        <td>State of Jurisdiction
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStateofJurisdiction" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofAccident" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Reported to Insurer
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateReportedtoInsurer" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Claim Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimStatus" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claim Sub Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaim_Sub_Status" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Time of Loss
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTimeofLoss" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date Entered
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateEntered" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Closed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateClosed" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Location Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLocationCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Coverage Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoverageCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Lawsuit Y/N
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLawSuitYN" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Suit Filed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateSuitFiled" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Suit Type Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSuitTypeCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Suit Result Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSuitResultCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Plaintiff Attorney Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPlaintiffAttorneyCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>TPA Policy Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTPAPolicyNumber" runat="server"></asp:Label>
                                                        </td>
                                                        <td>TPA Policy Begin Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTPAPolicyBeginDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>TPA Policy End Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTPAPolicyEndDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Carrier Policy Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCarrierPolicyNumber" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Carrier Policy Begin Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCarrierPolicyBeginDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Carrier Policy End Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCarrierPolicyEndDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date Disability Began
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateDisabilityBegan" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date of Return to Work
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofReturntoWork" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date of Maximum Medical Imrovement
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofMaximumMedicalImrovement" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Surgery Y/N
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSurgeryYN" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Claimant Attorney/Representative Y/N
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimantAttorneyRepresentativeYN" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Controverted Case Y/N
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblControvertedCaseYN" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date Appeals Application Applied
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateAppealsApplicationApplied" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date of Attorney Disclosure
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofAttorneyDisclosure" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Year Last Exposed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblYearLastExposed" runat="server"></asp:Label>
                                                        </td>
                                                        <td>NCCI Occupation Class Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNCCIOccupationClassCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Compensation Coverage Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCompensationCoverageCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Beneficiary’s Relationship
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBeneficiarysRelationship" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Beneficiary Dependency
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBeneficiaryDependency" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Beneficiary 1 Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBeneficiary1DateofBirth" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Beneficiary 2 Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBeneficiary2DateofBirth" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Beneficiary 3 Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBeneficiary3DateofBirth" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Beneficiary 4 Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBeneficiary4DateofBirth" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Occupation Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOccupationDescription" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claim Status Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimStatusDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Cause of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCauseofInjuryCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Nature of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNatureofInjuryCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Part of Body Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartofBodyCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Cause/Injury/Body Part Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCauseInjuryBodyPartDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>LT/MED only Indicator
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLTMEDonlyIndicator" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date of Hire
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofHire" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>State of Employment
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStateofEmployment" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Nature of Benefit Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNatureofBenefitCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Number of Dependents
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberofDependents" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Percentage of Impairment
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPercentageofImpairment" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Accident City/Town
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccidentCityTown" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Zip code of Accident Site
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblZipcodeofAccidentSite" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date Reported to Employer
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateReportedtoEmployer" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date of First Indemnity Payment
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofFirstIndemnityPayment" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date of Death
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofDeath" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Employment Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmploymentStatus" runat="server"></asp:Label>
                                                        </td>
                                                        <td>NCCI Cause of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNCCICauseofInjuryCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>NCCI Body Part Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNCCIBodyPartCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>NCCI Nature of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNCCINatureofInjuryCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Previous TPA Claim Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreviousTPAClaim" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Adjustor Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAdjustorCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date Restricted Work Began&nbsp;<span id="Span1" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDateRestrictedWorkBegan" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="120px"></asp:TextBox>
                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtDateRestrictedWorkBegan.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                alt="Date Restricted Work Began" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtDateRestrictedWorkBegan"
                                                                ValidationGroup="vsWCClaimGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date Restricted Work Began is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                        <td>Date Restricted Work Ended&nbsp;<span id="Span2" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDateRestrictedWorkEnd" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="120px"></asp:TextBox>
                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtDateRestrictedWorkEnd.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                alt="Date Restricted Work Ended" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtDateRestrictedWorkEnd"
                                                                ValidationGroup="vsWCClaimGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date Restricted Work Ended is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                            <asp:CompareValidator ID="cmpRestrictedWorkDate" runat="server" ControlToCompare="txtDateRestrictedWorkBegan"
                                                                ControlToValidate="txtDateRestrictedWorkEnd" Type="Date" Display="None" ErrorMessage="Date Restricted Work End must be grater than Date Restricted Work Began"
                                                                Operator="GreaterThanEqual" ValidationGroup="vsWCClaimGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <b>Claim Status Denial Information</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Processing Office&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblProcessingOffice" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Status Change Date&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStatusChangeDate" runat="server"></asp:Label>
                                                            <%--<asp:TextBox ID="txtStatusChangeDate" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="120px"></asp:TextBox>
                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtStatusChangeDate.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                alt="Status Change Date Work Began" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                            <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtStatusChangeDate"
                                                                ValidationGroup="vsWCClaimGroup" ClientValidationFunction="CheckDate" ErrorMessage="Status Change Date is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Status&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Sub Status&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSubStatus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Reopen&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReopen" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Sub Status Reason for Denial or Termination Code&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReason1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Sub Status Reason for Denial or Termination Code 2&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReason2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Sub Status Reason for Denial or Termination Code 3&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReason3" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Sub Status Reason for Denial or Termination Code 4&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReason4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Sub Status Reason for Denial or Termination Code 5&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReason5" runat="server"></asp:Label>
                                                            
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnSaveWCClaim" runat="server" Text="Save" Width="90px" OnClick="btnSaveWCClaim_Click"
                                                                ValidationGroup="vsWCClaimGroup" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlFinancial" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Indemnity</b>
                                                        </td>
                                                        <td align="center" width="4%"></td>
                                                        <td width="26%"></td>
                                                        <td align="left" width="20%">
                                                            <b>Expense</b>
                                                        </td>
                                                        <td align="center" width="4%"></td>
                                                        <td width="26%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityGrossPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Gross Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblExpenseGrossPaid" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Net Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNetIndemnityPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Net Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNetExpensePaid" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Net Recovered
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityNetRecovered" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Net Recovered
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblExpenseNetRecovered" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Total Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityIncurred" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Total Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblExpenseIncurred" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Outstanding
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityOutstanding" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Outstanding
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblExpenseOutstanding" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Recovered Indemnity Deductible Amount
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRecoveredIndemnityDeductibleAmount" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Legal Expense Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLegalExpenseIncurred" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Non-Scheduled Indemnity Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNonScheduledIndemnityIncurred" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Legal Expense Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLegalExpensePaidtoDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                        <td>Recovered Expense Deductible Amount
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRecoveredExpenseDeductibleAmount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Medical</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                        <td>Employee Legal Expense Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeLegalExpensePTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMedicalGrossPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <strong>Indemnity Subrogation</strong>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Net Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNetMedicalPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Gross
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityGrossSubrogation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Net Recovered
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMedicalNetRecovered" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Expense
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnitySubrogationExpense" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Total Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMedicalIncurred" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Gross Salvage
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityGrossSalvage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Outstanding
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMedicalOutstanding" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Salvage Expense
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnitySalvageExpense" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Recovered Medical Deductible Amount
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRecoveredMedicalDeductibleAmount" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;Indemnity Gross Refund
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIndemnityGrossRefund" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Gross Subrogation
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMedicalGrossSubrogation" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <strong>Vocational Rehabilitation</strong>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Gross Refund
                                                        </td>
                                                        <td align="center"></td>
                                                        <td>
                                                            <asp:Label ID="lblMedicalGrossRefund" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Expense Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVocaRehabExpensePTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Total Payments to Physicians
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTotalPaymentToPhysicians" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Maintenance Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVocaRehabMaintenancePTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Hospital Expenses Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblHospitalExpensesPaidToDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Evaluation Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVocaRehabEvaluationPTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Other Medical Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOtherMedicalPaidtoDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Education Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVocaRehabEducationPTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>ALE</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                        <td>Other Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOtherVocaRehabExpensesPTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Subrogation
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAleGrossSubrogation" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Expense Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVocaRehabExpenseIncurred" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Salvage
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAleGrossSalvage" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Refund
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAleGrossRefund" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Lump Sum Settlement Amount
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLumpSumSettlementAmount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Refund Expense
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAleRefundExpense" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Funeral Expenses Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblFuneralExpensePTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Previous TPA</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                        <td>Non-Scheduled Impairment Percent
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNonScheduledImpairmentPercent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Indemnity Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreviousTPAIndemnityPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claim Subrogation Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimSubrogationPaidtoDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreviousTPAMedicalPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Employers Liability Paid to Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployersLiabilityPTD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Expense Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreviousTPAExpensePaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Temporary Indemnity Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTemporaryIndemnityIncurred" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlTransactions" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="Server" ID="updTrans" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        Click For Detail
                                                        <br />
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="45%"></td>
                                                                <td valign="top" align="right">
                                                                    <uc:ctrlPaging ID="ctrlPageTransaction" runat="server" OnGetPage="GetPage" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <br></br>
                                                        <div id="divTransactionList" style="width: 99%; height: 200px; overflow-y: scroll; border: solid 1px #000000;">
                                                            <asp:GridView ID="gvWCTransList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvWCTransList_RowCommand" OnRowDataBound="gvWCTransList_RowDataBound" Width="98%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTransaction_Entry_date" runat="server" CommandArgument='<%#Eval("PK_Claims_Transactions_ID")%>' CommandName="View">
                                                                        <%#Eval("Transaction_Entry_date")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Transaction_Nature_of_Benefit_Desc" HeaderText="Transaction Type" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                                                                    <asp:BoundField DataField="Payee_Name1" HeaderText="Payee" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                                                                    <asp:BoundField DataField="Nature_of_Payment_Statement" HeaderText="Nature Of Payment" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <%# string.Format("{0:C2}",Eval("Transaction_Amount"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField HeaderText="Amount" DataField="Transaction_Amount" DataFormatString="$ {0:C2}" ItemStyle-HorizontalAlign="Right" />--%>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="center" style="border: 1px solid #cccccc;" width="100%">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                        <asp:Panel ID="pnlTransactionDetail" runat="server" Visible="false" Width="100%">
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td width="20%">Date </td>
                                                                    <td width="4%">: </td>
                                                                    <td width="26%">
                                                                        <asp:Label ID="lblTransactionEntrydate" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">Data Source </td>
                                                                    <td width="4%">: </td>
                                                                    <td width="26%">
                                                                        <asp:Label ID="lblDataOrigin" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee Name 1 </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeName1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Key Claim Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblOriginKeyClaimNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee Name 2 </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeName2" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Claimant Sequence Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblClaimantSequenceNumber3" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee Name 3 </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeName3" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Policy Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPolicyNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee Street_Address </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeStreetAddress" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Carrier Policy Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCarrierpolicynumber2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee City </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeCity" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee State </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeState" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Transaction Amount </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTransactionAmount" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee Zip </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeZip" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Transaction Sequence Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTransactionSequenceNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Payee ID </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPayeeID" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Claim Status </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblClaimStatus2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Entry Code </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblEntryCode" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Entry Code Modiifer </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblEntryCodeModifier" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Nature of Benefit </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblNatureofBenefitCode2" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Transaction Nature of Benefit </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTransactionNatureofBenefit" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Nature of Payment Statement </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblNatureofPaymentStatement" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Check Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCheckNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>SRS Recovery Office Code </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSRSRecoveryOfficeCode" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Check Issue Date </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCheckIssueDate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>SRS Draft Issue Office Code </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSRSDraftIssueOfficeCode" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Recovery Sequence Number </td>
                                                                    <td>: </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRecoverySequenceNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        </br>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlReturnToWork" runat="server">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Effective Date
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td width="26%">
                                                            <asp:Label ID="lblEffectiveDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td width="20%"></td>
                                                        <td align="center" width="4%"></td>
                                                        <td width="26%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Work Status Type
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWorkStatusType" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Authorized Off Work?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAuthorizedOffWork" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Last Worked
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLastWorked" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Last Worked Was a Full Day?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLastWorkedFullDay" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Examiner Anticipates Return to Work Full Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblExaminerAnticipatesFullDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Examiner Anticipates Return to Work Restricted Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblExaminerAnticipatesRestrictedDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Case Manager Anticipates Return to Work Full Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCaseManagerAnticipateFullDay" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Case Manager Anticipates Return to Work Restricted Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCaseManagerAnticipateRestrictedDay" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Physician Anticipates Return to Work Full Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPhysicianAnticipatesFullDay" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Physician Anticipates Return to Work Restricted Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPhysicianAnticipatesRestrictedDay" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Moderate Duty Available?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblModerateDutyAval" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Modified Duty Available
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateModifiedDutyAval" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Moderate Duty Offered?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblModerateDutyOffered" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Modified Duty Offered
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateModifiedDutyOffered" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Moderate Duty Accepted?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblModerateDutyAccepted" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Date Modified Duty Accepted
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateModifiedDutyAccepted" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Modified Duty Occupation
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblModifiedDutyOccupation" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Modified Duty Demand
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblModifiedDutyDemand" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Notified
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateNotified" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Full Days Worked on Modified Duty?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblFullDaysModifiedDuty" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Hours Worked on Modified Duty
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblHoursModifiedDuty" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Return to Work Occupation
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRTWOccupation" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Return to Work Demand
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRTWDemand" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Return to Work Schedule
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:Label ID="lblRTWSchedule" runat="server"></asp:Label>
                                                        </td>
                                                        <%--<td>
                                                         
                                                        </td>
                                                        <td align="center">
                                                           
                                                        </td>
                                                        <td>
                                                           
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Disability Began
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDisabilityBegan" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Number of Lost Time Days
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberLostTimeDays" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Number of Restricted Work Days
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberRestrictedWorkDays" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Reason for Termination
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblReasonForTermination" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlNotes" runat="server" Width="100%">
                                                <table cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:CtrlAdjusterNotes ID="ucAdjusterNotes" runat="server" CurrentClaimType="WC" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlRiskManagementWorksheet" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Claim Number
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblOrigin_Claim_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">Date of Incident
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblDate_of_Accident" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Employee First Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblClaimant_First_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Employee Last Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblClaimant_Last_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployee_Date_of_Birth" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Date of Hire
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_of_Hire" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Reported to Employer
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Reported_To_Employer" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Date Reported to Insurer
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Reported_To_Insurer" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblState_Of_Accident" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Part of Body Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblFK_Part_of_Body_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Cause/Injury/Body Part Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCause_Injury_Body_Part_Description" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Status
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Nature of Injury Code
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblFK_Nature_of_Injury_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">Surgery Y/N
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblSurgery_Indicator" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Disability Began
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Disability_Began" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Date Return to Work
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Return_To_Work" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Percentage of Impairment
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPercentage_Impairment" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Cause of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblFK_Cause_of_Injury_Code" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Claim Status Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblClaim_Status_Description" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Date of Maximum Medical Improvement
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_of_Max_Medical_Improvement" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">NCCI Occupation Class Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblFK_NCCI_Occupation_Class_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Reserves and Payments
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>Indemnity</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>Medical</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>Expenses</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>Total</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Reserve</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblIndemnity_Incurred"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblMedical_Incurred"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblExpense_Incurred"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblTotal_Reserve"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Paid</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblIndemnity_Gross_Paid"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblMedical_Gross_Paid"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblExpense_Gross_Paid"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblTotal_Paid"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Outstanding</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblIndemnity_Outstanding"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblMedical_Outstanding"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblExpense_Outstanding"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblTotal_Outstanding"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Settlement Request
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%" valign="top">Settlement Method&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:CtrlMultiLineText_Claim ID="txtSettlement_Method" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">Policy Deductible&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">$
                                                            <asp:TextBox runat="server" ID="txtPolicy_Deductible" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%">&nbsp;
                                                        </td>
                                                        <td align="left" width="26%">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Classification
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Compensation Originally Denied?
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:RadioButtonList runat="server" ID="rdoCompensation_Originally_Denied" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="20%">L/S Reimbursement of Cost?
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:RadioButtonList runat="server" ID="rdoLS_Reimbursement_Of_Cost" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Waive Subrogation?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoWaive_Subrogation" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Close Medicals?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoClose_Medicals" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Confidentiality Clause?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoConfidentiality_Clause" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Other Medicals?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoOther_Medicals" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Settlement of Permanent Total?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoSettlement_of_Permanent_Total" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Resignation?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoResignation" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Other?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoOther_Classification" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Resignation Date&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtResignation_Date" runat="server"></asp:TextBox>
                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtResignation_Date', 'mm/dd/y',OnChangeFunction);"
                                                                alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                            <asp:CustomValidator ID="cvResignation_Date" runat="server" ControlToValidate="txtResignation_Date"
                                                                ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Resignation is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Legal
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Defense Council’s Name&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:TextBox runat="server" ID="txtDefense_Council_Name" MaxLength="75"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="20%">Defense Council’s Telephone &nbsp;<span id="Span6" style="color: Red; display: none;"
                                                            runat="server">*</span><br />
                                                            (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:TextBox runat="server" ID="txtDefense_Council_Telephone" MaxLength="12"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revDefense_Council_Telephone" ControlToValidate="txtDefense_Council_Telephone"
                                                                runat="server" ValidationGroup="vsWorkSheetGroup" ErrorMessage="Please Enter Council’s Telephone in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Claimant’s Attorney&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtClaimant_Attorney" MaxLength="75"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Claimant’s Attorney Telephone&nbsp;<span id="Span8" style="color: Red; display: none;"
                                                            runat="server">*</span><br />
                                                            (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtClaimant_Attorney_Telephone" MaxLength="12"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revClaimant_Attorney_Telephone" ControlToValidate="txtClaimant_Attorney_Telephone"
                                                                runat="server" ValidationGroup="vsWorkSheetGroup" ErrorMessage="Please Enter Claimant’s Attorney Telephon in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Trial Date&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTrial_Date" runat="server"></asp:TextBox>
                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTrial_Date', 'mm/dd/y',OnChangeFunction);"
                                                                alt="Trial_Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                            <asp:CustomValidator ID="cvTrial_Date" runat="server" ControlToValidate="txtTrial_Date"
                                                                ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Trial is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                        <td align="left">Mediation Date&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtMediation_Date" runat="server"></asp:TextBox>
                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtMediation_Date', 'mm/dd/y',OnChangeFunction);"
                                                                alt="Mediation Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                            <asp:CustomValidator ID="cvMediation_Date" runat="server" ControlToValidate="txtMediation_Date"
                                                                ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Mediation is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Settlement Approvals
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Demand Amount (PA)&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">$
                                                            <asp:TextBox runat="server" ID="txtDemand_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="20%">Requested Amount (ADJ)&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">$
                                                            <asp:TextBox runat="server" ID="txtADJ_Requested_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Requested Amount (RM)&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">$
                                                            <asp:TextBox runat="server" ID="txtRM_Requested_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Authorized Amount (SAI)&nbsp;<span id="Span14" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">$
                                                            <asp:TextBox runat="server" ID="txtAuthorized_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Potential Total Exposure&nbsp;<span id="Span15" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">$
                                                            <asp:TextBox runat="server" ID="txtPotential_Total_Exposure" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Settled?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoSettled" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Settled Amount&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">$
                                                            <asp:TextBox runat="server" ID="txtSettled_Amount" onKeyPress="OnChangeFunction(); return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Full & Final Clincher?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoFullFinalClincher" runat="server" SkinID="YesNoType" />
                                                        </td>
                                                        <td colspan="3">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Approvals
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6">
                                                            <a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,0);">Email ALL</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">GM
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'GM');">Email GM</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtGM_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtGM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtGM_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="GM Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtGM_Last_Email_Date" runat="server" ControlToValidate="txtGM_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup">
                                                                        </asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvGM_Last_Email_Date" runat="server" ControlToValidate="txtGM_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="GM Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoGM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">GM Response Date&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtGM_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtGM_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="GM Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtGM_Response_Date" runat="server" ControlToValidate="txtGM_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(GM Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvGM_Response_Date" runat="server" ControlToValidate="txtGM_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="GM Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">CRM
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'CRM');">Email CRM--</a>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCRM_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtCRM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCRM_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CRM Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCRM_Last_Email_Date" runat="server" ControlToValidate="txtCRM_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCRM_Last_Email_Date" runat="server" ControlToValidate="txtCRM_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CRM Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoCRM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">CRM Response Date&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCRM_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCRM_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CRM Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCRM_Response_Date" runat="server" ControlToValidate="txtCRM_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(CRM Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCRM_Response_Date" runat="server" ControlToValidate="txtCRM_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CRM Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">RVP
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'RVP');">Email RVP</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtRVP_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtRVP_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRVP_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="RVP Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtRVP_Last_Email_Date" runat="server" ControlToValidate="txtRVP_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvRVP_Last_Email_Date" runat="server" ControlToValidate="txtRVP_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="RVP Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoRVP_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">RVP Response Date&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtRVP_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRVP_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="RVP Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtRVP_Response_Date" runat="server" ControlToValidate="txtRVP_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(RVP Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvRVP_Response_Date" runat="server" ControlToValidate="txtRVP_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="RVP Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">Corporate Controller
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'CC');">Email Corporate
                                                                            Controller</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCC_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtCC_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCC_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CC Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCC_Last_Email_Date" runat="server" ControlToValidate="txtCC_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCC_Last_Email_Date" runat="server" ControlToValidate="txtCC_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CC Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoCC_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">Corporate Controller Response Date&nbsp;<span id="Span27" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCC_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCC_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CC Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCC_Response_Date" runat="server" ControlToValidate="txtCC_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid( Corporate Controller Response Date)" Display="none"
                                                                            ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCC_Response_Date" runat="server" ControlToValidate="txtCC_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CC Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">DRM
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'DRM');">Email DRM</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtDRM_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtDRM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDRM_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="DRM Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:CustomValidator ID="cvDRM_Last_Email_Date" runat="server" ControlToValidate="txtDRM_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="DRM Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoDRM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">DRM Response Date&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDRM_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDRM_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="DRM Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:CustomValidator ID="cvDRM_Response_Date" runat="server" ControlToValidate="txtDRM_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="DRM Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">CFO
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'CFO');">Email CFO</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCFO_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtCFO_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCFO_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CFO Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:CustomValidator ID="cvCFO_Last_Email_Date" runat="server" ControlToValidate="txtCFO_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CFO Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoCFO_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">CFO Response Date&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCFO_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCFO_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CFO Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:CustomValidator ID="cvCFO_Response_Date" runat="server" ControlToValidate="txtCFO_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CFO Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">COO
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%;">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["WC_CI_ID"] %>,'COO');">Email COO</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCOO_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtCOO_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCOO_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="COO Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:CustomValidator ID="cvCOO_Last_Email_Date" runat="server" ControlToValidate="txtCOO_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="COO Last Email Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoCOO_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">COO Response Date&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCOO_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCOO_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="COO Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:CustomValidator ID="cvCOO_Response_Date" runat="server" ControlToValidate="txtCOO_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="COO Response Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%" valign="top">Comments&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td colspan="4" valign="top">
                                                            <uc:CtrlMultiLineText_Claim ID="txtComments" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr class="bandHeaderRow">
                                                        <td colspan="6">Attachment
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <Attchment:ctlAttchment ID="ctlAttchment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <AttchmentDetails:ctlAttchmentDetails ID="ctlAttchmentDetails" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" Width="90px" ID="btnSave" Text="Save" OnClick="btnSave_Click"
                                                                CausesValidation="true" ValidationGroup="vsWorkSheetGroup" />
                                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail"
                                                                OnClientClick="javascript:return AuditPopUp();" Visible="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Label runat="server" ID="lblErrorWorksheet" ForeColor="red" EnableViewState="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlSonicNotes" runat="server" Style="display: none;">
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotes" runat="server" IsAddVisible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<div class="bandHeaderRow">
                                                    Sonic Notes</div>--%>
                                                <%--<table cellpadding="3" cellspacing="1" border="0" width="100%">                                                
                                                    <tr>
                                                        <td valign="top" style="width: 15%">
                                                            Sonic Notes Grid<br />
                                                            <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                                OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 3%">
                                                            :
                                                        </td>
                                                        <td style="margin-left: 40px" style="width: 650px" align="left">
                                                            <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                OnRowCommand="gvNotes_RowCommand">
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectNoteHeader();" />
                                                                            <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_Claim_Notes") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Note Date">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="80px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="User">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="100px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Notes">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Remove">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                                Width="80px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <asp:Button ID="btnView" runat="server" Text=" View " OnClick="btnView_Click" OnClientClick="return CheckSelectedSonicNotes('View');" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click"
                                                                OnClientClick="return CheckSelectedSonicNotes('Print');" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAttachment" runat="server">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td>
                                                            <uc:CtlAttachment ID="CtrlAttachment_Cliam" runat="server" ValidationGroup="AddAttachment1" />
                                                        </td>
                                                    </tr>
                                                    <uc:CtlAttachmentDetail ID="CtlAttachDetail_Cliam" runat="server" IntAttachmentPanel="6" />
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="right" width="50%">
                                        <input type="button" id="btnPrev" style="font-weight: bold; color: #000080;" value="Previous"
                                            onclick="javascript: CheckValueChange(null, -1);" />
                                    </td>
                                    <td align="left" width="50%">
                                        <input type="button" id="btnNext" style="font-weight: bold; color: #000080;" value=" Next "
                                            onclick="javascript: CheckValueChange(null, 1);" />
                                        <asp:Button ID="btnClaimReview" runat="server" Text="Return to Claim Review Worksheet" OnClientClick="history.go(-1);return false;" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidatorClaimInfo" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsClaimInfo" Display="None" ValidationGroup="vsWCClaimGroup" />
    <input id="hdnControlIDsClaimInfo" runat="server" type="hidden" />
    <input id="hdnErrorMsgsClaimInfo" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorRMW" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsRMW"
        Display="None" ValidationGroup="vsWorkSheetGroup" />
    <input id="hdnControlIDsRMW" runat="server" type="hidden" />
    <input id="hdnErrorMsgsRMW" runat="server" type="hidden" />
</asp:Content>
