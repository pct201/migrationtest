<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Property.aspx.cs"
    Inherits="Exposures_Property" Title="eRIMS Sonic :: Exposures :: Property Cope" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>greybox/';     
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script type="text/javascript" language="javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(pageLoaded);

        function pageLoaded(sender, args) {
            window.scrollTo(0, 0);
        }

        function ShowHideSabaTrainingYear() {
            var dt = document.getElementById('<%=txtSaba_Training_Date.ClientID %>').value;
            document.getElementById('<%=trSabaTrainingYear.ClientID %>').style.display = (dt == '') ? '' : 'none';
            document.getElementById('<%=trSabaTrainingQuarter.ClientID %>').style.display = (dt == '') ? '' : 'none';
        }

        function AuditPopUp(page) {
            var pageName = "";
            var ID = "";
            if (page == 'COPE') {
                pageName = "AuditPopup_PropertyCOPE.aspx"; ID = '<%=ViewState["PK_Property_Cope_ID"]%>';
            }
            else if (page == 'Building') {
                pageName = "AuditPopup_Building.aspx"; ID = document.getElementById('<%=hdnBuildingID.ClientID%>').value;
            }
            else if (page == 'Ownership') {
                // if ownership is "Owned"
                if (document.getElementById('<%=rdoOwnership.ClientID%>' + '_0').checked)
                    pageName = "AuditPopup_OwnershipDetail_Owned.aspx";
                else
                    pageName = "AuditPopup_OwnershipDetail_Leased.aspx";

                ID = document.getElementById('<%=hdnBuildingOwnershipID.ClientID%>').value;
            }
            else if (page == 'Additional_Insured') {
                pageName = "AuditPopup_Additional_Insured.aspx"; ID = document.getElementById('<%=hdnAdditionalInsured.ClientID%>').value;
            }
            else if (page == 'Loss_Payee') {
                pageName = "AuditPopup_Additional_Insured.aspx"; ID = document.getElementById('<%=hdnLossPayeeID.ClientID%>').value;
            }
            else if (page == 'Property_Assessment') {
                pageName = "AuditPopup_Property_Assessment.aspx"; ID = document.getElementById('<%=hdnAssessmentID.ClientID%>').value;
            }
            else if (page == 'Contacts') {
                pageName = "AuditPopup_Property_Contact.aspx"; ID = document.getElementById('<%=hdnBuildingID.ClientID%>').value;
            }
            else if (page == 'Sub_Lease') {
                pageName = "AuditPopup_BuildingOwnership_Sublease.aspx"; ID = document.getElementById('<%=hdnSubLeaseID.ClientID%>').value;
            }
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 200;

    obj = window.open(pageName + "?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function seLocationBuildingNumber(str) {
    document.getElementById("ctl00_ContentPlaceHolder1_ucCtrlExposureInfo_lblRMLocationNumber").innerText = str;
}

function ShowHideLiability() {
    var rdoID = '<%=rdoOwnership.ClientID%>';
    var trLb = document.getElementById('<%=trLiability.ClientID%>');
    if (document.getElementById(rdoID + '_1').checked || document.getElementById(rdoID + '_4').checked)
        trLb.style.display = "";
    else
        trLb.style.display = "none";
}

function ShowAuditPopUp(url) {
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 200;
    obj = window.open(url, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
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
                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtDisposal_Type') {
                            var ctlVal = document.getElementById('<%=ddlStatus.ClientID %>').options[document.getElementById("<%=ddlStatus.ClientID %>").selectedIndex].value;
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (ctlVal == 'Disposed')
                                bEmpty = true;
                        }
                        else
                            bEmpty = true;
                    }
                    break;
                case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
            }
            if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
        }
        if (msg.length > 0) {
            //sender.errormessage = msg;
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

function ValidateFieldsBuildInfo(sender, args) {
    var msg = '';
    var ctrlIDs = document.getElementById('<%=hdnControlIDsBuild.ClientID%>').value.split(',');
    var Messages = document.getElementById('<%=hdnErrorMsgsBuild.ClientID%>').value.split(',');
    var focusCtrlID = "";
    if (document.getElementById('<%=hdnControlIDsBuild.ClientID%>').value != "") {
        var i = 0;
        for (i = 0; i < ctrlIDs.length; i++) {
            var bEmpty = false;
            var ctrl = document.getElementById(ctrlIDs[i]);
            switch (ctrl.type) {
                case "textarea":
                    if (ctrl.value == '') {
                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_History_Descr_txtNote') {
                            var rdbFlh = document.getElementById('ctl00_ContentPlaceHolder1_rdoPrior_Flood_History_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbFlh.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtProperty_Loss_Descr_txtNote') {
                            var rdbPLoss = document.getElementById('ctl00_ContentPlaceHolder1_rdoProperty_Damage_Losses_in_the_Past_5_years_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbPLoss.checked)
                                bEmpty = true;
                        }
                        else
                            bEmpty = true;
                    }
                    break;
                case "text":
                    if (ctrl.value == '') {
                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtNeighbor_Occupancy') {
                            var rdbBw100 = document.getElementById('ctl00_ContentPlaceHolder1_rdoNeighboring_Buildings_within_100_ft_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbBw100.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtsecuCam_System' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Contact_Name' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Vendor_Name' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Contact_Expiration_Date' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Address_1' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Telephone_Number' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Address_2' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Alternate_Number' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_City' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Email' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Comments' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtSecuCam_Zip') {
                            var rdbSecCam = document.getElementById('ctl00_ContentPlaceHolder1_rdoAlarm_Security_Cameras_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbSecCam.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_System' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Contact_Name' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Vendor_Name' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Contact_Expiration_Date' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Address_1' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Telephone_Number' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Address_2' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Alternate_Number' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_City' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Email' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Comments' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGuard_Zip') {
                            var rdbGuardSys = document.getElementById('ctl00_ContentPlaceHolder1_rdoGuard_System_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbGuardSys.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_System' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Contact_Name' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Vendor_Name' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Contact_Expiration_Date' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Address_1' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Telephone_Number' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Address_2' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Alternate_Number' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_City' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Email' ||
                         ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Comments' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtIntru_Zip') {
                            var rdbInsAlarm = document.getElementById('ctl00_ContentPlaceHolder1_rdoIntru_System_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbInsAlarm.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtGenerator_Make' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGenerator_Model' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtGenerator_Size') {
                            var rdbGenerator = document.getElementById('ctl00_ContentPlaceHolder1_rdoGenerator_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbGenerator.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Carrier' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Policy_Inception_Date' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Policy_Number' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Policy_Expiration_Date'
                         || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Premium' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Deductible' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Polciy_Limits_Contents' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtFlood_Policy_Limits_Building') {
                            var rdbNFP = document.getElementById('ctl00_ContentPlaceHolder1_rdoNational_Flood_Policy_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbNFP.checked)
                                bEmpty = true;
                        }
                        else
                            bEmpty = true;
                    } break;
                case "select-one":
                    if (ctrl.selectedIndex == 0) {
                        if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlSecuCam_State') {
                            var rdbSecCam = document.getElementById('ctl00_ContentPlaceHolder1_rdoAlarm_Security_Cameras_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbSecCam.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlGuard_State') {
                            var rdbSecCam = document.getElementById('ctl00_ContentPlaceHolder1_rdoGuard_System_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbSecCam.checked)
                                bEmpty = true;
                        }
                        else if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlIntru_State' || ctrl.id == 'ctl00_ContentPlaceHolder1_ddlIntru_Contact_Alarm_Type') {
                            var rdbInsAlarm = document.getElementById('ctl00_ContentPlaceHolder1_rdoIntru_System_0');
                            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                            if (rdbInsAlarm.checked)
                                bEmpty = true;
                        }
                        else
                            bEmpty = true;
                    }
                    break;
                case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
            }
            if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
        }
        if (msg.length > 0) {
            //sender.errormessage = msg;
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

function ValidateFieldsOwnership(sender, args) {
    var msg = '';
    var ctrlIDs = document.getElementById('<%=hdnControlIDsOwnership.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsOwnership.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsOwnership.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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


        function ValidateFieldsPropertyCondition(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsPCA.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsPCA.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsPCA.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsConcernNote(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsConcernNote.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsConcernNote.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsConcernNote.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsContact(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsContact.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsContact.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsContact.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ConfirmProceed(pgURL) {
            var bConfirm = confirm("The contact details will not be saved until a building information is selected or saved. Are you sure to proceed?");
            if (bConfirm) {
                window.location.href = pgURL;
            }
            else
                ShowPanel(5);

        }

        function ValidateFieldsST(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsST.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsST.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsST.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + (i == ctrlIDs.length - 1 ? "" : "\n");
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsAdditionalInsured(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsAI.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsAI.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsAI.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
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

        function ValidateFieldsLossPayee(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsLossPayee.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsLossPayee.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsLossPayee.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
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

        function ValidateFieldsBuildindOwnerSubLease(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsBuildingOwnerShipSubLease.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsBuildingOwnerShipSubLease.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsBuildingOwnerShipSubLease.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
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
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <asp:ValidationSummary ID="valPropertyCOPE" runat="server" ValidationGroup="vsErrorPropertyCope"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="valBuilding" runat="server" ValidationGroup="vsErrorBuilding"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="valOwnership" runat="server" ValidationGroup="vsErrorOwnership"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vsErrorAdditionalInsured"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vsErrorLossPayee"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ValidationGroup="vsErrorBuildindOwnerSubLease"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="vsErrorAssessment"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="vsErrorConcern"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary5" runat="server" ValidationGroup="vsErrorContact"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ValidationGroup="vsErrorSabaTraining"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
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
                            <asp:UpdatePanel ID="upPanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table class="ctl00_ContentPlaceHolder1_mnuProperty_2" id="ctl00_ContentPlaceHolder1_mnuProperty"
                                            cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn0" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(1);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuSelected" id="PropertyMenu1" onclick="javascript:ShowPanel(1);">Property Cope </span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn1" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a class="ctl00_ContentPlaceHolder1_mnuProperty_1" href="javascript:void(2);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu2" onclick="javascript:ShowPanel(2);">Building Information</span>&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn2" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(4);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu4" onclick="javascript:ShowPanel(4);">Building Improvements</span>&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red; display: none">*</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn3" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(5);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu5" onclick="javascript:ShowPanel(5);">Contacts
                                                                                            </span>&nbsp;<span id="MenuAsterisk4" runat="server" style="color: Red; display: none">*</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
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
                                    <td style="width: 5px">&nbsp;
                                    </td>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server">
                                            <asp:Panel ID="pnlPropertyCope" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="server" ID="updPropertyCope" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="bandHeaderRow" id="hdrPropertyCope" runat="server">
                                                            Property Cope
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblPropertyCope" runat="server">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Location d/b/a
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label runat="server" ID="lblLocationdba"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Legal Entity Name
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label runat="server" ID="lblLegalEntity"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Location f/k/a
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblLocationfka"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Sonic Location Code
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblLocationRMNumber"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Status&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlStatus" SkinID="ddlExposure" onChange="CheckStatus();">
                                                                        <asp:ListItem Text="--SELECT--" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                                        <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                                                        <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">Status as of Date &nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtStatus_As_Of_Date" Width="170px" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img alt="Status As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStatus_As_Of_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6" id="tdDisposal" runat="server" style="display: none">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" width="18%" valign="top">Disposal Type&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" width="4%" valign="top">:
                                                                            </td>
                                                                            <td align="left" width="28%" valign="top">
                                                                                <asp:TextBox runat="server" ID="txtDisposal_Type" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Union Shop?
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList runat="server" ID="rdoUnion_Shop" SkinID="YesNoTypeNullSelection">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">Property Boundary Dimension&nbsp;<span id="Span4" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Boundry_Dimension" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <b>Primary/Physical Address</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Address 1&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtAddress_1" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">Telephone&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTelephone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regTelephone" ControlToValidate="txtTelephone"
                                                                        SetFocusOnError="true" runat="server" ValidationGroup="vsErrorPropertyCope" ErrorMessage="Please Enter Telephone Number in xxx-xxx-xxxx format."
                                                                        Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Address 2&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtAddress_2" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">Web Site&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtWeb_Site" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regWebSite" runat="server" Display="none" Enabled="true"
                                                                        ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?|(http(s)?://)([\w-]+\.)*[\w-]+(/[\w- ./?%&=]*)?"
                                                                        ControlToValidate="txtWeb_Site" SetFocusOnError="true" ValidationGroup="vsErrorPropertyCope"
                                                                        ErrorMessage="Web site URL is not valid" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">City&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtCity" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">State&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlState" Width="170px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="3">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Zip&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtZip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code is not valid"
                                                                        ValidationGroup="vsErrorPropertyCope" SetFocusOnError="true" ControlToValidate="txtZip"
                                                                        ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                                                                </td>
                                                            </tr>
                                                            <!-- Commented below Section for ticket #3132 -->
                                                            <%-- <tr>
                                                                <td colspan="6" width="100%">
                                                                    <b>Financial Limits(Summary of all buildings)</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Valuation Date&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtValuation_Date" runat="server" Width="170px" SkinID="txtdate"></asp:TextBox>
                                                                    <img alt="Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtValuation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RangeValidator ID="regValuation_Date" ControlToValidate="txtValuation_Date"
                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Valuation Date is not valid."
                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsErrorPropertyCope" Display="none" />
                                                                </td>
                                                                <td align="left" valign="top">Building Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblBuilding_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Leasehold Interests<br />
                                                                    Limit - Betterment
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblLeasehold_Interests_Limit_Betterment" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Betterment Date Complete
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblBetterment_Date_Complate" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Leasehold Interests<br />
                                                                    Limit - Expansion
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblLeasehold_Interests_Limit_Expansion" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Expansion Date Complete
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblExpansion_Date_Complate" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Associate Tools Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblAssociate_Tools_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Contents Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblContents_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">Parts Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblParts_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">RS Means Building Value
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRS_Means_Building_Value_Total" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">Business Interruption
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <asp:GridView ID="gvBusinessInterruption" runat="server" Width="100%" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type&nbsp;&nbsp;<i>Click to view detail</i>">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("TypeDesc").ToString() != "Total" ? "<a href='#' onclick=\"OpenSelectYearPopup('" + Eval("Type") + "')\">" + Eval("TypeDesc") + "</a>" : "<b>Total</b>"%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>--%>
                                                            <!-- Commented above Section for ticket #3132 -->
							<%--
                                                            <tr>
                                                                <td align="left" valign="top">Inventory Level
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblInventory_Levels" Width="170px" ReadOnly="true"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">TIV
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblCalculated" runat="server" Width="170px" ReadOnly="true"></asp:Label>
                                                                </td>
                                                            </tr>
							--%>
                                                            <tr>
                                                                <td align="left" valign="top">Saba Training Grid
                                                                    <br />
                                                                    <asp:LinkButton ID="lbAddSabaTraining" runat="server" Text="--Add--" OnClick="lbAddSabaTraining_Click"
                                                                        CausesValidation="true" ValidationGroup="vsErrorPropertyCope"></asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4" align="left" valign="top">
                                                                    <asp:HiddenField ID="hdnPKPropertySabaTraning" runat="server" />
                                                                    <asp:GridView ID="gvSabaTraining" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                        OnRowCommand="gvSabaTraining_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date")) %>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnYear" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# Eval("Year") %>' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year") %>' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Quarter">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnQuarter" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# Eval("Quarter") %>' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblQuarter" runat="server" Text='Running Total' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Number of Associates To Train">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnEmployees" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Employees")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblEmployees" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Employees")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Number of Associates Trained">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnEmployeesTrained" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# clsGeneral.GetStringValue(Eval("Number_Trained")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblEmployeesTrained" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_Trained")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Percent of Associates Trained">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnPercent" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# Eval("Percent_Trained") !=DBNull.Value ? Eval("Percent_Trained") + "%" : "" %>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblPercent" runat="server" Text='<%# Eval("Percent_Trained") !=DBNull.Value ? Eval("Percent_Trained") + "%" : "" %>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="8%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbRemove" runat="server" Text="Remove" OnClientClick="return returnConfirm();"
                                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            No Record Found !
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <asp:Button runat="server" ID="btnPropertyCopeSave" Text="Save & Next" OnClick="btnPropertyCopeSave_Click"
                                                                        CausesValidation="true" ValidationGroup="vsErrorPropertyCope" />&nbsp;
                                                                    <asp:Button ID="btnViewAuditPropertyCOPE" runat="server" Text="View Audit Trail"
                                                                        OnClientClick="javascript:return AuditPopUp('COPE');" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel ID="pnlSabaTraining" runat="server" Width="100%">
                                                            <div class="bandHeaderRow">
                                                                Saba Training
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%" valign="top">Date&nbsp;<span id="Span138" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSaba_Training_Date" runat="server" Width="170px" SkinID="txtDate"
                                                                            onblur="ShowHideSabaTrainingYear();"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSaba_Training_Date', 'mm/dd/y',ShowHideSabaTrainingYear,'');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RangeValidator ID="regFinancial_Betterment_Date_Complate" ControlToValidate="txtSaba_Training_Date"
                                                                            MinimumValue="01/01/1753" MaximumValue="12/31/2010" Type="Date" ErrorMessage="[Property Cope]/Date must be valid and should be for years less than 2011."
                                                                            runat="server" SetFocusOnError="true" ValidationGroup="vsErrorSabaTraining" Display="none" />
                                                                        <%-- <asp:RequiredFieldValidator ID="rfvtxtSaba_Training_Date" runat="server" ErrorMessage="Please Enter [Saba Training]/Date."
                                                                            Display="None" SetFocusOnError="true" ControlToValidate="txtSaba_Training_Date"
                                                                            ValidationGroup="vsErrorSabaTraining"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trSabaTrainingYear" runat="server">
                                                                    <td align="left" width="21%" valign="top">Year
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpSabaTrainingYear" runat="server" Width="175px" SkinID="dropGen" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="trSabaTrainingQuarter" runat="server">
                                                                    <td align="left" valign="top">Quarter
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpQuarter" runat="server" Width="175px" SkinID="dropGen">
                                                                            <asp:ListItem Text="1" Value="1" />
                                                                            <asp:ListItem Text="2" Value="2" />
                                                                            <asp:ListItem Text="3" Value="3" />
                                                                            <asp:ListItem Text="4" Value="4" />
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Number of Associates To Train&nbsp;<span id="Span139" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox runat="server" ID="txtNumber_of_Employees" Width="170px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,6,true);" onblur="GetPercentTrained();"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Number of Associates Trained&nbsp;<span id="Span140" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox runat="server" ID="txtNumber_of_Employees_To_Date" Width="170px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,6,true);" onblur="GetPercentTrained();"></asp:TextBox>
                                                                        <asp:CompareValidator ID="cvNumber_Employees" runat="server" ControlToValidate="txtNumber_of_Employees"
                                                                            ValidationGroup="vsErrorSabaTraining" ErrorMessage="Number of Associates To Train must be Greater Than or Equal to Number of Associates Trained."
                                                                            Type="Currency" Operator="GreaterThanEqual" ControlToCompare="txtNumber_of_Employees_To_Date"
                                                                            Display="none"></asp:CompareValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Percent of Associates Trained&nbsp;<span id="Span141" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox runat="server" ID="txtPercent_Employee_to_Date" Width="170px" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" align="left" valign="top">
                                                                        <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Button ID="btnSaveSabaTraining" runat="server" Text="Save" OnClick="btnSaveSabaTraining_Click"
                                                                                        CausesValidation="true" ValidationGroup="vsErrorSabaTraining" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnViewAuditSabaTraining" runat="server" Text="View Audit Trail" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnBackSabaTraing" runat="server" Text="Back" OnClick="btnBackProperty_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                    <%--<Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="lbAddSabaTraining" EventName="Click" />
                                                    </Triggers>--%>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlBuildingInformation" runat="server" Width="100%" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Building Information
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updBuildingInfo" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:GridView ID="gvBuildingEdit" runat="server" EmptyDataText="No Building Records Exists"
                                                                        AutoGenerateColumns="false" OnRowCommand="gvBuildingEdit_RowCommand" OnRowDataBound="gvBuildingEdit_RowDataBound"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemStyle Width="5%" HorizontalAlign="center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkViewDetail" CausesValidation="false" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                        CommandName="ViewBuildingDetail" CommandArgument='<%# Eval("PK_Building_ID")%>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Building Number">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Building_Number")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Occupancy">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblOccupancy" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="LinkButton1" TeID="lnkRemove" OnClientClick="return ConfirmRemove();" CausesValidation="false"
                                                                                        runat="server" CommandName="RemoveBuilding" CommandArgument='<%#Eval("PK_Building_ID")%>'
                                                                                        Text="Remove"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:LinkButton ID="lnkAddNewBuilding" runat="server" OnClick="lnkAddNewBuilding_Click"
                                                                        Text="Add New" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="dvBuilding" runat="server" style="display: none;">
                                                                        <table cellpadding="3" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="left" valign="top">Status&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td width="2%" align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:DropDownList ID="drpLocationStatus" runat="server" SkinID="dropGen" Width="170px">
                                                                                        <asp:ListItem Text="--Select--" Value="" Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                                                        <asp:ListItem Text="Demolished" Value="Demolished"></asp:ListItem>
                                                                                        <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                                                                                        <asp:ListItem Text="Due Diligence" Value="Due Diligence"></asp:ListItem>
                                                                                        <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Ownership</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoOwnership" RepeatDirection="Vertical"
                                                                                        RepeatColumns="1" onclick="ShowHideLiability();">
                                                                                        <asp:ListItem Text="Sonic Owned with Internal Lease" Value="Internal"></asp:ListItem>
                                                                                        <asp:ListItem Text="Sonic Owned with Third Party Lease" Value="ThirdParty"></asp:ListItem>
                                                                                        <asp:ListItem Text="Sonic Owned" Value="Owned"></asp:ListItem>
                                                                                        <asp:ListItem Text="Third Party Owned and Sonic Leased" Value="ThirdPartyLease"></asp:ListItem>
                                                                                        <asp:ListItem Text="Third Party Owned and Sonic Leased and Subleased to Third Party"
                                                                                            Value="ThirdPartySublease"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trLiability" runat="server" style="display: none">
                                                                                <td align="left" colspan="6">
                                                                                    <b>Liability</b><br />
                                                                                    <asp:RadioButtonList ID="rdoLiability" runat="server" RepeatDirection="Vertical"
                                                                                        RepeatColumns="1">
                                                                                        <asp:ListItem Text="Assigned with Liability" Value="Assigned with Liability" />
                                                                                        <asp:ListItem Text="Assigned without Liability" Value="Assigned without Liability" />
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Occupancy</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6" width="100%">
                                                                                    <asp:CheckBoxList runat="server" ID="chkLstOccupancy" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                                        Width="100%">
                                                                                        <asp:ListItem Text="Sales - New"></asp:ListItem>
                                                                                        <asp:ListItem Text="Body Shop"></asp:ListItem>
                                                                                        <asp:ListItem Text="Parking Lot"></asp:ListItem>
                                                                                        <asp:ListItem Text="Sales - Used"></asp:ListItem>
                                                                                        <asp:ListItem Text="Parts"></asp:ListItem>
                                                                                        <asp:ListItem Text="Raw Land"></asp:ListItem>
                                                                                        <asp:ListItem Text="Service"></asp:ListItem>
                                                                                        <asp:ListItem Text="Office"></asp:ListItem>
                                                                                        <asp:ListItem Text="Car Wash"></asp:ListItem>
                                                                                        <asp:ListItem Text="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="2"></asp:ListItem>
                                                                                        <asp:ListItem Text="Photo Booth"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Address</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" width="18%" valign="top">Address 1&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" width="4%" valign="top">:
                                                                                </td>
                                                                                <td align="left" width="28%" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtBuildingAddress_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" width="18%" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" width="4%" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" width="28%" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Address 2&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtBuildingAddress_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">City&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtBuilding_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">State&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:DropDownList runat="server" ID="ddlBuidingState" SkinID="ddlExposure">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Zip&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtBuilding_Zip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="revBuildingZipCode" runat="server" ErrorMessage="Building Zip Code is not valid"
                                                                                        ControlToValidate="txtBuilding_Zip" ValidationGroup="vsErrorBuilding" SetFocusOnError="true"
                                                                                        ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Financial Limits</b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--<tr>
                                                                                <td class="Spacer" style="height: 8px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Building Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:TextBox ID="txtFinancial_Building_Limit" runat="server" Width="170px" OnBlur="CountFinancialLimits();"
                                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td align="left" valign="top">
                                                                                    Leasehold Interests<br />
                                                                                    Limit - Betterment
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Leasehold_Interests_Limit_Betterment" runat="server"
                                                                                        Width="170px" OnBlur="CountFinancialLimits();" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Betterment Date Complete
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Betterment_Date_Complate" runat="server" Width="170px"
                                                                                        SkinID="txtDate"></asp:TextBox>
                                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFinancial_Betterment_Date_Complate', 'mm/dd/y');"
                                                                                        onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                                        align="middle" />
                                                                                    <asp:RangeValidator ID="regFinancial_Betterment_Date_Complate" ControlToValidate="txtFinancial_Betterment_Date_Complate"
                                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Betterment Date Complete is not valid."
                                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Leasehold Interests<br />
                                                                                    Limit - Expansion
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Leasehold_Interests_Limit_Expansion" runat="server"
                                                                                        Width="170px" OnBlur="CountFinancialLimits();" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Expansion Date Complete
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Expansion_Date_Complate" runat="server" Width="170px"
                                                                                        SkinID="txtDate"></asp:TextBox>
                                                                                    <img alt="Expansion Complete Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFinancial_Expansion_Date_Complate', 'mm/dd/y');"
                                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                        align="middle" />
                                                                                    <asp:RangeValidator ID="regtxtFinancial_Expansion_Date_Complate" ControlToValidate="txtFinancial_Expansion_Date_Complate"
                                                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Expansion Date Complete is not valid."
                                                                                        runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Associate Tools Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Associate_Tools_Limit" runat="server" Width="170px"
                                                                                        OnBlur="CountFinancialLimits();" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Contents Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Contents_Limit" runat="server" Width="170px" OnBlur="CountFinancialLimits();"
                                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Parts Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtFinancial_Parts_Limit" runat="server" Width="170px" onBlur="CountFinancialLimits();"
                                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                     Inventory Levels
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                     <asp:TextBox runat="server" ID="txtFinancial_Inventory_Levels" Width="170px" onBlur="CountFinancialLimits();"
                                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Total
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtFinancial_Total" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    RS Means Building Value
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtRS_Means_Building_Value" runat="server" Width="170px" onBlur="CountFinancialLimits();"
                                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 5px;">
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td align="left" valign="top">Financial Limits Grid<br />
                                                                                    <asp:LinkButton ID="lnkFinancialLimitGrid" runat="server" Text="--Add--" OnClick="lnkFinancialLimitGrid_Click" />
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top" colspan="4">
                                                                                    <asp:GridView ID="gvFinancialLimit" runat="server" Width="100%" OnRowCommand="gvFinancialLimit_RowCommand"
                                                                                        EmptyDataText="No Record Found">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Property Valuation Date">
                                                                                                <ItemStyle Width="18%" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkPVDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Property_Valuation_Date"))%>'
                                                                                                        CommandArgument='<%#Eval("PK_Building_Financial_Limits")%>' CommandName="ShowDetails" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total Value $">
                                                                                                <ItemStyle Width="18%" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkTotal" runat="server" Text='<%# string.Format("{0:N2}",Eval("Total")) %>'
                                                                                                        CommandArgument='<%#Eval("PK_Building_Financial_Limits")%>' CommandName="ShowDetails" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                                <ItemStyle Width="10%" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Building_Financial_Limits")%>'
                                                                                                        CommandName="RemoveDetails" OnClientClick="return confirm('Are you sure that you want to delete the selected record from the Financial Limit Grid?');" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Exterior</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="19%">Number of Parking Spaces&nbsp;<span id="Span155" style="color: Red; display: none;"
                                                                                                runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" width="3%" style="padding-left: 4px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="29%" style="padding-left: 12px;">
                                                                                                <asp:TextBox runat="server" ID="txtNumber_Of_Parking_Spaces" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,4,true);"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 3px;" width="19%">Acreage
                                                                                    
                                                                                    &nbsp;<span id="Span156" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="3%" style="padding-left: 1px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="27%">
                                                                                                <asp:TextBox runat="server" ID="txtAcreage" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumberToDec(event,this.id,8,false,3);"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="19%">Year Built&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" width="3%" style="padding-left: 4px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="29%" style="padding-left: 12px;">
                                                                                                <asp:TextBox runat="server" ID="txtYear_Built" Width="170px" MaxLength="4" onkeypress="return isValid(this);"
                                                                                                    onblur="YearValidate(this.id);"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 3px;" width="19%">Square Footage&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="3%" style="padding-left: 1px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="27%">
                                                                                                <asp:TextBox runat="server" ID="txtSquare_Footage" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Stories&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtNumber_of_Stories" Width="170px" onpaste="return false"
                                                                                        onkeypress="return FormatNumber(event,this.id,9,false);"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Roof</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkRoof_Reinforced_Concrete" Text="Reinforced Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkRoof_Concrete_Panels" Text="Concrete Panels" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkRoof_Steel_Deck_With_Fasteners" Text="Steel Deck With Fasteners" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkRoof_Poured_Concrete" Text="Poured Concrete" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkRoof_Steel_Deck" Text="Steel Deck" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkRoof_Wood_Joists" Text="Wood Joists" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Floors</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkFloors_Reinforced_Concrete" Text="Reinforced Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkFloors_Poured_Concrete" Text="Poured Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkFloors_Wood_Timber" Text="Wood Timber" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Exterior Walls</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkExt_Walls_Reinforced_Concrete" Text="Reinforced Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkExt_Walls_Masonry" Text="Masonry" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkExt_Walls_Corrugated_Metal_Panels" Text="Corrugated Metal Panels" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkExt_Walls_Tilt_up_Concrete" Text="Tilt-up Concrete" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkExt_Walls_Glass_and_Steel_Curtain" Text="Glass and Steel Curtain" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkExt_Walls_Wood_Frame" Text="Wood Frame" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Interior Walls</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkInt_Walls_Masonry_With_Fire_Doors" Text="Masonry With Fire Doors" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkInt_Walls_Masonry_with_Openings" Text="Masonry with Openings" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkInt_Walls_No_Interior_Walls" Text="No Interior Walls" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkInt_Walls_Masonry" Text="Masonry" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CheckBox runat="server" ID="chkInt_Walls_Gypsum_Board" Text="Gypsum Board" />
                                                                                            </td>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Do major interior masonry walls(fire walls) extend above roof line
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoInt_wall_extend_above_roof" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    <%-- Number of Paint Booths&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>--%>
                                                                                </td>
                                                                                <td align="center" valign="top"></td>
                                                                                <td align="left" valign="top">
                                                                                    <%--<asp:TextBox runat="server" ID="txtNumber_of_Paint_Booths" Width="170px" onpaste="return false"
                                                                                        onkeypress="return FormatNumber(event,this.id,9,true);"></asp:TextBox>--%>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <%--Number of Lifts &nbsp;<span id="Span23" style="color: Red; display: none;"
                                                                                        runat="server">*</span>--%>
                                                                                </td>
                                                                                <td align="center" valign="top"></td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox runat="server" ID="txtNumber_of_Lifts" Width="170px" onpaste="return false"
                                                                                        onkeypress="return FormatNumber(event,this.id,9,true);" Visible="false"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <%--<asp:Panel ID="pnlInsuranceCope" runat="server">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="left" >--%>
                                                                                    <table id="tblInsurance" runat="server" width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td colspan="6" align="left"><b>Insurance COPE</b><br />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <%--</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>--%>                                                                                   
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Protection</b><br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Automatic Sprinklers</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="19%">Sales - New
                                                                                    <br />
                                                                                                % Sprinklered&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" width="3%" style="padding-left: 4px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 10px" width="29%">
                                                                                                <asp:TextBox runat="server" ID="txtSales_New_Sprinklered" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,10,false);"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 3px;" width="19%">Sales - Used
                                                                                    <br />
                                                                                                &nbsp;% Sprinklered&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 1px;" width="3%">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 0px" width="27%">
                                                                                                <asp:TextBox runat="server" ID="txtSales_Used_Sprinklered" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,10,false);"></asp:TextBox>
                                                                                            </td>

                                                                                        </tr>

                                                                                    </table>

                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="19%">Service
                                                                                    <br />
                                                                                                % Sprinklered&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" width="3%" style="padding-left: 4px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 10px" width="29%">
                                                                                                <asp:TextBox runat="server" ID="txtService_Sprinklered" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,10,false);"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 3px;" width="19%">Body Shop
                                                                                    <br />
                                                                                                &nbsp;% Sprinklered&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 1px;" width="3%">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 0px" width="27%">
                                                                                                <asp:TextBox runat="server" ID="txtBody_Shop_Sprinklered" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,10,false);"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="19%">Parts
                                                                                    <br />
                                                                                                % Sprinklered&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" width="3%" style="padding-left: 4px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 10px" width="29%">
                                                                                                <asp:TextBox runat="server" ID="txtParts_Sprinklered" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,10,false);"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 3px;" width="19%">Office
                                                                                    <br />
                                                                                                &nbsp;% Sprinklered&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="left" valign="top" width="3%" style="padding-left: 1px;">:
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="padding-left: 0px" width="27%">
                                                                                                <asp:TextBox runat="server" ID="txtOffice_Sprinklered" Width="170px" onpaste="return false"
                                                                                                    onkeypress="return FormatNumber(event,this.id,10,false);"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Water Supply</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 33%" valign="top">
                                                                                                <asp:CheckBox runat="server" ID="chkWater_Public" Text="Public" />
                                                                                            </td>
                                                                                            <td style="width: 33%" valign="top">
                                                                                                <asp:CheckBox runat="server" ID="chkWater_Private" Text="Private" />
                                                                                            </td>
                                                                                            <td style="width: 34%" valign="top">
                                                                                                <asp:CheckBox runat="server" ID="chkWater_Boosted" Text="Boosted by Fire Pump" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td class="Spacer" style="height: 10px;" colspan="6"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%" valign="top">
                                                                                                <asp:Label ID="Label51" runat="server" Text="Design Densities for each area?" Width="146px"></asp:Label>
                                                                                                &nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">
                                                                                                <asp:Label ID="Label52" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px" valign="top">
                                                                                                <asp:TextBox runat="server" ID="txtDesign_Densities_for_each_area" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;" valign="top">
                                                                                                <asp:Label ID="Label53" runat="server" Text="Hydrants located within 500 feet of buildings" Width="132px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">
                                                                                                <asp:Label ID="Label5" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px" valign="top">
                                                                                                <asp:RadioButtonList runat="server" ID="rdoHydrants_within_500_ft" SkinID="YesNoTypeNullSelection"></asp:RadioButtonList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Supervisor Alarms Provided</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_UL_Central_Station" Text="UL Central Station" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Constant_Attended" Text="Constant Attended" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Sprinkler_Valve_Tamper" Text="Sprinkler Valve Tamper" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Non_UL_Central_Station" Text="Non UL-Central Station" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Local" Text="Local" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Smoke_Detectors" Text="Smoke Detectors" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Proprietary" Text="Proprietary" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Sprinkler_Waterflow" Text="Sprinkler Waterflow" />
                                                                                            </td>
                                                                                            <td style="width: 34%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Dry_Pipe_Air" Text="Dry Pipe Air" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Remote" Text="Remote" />
                                                                                            </td>
                                                                                            <td style="width: 33%">
                                                                                                <asp:CheckBox runat="server" ID="chkAlarm_Fire_Pump_Alarms" Text="Fire Pump Alarms" />
                                                                                            </td>
                                                                                            <td style="width: 34%">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Auto Fire Alarms
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoAlarm_Auto_Fire_Alarms" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Fire Inspection Company</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label1" runat="server" Text="Contact Name" Width="146px"></asp:Label>
                                                                                                &nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label25" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireContactName" Width="170px" MaxLength="50" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label2" runat="server" Text="Vendor Name"></asp:Label>
                                                                                                &nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label26" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireVendorName" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">Contract Expiration Date&nbsp;<span id="Span33" style="color: Red; display: none;"
                                                                                                runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireContactExpirationDate" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                                                <img alt="Status As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFireContactExpirationDate', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                    align="middle" />
                                                                                                <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtFireContactExpirationDate"
                                                                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Fire Inspection Company Contract Expiration Date is not valid."
                                                                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                                            </td>
                                                                                            <td align="left" style="padding-left: 9px;">
                                                                                                <asp:Label ID="Label27" runat="server" Text="Telephone Number"></asp:Label>
                                                                                                &nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireTelephone" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtFireTelephone"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Fire Inspection Company Telephone Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">Address 1&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireAddress1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="padding-left: 9px;">
                                                                                                <asp:Label ID="Label28" runat="server" Text="Alternate Number"></asp:Label>
                                                                                                &nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireAlternateNumber" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtFireAlternateNumber"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Fire Inspection Company Alternate Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">Address 2&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireAddress2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="padding-left: 9px;">
                                                                                                <asp:Label ID="Label29" runat="server" Text="City"></asp:Label>
                                                                                                &nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireCity" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">State&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:DropDownList runat="server" ID="drpFireState" SkinID="ddlExposure">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td align="left" style="padding-left: 9px;">
                                                                                                <asp:Label ID="Label30" runat="server" Text="Email"></asp:Label>
                                                                                                &nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireEmail" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Fire Inspection Company Email is not valid"
                                                                                                    ControlToValidate="txtFireEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">Zip&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireZipCode" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Fire Inspection Company Zip Code is not valid"
                                                                                                    ControlToValidate="txtFireZipCode" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" />
                                                                                            </td>
                                                                                            <td align="left" style="padding-left: 9px;">
                                                                                                <asp:Label ID="Label31" runat="server" Text="Comments"></asp:Label>
                                                                                                &nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtFireComments" Width="170px" MaxLength="200"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <%-- <td colspan="6">
                                                                                    <table width="40%" cellpadding="2" cellspacing="0"> 
                                                                                        <tr>--%>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="Label9" runat="server" Text="Security Cameras?" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    <asp:Label ID="Label11" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoAlarm_Security_Cameras" SkinID="YesNoTypeNullSelection"
                                                                                        onClick="checkSecurityCameras();">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <%--</tr>
                                                                                    </table>
                                                                                </td>--%>
                                                                            </tr>
                                                                            <tr runat="server" id="trSecurityCameras" style="display: none;">
                                                                                <td align="center" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label19" runat="server" Text="System" Width="146px"></asp:Label>
                                                                                                &nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label45" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtsecuCam_System" Width="170px" MaxLength="50" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label20" runat="server" Text="Contact Name" Width="132px"></asp:Label>
                                                                                                &nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label3" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Contact_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Vendor Name&nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Vendor_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label32" runat="server" Text="Contract Expiration Date"></asp:Label>
                                                                                                &nbsp;<span id="Span46" style="color: Red; display: none;"
                                                                                                    runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Contact_Expiration_Date" Width="170px"
                                                                                                    SkinID="txtDate"></asp:TextBox>
                                                                                                <img alt="Status As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSecuCam_Contact_Expiration_Date', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                    align="middle" />
                                                                                                <asp:RangeValidator ID="reg1Status_As_Of_Date" ControlToValidate="txtSecuCam_Contact_Expiration_Date"
                                                                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Security Cameras Contract Expiration Date is not valid."
                                                                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 1&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label33" runat="server" Text="Telephone Number" Width="132px"></asp:Label>
                                                                                                &nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Telephone_Number" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="regSecuCam_Telephone_Number" ControlToValidate="txtSecuCam_Telephone_Number"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Security Camera Telephone Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 2&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label34" runat="server" Text="Alternate Number"></asp:Label>
                                                                                                &nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Alternate_Number" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="regSecuCam_Alternate_Number" ControlToValidate="txtSecuCam_Alternate_Number"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Security Camera Alternate Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">City&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label35" runat="server" Text="Email"></asp:Label>
                                                                                                &nbsp;<span id="Span52" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Email" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="revSecuCam_Email" runat="server" ErrorMessage="Security Camera Email is not valid"
                                                                                                    ControlToValidate="txtSecuCam_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">State&nbsp;<span id="Span53" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:DropDownList runat="server" ID="ddlSecuCam_State" SkinID="ddlExposure">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label36" runat="server" Text="Comments"></asp:Label>
                                                                                                &nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Comments" Width="170px" MaxLength="200"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Zip&nbsp;<span id="Span55" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtSecuCam_Zip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="revSecuCamZipCode" runat="server" ErrorMessage="Security Camera Zip Code is not valid"
                                                                                                    ControlToValidate="txtSecuCam_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="Label10" runat="server" Text="Security Guard Services" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    <asp:Label ID="Label12" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoGuard_System" SkinID="YesNoTypeNullSelection"
                                                                                        onClick="checkGuardSystem();">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trGuardSystem" style="display: none;">
                                                                                <td align="center" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label37" runat="server" Text="System" Width="146px"></asp:Label>
                                                                                                &nbsp;<span id="Span56" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label38" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_System" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label40" runat="server" Text="Contact Name" Width="132px"></asp:Label>
                                                                                                &nbsp;<span id="Span57" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label39" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Contact_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Vendor Name&nbsp;<span id="Span58" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Vendor_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label44" runat="server" Text="Contract Expiration Date"></asp:Label>
                                                                                                &nbsp;<span id="Span106" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Contact_Expiration_Date" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                                                <img alt="Status As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtGuard_Contact_Expiration_Date', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                    align="middle" />
                                                                                                <asp:RangeValidator ID="regExpiration_Date" ControlToValidate="txtGuard_Contact_Expiration_Date"
                                                                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Security Guard Services Contract Expiration Date  is not valid"
                                                                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 1&nbsp;<span id="Span59" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label46" runat="server" Text="Telephone Number" Width="132px"></asp:Label>
                                                                                                &nbsp;<span id="Span60" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Telephone_Number" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="regGuard_Telephone_Number" ControlToValidate="txtGuard_Telephone_Number"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Security Guard Services Telephone Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 2&nbsp;<span id="Span61" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label50" runat="server" Text="Alternate Number"></asp:Label>
                                                                                                <span id="Span105" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Alternate_Number" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="regGuard_Alternate_Number" ControlToValidate="txtGuard_Alternate_Number"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Security Guard Services Alternate Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">City&nbsp;<span id="Span62" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label57" runat="server" Text="Email"></asp:Label>
                                                                                                &nbsp;<span id="Span63" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Email" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="revGuardEmail" runat="server" ErrorMessage="Security Guard Services Email is not valid"
                                                                                                    ControlToValidate="txtGuard_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">State&nbsp;<span id="Span64" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:DropDownList runat="server" ID="ddlGuard_State" SkinID="ddlExposure">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label58" runat="server" Text="Comments"></asp:Label>
                                                                                                &nbsp;<span id="Span65" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Comments" Width="170px" MaxLength="200"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Zip&nbsp;<span id="Span66" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtGuard_Zip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="revGuardZipCode" runat="server" ErrorMessage="Security Guard Services Zip Code is not valid"
                                                                                                    ControlToValidate="txtGuard_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label16" runat="server" Text="Intrusion Alarms" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label13" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoIntru_System" SkinID="YesNoTypeNullSelection"
                                                                                        onClick="checkIntrusionAlarms();">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trIntrusionAlarms" style="display: none;">
                                                                                <td align="center" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label41" runat="server" Text="System" Width="146px"></asp:Label>
                                                                                                &nbsp;<span id="Span67" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label42" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_System" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label43" runat="server" Text="Contact Name" Width="132px"></asp:Label>
                                                                                                &nbsp;<span id="Span68" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label4" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Contact_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Vendor Name&nbsp;<span id="Span69" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Vendor_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label59" runat="server" Text="Alarm type"></asp:Label>
                                                                                                &nbsp;<span id="Span70" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:DropDownList runat="server" ID="ddlIntru_Contact_Alarm_Type" SkinID="ddlExposure">
                                                                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                                                                    <asp:ListItem Text="Beam" Value="Beam"></asp:ListItem>
                                                                                                    <asp:ListItem Text="Motion" Value="Motion"></asp:ListItem>
                                                                                                    <asp:ListItem Text="Ultrasound" Value="Ultrasound"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 1&nbsp;<span id="Span71" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label60" runat="server" Text="Contract Expiration Date"></asp:Label>
                                                                                                &nbsp;<span id="Span72" style="color: Red; display: none;"
                                                                                                    runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Contact_Expiration_Date" Width="170px" MaxLength="50"
                                                                                                    SkinID="txtDate"></asp:TextBox>
                                                                                                <img alt="Status As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIntru_Contact_Expiration_Date', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                    align="middle" />
                                                                                                <asp:RangeValidator ID="regIntruExpiration_Date" ControlToValidate="txtIntru_Contact_Expiration_Date"
                                                                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Intrusion Alarms Contract Expiration Date is not valid "
                                                                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 2&nbsp;<span id="Span73" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label61" runat="server" Text="Telephone Number" Width="132px"></asp:Label>
                                                                                                &nbsp;<span id="Span74" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Telephone_Number" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="regIntru_Telephone_Number" ControlToValidate="txtIntru_Telephone_Number"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Intrusion Alarms Telephone Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">City&nbsp;<span id="Span75" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label62" runat="server" Text="Alternate Number"></asp:Label>
                                                                                                &nbsp;<span id="Span76" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Alternate_Number" Width="170px" MaxLength="12"
                                                                                                    onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="regIntru_Alternate_Number" ControlToValidate="txtIntru_Alternate_Number"
                                                                                                    SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter Intrusion Alarms Alternate Number in xxx-xxx-xxxx format."
                                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">State&nbsp;<span id="Span77" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:DropDownList runat="server" ID="ddlIntru_State" SkinID="ddlExposure">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label63" runat="server" Text="Email"></asp:Label>
                                                                                                &nbsp;<span id="Span78" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Email" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="revIntruEmail" runat="server" ErrorMessage="Intrusion Alarms Email is not valid"
                                                                                                    ControlToValidate="txtIntru_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Zip&nbsp;<span id="Span79" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Zip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="revIntruZipCode" runat="server" ErrorMessage="Intrusion Alarms Zip Code is not valid"
                                                                                                    ControlToValidate="txtIntru_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                    Display="none" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label64" runat="server" Text="Comments"></asp:Label>
                                                                                                &nbsp;<span id="Span80" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                                <asp:TextBox runat="server" ID="txtIntru_Comments" Width="170px" MaxLength="200"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Fence
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoFence" SkinID="YesNoTypeNullSelection"
                                                                                        onClick="chkFence();">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trFence" style="display: none;">
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td align="center" colspan="4">
                                                                                    <table cellpadding="3" cellspacing="1" border="0" width="95%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:CheckBox runat="server" ID="chkRazor_Wire" Text="Razor Wire" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:CheckBox runat="server" ID="chkFence_Electrified" Text="Electrified" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label18" runat="server" Text="Generator" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label15" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList runat="server" ID="rdoGenerator" SkinID="YesNoTypeNullSelection"
                                                                                        onClick="chkGenerator();">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trGenerator" style="display: none;">
                                                                                <td align="center" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 19%" valign="top">
                                                                                                <asp:Label ID="Label47" runat="server" Text="Make"></asp:Label>
                                                                                                &nbsp;<span id="Span81" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">
                                                                                                <asp:Label ID="Label48" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 27%; padding-left: 3px" valign="top">
                                                                                                <asp:TextBox runat="server" ID="txtGenerator_Make" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 17%; padding-left: 9px;" valign="top">
                                                                                                <asp:Label ID="Label49" runat="server" Text="Model"></asp:Label>
                                                                                                &nbsp;<span id="Span82" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%; padding-left: 1px" valign="top">
                                                                                                <asp:Label ID="Label8" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 29%; padding-left: 5px" valign="top">
                                                                                                <asp:TextBox runat="server" ID="txtGenerator_Model" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%" valign="top">Size&nbsp;<span id="Span83" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px" valign="top">
                                                                                                <asp:TextBox runat="server" ID="txtGenerator_Size" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="left" style="width: 17%" valign="top">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%; padding-left: 5px" valign="top">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 29%; padding-left: 3px" valign="top">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;" colspan="6"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Public Fire Department</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;" colspan="6"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" style="width: 19%">
                                                                                                <asp:Label ID="Label6" runat="server" Text="Type"></asp:Label>
                                                                                                &nbsp;<span id="Span84" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" style="width: 4%">
                                                                                                <asp:Label ID="Label7" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%; padding-left: 3px" valign="top">
                                                                                                <asp:DropDownList runat="Server" ID="ddlFireDeptType" SkinID="ddlExposure">
                                                                                                    <asp:ListItem Value="" Text="--SELECT--"></asp:ListItem>
                                                                                                    <asp:ListItem Value="Paid" Text="Paid"></asp:ListItem>
                                                                                                    <asp:ListItem Value="Part Paid" Text="Part Paid"></asp:ListItem>
                                                                                                    <asp:ListItem Value="Volunteer" Text="Volunteer"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td align="left" valign="top" style="width: 17%; padding-left: 9px;">
                                                                                                <asp:Label ID="Label14" runat="server" Text="Distance"></asp:Label>
                                                                                                &nbsp;<span id="Span85" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="center" valign="top" style="width: 4%; padding-left: 2px">
                                                                                                <asp:Label ID="Label54" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                                <%--<asp:Label ID="Label8" runat="server" Text=":" Width="31px"></asp:Label>--%>
                                                                                            </td>
                                                                                            <td align="left" style="width: 29%; padding-left: 5px" valign="top">
                                                                                                <asp:DropDownList runat="server" ID="ddlDistance" SkinID="ddlExposure">
                                                                                                    <asp:ListItem Value="" Text="--SELECT--"></asp:ListItem>
                                                                                                    <asp:ListItem Value="<1 MIles" Text="<1 MIles"></asp:ListItem>
                                                                                                    <asp:ListItem Value="1-5 Miles" Text="1-5 Miles"></asp:ListItem>
                                                                                                    <asp:ListItem Value="5-10 Miles" Text="5-10 Miles"></asp:ListItem>
                                                                                                    <asp:ListItem Value=">10 Miles" Text=">10 Miles"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Service Capacity</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" valign="top" style="width: 19%">
                                                                                <asp:Label ID="Label68" runat="server" Text="Number of Bays"></asp:Label>
                                                                                &nbsp;<span id="Span86" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top" style="width: 4%">
                                                                                <asp:Label ID="Label69" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 27%; padding-left: 3px" valign="top">
                                                                                <asp:TextBox ID="txtNumberOfBays" runat="server" onpaste="return false" Width="170px" onkeypress="return FormatNumber(event,this.id,9,true);" />
                                                                            </td>
                                                                            <td align="left" valign="top" style="width: 17%; padding-left: 9px;">
                                                                                <asp:Label ID="Label23" runat="server" Text="Number of Lifts"></asp:Label>
                                                                                &nbsp;<span id="Span87" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top" style="width: 4%; padding-left: 1px">
                                                                                <asp:Label ID="Label55" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 29%; padding-left: 5px" valign="top">
                                                                                <asp:TextBox ID="txtNumberOfLifts" runat="server" onpaste="return false" SkinID="txtDisabled" Width="172px"
                                                                                    ReadOnly="true" onkeypress="return FormatNumber(event,this.id,9,true);" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top" style="width: 18%">
                                                                                <asp:Label ID="Label70" runat="server" Text="Number of Prep Areas"></asp:Label>&nbsp;<span id="Span88" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top" style="width: 4%">
                                                                                <asp:Label ID="Label71" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px" valign="top">
                                                                                <asp:TextBox ID="txtNumberOfPrepAreas" runat="server" SkinID="txtDisabled" ReadOnly="true" Width="172px"
                                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,true);" />
                                                                            </td>
                                                                            <td align="left" valign="top" style="width: 17%; padding-left: 9px;">
                                                                                <asp:Label ID="Label24" runat="server" Text=" Number of Car Wash Stations "></asp:Label>
                                                                                &nbsp; <span id="Span89" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top" style="width: 4%; padding-left: 1px">
                                                                                <asp:Label ID="Label56" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 29%; padding-left: 5px" valign="top">
                                                                                <asp:TextBox ID="txtNumberOfCarWashStations" runat="server" onpaste="return false" Width="170px"
                                                                                    onkeypress="return FormatNumber(event,this.id,9,true);" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label ID="Label72" runat="server" Text="Number of Paint Booths"></asp:Label>&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                                                    runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                <asp:Label ID="Label73" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px" valign="top">
                                                                                <asp:TextBox runat="server" ID="txtNumber_of_Paint_Booths" SkinID="txtDisabled" Width="172px"
                                                                                    ReadOnly="true" onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,true);"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="3"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 8px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Improvements</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 8px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Exposure</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 8px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Tier 1 County
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList runat="server" ID="rdoTier_1_County" SkinID="YesNoTypeNullSelection">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Earthquake Zone/Fault Line
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList runat="server" ID="rdoEarthquake_Zone_Fault_Line" SkinID="YesNoTypeNullSelection">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Neighboring Buildings within 100 ft.
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList runat="server" ID="rdoNeighboring_Buildings_within_100_ft" SkinID="YesNoTypeNullSelection"
                                                                        onclick="ShowHideNeighbouringOccupancy()">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td colspan="3">
                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblNeighboringOccupancy" style="display: none;" runat="server">
                                                                        <tr>
                                                                            <td align="left" valign="top" width="17%">
                                                                                <asp:Label ID="lbl98" runat="server" Text="Occupancy"></asp:Label>
                                                                                &nbsp;<span id="Span90" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top" width="4%">
                                                                                <asp:Label ID="Label74" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top" width="29%" style="padding-left: 7px;">
                                                                                <asp:TextBox runat="server" ID="txtNeighbor_Occupancy" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Distance from body of water<br />
                                                                    (creek, river, ocean)&nbsp;<span id="Span91" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlDistance_from_body_of_water" SkinID="ddlExposure">
                                                                        <asp:ListItem Value="" Text="--SELECT--"></asp:ListItem>
                                                                        <asp:ListItem Value="<1 MIles" Text="<1 MIles"></asp:ListItem>
                                                                        <asp:ListItem Value="1-5 Miles" Text="1-5 Miles"></asp:ListItem>
                                                                        <asp:ListItem Value="5-10 Miles" Text="5-10 Miles"></asp:ListItem>
                                                                        <asp:ListItem Value=">10 Miles" Text=">10 Miles"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Prior Flood History
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPrior_Flood_History" SkinID="YesNoTypeNullSelection"
                                                                        onClick="checkFloodHistory();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="trFloodHistory" style="display: none;">
                                                                <td align="left" valign="top">Describe&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ControlType="TextBox" ID="txtFlood_History_Descr" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Lowest finish floor elevation<br />
                                                                    (above sea level)&nbsp;<span id="Span93" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtLowest_finish_floor_elevation" Width="170px" onpaste="return false"
                                                                        onkeypress="return FormatNumber(event,this.id,9,true);"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Property Damage Losses in the Past 5 years
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList runat="server" ID="rdoProperty_Damage_Losses_in_the_Past_5_years"
                                                                        SkinID="YesNoTypeNullSelection" onClick="checkPropertyDamageLoss();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="trPropertyDamageLoss" style="display: none;">
                                                                <td align="left" valign="top">Describe&nbsp;<span id="Span94" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ControlType="TextBox" ID="txtProperty_Loss_Descr" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Flood Zone&nbsp;<span id="Span95" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtFloodZone" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <%-- <asp:DropDownList runat="server" ID="ddlFlood_Zone" SkinID="ddlExposure">
                                                                                    </asp:DropDownList>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">National Flood Policy
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList runat="server" ID="rdoNational_Flood_Policy" SkinID="YesNoTypeNullSelection"
                                                                        onClick="checkNational_Flood_Policy();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="trNational_Flood_Policy" style="display: none;">
                                                                <td align="center" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                <asp:Label ID="Label99" runat="server" Text="Carrier" Width="146px"></asp:Label>
                                                                                &nbsp;<span id="Span96" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                <asp:Label ID="Label17" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Carrier" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                <asp:Label ID="Label21" runat="server" Text="Policy Inception Date"></asp:Label>
                                                                                &nbsp;<span id="Span97" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                <asp:Label ID="Label22" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 5px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Policy_Inception_Date" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                                <img alt="Flood Policy Inception Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFlood_Policy_Inception_Date', 'mm/dd/y');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" />
                                                                                <asp:RangeValidator ID="regFloodInception_Date" ControlToValidate="txtFlood_Policy_Inception_Date"
                                                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="National Flood Policy Inception Date is not valid"
                                                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Policy Number&nbsp;<span id="Span98" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Policy_Number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                <asp:Label ID="Label65" runat="server" Text="Policy Expiration Date"></asp:Label>
                                                                                &nbsp;<span id="Span99" style="color: Red; display: none;"
                                                                                    runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 5px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Policy_Expiration_Date" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                                <img alt="Status As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFlood_Policy_Expiration_Date', 'mm/dd/y');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" />
                                                                                <asp:RangeValidator ID="regFloodExpiration_Date" ControlToValidate="txtFlood_Policy_Expiration_Date"
                                                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="National Flood Policy Expiration Date is not valid"
                                                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorBuilding" Display="none" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Premium&nbsp;<span id="Span100" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Premium" Width="170px" onpaste="return false"
                                                                                    onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                <asp:Label ID="Label66" runat="server" Text="Deductible"></asp:Label>
                                                                                &nbsp;<span id="Span101" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 5px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Deductible" Width="170px" onpaste="return false"
                                                                                    onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Policy Limits - Contents&nbsp;<span id="Span102" style="color: Red; display: none;"
                                                                                runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Polciy_Limits_Contents" Width="170px" onpaste="return false"
                                                                                    onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                <asp:Label ID="Label67" runat="server" Text=" Policy Limits - Building"></asp:Label>
                                                                                &nbsp;<span id="Span103" style="color: Red; display: none;"
                                                                                    runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 5px">
                                                                                <asp:TextBox runat="server" ID="txtFlood_Policy_Limits_Building" Width="170px" onpaste="return false"
                                                                                    onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Power Requirements</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Voltage Security
                                                                                <span id="spnVoltageSecurity" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                <asp:Label ID="Label76" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:DropDownList runat="server" ID="ddlVoltageSecurity" Width="170px" />
                                                                            </td>
                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                <asp:Label ID="lblPhasePower" runat="server" Text="Phase Power"></asp:Label>
                                                                                &nbsp;<span id="spnPhasePower" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                <asp:Label ID="Label78" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:DropDownList runat="server" ID="ddlPhasePower" Width="170px"></asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="4"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Voltage Security, Other&nbsp;<span id="spnVoltageSecurityOther" style="color: Red; display: none;"
                                                                                runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtVoltageSecurityOther" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;">
                                                                                <asp:Label ID="lblRequiredCableLength" runat="server" Text="Required Cable Length"></asp:Label>
                                                                                &nbsp;<span id="spnRequiredCableLength" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:DropDownList runat="server" ID="ddlRequiredCableLength" Width="170px"></asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Power Service&nbsp;<span id="spnPowerService" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:DropDownList runat="server" ID="ddlPowerService" Width="170px"></asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;">
                                                                                <asp:Label ID="lblRequiredCableLengthOther" runat="server" Text="Required Cable Length, Other"></asp:Label>
                                                                                &nbsp;<span id="spnRequiredCableLengthOther" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtRequiredCableLengthOther" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="4"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Power Service, Other&nbsp;<span id="spnPowerServiceOther" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtPowerServiceOther" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;">Total Amperage Required<span id="spnTotalAmperageRequired" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtTotalAmperageRequired" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td align="left" valign="top">
                                                                    <b>GGKL Renewal Information Grid</b><br />
                                                                    <asp:LinkButton ID="lnkAddNewGGKL" runat="server" Text="--Add--" OnClick="lnkAddNewGGKL_Click" />
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:GridView ID="gvGGKL" runat="server" Width="100%" OnRowCommand="gvGGKL_RowCommand"
                                                                        EmptyDataText="No Records Found !">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemStyle Width="40%" HorizontalAlign="Left" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date")) %>'
                                                                                        CommandArgument='<%#Eval("PK_Building_GGKL") %>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total">
                                                                                <ItemStyle Width="40%" HorizontalAlign="Left" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkTotal" runat="server" Text='<%# string.Format("{0:N0}",Eval("Total")) %>'
                                                                                        CommandArgument='<%#Eval("PK_Building_GGKL") %>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                        CommandArgument='<%#Eval("PK_Building_GGKL") %>' OnClientClick="return confirm('Are you sure that you want to delete the selected record?');" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Other Building Attachments</b><br />
                                                                    <i>Click to view detail</i>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;" colspan="6">
                                                                    <asp:GridView ID="gvBuildingAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvBuildingAttachmentDetails_RowDataBound"
                                                                        OnRowCommand="gvBuildingAttachmentDetails_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="File Name">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <a id="lnkBuildingAttachFile" runat="server" href="#">
                                                                                        <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                                    </a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Type") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Building_Attachments_ID") + ":" + Eval("FileName") %>'
                                                                                        CommandName="RemoveAttachment" OnClientClick="return ConfirmRemove();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <a href="javascript:CheckBeforeAddBuildingAttach();">Add New</a>
                                                                    <input type="hidden" id="hdnBuildingID" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trBuildingAttachment" runat="server" style="display: none;">
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlAttachment runat="server" ID="BuildingAttachment" OnFileSelection="Upload_Building_Attachment" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">Other Building Comments&nbsp;<span id="Span104" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtComments" ControlType="textbox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Button runat="server" ID="btnBuildingInformationSave" Text="Save & Next" OnClick="btnBuildingInformationSave_Click"
                                                                                    CausesValidation="true" ValidationGroup="vsErrorBuilding" />&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnViewAuditBuilding" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Building');"
                                                                                    Visible="false" />
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnOwnerShip" runat="server" Text="Ownership Details" OnClick="btnBuildingInformationSave_Click"
                                                                                    CausesValidation="true" ValidationGroup="vsErrorBuilding" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlOwnershipDetails" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Ownership Details
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updOwnerShip">
                                                    <ContentTemplate>
                                                        <input type="hidden" id="hdnBuildingOwnershipID" runat="server" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="50%" align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Landlord Name&nbsp;<span id="Span117" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLandlord_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1&nbsp;<span id="Span116" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLandlord_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2&nbsp;<span id="Span115" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLandlord_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City&nbsp;<span id="Span114" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtLandlord_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State&nbsp;<span id="Span113" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:DropDownList runat="server" ID="ddlLandlord_State" SkinID="ddlExposure">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip&nbsp;<span id="Span112" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLandlord_Zip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revLandlordZipCode" runat="server" ErrorMessage="Landlord Zip Code is not valid"
                                                                                                ControlToValidate="txtLandlord_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                Display="none" SetFocusOnError="true" ValidationGroup="vsErrorOwnership" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <%--<tr id="trLegalEntiry" runat="server" style="display: block">--%>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Landlord Legal Entity&nbsp;<span id="Span111" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLandlordLegalEntity" Width="170px" MaxLength="75"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Lease ID&nbsp;<span id="Span110" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLease_ID" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Commencement Date&nbsp;<span id="Span109" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtCommencement_Date" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                                            <img alt="Commencement Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCommencement_Date', 'mm/dd/y');"
                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                align="middle" />
                                                                                            <asp:RangeValidator ID="regCommencement_Date" ControlToValidate="txtCommencement_Date"
                                                                                                MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Commencement Date is not valid"
                                                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorOwnership" Display="none" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Expiration Date&nbsp;<span id="Span108" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtExpiration_Date" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                                            <img alt="Expiration Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtExpiration_Date', 'mm/dd/y');"
                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                align="middle" />
                                                                                            <asp:RangeValidator ID="regOwnerExpiration_Date" ControlToValidate="txtExpiration_Date"
                                                                                                MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Expiration Date is not valid"
                                                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorOwnership" Display="none" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trgvSubLease" runat="server" style="display: none;">
                                                                            <td valign="top">
                                                                                <i><b>Sub-Lease<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td id="gridSubLease" runat="server" style="display: none;" colspan="2">
                                                                                <asp:GridView ID="gvSubLease" runat="server" EmptyDataText="No Additional Sub Lease Record Exists"
                                                                                    OnRowCommand="gvSubLease_OnRowCommand" Width="100%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewSubLeaseDetails" CausesValidation="false" runat="server"
                                                                                                    Text='<%# Container.DataItemIndex + 1 %>' CommandName="ViewSubLeaseDetails" CommandArgument='<%#Eval("PK_Building_Ownership_Sublease")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease Name">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_Name") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease LandLord">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("SubLease_Landlord")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease First Name">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_FirstName")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease Last Name">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_LastName")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease Phone">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_Phone")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remove">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkRemoveLease" TeID="lnkRemove" OnClientClick="return ConfirmSubLeaseRemove();"
                                                                                                    CausesValidation="false" runat="server" Text="Remove" CommandName="RemoveLease"
                                                                                                    CommandArgument='<%#Eval("PK_Building_Ownership_Sublease")%>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trAddNewLease" runat="server" align="left">
                                                                            <td>
                                                                                <a href="javascript:checkAdditionalSubLease();">Add New</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trSubLease" runat="server" style="display: none">
                                                                            <td align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Name<span id="Span164" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubLease_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1<span id="Span165" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSublease_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2 <span id="Span166" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSublease_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City<span id="Span167" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtSublease_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State<span id="Span168" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:DropDownList runat="server" ID="ddlSublease_State" SkinID="ddlExposure">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip<span id="Span169" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSublease_Zip" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revSubleaseZipCode" runat="server" ErrorMessage="[Ownership Details]/Sub-Lease Zip Code is not valid"
                                                                                                ControlToValidate="txtSublease_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                Display="none" SetFocusOnError="true" ValidationGroup="vsErrorOwnership" Enabled="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Landlord<span id="Span157" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubLandlord" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease First Name<span id="Span158" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubleaseFirstName" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Last Name<span id="Span159" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubleaseLastName" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Title <span id="Span160" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubleaseTitle" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Phone <span id="Span161" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubleasePhone" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revSubleasePhone" ControlToValidate="txtSubleasePhone"
                                                                                                SetFocusOnError="true" runat="server" ValidationGroup="vsErrorOwnership" ErrorMessage="Please Enter Sub-Lease Phone Number in xxx-xxx-xxxx format."
                                                                                                Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Fax<span id="Span162" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubleaseFax" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revSubleaseFax" ControlToValidate="txtSubleaseFax"
                                                                                                SetFocusOnError="true" runat="server" ValidationGroup="vsErrorOwnership" ErrorMessage="Please Enter  Sub-Lease Fax in xxx-xxx-xxxx format."
                                                                                                Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Email<span id="Span163" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtSubleaseEmail" Width="170px" MaxLength="255"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revSubleaseEmail" runat="server" ErrorMessage="Sub-Lease Email is not valid"
                                                                                                ControlToValidate="txtSubleaseEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                Display="none" SetFocusOnError="true" ValidationGroup="vsErrorOwnership"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trbtngvLeaseSave" runat="server" style="display: none;">
                                                                            <td colspan="6" width="100%" align="center">
                                                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="30%" align="right" valign="top">
                                                                                            <input type="hidden" id="hdnSubLeaseID" runat="server" value="View Audit Trail" style="display: none;" />
                                                                                            <asp:Button ID="btngvLeaseSave" Text="Save" runat="server" OnClick="btngvLeaseSave_OnClick"
                                                                                                ValidationGroup="vsErrorBuildindOwnerSubLease" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Button ID="btnLeaseAuditTrail" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Sub_Lease');" />&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr style="height: 2px">
                                                                            <td align="left" width="18%" valign="top"></td>
                                                                            <td align="center" width="4%" valign="top"></td>
                                                                            <td align="left" width="28%" valign="top"></td>
                                                                            <td align="left" width="18%" valign="top"></td>
                                                                            <td align="center" width="4%" valign="top"></td>
                                                                            <td align="left" width="28%" valign="top"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <i><b>Named Additional Insured<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <asp:GridView ID="gvAdditionalInsureds" runat="server" OnRowCommand="gvAdditionalInsureds_RowCommand"
                                                                                    EmptyDataText="No Additional Insured Record Exists" Width="100%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewDetails" CausesValidation="false" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                                    CommandName="ViewDetails" CommandArgument='<%#Eval("PK_Building_Additional_Insureds_Payees_ID")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name">
                                                                                            <ItemStyle Width="25%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Named") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address">
                                                                                            <ItemStyle Width="35%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Address_1")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City">
                                                                                            <ItemStyle Width="25%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("City")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remove">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButton2" TeID="lnkRemove" OnClientClick="return ConfirmRemove();" CausesValidation="false"
                                                                                                    runat="server" Text="Remove" CommandName="RemoveInsured" CommandArgument='<%#Eval("PK_Building_Additional_Insureds_Payees_ID")%>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <a href="javascript:checkAdditionalInsured();">Add New</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="trAdditionalInsured" style="display: none;">
                                                                            <td align="left" colspan="6">
                                                                                <input type="hidden" id="hdnAdditionalInsured" runat="server" />
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="18%" valign="top">Named Insured&nbsp;<span id="Span142" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtAdditional_Insureds_Named" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1&nbsp;<span id="Span143" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtAdditional_Insureds_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2&nbsp;<span id="Span144" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtAdditional_Insureds_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">City&nbsp;<span id="Span145" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtAdditional_Insureds_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State&nbsp;<span id="Span146" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:DropDownList runat="server" ID="ddlAdditional_Insureds_State" SkinID="ddlExposure">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip&nbsp;<span id="Span147" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtAdditional_Insureds_Zip" Width="170px" MaxLength="10"
                                                                                                onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revAdditionalZipCode" runat="server" ErrorMessage="Additional Insured Zip Code is not valid"
                                                                                                ControlToValidate="txtAdditional_Insureds_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                Display="none" ValidationGroup="vsErrorAdditionalInsured" SetFocusOnError="true" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" width="100%" align="center">
                                                                                            <table cellpadding="5" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" valign="top">
                                                                                                        <asp:Button ID="btnAdditionalIsuredSave" runat="server" Text="Save" OnClick="btnAdditionalIsuredSave_Click"
                                                                                                            ValidationGroup="vsErrorAdditionalInsured" />
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Button ID="btnViewAuditAdditionalInsured" runat="server" Text="View Audit Trail"
                                                                                                            OnClientClick="javascript:return AuditPopUp('Additional_Insured');" Style="display: none;" />&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <i><b>Named Loss Payees<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <asp:GridView ID="gvPayee" runat="server" OnRowCommand="gvPayee_RowCommand" EmptyDataText="No Payee Records Exists"
                                                                                    Width="100%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewDetails" CausesValidation="false" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                                    CommandName="ViewDetails" CommandArgument='<%#Eval("PK_Building_Additional_Insureds_Payees_ID")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name">
                                                                                            <ItemStyle Width="25%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Named") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address">
                                                                                            <ItemStyle Width="35%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Address_1")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City">
                                                                                            <ItemStyle Width="25%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("City")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remove">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButton3" TeID="lnkRemove" OnClientClick="return ConfirmRemove();" CausesValidation="false"
                                                                                                    runat="server" Text="Remove" CommandName="RemovePayee" CommandArgument='<%#Eval("PK_Building_Additional_Insureds_Payees_ID")%>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <a href="javascript:checkNamedLossPayees();">Add New</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trNamedLossPayees" runat="server" style="display: none;">
                                                                            <td align="left" colspan="6">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="18%" valign="top">Named Insured&nbsp;<span id="Span148" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLoss_Payees_Named" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" width="18%" valign="top">Type&nbsp;<span id="Span149" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">
                                                                                            <asp:DropDownList runat="server" ID="ddlLoss_Payees_Type" SkinID="ddlExposure">
                                                                                                <asp:ListItem Text="--SELECT--" Value=""></asp:ListItem>
                                                                                                <asp:ListItem Text="Mortgagee" Value="Mortgagee"></asp:ListItem>
                                                                                                <asp:ListItem Text="Landlord" Value="Landlord"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1&nbsp;<span id="Span150" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLoss_Payees_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2&nbsp;<span id="Span151" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLoss_Payees_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">City&nbsp;<span id="Span152" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLoss_Payees_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State&nbsp;<span id="Span153" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:DropDownList runat="server" ID="ddlLoss_Payees_State" SkinID="ddlExposure">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip&nbsp;<span id="Span154" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtLoss_Payees_Zip" Width="170px" MaxLength="10"
                                                                                                onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="revPayeeZipCode" runat="server" ErrorMessage="Loss Payee Zip Code is not valid"
                                                                                                ControlToValidate="txtLoss_Payees_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                                                Display="none" ValidationGroup="vsErrorLossPayee" SetFocusOnError="true" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" width="100%" align="center">
                                                                                            <table cellpadding="5" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td width="30%" align="right" valign="top">
                                                                                                        <input type="hidden" id="hdnLossPayeeID" runat="server" value="View Audit Trail"
                                                                                                            style="display: none;" />
                                                                                                        <asp:Button ID="btnPayeeSave" runat="server" Text="Save" OnClick="btnPayeeSave_Click"
                                                                                                            ValidationGroup="vsErrorLossPayee" />
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Button ID="btnViewAuditLossPayee" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Loss_Payee');"
                                                                                                            Style="display: none;" />&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">Special Wording for the Certificate of Insurance&nbsp;<span id="Span107" style="color: Red; display: none;"
                                                                                runat="server">*</span>
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="6">
                                                                                <uc:ctrlMultiLineTextBox runat="server" ID="txtCOI_Wording" ControlType="TextBox" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="22%" align="left" valign="top">
                                                                                            <b>Insurance Requirements</b>
                                                                                        </td>
                                                                                        <td width="10%" align="left" valign="top">Sub-Tenant<br />
                                                                                            Responsible
                                                                                        </td>
                                                                                        <td width="22%" align="left" valign="top">View<br />
                                                                                            COI
                                                                                        </td>
                                                                                        <td width="10%" align="left" valign="top">Date
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQWC" runat="server" Text="Workers Compensation" onclick="ShowHideLimits(this.checked,'WC');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkWCTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'WC');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_WC" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('WC');" />
                                                                                            <input type="hidden" id="hdnCOI_WC" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_WC_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_WC_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_WC_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblWCLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_WC" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQEL" runat="server" Text="Employers Liability" onclick="ShowHideLimits(this.checked,'EL');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkELTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'EL');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_EL" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('EL');" />
                                                                                            <input type="hidden" id="hdnCOI_EL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_EL_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_EL_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_EL_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblELLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_EL" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQGL" runat="server" Text="General Liability" onclick="ShowHideLimits(this.checked,'GL');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkGLTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'GL');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_GL" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('GL');" />
                                                                                            <input type="hidden" id="hdnCOI_GL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_GL_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_GL_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_GL_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblGLLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_GL" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQPollution" runat="server" Text="Pollution" onclick="ShowHideLimits(this.checked,'Pollution');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkPollutionTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'Pollution');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Pollution" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('Pollution');" />
                                                                                            <input type="hidden" id="hdnCOI_Pollution" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Pollution_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Pollution_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Pollution_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblPollutionLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_Pollution" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQProperty" runat="server" Text="Property" onclick="ShowHideLimits(this.checked,'Property');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkPropertyTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'Property');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Property" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('Property');" />
                                                                                            <input type="hidden" id="hdnCOI_Property" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Property_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Property_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Property_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblPropertyLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_Property" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQFlood" runat="server" Text="Flood" onclick="ShowHideLimits(this.checked,'Flood');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkFloodTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'Flood');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Flood" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('Flood');" />
                                                                                            <input type="hidden" id="hdnCOI_Flood" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Flood_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Flood_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Flood_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblFloodLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_Flood" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQEQ" runat="server" Text="EQ" onclick="ShowHideLimits(this.checked,'EQ');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkEQTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'EQ');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_EQ" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('EQ');" />
                                                                                            <input type="hidden" id="hdnCOI_EQ" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_EQ_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_EQ_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_EQ_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblEQLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_EQ" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:CheckBox ID="chkREQWaiver" runat="server" Text="Waiver of Subrogation" onclick="ShowHideLimits(this.checked,'Waiver');" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:CheckBox ID="chkWaiverTenant" runat="server" onclick="return OpenOrRemoveCOI(this.checked,'Waiver');" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Waiver" runat="server" CausesValidation="false" OnClientClick="return ViewCOI('Waiver');" />
                                                                                            <input type="hidden" id="hdnCOI_Waiver" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Waiver_URL" runat="server" />
                                                                                            <input type="hidden" id="hdnCOI_Waiver_Date" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Waiver_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="0" cellspacing="0" width="100%" id="tblWaiverLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="40%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:TextBox ID="txtReqLim_Waiver" runat="server" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,true);" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <i><b>Sub-Lease Attachments<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <asp:GridView ID="gvLeaseAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvLeaseAttachmentDetails_RowDataBound"
                                                                                    OnRowCommand="gvLeaseAttachmentDetails_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="File Name">
                                                                                            <ItemStyle Width="35%" />
                                                                                            <ItemTemplate>
                                                                                                <a id="lnkLeaseAttachFile" runat="server" href="#">
                                                                                                    <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                                                </a>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Type">
                                                                                            <ItemStyle Width="35%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Type") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remove">
                                                                                            <ItemStyle Width="30%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Lease_SubLease_Attachments_ID") + ":" + Eval("FileName") %>'
                                                                                                    CommandName="RemoveAttachment" OnClientClick="return ConfirmRemove();" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="6">
                                                                                <a href="javascript:ShowHideLeaseAttachment();">Add New</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trLeaseAttachment" runat="server" style="display: none;">
                                                                            <td align="left" colspan="6">
                                                                                <uc:ctrlAttachment runat="server" ID="LeaseAttachment" OnFileSelection="Upload_Lease_Attachment" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:Button runat="server" ID="btnOwnershipSave" Text="Save & Next" OnClick="btnOwnershipSave_Click"
                                                                        ValidationGroup="vsErrorOwnership" />&nbsp;
                                                                    <asp:Button ID="btnViewAuditOwnership" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Ownership');"
                                                                        Visible="false" />&nbsp;
                                                                    <asp:Button ID="btnBackToBuilding" runat="server" Text="Back To Building Information"
                                                                        OnClientClick="javascript:ShowPanel(2);return false;" Width="220" SkinID="btnGen" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlBuildingImprovements" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Building Improvements
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updBuildingImprovements">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">Building Improvements Grid<br />
                                                                    <b><i>Click to view detail</i></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvBuildingImprovements" runat="server" Width="100%" OnRowCommand="gvBuildingImprovements_RowCommand"
                                                                        EmptyDataText="No Record Found" AllowSorting="true" OnSorting="gvBuildingImprovements_Sorting">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Building" SortExpression="Building_Number">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkBuilding" runat="server" Text='<%#Eval("Building_Number")%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Project Number" SortExpression="Project_Number">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkProjectNumber" runat="server" Text='<%#Eval("Project_Number")%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Project Description" SortExpression="Project_Description">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkProjectDesc" runat="server" Text='<%#Eval("Project_Description")%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements")%>' CommandName="ShowDetails" CssClass="TextClip" Width="250px" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Start Date" SortExpression="Start_Date">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Start_Date"))%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Target Date" SortExpression="Target_Completion_Date">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkCompletionDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Target_Completion_Date"))%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Building_Improvements")%>'
                                                                                        CommandName="RemoveDetails" OnClientClick="return confirm('Are you sure that you want to delete the selected record from the Improvements Grid?');" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:LinkButton ID="lnkAddNewImprovement" runat="server" Text="Add New" OnClick="lnkAddNewImprovement_Click" />
                                                                    <input type="hidden" id="hdnAssessmentID" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlContacts" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Contacts
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Facility Contact</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Name&nbsp;<span id="Span132" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtName" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">Cell Phone&nbsp;<span id="Span133" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtCell_Phone" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regCell_Phone" ControlToValidate="txtCell_Phone"
                                                                        SetFocusOnError="true" runat="server" ValidationGroup="vsErrorContact" ErrorMessage="Please Enter Facility Contact Cell Phone in xxx-xxx-xxxx format."
                                                                        Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Facility Telephone&nbsp;<span id="Span134" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtPhone" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regPhone" ControlToValidate="txtPhone" SetFocusOnError="true"
                                                                        runat="server" ValidationGroup="vsErrorContact" ErrorMessage="Please Enter Facility Contact Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>After Hours Contact</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Name&nbsp;<span id="Span135" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtAfter_Hours_Contact_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">Cell Phone&nbsp;<span id="Span136" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtAfter_Hours_Contact_Cell_Phone" Width="170px"
                                                                        MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regAfter_Hours_Contact_Cell_Phone" ControlToValidate="txtAfter_Hours_Contact_Cell_Phone"
                                                                        SetFocusOnError="true" runat="server" ValidationGroup="vsErrorContact" ErrorMessage="Please Enter After Hours Contact Cell Phone in xxx-xxx-xxxx format."
                                                                        Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Facility Telephone&nbsp;<span id="Span137" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox runat="server" ID="txtAfter_Hours_Contact_Phone" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regAfter_Hours_Contact_Phone" ControlToValidate="txtAfter_Hours_Contact_Phone"
                                                                        SetFocusOnError="true" runat="server" ValidationGroup="vsErrorContact" ErrorMessage="Please Enter After Hours Contact Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Emergency Contacts</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvEmergencyContact" runat="server" Width="100%" OnRowCommand="gvEmergencyContact_RowCommand"
                                                                        EmptyDataText="No Emergency Contact Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Type") %>' CommandArgument='<%# Eval("PK_Property_Contact_ID")%>'
                                                                                        CommandName="ViewDetails" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Organization">
                                                                                <ItemStyle Width="23%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Organization")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Contact">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Phone">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Phone")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Email">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("email") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                        CommandArgument='<%# Eval("PK_Property_Contact_ID")%>' CommandName="RemoveContact"
                                                                                        OnClientClick="return ConfirmRemove();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Utility Contacts</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvUtilityContacts" runat="server" Width="100%" OnRowCommand="gvUtilityContacts_RowCommand"
                                                                        EmptyDataText="No Utility Contact Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Type") %>' CommandArgument='<%# Eval("PK_Property_Contact_ID")%>'
                                                                                        CommandName="ViewDetails" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Organization">
                                                                                <ItemStyle Width="23%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Organization")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Contact">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Phone">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Phone")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Email">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("email") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                        CommandArgument='<%# Eval("PK_Property_Contact_ID")%>' CommandName="RemoveContact"
                                                                                        OnClientClick="return ConfirmRemove();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Other Contacts</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvOtherContacts" runat="server" Width="100%" OnRowCommand="gvOtherContacts_RowCommand"
                                                                        EmptyDataText="No Other Contact Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Type") %>' CommandArgument='<%# Eval("PK_Property_Contact_ID")%>'
                                                                                        CommandName="ViewDetails" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Organization">
                                                                                <ItemStyle Width="23%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Organization")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Contact">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Phone">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Phone")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Email">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("email") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                        CommandArgument='<%# Eval("PK_Property_Contact_ID")%>' CommandName="RemoveContact"
                                                                                        OnClientClick="return ConfirmRemove();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="left">
                                                                    <asp:LinkButton ID="lnkAddNewContact" runat="server" OnClick="lnkAddNewContact_Click"
                                                                        Text="Add New" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Fire Alarm Monitoring Company</b>
                                                                </td>
                                                            </tr>                                                            
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Company Name
                                                                                <span id="spnCompanyName" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                <asp:Label ID="Label75" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtCompanyName" Width="170px" MaxLength="75" />
                                                                            </td>
                                                                            <td align="left" style="width: 18%; padding-left: 9px;">
                                                                                <asp:Label ID="Label77" runat="server" Text="Contact Name"></asp:Label>
                                                                                &nbsp;<span id="spnContactName" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                <asp:Label ID="Label79" runat="server" Text=":" Width="31px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtContactName" Width="170px" MaxLength="75"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="4"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Address&nbsp;<span id="spnAddress" style="color: Red; display: none;"
                                                                                runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtAddress" Width="170px" MaxLength="75"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;">
                                                                                <asp:Label ID="Label80" runat="server" Text="City"></asp:Label>
                                                                                &nbsp;<span id="spnCity" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtCity1" Width="170px" MaxLength="75"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">State&nbsp;<span id="spnContactState" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:DropDownList runat="server" ID="ddlContactState" Width="170px"></asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;">
                                                                                <asp:Label ID="Label81" runat="server" Text="Zip Code"></asp:Label>
                                                                                &nbsp;<span id="spnZipCode" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtZipCode" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" ></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Please Enter Zip Code in xxxxx-xxxx format."
                                                                                    ValidationGroup="vsErrorContact" SetFocusOnError="true" ControlToValidate="txtZipCode"
                                                                                    ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="4"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Telephone (XXX-XXX-XXXX)&nbsp;<span id="spntxtTelephone1" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtTelephone1" Width="170px" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtTelephone1" ValidationGroup="vsErrorContact"
                                                                                    SetFocusOnError="true" runat="server" ErrorMessage="Please Enter Telephone Number in xxx-xxx-xxxx format."
                                                                                    Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;"></td>
                                                                            <td align="center"></td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px"></td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td align="left">Account Number&nbsp;<span id="spnAccountNumber" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtAccountNumber" Width="170px" MaxLength="75"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;">Monthly Monitoring Amount<span id="spnMonthlyMonitoringAmount" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">$&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtMonthlyMonitoringAmount" Width="170px" MaxLength="13" SkinID="txtCurrency"></asp:TextBox>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td align="left">Control Panel&nbsp;<span id="spnControlPanel" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px">
                                                                                <asp:TextBox runat="server" ID="txtControlPanel" Width="170px" MaxLength="75"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" style="padding-left: 9px;"></td>
                                                                            <td align="center"></td>
                                                                            <td align="left" style="width: 28%; padding-left: 3px"></td>
                                                                        </tr>
                                                                        <tr height="10">
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="6">
                                                                                <asp:Button runat="server" ID="btnSaveAndView" Text="Save & View" OnClick="btnSaveAndView_Click"
                                                                                    ValidationGroup="vsErrorContact" CausesValidation="true" />&nbsp;
                                                                    <asp:Button ID="btnViewAuditContacts" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Contacts');"
                                                                        Visible="false" />&nbsp;
                                                                    <input id="hdnContacts" runat="server" type="hidden" />
                                                                                <asp:Button ID="btnUpdateContactGrids" runat="server" OnClick="btnUpdateContactGrids_Click"
                                                                                    Style="display: none;" CausesValidation="false" />
                                                                            </td>
                                                                        </tr>


                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 10px;"></td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidatorPropertyCope" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorPropertyCope" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorBuildingInfo" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsBuildInfo" Display="None" ValidationGroup="vsErrorBuilding" />
    <input id="hdnControlIDsBuild" runat="server" type="hidden" />
    <input id="hdnErrorMsgsBuild" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorOwnershipDetails" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsOwnership" Display="None" ValidationGroup="vsErrorOwnership" />
    <input id="hdnControlIDsOwnership" runat="server" type="hidden" />
    <input id="hdnErrorMsgsOwnership" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorAdditionalInsured" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsAdditionalInsured" Display="None" ValidationGroup="vsErrorAdditionalInsured" />
    <input id="hdnControlIDsAI" runat="server" type="hidden" />
    <input id="hdnErrorMsgsAI" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorLossPayee" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsLossPayee" Display="None" ValidationGroup="vsErrorLossPayee" />
    <input id="hdnControlIDsLossPayee" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLossPayee" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorBuildindOwnerSubLease" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsBuildindOwnerSubLease" Display="None"
        ValidationGroup="vsErrorBuildindOwnerSubLease" />
    <input id="hdnControlIDsBuildingOwnerShipSubLease" runat="server" type="hidden" />
    <input id="hdnErrorMsgsBuildingOwnerShipSubLease" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorPCA" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsPropertyCondition"
        Display="None" ValidationGroup="vsErrorAssessment" />
    <input id="hdnControlIDsPCA" runat="server" type="hidden" />
    <input id="hdnErrorMsgsPCA" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorConcernNote" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsConcernNote" Display="None" ValidationGroup="vsErrorConcern" />
    <input id="hdnControlIDsConcernNote" runat="server" type="hidden" />
    <input id="hdnErrorMsgsConcernNote" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorContact" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsContact"
        Display="None" ValidationGroup="vsErrorContact" />
    <input id="hdnControlIDsContact" runat="server" type="hidden" />
    <input id="hdnErrorMsgsContact" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorST" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsST"
        Display="None" ValidationGroup="vsErrorSabaTraining" />
    <input id="hdnControlIDsST" runat="server" type="hidden" />
    <input id="hdnErrorMsgsST" runat="server" type="hidden" />
    <script language="javascript" type="text/javascript">
        window.onscroll = getScrollHeight;
        //window.onload=getScrollHeight;
        //used to get height of scrollbar and add to total screen height +  scollbar height
        function getScrollHeight() {
            var h = window.pageYOffset ||
           document.body.scrollTop ||
           document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }


        //used to hide/display Named Loss Payees controls
        function checkNamedLossPayees() {
            document.getElementById('<%=btnViewAuditLossPayee.ClientID%>').style.display = "none";
            document.getElementById('<%=trNamedLossPayees.ClientID %>').style.display = "";
        }

        //used to hide/display Additional Insured controls
        function checkAdditionalInsured() {
            document.getElementById('<%=btnViewAuditAdditionalInsured.ClientID%>').style.display = "none";
            document.getElementById('<%=trAdditionalInsured.ClientID %>').style.display = "";
        }


        function checkAdditionalSubLease() {
            var ID = document.getElementById('<%=hdnBuildingOwnershipID.ClientID%>').value;
            if (ID > 0) {
                document.getElementById('<%=gridSubLease.ClientID %>').style.display = "";
                document.getElementById('<%=trSubLease.ClientID %>').style.display = "";
                document.getElementById('<%=trbtngvLeaseSave.ClientID %>').style.display = "";
                document.getElementById('<%=btnLeaseAuditTrail.ClientID %>').style.display = "none";
                document.getElementById('<%=txtSubLease_Name.ClientID %>').value = "";
                document.getElementById('<%=txtSublease_Address_1.ClientID %>').value = "";
                document.getElementById('<%=txtSublease_Address_2.ClientID %>').value = "";
                document.getElementById('<%=txtSublease_City.ClientID %>').value = "";
                document.getElementById('<%=ddlSublease_State.ClientID %>').value = "";
                document.getElementById('<%=txtSublease_Zip.ClientID %>').value = "";
                document.getElementById('<%=txtSubLandlord.ClientID %>').value = "";
                document.getElementById('<%=txtSubleaseFirstName.ClientID %>').value = "";
                document.getElementById('<%=txtSubleaseLastName.ClientID %>').value = "";
                document.getElementById('<%=txtSubleaseTitle.ClientID %>').value = "";
                document.getElementById('<%=txtSubleasePhone.ClientID %>').value = "";
                document.getElementById('<%=txtSubleaseFax.ClientID %>').value = "";
                document.getElementById('<%=txtSubleaseEmail.ClientID %>').value = "";
            }
            else {
                alert('Please enter Ownership Details First');
            }
        }

        //used to hide/display Flodd Policy controls
        function checkNational_Flood_Policy() {
            var ctl = document.getElementById('<%=rdoNational_Flood_Policy.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trNational_Flood_Policy.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trNational_Flood_Policy.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Property Damage controls
        function checkPropertyDamageLoss() {
            var ctl = document.getElementById('<%=rdoProperty_Damage_Losses_in_the_Past_5_years.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trPropertyDamageLoss.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trPropertyDamageLoss.ClientID %>').style.display = "none";
            }
        }

        function ShowHideNeighbouringOccupancy() {
            var ctl = document.getElementById('<%=rdoNeighboring_Buildings_within_100_ft.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=tblNeighboringOccupancy.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=tblNeighboringOccupancy.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Flood History controls
        function checkFloodHistory() {
            var ctl = document.getElementById('<%=rdoPrior_Flood_History.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trFloodHistory.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trFloodHistory.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Generator controls
        function chkGenerator() {
            var ctl = document.getElementById('<%=rdoGenerator.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trGenerator.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trGenerator.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Fence controls
        function chkFence() {
            var ctl = document.getElementById('<%=rdoFence.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trFence.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trFence.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Intrusion Alarm controls
        function checkIntrusionAlarms() {
            var ctl = document.getElementById('<%=rdoIntru_System.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trIntrusionAlarms.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trIntrusionAlarms.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Security Guard Service controls
        function checkGuardSystem() {
            var ctl = document.getElementById('<%=rdoGuard_System.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trGuardSystem.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trGuardSystem.ClientID %>').style.display = "none";
            }
        }

        //used to hide/display Security Cameras controls
        function checkSecurityCameras() {
            var ctl = document.getElementById('<%=rdoAlarm_Security_Cameras.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trSecurityCameras.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trSecurityCameras.ClientID %>').style.display = "none";
            }
        }
        //used to Calculate Financial Limits TOtal
        function CountFinancialLimits() {
            var Building_Limit = document.getElementById('txtFinancial_Building_Limit.ClientID').value;
            Building_Limit = RemoveCommas(Building_Limit);

            var Associate_Tools_Limit = document.getElementById('txtFinancial_Associate_Tools_Limit.ClientID').value;
            Associate_Tools_Limit = RemoveCommas(Associate_Tools_Limit);

            var Contents_Limit = document.getElementById('txtFinancial_Contents_Limit.ClientID').value;
            Contents_Limit = RemoveCommas(Contents_Limit);

            var Parts_Limit = document.getElementById('txtFinancial_Parts_Limit.ClientID').value;
            Parts_Limit = RemoveCommas(Parts_Limit);

            var Building_Value = document.getElementById('txtRS_Means_Building_Value.ClientID').value;
            Building_Value = RemoveCommas(Building_Value);

            Building_Limit = Building_Limit != '' ? Number(Building_Limit) : 0;
            Associate_Tools_Limit = Associate_Tools_Limit != '' ? Number(Associate_Tools_Limit) : 0;
            Contents_Limit = Contents_Limit != '' ? Number(Contents_Limit) : 0;
            Parts_Limit = Parts_Limit != '' ? Number(Parts_Limit) : 0;
            Building_Value = Building_Value != '' ? Number(Building_Value) : 0;

            var Total = Building_Limit + Associate_Tools_Limit + Contents_Limit + Parts_Limit + Building_Value;
            Total.toFixed(2);
            Total = CurrencyFormatted(Total);

            document.getElementById('txtFinancial_Total.ClientID').value = InsertCommas(Total);
        }

        //used to hide/display DIsposal Type
        function CheckStatus() {
            var ctlVal = document.getElementById('<%=ddlStatus.ClientID %>').options[document.getElementById("<%=ddlStatus.ClientID %>").selectedIndex].value;
            //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
            if (ctlVal == 'Disposed') {
                document.getElementById('<%=tdDisposal.ClientID %>').style.display = "inline";
            }
            else {
                document.getElementById('<%=tdDisposal.ClientID %>').style.display = "none";
                //document.getElementById('<%=txtDisposal_Type.ClientID %>').value="";
            }
        }

        //Used to set Menu Style
        function SetMenuStyle(index) {
            var i;
            if (index == 3)
                index = 2;
            for (i = 1; i <= 5; i++) {

                var tb = document.getElementById("PropertyMenu" + i);

                if (tb != null) {
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
        }
        //Show panel
        function ShowPanel(index) {
            SetMenuStyle(index);
            var op = '<%=strOperation%>';
            if (op == "view") {
                document.getElementById("<%=dvEdit.ClientID %>").style.display = "none";
            }
            else {
                //check if index is 1 than display Property Cope Section.
                if (index == 1) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "";
                    document.getElementById("<%=hdrPropertyCope.ClientID%>").style.display = "";
                    document.getElementById("<%=tblPropertyCope.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 2 than display Building Informaiton Section.
                if (index == 2) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 3 than display Owner ship Details Section.
                if (index == 3) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 4 than display Building Improvement Section.
                if (index == 4) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 5 than display Contacts Section.
                if (index == 5) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "";
                }
            }
        }

        function OpenSelectYearPopup(strType) {
            GB_showCenter('Select Year', '<%=AppConfig.SiteURL%>SONIC/Exposures/PropetySelectYear.aspx?loc=<%=Request.QueryString["loc"]%>&type=' + strType, 300, 500);
        }

        function ViewCOI(type) {
            var popUpTitle = 'Attach Sub-Tenant Certificate of Insurance';
            var PopUpURL = '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyAddCOI.aspx';
            if (type == 'WC') {
                var lnkCOI_WC = document.getElementById('<%=lnkCOI_WC.ClientID %>');
                if (lnkCOI_WC.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_WC.ClientID%>&hdn=<%=hdnCOI_WC.ClientID%>&chk=<%=chkWCTenant.ClientID%>&dtID=<%=lblCOI_WC_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_WC_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);

                    return false;
                }
            }
            else if (type == 'EL') {
                var lnkCOI_EL = document.getElementById('<%=lnkCOI_EL.ClientID %>');
                if (lnkCOI_EL.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_EL.ClientID%>&hdn=<%=hdnCOI_EL.ClientID%>&chk=<%=chkELTenant.ClientID%>&dtID=<%=lblCOI_EL_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_EL_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }
            else if (type == 'GL') {
                var lnkCOI_GL = document.getElementById('<%=lnkCOI_GL.ClientID %>');
                if (lnkCOI_GL.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_GL.ClientID%>&hdn=<%=hdnCOI_GL.ClientID%>&chk=<%=chkGLTenant.ClientID%>&dtID=<%=lblCOI_GL_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_GL_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }
            else if (type == 'Pollution') {
                var lnkCOI_Pollution = document.getElementById('<%=lnkCOI_Pollution.ClientID %>');
                if (lnkCOI_Pollution.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Pollution.ClientID%>&hdn=<%=hdnCOI_Pollution.ClientID%>&chk=<%=chkPollutionTenant.ClientID%>&dtID=<%=lblCOI_Pollution_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_Pollution_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }
            else if (type == 'Property') {
                var lnkCOI_Property = document.getElementById('<%=lnkCOI_Property.ClientID %>');
                if (lnkCOI_Property.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Property.ClientID%>&hdn=<%=hdnCOI_Property.ClientID%>&chk=<%=chkPropertyTenant.ClientID%>&dtID=<%=lblCOI_Property_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_Property_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }
            else if (type == 'Flood') {
                var lnkCOI_Flood = document.getElementById('<%=lnkCOI_Flood.ClientID %>');
                if (lnkCOI_Flood.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Flood.ClientID%>&hdn=<%=hdnCOI_Flood.ClientID%>&chk=<%=chkFloodTenant.ClientID%>&dtID=<%=lblCOI_Flood_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_Flood_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }
            else if (type == 'EQ') {
                var lnkCOI_EQ = document.getElementById('<%=lnkCOI_EQ.ClientID %>');
                if (lnkCOI_EQ.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_EQ.ClientID%>&hdn=<%=hdnCOI_EQ.ClientID%>&chk=<%=chkEQTenant.ClientID%>&dtID=<%=lblCOI_EQ_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_EQ_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }
            else if (type == 'Waiver') {
                var lnkCOI_Waiver = document.getElementById('<%=lnkCOI_Waiver.ClientID %>');
                if (lnkCOI_Waiver.innerHTML == 'Add') {
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Waiver.ClientID%>&hdn=<%=hdnCOI_Waiver.ClientID%>&chk=<%=chkWaiverTenant.ClientID%>&dtID=<%=lblCOI_Waiver_Date.ClientID%>', 300, 500);
                    return false;
                }
                else {
                    var strURL = document.getElementById('<%=hdnCOI_Waiver_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }
            }

}

function OpenOrRemoveCOI(bChecked, type) {
    if (!bChecked) {
        if (type == 'WC') {
            document.getElementById('<%=lnkCOI_WC.ClientID%>').innerHTML = "Add";
            document.getElementById('<%=hdnCOI_WC_Date.ClientID%>').value = "";
            document.getElementById('<%=lblCOI_WC_Date.ClientID%>').innerHTML = '';
        }
        if (type == 'EL') {
            document.getElementById('<%=lnkCOI_EL.ClientID%>').innerHTML = "Add";
            document.getElementById('<%=hdnCOI_EL_Date.ClientID%>').value = "";
            document.getElementById('<%=lblCOI_EL_Date.ClientID%>').innerHTML = '';
        }
        if (type == 'GL') {
            document.getElementById('<%=lnkCOI_GL.ClientID%>').innerHTML = "Add";
            document.getElementById('<%=hdnCOI_GL_Date.ClientID%>').value = "";
            document.getElementById('<%=lblCOI_GL_Date.ClientID%>').innerHTML = '';
        }
        if (type == 'Pollution') {
            document.getElementById('<%=lnkCOI_Pollution.ClientID%>').innerHTML = "Add";
            document.getElementById('<%=hdnCOI_Pollution_Date.ClientID%>').value = "";
            document.getElementById('<%=lblCOI_Pollution_Date.ClientID%>').innerHTML = '';
        }
        if (type == 'Property') {
            document.getElementById('<%=lnkCOI_Property.ClientID%>').innerHTML = "Add";
            document.getElementById('<%=hdnCOI_Property_Date.ClientID%>').value = "";
            document.getElementById('<%=lblCOI_Property_Date.ClientID%>').innerHTML = '';
        }
        if (type == 'Flood') {
            document.getElementById('<%=lnkCOI_Flood.ClientID%>').innerHTML = "Add";
            document.getElementById('<%=hdnCOI_Flood_Date.ClientID%>').value = "";
            document.getElementById('<%=lblCOI_Flood_Date.ClientID%>').innerHTML = '';
        }
        if (type == 'EQ') {
            document.getElementById('<%=lnkCOI_EQ.ClientID%>').innerHTML = "Add";
                    document.getElementById('<%=hdnCOI_EQ_Date.ClientID%>').value = "";
                    document.getElementById('<%=lblCOI_EQ_Date.ClientID%>').innerHTML = '';
                }
                if (type == 'Waiver') {
                    document.getElementById('<%=lnkCOI_Waiver.ClientID%>').innerHTML = "Add";
                    document.getElementById('<%=hdnCOI_Waiver_Date.ClientID%>').value = "";
                    document.getElementById('<%=lblCOI_Waiver_Date.ClientID%>').innerHTML = '';
                }
            }
            else {
                var popUpTitle = 'Attach Sub-Tenant Certificate of Insurance';
                var PopUpURL = '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyAddCOI.aspx';
                if (type == 'WC')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_WC.ClientID%>&hdn=<%=hdnCOI_WC.ClientID%>&chk=<%=chkWCTenant.ClientID%>&dtID=<%=lblCOI_WC_Date.ClientID%>', 300, 500);
                else if (type == 'EL')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_EL.ClientID%>&hdn=<%=hdnCOI_EL.ClientID%>&chk=<%=chkELTenant.ClientID%>&dtID=<%=lblCOI_EL_Date.ClientID%>', 300, 500);
                else if (type == 'GL')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_GL.ClientID%>&hdn=<%=hdnCOI_GL.ClientID%>&chk=<%=chkGLTenant.ClientID%>&dtID=<%=lblCOI_GL_Date.ClientID%>', 300, 500);
                else if (type == 'Pollution')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Pollution.ClientID%>&hdn=<%=hdnCOI_Pollution.ClientID%>&chk=<%=chkPollutionTenant.ClientID%>&dtID=<%=lblCOI_Pollution_Date.ClientID%>', 300, 500);
                else if (type == 'Property')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Property.ClientID%>&hdn=<%=hdnCOI_Property.ClientID%>&chk=<%=chkPropertyTenant.ClientID%>&dtID=<%=lblCOI_Property_Date.ClientID%>', 300, 500);
                else if (type == 'Flood')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Flood.ClientID%>&hdn=<%=hdnCOI_Flood.ClientID%>&chk=<%=chkFloodTenant.ClientID%>&dtID=<%=lblCOI_Flood_Date.ClientID%>', 300, 500);
                else if (type == 'EQ')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_EQ.ClientID%>&hdn=<%=hdnCOI_EQ.ClientID%>&chk=<%=chkEQTenant.ClientID%>&dtID=<%=lblCOI_EQ_Date.ClientID%>', 300, 500);
                else if (type == 'Waiver')
                    GB_showCenter(popUpTitle, PopUpURL + '?lnk=<%=lnkCOI_Waiver.ClientID%>&hdn=<%=hdnCOI_Waiver.ClientID%>&chk=<%=chkWaiverTenant.ClientID%>&dtID=<%=lblCOI_Waiver_Date.ClientID%>', 300, 500);

}
}

function ShowHideBuildingAttachment() {
    var trAttach = document.getElementById('<%=trBuildingAttachment.ClientID%>');
    trAttach.style.display = "";
}

function ShowHideLeaseAttachment() {
    document.getElementById('<%=trLeaseAttachment.ClientID%>').style.display = "";
}

 function CheckBeforeAddBuildingAttach() {
            var PK = document.getElementById('<%=hdnBuildingID.ClientID%>').value;
    if (PK > 0)
        ShowHideBuildingAttachment();
    else {
        alert('Please Enter Building Information First');
    }
}



function ConfirmRemove() {
    return confirm("Are you sure to remove?");
}

function ConfirmSubLeaseRemove() {
    return confirm("You have selected to remove a Sub-Lease, the associated Sub-Lease record will also be removed from the Lease Module, Subtenant Information grid. Continue?")
}
function YearValidate(x) {
    var strErrorInval = "";
    var strErrorLess = "";
    strErrorInval = "Year of Built is Invalid.";
    strErrorLess = "Year of Built should be less than or equal to current year.";

    var right_now = new Date();
    var the_year = right_now.getYear();

    var y = document.getElementById(x).value;
    if (y.length < 4 && y.length > 0) {
        alert(strErrorInval);
        document.getElementById(x).select();
    }
    if (y != the_year && y > the_year) {
        alert(strErrorLess);
        document.getElementById(x).select();
    }
}

var pattern = /[0-9]/;
function isValid(id) {
    var keyCode = event.keyCode ? event.keyCode : event.which;
    var key = String.fromCharCode(keyCode);
    if (!pattern.test(key)) {
        event.keyCode = "";
        return false;
    }
}

function ShowHideLimits(bChecked, type) {
    if (type == 'WC')
        document.getElementById('<%=tblWCLimit.ClientID%>').style.display = bChecked ? "" : "none";
    else if (type == 'EL')
        document.getElementById('<%=tblELLimit.ClientID%>').style.display = bChecked ? "" : "none";
    else if (type == 'GL')
        document.getElementById('<%=tblGLLimit.ClientID%>').style.display = bChecked ? "" : "none";
    else if (type == 'Pollution')
        document.getElementById('<%=tblPollutionLimit.ClientID%>').style.display = bChecked ? "" : "none";
            else if (type == 'Property')
                document.getElementById('<%=tblPropertyLimit.ClientID%>').style.display = bChecked ? "" : "none";
            else if (type == 'Flood')
                document.getElementById('<%=tblFloodLimit.ClientID%>').style.display = bChecked ? "" : "none";
            else if (type == 'EQ')
                document.getElementById('<%=tblEQLimit.ClientID%>').style.display = bChecked ? "" : "none";
            else if (type == 'Waiver')
                document.getElementById('<%=tblWaiverLimit.ClientID%>').style.display = bChecked ? "" : "none";

}

function OpenPropertyDetailPopup(PK, FK, strOp) {
    if (strOp == "")
        GB_showCenter('Enter Contact Details', '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyContactDetails.aspx?PK=' + PK + '&FK=' + FK, 300, 500);
    else
        GB_showCenter('Enter Contact Details', '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyContactDetails.aspx?PK=' + PK + '&FK=' + FK + '&op=edit', 300, 500);
}

function ConfirmSave() {
    var isNameAvail = document.getElementById('<%=txtName.ClientID%>').value != "";
    var isPhoneAvail = document.getElementById('<%=txtPhone.ClientID%>').value != "";
    var isCellAvail = document.getElementById('<%=txtCell_Phone.ClientID%>').value != "";
    var isContNameAvail = document.getElementById('<%=txtAfter_Hours_Contact_Name.ClientID%>').value != "";
    var isContactPhoneAvail = document.getElementById('<%=txtAfter_Hours_Contact_Phone.ClientID%>').value != "";
    var isContactCellAvail = document.getElementById('<%=txtAfter_Hours_Contact_Cell_Phone.ClientID%>').value != "";
    var BuildingID = document.getElementById('<%=hdnBuildingID.ClientID%>').value;

    if (isNameAvail || isPhoneAvail || isCellAvail || isContNameAvail || isContactPhoneAvail || isContactCellAvail) {
        if (BuildingID > 0)
            return true;
        else {
            var bConfirm = confirm("The contact details will not be saved until a building information is selected or saved. Are you sure to proceed?");
            return bConfirm;
        }
    }
    else
        return false;
}

function CurrencyFormatted(amount) {
    var i = parseFloat(amount);
    if (isNaN(i)) { i = 0.00; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);

    i = parseInt((i + .005) * 100);

    i = i / 100;
    s = new String(i);
    if (s.indexOf('.') < 0) { s += '.00'; }
    if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
    s = minus + s;
    return s;
}

function returnConfirm() {
    return confirm('Are you sure you want to remove the selected data from eRIMS2? Once the data are removed, eRIMS2 does not have functionality to retrieve the data.');
}

function GetPercentTrained() {

    var Number_Of_Employees = document.getElementById('<%=txtNumber_of_Employees.ClientID %>').value;
    var Number_Trained = document.getElementById('<%=txtNumber_of_Employees_To_Date.ClientID%>').value;

    if (Number_Of_Employees != "" && Number_Trained != "" && Number(Number_Of_Employees.replace(/,/g, '')) > 0) {
        var cPercent = ((parseFloat(Number_Trained.replace(/,/g, '')) / parseFloat(Number_Of_Employees.replace(/,/g, '')))) * 100;
        if (cPercent != NaN)
            cPercent = cPercent.toFixed(1);
        document.getElementById('<%=txtPercent_Employee_to_Date.ClientID%>').value = cPercent;
    }
    else {
        document.getElementById('<%=txtPercent_Employee_to_Date.ClientID%>').value = '100.0';
    }
}
    </script>
</asp:Content>
