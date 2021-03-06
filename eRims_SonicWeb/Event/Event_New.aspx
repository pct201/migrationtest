﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Event_New.aspx.cs" Inherits="Event_Event_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>--%>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentTab/IncidentTab.ascx" TagName="IncidentTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentInfo/IncidentInfo.ascx" TagName="IncidentInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Event/AttachmentEvent.ascx" TagName="Attachment" TagPrefix="uc" %>
<%@ Register Src="~/Controls/EventInfo/EventInfo.ascx" TagName="EventInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Src="~/Controls/AbstractLetters/AbstractLetters.ascx" TagName="ctrlAbstractLetters" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/GridViewScroll/gridviewScroll.min.js"></script>

    <script type="text/javascript">
        
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';

        function OpenChooseBuilding(Type, id) {
            var values = '<%=ViewState["PK_Event"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Event Record First');
                ShowPanel(<%=hdnPanel.Value%>);
                return false;
            }
            else {
                var ddlLocation_Sonic = document.getElementById("<%=ddlLocation_Sonic.ClientID%>");
                var ddlLocation_SonicValue = ddlLocation_Sonic.options[ddlLocation_Sonic.selectedIndex].value;
                GB_showCenter('Building Information', '<%=AppConfig.SiteURL%>Event/BuildingDetailPopUp.aspx?CT_ID=' + Type + '&aci_loc_id=' + ddlLocation_SonicValue + '&event=<%=PK_Event%>', 320, 700, '');
                ShowPanel(<%=hdnPanel.Value%>);
                return false;
            }
        }

        function CheckEvent() {
            var values = '<%=ViewState["PK_Event"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Event Record First');
                return false;
            }
            else {
                return true;
            }
        }

        function SelectDeselectAllACINotes(bChecked) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicACINotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function SelectDeselectSonicNoteHeader() {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicACINotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            var rowCnt = document.getElementById('<%=gvSonic_Notes.ClientID%>').rows.length - 1;
            var headerChkID = 'chkMultiSelectSonicACINotes';

            if (cnt == rowCnt)
                document.getElementById(headerChkID).checked = true;
            else
                document.getElementById(headerChkID).checked = false;
        }

  
        function CheckSelectedAcadianNotes(buttonType) {
            var gv = document.getElementById('<%=gvACI_Notes.ClientID%>');
            var ctrls = gv.getElementsByTagName('input');
            var i;
            var cnt = 0;
            var m_strAttIds = '';
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSonicNotes") > 0) {
                    if (ctrls[i].checked) {
                        var ctrlId = ctrls[i].id;
                        ctrlId = ctrlId.substring(ctrlId.lastIndexOf("_") - 2);
                        var hdnpk = ctrlId.replace("chkSelectSonicNotes", "hdnPK_ACI_Event_Notes");
                        //index = Number(index) - 2;
                        var id = document.getElementById('ctl00_ContentPlaceHolder1_gvACI_Notes_ctl' + hdnpk).value;
                        if (m_strAttIds == "")
                            m_strAttIds = id;
                        else {
                            m_strAttIds = m_strAttIds + "," + id;
                        }
                        cnt++;
                    }
                }
            }
            
            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Note(s) to View");
                else
                    alert("Please select Note(s)");

                return false;
            }
            else {
                if(buttonType != 'Print')//here sonic both view time condition is right
                {
                    AciSelectedNotePopup(m_strAttIds,buttonType);
                    return false;
                }
                else
                    return true;
            }
        }

        function CheckSelectedSonicNotes(buttonType) {
             
            var gv = document.getElementById('<%=dvSonicNOtes.ClientID%>');
            var ctrls = gv.getElementsByTagName('input');
            var i;
            var cnt = 0;
            var m_strAttIds = '';
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSonicACINotes") > 0) {
                    if (ctrls[i].checked) {
                        var ctrlId = ctrls[i].id;
                        ctrlId = ctrlId.substring(ctrlId.lastIndexOf("_") - 2);
                        var hdnpk = ctrlId.replace("chkSelectSonicACINotes", "hdnPK_Sonic_Event_Notes");
                        //index = Number(index) - 2;
                        var id = document.getElementById('ctl00_ContentPlaceHolder1_gvSonic_Notes_ctl' + hdnpk).value;
                        if (m_strAttIds == "")
                            m_strAttIds = id;
                        else {
                            m_strAttIds = m_strAttIds + "," + id;
                        }
                        cnt++;
                    }
                }
            }
            
            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Note(s) to View");
                else
                    alert("Please select Note(s)");

                return false;
            }
            else {
                if(buttonType != 'Print')
                {
                    AciSelectedNotePopup(m_strAttIds,buttonType);
                    return false;
                }
                else
                    return true;
            }
        }

        function ConfirmRemove() {
            return confirm("Are you sure to remove?");
        }

        function checkLength() 
        {
            var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtACI_Notes_txtNote') 
            if (oObject.value.length < 50)
            {
                alert("Please enter minimum 50 Characters for Notes.");
                return false;
            }
            else
            {
                return true;            
            }              
        }

        function SelectDeselectACINoteHeader() {
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

            var rowCnt = document.getElementById('<%=gvACI_Notes.ClientID%>').rows.length - 1;

            var headerChkID = 'chkMultiSelectSonicNotes';

            if (cnt == rowCnt)
                document.getElementById(headerChkID).checked = true;
            else
                document.getElementById(headerChkID).checked = false;
        }

        function checkLengthSonic() 
        {
            document.getElementById('<%=csvSonicNoteGrid.ClientID%>').enabled = false;

            if (Page_ClientValidate("vsErrorGroup"))
            {
                var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtSonic_Notes_txtNote') 
                if (oObject.value.length < 50)
                {
                    alert("Please enter minimum 50 Characters for Notes.");
                    return false;
                }
                else
                {
                    return true;            
                }        
            }
            else
                return false;
        }

        function valSaveEvent() 
        {
            if (Page_ClientValidate("vsErrorGroup"))
            {
                if (Page_ClientValidate("vsErrorEvent_Camera"))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        function valSaveEventSonic() 
        {
            if (Page_ClientValidate("vsErrorGroup"))
            {
                if (Page_ClientValidate("vsErrorEvent_Camera_Sonic"))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        function AciNotePopup(NoteId, type) {            
            var winHeight = 500;
            var winWidth = 500;
            var EventId = <%=ViewState["PK_Event"]%>;            
        obj = window.open("Event_Note.aspx?nid=" + NoteId + "&id=" + '<%=ViewState["PK_Event"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
        obj.focus();
    }

    function AciSelectedNotePopup(NoteId, type) {  
        var winHeight = 450;
        var winWidth = 750;
        var EventId = <%=ViewState["PK_Event"]%>;            
            obj = window.open("Event_Note.aspx?viewIDs=" +  NoteId + "&id=" + '<%=ViewState["PK_Event"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',resizable=yes,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function setscroll() {
            document.documentElement.scrollLeft = document.getElementById('<%=hndScrollX.ClientID%>').value;
             document.documentElement.scrollTop = document.getElementById('<%=hndScrollY.ClientID%>').value;
         }

         function getscroll() {
             var x = document.documentElement.scrollLeft;
             var y = document.documentElement.scrollTop;
             document.getElementById('<%=hndScrollX.ClientID%>').value = x;
            document.getElementById('<%=hndScrollY.ClientID%>').value = y;
        }

        function OpenPopupContact(ContactType) {
            ShowDialog('<%=AppConfig.SiteURL %>/Event/PopupContact.aspx?ContactType=' + ContactType, PopupWidth_Contact, PopupHeight_Contact);
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 8; i++) {
                //if(i==4)i++;
                if(i==5)i++;
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
        }



        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 5) {
                return ValSave();
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                //ShowPanel(ActiveTabIndex);
                return false;
            }
        }

        function onPreviousStep() {
            if (ActiveTabIndex == 1) {
                return true;
            }
            else {
                ActiveTabIndex = ActiveTabIndex - 1;
                document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
                // ShowPanel(ActiveTabIndex);
                return false;
            }
        }


        function ValSave() {
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                if (Page_ClientValidate("vsErrorGroup"))
                    return true;
                else
                    return false;
            }
        }

        function ShowPanel(index) {
            ReportedEventEnableDisable();
            var Is_Sonic_Event = '<%=Is_Sonic_Event%>';
            if (Is_Sonic_Event != null) {
                if (Is_Sonic_Event == "True" && index == 1) {
                    index = 2;
                }
            }

            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                for (i = 1; i <= 4; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                }
                document.getElementById('<%=pnlAttachment.ClientID%>').style.display = (index == 5) ? "block" : "none";
                document.getElementById('<%=pnl6.ClientID%>').style.display = (index == 6) ? "block" : "none";
                document.getElementById('<%=pnl7.ClientID%>').style.display = (index == 7) ? "block" : "none";
                document.getElementById('<%=pnl8.ClientID%>').style.display = (index == 8) ? "block" : "none";
            }
            //			if (index == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
            //			else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "block";
            ShowHideVideoRequest();
        }



        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('ctl00_ContentPlaceHolder1_pnl' + 1 +'view').style.display = "block";
        }

        function SetFocusOnFirstControl(index) {
            document.getElementById('<%=ddlLocation.ClientID %>').focus();

        }

        function YearValidate(obj, args) {
            if (trim(args.Value) != '') {
                var y = args.Value;
                if ((y.length < 4 && y.length > 0) || !IsNumericNoAlert(y) || y >= 9999 || y <= 1753) {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
            return args.IsValid;
        }

        function ValidateTime(obj, args) {
            //var RegularExpression = new RegExp("(([0-1]?[0-9])|([2][0-2])):([0-5]?[0-9])(:([0-5]?[0-9]))?$");
            var t = /^((1[012])|(0[1-9])):([0-5][0-9])?$/
            var strTime;
            strTime = args.value;
            if (t.test(strTime)) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return args.IsValid;
        }

        function CheckBeforeSave(id) {
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                var bValid = false;
                if (id == 'btnSave')
                {
                    disableValidationvideo();
                }
                else
                {
                    ShowHideVideoRequest();
                }
                if (Page_ClientValidate("vsErrorGroup")) {
                    bValid = true;

                }
                if (bValid)
                    CallSave(id);
            }
        }



        function CallSave(id) {
            
            if (id == 'btnSend_Notification')
                __doPostBack('ctl00$ContentPlaceHolder1$btnSend_Notification', '');
            else
                __doPostBack('ctl00$ContentPlaceHolder1$btnSave', '');
        }


        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 20;
            }
            var winWidth = window.screen.availWidth - 200;
            obj = window.open("AuditPopup_Event_New.aspx?id=" + '<%=ViewState["PK_Event"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function SetClosedDate() {
            var rdoStatus = document.getElementById('<%=rdoStatus.ClientID %>');

            for (var i = 0; i < rdoStatus.rows.length; ++i) {

                if (rdoStatus.rows[i].cells[1].firstChild.checked) {
                    var date = new Date();

                    var yyyy = date.getFullYear().toString();
                    var mm = (date.getMonth() + 1).toString();
                    var dd = date.getDate().toString();

                    var mmChars = mm.split('');
                    var ddChars = dd.split('');

                    dateString = (mmChars[1] ? mm : "0" + mmChars[0]) + '/' + (ddChars[1] ? dd : "0" + ddChars[0]) + '/' + yyyy;
                    document.getElementById('<%=txtDate_Closed.ClientID%>').value = dateString;
                }
            }
        }

        function ReportedEventEnableDisable() {
            var Is_Sonic_Event = '<%=Is_Sonic_Event%>';
            if (Is_Sonic_Event != null) {
                if (Is_Sonic_Event == "True") {
                    document.getElementById("<%=trACIReportedEvent.ClientID%>").style.display = "none";
                    document.getElementById("<%=trSonicReportedEvent.ClientID%>").style.display = "";
                    var objvalidator = document.getElementById("<%=csvrptEventType.ClientID%>");
                    objvalidator.enabled = false;
                    var objvalidator = document.getElementById("<%=csvrptEventTypeSonic.ClientID%>");
                    objvalidator.enabled = true;
                }
                else {
                    document.getElementById("<%=trACIReportedEvent.ClientID%>").style.display = "";
                    document.getElementById("<%=trSonicReportedEvent.ClientID%>").style.display = "none";
                    var objvalidator = document.getElementById("<%=csvrptEventType.ClientID%>");
                    objvalidator.enabled = true;
                    var objvalidator = document.getElementById("<%=csvrptEventTypeSonic.ClientID%>");
                    objvalidator.enabled = false;
                }
            }
        }

        function OpenFRNumber(FRtype) {
            GB_showCenter('FR Number', '<%=AppConfig.SiteURL%>Event/PopupFirstReport.aspx?ftype='+FRtype, 500, 650, '');
            return false;
        }

        function setAgencyNameSonic()
        {
            var agencyname =  document.getElementById("<%=txtAgency_name.ClientID%>").value;
            var agencynameSonic = document.getElementById("<%=txtAgency_name_Sonic.ClientID%>");
            agencynameSonic.value = agencyname;
        }
        function setOfficerNameSonic()
        {
            var Officername =  document.getElementById("<%=txtOfficer_Name.ClientID%>").value;
            var OfficernameSonic = document.getElementById("<%=txtOfficer_Name_Sonic.ClientID%>");
            OfficernameSonic.value = Officername;
        }
              
        function setPhoneSonic()
        {
            var PhoneNumber =  document.getElementById("<%=txtOfficer_Phone.ClientID%>").value;
            var PhoneNumberSonic = document.getElementById("<%=txtOfficer_Phone_Sonic.ClientID%>");
            PhoneNumberSonic.value = PhoneNumber;
        }

        function setPoliceReportSonic()
        {
            var PoliceReport =  document.getElementById("<%=txtPolice_Report_Number.ClientID%>").value;
            var PoliceReportSonic = document.getElementById("<%=txtPolice_Report_Number_Sonic.ClientID%>");
            PoliceReportSonic.value = PoliceReport;
        }

        function setIncidentReportSonic()
        {
            //alert('98647');
        }

        function setPolicecalledSonic()
        {
            var rdopolice = document.getElementById("<%=rdoPolice_Called.ClientID%>");
                 var rdo = document.getElementById(rdopolice.id + "_0");

                 var rdopoliceSonic = document.getElementById("<%=rdoPolice_Called_Sonic.ClientID%>");
            var rdoSonicYes = document.getElementById(rdopoliceSonic.id + "_0");
            var rdoSonicNo = document.getElementById(rdopoliceSonic.id + "_1");

            if (rdo.checked)
            {
                rdoSonicYes.checked = true;
            }
            else
                rdoSonicNo.checked = true;
            
        }

        function ValidateEventTypeSonic(sender, args) {
            var gridView = document.getElementById("ctl00_ContentPlaceHolder1_trrptEventTypeSonic");
            var checkBoxes = gridView.getElementsByTagName("input");
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function ValidateEventType(sender, args) {
            var gridView = document.getElementById("ctl00_ContentPlaceHolder1_pnl1");
            var checkBoxes = gridView.getElementsByTagName("input");
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function ConfirmDelete() {
            var currentDate = "<%=DateTime.Now %>";
            var dateOfEvent =document.getElementById("<%=txtEvent_Start_Date.ClientID%>").value;

            var timeOfEvent =document.getElementById("<%=txtEvent_End_Time.ClientID%>").value;

            if(!dateOfEvent || 0 === dateOfEvent.length)
            {
                alert("Please enter Date of Event.");
                return false;
            }

            if(!timeOfEvent || 0 === timeOfEvent.length)
            {
                alert("Please enter Event end time.");
                return false;
            }

            var dateParts = dateOfEvent.split('/');
            var timeParts = timeOfEvent.split(':');

            var date = new Date(dateParts[2], parseInt(dateParts[0], 10) - 1, dateParts[1], timeParts[0], timeParts[1]);
            dateTimeParts = currentDate.split(' ');
            timeParts = dateTimeParts[1].split(':');
            dateParts = dateTimeParts[0].split('/');
            var todaydate = new Date(dateParts[2], parseInt(dateParts[0], 10) - 1, dateParts[1], timeParts[0], timeParts[1]);
            var hours = Math.abs(todaydate - date) / 36e5;
            
            if(hours > 24){
                alert("24 hour already elapsed so you can not make this event non-Actionable.");
                return false;
            }
            else{
                if (confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?")) {
                    document.getElementById("ctl00_ContentPlaceHolder1_btnhdnNonactionable").click();
                    return true;
                }
                else return false;
            }
        }

        function ShowHideVideoRequest() {
           
            var Is_Sonic_Event = '<%=ViewState["Is_Sonic_Event"]%>';
            if (Is_Sonic_Event == 'False')
            {
                var rdorequest = document.getElementById("ctl00_ContentPlaceHolder1_rblVideoRequestedByACI");
                var rdoSonicYes = document.getElementById(rdorequest.id + "_0");
                var trVideoRequest = document.getElementById("ctl00_ContentPlaceHolder1_trVideoRequest");

                var rfvddllocation = document.getElementById("<%=rfvddlLocation_Video.ClientID%>");
                var rfvddlFK_LU_Type_of_Activity_Video = document.getElementById("<%=rfvddlFK_LU_Type_of_Activity_Video.ClientID%>");
                var rfvtxtDate_Of_Event_Video = document.getElementById("<%=rfvtxtDate_Of_Event_Video.ClientID%>");
                var rfvtxtDate_Of_Request_Video = document.getElementById("<%=rfvtxtDate_Of_Request_Video.ClientID%>");
                var revtxtFull_Name_Video = document.getElementById("<%=revtxtFull_Name_Video.ClientID%>");
                <%--var revtxtWork_Phone_Video = document.getElementById("<%=revtxtWork_Phone_Video.ClientID%>");--%>
                <%--var revtxtLocation_Video = document.getElementById("<%=revtxtLocation_Video.ClientID%>");--%>
                <%--var revtxtAlternate_Phone_Video = document.getElementById("<%=revtxtAlternate_Phone_Video.ClientID%>");--%>
                var rfvReason_Request_Video_rfvNotes =  document.getElementById("ctl00_ContentPlaceHolder1_txtReason_Request_Video_rfvNotes");

                if (rdoSonicYes.checked)
                {
                    trVideoRequest.style["display"] = "";
                    rfvddllocation.enabled = true;
                    rfvddlFK_LU_Type_of_Activity_Video.enabled = true;
                    rfvtxtDate_Of_Event_Video.enabled = true;
                    rfvtxtDate_Of_Request_Video.enabled = true;
                    revtxtFull_Name_Video.enabled = true; 
                    //revtxtWork_Phone_Video.enabled = true; 
                    //revtxtLocation_Video.enabled = true; 
                    //revtxtAlternate_Phone_Video.enabled = true; 
                    rfvReason_Request_Video_rfvNotes.enabled = true;
               
                    setVideoRequestData();
                }
                else
                {
                    trVideoRequest.style["display"] = "none";
                    rfvddllocation.enabled = false;
                    rfvddlFK_LU_Type_of_Activity_Video.enabled = false;
                    rfvtxtDate_Of_Event_Video.enabled = false;
                    rfvtxtDate_Of_Request_Video.enabled = false;
                    revtxtFull_Name_Video.enabled = false; 
                    //revtxtWork_Phone_Video.enabled = false; 
                    //revtxtLocation_Video.enabled = false; 
                    //revtxtAlternate_Phone_Video.enabled = false; 
                    rfvReason_Request_Video_rfvNotes.enabled = false;
                }
                setUrgentNeed();
            }
            
        }

        function setUrgentNeed()
        {
            var rdoUrgent = document.getElementById("ctl00_ContentPlaceHolder1_rdoUrgent_Need_Video");
            var rdoUrgentYes = document.getElementById(rdoUrgent.id + "_0");
            var Is_Sonic_Event = '<%=ViewState["Is_Sonic_Event"]%>';
            var rdorequest;

            if(Is_Sonic_Event == 'True')
                rdorequest = document.getElementById("ctl00_ContentPlaceHolder1_rblVideoRequestedBySonic");
            else 
                rdorequest = document.getElementById("ctl00_ContentPlaceHolder1_rblVideoRequestedByACI");

            var rdoSonicYes = document.getElementById(rdorequest.id + "_0");

            var revtxtCamera_Name_Video = document.getElementById("<%=revtxtCamera_Name_Video.ClientID%>");
            var revtxtEvent_Start_Time_Video = document.getElementById("<%=revtxtEvent_Start_Time_Video.ClientID%>");
            var revtxtEvent_End_Time_Video = document.getElementById("<%=revtxtEvent_End_Time_Video.ClientID%>");

            var spancameraname = document.getElementById("<%=spancameraname.ClientID%>");
            var spanstarttime = document.getElementById("<%=spanstarttime.ClientID%>");
            var spanendtime = document.getElementById("<%=spanendtime.ClientID%>");

            if (rdoUrgentYes.checked && rdoSonicYes.checked)
            {
                revtxtCamera_Name_Video.enabled = true;
                revtxtEvent_Start_Time_Video.enabled = true;
                revtxtEvent_End_Time_Video.enabled = true;

                spancameraname.style.display = "";
                spanstarttime.style.display = "";
                spanendtime.style.display = "";
            }
            else
            {
                revtxtCamera_Name_Video.enabled = false;
                revtxtEvent_Start_Time_Video.enabled = false;
                revtxtEvent_End_Time_Video.enabled = false;

                spancameraname.style.display = "none";
                spanstarttime.style.display = "none";
                spanendtime.style.display = "none";
            }

        }

        function setVideoRequestData()
        {
            var PK_Event_Video_Tracking_Request = '<%=ViewState["PK_Event_Video_Tracking_Request"]%>';
            if (PK_Event_Video_Tracking_Request <= 0) 
            {
                var Location_Sonic =  document.getElementById("<%=ddlLocation_Sonic.ClientID%>").value;
                var DateofEvent_Sonic = document.getElementById("<%=txtEvent_Start_Date_Sonic.ClientID%>").value;
                var Event_Start_Time_Sonic = document.getElementById("<%=txtEvent_Start_Time_Sonic.ClientID%>").value;
                var Event_End_Time_Sonic = document.getElementById("<%=txtEvent_End_Time_Sonic.ClientID%>").value;

                var Location = document.getElementById("<%=ddlLocation.ClientID%>").value;
                var DateofEvent = document.getElementById("<%=txtEvent_Start_Date.ClientID%>").value;
                var Event_Start_Time = document.getElementById("<%=txtEvent_Start_Time.ClientID%>").value;
                var Event_End_Time = document.getElementById("<%=txtEvent_End_Time.ClientID%>").value;

                var ddlLocation_Video = document.getElementById("<%=ddlLocation_Video.ClientID%>");
                var txtDate_Of_Event_Video = document.getElementById("<%=txtDate_Of_Event_Video.ClientID%>");
                var txtEvent_Start_Time_Video = document.getElementById("<%=txtEvent_Start_Time_Video.ClientID%>");
                var txtEvent_End_Time_Video = document.getElementById("<%=txtEvent_End_Time_Video.ClientID%>");

                var Is_Sonic_Event = '<%=Is_Sonic_Event%>';
                if (Is_Sonic_Event != null && Is_Sonic_Event == "True")
                {
                    ddlLocation_Video.value = Location_Sonic;
                    txtDate_Of_Event_Video.value = DateofEvent_Sonic;
                    txtEvent_Start_Time_Video.value = Event_Start_Time_Sonic;
                    txtEvent_End_Time_Video.value = Event_End_Time_Sonic;
                }
                else
                {
                    ddlLocation_Video.value = Location;
                    txtDate_Of_Event_Video.value = DateofEvent;
                    txtEvent_Start_Time_Video.value = Event_Start_Time;
                    txtEvent_End_Time_Video.value = Event_End_Time;
                }
            }
        }

        function disableValidationvideo()
        {
            var rfvddllocation = document.getElementById("<%=rfvddlLocation_Video.ClientID%>");
            var rfvddlFK_LU_Type_of_Activity_Video = document.getElementById("<%=rfvddlFK_LU_Type_of_Activity_Video.ClientID%>");
            var rfvtxtDate_Of_Event_Video = document.getElementById("<%=rfvtxtDate_Of_Event_Video.ClientID%>");
            var rfvtxtDate_Of_Request_Video = document.getElementById("<%=rfvtxtDate_Of_Request_Video.ClientID%>");
            var revtxtFull_Name_Video = document.getElementById("<%=revtxtFull_Name_Video.ClientID%>");
            <%--var revtxtWork_Phone_Video = document.getElementById("<%=revtxtWork_Phone_Video.ClientID%>");--%>
            <%--var revtxtLocation_Video = document.getElementById("<%=revtxtLocation_Video.ClientID%>");--%>
            <%--var revtxtAlternate_Phone_Video = document.getElementById("<%=revtxtAlternate_Phone_Video.ClientID%>");--%>
            var rfvReason_Request_Video_rfvNotes =  document.getElementById("ctl00_ContentPlaceHolder1_txtReason_Request_Video_rfvNotes");

            var revtxtCamera_Name_Video = document.getElementById("<%=revtxtCamera_Name_Video.ClientID%>");
            var revtxtEvent_Start_Time_Video = document.getElementById("<%=revtxtEvent_Start_Time_Video.ClientID%>");
            var revtxtEvent_End_Time_Video = document.getElementById("<%=revtxtEvent_End_Time_Video.ClientID%>");

            rfvddllocation.enabled = false;
            rfvddlFK_LU_Type_of_Activity_Video.enabled = false;
            rfvtxtDate_Of_Event_Video.enabled = false;
            rfvtxtDate_Of_Request_Video.enabled = false;
            revtxtFull_Name_Video.enabled = false; 
            //revtxtWork_Phone_Video.enabled = false; 
            //revtxtLocation_Video.enabled = false; 
            //revtxtAlternate_Phone_Video.enabled = false; 
            rfvReason_Request_Video_rfvNotes.enabled = false;

            revtxtCamera_Name_Video.enabled = false;
            revtxtEvent_Start_Time_Video.enabled = false;
            revtxtEvent_End_Time_Video.enabled = false;
        }

      function VideoNotePopup(NoteId, type) {  
            var winHeight = 500;
            var winWidth = 500;
            var VideoId = '<%=ViewState["PK_Event_Video_Tracking_Request"]%>';            
            obj = window.open("Video_Request_Note.aspx?nid=" + NoteId + "&id=" + '<%=ViewState["PK_Event_Video_Tracking_Request"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
        }

        function VideoSelectedNotePopup(NoteId, type) {  
            var winHeight = 450;
            var winWidth = 750;
            var VideoId = '<%=ViewState["PK_Event_Video_Tracking_Request"]%>';            
            obj = window.open("Video_Request_Note.aspx?viewIDs=" +  NoteId + "&id=" + '<%=ViewState["PK_Event_Video_Tracking_Request"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',resizable=yes,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

    function CheckSelectedVideoNotes(buttonType) {
        var gv = document.getElementById('<%=gvVideo_Notes.ClientID%>');
            var ctrls = gv.getElementsByTagName('input');
            var i;
            var cnt = 0;
            var m_strAttIds = '';
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectVideoNotes") > 0) {
                    if (ctrls[i].checked) {
                        var ctrlId = ctrls[i].id;
                        ctrlId = ctrlId.substring(ctrlId.lastIndexOf("_") - 2);
                        var hdnpk = ctrlId.replace("chkSelectVideoNotes", "hdnPK_Video_Request_Notes");
                        //index = Number(index) - 2;
                        var id = document.getElementById('ctl00_ContentPlaceHolder1_gvVideo_Notes_ctl' + hdnpk).value;
                        if (m_strAttIds == "")
                            m_strAttIds = id;
                        else {
                            m_strAttIds = m_strAttIds + "," + id;
                        }
                        cnt++;
                    }
                }
            }
            
            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Note(s) to View");
                else
                    alert("Please select Note(s)");

                return false;
            }
            else {
                if(buttonType != 'Print')//here sonic both view time condition is right
                {
                    VideoSelectedNotePopup(m_strAttIds,buttonType);
                    return false;
                }
                else
                    return true;
            }
        }

        //function checkLength() {
        //    var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtVideo_Notes_txtNote')
        //    if (oObject.value.length < 50) {
        //        alert("Please enter minimum 50 Characters for Notes.");
        //        return false;
        //    }
        //    else {
        //        return true;
        //    }
        //}

        function CheckVideo() {
            <%--var values = '<%=ViewState["PK_Event_Video_Tracking_Request"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Video Request First');
                return false;
            }
            else {
                return true;
            }--%>
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                var bValid = false;
                //ShowHideVideoRequest();
                if (Page_ClientValidate("vsErrorGroup")) {
                    bValid = true;
                }
                return bValid;
            }
        }

        function SelectDeselectAllVideoNotes(bChecked) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectVideoNotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function SelectDeselectVideoNoteHeader() {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectVideoNotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            var rowCnt = document.getElementById('<%=gvVideo_Notes.ClientID%>').rows.length - 1;
            var headerChkID = 'chkMultiSelectVideoNotes';

            if (cnt == rowCnt)
                document.getElementById(headerChkID).checked = true;
            else
                document.getElementById(headerChkID).checked = false;
        }

        function Sonicnotecount(obj, args) {
            var gv = document.getElementById('<%=gvSonic_Notes.ClientID%>');
                    if (gv.rows.length <= 1) {
                        args.IsValid = false;
                    }
                    else {
                        args.IsValid = true;
                    }
                    return args.IsValid;

        }

        function CheckSonicNote() {
            document.getElementById('<%=csvSonicNoteGrid.ClientID%>').enabled = false;
                if (Page_ClientValidate('vsErrorGroup')) {
                    return true;
                }
                else
                    return false;
        }

        function showbutton()
        {
            var savebutton =  document.getElementById("<%=btnSend_Notification.ClientID%>");
                    var status =  document.getElementById("<%=drpStatus.ClientID%>");
                    var selectedText = status.options[status.selectedIndex].text;

                    if(selectedText == 'Closed')
                        savebutton.style.display = "";
                    else
                        savebutton.style.display = "none";

        }


    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorCamera" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorEvent_Camera" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorOtherVehicle" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorCameraSonic" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorEvent_Camera_Sonic" BorderColor="DimGray" BorderWidth="1"
            HeaderText="Verify the following fields:" ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:IncidentTab ID="ucIncident" runat="server" />
                <%--<uc:ClaimTab ID="uclaimincidenttab" runat="server" Visible="false" />--%>
            </td>
        </tr>
        <tr>
            <td align="left">
                <%--<uc:IncidentInfo ID="ucIncidentInfo" runat="server" Visible="false" />--%>
                <uc:EventInfo ID="ucEventInfo" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">Event
                            </td>
                            <td align="right">
                                <asp:Label ID="lblLastModifiedDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu" style="padding-left: 2px;">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr runat="server" id="trACIReportedEvent">
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">ACI Reported
                                            Event</span>
                                    </td>
                                </tr>
                                <tr runat="server" id="trSonicReportedEvent">
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Sonic Reported
                                            Event</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">
                                            <asp:Label runat="server" ID="lblMenu2"></asp:Label>&nbsp;<span id="spanmenu2" runat="server" style="color: Red;">*</span>
                                        </span><%--Acadian Investigations--%>
                                    </td>
                                </tr>
                                <tr runat="server" id="trVideoRequest">
                                    <td align="left" width="100%">
                                        <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Video Request</span>
                                        <span id="MenuAsterisk2" runat="server" style="color: Red;">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Cause Investigations</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Insurance Type Claim</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Abstracts & Custom Letters</span>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="left" width="100%">
                                        <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Attachments</span>
                                    </td>
                                </tr>--%>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <asp:HiddenField ID="hndScrollX" runat="server" />
                                        <asp:HiddenField ID="hndScrollY" runat="server" />
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Event Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="100%" valign="top" colspan="6">
                                                            <b>Make Non-Actionable :</b>&nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkNonActionable" runat="server" OnClick="return ConfirmDelete();" />
                                                            <asp:Button ID="btnhdnNonactionable" runat="server" OnClick="btnhdnNonactionable_Click" Style="display: none;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="19%" valign="top">Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="27%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">ACI Event ID
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtACI_EventID" runat="server" MaxLength="30" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">Event Level
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlEvent_Level" runat="server" Width="175px"></asp:DropDownList>
                                                        </td>
                                                        <td colspan="3">&nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><b>Actionable Event Type</b></u>

                                                        </td>
                                                        <td colspan="3">
                                                            <u><b>Description of Event</b></u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:Repeater ID="rptEventType" runat="server" OnItemDataBound="rptEventType_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="left" valign="top" colspan="2">
                                                                                <asp:CheckBox ID="chkEventType" runat="server" />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Label ID="lblEventType" Text='<%#Eval("Fld_Desc") %>' runat="server"></asp:Label>
                                                                                <asp:Label ID="lblPK_LU_Event_Type" Text='<%#Eval("PK_LU_Event_Type") %>' runat="server"
                                                                                    Style="display: none;"></asp:Label>
                                                                            </td>
                                                                            <%--<td width="18%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtEventDesciption" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td width="4%" align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="28%" align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <asp:CustomValidator ID="csvrptEventType" runat="server" ErrorMessage="[ACI Reported Event] / Please Select Actionable Event Type"
                                                                ClientValidationFunction="ValidateEventType" ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
                                                        </td>
                                                        <td colspan="3" valign="top">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <uc:ctrlMultiLineTextBox ID="txtEventDesciption" runat="server" Width="450" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" id="trEvent_Building" style="display: none;">
                                                                    <td colspan="3">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Building Grid
                                                                                </td>
                                                                                <td align="center" valign="top" colspan="2">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" width="36%" valign="top">Building Description
                                                                                </td>
                                                                                <td align="center" width="8%" valign="top">:
                                                                                </td>
                                                                                <td align="left" width="56%" valign="top">
                                                                                    <asp:TextBox ID="txtBuilding_Description" runat="server" MaxLength="500" Width="170px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Restricted
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:CheckBox ID="chkRestricted" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Exterior/Interior
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:RadioButtonList ID="rdoExterior_Interior" runat="server">
                                                                                        <asp:ListItem Text="Exterior" Value="Exterior"></asp:ListItem>
                                                                                        <asp:ListItem Text="Interior" Value="Interior"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left"></td>
                                                                                <td align="center"></td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:Button ID="btnEvent_BuildingAdd" OnClick="btnEvent_BuildingAdd_Click"
                                                                                        runat="server" OnClientClick="javascript:return valSaveEventSonic();"
                                                                                        Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:Button ID="btnEvent_BuildingCancel" OnClick="btnEvent_BuildingCancel_Click"
                                                                                        runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        Building Grid
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" id="trEvent_BuildingGrid">
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <asp:GridView ID="gvEvent_Building" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvEvent_Building_RowCommand"
                                                                            OnPageIndexChanging="gvEvent_Building_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="1%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hdnPK_Event_Building" runat="server" Value='<%# Eval("PK_Event_Building") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Building Description">
                                                                                    <ItemStyle Width="49%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("Building_Description")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Exterior/Interior">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("Exterior_Interior")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Restricted">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("Restricted")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="30%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                            CommandArgument='<%#Eval("PK_Event_Building") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                                        </asp:LinkButton>
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Event_Building") %>'
                                                                                            CommandName="RemoveEventBuilding" OnClientClick="return confirm('Are you sure to remove Event Building record?');"
                                                                                            CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                            <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 5px;">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddEvent_BuildingNew" OnClick="lnkAddEvent_BuildingNew_Click"
                                                                            runat="server" Text="Add New" OnClientClick="return CheckEvent();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                        <asp:LinkButton Style="display: none" ID="lnkEvent_BuildingCancel" runat="server"
                                                                            Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                    
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="txtEvent_Start_Date" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEvent_Start_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgEvent_Start_Date" />
                                                            <asp:RegularExpressionValidator ID="revReport_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[ACI Reported Event]/Date of Event is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEvent_Start_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtEventReportDate" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtEvent_Start_Date" Display="None" Text="*" ErrorMessage="[ACI Reported Event]/Date of Event should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Start Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_Start_Time" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Start_Time"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEvent_Start_Time"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[ACI Reported Event]/Invalid Event Start Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Event End Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_End_Time" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_End_Time"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEvent_End_Time"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[ACI Reported Event]/Invalid Event End Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td colspan="6">
                                                            <asp:GridView ID="gvBuildingEditACI" runat="server" EmptyDataText="No Building Records Found"
                                                                AutoGenerateColumns="false" Width="100%" OnRowDataBound="gvBuildingEditACI_RowDataBound"
                                                                OnRowCommand="gvBuildingEditACI_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkViewDetail" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'
                                                                                CommandName="ViewBuildingDetail" CommandArgument='<%# Eval("FK_LU_Location_ID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Building Number">
                                                                        <ItemStyle Width="20%" />
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
                                                                        <ItemStyle Width="40%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOccupancy" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEvent_Link_Building" TeID="lnkRemove" OnClientClick="return ConfirmRemove();" CausesValidation="false"
                                                                                runat="server" CommandName="RemoveEventBuilding" CommandArgument='<%#Eval("PK_Event_Link_Building")%>'
                                                                                Text="Remove" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_Camera" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Camera Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Camera Name
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Name" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Camera Number
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Number" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Event Time From
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_From" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtClaim_Time" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_From"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtClaim_Time" runat="server" ControlToValidate="txtEvent_Time_From"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[ACI Reported Event]/Invalid Event Time From" Display="none" ValidationGroup="vsErrorEvent_Camera"
                                                                            SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Event Time To
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_To" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtEvent_Time_To" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_To"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtEvent_Time_To" runat="server" ControlToValidate="txtEvent_Time_To"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[ACI Reported Event]/Invalid Event Time To" Display="none" ValidationGroup="vsErrorEvent_Camera"
                                                                            SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnEvent_CameraAdd" OnClick="btnEvent_CameraAdd_Click" runat="server"
                                                                            ValidationGroup="vsErrorEvent_Camera" OnClientClick="javascript:return valSaveEvent();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnEvent_CameraCancel" OnClick="btnEvent_CameraCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_CameraGrid">
                                                        <td align="left" valign="top">Camera Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvEvent_Camera" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvEvent_Camera_RowCommand"
                                                                OnPageIndexChanging="gvEvent_Camera_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="1%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_Event_Camera" runat="server" Value='<%# Eval("PK_Event_Camera") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Name">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Number")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time From">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_From")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time To">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_To")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Event_Camera") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Event_Camera") %>'
                                                                                CommandName="RemoveEventCamera" OnClientClick="return confirm('Are you sure to remove Event Camera record?');"
                                                                                CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-bottom: 5px;">
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddEvent_CameraNew" OnClick="lnkAddEvent_CameraNew_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: none" ID="lnkEvent_CameraCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Acadian Investigator Name
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtInvestigator_Name" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Acadian Investigator Email Address
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtInvestigator_Email" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegExpEmailID" runat="server" ControlToValidate="txtInvestigator_Email"
                                                                            Display="None" ErrorMessage="[ACI Reported Event] /Please Enter Valid Acadian Investigator Email Address"
                                                                            SetFocusOnError="True" ValidationGroup="vsErrorGroup" ToolTip="Please Enter Valid Acadian Investigator Email Address"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Acadian Investigator Phone #
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtInvestigator_Phone" runat="server" MaxLength="12" Width="170px"
                                                                            SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtInvestigator_Phone" ControlToValidate="txtInvestigator_Phone"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[ACI Reported Event] / Please Enter Acadian Investigator Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>--%>
                                                    <tr runat="server" id="trImgEvent_Image">
                                                        <td align="left" valign="top">Event Image
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Image ID="ImgEvent_Image" runat="server" Height="400" Width="500" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    <asp:Label ID="lblMenu2Header" runat="server"></asp:Label>
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                   <tr runat="server" id="trVideoRequestByACI">
                                                        <td align="left" width="18%" valign="top">Do you want to Request Video?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rblVideoRequestedByACI" runat="server" onClick="return ShowHideVideoRequest();">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none">
                                                        <td align="left" width="18%" valign="top">Police Called?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoPolice_Called" runat="server" onclick=" return setPolicecalledSonic();">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>

                                                    
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td width="100%" align="left" colspan="6">
                                                            <uc:ctrlEventNotes ID="ctrlEventNotes" runat="server" IsAddVisible="true" />
                                                        </td>
                                                    </tr>--%>
                                                    
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px"></td>
                                                    </tr>
                                                    <tr id="trHeadersonicNotes" runat ="server">
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                            <div class="bandHeaderRow">
                                                                Notes
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSonicNotes" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td align="left" valign="top" width="19%">Date
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtACI_Notes_Date" runat="server" SkinID="txtDate" MaxLength="12" autocomplete="off"
                                                                            onpaste="return false"></asp:TextBox>
                                                                        <img alt="Report Date" onclick="return showCalendar('<%= txtACI_Notes_Date.ClientID %>', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                            Display="none" ErrorMessage="[ACI Notes Grid]/Date Sonic is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtDate_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCurrentDate"
                                                                            ControlToValidate="txtACI_Notes_Date" Display="None" Text="*" ErrorMessage="[ACI Notes Grid]/Date should not be greater than current date."
                                                                            Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                                    </td>--%>
                                                                    <td align="left" valign="top" width="19%">Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSonic_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnSonicNotesAdd" OnClick="btnSonicNotesAdd_Click" runat="server"
                                                                            ValidationGroup="vsErrorGroup" OnClientClick="javascript:return checkLengthSonic();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnSonicNotesCancel" OnClick="btnSonicNotesCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSonicNotesGrid">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="17%">Notes Grid
                                                                    </td>
                                                                    <td align="center" valign="top" width="5%">:
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" OnGetPage="GetSonicPage" RecordPerPage="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <div runat="server" id="dvSonicNOtes" style="width: 99%; overflow-y: scroll; border: solid 1px #000000;">
                                                                            <asp:GridView ID="gvSonic_Notes" runat="server" Width="97%" AutoGenerateColumns="false" AllowSorting="true"
                                                                                EnableViewState="true" AllowPaging="false" OnRowCommand="gvSonic_Notes_RowCommand" OnSorting="gvSonic_Notes_Sorting"
                                                                                OnPageIndexChanging="gvSonic_Notes_PageIndexChanging" Style="word-wrap: normal; word-break: break-all;">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                                        <HeaderTemplate>
                                                                                            <input type="checkbox" id="chkMultiSelectSonicACINotes" onclick="SelectDeselectAllACINotes(this.checked);" />Select
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkSelectSonicACINotes" runat="server" onclick="SelectDeselectSonicNoteHeader();" />
                                                                                            <input type="hidden" id="hdnPK_Sonic_Event_Notes" runat="server" value='<%#Eval("PK_Sonic_Event_Notes") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date" SortExpression="Note_Date">
                                                                                        <ItemStyle Width="10%" />
                                                                                        <ItemTemplate>
                                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="User">
                                                                                        <ItemStyle Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUpdated_By" runat="server" Text='<%# Eval("Updated_by_Name") %>' Style="word-wrap: normal; word-break: break-all;"
                                                                                                Width="70px" CssClass="TextClip"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Notes">
                                                                                        <ItemStyle Width="45%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' Style="word-wrap: normal; word-break: break-all;"
                                                                                                Width="310px" CssClass="TextClip"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                                CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                                            </asp:LinkButton>
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>'
                                                                                            CommandName="RemoveACINote" OnClientClick="return confirm('Are you sure to remove Sonic Note record?');"
                                                                                            CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                            <asp:CustomValidator ID="csvSonicNoteGrid" runat="Server" ErrorMessage="Please add at least one Note"
                                                                                    Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="Sonicnotecount"></asp:CustomValidator>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 5px;" colspan="6">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddSonicNotesNew" OnClick="lnkAddSonicNotesNew_Click"
                                                                            runat="server" Text="Add New" OnClientClick="return CheckSonicNote();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                          <asp:Button ID="btnSonicNoteView" runat="server" Text=" View" OnClientClick="return AciSelectedNotePopup('','SonicView');" />&nbsp;&nbsp;
                                                                                    <asp:Button ID="btnSonicPrint" runat="server" Text=" Print " OnClick="btnSonicPrint_Click"
                                                                                        OnClientClick="return CheckSelectedSonicNotes('Print');" />
                                                                        &nbsp;&nbsp;
                                                                                    <asp:Button ID="btnSonicSpecificNote" runat="server" CausesValidation="false" Text=" Show Specific Notes Only "
                                                                                        OnClientClick="javascript:return CheckSelectedSonicNotes('SONICSpecificNote');" />
                                                                        <asp:LinkButton Style="display: none" ID="lnkSonicNotesCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>

                                                    </tr>

                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <b>Images of Event : </b>
                                                        </td>
                                                        <td align="center" valign="top" colspan="5">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trInvest_Images">
                                                        <td colspan="6" align="center">
                                                            <div style="width: 95%; border: 3px solid;">
                                                                <asp:Repeater ID="rptInvest_Images" runat="server" OnItemDataBound="rptInvestImages_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="95%">
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <asp:Image ID="imgInvest_Images1" runat="server" ImageUrl='<%#Eval("InvestigationImgCol1") %>' BorderWidth="1px" BorderStyle="Solid" BorderColor="Black"
                                                                                        Height="80px" Width="350px" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td valign="top">
                                                                                    <asp:Image ID="imgInvest_Images2" runat="server" ImageUrl='<%#Eval("InvestigationImgCol2") %>' BorderWidth="1px" BorderStyle="Solid" BorderColor="Black"
                                                                                        Height="80px" Width="350px" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trStatus">
                                                        <td align="left" width="18%" valign="top">Status
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoStatus" runat="server" onclick="SetClosedDate();">
                                                                <asp:ListItem Text="Open" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Closed
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Closed" runat="server" SkinID="txtDate" />
                                                            <img alt="Date Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Closed', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgDate_Closed" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Closed" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[ACI Reported Event]/Date Closed is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Closed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDate_Closed" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtDate_Closed" Display="None" Text="*" ErrorMessage="[ACI Reported Event]/Date Closed should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Sonic Reported Event (SRE)
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation_Sonic" runat="server" Width="175px" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtEvent_Start_Date_Sonic" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEvent_Start_Date_Sonic', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgEvent_Start_Date_Sonic" />
                                                            <asp:RegularExpressionValidator ID="revtxtEvent_Start_Date_Sonic" runat="server"
                                                                ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Sonic Reported Event]/Date of Event is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEvent_Start_Date_Sonic" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtEvent_Start_Date_Sonic" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtEvent_Start_Date_Sonic" Display="None" Text="*" ErrorMessage="[Sonic Reported Event]/Date of Event should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">SRE#
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtEvent_Number_Sonic" runat="server" SkinID="txtDisabled" Width="170px" BackColor="LightGray"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Start Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_Start_Time_Sonic" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Start_Time_Sonic"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEvent_Start_Time_Sonic"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[Sonic Reported Event]/Invalid Event Start Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Event End Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_End_Time_Sonic" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_End_Time_Sonic"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEvent_End_Time_Sonic"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[Sonic Reported Event]/Invalid Event End Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Monitoring Hours
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoMonitoring_Hours_Sonic" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Source of Information
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <%--<uc:ctrlMultiLineTextBox ID="txtSource_Of_Information" runat="server" MaxLength="100" />--%>
                                                            <asp:TextBox ID="txtSource_Of_Information" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">Event Level
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="ddlEvent_Level_Sonic" runat="server" Width="175px" SkinID="dropGen"></asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                            <asp:Button ID="btnhdnReload" runat="server" OnClick="btnhdnReload_Click" Style="display: none;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:GridView ID="gvBuildingEdit" runat="server" EmptyDataText="No Building Records Found"
                                                                AutoGenerateColumns="false" Width="100%" OnRowDataBound="gvBuildingEdit_RowDataBound"
                                                                OnRowCommand="gvBuildingEdit_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkViewDetail" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="ViewBuildingDetail" CommandArgument='<%# Eval("FK_LU_Location_ID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Building Number">
                                                                        <ItemStyle Width="20%" />
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
                                                                        <ItemStyle Width="40%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOccupancy" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEvent_Link_Building" TeID="lnkRemove" OnClientClick="return ConfirmRemove();" CausesValidation="false"
                                                                                runat="server" CommandName="RemoveEventBuilding" CommandArgument='<%#Eval("PK_Event_Link_Building")%>'
                                                                                Text="Remove" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr id="trBuilding_Addlink" runat="server">
                                                        <td style="padding-bottom: 5px;">
                                                            <a id="A1" runat="server" href="#" onclick="OpenChooseBuilding(0,0);">--Add--</a>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_Camera_Sonic" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Camera Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Camera Name
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Name_Sonic" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Camera Number
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Number_Sonic" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Event Time From
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_From_Sonic" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtEvent_Time_From_Sonic" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_From_Sonic"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtEvent_Time_From_Sonic" runat="server" ControlToValidate="txtEvent_Time_From_Sonic"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[Sonic Reported Event]/Invalid Event Time From" Display="none"
                                                                            ValidationGroup="vsErrorEvent_Camera_Sonic" SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Event Time To
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_To_Sonic" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtEvent_Time_To_Sonic" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_To_Sonic"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtEvent_Time_To_Sonic" runat="server" ControlToValidate="txtEvent_Time_To_Sonic"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[Sonic Reported Event]/Invalid Event Time To" Display="none" ValidationGroup="vsErrorEvent_Camera_Sonic"
                                                                            SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnEvent_CameraAdd_Sonic" OnClick="btnEvent_CameraAdd_Sonic_Click"
                                                                            runat="server" ValidationGroup="vsErrorEvent_Camera_Sonic" OnClientClick="javascript:return valSaveEventSonic();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnEvent_CameraSonicCancel" OnClick="btnEvent_CameraSonicCancel_Click"
                                                                            runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_CameraGrid_Sonic">
                                                        <td align="left" valign="top">Camera Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvEvent_Camera_Sonic" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvEvent_Camera_Sonic_RowCommand"
                                                                OnPageIndexChanging="gvEvent_Camera_Sonic_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="1%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_Event_CameraSonic" runat="server" Value='<%# Eval("PK_Event_Camera") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Name">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Number")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time From">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_From")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time To">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_To")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Event_Camera") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Event_Camera") %>'
                                                                                CommandName="RemoveEventCamera" OnClientClick="return confirm('Are you sure to remove Event Camera record?');"
                                                                                CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-bottom: 5px;">
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddEvent_CameraNew_Sonic" OnClick="lnkAddEvent_CameraNew_Sonic_Click"
                                                                runat="server" Text="Add New" OnClientClick="return CheckEvent();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: none" ID="lnkEvent_CameraSonicCancel" runat="server"
                                                                Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><b>Actionable Event Type</b></u>
                                                        </td>
                                                        <td colspan="3">
                                                            <u><b>Description of Event</b></u>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trrptEventTypeSonic">
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:Repeater ID="rptEventTypeSonic" runat="server" OnItemDataBound="rptEventTypeSonic_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="left" valign="top" colspan="2">
                                                                                <asp:CheckBox ID="chkEventTypeSonic" runat="server" />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Label ID="lblEventTypeSonic" Text='<%#Eval("Fld_Desc") %>' runat="server"></asp:Label>
                                                                                <asp:Label ID="lblPK_LU_Event_TypeSonic" Text='<%#Eval("PK_LU_Event_Type") %>' runat="server"
                                                                                    Style="display: none;"></asp:Label>
                                                                            </td>
                                                                            <%--  <td width="18%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtEventDesciptionSonic" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td width="4%" align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="28%" align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <asp:CustomValidator ID="csvrptEventTypeSonic" runat="server" ErrorMessage="[Sonic Reported Event] / Please Select Actionable Event Type"
                                                                ClientValidationFunction="ValidateEventTypeSonic" ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
                                                        </td>
                                                        <td colspan="3" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtEventDesciptionSonic" runat="server" Width="450" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Police Called?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoPolice_Called_Sonic" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top" style="padding-left: 25px;">If Yes:
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">Agency Name
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAgency_name_Sonic" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">Phone #
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Phone_Sonic" runat="server" MaxLength="12" Width="170px"
                                                                            SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtOfficer_Phone_Sonic" ControlToValidate="txtOfficer_Phone_Sonic"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[Sonic Reported Event] / Please Enter Agency Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">Officer Name
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Name_Sonic" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">Police Report #
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPolice_Report_Number_Sonic" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">Badge #
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBadge_Number_Sonic" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Sonic Contact Information :
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">Name
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSonic_Contact_Name" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">Phone #
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSonic_Contact_Phone" runat="server" MaxLength="12" Width="170px"
                                                                            SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtSonic_Contact_Phone" ControlToValidate="txtSonic_Contact_Phone"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[Sonic Reported Event] / Please Enter Sonic Contact Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">Email Address
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSonic_Contact_Email" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revSonic_Contact_Email" runat="server" ControlToValidate="txtSonic_Contact_Email"
                                                                            Display="None" ErrorMessage="[Sonic Reported Event] /Please Enter Valid Sonic Contact Email Address"
                                                                            SetFocusOnError="True" ValidationGroup="vsErrorGroup" ToolTip="Please Enter Valid Sonic Contact Email Address"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Status
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoStatus_Sonic" runat="server" onclick="SetACIStatus();">
                                                                <asp:ListItem Text="Open" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                            </asp:RadioButtonList>
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
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Insurance Type Claim
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Claim Type - Select :
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Auto Liability - FROI #
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtFK_AL_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_AL_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('AL');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_AL_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">DPD - FROI #
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtFK_DPD_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_DPD_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('DPD');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_DPD_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Premises Liability - FROI #
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtFK_PL_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_PL_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('PL');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_PL_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Property Damage - FROI #
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtFK_Property_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_Property_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('Property');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_Property_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What is the Event's root cause?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtEvent_Root_Cause" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">How can the event be prevented from happening again?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtHow_Event_Prevented" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">$<asp:TextBox ID="txtFinancial_Loss" runat="server" Width="160px" onpaste="return false"
                                                            onkeypress="return FormatNumber(event,this.id,11,false);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Video Request
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                    <tr id="trsonicVideoRequest" runat="server">
                                                        <td align="left" width="18%" valign="top">Do you want to Request Video?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rblVideoRequestedBySonic" runat="server" >
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Location&nbsp;<span id="Span2" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation_Video" runat="server" Width="185px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvddlLocation_Video" runat="server" ControlToValidate="ddlLocation_Video"
                                                                InitialValue="0" ErrorMessage="[Video Request] /  Please Select Location" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Type Of Activity&nbsp;<span id="Span3" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlFK_LU_Type_of_Activity_Video" runat="server" Width="185px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvddlFK_LU_Type_of_Activity_Video" runat="server" ControlToValidate="ddlFK_LU_Type_of_Activity_Video"
                                                                InitialValue="0" ErrorMessage="[Video Request] /  Please Select Type of Activity" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Event&nbsp;<span id="Span4" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCurrentDate_Video" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="txtDate_Of_Event_Video" runat="server" SkinID="txtDate" />
                                                            <img alt="Date of Event" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Event_Video', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgDate_Of_Event_Video" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Of_Event_Video" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Video Request] /  Date of Event is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Of_Event_Video" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDate_Of_Event_Video" runat="server" ControlToCompare="txtCurrentDate_Video"
                                                                ControlToValidate="txtDate_Of_Event_Video" Display="None" Text="*" ErrorMessage="[Video Request] /  Date of Event should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:RequiredFieldValidator ID="rfvtxtDate_Of_Event_Video" runat="server" ControlToValidate="txtDate_Of_Event_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Date of Event" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date of Request&nbsp;<span id="Span5" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Of_Request_Video" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Request_Video', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgDate_Of_Request_Video" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Of_Request_Video" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Video Request] /  Date of Request is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Of_Request_Video" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDate_Of_Request_Video" runat="server" ControlToCompare="txtCurrentDate_Video"
                                                                ControlToValidate="txtDate_Of_Request_Video" Display="None" Text="*" ErrorMessage="[Video Request] /  Date of Request should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:RequiredFieldValidator ID="rfvtxtDate_Of_Request_Video" runat="server" ControlToValidate="txtDate_Of_Request_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Date of Request" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Full Name&nbsp;<span id="Span6" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFull_Name_Video" runat="server" MaxLength="500" Width="170px" />
                                                            <asp:RequiredFieldValidator ID="revtxtFull_Name_Video" runat="server" ControlToValidate="txtFull_Name_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Full Name" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" valign="top">Work Phone<%--&nbsp;<span id="Span8" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Phone_Video" runat="server" autocomplete="off" MaxLength="12" Width="170px" SkinID="txtPhone"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regtxtWork_Phone_Video" ControlToValidate="txtWork_Phone_Video"
                                                                runat="server" SetFocusOnError="true" ErrorMessage="[Video Request] /  Please Enter Work Phone # in XXX-XXX-XXXX format"
                                                                Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                           <%-- <asp:RequiredFieldValidator ID="revtxtWork_Phone_Video" runat="server" ControlToValidate="txtWork_Phone_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Work Phone" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"><%--Location&nbsp;<span id="Span7" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top"><%--:--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <%--<asp:TextBox ID="txtLocation_Video" runat="server" MaxLength="500" Width="170px" />
                                                            <asp:RequiredFieldValidator ID="revtxtLocation_Video" runat="server" ControlToValidate="txtLocation_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Location" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td align="left" valign="top">Alternate Phone<%--&nbsp;<span id="Span9" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAlternate_Phone_Video" runat="server" autocomplete="off" MaxLength="12" Width="170px" SkinID="txtPhone"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regtxtAlternate_Phone_Video" ControlToValidate="txtAlternate_Phone_Video"
                                                                runat="server" SetFocusOnError="true" ErrorMessage="[Video Request] /  Please Enter Alternate Phone # in XXX-XXX-XXXX format"
                                                                Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                           <%-- <asp:RequiredFieldValidator ID="revtxtAlternate_Phone_Video" runat="server" ControlToValidate="txtAlternate_Phone_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Alternate Phone" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Status&nbsp;<span id="Span9" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpStatus" runat="server" Width="1750px" onchange="return showbutton();">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <%--<tr>
                                                                    <td align="left" width="18%" valign="top" style="padding-left: 25px;">If Yes:
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top" style="padding-left: 1px;">Police Dept Agency Name
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtAgency_name" runat="server" MaxLength="60" Width="170px" onblur="setAgencyNameSonic();"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 1px;">Police Officer Name
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Name" runat="server" MaxLength="60" Width="170px" onblur="setOfficerNameSonic();"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 1px;">Police Department Phone #
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Phone" runat="server" autocomplete="off" MaxLength="12" Width="170px" SkinID="txtPhone" onblur="setPhoneSonic();"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtOfficer_Phone" ControlToValidate="txtOfficer_Phone"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[Acadian Investigations] / Please Enter Agency Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 1px;">Police Report #
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPolice_Report_Number" runat="server" MaxLength="30" Width="170px" onblur="setPoliceReportSonic();"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trACIVehicle_Information" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">Vehicle Information Grid
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Make
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtMake" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Model
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtModel" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Color
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtColor" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">License
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtLicense" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">State
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:DropDownList ID="ddlVehicle_InfoState" runat="server" Width="170px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Suspects Vehicle
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:RadioButtonList ID="rdoSuspect_Vehicle" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnVehicle_InfoAdd" OnClick="btnVehicle_InfoAdd_Click" runat="server"
                                                                            ValidationGroup="vsErrorGroup" Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                        <%--OnClientClick="javascript:return valSaveEvent();"--%>
                                                                        <asp:Button ID="btnVehicle_Info" OnClick="btnVehicle_InfoCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr runat="server" id="trACIVehicle_InformationGrid">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">Vehicle Information Grid :
                                                                    </td>
                                                                    <td align="center" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="7">
                                                                        <asp:GridView ID="gvVehicle_Information" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvVehicle_Information_RowCommand"
                                                                            OnPageIndexChanging="gvVehicle_Information_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="1%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hdnPK_Vehicle_Information" runat="server" Value='<%# Eval("PK_Vehicle_Information") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Make">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblMake" CssClass="TextClip" runat="server" Text='<%# Eval("Make")%>' Width="100px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Model">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblModel" CssClass="TextClip" runat="server" Text='<%# Eval("Model")%>' Width="100px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Color">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblColor" CssClass="TextClip" runat="server" Text='<%# Eval("Color")%>' Width="100px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="License">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLicense" CssClass="TextClip" runat="server" Text='<%# Eval("License")%>' Width="100px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="State">
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("STATE")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Suspect Vehicle">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("Suspect_Vehicle")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                            CommandArgument='<%#Eval("PK_Vehicle_Information") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                                        </asp:LinkButton>
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Vehicle_Information") %>'
                                                                                        CommandName="RemoveVehicleInformation" OnClientClick="return confirm('Are you sure to remove Vehicle Information record?');"
                                                                                        CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                            <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 5px;">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddVehicleInfo" OnClick="lnkAddVehicleInfo_Click"
                                                                            runat="server" Text="Add New" OnClientClick="return CheckEvent();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                    <asp:LinkButton Style="display: none" ID="LinkButton2" runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trACISuspect_Information" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">Suspect Information Grid
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Sex
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:RadioButtonList ID="rdoSex" runat="server">
                                                                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="Female" Value="F" Selected="True"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSuspect_Information_Note" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnSuspect_InfoAdd" OnClick="btnSuspect_InfoAdd_Click" runat="server"
                                                                            ValidationGroup="vsErrorGroup" Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                        <asp:Button ID="btnSuspect_InfoCancel" OnClick="btnSuspect_InfoCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr runat="server" id="trACISuspect_InformationGrid">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">Suspect Information Grid :
                                                                    </td>
                                                                    <td align="center" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="7">
                                                                        <asp:GridView ID="gvSuspect_Information" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvSuspect_Information_RowCommand"
                                                                            OnPageIndexChanging="gvSuspect_Information_PageIndexChanging" Style="word-wrap: normal; word-break: break-all;">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="1%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hdnPK_Suspect_Information" runat="server" Value='<%# Eval("PK_Suspect_Information") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sex">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("Sex")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Description">
                                                                                    <ItemStyle Width="45%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDesc" CssClass="TextClip" runat="server" Text='<%# Eval("Description")%>' Width="250px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                            CommandArgument='<%#Eval("PK_Suspect_Information") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                                        </asp:LinkButton>
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Suspect_Information") %>'
                                                                                    CommandName="RemoveSuspectInformation" OnClientClick="return confirm('Are you sure to remove Suspect Information record?');"
                                                                                    CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                            <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 5px;">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddSuspectInfo" OnClick="lnkAddSuspectInfo_Click"
                                                                            runat="server" Text="Add New" OnClientClick="return CheckEvent();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton Style="display: none" ID="LinkButton3" runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top;">Incident Report
                                                        </td>
                                                        <td style="vertical-align: top;">:</td>
                                                        <td colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtIncident_Report" runat="server" Width="500" onblur="setIncidentReportSonic();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">Reason the Request is Being Made (Please Include as much Detail as Possible)&nbsp;<span style="color: Red;">*</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top;"></td>
                                                        <td style="vertical-align: top;">:</td>
                                                        <td colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtReason_Request_Video" runat="server" Width="500" IsRequired="true" RequiredFieldMessage="[Video Request] /  Please Enter Reason the Request is Being Made (Please Include as much Detail as Possible)" ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trVideoNotes" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td align="left" valign="top" width="19%">Date
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtACI_Notes_Date" runat="server" SkinID="txtDate" MaxLength="12" autocomplete="off"
                                                                            onpaste="return false"></asp:TextBox>
                                                                        <img alt="Report Date" onclick="return showCalendar('<%= txtACI_Notes_Date.ClientID %>', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                            Display="none" ErrorMessage="[ACI Notes Grid]/Date Sonic is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtDate_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCurrentDate"
                                                                            ControlToValidate="txtACI_Notes_Date" Display="None" Text="*" ErrorMessage="[ACI Notes Grid]/Date should not be greater than current date."
                                                                            Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                                    </td>--%>
                                                                    <td align="left" valign="top" width="19%">Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtVideo_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnVideoNotesAdd" OnClick="btnVideoNotesAdd_Click" runat="server" 
                                                                             Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnVideoNotesCancel" OnClick="btnVideoNotesCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trVideoNotesGrid">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="17%">Notes Grid
                                                                    </td>
                                                                    <td align="center" valign="top" width="5%">:
                                                                    </td>

                                                                    <td colspan="4" align="right">&nbsp;
                                                                        <uc:ctrlPaging ID="ctrlPageVideoNotes" runat="server" OnGetPage="GetVideoPage" RecordPerPage="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <div runat="server" id="dvVideoNOtes" style="width: 99%; overflow-y: scroll; border: solid 1px #000000;">
                                                                            <asp:GridView ID="gvVideo_Notes" runat="server" Width="97%" AutoGenerateColumns="false" OnSorting="gvVideo_Notes_Sorting"
                                                                                EnableViewState="true" AllowPaging="false" OnRowCommand="gvVideo_Notes_RowCommand" AllowSorting="True"
                                                                                OnPageIndexChanging="gvVideo_Notes_PageIndexChanging" Style="word-wrap: normal; word-break: break-all;">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                                        <HeaderTemplate>
                                                                                            <input type="checkbox" id="chkMultiSelectVideoNotes" onclick="SelectDeselectAllVideoNotes(this.checked);" />Select
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkSelectVideoNotes" runat="server" onclick="SelectDeselectVideoNoteHeader();" />
                                                                                            <input type="hidden" id="hdnPK_Video_Request_Notes" runat="server" value='<%#Eval("PK_Video_Request_Notes") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date" SortExpression="Note_Date">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <a href="javascript:function(){return false};" onclick="VideoNotePopup('<%#Eval("PK_Video_Request_Notes") %>','SONIC');">
                                                                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="User">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblUpdated_By" runat="server" Text='<%# Eval("Updated_by_Name") %>'
                                                                                                    Style="word-wrap: normal; word-break: break-all;"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Notes">
                                                                                            <ItemStyle Width="43%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' Style="word-wrap: normal; word-break: break-all;"
                                                                                                    Width="310px" CssClass="TextClip"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                                CommandArgument='<%#Eval("PK_Video_Request_Notes") %>'>
                                                                                            </asp:LinkButton>
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Video_Request_Notes") %>'
                                                                                    CommandName="RemoveVideoNote" OnClientClick="return confirm('Are you sure to remove Note record?');"
                                                                                    CausesValidation="false" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <table cellpadding="4" cellspacing="0" width="97%">
                                                                                        <tr>
                                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
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
                                                                    <td style="padding-bottom: 5px;" colspan="6">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddVideoNotesNew" OnClick="lnkAddVideoNotesNew_Click"
                                                                            runat="server" Text="Add New" OnClientClick="return CheckVideo();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                         <asp:Button ID="btnVideoNoteView" runat="server" Text=" View" OnClientClick="return VideoSelectedNotePopup('','VideoView');" />&nbsp;&nbsp;
                                                                        <asp:Button ID="btnVideoPrint" runat="server" Text=" Print " OnClick="btnVideoPrint_Click"
                                                                            OnClientClick="return CheckSelectedVideoNotes('Print');" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnVideoSpecificNote" runat="server" CausesValidation="false" Text=" Show Specific Notes Only "
                                                                            OnClientClick="javascript:return CheckSelectedVideoNotes('VideoSpecificNote');" />
                                                                        <asp:LinkButton Style="display: none" ID="lnkVideoNotesCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>Tracking Grid</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:GridView ID="gvTracking" runat="server" EmptyDataText="No Tracking Records Found"
                                                                AutoGenerateColumns="false" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date Time">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%# string.Format("{0:MM/dd/yyyy hh:mm tt}", Eval("Update_Date")) %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="User">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("UserName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Status")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reason">
                                                                        <ItemStyle Width="40%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Reason_Request")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                            <div class="bandHeaderRow">
                                                                Footage Information
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Camera Name&nbsp;<span style="color: Red;" runat="server" id="spancameraname">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCamera_Name_Video" runat="server" MaxLength="500" Width="170px" />
                                                            <asp:RequiredFieldValidator ID="revtxtCamera_Name_Video" runat="server" ControlToValidate="txtCamera_Name_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Camera Name" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Start Time&nbsp;<span style="color: Red;" runat="server" id="spanstarttime">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_Start_Time_Video" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Start_Time_Video"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="regtxtEvent_Start_Time_Video" runat="server" ControlToValidate="txtEvent_Start_Time_Video"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[Video Request] /  Invalid Event Start Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="revtxtEvent_Start_Time_Video" runat="server" ControlToValidate="txtEvent_Start_Time_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Event Start Time" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" valign="top">Event End Time&nbsp;<span style="color: Red;" runat="server" id="spanendtime">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_End_Time_Video" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_End_Time_Video"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="regtxtEvent_End_Time_Video" runat="server" ControlToValidate="txtEvent_End_Time_Video"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[Video Request] /  Invalid Event End Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="revtxtEvent_End_Time_Video" runat="server" ControlToValidate="txtEvent_End_Time_Video"
                                                                InitialValue="" ErrorMessage="[Video Request] /  Please Enter Event End Time" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Video Link - Email Address to Send Link
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtVideo_Link_Email_Video" runat="server" MaxLength="100" Width="170px" />
                                                            <asp:RegularExpressionValidator ID="regtxtVideo_Link_Email_Video" runat="server" ControlToValidate="txtVideo_Link_Email_Video"
                                                                Display="None" ErrorMessage="[Video Request] /  Video Link - Email Address to Send Link is not valid" SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Still Shots - Email Address to Send Link
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtStill_Shots_Email_Video" runat="server" MaxLength="100" Width="170px" />
                                                            <asp:RegularExpressionValidator ID="regtxtStill_Shots_Email_Video" runat="server" ControlToValidate="txtStill_Shots_Email_Video"
                                                                Display="None" ErrorMessage="[Video Request] /  Still Shots - Email Address to Send Link is not valid" SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">DVD No. of Copies
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtNo_DVD_Copy_Video" runat="server" MaxLength="3" Width="40px" autocomplete="off"
                                                                onKeyPress="return FormatInteger(event);" onpaste="return false" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="color: Red;"><b>URGENT NEED</b></span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoUrgent_Need_Video" runat="server" onClick="return setUrgentNeed();">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Mailing Address for Media</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Address
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtMailing_Address_Video" runat="server" MaxLength="1000" Width="370px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Shipping Method
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoShipping_Method_Video" runat="server">
                                                                <asp:ListItem Text="Overnight" Value="Overnight"></asp:ListItem>
                                                                <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                                                                <asp:ListItem Text="Express/2-Day" Value="Express/2-Day"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Cause Investigation
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Cause Investigation
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlFK_LU_Cause_Investigation" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px"></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <br />
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="100%" style="height: 200px;">
                                                        <uc:Attachment ID="ucAttachment" runat="server" Attachment_Table="Event" MajorCoverage="Event" />
                                                    </td>
                                                </tr>
                                            </table>
                                                <br />
                                                <br />
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr runat="server" id="trACINotesGrid">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="17%">Acadian Notes Grid
                                                                    </td>
                                                                    <td align="center" valign="top" width="5%">:
                                                                    </td>

                                                                    <td colspan="4" align="right">&nbsp;
                                                                        <uc:ctrlPaging ID="ctrlPageAcadianNotes" runat="server" OnGetPage="GetPage" RecordPerPage="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <div runat="server" id="dvACINOtes" style="width: 99%; overflow-y: scroll; border: solid 1px #000000;">
                                                                            <asp:GridView ID="gvACI_Notes" runat="server" Width="97%" AutoGenerateColumns="false" OnSorting="gvACI_Notes_Sorting"
                                                                                EnableViewState="true" AllowPaging="false" OnRowCommand="gvACI_Notes_RowCommand" AllowSorting="True"
                                                                                OnPageIndexChanging="gvACI_Notes_PageIndexChanging" Style="word-wrap: normal; word-break: break-all;">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                                        <HeaderTemplate>
                                                                                            <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectACINoteHeader();" />
                                                                                            <input type="hidden" id="hdnPK_ACI_Event_Notes" runat="server" value='<%#Eval("PK_ACI_Event_Notes") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date" SortExpression="Note_Date">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_ACI_Event_Notes") %>','ACI');">
                                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                                        HeaderText="Note Text">
                                                                                        <ItemTemplate>
                                                                                            <%--   <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                                    CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>--%>
                                                                                            <asp:Label ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' Style="word-wrap: normal; word-break: break-all;"
                                                                                                Width="310px" CssClass="TextClip"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                                CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                                            </asp:LinkButton>
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>'
                                                                                CommandName="RemoveACINote" OnClientClick="return confirm('Are you sure to remove Acadian Note record?');"
                                                                                CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <table cellpadding="4" cellspacing="0" width="97%">
                                                                                        <tr>
                                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
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
                                                                    <td style="padding-bottom: 5px;" colspan="6">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddACINotesNew" OnClick="lnkAddACINotesNew_Click"
                                                                            runat="server" Text="Add New" OnClientClick="return CheckEvent();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                         <asp:Button ID="btnACINoteView" runat="server" Text=" View" OnClientClick="return AciSelectedNotePopup('','ACIView');" />&nbsp;&nbsp;
                                                                        <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click"
                                                                            OnClientClick="return CheckSelectedAcadianNotes('Print');" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnSpecificNote" runat="server" CausesValidation="false" Text=" Show Specific Notes Only "
                                                                            OnClientClick="javascript:return CheckSelectedAcadianNotes('ACISpecificNote');" />
                                                                        <asp:LinkButton Style="display: none" ID="lnkACINotesCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trACINotes" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Acadian Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td align="left" valign="top" width="19%">Date
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtACI_Notes_Date" runat="server" SkinID="txtDate" MaxLength="12" autocomplete="off"
                                                                            onpaste="return false"></asp:TextBox>
                                                                        <img alt="Report Date" onclick="return showCalendar('<%= txtACI_Notes_Date.ClientID %>', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                            Display="none" ErrorMessage="[ACI Notes Grid]/Date Sonic is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtDate_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCurrentDate"
                                                                            ControlToValidate="txtACI_Notes_Date" Display="None" Text="*" ErrorMessage="[ACI Notes Grid]/Date should not be greater than current date."
                                                                            Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                                    </td>--%>
                                                                    <td align="left" valign="top" width="19%">Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtACI_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnACINotesAdd" OnClick="btnACINotesAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                            OnClientClick="javascript:return checkLength();" Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnACINotesCancel" OnClick="btnACINotesCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnl6" runat="server" Style="display: none;" Width="794px">
                                            <div class="bandHeaderRow">
                                                Abstracts & Custom Letters
                                            </div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <uc:ctrlAbstractLetters ID="ucAbstractLetter" runat="server" PanelNumber="6" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlAttachment" runat="server" Style="display: none;" Width="794px">
                                            
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td width="100%" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <%--<asp:Button ID="btnPreviousStep" ToolTip="Previous Step" runat="server" Text="Previous Step"
                                                            OnClick="btnPreviousStep_Click" CausesValidation="false" OnClientClick="return  onPreviousStep();" />--%>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" ToolTip="Save & Continue Editing" Text="Save & Continue Editing"
                                                            OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            Width="170px" OnClientClick="CheckBeforeSave('btnSave');return false;" />
                                                        <asp:Button ID="btnSend_Notification" runat="server" ToolTip="Save and Send Notification" Text="Save and Send Notification"
                                                            OnClick="btnSend_Notification_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            Width="190px" OnClientClick="CheckBeforeSave('btnSend_Notification');return false;" />
                                                        <asp:Button ID="btnSaveHidden" runat="server" OnClick="btnSaveHidden_Click" Style="display: none" />
                                                        <asp:Button ID="btnBack" runat="server" ToolTip="Edit" Text="  Edit  " CausesValidation="false"
                                                            OnClick="btnBack_Click" />
                                                        <%--<asp:Button ID="btnNextStep" runat="server" ToolTip="Next Step" Text="Next Step"
                                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="javascript:return onNextStep();"
                                                            OnClick="btnNextStep_Click" />--%>
                                                        <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                            ToolTip="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />&nbsp;
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
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="pnl" runat="server" />
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
</asp:Content>
