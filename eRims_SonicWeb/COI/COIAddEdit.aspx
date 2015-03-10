<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Default.master"
    CodeFile="COIAddEdit.aspx.cs" Inherits="Admin_COIAddEdit" ValidateRequest="false" %>

<%@ Register Src="~/Controls/Calender/Calender.ascx" TagName="ctrlCalendar" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlNotes" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/COIInfo/COIInfo.ascx" TagName="ctrlCOIInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicClaimNotes/SonicNotes.ascx" TagName="ctrlSonicNotes" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function CheckVal() {
            // Pass any dummy validation group name for validate so it reset all validation control 
            // and fire postback. if do not validate or call Page_ClientValidate with dummy name 
            // then its not work properly.
            Page_ClientValidate('10');
            return true;
        }
        function SetLetterLevelText() {
            var strOpr = '<%=Request.QueryString["op"]%>';

            // If page is in ADD mode
            if (strOpr == null || strOpr == '') {
                var IssueDate = document.getElementById('<%=txtIssueDate.ClientID%>').value;
                var Signature = document.getElementById('<%=drpSignature.ClientID%>').value;

                var txtLevel1Text = document.getElementById('<%=txtLevel1Text.ClientID%>');
                var txtLevel2Text = document.getElementById('<%=txtLevel2Text.ClientID%>');
                var txtLevel3Text = document.getElementById('<%=txtLevel3Text.ClientID%>');
                var txtLevel4Text = document.getElementById('<%=txtLevel4Text.ClientID%>');

                // If Issue date is NULL
                if (IssueDate != '') {
                    // if level_X_Texts are NULL
                    if (txtLevel1Text.value == '' && txtLevel2Text.value == '' && txtLevel3Text.value == '' && txtLevel4Text.value == '') {
                        var SignatureNULLText = '<%=SIGNATURE_NULL_TEXT%>';
                        SignatureNULLText = SignatureNULLText.replace("[Date Received]", IssueDate);
                        txtLevel1Text.value = txtLevel2Text.value = txtLevel3Text.value = txtLevel4Text.value = SignatureNULLText;
                    }
                }
                else if (IssueDate == '') {

                    if (Signature == "1") {
                        txtLevel1Text.value = txtLevel2Text.value = txtLevel3Text.value = txtLevel4Text.value = '<%=SIGNATURE1_TEXT%>';
                    }
                    else if (Signature == "2") {
                        txtLevel1Text.value = txtLevel2Text.value = txtLevel3Text.value = txtLevel4Text.value = '<%=SIGNATURE2_TEXT%>';
                    }
                    else {
                        txtLevel1Text.value = txtLevel2Text.value = txtLevel3Text.value = txtLevel4Text.value = "";
                    }
            }
    }
}

function OpenPopupLetter() {
    ShowDialogCOI('GenerateLetterForSingleCOI.aspx?coi=<%=PK_COIs_Encrypt%>');
}

//Check Validation for Page
function CheckForValidation() {
    return AlertValidation('<%=Attachment.RequiredAttachTypeID%>', '<%=Attachment.RequiredAttachFileID%>');
}

function RedirectToPolicyPage(rdoID, PageName) {
    var rdoPolicyRequiredYes = document.getElementById(rdoID + "_0");
    if (rdoPolicyRequiredYes.checked) {
        Navigate_URL(PageName);
    }
}

function Navigate_URL(PageName) {
    var strOpr = '<%=Request.QueryString["op"]%>';
    if (strOpr != null && strOpr == "view") {
        RedirectToPage(PageName);
    }
    else {

        ValidatorEnable(document.getElementById('<%=Attachment.RequiredAttachTypeID%>'), false);
        ValidatorEnable(document.getElementById('<%=Attachment.RequiredAttachFileID%>'), false);
        ValSave();
        if (Page_IsValid == false) {
            //alert("There are invalid entries on this screen, in order to save the data, please provide a valid enty for the fields marked with '!!'");
        }
        else {
            document.getElementById('<%=hdnPageName.ClientID%>').value = PageName; document.getElementById('<%=btnDummyForSave.ClientID%>').click();
            /////__doPostBack('ctl00$ContentPlaceHolder1$btnSave', PageName); 
        }
    }
}
// Redirect to Page
function RedirectToPage(PageName) {
    if (PageName.indexOf("?") > 0)
        window.location.href = PageName + '&coi=<%=PK_COIs_Encrypt%>&op=<%=Request.QueryString["op"]%>';
    else
        window.location.href = PageName + '?coi=<%=PK_COIs_Encrypt%>';
}

function ConfirmDelete() {
    return confirm("Are you sure that you want to remove the data that was selected for deletion?");
}

var currIndex = 1;

