<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ALClaimInfo.aspx.cs"
    Inherits="SONIC_ALClaimInfo" Title="Claim Information :: Auto Liability" %>

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
<%@ Register Src="~/Controls/SonicClaimNotes/SonicNotes.ascx" TagName="ctrlSonicNotes" TagPrefix="uc" %>
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
    <script type="text/javascript" language="javascript">
        function FireAll() {
            if (ValidateRMW())
                return true;
            else
                return false;
        }
        function ValidateRMW() {

            //validate page for passed validation group.
            if (Page_ClientValidate("vsWorkSheetGroup")) {
                return true;
            }
            else
                return false;
        }
        var currIndex = 1;
        var CheckChangeVal = false;
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

                document.getElementById("btnPrev").style.display = "none";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 2) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 3) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 4) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 5) {
                document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlFinancial.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlTransactions.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlRiskManagementWorksheet.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
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

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
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

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "none";
                TextChange();
            }
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 7; i++) {
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

        function OnChangeFunction() {
            if (CheckChangeVal == false)
                CheckChangeVal = true
        }
        function CheckValueChange(Panelid, IndexVal) {
            if (CheckChangeVal == true) {
                if (confirm('Do you want to save your changes before leaving this screen?')) {
                    CheckChangeVal = false;
                    __doPostBack('<%=btnSave.UniqueID %>', 'OnClick');
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

            //debugger;
            //        var arrElementsAnchor = document.getElementsByTagName('a');	
            //        for (i=0; i<arrElementsAnchor.length; i++)
            //        {
            //            
            //            if (arrElementsAnchor[i].parentNode.parentNode.parentNode.parentNode.parentNode.id.indexOf('mnuMain')>-1) 
            //                arrElementsAnchor[i].onclick = alert1;
            //        }
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

        jQuery(function ($) {
            $("#<%=txtGM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCRM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtGM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCRM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtAGC_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtAGC_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtRVP_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtRVP_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtDRM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtDRM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCFO_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCFO_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCOO_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtCOO_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtPresident_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtPresident_Response_Date.ClientID%>").mask("99/99/9999");


        });

       
    </script>
    <script language="javascript" type="text/javascript">
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
            GB_showCenter('', '<%=AppConfig.SiteURL%>SONIC/ClaimInfo/EmailAttachment.aspx?claimId=' + claimId + '&Tbl=al', 500, 950, ReturnFunction);
        }
        function ReturnFunction() {
            var Ctl = document.getElementById('<%=hdnApprovalVal.ClientID %>').value;
            var EmailList = document.getElementById('<%=hdnEmailList.ClientID %>').value;
            var EMailDate = document.getElementById('<%=hdnEmailDate.ClientID %>').value;
            if (Ctl == 0) {
                if (EmailList != '' && EMailDate != '') {
                    //GM
                    if (document.getElementById('<%=trGMTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trGM.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtGM_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtGM_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtGM_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtGM_Last_Email_Date.ClientID %>').value = '';
                    }
                    //CRM
                    if (document.getElementById('<%=trCRMTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trCRM.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtCRM_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtCRM_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtCRM_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtCRM_Last_Email_Date.ClientID %>').value = '';
                    }
                    //AGC
                    if (document.getElementById('<%=trAGCTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trAGC.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtAGC_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtAGC_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtAGC_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtAGC_Last_Email_Date.ClientID %>').value = '';
                    }
                    //RVP
                    if (document.getElementById('<%=trRVPTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trRVP.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtRVP_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtRVP_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtRVP_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtRVP_Last_Email_Date.ClientID %>').value = '';
                    }
                    //DRM
                    if (document.getElementById('<%=trDRMTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trDRM.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtDRM_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtDRM_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtDRM_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtDRM_Last_Email_Date.ClientID %>').value = '';
                    }
                    //CFO
                    if (document.getElementById('<%=trCFOTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trCFO.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtCFO_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtCFO_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtCFO_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtCFO_Last_Email_Date.ClientID %>').value = '';
                    }
                    //COO
                    if (document.getElementById('<%=trCOOTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trCOO.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtCOO_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtCOO_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtCOO_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtCOO_Last_Email_Date.ClientID %>').value = '';
                    }
                    //President
                    if (document.getElementById('<%=trPRESIDENTTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trPRESIDENT.ClientID %>').style.display != "none") {
                        document.getElementById('<%=txtPresident_Email_To.ClientID %>').value = EmailList;
                        document.getElementById('<%=txtPresident_Last_Email_Date.ClientID %>').value = EMailDate;
                    }
                    else {
                        document.getElementById('<%=txtPresident_Email_To.ClientID %>').value = '';
                        document.getElementById('<%=txtPresident_Last_Email_Date.ClientID %>').value = '';
                    }

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
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("ALClaimInfoAuditPopup.aspx?id=" + '<%=ViewState["PK_Auto_Loss_RMW"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=0,menubar=0');
            obj.focus();
            return false;
        }


        ///check Validation Control 
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

                        case "textarea":

                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtAGC_Email_To' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtAGC_Last_Email_Date' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtAGC_Response_Date') {
                                    if (document.getElementById('<%=trAGCTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trAGC.ClientID %>').style.display != "none")
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPresident_Email_To' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPresident_Last_Email_Date' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPresident_Response_Date') {
                                    if (document.getElementById('<%=trPRESIDENTTitle.ClientID %>').style.display != "none" && document.getElementById('<%=trPRESIDENTTitle.ClientID %>').style.display != "none")
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                        } break;


                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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

        function OpenTransMailPopUp(tab, strPKs, FK_Table_Name, FK_Claim) {

            SelectDeselectTransHeader(false);
            var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection_SendMail.aspx?Tab=' + tab + '&PK_Fields=' + strPKs + '&Table_Name=' + FK_Table_Name + '&Claim_ID=' + FK_Claim, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(450, 300);
            return false;
        }

        function SelectDeselectAllTrans(bChecked, bFromGrid) {

            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = (bFromGrid == true ? "chkTranSelect" : "chkRptTransSelect");
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function SelectDeselectTransHeader(bFromGrid) {
            
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = (bFromGrid == true ? "chkTranSelect" : "chkRptTransSelect");
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            var rowCnt = 0;

            if (bFromGrid)
                rowCnt = document.getElementById('<%=gvALTransList.ClientID %>').rows.length - 1;
            else
                rowCnt = document.getElementById('<%=hdnRptRows.ClientID %>').value;

            var headerChkID = bFromGrid ? 'ctl00_ContentPlaceHolder1_gvALTransList_ctl01_chkMultiSelectTrans' : 'ctl00_ContentPlaceHolder1_rptTransDetail_ctl00_chkRptMultiSelectTrans';

            if (cnt == rowCnt)
                document.getElementById(headerChkID).checked = true;
            else
                document.getElementById(headerChkID).checked = false;

        }

        function CheckSelectedTrans(buttonType, bFromGrid) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = (bFromGrid == true ? "chkTranSelect" : "chkRptTransSelect");
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Transaction(s) to View");
                else if (buttonType == "Mail")
                    alert("Please select Transaction(s) to Mail");
                else
                    alert("Please select Transaction(s) to Print");

                return false;
            }
            else {
                return true;
            }
        }

        function ShowHideTranCheckbox() {
            $("#trMultiselectTran").css("display", "none");
            $("#trSelectTran").css("display", "none");
        }

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Risk Management Worksheet Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsWorkSheetGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Attachment:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="AddAttachment" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Comments/Attachment Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="AddClaimAttachment" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Attachment:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="AddAttachment1" CssClass="errormessage">
        </asp:ValidationSummary>
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
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel runat="Server" ID="updSonic" UpdateMode="Always">
                                <ContentTemplate>
                                    <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                        border="0">
                                        <tr class="PropertyInfoBG">
                                            <td style="width: 15%" align="left">
                                                <asp:Label ID="lblHeaderClaimNumber" runat="server" Text="Claim Number"></asp:Label>
                                            </td>
                                            <td style="width: 15%" align="left">
                                                <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                            </td>
                                            <td style="display: none; width: 15%" id="tdHeaderName" align="left" runat="server">
                                                <asp:Label ID="lblHeaderName" runat="server" Text="Name"></asp:Label>
                                            </td>
                                            <td style="width: 15%" align="left">
                                                <asp:Label ID="lblHeaderDateIncident" runat="server" Text="Date of Incident"></asp:Label>
                                            </td>
                                            <td style="width: 23%" align="left">
                                                <asp:Label ID="lblHeaderAssociatedFirstReport" runat="server" Text="Associated First Report"></asp:Label>
                                            </td>
                                            <td style="width: 17%" align="left">
                                                <asp:Label ID="lblCompanionClaim" runat="server" Text="Companion Claim(s)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color: white">
                                            <td align="left">
                                                <asp:Label ID="lblClaimNumber" runat="server">&nbsp; </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblLocationdba" runat="server"> </asp:Label>
                                            </td>
                                            <td style="display: none" id="tdName" align="left" runat="Server">
                                                <asp:Label ID="lblName" runat="server"> </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDateIncident" runat="server"> </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:LinkButton ID="lnkAssociatedFirstReport" runat="server" OnClick="lnkAssociatedFirstReport_Click"></asp:LinkButton>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList runat="server" ID="ddlCompanionClaim" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanionClaim_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                            <asp:HiddenField runat="Server" ID="hdnApprovalVal" />
                            <asp:HiddenField runat="Server" ID="hdnEmailList" />
                            <asp:HiddenField runat="Server" ID="hdnEmailDate" />
                        </td>
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
                                                    <span id="WCMenu1" href="#" onclick="javascript:CheckValueChange(1,null);">Claim Identification</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu2" href="#" onclick="javascript:CheckValueChange(2,null);">Financial</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu3" href="#" onclick="javascript:CheckValueChange(3,null);">Transactions</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu4" href="#" onclick="javascript:CheckValueChange(4,null);">Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td nowrap="nowrap">
                                                    <span id="WCMenu5" href="#" onclick="javascript:CheckValueChange(5,null);">Risk Management Worksheet</span>&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red; display: none">*</span>
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
                                    <td width="794px" valign="top" class="dvContainer">
                                        <div id="dvView" runat="server" style="width: 100%;" >
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
                                                            <asp:Label ID="lblOriginClaimNumber" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmployeeDateofBirth" runat="server"></asp:Label>
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
                                                        <td>State of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStateofAccident" runat="server"></asp:Label>
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
                                                        <td>Date of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateofAccident" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblClaim_sub_status" runat="server"></asp:Label>
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
                                                        <td>Date Closed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateClosed" runat="server"></asp:Label>
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
                                                        <td>Coverage Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoverageCode" runat="server"></asp:Label>
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
                                                        <td>Date Suit Filed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateSuitFiled" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Law Suit Y/N
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLitigationYN" runat="server"></asp:Label>
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
                                                        <td>Suit Type Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSuitTypeCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>TPA Policy Number
                                                        </td>
                                                        <td align="center"></td>
                                                        <td>
                                                            <asp:Label ID="lblSRSPolicyNumber" runat="server"></asp:Label>
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
                                                        <td>TPA Policy Begin Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPolicyEffectiveDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>TPA Policy End Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPolicyExpirationDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Carrier Policy Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOtherCarrierPolicyNumber" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Carrier Policy Begin Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCarrierEffectiveDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Carrier Policy End Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCarrierExpirationDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Claim Made Y/N
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimsMadeIndicator" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claim Made Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimsMadeDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Retroactive Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRetroactiveDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Accident City/Town
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccidentCityTown" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Catastrophe Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCatastropheCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Vehicle Make
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVehicleMake" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Vehicle Model
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVehicleModel" runat="server"></asp:Label>
                                                        </td>
                                                        <td>VIN
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVIN" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Vehicle Year
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVehicleYear" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Claim Status Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClaimDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Description and Cause of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccidentDescription" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Cause of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCauseofInjuryCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Driver’s Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Drivers Age
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Driver Marital Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverMaritalStatus" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Driver Date of Birth
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverDateofBirth" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Driver/client relation
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverRelationshipCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Driver Gender
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverGender" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Driver License Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDriverLicenseNumber" runat="server"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td align="center"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Previous TPA Claim Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreviousTPAClaimNumTakeover" runat="server"></asp:Label>
                                                        </td>
                                                        <td>Line Of Coverage
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLineOfCoverage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td colspan="3">&nbsp;
                                                        </td>
                                                        <td>Coverage Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoverage_Code_New" runat="server"></asp:Label>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlFinancial" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Loss</b>
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
                                                            <asp:Label ID="lblLossGrossPaid" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblNetLossPaid" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblLossNetRecovered" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblLossIncurred" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblLossOutstanding" runat="server"></asp:Label>
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
                                                        <td align="left">
                                                            <b>ALE</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">
                                                            <b>Loss Subrogation</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Subrogation
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAleGrossSubrogation" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Gross
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLossGrossSubrogation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Salvage
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAleGrossSalvage" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Expense
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLossSubrogationExpense" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Gross Refund
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAleGrossRefund" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Gross Salvage
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLossGrossSalvage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Refund Expense
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAleRefundExpense" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Salvage Expense
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLossSalvageExpense" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">Loss Gross Refund
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLossGrossRefund" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Previous TPA</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">
                                                            <b>Legal</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Indemnity Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPreviousTPAIndemnityPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Legal Expense Incurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLegalExpenseIncurred" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPreviousTPAMedicalPaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Legal Expense Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLegalExpensePaidtoDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Expense Paid
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPreviousTPAExpensePaid" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Recovered Loss Deductible Amount
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRecoveredLossDeductibleAmount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Recovered Expense Deductible Amount
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRecoveredExpenseDeductibleAmount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlTransactions" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="Server" ID="updTrans" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="pnlTransGrid" runat="server" Width="100%">
                                                           Click For Detail
                                                             <br />
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="ctrlPageTransaction" runat="server" OnGetPage="GetPage" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <br />
                                                                        <div id="divTransactionList" style="width: 99%; height: 200px; overflow-y: scroll; border: solid 1px #000000">
                                                                            <asp:GridView ID="gvALTransList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvALTransList_RowCommand" OnRowDataBound="gvALTransList_RowDataBound" Width="98%">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <input type="checkbox" id="chkMultiSelectTrans" runat="server" onclick="SelectDeselectAllTrans(this.checked, true);" />Select
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkTranSelect" runat="server" onclick="SelectDeselectTransHeader(true);" />
                                                                                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Claims_Transactions_ID")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date">
                                                                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkTransaction_Entry_date" runat="server" CommandArgument='<%#Eval("PK_Claims_Transactions_ID")%>' CommandName="View">
                                                                                                <%#Eval("Transaction_Entry_date")%>
                                                                                            </asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Transaction_Nature_of_Benefit" HeaderText="Transaction Type" ItemStyle-HorizontalAlign="left" ItemStyle-Width="20%" />
                                                                                    <asp:BoundField DataField="Payee_Name1" HeaderText="Payee" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                                                                                    <asp:BoundField DataField="Nature_of_Payment_Statement" HeaderText="Nature Of Payment" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                                                                                    <asp:TemplateField HeaderText="Amount">
                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                        <ItemTemplate>
                                                                                            <%# string.Format("{0:C2}",Eval("Transaction_Amount"))%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <%--<asp:BoundField HeaderText="Amount" DataField="Transaction_Amount" DataFormatString="$ {0:N2}" ItemStyle-HorizontalAlign="Right" />--%>
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
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2">
                                                                        <br />
                                                                        <asp:Button ID="btnViewSelectedTrans" runat="server" Text=" View "
                                                                            OnClientClick="return CheckSelectedTrans('View',true);" OnClick="btnViewSelectedTrans_Click" />&nbsp;
                                                                    <asp:Button ID="btnPrintSelectedTrans" runat="server" Text=" Print " OnClick="btnPrintSelectedTrans_Click" OnClientClick="return CheckSelectedTrans('Print',true);"/>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                            <asp:Panel ID="pnlSingleTransactionDetail" runat="server" Visible="false" Width="100%">
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
                                                                            <asp:Label ID="lblClaimantSequenceNumber2" runat="server"></asp:Label>
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
                                                                        <td>Payee Street Address </td>
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
                                                                            <asp:Label ID="lblPayeeId" runat="server"></asp:Label>
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
                                                                            <asp:Label ID="lblNatureofBenefitCode" runat="server"></asp:Label>
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
                                                            <asp:Panel ID="pnlTransactionDetail" runat="server" Visible="false" Width="100%">
                                                                <input type="hidden" id="hdnRptRows" runat="server" />
                                                                <table cellpadding="1" cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td width="100%">
                                                                            <div style="width: 770px; height: 370px; overflow-x: hidden; overflow-y: scroll;">
                                                                                <asp:Repeater ID="rptTransDetail" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                                            <tr id="trMultiselectTran" style='display: <%# Container.ItemIndex == 0  ? "block" : "none" %>'>
                                                                                                <td align="left" colspan="2" valign="bottom">
                                                                                                    <input type="checkbox" id="chkRptMultiSelectTrans" runat="server" onclick="SelectDeselectAllTrans(this.checked, false);" />
                                                                                                    Select </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td id="trSelectTran" align="left" valign="top" width="5%">
                                                                                                    <asp:CheckBox ID="chkRptTransSelect" runat="server" onclick="SelectDeselectTransHeader(false);" />
                                                                                                    <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Claims_Transactions_ID")%>' />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="20%">Date </td>
                                                                                                <td width="4%">: </td>
                                                                                                <td width="26%"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("Transaction_Entry_date"))%></td>
                                                                                                <td width="20%">Data Source </td>
                                                                                                <td width="4%">: </td>
                                                                                                <td width="26%"><%#Eval("Data_Origin")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee Name 1 </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_Name1")%></td>
                                                                                                <td>Key Claim Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Origin_Key_Claim_Number")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee Name 2 </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_Name2")%></td>
                                                                                                <td>Claimant Sequence Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Claimant_Sequence_Number")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee Name 3 </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_Name3")%></td>
                                                                                                <td>Policy Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Policy_Number")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee Street_Address </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_Street_Address")%></td>
                                                                                                <td>Carrier Policy Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Carrier_policy_number")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee City </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_City")%></td>
                                                                                                <td></td>
                                                                                                <td></td>
                                                                                                <td></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee State </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_State")%></td>
                                                                                                <td>Transaction Amount </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Transaction_Amount") == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(Eval("Transaction_Amount")))%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee Zip </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Payee_Zip")%></td>
                                                                                                <td>Transaction Sequence Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Transaction_Sequence_Number")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Payee ID </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Convert.ToString(Eval("Payee_Tax_Number")) + " - " + Convert.ToString(Eval("Payee_SSN_FEIN"))%></td>
                                                                                                <td>Claim Status </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Claim_Status")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Entry Code </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Entry_Code_Desc")%></td>
                                                                                                <td>Entry Code Modiifer </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Entry_Code_Modifier_Desc")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Nature of Benefit </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Nature_of_Benefit_Code_Desc")%></td>
                                                                                                <td>Transaction Nature of Benefit </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Transaction_Nature_of_Benefit_Desc")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Nature of Payment Statement </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Nature_of_Payment_Statement")%></td>
                                                                                                <td>Check Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Check_Number")%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>SRS Recovery Office Code </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("SRS_Recovery_Office_Code")%></td>
                                                                                                <td>Check Issue Date </td>
                                                                                                <td>: </td>
                                                                                                <td><%#clsGeneral.FormatDBNullDateToDisplay(Eval("Check_Issue_Date"))%></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>SRS Draft Issue Office Code </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("SRS_Draft_Issue_Office_Code")%></td>
                                                                                                <td>Recovery Sequence Number </td>
                                                                                                <td>: </td>
                                                                                                <td><%#Eval("Recovery_Sequence_Number")%></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <br />
                                                                            <asp:Button ID="btnPrintSelectedTransInner" runat="server" OnClick="btnPrintSelectedTransInner_Click" OnClientClick="return CheckSelectedTrans('Print',false);" Text=" Print " />
                                                                            &nbsp;
                                                                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text=" Cancel " />
                                                                            <asp:Button ID="btnMailTrans" runat="server" OnClick="btnMailTrans_Click" Text=" Mail "/>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp; </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </br>


                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btnPrintSelectedTrans" />
                                                        <asp:PostBackTrigger ControlID="btnPrintSelectedTransInner" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlNotes" runat="server" Width="100%">
                                                <table cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:CtrlAdjusterNotes ID="ucAdjusterNotes" runat="server" CurrentClaimType="AL" />
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
                                                        <td align="left">Claim Made Date
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Entered" runat="server"></asp:Label>
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
                                                        <td align="left">Location Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblFK_Insured_Location_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Region
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRegion" runat="server"></asp:Label>
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
                                                        <td align="left">State of Jurisdiction
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblState_of_Jurisdiction" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Claimant’s Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblClaimantsName"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Claimant a Customer?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoClaimant_Customer" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Claimant a Third Party?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoClaimant_Third_Party" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Driver’s Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDriver_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Driver a Customer?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoDriver_Customer" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Driver an Associate?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoDriver_Associate" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Description and Cause of Accident
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblAccident_Description" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Liability Analysis&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:CtrlMultiLineText_Claim ID="txtLiability_Analysis" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Legal
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Plaintiff Represented
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblPlaintiff_Attorney_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">Law Suit Y/N
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label ID="lblLegal_LitigationYN" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Suit Filed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Suit_Filed" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Demand?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoDemand" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Suit Type Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSuit_Type_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Suit Result Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSuit_Result_Code" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Name of Claimant Counsel&nbsp;<span id="Span2" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtClaimant_Counsel_Name" MaxLength="75"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Name of Plaintiff Counsel&nbsp;<span id="Span3" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtPlantiff_Counsel_Name" MaxLength="75"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Property Damage
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Property Damaged?
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoProperty_Damaged" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Property Damages&nbsp;<span id="Span4" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:CtrlMultiLineText_Claim ID="txtProperty_Damages_Description" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Damage Amount&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">$
                                                            <asp:TextBox runat="server" ID="txtDamage_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Bodily Injury
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Bodily Injury?
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoBodily_Injury" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Injuries&nbsp;<span id="Span6" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:CtrlMultiLineText_Claim ID="txtInjury_Description" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Body Parts Affected&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:DropDownList runat="server" ID="ddlFK_LU_Part_Of_Body" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Cause of Injury Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblCause_of_Injury_Code" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Nature of Injury&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:DropDownList runat="server" ID="ddlFK_LU_Nature_Of_Injury" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Medical Treatment&nbsp;<span id="Span9" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:CtrlMultiLineText_Claim ID="txtMedical_Treatment_Description" runat="server"
                                                                ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Total Medical Cost&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">$
                                                            <asp:TextBox runat="server" ID="txtMedical_Cost" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
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
                                                            <b>Loss</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>ALE</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>Expenses</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <b>Legal Expenses</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Incurred</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblLoss_Incurred"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblExpense_Incurred"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblLegal_Expense_Incurred"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Gross Paid</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblLoss_Gross_Paid"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblExpense_Gross_Paid"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblLegal_Expense_Paid_to_Date"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Outstanding</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblLoss_Outstanding"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblExpense_Outstanding"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            <b>Gross Subrogation</b>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblLoss_Gross_Subrogation"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">
                                                            <asp:Label runat="server" ID="lblAle_Gross_Subrogation"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                        <td align="left" width="20%">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Settlement Approvals
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Requested Amount&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">$
                                                            <asp:TextBox runat="server" ID="txtRequested_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="20%">Potential Total Exposure&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">$
                                                            <asp:TextBox runat="server" ID="txtPotential_Total_Exposure" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
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
                                                        <td align="left">Settled Amount&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">$
                                                            <asp:TextBox runat="server" ID="txtSettled_Amount" onKeyPress="OnChangeFunction();return currencyFormat(this,',','.',event);"
                                                                OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Approvals
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6">
                                                            <a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,0);">Email ALL</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trGMTitle" style="display: block;">GM
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trGM">
                                                            <table cellpadding="0" border="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'GM');">Email GM</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtGM_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="30%">
                                                                        <asp:TextBox ID="txtGM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtGM_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="GM Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtGM_Last_Email_Date" runat="server" ControlToValidate="txtGM_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"> </asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvGM_Last_Email_Date" runat="server" ControlToValidate="txtGM_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="GM Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
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
                                                                    <td align="left">GM Response Date&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
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
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trCRMTitle" style="display: block;">CRM
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trCRM">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'CRM');">Email CRM</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCRM_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
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
                                                                            Display="None"> </asp:CustomValidator>
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
                                                                    <td align="left">CRM Response Date&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
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
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trAGCTitle" style="display: block;">AGC
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trAGC">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'AGC');">Email AGC</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtAGC_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtAGC_Last_Email_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAGC_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="AGC Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtAGC_Last_Email_Date" runat="server" ControlToValidate="txtAGC_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvAGC_Last_Email_Date" runat="server" ControlToValidate="txtAGC_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="AGC Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoAGC_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">AGC Response Date&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtAGC_Response_Date" runat="server"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAGC_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="AGC Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtAGC_Response_Date" runat="server" ControlToValidate="txtAGC_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(AGC Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvAGC_Response_Date" runat="server" ControlToValidate="txtAGC_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="AGC Response Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trRVPTitle" style="display: block;">RVP
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trRVP">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'RVP');">Email RVP</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtRVP_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtRVP_Last_Email_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRVP_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="RVP Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtRVP_Last_Email_Date" runat="server" ControlToValidate="txtRVP_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvRVP_Last_Email_Date" runat="server" ControlToValidate="txtRVP_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="RVP Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
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
                                                                    <td align="left">RVP Response Date&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtRVP_Response_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRVP_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="RVP Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtRVP_Response_Date" runat="server" ControlToValidate="txtRVP_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(RVP Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvRVP_Response_Date" runat="server" ControlToValidate="txtRVP_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="RVP Response Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trDRMTitle" style="display: block;">
                                                        <td colspan="6">DRM
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trDRM">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'DRM');">Email DRM</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtDRM_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtDRM_Last_Email_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDRM_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="DRM Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtDRM_Last_Email_Date" runat="server" ControlToValidate="txtDRM_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvDRM_Last_Email_Date" runat="server" ControlToValidate="txtDRM_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="DRM Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
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
                                                                    <td align="left">DRM Response Date&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDRM_Response_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDRM_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="DRM Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtDRM_Response_Date" runat="server" ControlToValidate="txtDRM_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(DRM Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvDRM_Response_Date" runat="server" ControlToValidate="txtDRM_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="DRM Response Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trCFOTitle" style="display: block;">CFO
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trCFO">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'CFO');">Email CFO</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCFO_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtCFO_Last_Email_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCFO_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CFO Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCFO_Last_Email_Date" runat="server" ControlToValidate="txtCFO_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCFO_Last_Email_Date" runat="server" ControlToValidate="txtCFO_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CFO Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
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
                                                                    <td align="left">CFO Response Date&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCFO_Response_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCFO_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="CFO Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCFO_Response_Date" runat="server" ControlToValidate="txtCFO_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(CFO Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCFO_Response_Date" runat="server" ControlToValidate="txtCFO_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="CFO Response Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trCOOTitle" style="display: block;">COO
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trCOO">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'COO');">Email COO</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtCOO_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtCOO_Last_Email_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCOO_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="COO Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCOO_Last_Email_Date" runat="server" ControlToValidate="txtCOO_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCOO_Last_Email_Date" runat="server" ControlToValidate="txtCOO_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="COO Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
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
                                                                    <td align="left">COO Response Date&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCOO_Response_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCOO_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="COO Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtCOO_Response_Date" runat="server" ControlToValidate="txtCOO_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(COO Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvCOO_Response_Date" runat="server" ControlToValidate="txtCOO_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="COO Response Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" runat="server" id="trPRESIDENTTitle" style="display: block;">President
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="width: 100%; display: block;" runat="server" id="trPRESIDENT">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%">E-Mail To&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                        <br />
                                                                        --<a href="#" onclick="OpenWizardPopup(<%=ViewState["AL_CI_ID"] %>,'President');">Email
                                                                            President</a>--
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox runat="server" ID="txtPresident_Email_To"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                        <asp:TextBox ID="txtPresident_Last_Email_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPresident_Last_Email_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="President Last Email Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtPresident_Last_Email_Date" runat="server" ControlToValidate="txtPresident_Last_Email_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvPresident_Last_Email_Date" runat="server" ControlToValidate="txtPresident_Last_Email_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="President Last Email Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Decision
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList runat="server" ID="rdoPresident_Decision" SkinID="ApprovedNotApprovedTypeNullSelection">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left">President Response Date&nbsp;<span id="Span37" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtPresident_Response_Date" runat="server"></asp:TextBox><img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPresident_Response_Date', 'mm/dd/y',OnChangeFunction);"
                                                                            alt="President Response Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                        <asp:RegularExpressionValidator ID="revtxtPresident_Response_Date" runat="server" ControlToValidate="txtPresident_Response_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                            ErrorMessage="Date Not Valid(President Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        <asp:CustomValidator ID="cvPresident_Response_Date" runat="server" ControlToValidate="txtPresident_Response_Date"
                                                                            ValidationGroup="vsWorkSheetGroup" ClientValidationFunction="CheckDate" ErrorMessage="President Response Date is not valid."
                                                                            Display="None"> </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" width="20%" valign="top">Comments&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="left" width="4%" valign="top">:
                                                                    </td>
                                                                    <td colspan="4">
                                                                        <uc:CtrlMultiLineText_Claim ID="txtComments" runat="server" ControlType="TextBox" />
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                                    Sonic Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" style="width: 15%">
                                                            Sonic Notes Grid<br />
                                                            <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                                OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 3%">
                                                            :
                                                        </td>
                                                        <td style="margin-left: 40px" style="width: 650px">
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
                                                    <tr>
                                                        <td>
                                                            <uc:CtlAttachmentDetail ID="CtlAttachDetail_Cliam" runat="server" IntAttachmentPanel="4" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="right" width="50%">
                                        <input type="button" id="btnPrev" value="Previous" style="display: none; font-weight: bold; color: #000080;" onclick="javascript: CheckValueChange(null, -1);" />
                                    </td>
                                    <td align="left" width="50%">
                                        <input type="button" id="btnNext" value=" Next " style="font-weight: bold; color: #000080;" onclick="javascript: CheckValueChange(null, 1);" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsWorkSheetGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
