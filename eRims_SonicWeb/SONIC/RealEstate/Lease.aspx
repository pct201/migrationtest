<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Lease.aspx.cs"
    Inherits="SONIC_Exposures_Lease" Title="eRIMS Sonic :: Exposures :: Leases Data" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">

    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">

        window.onscroll = getScrollHeight;
        function getScrollHeight() {
            var h = window.pageYOffset ||
               document.body.scrollTop ||
               document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 11; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function() { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function() { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function() { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function() { this.className = 'LeftMenuStatic'; }
                }
            }
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;

            var op = document.getElementById('<%=hdnOperation.ClientID%>').value;

            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 10) {
                    for (i = 1; i <= 9; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }

//                    if (index == 3)
//                        document.getElementById('<%=txtSubtenant_Mailing_Address1.ClientID%>').focus();
                    if (index == 4)
                        document.getElementById('<%=txtResponsible_Party.ClientID%>').focus();
                    else if (index == 5)
                        document.getElementById('<%=txtAmount.ClientID%>').focus();
                    else if (index == 7)
                        document.getElementById('<%=txtCondition_At_Commencement.ClientID%>').focus();
                    else if (index == 8)
                        document.getElementById('<%=txtLandlord_Company.ClientID%>').focus();

                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + 11).style.display = "none";
                    
                }
                else {
                    for (i = 1; i <= 9; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + 11).style.display = "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";

                    if (index == 11) {

                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + 11).style.display = "block";
                        document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                        document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    }
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 10) {
                for (i = 1; i <= 9; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + 11 + "View").style.display = "none";
            }
            else {
                for (i = 1; i <= 9; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + 11 + "View").style.display = "none";
                }
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";

                if (index == 11) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + 11 + "View").style.display = "block";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                }
            }
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup')) {
                var retVal = true;
                if (Number(document.getElementById('<%=hdnREInfoID.ClientID%>').value) > 0) {
                    var hdn1 = document.getElementById('<%= hdnRegional_Vice_President.ClientID %>').value;
                    var hdn2 = document.getElementById('<%= hdnRegionalController.ClientID %>').value;
                    var hdn3 = document.getElementById('<%= hdnLoss_Control_Manager.ClientID %>').value;
                    var txt1 = document.getElementById('<%= txtRegional_Vice_President.ClientID %>').value;
                    var txt2 = document.getElementById('<%= txtRegionalController.ClientID %>').value;
                    var txt3 = document.getElementById('<%= txtLoss_Control_Manager.ClientID %>').value;
                    if (hdn1 != txt1 || hdn2 != txt2 || hdn3 != txt3) {
                        retVal = confirm("Would you like to apply the change(s) to the Regional Vice President, Regional Controller and Loss Control Manager to all leases at dealerships in the same Region?");
                        if(retVal == true)
                            __doPostBack(document.getElementById('<%=btnSave.ClientID%>').name, "UpdateRLCMDetails"); 
                    }
                }
                return true;
            }
            else
                return false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function OpenLandlordPopup() {
            var w = 480, h = 340;
            var subleaseYes = document.getElementById('<%=rdoSublease.ClientID %>' + '_0');
            var navigationurl = '<%=AppConfig.SiteURL%>SONIC/Exposures/SelectLandlordPopup.aspx?loc=<%=Request.QueryString["loc"]%>&sublease=' + (subleaseYes.checked ? 'Y' : 'N');

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 700, popH = 500;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navigationurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }

        function OpenBuildingPopup(pk) {
            ShowPanel(1);
            var w = 480, h = 340;
            var subleaseYes = document.getElementById('<%=rdoSublease.ClientID %>' + '_0');
            var navigationurl = '<%=AppConfig.SiteURL%>SONIC/Exposures/SelectBuildingPopup.aspx?loc=<%=Request.QueryString["loc"]%>&sublease=' + (subleaseYes.checked ? 'Y' : 'N') + '&PK_RE=' + pk;

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 700, popH = 500;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navigationurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }

        function OpenSubLeasePopup(pk) {
            var w = 480, h = 340;
            var navigationurl = '<%=AppConfig.SiteURL%>SONIC/Exposures/SelectSubLeasePopup.aspx?loc=<%=Request.QueryString["loc"]%>&PK_RE=' + pk;

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 700, popH = 500;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navigationurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }

        function YearValidate(x) {
            var strErrorInval = "";
            var strErrorLess = "";
            strErrorInval = "Year is Invalid.";
            strErrorLess = "Year should be less than or equal to current year.";

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

        function MakeEditableRateRent(drp) {
            if (drp.options[drp.selectedIndex].innerHTML == "LIBOR Rate Schedule") {
                document.getElementById('<%=txtPercentage_RateRent.ClientID%>').disabled = false;
            }
            else {
                document.getElementById('<%=txtPercentage_RateRent.ClientID%>').value = '';
                document.getElementById('<%=txtPercentage_RateRent.ClientID%>').disabled = true;
            }
        }

        function MakeEditableRateSubtenant(drp) {
            if (drp.options[drp.selectedIndex].innerHTML == "LIBOR Rate Schedule") {
                document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>').disabled = false;
            }
            else {
                document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>').value = '';
                document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>').disabled = true;
            }
        }

        function MakeEditableRateRentProjection(drp) {
            if (drp.options[drp.selectedIndex].innerHTML == "LIBOR Rate Schedule") {
                document.getElementById('<%=txtPercentage_Rate.ClientID%>').disabled = false;
            }
            else {
                document.getElementById('<%=txtPercentage_Rate.ClientID%>').value = '';
                document.getElementById('<%=txtPercentage_Rate.ClientID%>').disabled = true;
            }
        }

        function CalculateMonthlyRent(type) {
            var txtPercent;
            if (type == 'Rent')
                txtPercent = document.getElementById('<%=txtPercentage_RateRent.ClientID%>')
            else if (type == 'Subtenant')
                txtPercent = document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>')
            else
                txtPercent = document.getElementById('<%=txtPercentage_Rate.ClientID%>');

            if (Number(txtPercent.value) <= 100 || txtPercent.value == '') {
                if (document.getElementById('<%=txtLease_Commencement_Date.ClientID%>').value != '') {
                    if (type == 'Rent')
                        document.getElementById('<%=btnUpdateRent_Rent.ClientID%>').click();
                    else if (type == 'Subtenant')
                        document.getElementById('<%=btnUpdateRentSubtenant.ClientID%>').click();
                    else
                        document.getElementById('<%=btnUpdateRent_RentProj.ClientID%>').click();
                }
                else {
                    alert('Please enter the [Lease Information]/Lease Commensement Date to calculate the rents');
                    txtPercent.value = '';
                    txtPercent.focus();
                }
            }
            else {
                alert('Percentage Rate should be less than 100');
                txtPercent.value = '';
                txtPercent.focus();
            }
        }

        function AddRentScheduleRent(bAdd) {            
            var bValid = Page_ClientValidate('vsErrorGroup');
            if (bValid) {
                if (AvailableLeaseDateAndEscalation('Rent'))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        function AddSubTenantRentSchedule(bAdd) {
            //var bValid = (bAdd == 'Add') ? Page_ClientValidate('vsErrorGroup') : true;
            var bValid = Page_ClientValidate('vgSubtenant');
            if (bValid) {
                if (AvailableLeaseDateAndEscalation('SubTenant'))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        function AddRentProjectionRentSchedule(bAdd) {
            //var bValid = (bAdd == 'Add') ? Page_ClientValidate('vsErrorGroup') : true;
            var bValid = Page_ClientValidate('vsErrorGroup');
            if (bValid) {
                if (AvailableLeaseDateAndEscalation('RentProjection'))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        function AvailableLeaseDateAndEscalation(type) {
            var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
            var Escalation;
            if (type == 'Rent')
                Escalation = document.getElementById('<%=drpFK_LU_EscalationRent.ClientID %>').value;
            else if (type == 'SubTenant')
                Escalation = document.getElementById('<%=drpFK_LU_EscalationSubtenant.ClientID %>').value;
            else
                Escalation = document.getElementById('<%=drpFK_LU_Escalation.ClientID %>').value;

            if (LeaseDate == '') {
                alert("An entry in [Lease Information]/Lease Commencement Date is required in order to add a Rent Grid Record");
                return false;
            }
            else {
                if (Escalation == 0) {
                    alert("An entry in " + ((type == 'Rent') ? "[Rent]" : ((type == 'SubTenant') ? "[Subtenant Information]" : "[Rent Projections]"))
	                        + "/Escalation is required in order to add a Rent Grid Record");
                    return false;
                }
                else
                    return true;
            }
        }

        function ConfirmDelete() {
            return confirm('Are you sure you want to remove the selected data from eRIMS2? Once the data are removed, eRIMS2 does not have functionality to retrieve the data.');
        }

        function ConfirmSubLeaseRemove() {
            return confirm('You have selected to remove a Subtenant from the Lease module data for the above location. Continue?');
        }
        function UpdateRents() {
            var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
            if (LeaseDate != '') {
                var bValid = CheckValidDate('<%=txtLease_Commencement_Date.ClientID %>');
                if (bValid) {
                    __doPostBack('LeaseDateChanged', '');
                }
            }
            else {
                document.getElementById('<%=lblRentLeaseCommencementDate.ClientID%>').innerHTML = '';
                document.getElementById('<%=lblSubTenantLeaseCommencementDate.ClientID%>').innerHTML = '';
                document.getElementById('<%=lblRentProjectionsLeaseCommencementDate.ClientID%>').innerHTML = '';
            }
        }
        function ShowMessageLeaseDateError(type) {
            ShowPanel(1);
            if (type == 'Rent')
                alert('One or more From Date in [Rent]/Renewal Rent Schedule grid is less than Lease Commencement Date. Please enter proper Lease Commencement Date.');
            else if (type == 'Subtenant')
                alert('One or more From Date in [Subtenant Information]/Option Rent Scheule grid is less than Lease Commencement Date. Please enter proper Lease Commencement Date.');
            else
                alert('One or more From Date in [Rent Projection]/Option Rent Scheule grid is less than Lease Commencement Date. Please enter proper Lease Commencement Date.');

            //document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value = '';    
            //document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').focus();
        }

        function UpdateRentMonthlyRent() {
            var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
            var MonthlyRent = document.getElementById('<%=txtRentSubtenant_Monthly_Rent.ClientID%>').value;
            if (LeaseDate != '') {
                __doPostBack('RentMonthlyRentChanged', '');
            }
        }
        function UpdateSubtenantMonthlyRent() {
            var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
            var MonthlyRent = document.getElementById('<%=txtSubtenant_Monthly_RentSubtenant.ClientID%>').value;
            if (LeaseDate != '') {
                __doPostBack('SubtenantMonthlyRentChanged', '');
            }
        }

        function UpdateRentProjectionMonthlyRent() {
            var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
            var MonthlyRent = document.getElementById('<%=txtSubtenant_Monthly_Rent.ClientID%>').value;
            if (LeaseDate != '') {
                __doPostBack('RentProjectionMonthlyRentChanged', '');
            }
        }

        function CheckLeaseDate() {
            var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
            if (LeaseDate == '') {
                alert("Please enter the [Lease Information]/Lease Commencement Date in order to manage the Rent schedule grid records.");
                return false;
            }
            else
                return true;
        }

        function ReportPopUp() {
            var winHeight = window.screen.availHeight - 500;
            var winWidth = window.screen.availWidth - 800;

            window.open("../RealEstate/LeaseAbstract.aspx?id=" + '<%=_PK_RE_Information%>', '', 'width=' + 200 + ',height=' + 200 + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');

            return false;
        }

        function AuditPopUp(intIndex) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;
            var strURL;
            if (intIndex == 1)
                strURL = "AuditPopup_RE_Information.aspx?id=" + document.getElementById('<%=hdnREInfoID.ClientID%>').value;
            else if (intIndex == 2)
                strURL = "AuditPopup_RE_Subtenant.aspx?id=" + document.getElementById('<%=hdnSubtenantID.ClientID%>').value;
            else if (intIndex == 3)
                strURL = "AuditPopup_RE_Rent_Proj.aspx?id=" + document.getElementById('<%=hdnRentProjID.ClientID%>').value;
            else if (intIndex == 4)
                strURL = "AuditPopup_RE_Security_Deposit.aspx?id=" + document.getElementById('<%=hdnSecurityDepositID.ClientID%>').value;
            else if (intIndex == 5)
                strURL = "AuditPopup_RE_Surrender.aspx?id=" + document.getElementById('<%=hdnSurrenderID.ClientID%>').value;
            else if (intIndex == 6)
                strURL = "AuditPopup_RE_Notices.aspx?id=" + document.getElementById('<%=hdnNotices.ClientID%>').value;
            else if (intIndex == 7)
                strURL = "AuditPopup_RE_Rent.aspx?id=" + document.getElementById('<%=hdnRentID.ClientID%>').value;

            obj = window.open(strURL, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPercentage_RateSubtenant') {                                   
                                    if (document.getElementById('<%=drpFK_LU_EscalationSubtenant.ClientID %>').options[document.getElementById('<%=drpFK_LU_EscalationSubtenant.ClientID %>').selectedIndex].text == 'LIBOR Rate Schedule')                                   
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPercentage_RateRent') {
                                    if (document.getElementById('<%=drpFK_LU_EscalationRent.ClientID %>').options[document.getElementById('<%=drpFK_LU_EscalationRent.ClientID %>').selectedIndex].text == 'LIBOR Rate Schedule')
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPercentage_Rate') {
                                    if (document.getElementById('<%=drpFK_LU_Escalation.ClientID %>').options[document.getElementById('<%=drpFK_LU_Escalation.ClientID %>').selectedIndex].text == 'LIBOR Rate Schedule')
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
        function ValidateSubtenantFileds(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnSubtenanatIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnSubtenantErroeMassage.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnSubtenanatIDs.ClientID%>').value != "") {
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

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <asp:ValidationSummary ID="vsSubtenant" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vgSubtenant" CssClass="errormessage"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage">
    </asp:ValidationSummary>
    <br />
    <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
    <asp:UpdatePanel ID="pnlHiddentIDs" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <input type="hidden" id="hdnOperation" runat="server" />
            <input type="hidden" id="hdnREInfoID" runat="server" />
            <input type="hidden" id="hdnSubtenantID" runat="server" />
            <input type="hidden" id="hdnRentProjID" runat="server" />
            <input type="hidden" id="hdnSecurityDepositID" runat="server" />
            <input type="hidden" id="hdnSurrenderID" runat="server" />
            <input type="hidden" id="hdnNotices" runat="server" />
            <input type="hidden" id="hdnRentID" runat="server" />
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="2">
                        <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 5px;" colspan="2" width="100%">
                    </td>
                </tr>
            </table>
            <table id="tblMsg" runat="server" style="display: none" width="80%" align="center">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="left">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="#BB0000" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlEditViewLeaseInfo" runat="server">
                <table cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td width="98%" align="left">
                            <asp:GridView ID="gvRealEstate" runat="server" Width="100%" OnRowCommand="gvRealEstate_RowCommand"
                                OnPageIndexChanging="gvRealEstate_PageIndexChanging" AllowPaging="true" PageSize="5"
                                EmptyDataText="No Lease Records Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="Region">
                                        <ItemStyle Width="12%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRegion" runat="server" Text='<%#Eval("Region") %>' CommandName="ShowDetails"
                                                CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LCD">
                                        <ItemStyle Width="9%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLCD" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Commencement_Date"))%>'
                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LED">
                                        <ItemStyle Width="9%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLED" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Expiration_Date"))%>'
                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Landlord">
                                        <ItemStyle Width="11%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLandlord" runat="server" Text='<%#Eval("Landlord") %>' CommandName="ShowDetails"
                                                CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Acquired">
                                        <ItemStyle Width="11%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDate_Acquired" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Acquired"))%>'
                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Building Number(s)">
                                        <ItemStyle Width="21%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLeaseType" runat="server" Text='<%#Eval("Building_Number")%>'
                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Building Street Address">
                                        <ItemStyle Width="21%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkProject_Type" runat="server" Text='<%#Eval("Address_1")%>'
                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Information")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remove">
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_RE_Information") %>'
                                                CommandName="RemoveLease" OnClientClick="return ConfirmDelete();" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click" />
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="Spacer" style="height: 15px;" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="leftMenu">
                                        <table cellpadding="5" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="height: 18px;" class="Spacer">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Lease Information&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Rent&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Subtenant
                                                        Information&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Rent Projections&nbsp;<span id="MenuAsterisk4" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Security
                                                        Deposit&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Repair/Maintenance&nbsp;<span id="MenuAsterisk6" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Surrender
                                                        Obligations&nbsp;<span id="MenuAsterisk7" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu11" onclick="javascript:ShowPanel(11);" class="LeftMenuStatic">Lease Maint Obligations&nbsp;
                                                        <span id="MenuAsterisk11" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Notices&nbsp;<span id="MenuAsterisk8" runat="server" style="color: Red;display:none">*</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu9" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="Menu10" onclick="javascript:ShowPanel(10);" class="LeftMenuStatic">Attachments</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td width="5px" class="Spacer">
                                                    &nbsp;
                                                </td>
                                                <td class="dvContainer">
                                                    <div id="dvEdit" runat="server" width="794px">
                                                        <asp:Button ID="btnSelectBuildingOwnership" runat="server" Style="display: none"
                                                            OnClick="btnSelectBuildingOwnership_Click" />
                                                         <asp:Button id="btnSelectSubLease" runat="server" style="display:none;" OnClick="btnSelectSubLease_OnClick" />
                                                        <input type="hidden" id="hdnOwnershipInfo" runat="server" />
                                                        <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Lease Information</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="6" align="left" class="BlueItalicText">
                                                                        The data for the blue italicized fields on this screen are derived from the Property
                                                                        module for the same location.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="19%" valign="top" class="BlueItalicText">
                                                                        Dealership DBA
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:TextBox ID="txtLU_Location" runat="server" Enabled="false" Width="300px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="19%" valign="top" class="BlueItalicText">
                                                                        Legal Entity
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="27%" valign="top">
                                                                        <asp:TextBox ID="txtLegalEntity" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="20%" valign="top">
                                                                        Federal Id&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="26%" valign="top">
                                                                        <asp:TextBox ID="txtFederal_Id" runat="server" Width="170px" MaxLength="11" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Status" Width="175px" SkinID="dropGen" runat="server"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAddress1" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAddress2" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtCity" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtState" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtZipCode" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTelephone" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        County
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtCounty" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Region
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtRegion" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Tax Parcel Number&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTax_Parcel_Number" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <%--Lease Type--%>&nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        <%--:--%>&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                        <%--<asp:DropDownList ID="drpFK_LU_Lease_Type" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Building Grid&nbsp;<span style="color:Red">*</span><br />
                                                                        <asp:LinkButton ID="lnkAddBuilding" runat="server" Text="--Add--" CausesValidation="false" OnClick="lnkAddBuilding_Click" />
                                                                    </td>
                                                                    <td align="center" valign="top">:</td>
                                                                    <td colspan="4" align="left" valign="top">
                                                                        <asp:GridView ID="gvBuilding" runat="server" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="gvBuilding_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Building Number" DataField="Building_Number" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:TemplateField HeaderText="Building Address">
                                                                                    <ItemStyle Width="40%" />
                                                                                    <ItemTemplate>
                                                                                        <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>                                                                                                
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Landlord Name" DataField="Landlord_Name" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Year Built" DataField="Year_Built" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:TemplateField HeaderText="Remove" ItemStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveBuilding" CommandArgument='<%#Eval("PK_RE_Building") %>' OnClientClick="return confirm('Are you sure to delete the record?')" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>                                                                        
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Number
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBuildingNumber" runat="server" Width="160px" MaxLength="75" Enabled="false" />
                                                                        <input type="hidden" id="hdnBuildingNumber" runat="server" />
                                                                        <img src="../../Images/dropdown_icon.gif" id="img1" style="cursor: pointer;" alt=""
                                                                            onclick="javascript:return OpenBuildingPopup();" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBuildingAddress1" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBuildingAddress2" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBuildingCity" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBuildingState" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBuildingZipCode" runat="server" Width="170px" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord" runat="server" Width="170px" MaxLength="75" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Legal Entity
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlordLegalEntity" runat="server" Width="170px" MaxLength="75"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Location_Address1" runat="server" Width="170px" MaxLength="50"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Location_Address2" runat="server" Width="170px" MaxLength="50"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Location_City" runat="server" Width="170px" MaxLength="50"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpLandlord_Location_State" runat="server" SkinID="dropGen"
                                                                            Width="175px" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Location_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" Enabled="false" />
                                                                        <asp:RegularExpressionValidator ID="revZipCode" ControlToValidate="txtLandlord_Location_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Lease Information]/Landlord Location Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing Address 1&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Mailing_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing Address 2&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Mailing_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing City&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Mailing_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing State&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpLandlordMailingState" runat="server" Width="175px" SkinID="dropGen" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing Zip Code (XXXXX-XXXX)&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Mailing_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtLandlord_Mailing_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Lease Information]/Landlord Mailing Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revTelephone" ControlToValidate="txtLandlord_Telephone"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Lease Information]/Landlord Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Landlord E-Mail&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Email" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtLandlord_Email"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Lease Information]/Landlord E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Sublease?
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButtonList ID="rdoSublease" runat="server" SkinID="YesNoType" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="rdoSublease_SelectedIndexChanged">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Subtenant&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Lease Id
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLease_Id" runat="server" Width="170px" MaxLength="50" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLease_Commencement_Date" runat="server" Width="170px" onChange="UpdateRents();"
                                                                            Enabled="false" />
                                                                        <%--<img alt="Lease Commencement Date" onclick="return; return showCalendar('ctl00_ContentPlaceHolder1_txtLease_Commencement_Date', 'mm/dd/y',setTextFoucs,'ctl00_ContentPlaceHolder1_txtLease_Commencement_Date');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" 
                                                                        align="middle" /><br />--%>
                                                                        <cc1:MaskedEditExtender ID="mskLease_Commencement_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLease_Commencement_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvLease_Commencement_Date" runat="server" ControlExtender="mskLease_Commencement_Date"
                                                                            ControlToValidate="txtLease_Commencement_Date" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="revLease_Commencement_Date" runat="server" ControlToValidate="txtLease_Commencement_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Lease Commencement Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Project Type&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Project_Type" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLease_Expiration_Date" runat="server" Width="170px" Enabled="false" />
                                                                        <%--<img alt="Lease Expiration Date" onclick="return;return showCalendar('ctl00_ContentPlaceHolder1_txtLease_Expiration_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />--%>
                                                                        <cc1:MaskedEditExtender ID="mskLease_Expiration_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLease_Expiration_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvLease_Expiration_Date" runat="server" ControlExtender="mskLease_Expiration_Date"
                                                                            ControlToValidate="txtLease_Expiration_Date" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLease_Expiration_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Lease Expiration Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Date Acquired&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtDate_Acquired" runat="server" Width="145px" />
                                                                        <img alt="Date Acquired" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Acquired', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskDate_Acquired" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Acquired"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvDate_Acquired" runat="server" ControlExtender="mskDate_Acquired"
                                                                            ControlToValidate="txtDate_Acquired" Display="none" IsValidEmpty="true" Enabled="false"
                                                                            MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDate_Acquired"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Date Acquired in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Term In Months&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLease_Term_Months" runat="server" Width="170px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,4,true);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Date Sold&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtDate_Sold" runat="server" Width="145px" />
                                                                        <img alt="Date Sold" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Sold', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskDate_Sold" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                            Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Sold" CultureName="en-US"
                                                                            AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvDate_Sold" runat="server" ControlExtender="mskDate_Sold"
                                                                            ControlToValidate="txtDate_Sold" Display="none" IsValidEmpty="true" Enabled="false"
                                                                            MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDate_Sold"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Date Sold in valid format" Display="none"
                                                                            ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPrior_Lease_Commencement_Date" runat="server" Width="145px" />
                                                                        <img alt="Prior Lease Commencement Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPrior_Lease_Commencement_Date', 'mm/dd/y',setTextFoucs,'ctl00_ContentPlaceHolder1_txtPrior_Lease_Commencement_Date');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskPrior_Lease_Commencement_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtPrior_Lease_Commencement_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvPrior_Lease_Commencement_Date" runat="server" ControlExtender="mskPrior_Lease_Commencement_Date"
                                                                            ControlToValidate="txtPrior_Lease_Commencement_Date" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPrior_Lease_Commencement_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Prior Lease Commencement Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewals&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtRenewals" runat="server" Width="170px" MaxLength="100" />
                                                                    </td>
                                                                    <td colspan="3">&nbsp;</td>
                                                                    <%--<td align="left" valign="top" class="BlueItalicText">
                                                                        Year Built
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtYear_Built" runat="server" Width="170px" MaxLength="4" onkeypress="return isValid(this);"
                                                                            onblur="YearValidate(this.id);" Enabled="false" />
                                                                    </td>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Review Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblReviewDate" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Year Remodeled&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtYear_Remodeled" runat="server" Width="170px" MaxLength="4" onkeypress="return isValid(this);"
                                                                            onblur="YearValidate(this.id);" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Reminder Date&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtReminder_Date" runat="server" Width="145px" />
                                                                        <img alt="Reminder Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReminder_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskReminder_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtReminder_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvReminder_Date" runat="server" ControlExtender="mskReminder_Date"
                                                                            ControlToValidate="txtReminder_Date" Display="none" IsValidEmpty="true" Enabled="false"
                                                                            MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtReminder_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Reminder Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Regional Vice President&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtRegional_Vice_President" runat="server" Width="170px" MaxLength="75" />
                                                                        <input type="hidden" id="hdnRegional_Vice_President" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Regional Controller&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtRegionalController" runat="server" Width="170px" MaxLength="75" />
                                                                        <input type="hidden" id="hdnRegionalController" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Notification Date&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Notification_Date" runat="server" Width="145px" />
                                                                        <img alt="Landlord Notification Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLandlord_Notification_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskLandlord_Notification_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLandlord_Notification_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvLandlord_Notification_Date" runat="server" ControlExtender="mskLandlord_Notification_Date"
                                                                            ControlToValidate="txtLandlord_Notification_Date" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtLandlord_Notification_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Landlord Notification Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        General Manager&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtGeneral_Manager" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Vacate Date&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtVacate_Date" runat="server" Width="145px" />
                                                                        <img alt="Vacate Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtVacate_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskVacate_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtVacate_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvVacate_Date" runat="server" ControlExtender="mskVacate_Date"
                                                                            ControlToValidate="txtVacate_Date" Display="none" IsValidEmpty="true" Enabled="false"
                                                                            MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtVacate_Date"
                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Lease Information]/Vacate Date in valid format" Display="none"
                                                                            ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Controller&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtController" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Primary Use&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPrimary_Use" runat="server" Width="170px" MaxLength="125" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Loss Control Manager&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLoss_Control_Manager" runat="server" Width="170px" MaxLength="75" />
                                                                        <input type="hidden" id="hdnLoss_Control_Manager" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Codes&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLease_Codes" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Total Acres&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTotal_Acres" runat="server" Width="170px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,7,false);" />
                                                                        <%--""--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Number of Buildings&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtNumber_of_Buildings" runat="server" Width="170px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,4,true);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Total Gross Leasable Area (square feet)&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTotal_Gross_Leaseable_Area" runat="server" Width="170px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,9,true);" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Land Value&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;
                                                                        <asp:TextBox ID="txtLand_Value" runat="server" Width="160px" onpaste="return false"
                                                                            onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Amendment Info&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="txtAmendmentInfo" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Assignment Info&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="txtAssignementInfo" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnRE_Information_Audit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(1);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Rent</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Responsible Party&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtResponsible_PartyRent" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentLeaseCommencementDate" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Lease Term in Months&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentLeaseTerm" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentLeaseExpDate" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentPriorLeaseDate" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Cancel Options&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtCancel_OptionsRent" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewal Options&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtRenew_OptionsRent" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewal Notification Due Date&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtNotification_Due_DateRent" runat="server" Width="145px" />
                                                                        <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotification_Due_DateRent', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskNotification_Due_DateRent" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtNotification_Due_DateRent"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvNotification_Due_DateRent" runat="server" ControlExtender="mskNotification_Due_DateRent"
                                                                            ControlToValidate="txtNotification_Due_DateRent" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                            ControlToValidate="txtNotification_Due_DateRent" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Rent]/Renewal Notification Due Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Annual Rent&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:TextBox ID="txtRentSubtenant_Base_Rent" runat="server" Width="160px"
                                                                            onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Monthly Rent&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:TextBox ID="txtRentSubtenant_Monthly_Rent" runat="server" Width="160px"
                                                                            onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,false);"
                                                                            onchange="UpdateRentMonthlyRent();" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Rent Details&nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtRentDetails" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Rent Adjustments&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="txtRentAdjustment" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Escalation&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_EscalationRent" Width="175px" SkinID="dropGen" runat="server"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="drpFK_LU_EscalationRent_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Percentage Rate&nbsp;<span id="Span45" style="color: Red; display: none;position:absolute" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPercentage_RateRent" Enabled="false" runat="server" Width="170px"
                                                                            onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);"
                                                                            onchange="CalculateMonthlyRent('Rent');" />
                                                                        <asp:Button ID="btnUpdateRent_Rent" runat="server" Style="display: none" CausesValidation="false"
                                                                            OnClick="btnUpdateRent_Rent_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Increase Amount&nbsp;<span id="Span46" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtIncreaseRent" runat="server" Width="170px" onpaste="return false"
                                                                            onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Term Rent Schedule Grid<br />
                                                                        <asp:LinkButton ID="lnkAddTRSRent" runat="server" OnClientClick="javascript:return AddRentScheduleRent('Add');"
                                                                            OnClick="lnkAddTRSRent_Click" CausesValidation="true" ValidationGroup="ValidateSubtenantFileds">--Add--</asp:LinkButton>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentTRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentTRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentScheduleRent('Edit');" />
                                                                                        <input type="hidden" id="hdnPK_Rent_TRS" runat="server" value='<%#Eval("PK_RE_Rent_TRS") %>' />
                                                                                        <input type="hidden" id="hdnPercentage" runat="server" value='<%#Eval("Percentage_Rate") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentScheduleRent('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentScheduleRent('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentScheduleRent('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentScheduleRent('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="20%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentScheduleRent('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandName="RemoveTRS"
                                                                                            CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="return ConfirmDelete();" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewal Rent Schedule Grid<br />
                                                                        <asp:LinkButton ID="lnkAddRRSRent" runat="server" OnClientClick="javascript:return AddRentScheduleRent('Add');"
                                                                            OnClick="lnkAddRRSRent_Click" CausesValidation="true" ValidationGroup="ValidateSubtenantFileds">--Add--</asp:LinkButton>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentRRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentRRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Option">
                                                                                    <ItemStyle Width="13%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#Eval("Option_Period")%>' OnClientClick="javascript:return AddRentScheduleRent('Edit');"></asp:LinkButton>
                                                                                        <input type="hidden" id="hdnPK_Rent_RRS" runat="server" value='<%#Eval("PK_RE_Rent_RRS") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            OnClientClick="javascript:return AddRentScheduleRent('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            OnClientClick="javascript:return AddRentScheduleRent('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="13%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            OnClientClick="javascript:return AddRentScheduleRent('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="23%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            OnClientClick="javascript:return AddRentScheduleRent('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="RemoveRRS" OnClientClick="return ConfirmDelete();" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnRE_Rent_Audit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(7);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl3" runat="server">
                                                            <div class="bandHeaderRow">
                                                                Subtenant Information</div>
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td align="left" width="12%" valign="top">
                                                                        <asp:Label Text="Subtenant Grid :" runat="server" /> <br />
                                                                        <asp:LinkButton ID="lnkAddSubtenant" runat="server" Text="--Add--" CausesValidation="false" OnClick="lnkAddSubtenant_Click" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:GridView ID="gvSubtenanat" runat="server" EmptyDataText="No Subtenant Record Exists"
                                                                            OnRowCommand="gvSubtenant_OnRowCommand" Width="100%">
                                                                            <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewSubLeaseDetails" CausesValidation="false" runat="server"
                                                                                                    Text='<%# Container.DataItemIndex + 1 %>' CommandName="ViewSubTenantDetails" CommandArgument='<%#Eval("PK_RE_Subtenant")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Subtenant DBA">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Subtenant_DBA")%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Lease Commencement Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Commencement_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Lease Expiration Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Expiration_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sublease Commencement Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Sublease_Commencement_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sublease Expiration Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Sublease_Expiration_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remove">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkRemoveLease" TeID="lnkRemove" OnClientClick="return ConfirmSubLeaseRemove();"
                                                                                                    CausesValidation="false" runat="server" Text="Remove" CommandName="RemoveSubtenant"
                                                                                                    CommandArgument='<%#Eval("PK_RE_Subtenant")%>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                        </asp:GridView>
                                                                    </td>                                                               
                                                                </tr>                                                               
                                                            </table>    
                                                            <table id="tblSubtenant" runat="server" cellpadding="3" cellspacing="1" border="0" width="100%" style="display:none;">
                                                                <caption>
                                                                    Option Rent Schedule Grid
                                                                    <tr>
                                                                        <td align="left" class="BlueItalicText" colspan="6">The data for the blue italicized fields on this screen are derived from the Property module for the same location. </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="BlueItalicText" valign="top" width="19%">Subtenant/DBA </td>
                                                                        <td align="center" valign="top" width="4%">: </td>
                                                                        <td align="left" valign="top" width="27%">
                                                                            <asp:TextBox ID="txtSubtenant_DBA" runat="server" Enabled="false" MaxLength="75" Width="170px" />
                                                                        </td>
                                                                        <td align="left" valign="top" width="19%">&nbsp; </td>
                                                                        <td align="center" valign="top" width="4%">&nbsp; </td>
                                                                        <td align="center" valign="top" width="27%">&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" width="19%">Subtenant Mailing Address 1&nbsp;<span id="Span47" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top" width="4%">: </td>
                                                                        <td align="left" valign="top" width="27%">
                                                                            <asp:TextBox ID="txtSubtenant_Mailing_Address1" runat="server" MaxLength="50" Width="170px" />
                                                                        </td>
                                                                        <td align="left" valign="top">Subtenant Mailing Address 2&nbsp;<span id="Span48" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtSubtenant_Mailing_Address2" runat="server" MaxLength="50" Width="170px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Subtenant Mailing City&nbsp;<span id="Span49" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtSubtenant_Mailing_City" runat="server" MaxLength="50" Width="170px" />
                                                                        </td>
                                                                        <td align="left" valign="top">Subtenant Mailing State&nbsp;<span id="Span50" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpSubtenantMailingState" runat="server" SkinID="dropGen" Width="175px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Subtenant Mailing Zip Code (XXXXX-XXXX)&nbsp;<span id="Span51" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtSubtenant_Mailing_Zip_Code" runat="server" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" Width="170px" />
                                                                            <asp:RegularExpressionValidator ID="revSubtenant_Mailing_Zip_Code" runat="server" ControlToValidate="txtSubtenant_Mailing_Zip_Code" Display="none" ErrorMessage="Please Enter [Subtenant Information]/Subtenant Mailing Zip Code in xxxxx-xxxx format." ValidationExpression="\d{5}(-\d{4})?" ValidationGroup="vgSubtenant"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" valign="top">Subtenant Telephone&nbsp;<span id="Span52" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtSubtenantTelephone" runat="server" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" Width="170px" />
                                                                            <asp:RegularExpressionValidator ID="revSubtenantTelephone" runat="server" ControlToValidate="txtSubtenantTelephone" Display="none" ErrorMessage="Please Enter [Subtenant Information]/Subtenant Telephone in xxx-xxx-xxxx format." ValidationExpression="\d{3}(-\d{3})(-\d{4})" ValidationGroup="vgSubtenant"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Lease Commencement Date&nbsp;<span id="Span53" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label ID="lblSubTenantLeaseCommencementDate" runat="server" />
                                                                        </td>
                                                                        <td align="left" valign="top">Lease Term in Months&nbsp;<span id="Span54" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label ID="lblSubTenantLeaseTerm" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Lease Expiration Date&nbsp;<span id="Span55" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label ID="lblSubTenantLeaseExpDate" runat="server" />
                                                                        </td>
                                                                        <td align="left" valign="top">Prior Lease Commencement Date&nbsp;<span id="Span56" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label ID="lblSubTenantPriorLeaseDate" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Sublease Commencement Date&nbsp;<span id="Span57" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtSubLease_Commencement_Date" runat="server" Width="145px" />
                                                                            <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSubLease_Commencement_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                            <br />
                                                                            <cc1:MaskedEditExtender ID="mskSubLease_Commencement_Date" runat="server" AcceptNegative="Left" AutoComplete="true" AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtSubLease_Commencement_Date">
                                                                            </cc1:MaskedEditExtender>
                                                                            <cc1:MaskedEditValidator ID="mskvSubLease_Commencement_Date" runat="server" ControlExtender="mskSubLease_Commencement_Date" ControlToValidate="txtSubLease_Commencement_Date" Display="none" Enabled="false" InvalidValueMessage="Date is invalid." IsValidEmpty="true" MaximumValue="" MaximumValueMessage="" MinimumValue="" MinimumValueMessage="" TooltipMessage=""></cc1:MaskedEditValidator>
                                                                            <asp:RegularExpressionValidator ID="revSubLease_Commencement_Date" runat="server" ControlToValidate="txtSubLease_Commencement_Date" Display="none" ErrorMessage="Please Enter [Subtenant]/Sublease Commencement Date in valid format" SetFocusOnError="true" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$" ValidationGroup="vgSubtenant"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" valign="top">Sublease Expiration Date&nbsp;<span id="Span58" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtSubLease_Expiration_Date" runat="server" Width="145px" />
                                                                            <img alt="Lease Expiration Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSubLease_Expiration_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                            <br />
                                                                            <cc1:MaskedEditExtender ID="mskSubLease_Expiration_Date" runat="server" AcceptNegative="Left" AutoComplete="true" AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtSubLease_Expiration_Date">
                                                                            </cc1:MaskedEditExtender>
                                                                            <cc1:MaskedEditValidator ID="mskvSubLease_Expiration_Date" runat="server" ControlExtender="mskSubLease_Expiration_Date" ControlToValidate="txtSubLease_Expiration_Date" Display="none" Enabled="false" InvalidValueMessage="Date is invalid." IsValidEmpty="true" MaximumValue="" MaximumValueMessage="" MinimumValue="" MinimumValueMessage="" TooltipMessage=""></cc1:MaskedEditValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtSubLease_Expiration_Date" Display="none" ErrorMessage="Please Enter [Subtenant]/Sublease Expiration Date in valid format" SetFocusOnError="true" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$" ValidationGroup="vgSubtenant"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Rent Details&nbsp;<span id="Span59" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <uc:ctrlMultiLineTextBox ID="txtCancel_OptionsSubtenant" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Renew Options&nbsp;<span id="Span60" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <uc:ctrlMultiLineTextBox ID="txtRenew_OptionsSubtenant" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Late Fees&nbsp;<span id="Span61" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <uc:ctrlMultiLineTextBox ID="txtOpen_NotificationSubtenant" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Other Requirements&nbsp;<span id="Span62" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <uc:ctrlMultiLineTextBox ID="txtOther_Requirements" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Notification Due Date&nbsp;<span id="Span63" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtNotification_Due_DateSubtenant" runat="server" Width="145px" />
                                                                            <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotification_Due_DateSubtenant', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                            <br />
                                                                            <cc1:MaskedEditExtender ID="mskNotification_Due_DateSubtenant" runat="server" AcceptNegative="Left" AutoComplete="true" AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtNotification_Due_DateSubtenant">
                                                                            </cc1:MaskedEditExtender>
                                                                            <cc1:MaskedEditValidator ID="mskvNotification_Due_DateSubtenant" runat="server" ControlExtender="mskNotification_Due_DateSubtenant" ControlToValidate="txtNotification_Due_DateSubtenant" Display="none" Enabled="false" InvalidValueMessage="Date is invalid." IsValidEmpty="true" MaximumValue="" MaximumValueMessage="" MinimumValue="" MinimumValueMessage="" TooltipMessage=""></cc1:MaskedEditValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtNotification_Due_DateSubtenant" Display="none" ErrorMessage="Please Enter [Subtenant Information]/Notification Due Date in valid format" SetFocusOnError="true" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$" ValidationGroup="vgSubtenant"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Subtenant Annual Rent&nbsp;<span id="Span64" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSubtenant_Base_RentSubtenant" runat="server" onkeypress="return currencyFormat(this,',','.',event);" onpaste="return false" Width="160px" />
                                                                        </td>
                                                                        <td align="left" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Subtenant Monthly Rent&nbsp;<span id="Span65" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSubtenant_Monthly_RentSubtenant" runat="server" onchange="UpdateSubtenantMonthlyRent();" onkeypress="return FormatNumber(event,this.id,9,false);" onpaste="return false" Width="160px" />
                                                                        </td>
                                                                        <td align="left" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Security Deposit&nbsp;<span id="Span66" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSecurityDeposit" runat="server" onkeypress="return currencyFormat(this,',','.',event);" onpaste="return false" Width="160px" />
                                                                        </td>
                                                                        <td align="left" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Escalation&nbsp;<span id="Span67" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpFK_LU_EscalationSubtenant" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpFK_LU_EscalationSubtenant_SelectedIndexChanged" SkinID="dropGen" Width="175px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" valign="top">Percentage Rate&nbsp;<span id="Span169" runat="server" style="color: Red; display: none;position:absolute">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtPercentage_RateSubtenant" runat="server" Enabled="false" onchange="CalculateMonthlyRent('Subtenant');" onkeypress="return FormatNumber(event,this.id,5,false);" onpaste="return false" Width="170px" />
                                                                            <asp:Button ID="btnUpdateRentSubtenant" runat="server" CausesValidation="false" OnClick="btnUpdateRentSubtenant_Click" Style="display: none" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Increase&nbsp;<span id="Span68" runat="server" style="color: Red; display: none;">*</span> </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtIncreaseSubtenant" runat="server" onkeypress="return currencyFormat(this,',','.',event);" onpaste="return false" Width="170px" />
                                                                        </td>
                                                                        <td align="left" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                        <td align="center" valign="top">&nbsp; </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Term Rent Schedule Grid<br />
                                                                            <asp:LinkButton ID="lnkAddTRSSubTenant" runat="server" CausesValidation="false" OnClick="lnkAddTRSSubTenant_Click" OnClientClick="javascript:return AddSubTenantRentSchedule('Add');">--Add--</asp:LinkButton>
                                                                        </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <asp:GridView ID="gvSubtenantTRS" runat="server" EmptyDataText="No Record Found" OnRowCommand="gvSubtenantTRS_RowCommand" Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Year">
                                                                                        <ItemStyle Width="10%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkYear" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#Eval("Year")%>' />
                                                                                            <input type="hidden" id="hdnPK_subtenant_TRS" runat="server" value='<%#Eval("PK_RE_Subtenant_TRS") %>' />
                                                                                            <input type="hidden" id="hdnPercentage" runat="server" value='<%#Eval("Percentage_Rate") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="From">
                                                                                        <ItemStyle Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkFrom" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="To">
                                                                                        <ItemStyle Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkTo" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Months">
                                                                                        <ItemStyle Width="10%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Additions" ItemStyle-HorizontalAlign="Right">
                                                                                        <ItemStyle Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkAdditions" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remove">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' CommandName="RemoveTRS" OnClientClick="return ConfirmDelete();" Text="Remove" Visible="false" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Option Rent Schedule Grid<br />
                                                                            <asp:LinkButton ID="lnkAddORSSubTenant" runat="server" OnClick="lnkAddORSSubTenant_Click" OnClientClick="javascript:return AddSubTenantRentSchedule('Add');">--Add--</asp:LinkButton>
                                                                        </td>
                                                                        <td align="center" valign="top">: </td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <asp:GridView ID="gvSubtenantORS" runat="server" EmptyDataText="No Record Found" OnRowCommand="gvSubtenantORS_RowCommand" Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Option">
                                                                                        <ItemStyle Width="13%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#Eval("Option_Period")%>'></asp:LinkButton>
                                                                                            <input type="hidden" id="hdnPK_subtenant_ORS" runat="server" value='<%#Eval("PK_RE_SubTenant_ORS") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="From">
                                                                                        <ItemStyle Width="18%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="To">
                                                                                        <ItemStyle Width="18%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Months">
                                                                                        <ItemStyle Width="13%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right">
                                                                                        <ItemStyle Width="23%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>' CommandName="ShowDetails" OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remove">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>' CommandName="RemoveORS" OnClientClick="return ConfirmDelete();" Text="Remove" Visible="false" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2"></td>
                                                                        <td align="left" colspan="4" valign="top">
                                                                            <asp:Button ID="btnSaveSubtenantInformation" runat="server" CausesValidation="true" OnClick="btnSaveSubtenantInformation_OnClick" Text="Save" ValidationGroup="vgSubtenant" />
                                                                            &nbsp;
                                                                            <asp:Button ID="btnCancelSubtenantInformation" runat="server" OnClick="btnCancelSubtenantInformation_OnClick" Text="Cancel" />
                                                                            &nbsp;
                                                                            <asp:Button ID="btnSubtenantAudit" runat="server" OnClientClick="javascript:return AuditPopUp(2);" Text="View Audit Trail" />
                                                                        </td>
                                                                    </tr>
                                                                </caption>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl4" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Rent Projections</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Responsible Party&nbsp;<span id="Span69" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtResponsible_Party" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsLeaseCommencementDate" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Lease Term in Months
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsLeaseTerm" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsLeaseExpDate" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsPriorLeaseDate" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Cancel Details&nbsp;<span id="Span70" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtCancel_Options" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renew Options&nbsp;<span id="Span71" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtRenew_Options" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Option Notification&nbsp;<span id="Span72" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtOpen_Notification" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Notification Due Date&nbsp;<span id="Span73" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtNotification_Due_Date" runat="server" Width="145px" />
                                                                        <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotification_Due_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskNotification_Due_Date" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtNotification_Due_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvNotification_Due_Date" runat="server" ControlExtender="mskNotification_Due_Date"
                                                                            ControlToValidate="txtNotification_Due_Date" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                            ControlToValidate="txtNotification_Due_Date" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Rent Projections]/Notification Due Date in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Base Rent&nbsp;<span id="Span74" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:TextBox ID="txtSubtenant_Base_Rent" runat="server" Width="160px" onpaste="return false"
                                                                            onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Monthly Rent&nbsp;<span id="Span75" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:TextBox ID="txtSubtenant_Monthly_Rent" runat="server" Width="160px" onpaste="return false"
                                                                            onkeypress="return FormatNumber(event,this.id,9,false);" onchange="UpdateRentProjectionMonthlyRent();" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Escalation&nbsp;<span id="Span76" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Escalation" Width="175px" SkinID="dropGen" runat="server"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="drpFK_LU_Escalation_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Percentage Rate&nbsp;<span id="Span170" style="color: Red; display: none;position:absolute" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPercentage_Rate" Enabled="false" runat="server" Width="170px"
                                                                            onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);"
                                                                            onchange="CalculateMonthlyRent('RentProjection');" />
                                                                        <asp:Button ID="btnUpdateRent_RentProj" runat="server" Style="display: none" CausesValidation="false"
                                                                            OnClick="btnUpdateRent_RentProj_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Increase&nbsp;<span id="Span77" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtIncrease" runat="server" Width="170px" onpaste="return false"
                                                                            onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Term Rent Schedule Grid<br />
                                                                        <asp:LinkButton ID="lnkAddTRSRentProjection" runat="server" OnClientClick="javascript:return AddRentProjectionRentSchedule('Add');"
                                                                            OnClick="lnkAddTRSRentProjection_Click" CausesValidation="false">--Add--</asp:LinkButton>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentProjectionTRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentProjectionTRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" />
                                                                                        <input type="hidden" id="hdnPK_RentProjection_TRS" runat="server" value='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' />
                                                                                        <input type="hidden" id="hdnPercentage" runat="server" value='<%#Eval("Percentage_Rate") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="20%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandName="RemoveTRS"
                                                                                            CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' OnClientClick="return ConfirmDelete();" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Option Rent Schedule Grid<br />
                                                                        <asp:LinkButton ID="lnkAddORSRentProjection" runat="server" OnClientClick="javascript:return AddRentProjectionRentSchedule('Add');"
                                                                            OnClick="lnkAddORSRentProjection_Click">--Add--</asp:LinkButton>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentProjectionORS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentProjectionORS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Option">
                                                                                    <ItemStyle Width="13%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#Eval("Option_Period")%>' OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton>
                                                                                        <input type="hidden" id="hdnPK_RentProjection_ORS" runat="server" value='<%#Eval("PK_RE_Rent_Projections_ORS") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="13%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="23%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="RemoveORS" OnClientClick="return ConfirmDelete();" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnRentProjAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(3);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Security Deposit</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Amount&nbsp;<span id="Span78" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        $&nbsp;<asp:TextBox ID="txtAmount" runat="server" Width="160px" onpaste="return false"
                                                                            onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Date of Security Deposit&nbsp;<span id="Span79" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtDate_Of_Security_Deposit" runat="server" Width="145px" />
                                                                        <img alt="Date of Security Deposit" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Security_Deposit', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskDate_Of_Security_Deposit" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Of_Security_Deposit"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvDate_Of_Security_Deposit" runat="server" ControlExtender="mskDate_Of_Security_Deposit"
                                                                            ControlToValidate="txtDate_Of_Security_Deposit" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                            ControlToValidate="txtDate_Of_Security_Deposit" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Security Deposit]/Date of Security Deposit in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Tender Type&nbsp;<span id="Span80" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Tender_Type" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Received By&nbsp;<span id="Span81" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtReceived_By" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If Paid By Check</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Bank Name the Check was Drawn Against&nbsp;<span id="Span82" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBank_Name" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Check Number&nbsp;<span id="Span83" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtCheck_Number" runat="server" Width="170px" onkeypress="return FormatInteger(event);"
                                                                            MaxLength="6" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Name Printed on Check&nbsp;<span id="Span84" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtName_On_Check" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Account Number&nbsp;<span id="Span85" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAccount_Number" runat="server" Width="170px" onkeypress="return FormatInteger(event);"
                                                                            MaxLength="20" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit Held At&nbsp;<span id="Span86" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Security_Deposit_Held" Width="175px" SkinID="dropGen"
                                                                            runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit Returned?&nbsp;<span id="Span87" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButtonList ID="rdoSecurity_Deposit_Returned" runat="server" SkinID="YesNoType">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Date Security Deposit Returned&nbsp;<span id="Span88" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtDate_Security_Deposit_Returned" runat="server" Width="145px" />
                                                                        <img alt="Date Security Deposit Returned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Security_Deposit_Returned', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" /><br />
                                                                        <cc1:MaskedEditExtender ID="mskDate_Security_Deposit_Returned" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Security_Deposit_Returned"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="mskvDate_Security_Deposit_Returned" runat="server" ControlExtender="mskDate_Security_Deposit_Returned"
                                                                            ControlToValidate="txtDate_Security_Deposit_Returned" Display="none" IsValidEmpty="true"
                                                                            Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                            MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                            ControlToValidate="txtDate_Security_Deposit_Returned" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                            ErrorMessage="Please Enter [Security Deposit]/Date Security Deposit Returned in valid format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit Reduced?&nbsp;<span id="Span89" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButtonList ID="rdoSecurity_Deposit_Reduced" runat="server" SkinID="YesNoType">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Reason for Security Deposit Reduction&nbsp;<span id="Span90" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSecurity_Deposit_Reduction_Reason" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Any Interest to be Realized on Security Deposit?&nbsp;<span id="Span91" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButtonList ID="rdoInterest_On_Security_Deposit" runat="server" SkinID="YesNoType">
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Interest Amount&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:TextBox ID="txtInterest_Amount" runat="server" Width="160px" onpaste="return false"
                                                                            onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Amount of Security Deposit Returned&nbsp;<span id="Span93" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;
                                                                        <asp:TextBox ID="txtAmount_Security_Deposit_Returned" runat="server" Width="170px"
                                                                            onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnSecurityDeposit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(4);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl6" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Repair/Maintenance</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Repair/Maintenance Grid<br />
                                                                        <asp:LinkButton ID="lnkAddRepairMaint" runat="server" Text="--Add--" ValidationGroup="vsErrorGroup"
                                                                            CausesValidation="true" OnClick="lnkAddRepairMaint_Click" />
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <div style="width: 600px; overflow-x: scroll; overflow-y: hidden;">
                                                                            <asp:GridView ID="gvRepairMaintenance" runat="server" EmptyDataText="No Record Found"
                                                                                Width="1300px" OnRowCommand="gvRepairMaintenance_RowCommand">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Repair Type">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkRepairType" runat="server" Text='<%#Eval("Repair_Type")%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="PCA Conducted">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkPCADate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_PCA_Conducted")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Scope of Work">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkScopeOfWork" runat="server" Text='<%#Eval("Work_Scope") %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Detail">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDetail" runat="server" Text='<%# Eval("Detailed_Description")%>'
                                                                                                CssClass="TextClip" Width="90px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Contractor">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkContractor" runat="server" Text='<%#Eval("Contractor")%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Estimate $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEstimate" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Estimate_Amount"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Proposal $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkProposal" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Proposal_Amount"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Actual $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkActual" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Actual_Amount"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Variance $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkVariance" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Variance"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Est. Start Date">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEstStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Estaimted_Start_Date")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Actual Start Date">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkActualStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Start_Date")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date Complete">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDateComplete" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Days">
                                                                                        <ItemStyle Width="50px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDays" runat="server" Text='<%#Eval("Days")%>' CommandName="ShowDetails"
                                                                                                CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Remove">
                                                                                        <ItemStyle Width="50px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                                CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' OnClientClick="return ConfirmDelete();"
                                                                                                Visible='<%#(App_Access == AccessType.Administrative_Access) %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl7" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Surrender Obligations</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Condition at Lease Commencement Date&nbsp;<span id="Span94" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtCondition_At_Commencement" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Permitted Use&nbsp;<span id="Span95" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtPermitted_Use" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Alterations&nbsp;<span id="Span96" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtAlterations" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Tenant’s Obligations&nbsp;<span id="Span97" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtTenants_Obligations" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Environmental Matters – Tenant’s Covenant&nbsp;<span id="Span98" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtEnvironmental_Matters" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord’s Obligations&nbsp;<span id="Span99" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtLandlords_Obligations" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnSurrenderObligationAudit" runat="server" Text="View Audit Trail"
                                                                            OnClientClick="javascript:return AuditPopUp(5);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl8" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Notices</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If to Landlord</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Company&nbsp;<span id="Span100" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Company" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Contact Name&nbsp;<span id="Span101" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1&nbsp;<span id="Span102" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2&nbsp;<span id="Span103" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City&nbsp;<span id="Span104" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State&nbsp;<span id="Span105" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_State_Landlord" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span106" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_Zip_Code" ControlToValidate="txtLandlord_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span107" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_TelephoneNotices" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_TelephoneNotices" ControlToValidate="txtLandlord_TelephoneNotices"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span108" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_Facsimile" ControlToValidate="txtLandlord_Facsimile"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Facsimile in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail&nbsp;<span id="Span109" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_EmailNotices" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_EmailNotices" runat="server" ControlToValidate="txtLandlord_EmailNotices"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Landlord E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        With a copy to
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company&nbsp;<span id="Span110" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Company" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name&nbsp;<span id="Span111" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1&nbsp;<span id="Span112" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2&nbsp;<span id="Span113" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City&nbsp;<span id="Span114" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State&nbsp;<span id="Span115" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_State_Landlord_Copy" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span116" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_Copy_Zip_Code" ControlToValidate="txtLandlord_Copy_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Copy Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span117" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_Copy_Telephone" ControlToValidate="txtLandlord_Copy_Telephone"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Copy Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span118" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_Copy_Facsimile" ControlToValidate="txtLandlord_Copy_Facsimile"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Copy Facsimile in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail&nbsp;<span id="Span119" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtLandlord_Copy_Email" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revLandlord_Copy_Email" runat="server" ControlToValidate="txtLandlord_Copy_Email"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Landlord Copy E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If to Tenant</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company&nbsp;<span id="Span120" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Company" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name&nbsp;<span id="Span121" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1&nbsp;<span id="Span122" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2&nbsp;<span id="Span123" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City&nbsp;<span id="Span124" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State&nbsp;<span id="Span125" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_State_Tenant" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span126" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="rTenant_Zip_Code" ControlToValidate="txtTenant_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span127" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Telephone" ControlToValidate="txtTenant_Telephone"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span128" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Facsimile" ControlToValidate="txtTenant_Facsimile"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Facsimile in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail&nbsp;<span id="Span129" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Email" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Email" runat="server" ControlToValidate="txtTenant_Email"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Tenant E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        With a copy to
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company&nbsp;<span id="Span130" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Company" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name&nbsp;<span id="Span131" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1&nbsp;<span id="Span132" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2&nbsp;<span id="Span133" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City&nbsp;<span id="Span134" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State&nbsp;<span id="Span135" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_State_Tenant_Copy" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span136" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Copy_Zip_Code" ControlToValidate="txtTenant_Copy_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Copy Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span137" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Copy_Telephone" ControlToValidate="txtTenant_Copy_Telephone"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Copy Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span138" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Copy_Facsimile" ControlToValidate="txtTenant_Copy_Facsimile"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Copy Facsimile in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail&nbsp;<span id="Span139" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTenant_Copy_Email" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revTenant_Copy_Email" runat="server" ControlToValidate="txtTenant_Copy_Email"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Tenant Copy E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If to Subtenant</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company&nbsp;<span id="Span140" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Company" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name&nbsp;<span id="Span141" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1&nbsp;<span id="Span142" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2&nbsp;<span id="Span143" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City&nbsp;<span id="Span144" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State&nbsp;<span id="Span145" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_State_Subtenant" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span146" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Zip_Code" ControlToValidate="txtSubtenant_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span147" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Telephone" ControlToValidate="txtSubtenant_Telephone"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span148" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Facsimile" ControlToValidate="txtSubtenant_Facsimile"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Facsimile in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail&nbsp;<span id="Span149" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Email" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Email" runat="server" ControlToValidate="txtSubtenant_Email"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Subtenant E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        With a copy to
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company&nbsp;<span id="Span150" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Company" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name&nbsp;<span id="Span151" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1&nbsp;<span id="Span152" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2&nbsp;<span id="Span153" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City&nbsp;<span id="Span154" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_City" runat="server" Width="170px" MaxLength="50" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State&nbsp;<span id="Span155" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_State_Subtenant_Copy" Width="175px" SkinID="dropGen"
                                                                            runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span156" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                            onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Copy_Zip_Code" ControlToValidate="txtSubtenant_Copy_Zip_Code"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Copy Zip Code in xxxxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span157" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Copy_Telephone" ControlToValidate="txtSubtenant_Copy_Telephone"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Copy Telephone in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span158" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Copy_Facsimile" ControlToValidate="txtSubtenant_Copy_Facsimile"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Copy Facsimile in xxx-xxx-xxxx format."
                                                                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail&nbsp;<span id="Span159" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSubtenant_Copy_Email" runat="server" Width="170px" MaxLength="255" />
                                                                        <asp:RegularExpressionValidator ID="revSubtenant_Copy_Email" runat="server" ControlToValidate="txtSubtenant_Copy_Email"
                                                                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Subtenant Copy E-Mail Address Is Invalid"
                                                                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnNoticesAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(6);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl9" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Notes</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td width="18%" align="left" valign="top">
                                                                        Notes Grid<br />
                                                                        <asp:LinkButton ID="lnkAddNotes" runat="server" Text="--Add--" CausesValidation="true"
                                                                            ValidationGroup="vsErrorGroup" OnClick="lnkAddNotes_Click" />
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:GridView ID="gvNotes" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvNotes_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Note Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkNoteDate" runat="server" Text='<%#Convert.ToDateTime(Eval("Note_Date")).ToString("MMM-dd-yyyy")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Note Text Snippet">
                                                                                    <ItemStyle Width="75%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkNote" runat="server" Text='<%#Eval("Notes")%>' CssClass="TextClip"
                                                                                            Width="400px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" OnClientClick="return ConfirmDelete();"
                                                                                            CommandName="RemoveDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' Visible='<%#(App_Access == AccessType.Administrative_Access) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl11" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                               Lease Maintenance Obligations
                                                            </div>
                                                             <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        HVAC Repairs&nbsp;<span id="spanHVACRepairs" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_HVAC_Repairs" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        HVAC Capital&nbsp;<span id="spanCapital" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                       :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_HVAC_Capital" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Roof Repairs&nbsp;<span id="span36" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_Roof_Repairs" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Roof Capital&nbsp;<span id="span160" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                       :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_Roof_Capital" Width="175px" SkinID="dropGen" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                  <tr>
                                                                    <td align="left" valign="top">
                                                                        Other Repairs&nbsp;<span id="Span161" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtOtherRepairs" runat="server" Width="200"  MaxLength="255"/>
                                                                    </td>
                                                                      <td align="left" valign="top">
                                                                        Maintenance Notes&nbsp;<span id="Span162" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" >
                                                                        <uc:ctrlMultiLineTextBox ID="txtMaintenanceNotes" runat="server" Width="200" MaxLength="255" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnLeaseMaintAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(1);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                         </asp:Panel>
                                                        <div id="dvAttachment" runat="server" style="display: none;">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="100%">
                                                                        <uc:ctrlAttachment ID="Attachment" EnableValidationSummary="false" runat="Server"
                                                                            ShowAttachmentButton="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%" align="center">
                                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClick="btnAddAttachment_Click"
                                                                            ValidationGroup="AddAttachment" OnClientClick="javascript:return Page_ClientValidate('AddAttachment');" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Spacer" style="height: 20px;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Spacer" style="height: 20px;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                                                        <ProgressTemplate>
                                                            <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                                                <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                                                                    height: 100%;">
                                                                    <tr align="center" valign="middle">
                                                                        <td class="LoadingText" align="center" valign="middle">
                                                                            <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <div id="dvView" runat="server" width="794px">
                                                        <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Lease Information</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="6" align="left" class="BlueItalicText">
                                                                        The data for the blue italicized fields on this screen are derived from the Property
                                                                        module for the same location.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="19%" valign="top" class="BlueItalicText">
                                                                        Dealership DBA
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Location" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="20%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="26%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="19%" valign="top" class="BlueItalicText">
                                                                        Legal Entity
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="27%" valign="top">
                                                                        <asp:Label ID="lblLegalEntity" runat="server" Width="170px" />
                                                                    </td>
                                                                    <td align="left" width="20%" valign="top">
                                                                        Federal Id
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="26%" valign="top">
                                                                        <asp:Label ID="lblFederal_Id" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Status" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblAddress1" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblAddress2" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblCity" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblState" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblZipCode" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTelephone" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        County
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblCounty" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Region
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRegion" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Tax Parcel Number
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTax_Parcel_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <%--Lease Type--%>&nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        <%--:--%>&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <%--<asp:Label ID="lblFK_LU_Lease_Type" runat="server"></asp:Label>--%>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Building Grid
                                                                    </td>
                                                                    <td align="center" valign="top">:</td>
                                                                    <td colspan="4" align="left" valign="top">
                                                                        <asp:GridView ID="gvBuildingView" runat="server" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Found">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Building Number" DataField="Building_Number" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:TemplateField HeaderText="Building Address">
                                                                                    <ItemStyle Width="40%" />
                                                                                    <ItemTemplate>
                                                                                        <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>                                                                                                
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Landlord Name" DataField="Landlord_Name" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Year Built" DataField="Year_Built" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" />                                                                                
                                                                            </Columns>
                                                                        </asp:GridView>                                                                        
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Number
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBuildingNumber" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBuildingAddress1" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBuildingAddress2" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBuildingCity" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBuildingState" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Building Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBuildingZipCode" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Legal Entity
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlordLegalEntity" runat="server" Width="170px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Location_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Location_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Location_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlordLocationState" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Landlord Location Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Location_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Mailing_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Mailing_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Mailing_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlordMailingState" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Mailing Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Mailing_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Telephone" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Landlord E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Sublease?
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSublease" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Subtenant
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Lease Id
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLease_Id" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLease_Commencement_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Project Type
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Project_Type" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" class="BlueItalicText">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLease_Expiration_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Date Acquired
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDate_Acquired" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Term In Months
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLease_Term_Months" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Date Sold
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDate_Sold" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblPrior_Lease_Commencement_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewals
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td  align="left" valign="top" Style="word-wrap: normal; word-break: break-all;">
                                                                        <asp:Label ID="lblRenewals" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">&nbsp;
                                                                    </td>
                                                                    <%--<td align="left" valign="top" class="BlueItalicText">
                                                                        Year Built
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblYear_Built" runat="server"></asp:Label>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Review Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblReviewDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Year Remodeled
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblYear_Remodeled" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Reminder Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblReminder_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Regional Vice President
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRegional_Vice_President" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Regional Controller
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRegionalController" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord Notification Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Notification_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        General Manager
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblGeneral_Manager" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Vacate Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblVacate_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Controller
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblController" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Primary Use
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblPrimary_Use" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Loss Control Manager
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLoss_Control_Manager" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Codes
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLease_Codes" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Total Acres
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTotal_Acres" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Number of Buildings
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblNumber_of_Buildings" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Total Gross Leasable Area (square feet)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTotal_Gross_Leaseable_Area" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Land Value
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblLand_Value" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Amendment Info
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="lblAmendmentInfo" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Assignment Info
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="lblAssignementInfo" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnREInfoAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(1);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Rent</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Responsible Party
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblResponsible_PartyRent" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentLeaseCommencementDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Lease Term in Months
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentLeaseTermView" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentLeaseExpDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentPriorLeaseDateView" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Cancel Options
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblCancel_OptionsRent" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewal Options
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblRenew_OptionsRent" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewal Notification Due Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblNotification_Due_DateRent" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Annual Rent
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblRentSubtenant_Base_Rent" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Monthly Rent
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblRentSubtenant_Monthly_Rent" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Rent Details
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblRentDetails" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Rent Adjustments
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="lblRentAdjustments" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Escalation
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_EscalationRent" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Percentage Rate
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblPercentage_RateRent" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Increase Amount
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblIncreaseRent" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Term Rent Schedule Grid
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentTRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentTRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="11%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="21%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renewal Rent Schedule Grid
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentRRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentRRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Option">
                                                                                    <ItemStyle Width="14%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails"><%#Eval("Option_Period")%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="19%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="19%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="14%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails"><%#DataBinder.Eval(Container.DataItem, "Months", "{0:N1}")%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="24%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnRE_Rent_AuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(7);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl3View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Subtenant Information</div>
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td width="12%" valign="top">
                                                                        <asp:Label Text="Subtenant Grid :" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:GridView ID="gvSubtenanatView" runat="server" EmptyDataText="No Subtenant Record Exists"
                                                                             OnRowCommand="gvSubtenantView_OnRowCommand" Width="100%">
                                                                            <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewSubLeaseDetails" CausesValidation="false" runat="server"
                                                                                                    Text='<%# Container.DataItemIndex + 1 %>' CommandName="ViewSubTenantDetails" CommandArgument='<%#Eval("PK_RE_Subtenant")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Subtenant DBA">
                                                                                            <ItemStyle Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Subtenant_DBA")%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Lease Commencement Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Commencement_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Lease Expiration Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Lease_Expiration_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sublease Commencement Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Sublease_Commencement_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sublease Expiration Date">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Sublease_Expiration_Date"))%></ItemTemplate>
                                                                                        </asp:TemplateField>                                                                                        
                                                                                    </Columns>
                                                                        </asp:GridView>
                                                                    </td>                                                               
                                                                </tr>                                                                
                                                            </table>
                                                            <table id="tblSubtenantView" runat="server" cellpadding="3" cellspacing="1" border="0" width="100%" style="display:none;">
                                                                <tr>
                                                                    <td colspan="6" align="left" class="BlueItalicText">
                                                                        The data for the blue italicized fields on this screen are derived from the Property
                                                                        module for the same location.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="19%" valign="top" class="BlueItalicText">
                                                                        Subtenant/DBA
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="27%" valign="top">
                                                                        <asp:Label ID="lblSubtenant_DBA" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="19%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="27%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="19%" valign="top">
                                                                        Subtenant Mailing Address 1
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="27%" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Mailing_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Mailing Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Mailing_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Mailing City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Mailing_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Mailing State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenantMailingState" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Mailing Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Mailing_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Telephone
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenantTelephone" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenantLeaseCommencementDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Lease Term in Months
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenantLeaseTermView" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenantLeaseExpDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenantPriorLeaseDateView" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Sublease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubleaseCommencementDate" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Sublease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubleaseExpirationDate" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Rent Details
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblCancel_OptionsSubtenant" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renew Options
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblRenew_OptionsSubtenant" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Late Fees
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblOpen_NotificationSubtenant" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Other Requirements
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblOtherRequirements" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Notification Due Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblNotification_Due_DateSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Annual Rent
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblSubtenant_Base_RentSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Monthly Rent
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblSubtenant_Monthly_RentSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblSecurityDeposit" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Escalation
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_EscalationSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Percentage Rate
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblPercentage_RateSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Increase
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblIncreaseSubtenant" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Term Rent Schedule Grid
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvSubtenantTRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvSubtenantTRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="11%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="21%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Option Rent Schedule Grid
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvSubtenantORSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvSubtenantORS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Option">
                                                                                    <ItemStyle Width="14%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#Eval("Option_Period")%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="19%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="19%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="14%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="24%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="Button1" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(2);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl4View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Rent Projections</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Responsible Party
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblResponsible_Party" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsLeaseCommencementDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Lease Term in Months
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsLeaseTermView" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Lease Expiration Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsLeaseExpDateView" runat="server" />
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Prior Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblRentProjectionsPriorLeaseDateView" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Cancel Options
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblCancel_Options" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Renew Options
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblRenew_Options" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Option Notification
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblOpen_Notification" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Notification Due Date
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblNotification_Due_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Base Rent
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblSubtenant_Base_Rent" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Subtenant Monthly Rent
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblSubtenant_Monthly_Rent" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Escalation
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Escalation" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Percentage Rate
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblPercentage_Rate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Increase
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblIncrease" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Term Rent Schedule Grid
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentProjectionTRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentProjectionTRS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="11%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="16%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="21%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Option Rent Schedule Grid
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:GridView ID="gvRentProjectionORSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvRentProjectionORS_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Option">
                                                                                    <ItemStyle Width="14%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#Eval("Option_Period")%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From">
                                                                                    <ItemStyle Width="19%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To">
                                                                                    <ItemStyle Width="19%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Months">
                                                                                    <ItemStyle Width="14%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemStyle Width="24%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                            CommandName="ShowDetails"><%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="Button2" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(3);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl5View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Security Deposit</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Amount
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Date of Security Deposit
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblDate_Of_Security_Deposit" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Tender Type
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Tender_Type" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Received By
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblReceived_By" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If Paid By Check</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Bank Name the Check was Drawn Against
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblBank_Name" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Check Number
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblCheck_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Name Printed on Check
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblName_On_Check" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Account Number
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblAccount_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit Held At
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Security_Deposit_Held" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit Returned?
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSecurity_Deposit_Returned" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Date Security Deposit Returned
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDate_Security_Deposit_Returned" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Security Deposit Reduced?
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSecurity_Deposit_Reduced" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Reason for Security Deposit Reduction
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblSecurity_Deposit_Reduction_Reason" runat="server"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Any Interest to be Realized on Security Deposit?
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblInterest_On_Security_Deposit" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Interest Amount
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;<asp:Label ID="lblInterest_Amount" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Amount of Security Deposit Returned
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        $&nbsp;
                                                                        <asp:Label ID="lblAmount_Security_Deposit_Returned" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="Button3" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(4);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl6View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Repair/Maintenance</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Repair/Maintenance Grid
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <div style="width: 600px; overflow-x: scroll; overflow-y: hidden;">
                                                                            <asp:GridView ID="gvRepairMaintenanceView" runat="server" EmptyDataText="No Record Found"
                                                                                Width="1250px" OnRowCommand="gvRepairMaintenance_RowCommand">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Repair Type">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkRepairType" runat="server" Text='<%#Eval("Repair_Type")%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="PCA Conducted">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkPCADate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_PCA_Conducted")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Scope of Work">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkScopeOfWork" runat="server" Text='<%#Eval("Work_Scope") %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Detail">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDetail" runat="server" Text='<%# Eval("Detailed_Description")%>'
                                                                                                CssClass="TextClip" Width="90px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Contractor">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkContractor" runat="server" Text='<%#Eval("Contractor")%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Estimate $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEstimate" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Estimate_Amount"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Proposal $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkProposal" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Proposal_Amount"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Actual $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkActual" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Actual_Amount"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Variance $">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkVariance" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Variance"))%>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Est. Start Date">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEstStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Estaimted_Start_Date")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Actual Start Date">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkActualStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Start_Date")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date Complete">
                                                                                        <ItemStyle Width="100px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDateComplete" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>'
                                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Days">
                                                                                        <ItemStyle Width="50px" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDays" runat="server" Text='<%#Eval("Days")%>' CommandName="ShowDetails"
                                                                                                CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl7View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Surrender Obligations</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Condition at Lease Commencement Date
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblCondition_At_Commencement" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Permitted Use
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblPermitted_Use" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Alterations
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblAlterations" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Tenant’s Obligations
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblTenants_Obligations" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Environmental Matters – Tenant’s Covenant
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblEnvironmental_Matters" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Landlord’s Obligations
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblLandlords_Obligations" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="Button4" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(5);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl8View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Notices</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If to Landlord</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Company
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblLandlord_Company" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Contact Name
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblLandlord_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_State_Landlord" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_TelephoneNotices" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Facsimile" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_EmailNotices" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        With a copy to
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Company" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_State_Landlord_Copy" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Telephone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Facsimile" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblLandlord_Copy_Email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If to Tenant </b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Company" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_State_Tenant" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Telephone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Facsimile" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        With a copy to
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Company" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_State_Tenant_Copy" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Telephone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Facsimile" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTenant_Copy_Email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <b>If to Subtenant </b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Company" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_State_Subtenant" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Telephone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Facsimile" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        With a copy to
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Company
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Company" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Contact Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Address 1
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Address1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Address 2
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Address2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        City
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_City" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        State
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_State_Subtenant_Copy" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Zip Code (XXXXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Zip_Code" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Telephone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Facsimile (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Facsimile" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        E-Mail
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubtenant_Copy_Email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="Button5" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(6);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl9View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                Notes</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td width="18%" align="left" valign="top">
                                                                        Notes Grid
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:GridView ID="gvNotesView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                            OnRowCommand="gvNotes_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Note Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkNoteDate" runat="server" Text='<%#Convert.ToDateTime(Eval("Note_Date")).ToString("MMM-dd-yyyy")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Note Text Snippet">
                                                                                    <ItemStyle Width="85%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkNote" runat="server" Text='<%#Eval("Notes")%>' CssClass="TextClip"
                                                                                            Width="450px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnl11View" runat="server" Style="display: none;">
                                                            <div class="bandHeaderRow">
                                                                 Lease Maintenance Obligations
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="18%">
                                                                        HVAC Repairs
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" width="28%">
                                                                        <asp:Label ID="lblHVACRepairs" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" width="18%">
                                                                        HVAC Capital
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">
                                                                       :
                                                                    </td>
                                                                    <td align="left" valign="top" width="28%">
                                                                        <asp:Label ID="lblHVACCapital" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="18%">
                                                                        Roof Repairs
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" width="28%">
                                                                        <asp:Label ID="lblRoofRepairs" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" width="18%">
                                                                        Roof Capital
                                                                    </td>
                                                                    <td align="center" valign="top"width="4%">
                                                                       :
                                                                    </td>
                                                                    <td align="left" valign="top" width="28%">
                                                                        <asp:Label ID="lblRoofCapital" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                  <tr>
                                                                    <td align="left" valign="top" width="18%">
                                                                        Other Repairs
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" width="28%">
                                                                        <uc:ctrlMultiLineTextBox ID="lblOtherRepairs" runat="server" ControlType="Label" width="200"/>
                                                                    </td>
                                                                      <td align="left" valign="top" width="18%">
                                                                        Maintenance Notes
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" width="28%">
                                                                        <uc:ctrlMultiLineTextBox ID="lblMaintenanceNotes" runat="server" ControlType="Label"  Width="200"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="Button7" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp(1);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            </asp:Panel>
                                                    </div>
                                                    <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="100%">
                                                                    <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 150px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <%--<td>
                                &nbsp;
                            </td>--%>
                                    <td align="center" colspan="2">
                                        <div id="dvSave" runat="server" style="display: none;">
                                            <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                                        &nbsp;
                                                        <asp:Button ID="btnAbstractReport" runat="server" Text="Generate Abstract" OnClientClick="javascript:return ReportPopUp();"
                                                            Width="185px" Visible="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvBack" runat="server" style="display: none;">
                                            <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnBack" runat="server" Text=" Edit " OnClick="btnBack_Click" CausesValidation="false" />
                                                        &nbsp;
                                                        <asp:Button ID="btnAbstractReportView" runat="server" Text="Generate Abstract" OnClientClick="javascript:return ReportPopUp();"
                                                            Width="185px" Visible="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                 <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateSubtenantFileds"
                    Display="None" ValidationGroup="vgSubtenant" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
                <input id="hdnSubtenanatIDs" runat="server" type="hidden" />
                <input id="hdnSubtenantErroeMassage" runat="server" type="hidden" />
            </asp:Panel>            
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="lnkAddNew" />
            <asp:PostBackTrigger ControlID="btnAddAttachment" />
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