function ShowPrevNext(index) {
    ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
}
//Set Menu Style on Selection
function SetMenuStyle(index) {

    var i;
    for (i = 1; i <= 11; i++) {
        var tb = document.getElementById("Menu" + i);
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
    var prev = document.getElementById('<%=btnPrev.ClientID%>');
    var next = document.getElementById('<%=btnNext.ClientID%>');
    if (index == 1) {
        prev.disabled = true;
        next.disabled = false;
    }
    else if (index == 11) {
        prev.disabled = false;
        next.disabled = true;
    }
    else {
        prev.disabled = false;
        next.disabled = false;
    }

    var prevview = document.getElementById('<%=btnPreviousView.ClientID%>');
    var nextview = document.getElementById('<%=btnNextView.ClientID%>');
    if (index == 1) {
        prevview.disabled = true;
        nextview.disabled = false;
    }
    else if (index == 11) {
        prevview.disabled = false;
        nextview.disabled = true;
    }
    else {
        prevview.disabled = false;
        nextview.disabled = false;
    }
}
//function CheckGeneralGrid() {
//    document.getElementById("tblGeneralYes").style.display = "";
//    document.getElementById("tblGeneralNo").style.display = "None";
//}
//function CheckAutomobileGrid() {
//    document.getElementById("tblAutomobileYes").style.display = "";
//    document.getElementById("tblAutomobileNo").style.display = "None";
//}
//function CheckExcessGrid() {
//    document.getElementById("tblExcessYes").style.display = "";
//    document.getElementById("tblExcessNo").style.display = "None";
//}
//function CheckWCGrid() {
//    document.getElementById("tblWCYes").style.display = "";
//    document.getElementById("tblWCNo").style.display = "None";
//}
//function CheckPropertyGrid() {
//    document.getElementById("tblPropertyYes").style.display = "";
//    document.getElementById("tblPropertyNo").style.display = "None";
//}
//function CheckProfessionalGrid() {
//    document.getElementById("tblProfessionalYes").style.display = "";
//    document.getElementById("tblProfessionalNo").style.display = "None";
//}
//function CheckLiabilityGrid() {
//    document.getElementById("tblLiabilityYes").style.display = "";
//    document.getElementById("tblLiabilityNo").style.display = "None";
//}
// Display Selected Panel and Hide other in Edit Mode       
function ShowPanel(index) {
    currIndex = index;
    SetMenuStyle(index);
    var i;
    var op = '<%=StrOperation%>';

    if (op == "view") {
        document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvEdit.ClientID%>").style.display = "block";
                document.getElementById("<%=dvGrids.ClientID%>").style.display = "block";

                if (index < 10) {

                    for (i = 1; i <= 13; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                    }
                    if (index < 5) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel" + index).style.display = "block";
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel" + (4 + index)).style.display = "block";
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "none";

                }
                else {
                    for (i = 1; i <= 13; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                    }
                    if (index == 10) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "block";
                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                        document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    }
                    else if (index == 11) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                        document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "none";
                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "block";
                        document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";

                    }

            }
                //onSubleaseChange();
            SetFocusOnFirstControl(index);
        }

    }

    function SetFocusOnFirstControl(index) {
        switch (index) {
            case 1:
                document.getElementById('ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_0').focus(); break;
            case 2:
                document.getElementById('ctl00_ContentPlaceHolder1_drpRiskProfile').focus(); break;
            case 3:
                document.getElementById('ctl00_ContentPlaceHolder1_rdoSignedRecieved_0').focus(); break;
            case 4:
                document.getElementById('ctl00_ContentPlaceHolder1_rdoCOIActive_0').focus(); break;
            case 5:
                document.getElementById('ctl00_ContentPlaceHolder1_lnkProducersAdd').focus(); break;
            case 6:
                document.getElementById('ctl00_ContentPlaceHolder1_lnkCompaniesAdd').focus(); break;
            case 7:
                document.getElementById('ctl00_ContentPlaceHolder1_rdoGeneralRequired_0').focus(); break;
            case 8:
                document.getElementById('ctl00_ContentPlaceHolder1_lnkOwnersAdd').focus(); break;
            case 9:
                document.getElementById('ctl00_ContentPlaceHolder1_lnkCopiesAdd').focus(); break;
            case 10:
                document.getElementById('ctl00_ContentPlaceHolder1_Attachment_drpAttachType').focus();
                break;
            default:
                break;
        }
    }

    // Display Selected Panel and Hide other in View Mode          
    function ShowPanelView(index) {
        SetMenuStyle(index);
        document.getElementById('<%=dvView.ClientID%>').style.display = "block";

        document.getElementById("<%=dvGrids.ClientID%>").style.display = "block";

        var i;
        if (index < 10) {
            for (i = 1; i <= 13; i++) {

                document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_Panel" + (4 + index)).style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
            document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "none";
        }
        else {
            for (i = 1; i <= 13; i++) {

                document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
            }
            if (index == 10) {
                document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
            else if (index == 11) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                }
                //document.getElementById("<=dvAttachment.ClientID%>").style.display = "block";

        }
    }

    function onSubleaseChangePanel() {

        var SubleaseYes = document.getElementById("ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_0");
        var SubleaseNo = document.getElementById("ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_1");
        var btnInsuredname = document.getElementById('ctl00_ContentPlaceHolder1_btnInsuredName');
        var ddlDBA = document.getElementById('ctl00_ContentPlaceHolder1_ddlDBA');
        if (SubleaseYes.checked) {
            btnInsuredname.disabled = false;
            ddlDBA.disabled = true;
        }
        else if (SubleaseNo.checked) {
            btnInsuredname.disabled = true;
            ddlDBA.disabled = false;
        }
    }

    function onSubleaseChange() {
        var SubleaseYes = document.getElementById("ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_0");
        var SubleaseNo = document.getElementById("ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_1");
        var btnInsuredname = document.getElementById('ctl00_ContentPlaceHolder1_btnInsuredName');
        var ddlDBA = document.getElementById('ctl00_ContentPlaceHolder1_ddlDBA');
        var txtName = document.getElementById('ctl00_ContentPlaceHolder1_txtName');
        var txtContactLastName = document.getElementById('ctl00_ContentPlaceHolder1_txtContactLastName');
        var txtContactFirstName = document.getElementById('ctl00_ContentPlaceHolder1_txtContactFirstName');
        var txtContactTitle = document.getElementById('ctl00_ContentPlaceHolder1_txtContactTitle');
        var txtContactPhone = document.getElementById('ctl00_ContentPlaceHolder1_txtContactPhone');
        var txtContactFax = document.getElementById('ctl00_ContentPlaceHolder1_txtContactFax');
        var txtContactEmail = document.getElementById('ctl00_ContentPlaceHolder1_txtContactEmail');
        var drpRegion = document.getElementById('ctl00_ContentPlaceHolder1_drpRegion');
        var hdnPK_Building_Ownership_ID = document.getElementById('ctl00_ContentPlaceHolder1_hdnPK_Building_Ownership_ID');
        var txtSublease = document.getElementById('ctl00_ContentPlaceHolder1_txtSubleaseName');
        var txtLandlord = document.getElementById('ctl00_ContentPlaceHolder1_txtLandlordName');
        var BuildingGridAdd = document.getElementById('ctl00_ContentPlaceHolder1_lnkAddBuilding');
        var BuildingGrid = document.getElementById('ctl00_ContentPlaceHolder1_gvBuildingInformation');
        var op = '<%=StrOperation%>';

            txtName.disabled = SubleaseYes.checked;
            txtContactLastName.disabled = SubleaseYes.checked;
            txtContactFirstName.disabled = SubleaseYes.checked;
            txtContactTitle.disabled = SubleaseYes.checked;
            txtContactPhone.disabled = SubleaseYes.checked;
            txtContactFax.disabled = SubleaseYes.checked;
            txtContactEmail.disabled = SubleaseYes.checked;
            BuildingGridAdd.disabled = SubleaseYes.checked;
            ddlDBA.disabled = SubleaseYes.checked;
            btnInsuredname.disabled = !SubleaseYes.checked;

            if (SubleaseYes.checked) {
                var tmpBuilding_Number = document.getElementById('ctl00_ContentPlaceHolder1_hdnBuilding_Number').value;
                txtSublease.value = document.getElementById('ctl00_ContentPlaceHolder1_hdntxtName').value;
                txtLandlord.value = document.getElementById('ctl00_ContentPlaceHolder1_hdnLandlordName').value;

                BuildingGridAdd.href = "#";
                //Hide and Show BuildingGrid Column Building number and Remove Button
                var grid = document.getElementById('ctl00_ContentPlaceHolder1_gvBuildingInformation');
                if (grid != null && grid.rows.length > 1) {
                    for (i = 0; i < grid.rows.length; i++) {
                        grid.rows[i].cells[0].style.display = "none";
                        grid.rows[i].cells[1].style.display = "block";
                        grid.rows[i].cells[3].style.display = "none";
                        grid.rows[i].cells[4].style.display = "block";
                    }
                }
                //Check Validation
                document.getElementById('<%=Span1.ClientID %>').style.display = "none";
                document.getElementById('<%=Span4.ClientID %>').style.display = "none";
                document.getElementById('<%=Span6.ClientID %>').style.display = "none";
                document.getElementById('<%=Span8.ClientID %>').style.display = "none";
                document.getElementById('<%=Span10.ClientID %>').style.display = "none";
                document.getElementById('<%=Span12.ClientID %>').style.display = "none";
                document.getElementById('<%=Span14.ClientID %>').style.display = "none";
                document.getElementById('<%=Span16.ClientID %>').style.display = "none";
                document.getElementById('<%=Span19.ClientID %>').style.display = "none";
            }
            else if (SubleaseNo.checked) {
                txtSublease.value = '';
                txtLandlord.value = '';
                //Hide and Show BuildingGrid Column Building number and Remove Button
                var grid = document.getElementById('ctl00_ContentPlaceHolder1_gvBuildingInformation');
                if (grid != null && grid.rows.length > 1) {
                    for (i = 0; i < grid.rows.length; i++) {
                        grid.rows[i].cells[0].style.display = "block";
                        grid.rows[i].cells[1].style.display = "none";
                        grid.rows[i].cells[3].style.display = "block";
                        grid.rows[i].cells[4].style.display = "none";
                    }
                }
                BuildingGridAdd.href = "javascript:__doPostBack('ctl00$ContentPlaceHolder1$lnkAddBuilding','')";
                //BuildingGridAdd.onclick = "return true;"; ///COIInsuredBuilding.aspx?coi=<%=PK_COIs_Encrypt%>
                document.getElementById('ctl00_ContentPlaceHolder1_hdnPK_Building_Ownership_ID').value = 0;
                //Check Span Validation 
                var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
               if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                    var i = 0;
                    for (i = 0; i < ctrlIDs.length; i++) {
                        var ctrl = document.getElementById(ctrlIDs[i]);
                        switch (ctrl.type) {
                            case "textarea":
                            case "text":
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtName' || ctrl.id == 'ctl00_ContentPlaceHolder1_ddlDBA' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactLastName' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactFirstName' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactTitle' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactPhone' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactFax' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactEmail' || ctrl.id == 'ctl00_ContentPlaceHolder1_drpRegion') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_1');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked) {
                                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtName')
                                            document.getElementById('<%=Span1.ClientID %>').style.display = "";
                                       else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactLastName')
                                           document.getElementById('<%=Span6.ClientID %>').style.display = "";
                                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactFirstName')
                                            document.getElementById('<%=Span8.ClientID %>').style.display = "";
                                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactTitle')
                                            document.getElementById('<%=Span10.ClientID %>').style.display = "";
                                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactPhone')
                                            document.getElementById('<%=Span12.ClientID %>').style.display = "";
                                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactFax')
                                            document.getElementById('<%=Span14.ClientID %>').style.display = "";
                                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactEmail')
                                            document.getElementById('<%=Span16.ClientID %>').style.display = "";
            }
        } break;

    case "select-one":
        if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlDBA' || ctrl.id == 'ctl00_ContentPlaceHolder1_drpRegion') {
            var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_1');
            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
            if (rdb.checked) {
                if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlDBA')
                    document.getElementById('<%=Span4.ClientID %>').style.display = "";
                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_drpRegion')
                    document.getElementById('<%=Span19.ClientID %>').style.display = "";
        }
    }
    break;
}
}
}

}
}

function PopUpInsuredName() {

    var PopupHeight_InsuredName = 500;
    var PopupWidth_InsuredName = 850;
    ShowPopDialog('PopUpInsuredName.aspx', PopupWidth_InsuredName, PopupHeight_InsuredName);
}

function ShowPopDialog(navigateurl, width, height) {

    var w = 480, h = 340;
    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = width, popH = height;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }
    window.open(navigateurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
}

function IfSave() {
    var values = '<%=ViewState["COI_ID"]%>';
    if (values == '' || values == '0') {
        alert('Please Save Certificate of Insurance Record First');
        ShowPanel(1);
        return false;
    }
    else return Page_ClientValidate('AddAttachment');
}

function ValSave() {
    if (Page_ClientValidate("vsErrorGroup"))
        return true;
    else
        return false;
}
function FocusSet() {
    document.getElementById('<%=txtName.ClientID %>').focus();
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
                case "textarea":
                case "text":
                    if (ctrl.value == '') {
                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtName' || ctrl.id == 'ctl00_ContentPlaceHolder1_ddlDBA' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactLastName' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactFirstName' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactTitle' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactPhone' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactFax' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtContactEmail' || ctrl.id == 'ctl00_ContentPlaceHolder1_drpRegion') {
                            var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_1');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdb.checked)
                                bEmpty = true;
                        }
                        else
                            bEmpty = true;
                    } break;

                case "select-one":
                    if (ctrl.selectedIndex == 0) {
                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlDBA') {
                            var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoSubleaseAgreement_1');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdb.checked)
                                bEmpty = true;
                        }
                        else
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
    //For Sonic Notes Validation
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
    </script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenChooseCertiType(Type, id) {
            var values = '<%=ViewState["COI_ID"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Certificate of Insurance Record First');
                ShowPanel(3);
                return false;
            }
            else {
                GB_showCenter('', '<%=AppConfig.SiteURL%>COI/COI_CertificateType_Detail.aspx?CT_ID=' + Type + '&id=' + id + '&coi=<%=PK_COIs_Encrypt%>', 320, 700, '');
                ShowPanel(3);
                return false;
            }
        }

    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table cellpadding="0" cellspacing="0" width="100%" align="left">
            <tr>
                <td colspan="3" style="height: 5px;" class="Spacer"></td>
            </tr>
            <tr>
                <td colspan="3" align="left" style="font-family: Verdana; color: #266591; font-size: 13px; font-weight: 700; height: 16px">&nbsp; Certificates of Insurance
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 5px;" class="Spacer"></td>
            </tr>

            <tr>
                <td width="100%" colspan="3">
                    <uc:ctrlCOIInfo ID="ucCtrlCOIInfo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 5px;" colspan="3" width="100%"></td>
            </tr>

            <tr>
                <td class="leftMenu">
                    <table cellpadding="5" cellspacing="0" width="180px">
                        <tr>
                            <td style="height: 10px;" class="Spacer"></td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Insured</span>
                                <span id="MenuAsterisk1" runat="server" style="color: Red; display: none;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Risk Profile</span>
                                <span id="MenuAsterisk2" runat="server" style="color: Red; display: none;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Compliance</span>
                                <span id="MenuAsterisk3" runat="server" style="color: Red; display: none;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Notification
                                    Letter</span> <span id="MenuAsterisk4" runat="server" style="color: Red; display: none;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Producers</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Insurance
                                    Companies</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Limits and
                                    Coverage</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Owners</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu9" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">Copies</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu10" onclick="javascript:ShowPanel(10);" class="LeftMenuStatic">Notes</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu11" onclick="javascript:ShowPanel(11);" class="LeftMenuStatic">Attachment</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;" class="Spacer"></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 5px;" class="Spacer">&nbsp;
                </td>
                <td valign="top" width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="dvContainer">
                                <div id="dvEdit" runat="server">
                                    <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Insured
                                        </div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="left">Sublease Agreement?
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <%--<asp:RadioButtonList ID="rdoSubleaseAgreement" runat="server" SkinID="YesNoType" onclick="javascript:return onSubleaseChange();">
                                                    </asp:RadioButtonList>--%>
                                                    <asp:RadioButtonList ID="rdoSubleaseAgreement" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td></td>
                                                <td width="23%" align="left" class="lblValignTop">Date Requested&nbsp;<span id="Span3" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center" class="lblValignTop">:
                                                </td>
                                                <td width="28%" align="left" class="lblValignTop">
                                                    <asp:TextBox ID="txtDateRequested" runat="server" SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateRequested', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDateRequested"
                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                        ErrorMessage="Please Enter Valid [Insured]/Date Requested" Display="none" SetFocusOnError="true"
                                                        ValidationGroup="vsErrorGroup">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="15%" align="left" class="lblValignTop">Insured Name&nbsp;<span id="Span1" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center" class="lblValignTop">:
                                                </td>
                                                <td width="28%" align="left" class="lblValignTop">
                                                    <asp:TextBox ID="txtName" runat="server" MaxLength="254"></asp:TextBox>
                                                    <asp:Button ID="btnInsuredName" runat="server" Text="V" OnClientClick="javascript:PopUpInsuredName();return false;" />
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td width="23%" align="left" class="lblValignTop">Date Received&nbsp;<span id="Span2" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center" class="lblValignTop">:
                                                </td>
                                                <td width="28%" align="left" class="lblValignTop">
                                                    <asp:TextBox ID="txtIssueDate" runat="server" SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIssueDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <asp:RegularExpressionValidator ID="revDateOfProfile" runat="server" ControlToValidate="txtIssueDate"
                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                        ErrorMessage="Please Enter Valid [Insured]/Date Received" Display="none" SetFocusOnError="true"
                                                        ValidationGroup="vsErrorGroup">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Landlord Name
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtLandlordName" runat="server" Width="170px" Enabled="false" />
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Sublease Name
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtSubleaseName" runat="server" Width="170px" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">D/B/A Location Name&nbsp;<span id="Span4" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:DropDownList ID="ddlDBA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDBA_SelectedIndexChanged"
                                                        onchange="Page_ClientValidate('dummy');">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Region&nbsp;<span id="Span19" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:DropDownList ID="drpRegion" runat="server" Width="225px" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <table cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="15%" align="left" valign="top">Building Grid<br />
                                                                <asp:LinkButton ID="lnkAddBuilding" runat="server" OnClick="lnkAddBuilding_Click" CausesValidation="false">--Add--</asp:LinkButton>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvBuildingInformation" runat="server" Width="100%" OnRowCommand="gvBuildingInformation_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Building Number" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" />
                                                                            <ItemTemplate>
                                                                                <a id="aLinkEdit" href='COIInsuredBuilding.aspx?coi=<%=PK_COIs_Encrypt%>&op=edit&id=<%# Encryption.Encrypt(Eval("Building_Number").ToString())%>'>
                                                                                    <%#Eval("Building_Number")%></a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" />
                                                                            <ItemTemplate>
                                                                                <%# clsGeneral.FormatBuildingAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"),(Eval("FK_State") != DBNull.Value ? new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_state : ""), Eval("Zip"))%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                    OnClientClick="return ConfirmDelete();" CommandName="RemoveBuilding" CommandArgument='<%#Eval("Building_Number")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="">
                                                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            <ItemTemplate>
                                                                                &nbsp;
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for  Building Grid"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Contact Last Name&nbsp;<span id="Span6" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtContactLastName" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Contact First Name&nbsp;<span id="Span8" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtContactFirstName" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Contact Title&nbsp;<span id="Span10" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtContactTitle" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Contact E-Mail&nbsp;<span id="Span16" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtContactEmail" runat="server" Width="170px" MaxLength="254"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid [Insured]/Contact E-Mail"
                                                        ControlToValidate="txtContactEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Contact Phone (XXX-XXX-XXXX)&nbsp;<span id="Span12" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtContactPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ErrorMessage="Please Enter Valid [Insured]/Contact Phone"
                                                        ControlToValidate="txtContactPhone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Contact Fax (XXX-XXX-XXXX)&nbsp;<span id="Span14" style="color: Red; display: none; position: absolute"
                                                    runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtContactFax" runat="server" MaxLength="12" Width="170px" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revContactFax" runat="server" ErrorMessage="Please Enter Valid [Insured]/Contact Fax"
                                                        ControlToValidate="txtContactFax" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" valign="top">
                                                    Effective Date&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="left" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtDateActivated" runat="server" SkinID="txtdate" MaxLength="11"></asp:TextBox>
                                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateActivated', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDateActivated"
                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                        ErrorMessage="Please Enter Valid [Insured]/Date Activated" Display="none" SetFocusOnError="true"
                                                        ValidationGroup="vsErrorGroup">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    Expiration Date&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="left" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txtDateClosed" SkinID="txtDate" runat="server" ReadOnly="false"
                                                        MaxLength="10"></asp:TextBox>
                                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClosed', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDateClosed"
                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                        ErrorMessage="Please Enter Valid [Insured]/Date Closed." Display="none" ValidationGroup="vsErrorGroup"
                                                        SetFocusOnError="true">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="left" valign="top">Insured Active
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:RadioButtonList ID="rdoInsuredActive" RepeatDirection="Horizontal" runat="server"
                                                        SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">AM Best Rating of A- or Better?
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:RadioButtonList ID="rdoAMBestRequired" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Notes&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" colspan="5" valign="top">
                                                    <uc:ctrlNotes ID="txtNotes" runat="server" Width="630" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px;" colspan="7" class="Spacer"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Risk Profile
                                        </div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="height: 5px;" colspan="7" class="Spacer"></td>
                                            </tr>
                                            <tr>
                                                <td width="15%" align="left">&nbsp;Risk Profile&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="76%" align="left" colspan="5">
                                                    <asp:DropDownList ID="drpRiskProfile" runat="server" TabIndex="1" Width="76%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">&nbsp;Building TIV ($)&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                    runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="26%" align="left" colspan="5">
                                                    <asp:TextBox ID="txtBuilding_TIV" runat="server" Width="235px" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">&nbsp;Profile Notes&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" colspan="5" valign="top">
                                                    <uc:ctrlNotes ID="txtProfileNote" runat="server" TabIndex="4" Width="630" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 120px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel3" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Compliance
                                        </div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="height: 5px;" colspan="7" class="Spacer"></td>
                                            </tr>
                                            <tr>
                                                <td width="29%" align="left" valign="top" style="padding-left: 5px;">Original or Signed Certificate Received
                                                </td>
                                                <td width="1%" align="center" valign="top">:
                                                </td>
                                                <td width="19%" align="left" valign="top">
                                                    <asp:RadioButtonList ID="rdoSignedRecieved" runat="server" SkinID="YesNoType" RepeatDirection="Horizontal"
                                                        TabIndex="1">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <%-- <td width="1%">&nbsp;
                                                </td>--%>
                                                <td width="29%" align="left" valign="top">Certificate Includes Notice of Cancellation of&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                    runat="server">*</span>
                                                </td>
                                                <td width="1%" align="center" valign="top">:
                                                </td>
                                                <td width="20%" align="left" valign="bottom">
                                                    <asp:TextBox ID="txtCancellationNotice" runat="server" MaxLength="3" Width="120px"
                                                        TabIndex="4"></asp:TextBox>&nbsp;Days
                                                    <asp:RegularExpressionValidator ID="revCancellation" runat="server" ErrorMessage="Plese Enter Valid [Compliance]/Certificate Includes Notice of Cancellation of"
                                                        ControlToValidate="txtCancellationNotice" ValidationExpression="^([0-9]*|\d*\d{1}?\d*)$"
                                                        Display="none" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <asp:DataList ID="dlComplianceText" runat="server" Width="100%" RepeatColumns="2"
                                                        RepeatDirection="Horizontal" EnableViewState="true" Visible="true" OnItemDataBound="dlComplianceText_ItemDataBound">
                                                        <ItemStyle Width="50%" />
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="29%" align="left" valign="top">
                                                                        <asp:Label ID="lblComplianceText" runat="server" Text='<%#Eval("Compliance_Text") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnPK" runat="server" Value='<%#Eval("PK_Compliance") %>' />
                                                                    </td>
                                                                    <td width="1%" align="center" valign="top">:
                                                                    </td>
                                                                    <td width="20%" align="left" valign="top">
                                                                        <asp:RadioButtonList ID="rdoCompliance" runat="server" CellPadding="2" CellSpacing="3"
                                                                            RepeatDirection="Horizontal" SkinID="YesNoType" TabIndex="7" />
                                                                    </td>
                                                                    <%--<td width="2%">&nbsp;
                                                                    </td>--%>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="7" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Certificate Type Grid<br />
                                                    <a id="A1" runat="server" href="#" onclick="OpenChooseCertiType(0,0);">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <%-- <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                        <ContentTemplate>--%>
                                                    <asp:Button ID="btnhdnReload" runat="server" OnClick="btnhdnReload_Click" Style="display: none;" />
                                                    <asp:GridView ID="grvCertificateTypes" runat="server" Width="100%" OnRowCommand="grvCertificateTypes_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Certificate Type">
                                                                <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkCertiType" runat="server" Text='<%#Eval("CertificateTypeName")%>'
                                                                        CommandName="ViewDetail" CommandArgument='<%#Eval("PK_COI_Certificate_Detail_ID") + ";" + Eval("FK_CertificateType_ID") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date Issued">
                                                                <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDateIssue" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Issued"))%>'
                                                                        CommandName="ViewDetail" CommandArgument='<%#Eval("PK_COI_Certificate_Detail_ID") + ";" + Eval("FK_CertificateType_ID") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove">
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove"
                                                                        OnClientClick="return ConfirmDelete();" CommandName="RemoveCertiType" CommandArgument='<%#Eval("PK_COI_Certificate_Detail_ID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Certificate Type"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                    <%-- </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="7" style="height: 10px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel4" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Notification Letter
                                        </div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="height: 5px;" colspan="7" class="Spacer"></td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">COI Active
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="22%" align="left">
                                                    <asp:RadioButtonList ID="rdoCOIActive" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td width="14%" align="left">Signature&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="36%" align="left">
                                                    <asp:DropDownList ID="drpSignature" runat="server" Width="235px" onchange="SetLetterLevelText();">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Send by E-Mail
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:RadioButtonList ID="rdoSendByEmail" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Level 1 Text&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <uc:ctrlNotes ID="txtLevel1Text" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" class="lblValignTop">Level 2 Text&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td valign="top" align="center" class="lblValignTop">:
                                                </td>
                                                <td valign="top" align="left" class="lblValignTop" colspan="5">
                                                    <uc:ctrlNotes ID="txtLevel2Text" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" class="lblValignTop">Level 3 Text&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <uc:ctrlNotes ID="txtLevel3Text" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Level 4 Text&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <uc:ctrlNotes ID="txtLevel4Text" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" colspan="7" class="Spacer"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <div id="dvView" runat="server" style="display: none;" align="left">
                                    <asp:Panel ID="Panel5" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Insured
                                        </div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="left">Sublease Agreement?
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblSuleaseAgreement" runat="server">   </asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td width="23%" align="left" class="lblValignTop">Date Requested
                                                </td>
                                                <td width="2%" align="center" class="lblValignTop">:
                                                </td>
                                                <td width="28%" align="left" class="lblValignTop">
                                                    <asp:Label ID="lblDateRequested" runat="server" />
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="15%" align="left" class="lblValignTop">Insured Name
                                                </td>
                                                <td width="2%" align="center" class="lblValignTop">:
                                                </td>
                                                <td width="28%" align="left" class="lblValignTop">
                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td width="23%" align="left" class="lblValignTop">Date Received
                                                </td>
                                                <td width="2%" align="center" class="lblValignTop">:
                                                </td>
                                                <td width="28%" align="left" class="lblValignTop">
                                                    <asp:Label ID="lblIssueDate" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Landlord Name
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblLandlordName" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Sublease Name
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblSubleaseName" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">D/B/A Location Name
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblDBA" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Region
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblRegion" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <table cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="15%" align="left" valign="top">Building Grid
                                                            </td>
                                                            <td width="2%" align="left" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvBuildingInformationView" runat="server" Width="100%" OnRowCommand="gvBuildingInformationView_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Building Number">
                                                                            <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkView" runat="server" Text='<%#Eval("Building_Number")%>' CausesValidation="false"
                                                                                    CommandName="ViewBuilding" CommandArgument='<%#Eval("PK_COI_Insureds_Buildings")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address">
                                                                            <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                            <ItemTemplate>
                                                                                <%# clsGeneral.FormatBuildingAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), (Eval("FK_State") != DBNull.Value ? new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_state : ""), Eval("Zip"))%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for  Building Grid"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Contact Last Name
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblContactLastName" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Contact First Name
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblContactFirstName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Contact Title
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblContactTitle" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Contact E-Mail
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Contact Phone (XXX-XXX-XXXX)
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblContactPhone" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">Contact Fax (XXX-XXX-XXXX)
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblContactFax" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" valign="top">
                                                    Effective Date
                                                </td>
                                                <td align="left" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblDateActivated" runat="server" />
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    Expiration Date
                                                </td>
                                                <td align="left" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblDateClosed" runat="server" />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="left" valign="top">Insured Active
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblInsuredActive" Width="50%" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" valign="top">AM Best Rating of A- or Better?
                                                </td>
                                                <td align="left" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblAMBestRequired" Width="50%" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Notes
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" colspan="5" valign="top">
                                                    <uc:ctrlNotes ID="lblNotes" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px;" colspan="7" class="Spacer"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel6" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Risk Profile
                                        </div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">Risk Profile
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="26%" align="left">
                                                    <asp:Label ID="lblRiskProfile" runat="server" Width="235px"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td width="20%" align="left">&nbsp;
                                                </td>
                                                <td width="2%" align="center">&nbsp;
                                                </td>
                                                <td width="26%" align="left">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Building TIV ($)
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="26%" align="left" colspan="5">
                                                    <asp:Label ID="lblBuilding_TIV" runat="server" Width="235px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Profile Notes
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" colspan="5" valign="top">
                                                    <uc:ctrlNotes ID="lblProfileNote" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 200px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel7" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Compliance
                                        </div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="29%" align="left" valign="top">Original or Signed Certificate Received
                                                </td>
                                                <td width="1%" align="center" valign="top">:
                                                </td>
                                                <td width="19%" align="left" valign="top">
                                                    <asp:Label ID="lblSignedRecieved" runat="server"></asp:Label>
                                                </td>
                                                <%--<td width="2%">&nbsp;
                                                </td>--%>
                                                <td width="29%" align="left" valign="top">Certificate Includes Notice of Cancellation of
                                                </td>
                                                <td width="1%" align="center" valign="top">:
                                                </td>
                                                <td width="20%" align="left" valign="top">
                                                    <asp:Label ID="lblCancellationNotice" runat="server"></asp:Label>&nbsp;Days
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <asp:DataList ID="dlComplianceView" runat="server" Width="100%" RepeatColumns="2"
                                                        CellPadding="3" CellSpacing="1" RepeatDirection="Horizontal" EnableViewState="true"
                                                        Visible="true" OnItemDataBound="dlComplianceTextView_ItemDataBound">
                                                        <ItemStyle Width="50%" />
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="29%" align="left" valign="top">
                                                                        <asp:Label ID="lblComplianceText" runat="server" Text='<%#Eval("Compliance_Text") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnPK" runat="server" Value='<%#Eval("PK_Compliance") %>' />
                                                                    </td>
                                                                    <td width="1%" align="center" valign="top">:
                                                                    </td>
                                                                    <td width="20%" align="left" valign="top">
                                                                        <asp:Label ID="lblIsTurnedOn" runat="server"></asp:Label>
                                                                    </td>
                                                                    <%-- <td width="2%">&nbsp;
                                                                    </td>--%>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="7" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Certificate Type Grid<br />
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <asp:GridView ID="grvCertificateTypesView" runat="server" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Certificate Type">
                                                                <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <%#Eval("CertificateTypeName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date Issued">
                                                                <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Issued"))%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Certificate Type"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="7" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 125px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel8" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Notification Letter
                                        </div>
                                        <table cellpadding="5" cellspacing="1" width="100%" height="250px">
                                            <tr>
                                                <td width="20%" align="left">COI Active
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="22%" align="left">
                                                    <asp:Label ID="lblCOIActive" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td width="14%" align="left">Signature
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td width="36%" align="left">
                                                    <asp:Label ID="lblSignature" runat="server" Width="215px" ReadOnly="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Send by E-Mail
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblSendByEmail" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Level 1 Text
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">&nbsp;<uc:ctrlNotes ID="lblLevel1Text" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Level 2 Text
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <uc:ctrlNotes ID="lblLevel2Text" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Level 3 Text
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">
                                                    <uc:ctrlNotes ID="lblLevel3Text" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Level 4 Text
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top" colspan="5">&nbsp;<uc:ctrlNotes ID="lblLevel4Text" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 10px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <div id="dvGrids" runat="server" style="display: block;" align="left">
                                    <asp:Panel ID="Panel9" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            &nbsp;Producers
                                        </div>
                                        <table cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="15%" align="left" valign="top">Producers Grid<br />
                                                    <a id="lnkProducersAdd" runat="server" href="javascript:Navigate_URL('ProducersAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td width="2%" align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upProducer">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvProducers" runat="server" Width="100%" OnRowCommand="gvProducers_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('ProducersAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Producers").ToString())%>');">
                                                                                <%#Eval("Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_abbreviation, Eval("Zip_Code"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemoveProducer" CommandArgument='<%#Eval("PK_COI_Producers")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Producers"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 225px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel10" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Insurance Companies
                                        </div>
                                        <table cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left" valign="top">Insurance Companies Grid<br />
                                                    <a id="lnkCompaniesAdd" runat="server" href="javascript:Navigate_URL('CompanyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td width="2%" align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upCompanies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvInsuranceCompanies" runat="server" Width="100%" OnRowCommand="gvInsuranceCompanies_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Company">
                                                                        <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('CompanyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Insurance_Companies").ToString())%>');">
                                                                                <%#Eval("Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_abbreviation, Eval("Zip_Code"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemoveCompany" CommandArgument='<%#Eval("PK_COI_Insurance_Companies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Insurance Company"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 225px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel11" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Limits and Coverage
                                        </div>
                                        <table cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="General">General Liability Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblGeneralRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoGeneralRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">General Liability Policies Grid<br />
                                                    <a id="lnkGeneralAdd" runat="server" href="javascript:Navigate_URL('GeneralPolicyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upGeneralLiability">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvGeneralPolicies" runat="server" Width="100%" OnRowCommand="gvGeneralPolicies_RowCommand" OnRowDataBound="gvGeneralPolicies_RowDataBound" ShowHeaderWhenEmpty="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('GeneralPolicyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_General_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" src='<%#((Convert.ToBoolean(Eval("HasRisk"))==true)? AppConfig.RiskImageURL : AppConfig.NoRiskImageURL )%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_General_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" runat="server" id="tblGeneralYes">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for General Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblGeneralNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="Label1" runat="server" SkinID="Message" Text="No data has been entered for General Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="3" style="height: 5px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="Automobile">Automobile Liability Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblAutoRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoAutoRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Automobile Liability Policies Grid<br />
                                                    <a id="lnkAutoAdd" runat="server" href="javascript:Navigate_URL('AutomobilePolicyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upAutomobilePolicies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvAutomobilePolicies" runat="server" Width="100%" OnRowCommand="gvAutomobilePolicies_RowCommand" OnRowDataBound="gvAutomobilePolicies_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('AutomobilePolicyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Automobile_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" src='<%#((Convert.ToBoolean(Eval("HasRisk"))==true)? AppConfig.RiskImageURL : AppConfig.NoRiskImageURL )%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_Automobile_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" runat="server" id="tblAutomobileYes">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Automobile Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblAutomobileNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblAutomobileMsg" runat="server" SkinID="Message" Text="No data has been entered for Automobile Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="3" style="height: 5px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="Excess">Excess Liability Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblExcessRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoExcessRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Excess Liability Policies Grid<br />
                                                    <a id="lnkExcessAdd" runat="server" href="javascript:Navigate_URL('ExcessPolicyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upExcessPolicies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvExcessPolicies" runat="server" Width="100%" OnRowCommand="gvExcessPolicies_RowCommand" OnRowDataBound="gvExcessPolicies_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('ExcessPolicyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Excess_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" src='<%#((Convert.ToBoolean(Eval("HasRisk"))==true)? AppConfig.RiskImageURL : AppConfig.NoRiskImageURL )%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_Excess_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" id="tblExcessYes" runat="server">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblExcessYMsg" runat="server" SkinID="Message" Text="No data has been entered for Excess Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblExcessNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblExcessMsg" runat="server" SkinID="Message" Text="No data has been entered for Excess Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="3" style="height: 5px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="WC">Worker’s Compensation/Employer Liability Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblWCRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoWCRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Worker’s Compensation/Employer Liability Policies Grid<br />
                                                    <a id="lnkWCAdd" runat="server" href="javascript:Navigate_URL('WCPolicyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upWCPolicies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvWCPolicies" runat="server" Width="100%" OnRowCommand="gvWCPolicies_RowCommand" OnRowDataBound="gvWCPolicies_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('WCPolicyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_WC_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" src='<%#((Convert.ToBoolean(Eval("HasRisk"))==true)? AppConfig.RiskImageURL : AppConfig.NoRiskImageURL )%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_WC_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" runat="server" id="tblWCYes">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblWCYMsg" runat="server" SkinID="Message" Text="No data has been entered for WC Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblWCNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblWCMsg" runat="server" SkinID="Message" Text="No data has been entered for WC Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="3" style="height: 5px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="Property">Property Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblPropertyRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoPropertyRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Property Policies Grid<br />
                                                    <a id="lnkPropertyAdd" runat="server" href="javascript:Navigate_URL('PropertyPolicyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upPropertyPolicies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvPropertyPolicies" runat="server" Width="100%" OnRowDataBound="gvPropertyPolicies_RowDataBound"
                                                                OnRowCommand="gvPropertyPolicies_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('PropertyPolicyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Property_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Building Value">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_Property_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" runat="server" id="tblPropertyYes">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblPropertyYMsg" runat="server" SkinID="Message" Text="No data has been entered for Property Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%-- </tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblPropertyNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblPropertyMsg" runat="server" SkinID="Message" Text="No data has been entered for Property Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="3" style="height: 5px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="Professional">Professional Liability Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblProfessionalRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoProfessionalRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Professional Liability Policies Grid<br />
                                                    <a id="lnkProfessionalAdd" runat="server" href="javascript:Navigate_URL('ProfessionalPolicy.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upProfessionalPolicies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvProfessionalPolicies" runat="server" Width="100%" OnRowCommand="gvProfessionalPolicies_RowCommand" OnRowDataBound="gvProfessionalPolicies_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('ProfessionalPolicy.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Professional_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" src='<%#((Convert.ToBoolean(Eval("HasRisk"))==true)? AppConfig.RiskImageURL : AppConfig.NoRiskImageURL )%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_Professional_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" runat="server" id="tblProfessionalYes">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblProfessionalYMsg" runat="server" SkinID="Message" Text="No data has been entered for Professional Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblProfessionalNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblProfessionalMsg" runat="server" SkinID="Message" Text="No data has been entered for Professional Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" colspan="3" style="height: 5px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" class="headerrowSmall">
                                                    <a name="Liquor">Other Liability Policies</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">Required?
                                                </td>
                                                <td width="2%" align="center">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblLiquorRequired" runat="server"></asp:Label>
                                                    <asp:RadioButtonList ID="rdoLiquorRequired" Width="15%" runat="server" SkinID="YesNoType">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Other Liability Policies Grid<br />
                                                    <a id="lnkLiquorAdd" runat="server" href="javascript:Navigate_URL('LiquorPolicyAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upLiquorPolicies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvLiquorPolicies" runat="server" Width="100%" OnRowCommand="gvLiquorPolicies_RowCommand" OnRowDataBound="gvLiquorPolicies_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle Width="40%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('LiquorPolicyAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Liquor_Policies").ToString())%>');">
                                                                                <%#Eval("Insurance_Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            $&nbsp;<%# Eval("Limit") != DBNull.Value ? clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))) : string.Empty %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Risk">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <img id="imgRisk" src='<%#((Convert.ToBoolean(Eval("HasRisk"))==true)? AppConfig.RiskImageURL : AppConfig.NoRiskImageURL )%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemovePolicy" CommandArgument='<%#Eval("PK_COI_Liquor_Policies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%" style="border-collapse: collapse; font-family: Tahoma; color: #333333; font-size: 8pt; display: none;" runat="server" id="tblLiabilityYes">
                                                                        <%--<tbody>--%>
                                                                        <tr align="left" style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <th scope="col" width="40%">Carrier
                                                                            </th>
                                                                            <th scope="col" width="20%">Limit
                                                                            </th>
                                                                            <th scope="col" width="20%">Risk
                                                                            </th>
                                                                            <th scope="col" width="20%">Remove
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="background-color: #eaeaea; font-family: Tahoma; font-size: 8pt;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblLiabilityYMsg" runat="server" SkinID="Message" Text="No data has been entered for Other Liability Policies"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                            <td align="left">
                                                                                <img id="imgRisk" src='..\Images\rdb-red.gif' alt="nodata" /></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <%--<tbody>--%>
                                                                    </table>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblLiabilityNo" runat="server">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblLiabilityMsg" runat="server" SkinID="Message" Text="No data has been entered for Other Liability Policies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel12" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Owners
                                        </div>
                                        <table cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="15%" align="left" valign="top">Owners Grid<br />
                                                    <a id="lnkOwnersAdd" runat="server" href="javascript:Navigate_URL('OwnerAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td width="2%" align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upOwners">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvOwners" runat="server" Width="100%" OnRowCommand="gvOwners_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('OwnerAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Owners").ToString())%>');">
                                                                                <%# clsGeneral.FormatName(Eval("First_Name"), Eval("Last_Name"))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_abbreviation, Eval("Zip_Code"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemoveOwner" CommandArgument='<%#Eval("PK_COI_Owners")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Owners"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 220px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel13" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Copies
                                        </div>
                                        <table cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="15%" align="left" valign="top">Copies Grid<br />
                                                    <a id="lnkCopiesAdd" runat="server" href="javascript:Navigate_URL('CopiesAddEdit.aspx');">--Add--</a>
                                                </td>
                                                <td width="2%" align="center" valign="top">:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:UpdatePanel runat="server" ID="upCopies">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvCopies" runat="server" Width="100%" OnRowCommand="gvCopies_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="30%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:Navigate_URL('CopiesAddEdit.aspx?id=<%# Encryption.Encrypt(Eval("PK_COI_Copies").ToString())%>');">
                                                                                <%#Eval("Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="60%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_abbreviation, Eval("Zip_Code"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" CommandName="RemoveCopies" CommandArgument='<%#Eval("PK_COI_Copies")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No data has been entered for Copies"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 220px;"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <div id="Div1" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <uc:ctrlAttachment ID="Attachment" runat="Server" ShowAttachmentButton="true" ShowAttachmentType="true"
                                                    OnbtnHandler="Attachment_btnHandler" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 10px;"></td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Panel ID="dvAttachment" runat="server" Width="100%" Style="display: none; height: 100%;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" ShowReplaceColumn="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 200px;"></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <div id="Div2" runat="server" style="display: none;">
                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                            <tr>
                                                <td colspan="3">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="45%"></td>
                                                            <td valign="top" align="right">
                                                                <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                            <tr>
                                                <td valign="top" style="width: 15%">Notes Grid<br />
                                                    <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                        OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                </td>
                                                <td align="center" valign="top" style="width: 3%">:
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
                                                                    <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_COI_Notes") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                HeaderText="Note Date">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                        CommandName="EditRecord" CommandArgument='<%#Eval("PK_COI_Notes") %>' Width="80px"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                            HeaderText="User">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                                                    CommandName="EditRecord" CommandArgument='<%#Eval("PK_COI_Notes") %>' Width="100px"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                HeaderText="Notes">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                        CommandArgument='<%#Eval("PK_COI_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                HeaderText="Remove">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                        CommandArgument='<%#Eval("PK_COI_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                        Width="80px"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
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
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td width="5px" class="Spacer">&nbsp;
                                                </td>
                                                <td class="dvContainer">
                                                    <div id="DivEditNotes" runat="server" width="794px" style="display: none">
                                                        <div class="bandHeaderRow">
                                                            Notes
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Date of Note&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtNote_Date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                                                    <img alt="Date of Note" onclick="return showCalendar('<%= txtNote_Date.ClientID %>', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" id="imgtxtNote_Date" />
                                                                    <asp:RegularExpressionValidator ID="rvtxtNote_Date" runat="server" ControlToValidate="txtNote_Date"
                                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                        ErrorMessage="[Notes]/Date of Note is Not Valid Date." Display="none" SetFocusOnError="true">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Notes&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="CtrlMultiLineTextBox1" ControlType="TextBox" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="DivViewNotes" runat="server" width="794px" style="display: none">
                                                        <div class="bandHeaderRow">
                                                            Notes
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Date of Note
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblNote_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Notes
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="CtrlMultiLineTextBox2" ControlType="Label" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="DivNotesList" runat="server" width="794px" style="display: none">
                                                        <div class="bandHeaderRow">
                                                            Notes
                                                        </div>
                                                        <table cellpadding="1" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td width="100%">
                                                                    <div style="width: 785px; height: 370px; overflow-x: hidden; overflow-y: scroll;">
                                                                        <asp:Repeater ID="rptNotes" runat="server">
                                                                            <ItemTemplate>
                                                                                <table cellpadding="1" cellspacing="1" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                <tr>
                                                                                                    <td width="18%" align="left" valign="top">Date of Note
                                                                                                    </td>
                                                                                                    <td width="4%" align="center" valign="top">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top">Notes
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top" colspan="4">
                                                                                                        <uc:ctrlMultiLineTextBox ID="lblNoteText" runat="server" Text='<%# Eval("Note") %>'
                                                                                                            ControlType="Label" Width="540" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="height: 30px">
                                                                                        <td colspan="2" style="vertical-align: middle;">
                                                                                            <hr size="1" color="Black" style="width: 758px;" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnPrintSelectedNotes" runat="server" Text=" Print " OnClick="btnPrintSelectedNotes_Click"
                                                                        CausesValidation="false" />&nbsp;
                                                        <asp:Button ID="btnCancel" runat="server" Text=" Return " OnClick="btnCancel_Click"
                                                            CausesValidation="false" />&nbsp;
                                                        <asp:Button ID="btnMail" runat="server" Text=" Mail " OnClientClick="return OpenMailPopUp();"
                                                            CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <div id="dvSave" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="Spacer" style="height: 10px;"></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <input id="btnPrev" runat="server" onclick="javascript: ShowPrevNext(-1);" type="button"
                                        value="Previous" style="background-position: left top; height: 22px; background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnSave" runat="server" SkinID="SaveAndView" CausesValidation="true"
                                        ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" OnClick="btnSave_Click" />&nbsp;
                                    <input id="btnNext" runat="server" onclick="javascript: ShowPrevNext(1);" style="background-position: left top; height: 22px; background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold; cursor: pointer;"
                                        type="button" value=" Next " />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 10px;"></td>
                                <td class="Spacer" style="height: 10px;"></td>
                            </tr>
                        </table>
                    </div>
                    <div id="dvBack" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="Spacer" style="height: 10px;" width="100%" colspan="3"></td>
                            </tr>
                            <tr>
                                <td width="36%" align="right">
                                    <input id="btnPreviousView" runat="server" onclick="javascript: ShowPrevNext(-1);"
                                        type="button" value="Previous" style="background-position: left top; height: 22px; background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation="false" Visible="false"
                                        OnClick="btnEdit_Click" />
                                </td>
                                <td width="12%" align="center">
                                    <asp:Button ID="btnBack" runat="server" SkinID="Back" CausesValidation="false" OnClick="btnBack_Click" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnGenerateLetter" runat="server" Text="Generate Letter" OnClientClick="javascript:OpenPopupLetter();return false;"
                                        Style="background-position: left top; height: 22px; background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" />
                                    <input id="btnNextView" runat="server" onclick="javascript: ShowPrevNext(1);" style="background-position: left top; height: 22px; background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold; cursor: pointer;"
                                        type="button" value=" Next " />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 10px;" colspan="3">
                                    <asp:Button ID="btnDummyForSave" runat="server" OnClick="btnDummyForSave_Click" Style="display: none" />
                                    <input type="hidden" id="hdnPageName" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <%--   <tr>
            <td> <asp:Button ID="btnreadonly" runat="server" OnClick="btnreadonly_Click" Style="display: none" /> </td>
            </tr>--%>
            <asp:HiddenField ID="hdntxtName" runat="server" />
            <asp:HiddenField ID="hdnLandlordName" runat="server" />
            <asp:HiddenField ID="hdnBuilding_Number" runat="server" />
            <asp:HiddenField ID="hdnstrRegion" runat="server" />
            <asp:HiddenField ID="hdntxtAddress1" runat="server" />
            <asp:HiddenField ID="hdntxtAddress2" runat="server" />
            <asp:HiddenField ID="hdntxtCity" runat="server" />
            <asp:HiddenField ID="hdndrpState" runat="server" />
            <asp:HiddenField ID="hdntxtZipCode" runat="server" />
            <asp:HiddenField ID="hdntxtBuilding_TIV" runat="server" />
            <asp:HiddenField ID="hdntxtContactFirstName" runat="server" />
            <asp:HiddenField ID="hdntxtContactLastName" runat="server" />
            <asp:HiddenField ID="hdntxtContactTitle" runat="server" />
            <asp:HiddenField ID="hdntxtContactPhone" runat="server" />
            <asp:HiddenField ID="hdntxtContactFax" runat="server" />
            <asp:HiddenField ID="hdntxtContactEmail" runat="server" />
            <asp:HiddenField ID="hdnDBA" runat="server" />
            <asp:HiddenField ID="hdnPK_Building_Ownership_ID" runat="server" Value="0" />
            <asp:HiddenField ID="hdnPK_LU_Location_ID" runat="server" Value="0" />
            <asp:HiddenField ID="hdnPK_Building_Ownership_ID_Old" runat="server" Value="0" />
            <asp:Button ID="btnOwnershipDetails" runat="server" Text="" OnClick="btnOwnershipDetails_Click"
                Style="display: none;" />
        </table>
    </div>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
