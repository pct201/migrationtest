<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="SLT_Meeting.aspx.cs" Inherits="SONIC_SLT_SLT_Meeting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/SLT/IncidentReview_Info.ascx" TagName="IncidentReview"
    TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicLocationInfo/SonicLocationInfo.ascx" TagName="ctrlInvestigationInfo"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment_SLT.ascx" TagName="ctrlAttachment_SLT" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment_Detail.ascx" TagName="ctrlAttachmentDetail" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_SafetywalkAttachment_txtType").val("");
        });

        function AuditPopUpMeeting(Name) {
            var winHeight = window.screen.availHeight - 380;
            var winWidth = window.screen.availWidth - 390;

            if (Name == "SLTMembers") {
                var ID = '<%=ViewState["PK_SLT_Member"]%>';
                obj = window.open("../SLT/AuditPopup_SLTMembers.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "SLTSchedule") {
                var ID = '<%=ViewState["PK_SLT_Meeting_Schedule"]%>';
                obj = window.open("../SLT/AuditPopup_SLTSchedule.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "QuarterlyInspections") {
                var ID = '<%=ViewState["PK_SLT_Quarterly_Inspections"]%>';
                obj = window.open("../SLT/AuditPopup_SLTQuarterly_Inspections.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "SLTTraining") {
                var ID = '<%=ViewState["PK_SLT_Training"]%>';
                obj = window.open("../SLT/AuditPopup_SLTTraining.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "New_Procedure") {
                var ID = '<%=ViewState["PK_SLT_New_Procedure"]%>';
                obj = window.open("../SLT/AuditPopup_SLTNew_Procedure.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "SLTSuggestion") {
                var ID = '<%=ViewState["PK_SLT_Suggestion"]%>';
                obj = window.open("../SLT/AuditPopup_SLTSuggestion.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "SLTMeeting") {
                var ID = '<%=ViewState["PK_SLT_Meeting"]%>';
                obj = window.open("../SLT/AuditPopup_SLTMeeting.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (Name == "SLTSafetyWalk") {
                var ID = '<%=ViewState["PK_SLT_Safety_Walk"]%>';
                    obj = window.open("../SLT/AuditPopup_SLTSafetyWalk.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
                    obj.focus();
            }
            else if (Name == "SLTBTSecurityWalk") {
                var ID = '<%=ViewState["PK_SLT_BT_Security_Walk"]%>';
                obj = window.open("../SLT/AuditPopup_SLT_BT_Security_Walk.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
                obj.focus();
            }
    return false;
}

function showPanelIncident(id) {

    if (id == "ctl00_ContentPlaceHolder1_img1") {
        document.getElementById('<%=trIncidentReview_SubMenu.ClientID%>').style.display = "";
        document.getElementById('<%=img2.ClientID%>').style.display = "";
        document.getElementById('<%=img1.ClientID%>').style.display = "none";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgPlus") {
        document.getElementById('<%=submenumeeting.ClientID%>').style.display = "";
        document.getElementById('<%=imgMinus.ClientID%>').style.display = "";
        document.getElementById('<%=imgPlus.ClientID%>').style.display = "none";
    }
    else if (id == "MenuMeeting") {
        if (document.getElementById('<%=submenumeeting.ClientID%>').style.display == "") {
            document.getElementById('<%=submenumeeting.ClientID%>').style.display = "none";
            document.getElementById('<%=imgMinus.ClientID%>').style.display = "none";
            document.getElementById('<%=imgPlus.ClientID%>').style.display = "";
        }
        else {
            document.getElementById('<%=submenumeeting.ClientID%>').style.display = "";
            document.getElementById('<%=imgMinus.ClientID%>').style.display = "";
            document.getElementById('<%=imgPlus.ClientID%>').style.display = "none";
        }
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgGuidanceplusedit") {
        document.getElementById('<%=trGuidanceText.ClientID%>').style.display = "";
        document.getElementById('<%=imgGuidanceminusedit.ClientID%>').style.display = "";
        document.getElementById('<%=imgGuidanceplusedit.ClientID%>').style.display = "none";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgGuidanceplusView") {
        document.getElementById('<%=trGuidance_view.ClientID%>').style.display = "";
        document.getElementById('<%=imgGuidanceminusView.ClientID%>').style.display = "";
        document.getElementById('<%=imgGuidanceplusView.ClientID%>').style.display = "none";
    }
}
function HidePaneIncident(id) {
    if (id == "ctl00_ContentPlaceHolder1_img2") {
        document.getElementById('<%=trIncidentReview_SubMenu.ClientID%>').style.display = "none";
        document.getElementById('<%=img2.ClientID%>').style.display = "none";
        document.getElementById('<%=img1.ClientID%>').style.display = "";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgMinus") {
        document.getElementById('<%=submenumeeting.ClientID%>').style.display = "none";
        document.getElementById('<%=imgMinus.ClientID%>').style.display = "none";
        document.getElementById('<%=imgPlus.ClientID%>').style.display = "";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgGuidanceminusedit") {
        document.getElementById('<%=trGuidanceText.ClientID%>').style.display = "none";
        document.getElementById('<%=imgGuidanceminusedit.ClientID%>').style.display = "none";
        document.getElementById('<%=imgGuidanceplusedit.ClientID%>').style.display = "";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgGuidanceminusView") {
        document.getElementById('<%=trGuidance_view.ClientID%>').style.display = "none";
        document.getElementById('<%=imgGuidanceminusView.ClientID%>').style.display = "none";
        document.getElementById('<%=imgGuidanceplusView.ClientID%>').style.display = "";
    }
}

function OpenRLCM_Training(Quater, Year, RLCM_ID, PK_SLT_Meeting, Location_ID, StrOperation) {
    var w = 480, h = 340;
    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 800, popH = 300;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }
    window.open('PopUp_Training_RLCM.aspx?Quater=' + Quater + '&Year=' + Year + '&RLCM_ID=' + RLCM_ID + '&PK_SLT=' + PK_SLT_Meeting + '&Loc_ID=' + Location_ID + '&op=' + StrOperation, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    return false;
}

function OpenPopupEmailSchedule(Doctype) {
    var ID = '<%=PK_SLT_Meeting%>';
    var w = 480, h = 340;
    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 800, popH = 460;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }
    window.open('Popup_SLT_ReviewMail.aspx?id=' + ID + '&Doctype=' + Doctype, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);

}
function OpenPopupEmail(Doctype) {
    var w = 480, h = 340;
    var ID = '<%=PK_SLT_Meeting_Schedule%>';
    var temp_ID = '<%=PK_Temp_Schedule_ID %>';
    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 800, popH = 460;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }

    if (ID > 0) {
        window.open('Popup_SLT_ReviewMail.aspx?Sid=' + ID + '&Doctype=' + Doctype, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    }
    else if (temp_ID > 0) {
        window.open('Popup_SLT_ReviewMail.aspx?Sid=' + temp_ID + '&Doctype=' + Doctype, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    }
    else {
        alert('Please select meeting agenda record');
    }

}
function SetMenuStyle(index) {
    var i;
    for (i = 1; i <= 15; i++) {

        //if (i == 5)
        //{
        //    var tb = document.getElementById("ctl00_ContentPlaceHolder1_Menu5");
        //}
        //else
        //{
        var tb = document.getElementById("Menu" + i);
        //}

        var tb3 = document.getElementById("MenuMeeting");
        if (i == index) {
            if (index >= 3) {
                tb3.className = "LeftMenuSelected";
                tb3.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                tb3.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                tb.className = "LeftMenuSelected";
                tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
            }
            else {
                tb3.className = "LeftMenuStatic";
                tb3.onmouseover = function () { this.className = 'LeftMenuHover'; }
                tb3.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                tb.className = "LeftMenuSelected";
                tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
            }

        }
        else {
            tb.className = "LeftMenuStatic";
            tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
            tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
        }
    }
}
function ShowPanel(index) {
    var IsEditable = '<%=meetingIsEditable %>';
    SetMenuStyle(index);
    ActiveTabIndex = index;
    if (index != 3) {
        document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
    }
    var meetingindex = document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value;
    document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel2").value = ActiveTabIndex;
    document.getElementById("ctl00_ContentPlaceHolder1_btnRecalculate").style.display = "none";
    var op = '<%=StrOperation%>';
    if (op == "view") {
        ShowPanelView(index, 'true');
    }
    else if (IsEditable == 'False' && op != "view") {
        for (i = 1; i <= 2; i++) {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
            document.getElementById('ctl00_ContentPlaceHolder1_dvnonEditable').style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl14View").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl14").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnSaveNnextCall").style.display = "inline";
            document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "none";
        }
        document.getElementById("ctl00_ContentPlaceHolder1_btnPrevious").style.display = (index == 1) ? "none" : "inline";
        //document.getElementById("ctl00_ContentPlaceHolder1_btnSendTO_RLCM").style.display = (index == 13) ? "inline" : "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSend").style.display = (index == 14) ? "inline" : "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSendMeetingView").style.display = (index == 13) ? "inline" : "none";
        if (index >= 3 && index < 14) {
            ShowPanelView(index, 'false');
            document.getElementById("ctl00_ContentPlaceHolder1_btnSaveNnextCall").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "none";

        }
        if (index == 14) {
            document.getElementById("ctl00_ContentPlaceHolder1_btnSaveNnextCall").style.display = "none";
            HideDisplayReviewPanel();
        }
        if (index == 15) {
            ShowPanelView(index, 'false');
            document.getElementById("ctl00_ContentPlaceHolder1_btnSaveNnextCall").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "none";
        }
    }
    else {
        var i;
        for (i = 1; i <= 13; i++) {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl14View").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl14").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "none";
        }

        if (index == 15) {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl17").style.display = (15 == index) ? "block" : "none";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl14View").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl14").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "none";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl17").style.display = "none";
        }


        document.getElementById("ctl00_ContentPlaceHolder1_btnPrevious").style.display = (index == 1) ? "none" : "inline";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSaveNnextCall").style.display = (index != 14 && index != 13) ? "inline" : "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSaveNSend").style.display = (index == 13) ? "inline" : "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSendMail").style.display = (index == 13) ? "inline" : "none";
        //document.getElementById("ctl00_ContentPlaceHolder1_btnSendTO_RLCM").style.display = (index == 13) ? "inline" : "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSend").style.display = (index == 14) ? "inline" : "none";
        if (index == 3) {
            var rowscount = document.getElementById('<%=gv_MeetingAttendees.ClientID%>').rows.length;
            var rowscount1 = '<%=PK_SLT_Member%>';
            var Schedule_ID = '<%=PK_SLT_Meeting_Schedule %>';
            if (rowscount1 > 0) {
                if (Schedule_ID > 0 || Schedule_ID == -1) {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnl3").style.display = "block";
                }
                else {
                    SetMenuStyle(meetingindex);
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + meetingindex).style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl3").style.display = "none";
                    alert('Please Add or Select SLT Meeting Agenda record first');
                }
            }
            else {
                SetMenuStyle(meetingindex);
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + meetingindex).style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_pnl3").style.display = "none";
                alert('Please Add SLT Member record first');
            }
        }
        if (index == 14) {
            HideDisplayReviewPanel();
            document.getElementById("ctl00_ContentPlaceHolder1_btnRecalculate").style.display = "inline";
        }


    }
}

function HideDisplayReviewPanel() {
    var Userrole = '<%=UserIsRegional%>';
    var IsEditable = '<%=meetingIsEditable %>';
    if (Userrole == 'True') {
        document.getElementById("ctl00_ContentPlaceHolder1_pnl14").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_pnl14View").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "inline";
        document.getElementById("ctl00_ContentPlaceHolder1_btnRecalculate").style.display = ActiveTabIndex == 14 ? "inline" : "none";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_pnl14View").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_pnl14").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_btnSave").style.display = "none";
    }
}
function ShowPanelView(index, strStatus) {
    SetMenuStyle(index);
    ActiveTabIndex = index;
    document.getElementById('<%=dvView.ClientID%>').style.display = strStatus == 'true' ? "block" : "none";
    document.getElementById('ctl00_ContentPlaceHolder1_dvnonEditable').style.display = "block";
    if (index != 3) {
        document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
    }
    var meetingindex = document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value;
    document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel2").value = ActiveTabIndex;
    var i;
    for (i = 1; i <= 14; i++) {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
    }

    if (index == 15)
        document.getElementById("ctl00_ContentPlaceHolder1_pnl17View").style.display = "block";
    else
        document.getElementById("ctl00_ContentPlaceHolder1_pnl17View").style.display = "none";

    document.getElementById("ctl00_ContentPlaceHolder1_btnPrevious").style.display = (index == 1) ? "none" : "inline";
    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = (index == 14) ? "none" : "inline";
    //document.getElementById("ctl00_ContentPlaceHolder1_btnSendTO_RLCM").style.display = (index == 13) ? "inline" : "none";
    document.getElementById("ctl00_ContentPlaceHolder1_btnSendMeetingView").style.display = (index == 13) ? "inline" : "none";
    if (index == 3) {

        var rowscount = document.getElementById('<%=gvMeetingAttendeesView.ClientID%>').rows.length;
        var rowscount1 = '<%=PK_SLT_Member%>';
        var Schedule_ID = '<%=PK_SLT_Meeting_Schedule %>';
        if (rowscount1 > 0) {
            if (Schedule_ID > 0 || Schedule_ID == -1) {

                document.getElementById("ctl00_ContentPlaceHolder1_pnl3View").style.display = "block";
            }
            else {
                SetMenuStyle(meetingindex); //alert(meetingindex);
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + meetingindex + "View").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_pnl3View").style.display = "none";
                alert('Please Select SLT Meeting Agenda record first');
            }
        }
        else {
            SetMenuStyle(meetingindex);
            //dvView.visible = none;
            document.getElementById("ctl00_ContentPlaceHolder1_pnl" + meetingindex + "View").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_pnl3View").style.display = "none";
            alert('No SLT Member record Found ');
        }
    }
}

function ShowHideExlpain(id) {

    var lblExplain_id = id.replace("drpExplain", "lblExplain");
    var txtExplain_id = id.replace("drpExplain", "txtExplain");
    var ddl = document.getElementById(id); //ctl00_ContentPlaceHolder1_gv_MeetingAttendees
    var lblExplain = document.getElementById(lblExplain_id);
    var txtExplain = document.getElementById(txtExplain_id);
    if (ddl.options[ddl.selectedIndex].text == "Other") {
        lblExplain.style.display = "block";
        txtExplain.style.display = "block";
    }
    else {
        lblExplain.style.display = "none";
        txtExplain.style.display = "none";
    }
}
function ShowHideComments(rdoID, type) {
    document.getElementById('ctl00_ContentPlaceHolder1_tr' + type).style.display = (document.getElementById(rdoID + '_0').checked) ? "" : "none";
}

function ShowHideBTSecComments(rdoID, type) {
    document.getElementById('ctl00_ContentPlaceHolder1_trBTSec' + type).style.display = (document.getElementById(rdoID + '_0').checked) ? "" : "none";
}

var ActiveTabIndex = 1;
function onNextStep() {
    var IsEditable = '<%=meetingIsEditable %>';
    var op = '<%=StrOperation%>';
    if (op == "view") {
        ActiveTabIndex = ActiveTabIndex + 1;
        if (ActiveTabIndex == 3) {
            ShowPanel(4);
            return false;
        }
        else {
            if (IsEditable == 'False' && op != "view") {
                ShowPanelView(ActiveTabIndex, 'false');
                return false;
            }
            else {
                ShowPanelView(ActiveTabIndex, 'true');
                return false;
            }
        }

    }

    else {
        ActiveTabIndex = ActiveTabIndex + 1;
        if (ActiveTabIndex == 3) {
            ShowPanel(4);
        }
        else
            ShowPanel(ActiveTabIndex);
        return false;
    }

}
function onPreviousStep() {
    ActiveTabIndex = ActiveTabIndex - 1;
    document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
    document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel2").value = ActiveTabIndex;
    if (ActiveTabIndex == 3) {
        ShowPanel(2);
    }
    else if (ActiveTabIndex == 5) {
        ShowPanel(15);
    }
    else
        ShowPanel(ActiveTabIndex);
    return false;
}

function CheckBeforeAddSaftyWalkAttach() {
    var trAttach = document.getElementById('<%=trSafetyWalkAttachment.ClientID%>');
    trAttach.style.display = "block";
}

function CheckBeforeAddBTSecurityWalkAttach() {
    var trAttach = document.getElementById('<%=trBTSecWalkAttachment.ClientID%>');
    trAttach.style.display = "block";
}

function CheckBeforeAddTrainingAttach() {
    $("#ctl00_ContentPlaceHolder1_SLT_TrainingAttachmentADD_txtType").val("");
    var PK = '<%=PK_SLT_Training%>';
    if (PK > 0) {
        var trAttach = document.getElementById('<%=tr_training_Attachment.ClientID%>');
        trAttach.style.display = "block";
    }
    else {
        alert('Please Add or Select Training Information First');
    }
}
function openWindowAbstract(strURL) {
    //oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
    var w = 480, h = 340;
    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 200, popH = 200;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }
    window.open(strURL, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
    //oWnd.moveTo(260,180);
    return false;
}
function CheckSLT_Member() {
    var rowscount = document.getElementById('<%=gvSLT_Members.ClientID%>').rows.length;
    if (rowscount > 1)
        return true;
    else {
        alert('Please  Add SLT Member record first');
        return false;
    }
}

function SetValidationGroup() {
    var Index = document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel2").value;
    var Schedule_id = '<%=ViewState["PK_SLT_Meeting_Schedule"] %>';
    var temp_ID = '<%=PK_Temp_Schedule_ID %>';
    var ValidationGroups;
    if (Index == 1) {
        if (document.getElementById("ctl00_ContentPlaceHolder1_tr_SltmembersADD").style.display == "block") {
            ValidationGroups = "vsErrorSLT_Members";
        }
        else
            return true;
    }
    if (Index == 3) ValidationGroups = "vsErrorAttendees";
    else if (Index != 1 && Index != 8 && Index != 13 && Index != 7 && Index != 3 && Index != 2 && Index != 9 && Index != 14) {
        if (Schedule_id > 0) {
            if (Index == 4) ValidationGroups = "vsErrorcallToOrder";
            else if (Index == 5) ValidationGroups = "vsErrorSafetywalkGroup";
            else if (Index == 15) ValidationGroups = "vsErrorBTSecuritywalkGroup";
            else if (Index == 6) {
                var id_Q_Ins = '<%=ViewState["PK_SLT_Quarterly_Inspections"] %>';
                var id_Q_Res = '<%=ViewState["FK_Inspection_Responses_ID"] %>';
                if (parseInt(id_Q_Ins) > 0 && parseInt(id_Q_Res) > 0) {
                    ValidationGroups = "vsErrorInspectionGroup";
                }
                else {
                    ValidationGroups = "";
                }
            }
            else if (Index == 10) ValidationGroups = "vsErrorTrainingGroup";
            else if (Index == 11) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_tr_procedureAdd").style.display == "block") {
                    ValidationGroups = "vsErrorProcedure";
                }
                else
                    return true;
            }
            else if (Index == 12) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_tr_suggestionadd").style.display == "block") {
                    ValidationGroups = "vsErrorSuggestion";
                }
                else
                    return true;
            }
}
else {
    alert('Please select meeting agenda record');
    return false;
}
}
else if (Index == 14) {
    if (temp_ID > 0 || Schedule_id > 0) {
        ValidationGroups = "vsErrorMeetingReview";
    }
    else {
        alert('Please select meeting agenda record');
        return false;
    }
}
else if (Index == 9) {
    if ('<%=ViewState["FK_Claim"] %>' > 0) {
        ValidationGroups = "vsErrorClaimManagement";
    }
    else {
        return true;
    }
}
else if (Index == 8) {
    if (document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_WC_lblIncidentNumber_WC').innerText.length > 0) {
        ValidationGroups = "VSGroup_WC";
    }
    else {
        ValidationGroups = "";
    }
}
else if (Index == 13)
    ValidationGroups = "vsErrorSchedule";
else
    ValidationGroups = "";

    if (ValidationGroups != "") {
        if (Page_ClientValidate(ValidationGroups)) {
            return true;
        }
        else {
            Page_ClientValidate('dummy');
            return false;
        }
    }
    return true;
}
function CallControlSave(id) {
    document.getElementById(id).click();
}
function CheckScheduleid() {
    var Iseditable = '<%=ViewState["meetingIsEditable"] %>'
    var Schedule_id = '<%=ViewState["PK_SLT_Meeting_Schedule"] %>';

    if (Schedule_id > 0) {
        if (Iseditable == 'True') {
            return true;
        }
        else {
            alert('You cannot edit data once slt meeting is reviewed by RLCM.');
            return false;
        }
    }
    else {
        alert('Please select meeting agenda record');
        return false;
    }
}
function CheckScheduleidForRLCM() {
    var Schedule_id = '<%=ViewState["PK_SLT_Meeting_Schedule"] %>';

    if (Schedule_id > 0) {
        ShowPanel(13);
        OpenPopupEmailSchedule('Next_Schedule');
        return false;
    }
    else {
        alert('Please select meeting agenda record');
        return false;
    }
}

function CheckPoints(type, txt) {
    value = parseInt(txt.value);
    if ((type == 1 || type == 2 || type == 3) && value > 1) {
        alert('Please enter either 0 or 1');
        txt.focus();
    }
    else if (type == 4 && value > 2) {
        alert('Please enter value between 0 and 2');
        txt.focus();
    }
}

function ValidatePoints(sender, args) {
    var Point1 = document.getElementById('<%=txtMeetingPoints.ClientID %>').value;
    var Point2 = document.getElementById('<%=txtSafetyWalkPoints.ClientID %>').value;
    var Point3 = document.getElementById('<%=txtIncidentReviewPoints.ClientID %>').value;
    var Point4 = document.getElementById('<%=txtQualityReviewPoints.ClientID %>').value;

    if ((Point1 == "" && Point2 == "" && Point3 == "" && Point4 == "") || (Point1 != "" && Point2 != "" && Point3 != "" && Point4 != ""))
        args.IsValid = true;
    else
        args.IsValid = false;
}

function OpenPopup() {
    //GB_showCenter('', '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?DBA=' + DBA.replace(/&/g, '%26') + '&Code=' + Code.toString() + '&year=' + year + '&MapID=' + MapID + '&' + new Date().toString(), 300, 400, '');
    var navUrl = '<%=AppConfig.SiteURL%>DashBoard/DealershipDetail.aspx?DBA=' + '<%= Convert.ToString(ViewState["jDBA"]) %>' + '&Code=' + '<%= Convert.ToString(ViewState["jSLC"]) %>' + '&year=' + '<%= Convert.ToString(ViewState["jYear"]) %>' + '&MapID=' + 3 + '&' + new Date().toString();
    OpenWindow(navUrl);
}

function OpenWindow(navUrl) {
    var w = 700, h = 550;

    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 400, popH = 300;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }

    window.open(navUrl, "popup2", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
}


jQuery(function ($) {
    $("#<%=txtMembersStart_Date.ClientID%>").mask("99/99/9999");
    $("#<%=txtmemberEnd_date.ClientID%>").mask("99/99/9999");
    $("#<%=txtActual_Meeting_Date.ClientID%>").mask("99/99/9999");
    $("#<%=txtMeeting_Start_Time.ClientID%>").mask("99:99");
    $("#<%=txtMeeting_End_Time.ClientID%>").mask("99:99");
    $("#<%=txtScheduled_Meeting_Time.ClientID%>").mask("99:99");
});

function DisableButton() {
    document.getElementById('<%= btnSaveNnextCall.ClientID %>').disabled = true;
            document.getElementById('<%= btnSaveNnextCall.ClientID %>').value = 'Submitting...';
        }

    </script>
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="vsErrorSLT_Members"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary8" runat="server" ValidationGroup="vsErrorScheduleSearch"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary10" runat="server" ValidationGroup="vsErrorAttendees"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary11" runat="server" ValidationGroup="vsErrorcallToOrder"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ValidationGroup="vsErrorSafetywalkGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ValidationGroup="vsErrorInspectionGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary9" runat="server" ValidationGroup="vsErrorClaimManagement"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary5" runat="server" ValidationGroup="vsErrorTrainingGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vsErrorProcedure"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="vsErrorSuggestion"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vsErrorSchedule"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorMeetingReview"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="Spacer" style="height: 10px;">
                <uc1:ctrlInvestigationInfo ID="InvestigationInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="2" cellspacing="1" width="100%" border="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer" colspan="2"></td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top">&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">SLT Members</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td align="left">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Meeting Agenda
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="bottom" width="3%">
                                        <img id="imgPlus" runat="server" src="../../Images/plus.jpg" style="cursor: pointer; display: none;"
                                            height="15" onclick="showPanelIncident(this.id);" />
                                        <img id="imgMinus" runat="server" src="../../Images/minus.jpg" style="cursor: pointer;"
                                            height="15" onclick="HidePaneIncident(this.id);" />
                                    </td>
                                    <td align="left" valign="top" width="97%">
                                        <span id="MenuMeeting" onclick="javascript:SetMenuStyle(3);showPanelIncident(this.id);"
                                            class="LeftMenuStatic">Meeting Minutes</span>
                                    </td>
                                </tr>
                                <tr id="submenumeeting" runat="server">
                                    <td>&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <table cellpadding="2" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td width="3%" valign="top" align="right">
                                                    <img id="imgredMark" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                                </td>
                                                <td align="left" valign="top" width="97%">
                                                    <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Meeting Attendees</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Call To Order</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <img id="img3" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Safety Walk</span>
                                                    <%--<span id="Menu5" class="LeftMenuStatic" runat="server" >Safety Walk</span>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <img id="imgBTSecurityWalk" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu15" onclick="javascript:ShowPanel(15);" class="LeftMenuStatic">BT Security Walk</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Quarterly
                                                        Facility Inspection</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top" width="3%">
                                                    <img id="img1" runat="server" src="../../Images/plus.jpg" style="cursor: pointer; display: none;"
                                                        height="15" onclick="showPanelIncident(this.id);" />
                                                    <img id="img2" runat="server" src="../../Images/minus.jpg" style="cursor: pointer;"
                                                        height="15" onclick="HidePaneIncident(this.id);" />
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Incident
                                                        Investigation</span>
                                                </td>
                                            </tr>
                                            <tr id="trIncidentReview_SubMenu" runat="server">
                                                <td align="right" valign="top">&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Panel ID="pnlIncidentReview_SubMenu" runat="server">
                                                        <table cellpadding="2" cellspacing="1" width="100%" border="0">
                                                            <tr>
                                                                <td align="left" valign="top" style="padding-left: 10px">
                                                                    <img id="img4" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                                                    <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Investigations</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu9" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">WC Claim
                                                        Management</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu10" onclick="javascript:ShowPanel(10);" class="LeftMenuStatic">Sonic University
                                                        Training</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu11" onclick="javascript:ShowPanel(11);" class="LeftMenuStatic">New Procedures</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu12" onclick="javascript:ShowPanel(12);" class="LeftMenuStatic">Suggestions/Comments/Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu13" onclick="javascript:ShowPanel(13);" class="LeftMenuStatic">Meeting
                                                        Schedule</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <img id="img5" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                                </td>
                                                <td align="left" valign="top">
                                                    <span id="Menu14" onclick="javascript:ShowPanel(14);" class="LeftMenuStatic">Meeting
                                                        Review</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" width="80%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer" valign="top">
                                        <div id="dvEdit" runat="server" width="794px" style="overflow-x: hidden; overflow-y: scroll;">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    SLT Members
                                                </div>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 455px">
                                                    <tr id="tr_Sltmembers" runat="server">
                                                        <td align="left" valign="top" width="100%">
                                                            <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <asp:GridView ID="gvSLT_Members" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvSLT_Members_RowCommand"
                                                                            OnPageIndexChanging="gvSLT_Members_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="5%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnk1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                            CommandArgument='<%# Eval("PK_SLT_Members") %>' CommandName="EditMembers" CausesValidation="false" />
                                                                                        <asp:HiddenField ID="hdnPK_SLT_Members" runat="server" Value='<%# Eval("PK_SLT_Members") %>' />
                                                                                        <asp:HiddenField ID="hdnEmail" runat="server" Value='<%#Eval("Email") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="First Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Last Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SLT Role">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Start Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Start_Date")) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="End Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEnd_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="25%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("PK_SLT_Members") %>'
                                                                                            CommandName="EditMembers" CausesValidation="false" />
                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_SLT_Members") %>'
                                                                                            CommandName="RemoveMembers" OnClientClick="return confirm('Are you sure to remove the SLT Members record?');"
                                                                                            CausesValidation="false" />
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
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <asp:LinkButton ID="lnkSLT_MemberAdd_New" runat="server" Text="Add New" OnClick="lnkSLT_MemberAdd_New_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <span style="font-weight: bold">Yearly Member Report Grid</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Year
                                                                    </td>
                                                                    <td align="left" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="ddlYear" runat="server" SkinID="dropGen" Width="80px" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <asp:GridView ID="gvSLT_MembersBYYear" runat="server" Width="80%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvSLT_MembersBYYear_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="First Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Last Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SLT Role">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Start Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Start_Date")) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="End Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEnd_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>' />
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_SltmembersADD" runat="server" style="display: none">
                                                        <td align="left" valign="top" width="100%">
                                                            <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="14%">Member Start Date&nbsp;<span id="Span1" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="20%">
                                                                        <asp:TextBox ID="txtMembersStart_Date" runat="server"></asp:TextBox>
                                                                        <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtMembersStart_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <br />
                                                                        <asp:RegularExpressionValidator ID="revPolicy_Date" runat="server" ValidationGroup="vsErrorSLT_Members"
                                                                            Display="none" ErrorMessage="[SLT Members]/Member Start Date is not valid" SetFocusOnError="true"
                                                                            ControlToValidate="txtMembersStart_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="14%">Member End Date&nbsp;<span id="Span2" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="20%">
                                                                        <asp:TextBox ID="txtmemberEnd_date" runat="server"></asp:TextBox>
                                                                        <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtmemberEnd_date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <br />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorSLT_Members"
                                                                            Display="none" ErrorMessage="[SLT Members]/Member End Date is not valid" SetFocusOnError="true"
                                                                            ControlToValidate="txtmemberEnd_date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtmemberEnd_date"
                                                                            ControlToCompare="txtMembersStart_Date" Operator="GreaterThanEqual" Type="Date"
                                                                            ValidationGroup="vsErrorSLT_Members" ErrorMessage="[SLT Members]/Meeting End Date must be greater than or equal Start Date"
                                                                            SetFocusOnError="true" Display="None" />
                                                                        <asp:HiddenField ID="hdnSLTMember_ISNew" Value="0" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="trMemberName_Old" runat="server">
                                                                    <td align="left" valign="top">Member Name&nbsp;<span id="Span3" runat="server" style="color: Red; display: none">*</span>
                                                                        (First, Middle,Last)
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtMembersFirst_Name" runat="server" Width="150px" MaxLength="30"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtMembersMiddle_Name" runat="server" Width="150px" MaxLength="30"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtMemberLast_Name" runat="server" Width="150px" MaxLength="30"></asp:TextBox>
                                                                        <%--<asp:Button ID="btnpopupEmployee" runat="server" OnClientClick="OpenPopupEmployee();return false;"
                                                                            Text="V" />--%>
                                                                        <%--<asp:HiddenField ID="hdnPK_Employee" runat="server" />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trMemberName_New" runat="server">
                                                                    <td align="left" valign="top">Member Name&nbsp;<span id="Span3_New" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:DropDownList ID="drpFK_Employee" runat="server" OnSelectedIndexChanged="drpFK_Employee_SelectedIndexChanged" AutoPostBack="true" SkinID="dropGen" Width="225px"></asp:DropDownList>
                                                                    &nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnViewEmployee" runat="server" Text="View Employees for Location Only" OnClick="btnViewEmployee_Click" Width="225px"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Department&nbsp;<span id="Span4" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpDepartment" runat="server" Width="155px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">SLT Role&nbsp;<span id="Span5" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpSLT_Role" runat="server" Width="155px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Email Address&nbsp;<span style="color: Red">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:TextBox ID="txtMember_Email" runat="server" Width="170px" MaxLength="200"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ErrorMessage="[SLT Members]/ Email Address is not valid"
                                                                            ControlToValidate="txtMember_Email" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorSLT_Members"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rqvEmail_Address" runat="server" ErrorMessage="[SLT Members]/ Please enter Email Address"
                                                                            ControlToValidate="txtMember_Email" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorSLT_Members"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td align="left" valign="top">
                                                                        Member Location(s)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:ListBox ID="lstMember_Location" runat="server" Width="330px" SelectionMode="Multiple">
                                                                        </asp:ListBox>
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnSave_member" runat="server" Text="Save" OnClick="btnSave_member_Click"
                                                                            CausesValidation="true" ValidationGroup="vsErrorSLT_Members" />&nbsp;&nbsp;
                                                                        <asp:Button ID="btnMember_Cancel" runat="server" Text="Cancel" OnClick="btnMember_Cancel_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnSLTMembers_AuditEdit" runat="server" Text="View Audit Trail" Visible="false"
                                                                            OnClientClick="javascript:return AuditPopUpMeeting('SLTMembers');" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;" Height="455px">
                                                <div class="bandHeaderRow">
                                                    Meeting Agenda
                                                </div>
                                                <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                    <tr id="tr_Agenda_Search" runat="server" visible="true">
                                                        <td align="center" valign="top">
                                                            <table cellpadding="4" cellspacing="1" border="0" width="90%">
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="16%">
                                                                        <asp:RadioButton ID="rdbagendaFrom" runat="server" GroupName="Agenda_Search" Checked="true" />
                                                                        &nbsp;&nbsp;&nbsp; From
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="32%">
                                                                        <asp:TextBox ID="txtMeeting_Agenda_DateFrom" runat="server" Width="155px" SkinID="txtDate"></asp:TextBox>
                                                                        <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtMeeting_Agenda_DateFrom', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="revtxtMeeting_Agenda_DateFrom" runat="server"
                                                                            ValidationGroup="vsErrorScheduleSearch" Display="none" ErrorMessage="[Meeting Agenda]/From Date is not valid"
                                                                            SetFocusOnError="true" ControlToValidate="txtMeeting_Agenda_DateFrom" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="16%">To
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="32%">
                                                                        <asp:TextBox ID="txtMeeting_Agenda_DateTo" runat="server" Width="155px" SkinID="txtDate"></asp:TextBox>
                                                                        <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtMeeting_Agenda_DateTo', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="revtxtMeeting_Agenda_DateTo" runat="server" ValidationGroup="vsErrorScheduleSearch"
                                                                            Display="none" ErrorMessage="[Meeting Agenda]/To Date is not valid" SetFocusOnError="true"
                                                                            ControlToValidate="txtMeeting_Agenda_DateTo" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="cmpMeeting_Agenda" runat="server" ControlToValidate="txtMeeting_Agenda_DateTo"
                                                                            ControlToCompare="txtMeeting_Agenda_DateFrom" Operator="GreaterThanEqual" Type="Date"
                                                                            ValidationGroup="vsErrorScheduleSearch" ErrorMessage="[Meeting Agenda]/To Date must be greater than or equal From Date"
                                                                            SetFocusOnError="true" Display="None" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButton ID="rdbMeeting_AgendaYear" runat="server" GroupName="Agenda_Search" />
                                                                        &nbsp;&nbsp;&nbsp; In Year
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpMeeting_AgendaYear" runat="server" Width="160px" SkinID="dropGen" runnat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">Month
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpMeeting_AgendaMonth" runat="server" Width="160px" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_Agenda_grid" runat="server" visible="false">
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvMeeting" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="gvMeeting_PageIndexChanging" AllowSorting="True"
                                                                OnRowCommand="gvMeeting_RowCommand" OnRowDataBound="gvMeeting_RowDataBound" OnSorting="gvMeeting_Sorting"
                                                                OnRowCreated="gvMeeting_RowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnk1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="EditMeeting" CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule") %>'
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Scheduled Meeting Date" DataField="Scheduled_Meeting_Date" SortExpression="Scheduled_Meeting_Date"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Date Meeting Minutes Sent" DataField="Date_Meeting_Minutes_Sent"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:TemplateField HeaderText="Actual Meeting Date" SortExpression="Actual_Meeting_Date">
                                                                        <ItemStyle Width="14%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblActual_Meeting_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Meeting_Date")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number Of Members Present">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNum_Present" runat="server" Text='<%#Eval("Num_Present") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SLT Score" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSLT_RLCM_SCORE" runat="server" Text='<%#Eval("Score") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderText="Email / Print">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMail" runat="server" Text="Mail" CausesValidation="false"
                                                                                CommandName="Mail" CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule") %>' />
                                                                            &nbsp;&nbsp;<asp:LinkButton ID="lnkPrint" runat="server" Text="Print" CommandName="Print"
                                                                                CausesValidation="false" CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="RemoveRecord"
                                                                                CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule") %>'
                                                                                OnClientClick="return confirm('Are you sure to remove the meeting agenda record?');"
                                                                                CausesValidation="false" />
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
                                                            <br />
                                                            <asp:LinkButton ID="lnkAddMeeting" runat="server" Text="Add New" OnClientClick="javascript:return CheckSLT_Member();"
                                                                OnClick="lnkAddMeeting_Click"></asp:LinkButton>
                                                            <asp:Button ID="btnSendMailAgenda" runat="server" Style="display: none" OnClick="btnSendMailAgenda_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:Button ID="btnAgendaSearch" runat="server" Text="Search" OnClick="btnAgendaSearch_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorScheduleSearch" />
                                                            <asp:Button ID="btnAgenda_Cancel" runat="server" Text="Search" OnClick="btnAgenda_Cancel_Click"
                                                                Visible="false" />
                                                            &nbsp;&nbsp;<asp:Button ID="btnAdd_NewAgenda" runat="server" Text="Add New" OnClientClick="javascript:return CheckSLT_Member();"
                                                                OnClick="lnkAddMeeting_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td><b>Employee Details who Signed up for Training but have not completed yet :</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Year : 
                                                            <asp:DropDownList ID="ddlEmployeeSignedupYear" runat="server" Width="160px" SkinID="dropGen" runnat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeeSignedupYear_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr4" runat="server">
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvEmployeeSignedUp" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="7" AllowPaging="true" OnPageIndexChanging="gvEmployeeSignedUp_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status Description">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatusDescription" runat="server" Text='<%#Eval("StatusDescription") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="EnrollmentDate">
                                                                        <ItemStyle Width="12%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEnrollmentDate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("EnrollmentDate")) %>' />
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Meeting Attendees
                                                </div>
                                                <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Scheduled Meeting Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:Label ID="lblScheduled_Meeting_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Actual Meeting Date&nbsp;<span id="Span6" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:TextBox ID="txtActual_Meeting_Date" runat="server" Width="160px"></asp:TextBox>
                                                            <div style="display: none">
                                                                <asp:TextBox ID="txtCurrent_Date" runat="server"></asp:TextBox>
                                                            </div>
                                                            <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActual_Meeting_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorAttendees"
                                                                Display="none" ErrorMessage="[Meeting Attendees]/Actual Meeting Date is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtActual_Meeting_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmvDateofBirth" runat="server" ControlToValidate="txtActual_Meeting_Date"
                                                                ValidationGroup="vsErrorAttendees" SetFocusOnError="true" ErrorMessage="[Meeting Attendees]/Actual Meeting Date can not be Greater Than Today's Date"
                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrent_Date" Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <%--<div style="width: 800px;overflow-x:scroll;overflow-y:hidden;" id="divAttendees"
                                                                runat="server">--%>
                                                            <asp:GridView ID="gv_MeetingAttendees" runat="server" PageSize="10" Width="100%"
                                                                EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gv_MeetingAttendees_PageIndexChanging"
                                                                OnRowDataBound="gv_MeetingAttendees_DataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="First Name">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                                                            <asp:HiddenField ID="hdnPK_SLT_Members" runat="server" Value='<%#Eval("PK_SLT_Members") %>' />
                                                                            <%--<asp:HiddenField ID="hdnPK_SLT_Meeting_Attendees" runat="server" Value='<%#Eval("PK_SLT_Meeting_Attendees") %>' />--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SLT Role">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Present">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:RadioButtonList ID="rdbPresent" runat="server" SkinID="YesNoType">
                                                                            </asp:RadioButtonList>
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
                                                            <%--</div>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">RLCM In Attendance?
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:RadioButtonList ID="rdoRLCM_Attendance" runat="server" SkinID="YesNoType" TabIndex="7" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center" valign="top">
                                                            <asp:Button ID="btnAttendeesSave" runat="server" Text="Save" CausesValidation="true"
                                                                ValidationGroup="vsErrorAttendees" OnClick="btnAttendeesSave_Click" />
                                                            <asp:Button ID="btnCancelAttendees" runat="server" Text="Cancel" OnClick="btnCancelAttendees_Click" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnMeetingAttendees" runat="server" Text="View Audit Trail" Visible="false"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('SLTSchedule');" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Call to Order
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Meeting Start Time&nbsp;<span id="Span7" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtMeeting_Start_Time" runat="server" Width="70px" MaxLength="5" />
                                                            <asp:RegularExpressionValidator ID="revtxtMeeting_Start_Time" runat="server" ControlToValidate="txtMeeting_Start_Time"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[Call to Order]/Meeting Start Time is not valid." Display="none"
                                                                ValidationGroup="vsErrorcallToOrder" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                            &nbsp;&nbsp;<asp:DropDownList ID="ddlMeeting_Start_Time_AM" SkinID="dropGen" runat="server"
                                                                Width="30%">
                                                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Meeting End Time&nbsp;<span id="Span8" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtMeeting_End_Time" runat="server" Width="70px" MaxLength="5" />
                                                            <asp:RegularExpressionValidator ID="RevtxtMeeting_End_Time" runat="server" ControlToValidate="txtMeeting_End_Time"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="[Call to Order]/Meeting End Time is not valid." Display="none"
                                                                ValidationGroup="vsErrorcallToOrder" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                            &nbsp;&nbsp;<asp:DropDownList ID="ddlMeeting_End_Time_AM" SkinID="dropGen" runat="server"
                                                                Width="30%">
                                                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Previous Meeting Reviewed and Approved
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoPrev_Meeting_Review" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Safety Board Updated?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoSafety_Board_Updated" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                <asp:Panel ID="pnl16" runat="server">
                                                    <div class="bandHeaderRow">
                                                        Safety Walk
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Monthly Safety Walk Completed
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:RadioButtonList ID="rdoSafety_Walk_Comp" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Date Completed&nbsp;<span id="Span9" runat="server" style="color: Red; display: none">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:TextBox ID="txtSafety_Walk_Comp_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSafety_Walk_Comp_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revSafety_Walk_Comp_Date" runat="server" ValidationGroup="vsErrorSafetywalkGroup"
                                                                    Display="none" ErrorMessage="[Safety Walk]/Date Completed is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtSafety_Walk_Comp_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorSafetywalkGroup"
                                                                    Display="none" ErrorMessage="[Safety Walk]/Date Completed is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtSafety_Walk_Comp_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Monthly Safety Walk Completed by the following SLT Members
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:GridView ID="gvSafetyWalk" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    AllowPaging="true" PageSize="10" EmptyDataText="No Record Found" OnPageIndexChanging="gvSafetyWalk_PageIndexChanging"
                                                                    OnRowDataBound="gvSafetyWalk_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="First Name" DataField="First_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="Last Name" DataField="Last_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="SLT Role" DataField="SLT_Role" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:TemplateField HeaderText="Participated">
                                                                            <ItemTemplate>
                                                                                <asp:RadioButtonList ID="rdoParticipated" runat="server" SkinID="YesNoType" />
                                                                                <asp:HiddenField ID="hdnFK_SLT_Member" runat="server" Value='<%# Eval("PK_SLT_Members") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <hr size="1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6">
                                                                <b>Departments Reviewed</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Sales
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoSales_Reviewed" runat="server" SkinID="YesNoType" onclick="ShowHideComments(this.id,'Sales');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoSales_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trSales" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtSales_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parts
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoParts_Reviewed" runat="server" SkinID="YesNoType" onclick="ShowHideComments(this.id,'Parts');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoParts_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trParts" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtParts_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Service Facility
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoService_Facility_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideComments(this.id,'Service');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoService_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trService" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtService_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Body Shop
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBody_Shop_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideComments(this.id,'Body_Shop');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBody_Shop_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBody_Shop" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBody_Shop_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Business Office
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBus_Off_Reviewed" runat="server" SkinID="YesNoType" onclick="ShowHideComments(this.id,'Business');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBus_Off_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBusiness" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBus_Off_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Detail Area
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoDetail_Area_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideComments(this.id,'DetailArea');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoDetail_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trDetailArea" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtDetail_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Car Wash
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoCar_Wash_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideComments(this.id,'CarWash');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoCar_Wash_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trCarWash" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtCar_Wash_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parking Lot
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoParking_Lot_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideComments(this.id,'Parking');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoParking_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trParking" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtParking_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left">
                                                                <b>Safety Walk Attachments</b><br />
                                                                <i>Click to view details</i>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:GridView ID="gvSafetywalkAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvSafetywalkAttachmentDetails_RowDataBound"
                                                                    OnRowCommand="gvSafetywalkAttachmentDetails_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="File Name">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <a id="lnkSaftywalkAttachFile" runat="server" href="#">
                                                                                    <%# Eval("Attachment_Name1")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <%# Eval("Attachment_Description")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="30%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Name") %>'
                                                                                    CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove the Attachment?');" />
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
                                                                <asp:LinkButton ID="lnlADDAttachmentSafetywalk" runat="server" CausesValidation="true"
                                                                    Text="Add New" ValidationGroup="vsErrorSafetywalkGroup" OnClientClick="javascript:CheckBeforeAddSaftyWalkAttach();return false;"></asp:LinkButton>
                                                                <%--<input type="hidden" id="hdnBuildingID" runat="server" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr id="trSafetyWalkAttachment" runat="server" style="display: none;">
                                                            <td align="left" colspan="6">
                                                                <uc:ctrlAttachment runat="server" ID="SafetywalkAttachment" OnFileSelection="Upload_SaftyWalk_Attachment" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center">
                                                                <asp:Button ID="btnSave_SafetyWalk" runat="server" Text="Save" CausesValidation="true"
                                                                    ValidationGroup="vsErrorSafetywalkGroup" OnClick="btnSaveNnextSafety_Click" />
                                                                &nbsp;&nbsp;<asp:Button ID="btnView_auditSafetyWalk" runat="server" Text="View Audit Trail"
                                                                    OnClientClick="javascript:return AuditPopUpMeeting('SLTSafetyWalk');" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl15" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td class="bandHeaderRow">
                                                                <asp:Label ID="lblSLTWalk" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="min-height: 302px;">
                                                                    <asp:GridView ID="gvSLTSafetyWalk" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                        EmptyDataText="No Record Found" OnRowCommand="gvSLTSafetyWalk_RowCommand" OnRowDataBound="gvSLTSafetyWalk_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Month" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnMonthNumber" runat="server" Value='<%# Eval("MonthNum") %>' />
                                                                                    <asp:HiddenField ID="hdnActualMeetingDate" runat="server" Value='<%# Eval("Actual_Meeting_Date") %>' />
                                                                                    <asp:HiddenField ID="hdnSafety_Walk_Comp" runat="server" Value='<%# Convert.ToBoolean(Eval("Safety_Walk_Comp")) %>' />
                                                                                    <asp:HiddenField ID="hdnPK_SLT_Safety_Walk" runat="server" Value='<%# Eval("PK_SLT_Safety_Walk") %>' />
                                                                                    <asp:HiddenField ID="hdnPK_SLT_Meeting_Schedule" runat="server" Value='<%# Eval("PK_SLT_Meeting_Schedule") %>' />
                                                                                    <%# Eval("Month") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Focus Area" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Focus_Area") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Monthly Safety Walk Completed?" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButtonList ID="rdoParticipated" runat="server" SkinID="YesNoType" Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date Completed" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtCompletedDate" runat="server" Width="80px" SkinID="txtDate" Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>' Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Safety_Walk_Comp_Date")) %>' />
                                                                                    <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="../../Images/iconPicDate.gif" ImageAlign="Middle" Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>' OnClientClick="javascript:return false;" />
                                                                                    <cc1:CalendarExtender ID="calCompletedDate" runat="server" TargetControlID="txtCompletedDate" PopupButtonID="imgbtn"></cc1:CalendarExtender>
                                                                                    <asp:RegularExpressionValidator ID="revDate_Completed_Inspection" runat="server"
                                                                                        ValidationGroup="vsErrorInspectionGroup" Display="none" ErrorMessage="Date Completed is not a valid date"
                                                                                        SetFocusOnError="true" ControlToValidate="txtCompletedDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Safety Walk Participation" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkParticipation" runat="server" Text="Participants" CommandName="Participation"
                                                                                        CommandArgument='<%#Eval("MonthNum") + ":" + Eval("PK_SLT_Safety_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'></asp:LinkButton>
                                                                                    <%--<asp:HyperLink ID="SafetyWalkParticipation" runat="server" Text="Participants"></asp:HyperLink>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Observations Open" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkObservationOpen" runat="server" Text='<%# Eval("Observations_Open") %>' CommandName="ObservationOpen"
                                                                                        CommandArgument='<%#Eval("Month") + ":" + Eval("PK_SLT_Safety_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'>
                                                                                    </asp:LinkButton>
                                                                                    <%--<asp:HyperLink ID="ObservationsOpen" runat="server" Text='<%# Eval("Observations_Open") %>'></asp:HyperLink>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center">
                                                                <asp:Button ID="btnSave_SLTSafety" runat="server" Text="Save" OnClick="btnSave_SLTSafety_Click" Visible="false" />
                                                                &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="View Audit Trail"
                                                                    OnClientClick="javascript:return AuditPopUpMeeting('SLTSafetyWalk');" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Button ID="btnhdnReload" runat="server" OnClick="btnhdnReload_Click" Style="display: none;" />
                                                    <asp:Button ID="btnReload_Participant" runat="server" OnClick="btnReload_Participant_Click" Style="display: none;" />
                                                </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Quarterly Facility Inspection
                                                </div>
                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Year
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpYearInspection" runat="server" SkinID="dropGen" Width="150px"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpYearInspection_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Dealership PlayBook Score
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblInspectionScore" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <%--                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Quarterly Results
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoInspectionQuarters" runat="server" RepeatDirection="Horizontal"
                                                                AutoPostBack="true" OnSelectedIndexChanged="rdoInspectionQuarters_SelectedIndexChanged">
                                                                <asp:ListItem Text="Q1" Value="1" Selected="True" />
                                                                <asp:ListItem Text="Q2" Value="2" />
                                                                <asp:ListItem Text="Q3" Value="3" />
                                                                <asp:ListItem Text="Q4" Value="4" />
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:GridView ID="gvInspection" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                AllowPaging="true" PageSize="6" AutoGenerateColumns="false" ShowHeader="true"
                                                                OnPageIndexChanging="gvInspection_PageIndexChanging" OnRowCommand="gvInspection_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInspection" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandArgument='<%# Container.DataItemIndex + "," + Eval("PK_Inspection_ID")  %>'
                                                                                CommandName="ViewDetails" />
                                                                            <input type="hidden" id="hdnDeficiencies" runat="server" value='<%#Eval("Deficiencies") %>' />
                                                                            <input type="hidden" id="hdnDeficienciesNotCompleted" runat="server" value='<%#Eval("Deficiencies_NotCompleted") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspector Name">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInspectorName" runat="server" Text='<%#Eval("Inspector_Name")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspection Date">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInspectionDate" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Date")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of Deficiencies">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDateCompleted" runat="server" Text='<%# Eval("Deficiencies") %>' />
                                                                            <asp:HiddenField ID="hdnPK_Inspection_ID" runat="server" Value='<%#Eval("PK_Inspection_ID") %>' />
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
                                                    <tr>
                                                        <td align="left" valign="top">Inspector Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInspectorName" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Inspection Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInspectionDate" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Number of Deficiencies
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDeficiencies" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Number of Deficiencies Not Completed
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDeficienciesNotCompleted" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:GridView ID="gvInspection_responses" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                AutoGenerateColumns="false" ShowHeader="true" OnRowCommand="gvInspection_responses_RowCommand"
                                                                AllowPaging="true" PageSize="6" OnPageIndexChanging="gvInspection_responses_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInspection_Responses" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandArgument='<%# Eval("PK_Inspection_Responses_ID") %>' CommandName="ViewDetails" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Focus Area">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFocusArea" runat="server" Text='<%#Eval("Item_Number_Focus_Area")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Question">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQuestion_Text" runat="server" Text='<%# Eval("Question_Text")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Opened">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_opened" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Date_Opened")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Days Open">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldays_opened" runat="server" Text='<%# Eval("Days_Opened") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Target Completion Date">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTarget_Completion_Date" runat="server" Text='<%# Eval("Target_Completion_Date")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInspection_response_View" runat="server" Text="View" CommandArgument='<%# Eval("PK_Inspection_Responses_ID") %>'
                                                                                CommandName="ViewDetails" />
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
                                                    <tr>
                                                        <td align="left" valign="top">Focus Area
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResponse_FocusArea" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Deficiency
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResponse_Deficiency" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 10px">
                                                                        <asp:Label ID="lblQuestion_NumberEdit" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuestionTextEdit" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Spacer" style="height: 5px;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="left">
                                                                        <table cellpadding="2" cellspacing="1" border="0" width="100%">
                                                                            <tr>
                                                                                <td width="3%" valign="top" align="left">
                                                                                    <img id="imgGuidanceplusedit" runat="server" src="../../Images/plus.jpg" alt="" onclick="showPanelIncident(this.id);" />
                                                                                    <img id="imgGuidanceminusedit" runat="server" src="../../Images/minus.jpg" alt=""
                                                                                        onclick="HidePaneIncident(this.id);" style="display: none" />
                                                                                </td>
                                                                                <td valign="top" align="left">Guidance
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Spacer" style="height: 5px;"></td>
                                                                </tr>
                                                                <tr id="trGuidanceText" runat="server" style="display: none">
                                                                    <td width="100%" style="padding-left: 20px">
                                                                        <asp:Label ID="lblGuidance_Text" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Spacer" style="height: 5px;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <table cellpadding="3" cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td width="18%" align="left" valign="top">Repeat Deficiency?
                                                                                </td>
                                                                                <td width="4%" align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblRepeated_Deficiency" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="18%" align="left" valign="top">Department
                                                                                </td>
                                                                                <td width="4%" align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top" colspan="4">
                                                                                    <asp:DataList ID="rptDepartment" runat="server" Width="100%" RepeatColumns="3">
                                                                                        <ItemTemplate>
                                                                                            <table cellpadding="2" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td width="60%" align="left">
                                                                                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                                                                        <input type="hidden" id="hdnDeptID" runat="server" value='<%#Eval("PK_LU_Department_ID") %>' />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="lblValue" runat="server" Text="No" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">Date Opened
                                                                                </td>
                                                                                <td align="center">:
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:Label ID="lblResponse_Date_Opned" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="left" width="18%">Days Open
                                                                                </td>
                                                                                <td align="center" width="4%">:
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:Label ID="lblDays_Open" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">Corrective Action:
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <uc:ctrlMultiLineTextBox ID="lblAction" runat="server" ControlType="Label" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">Target Completion Date
                                                                                </td>
                                                                                <td align="center">:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblTargetCompletion_date" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="left">Actual Completion Date
                                                                                </td>
                                                                                <td align="center">:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblActual_completion_Date" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">Notes:
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Assigned To&nbsp;<span id="Span10" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_SLT_Members" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Completed&nbsp;<span id="Span11" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Completed_Inspection" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Completed_Inspection', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Completed_Inspection" runat="server"
                                                                ValidationGroup="vsErrorInspectionGroup" Display="none" ErrorMessage="[Quarterly Facility Inspection]/Date Completed is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Completed_Inspection" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span12" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments_Inspection" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">RLCM Notified
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoRLCM_Notified" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnInspection_Save" runat="server" Text="Save" OnClick="btnInspection_Save_Click"
                                                                ValidationGroup="vsErrorInspectionGroup" Enabled="false" />
                                                            <asp:Button ID="btnInspectionAudit_Edit" runat="server" Text="View Audit Trail" Visible="false"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('QuarterlyInspections');" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7" runat="server" Style="display: none;">
                                                <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                    <tr>
                                                        <td align="left" valign="top" class="bandHeaderRow" width="100%">
                                                            <asp:Label ID="lblHeading" runat="server" Text="Incident Investigation"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trDealers" runat="server">
                                                        <td>
                                                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tr id="trDealership" runat="server" visible="true">
                                                                    <td align="left" width="19%">Dealership Playbook Score
                                                                    </td>
                                                                    <td align="center" width="1%">:&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" colspan="5" width="20%">
                                                                        <asp:Label ID="lblDealerShip" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" width="17%">Year
                                                                    </td>
                                                                    <td align="center" width="3%">:&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" width="20%">
                                                                        <asp:DropDownList ID="ddlYearIncident" runat="server" Width="80px" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddlYearIncident_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tr>
                                                                    <td width="15%"></td>
                                                                    <td align="right" width="16%">
                                                                        <%--   Month&nbsp;--%>
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
                                                    <tr id="trIncident_Review_Grid" runat="server">
                                                        <td align="left">
                                                            <div style="color: White; font-weight: bold; width: 90%; background-color: #7f7f7f; float: left; height: 20px; text-align: center; font-size: 13px;">
                                                                Sonic Cause Code
                                                            </div>
                                                            <asp:GridView ID="gvIncidentGrid" ShowFooter="true" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                OnRowDataBound="gvIncidentGrid_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Month
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("Month_Name")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle BackColor="#7f7f7f" Font-Bold="True" Width="15%" ForeColor="White" />
                                                                        <FooterTemplate>
                                                                            Yearly Total
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-1
                                                                                        <br />
                                                                                        S0-1
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S1")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS1" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-2
                                                                                        <br />
                                                                                        S0-2
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S2")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS2" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-3
                                                                                        <br />
                                                                                        S0-3
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S3")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS3" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-4
                                                                                        <br />
                                                                                        S0-4
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S4")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS4" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-5
                                                                                        <br />
                                                                                        S0-5
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S5")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS5" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Monthly Total
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("Monthly_Total")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10%" />
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblMonthly_Total" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <%--<table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="7">
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<cc1:IncidentReview ID="Incident_Review" runat="server" Incident_ReviewType="Review" />--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8" runat="server" Style="display: none;">
                                                <cc1:IncidentReview ID="IncidentReview_WC" runat="server" Incident_ReviewType="WC"
                                                    OnIncidentReview="BindIncidentReviewGrid" OnUpdateSLTScore="UpdateSLTScore" />
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    WC Claim Management
                                                </div>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Dealership Playbook Score
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:Label ID="lblDealershipScore" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top" width="4%">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top" width="24%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:GridView ID="gvClaim_management" runat="server" Width="100%" AllowPaging="true"
                                                                PageSize="8" AutoGenerateColumns="false" OnPageIndexChanging="gvClaim_management_PageIndexChanging"
                                                                OnRowCommand="gvClaim_management_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnk1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandArgument='<%# Eval("PK_Workers_Comp_Claims_ID") %>' CommandName="editClaim"
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClaim_Number" runat="server" Text='<%# Eval("Origin_Claim_Number") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Incident">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_Of_Incident" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Accident")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Reported To Sedgewick">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_Reported_ToSed" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Reported_To_Insurer")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lag Time">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbllagTime" runat="server" Text='<%# Eval("Lag_Time") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Status">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClaim_Status" runat="server" Text='<%# Eval("Claim_Status") %>'></asp:Label>
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
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Claim Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClaim_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Associate Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClaimant_name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Date Of incident
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_of_incident" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Reported to Sedgwick
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_reported" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Lag Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLagtime" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Claim Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClaim_Status" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cause/Injury/Body Part Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="lblCause_injury_desc" runat="server" ControlType="Label" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Please Explain If Lag Time Is Greater Than 3 Days&nbsp;<span id="Span13" runat="server"
                                                            style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="txtLag_explaination" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What is the associates current Status&nbsp;<span id="Span14" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpAssociates_Status" runat="server" SkinID="dropGen" Width="165px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">If in a modified Light Duty Position Explain&nbsp;<span id="Span15" runat="server"
                                                            style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="txtLight_Duty" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span16" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top" colspan="6">
                                                            <asp:Button ID="btnSaveClaimmanagement" runat="server" Text="Save" Enabled="false"
                                                                CausesValidation="true" ValidationGroup="vsErrorClaimManagement" OnClick="btnSaveClaimmanagement_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl10" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Sonic University Training
                                                </div>
                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="18%" align="left" valign="top">Dealership Playbook Score
                                                        </td>
                                                        <td width="4%" align="center" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblTrainingScore" runat="server" />
                                                        </td>
                                                        <td width="18%" align="left" valign="top">Year
                                                        </td>
                                                        <td width="4%" align="center" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpTrainingYear" runat="server" SkinID="dropGen" Width="100px"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpTrainingYear_SelectedIndexChanged" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">
                                                            Location Status
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpLocationStatus" runat="server" Width="175px" SkinID="dropGen"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpLocationStatus_SelectedIndexChanged" />
                                                        </td>
                                                        <td colspan="3">
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">Q1
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ1" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Q2
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ2" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Q3
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ3" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Q4
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ4" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Quarterly Training Conducted by RLCM
                                                </div>
                                                <table cellpadding="4" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <asp:GridView ID="gvQuarterly_TrainingConducted_ByRLCM" runat="server" Width="100%"
                                                                AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowDataBound="gvQuarterly_TrainingConducted_ByRLCM_OnRowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkQualityTraining" runat="server" Text='<%# Eval("Quarter") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Focus">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFocus" runat="server" Text='<%# Eval("Focus") %>' CssClass="TextClip"
                                                                                Width="150px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Topic">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTopic" runat="server" Text='<%# Eval("Topic") %>' CssClass="TextClip"
                                                                                Width="150px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Scheduled">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Scheduled" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Scheduled")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Completed">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Completed" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Completed")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reason Not Completed">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReason_Not_Completed" runat="server" Text='<%# Eval("Reason_Not_Completed") %>'
                                                                                CssClass="TextClip" Width="200px" />
                                                                            <asp:HiddenField ID="hdnPK_SLT_Training_RLCM" runat="server" Value='<%# Eval("PK_SLT_Training_RLCM") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Training Suggestions
                                                </div>
                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <asp:GridView ID="gvTrainingSuggestions" runat="server" Width="98%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Found" AllowPaging="true" PageSize="3" OnRowCommand="gvTrainingSuggestions_RowCommand"
                                                                OnPageIndexChanging="gvTrainingSuggestions_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTrainSuggestion" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_SLT_Training") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Training Description" DataField="Training_Description"
                                                                        ItemStyle-Width="30%" />
                                                                    <asp:BoundField HeaderText="Desired Completion Date" DataField="Desired_Comp_Date"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="30%" />
                                                                    <asp:BoundField HeaderText="Completed" DataField="Completed" ItemStyle-Width="15%" />
                                                                    <asp:BoundField HeaderText="Date Completed" DataField="Date_Completed" DataFormatString="{0:MM/dd/yyyy}"
                                                                        ItemStyle-Width="15%" />
                                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTrainingDelete" runat="server" Text="Delete" CommandName="DeleteDetails"
                                                                                CommandArgument='<%# Eval("PK_SLT_Training") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="lnkAddNewTrainingSuggestion" runat="server" Text="Add New" OnClick="lnkAddNewTrainingSuggestion_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Type/Description of Training&nbsp;<span id="Span17" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtTraining_Description" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Desired Date to Have Training Completed&nbsp;<span id="Span18" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDesired_Comp_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Desired Date to Have Training Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDesired_Comp_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDesired_Comp_Date" runat="server" ValidationGroup="vsErrorTrainingGroup"
                                                                Display="none" ErrorMessage="[Training Suggestions]/Desired Date to Have Training Completed is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDesired_Comp_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Completed
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Date Completed&nbsp;<span id="Span19" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Completed_Training" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Completed_Training', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Completed_Training" runat="server" ValidationGroup="vsErrorTrainingGroup"
                                                                Display="none" ErrorMessage="[Training Suggestions]/Date Completed is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Completed_Training" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span20" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments_Training" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:LinkButton ID="lnkAssociateSafetyCertificationTraining" Text="Associate Safety Certification Training" OnClientClick="OpenPopup(); return false;" runat="server"></asp:LinkButton><br />
                                                            <i>Click to view details</i>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <b>SABA Weekly Training Report Attachments</b><br />
                                                            <i>Click to view details</i>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:GridView ID="gvSLT_TrainingAttachment" runat="server" Width="100%" OnRowDataBound="gvSLT_TrainingAttachment_RowDataBound"
                                                                OnRowCommand="gvSLT_TrainingAttachment_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="File Name">
                                                                        <ItemStyle Width="35%" />
                                                                        <ItemTemplate>
                                                                            <a id="lnkTrainingAttachFile" runat="server" href="#">
                                                                                <%# Eval("Attachment_Name1")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="35%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Attachment_Description")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Name") %>'
                                                                                CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove the Attachment?');" />
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
                                                            <a href="javascript:CheckBeforeAddTrainingAttach();">Add New</a>
                                                            <%--<input type="hidden" id="hdnBuildingID" runat="server" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_training_Attachment" runat="server" style="display: none;">
                                                        <td align="left" colspan="6">
                                                            <uc:ctrlAttachment runat="server" ID="SLT_TrainingAttachmentADD" OnFileSelection="Upload_Training_Attachment" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="6">
                                                            <asp:Button ID="btnSaveTrainingSuggestion" runat="server" Text="Save" OnClick="btnSaveTrainingSuggestion_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorTrainingGroup" />
                                                            &nbsp;&nbsp;
                                                            <asp:Button ID="btnTrainigAudit_Edit" runat="server" Text="View Audit Trail" Visible="false"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('SLTTraining');" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl11" runat="server" Style="display: none;" Height="540px">
                                                <div class="bandHeaderRow">
                                                    New Procedures
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr id="tr_proceduregrid" runat="server">
                                                        <td width="100%">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Year
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:DropDownList ID="drpProcedureYear" Width="175px" runat="server" SkinID="dropGen"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="drpProcedureYear_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td colspan="3">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="6">
                                                                        <asp:GridView ID="gvNewProcedures" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="3" OnPageIndexChanging="gvNewProcedures_PageIndexChanging"
                                                                            EmptyDataText="No Record Found" OnRowCommand="gvNewProcedures_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkProcedure" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_SLT_New_Procedure") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Assigned To" DataField="Assigned_To" ItemStyle-Width="16%"
                                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Importance" DataField="Importance" ItemStyle-Width="14%"
                                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Procedure Source" DataField="Procedure_Source" ItemStyle-Width="16%"
                                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Target Completion Date" DataField="Target_Completion_Date"
                                                                                    DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="26%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Date Completed" DataField="Date_Completed" ItemStyle-Width="15%"
                                                                                    DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:TemplateField ItemStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkProcedureDelete" runat="server" Text="Delete" CommandName="DeleteDetails"
                                                                                            CommandArgument='<%# Eval("PK_SLT_New_Procedure") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="left">
                                                                        <asp:LinkButton ID="lnkAddNewProcedure" runat="server" Text="Add New" OnClientClick="javascript:return CheckScheduleid();"
                                                                            OnClick="lnkAddNewProcedure_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <hr />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_procedureAdd" runat="server" style="display: none">
                                                        <td width="100%">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Importance&nbsp;<span id="Span21" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Importance" Width="175px" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">Procedure Source&nbsp;<span id="Span22" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Procedure_Source" Width="175px" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Procedure Description&nbsp;<span id="Span23" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtProcedure_Description" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Action Item&nbsp;<span id="Span24" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAction_Item" runat="server" Width="170px" MaxLength="30" />
                                                                    </td>
                                                                    <td align="left" valign="top">Assigned To&nbsp;<span id="Span25" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpProcedureAssignet_to" runat="server" SkinID="dropGen" Width="175px">
                                                                        </asp:DropDownList>
                                                                        <%--<asp:TextBox ID="txtAssigned_To" runat="server" Width="170px" MaxLength="30" />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Target Completion Date&nbsp;<span id="Span26" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTarget_Completion_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                        <img alt="Target Completion Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTarget_Completion_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="revTarget_Completion_Date" runat="server" ValidationGroup="vsErrorProcedure"
                                                                            Display="none" ErrorMessage="[New Procedures]/Target Completion Date is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtTarget_Completion_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">Date Completed&nbsp;<span id="Span27" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtDate_Completed" runat="server" Width="150px" SkinID="txtDate" />
                                                                        <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Completed', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="revDate_Completed" runat="server" ValidationGroup="vsErrorProcedure"
                                                                            Display="none" ErrorMessage="[New Procedures]/Date Completed is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtDate_Completed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Status&nbsp;<span id="Span28" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Item_Status" Width="175px" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center" valign="top">
                                                                        <asp:Button ID="btnSaveProcedure" runat="server" CausesValidation="true" ValidationGroup="vsErrorProcedure"
                                                                            Text="Save" OnClick="btnSaveProcedure_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnCancelProcedure" runat="server" Text="Cancel" OnClick="btnCancelProcedure_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnNewProcedureAudit_Edit" runat="server" Text="View Audit Trail"
                                                                            Visible="false" OnClientClick="javascript:return AuditPopUpMeeting('New_Procedure');" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl12" runat="server" Style="display: none;" Height="520px">
                                                <div class="bandHeaderRow">
                                                    Suggestions/Comments/Notes
                                                </div>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr id="tr_suggestiongrid" runat="server">
                                                        <td width="100%">
                                                            <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="6">
                                                                        <asp:GridView ID="gvSuggestions" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            AllowPaging="true" PageSize="3" OnPageIndexChanging="gvSuggestions_PageIndexChanging"
                                                                            EmptyDataText="No Record Found" OnRowCommand="gvSuggestions_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkSuggestion" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_SLT_Suggestion") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Assigned To" DataField="Assigned_To" ItemStyle-Width="16%"
                                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Suggestion Source" DataField="Suggestion_Source" ItemStyle-Width="19%"
                                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Importance" DataField="Importance" ItemStyle-Width="14%"
                                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Target Completion Date" DataField="Target_Completion_Date"
                                                                                    DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField HeaderText="Date Completed" DataField="Date_Completed" ItemStyle-Width="18%"
                                                                                    DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:TemplateField ItemStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkProcedureDelete" runat="server" Text="Delete" CommandName="DeleteDetails"
                                                                                            CommandArgument='<%# Eval("PK_SLT_Suggestion") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="left">
                                                                        <asp:LinkButton ID="lnkAdd_NewSuggestion" runat="server" Text="Add New" OnClientClick="javascript:return CheckScheduleid();"
                                                                            OnClick="lnkAdd_NewSuggestion_Click" />
                                                                    </td>
                                                                </tr>
                                                                
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_suggestionadd" runat="server" style="display: none">
                                                        <td>
                                                            <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <hr />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Assigned To&nbsp;<span id="Span29" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:DropDownList ID="DrpAssigned_To_Sugg" runat="server" SkinID="dropGen" Width="175px">
                                                                        </asp:DropDownList>
                                                                        <%--<asp:TextBox ID="txtAssigned_To_Sugg" runat="server" Width="170px" MaxLength="30" />--%>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">Suggestion Source&nbsp;<span id="Span30" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Suggestion_Source" Width="175px" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Importance&nbsp;<span id="Span31" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Importance_Sugg" Width="175px" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">Target Completion Date&nbsp;<span id="Span32" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtTarget_Completion_Date_Sugg" runat="server" Width="150px" SkinID="txtDate" />
                                                                        <img alt="Target Completion Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTarget_Completion_Date_Sugg', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="revTarget_Completion_Date_Sugg" runat="server"
                                                                            ValidationGroup="vsErrorSuggestion" Display="none" ErrorMessage="[Suggestions]/Target Completion Date is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtTarget_Completion_Date_Sugg" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Suggestion/Comments/Other&nbsp;<span id="Span33" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSuggestion_Description" runat="server"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Action Item&nbsp;<span id="Span34" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAction_Item_Sugg" runat="server" Width="170px" MaxLength="30" />
                                                                    </td>
                                                                    <td align="left" valign="top">Date Completed&nbsp;<span id="Span35" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtDate_Completed_Sugg" runat="server" Width="150px" SkinID="txtDate" />
                                                                        <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Completed_Sugg', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="revDate_Completed_Sugg" runat="server" ValidationGroup="vsErrorSuggestion"
                                                                            Display="none" ErrorMessage="[Suggestions]/Date Completed is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtDate_Completed_Sugg" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Status&nbsp;<span id="Span36" runat="server" style="color: Red; display: none">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpFK_LU_Item_Status_Sugg" Width="175px" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td align="left" valign="top">Notes
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSuggestion_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center" valign="top">
                                                                        <asp:Button ID="btnSaveSuggestion" runat="server" CausesValidation="true" ValidationGroup="vsErrorSuggestion"
                                                                            Text="Save" OnClick="btnSaveSuggestion_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnCancelSuggestion" runat="server" Text="Cancel" OnClick="btnCancelSuggestion_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnSuggestionAudit_Edit" runat="server" Text="View Audit Trail" Visible="false"
                                                                            OnClientClick="javascript:return AuditPopUpMeeting('SLTSuggestion');" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl13" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Meeting Schedule
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6">
                                                            <br />
                                                            Next Scheduled Meeting Date<br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date&nbsp;<span id="Span37" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtScheduled_Meeting_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtScheduled_Meeting_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revScheduled_Meeting_Date" runat="server" ValidationGroup="vsErrorSchedule"
                                                                Display="none" ErrorMessage="[Meeting Schedule]/Date is not a valid date." SetFocusOnError="true"
                                                                ControlToValidate="txtScheduled_Meeting_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Time&nbsp;<span id="Span38" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtScheduled_Meeting_Time" runat="server" Width="70px" MaxLength="5" />
                                                            <asp:RegularExpressionValidator ID="RevtxtScheduled_Meeting_Time" runat="server"
                                                                ValidationGroup="vsErrorSchedule" Display="none" ErrorMessage="[Meeting Schedule]/Time is not valid."
                                                                SetFocusOnError="true" ControlToValidate="txtScheduled_Meeting_Time" ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$">
                                                            </asp:RegularExpressionValidator>
                                                            &nbsp;&nbsp;<asp:DropDownList ID="ddlScheduled_Meeting_Time_AM" SkinID="dropGen"
                                                                runat="server" Width="30%">
                                                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Meeting Place&nbsp;<span id="Span39" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtMeeting_Place" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Time Zone&nbsp;<span id="Span43" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpTime_Zone" Width="150px" runat="server" SkinID="dropGen">
                                                                <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Eastern" Value="Eastern"></asp:ListItem>
                                                                <asp:ListItem Text="Central" Value="Central"></asp:ListItem>
                                                                <asp:ListItem Text="Mountain" Value="Mountain"></asp:ListItem>
                                                                <asp:ListItem Text="Pacific" Value="Pacific"></asp:ListItem>
                                                                <asp:ListItem Text="Alaska" Value="Alaska"></asp:ListItem>
                                                                <asp:ListItem Text="Hawaii" Value="Hawaii"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <%--<td align="left" valign="top">
                                                            E-mail Members
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoEmail_Members" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="right" valign="top">
                                                            <%-- <asp:Button ID="btnSaveCommonMeeting" runat="server" Text="Save" OnClick="btnSaveCommonMeeting_Click" CausesValidation="true"
                                                                ValidationGroup="vsErrorSchedule" />
                                                               &nbsp;&nbsp;&nbsp; <asp:Button ID="btnSendMeeting_Members" runat="server" OnClientClick="javascript:OpenPopupEmailSchedule('Next_Schedule');return false;" Text="Send" Enabled="false"/>--%>
                                                            <asp:Button ID="btnSchedule_View" runat="server" Text="View Audit Trail" Visible="false"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('SLTSchedule');" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Button ID="btnSendSchedule" runat="server" Style="display: none" OnClick="btnSendMeeting_Members_Click" />
                                                        </td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl14" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Review
                                                </div>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">SLT Meeting Reviewed/Approved&nbsp;<span id="Span40" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtMeeting_Approved_date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="SLT Meeting Reviewed/Approved" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtMeeting_Approved_date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revMeeting_Approved_date" runat="server" ValidationGroup="vsErrorMeetingReview"
                                                                Display="none" ErrorMessage="[Review]/SLT Meeting Reviewed/Approved is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtMeeting_Approved_date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Scored
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Scored" runat="server" Width="170px" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Review Quality&nbsp;<span id="Span41" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Meeting_Quality" Width="175px" runat="server" SkinID="dropGen">
                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Spectator" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Water boy" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Second String" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Starter" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="All Pro" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Lag Time
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtLag_Time" runat="server" Width="170px" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Comments&nbsp;<span id="Span42" runat="server" style="color: Red; display: none">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtMeeting_Comment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            <u>Scoring Activity </u>
                                                        </td>
                                                        <td align="center" width="4%" valign="top"></td>
                                                        <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<u>Possible Points</u>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            <u>Granted Points</u>
                                                        </td>
                                                        <td align="center" width="4%" valign="top"></td>
                                                        <td align="left" width="28%" valign="top">
                                                            <u>Overwrite Points</u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Meeting Held and 100% Participation
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            <asp:Label runat="server" ID="lblMeeting_Participation"></asp:Label>
                                                        </td>
                                                        <td align="center" width="4%" valign="top"></td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtMeetingPoints" runat="server" Width="50px" MaxLength="1" onkeypress="return FormatInteger(event);"
                                                                onblur="CheckPoints(1, this);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 15px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Safety Walk Conducted and 100% Participated
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            <asp:Label runat="server" ID="lblSaftey_Walk_Participated"></asp:Label>
                                                        </td>
                                                        <td align="center" width="4%" valign="top"></td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtSafetyWalkPoints" runat="server" Width="50px" MaxLength="1" onkeypress="return FormatInteger(event);"
                                                                onblur="CheckPoints(2, this);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 15px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Incident Review Conducted
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            <asp:Label runat="server" ID="lblIncident_Review_Conducted"></asp:Label>
                                                        </td>
                                                        <td align="center" width="4%" valign="top"></td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtIncidentReviewPoints" runat="server" Width="50px" MaxLength="1"
                                                                onkeypress="return FormatInteger(event);" onblur="CheckPoints(3, this);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 15px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Quality Review
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            <asp:Label runat="server" ID="lblQuality_Review"></asp:Label>
                                                        </td>
                                                        <td align="center" width="4%" valign="top"></td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtQualityReviewPoints" runat="server" Width="50px" MaxLength="1"
                                                                onkeypress="return FormatInteger(event);" onblur="CheckPoints(4, this);" />
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    <tr>
                                                        <td colspan="6">
                                                            <div id="dvAttachment" runat="server">
                                                                <table cellpadding="0" cellspacing="0" width="100%" style="height: 230px;">
                                                                    <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                                        <td colspan="100%">Attachments</td>
                                                                        <%--3439 Point 4--%>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="100%">
                                                                            <uc:ctrlAttachment_SLT ID="Attachments_SLT" runat="Server" OnbtnHandler="btnAddAttachment_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="Spacer" style="height: 20px;"></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <asp:Panel ID="pnlAttachmentDetails" runat="server" Width="714px">
                                                                <table cellpadding="0" cellspacing="0" width="100%" style="height: 250px;">
                                                                    <tr>
                                                                        <td width="100%" valign="top">
                                                                            <uc:ctrlAttachmentDetail ID="AttachDetails" runat="Server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<asp:CustomValidator ID="cvPoints" runat="server" ClientValidationFunction="ValidatePoints" ErrorMessage="Please enter all points to overwrite" 
                                                Display="None" ValidationGroup="vsErrorMeetingReview" />--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl17" runat="server" Style="display: none;">

                                                <asp:Panel ID="pnlBTSecurity" runat="server">
                                                    <div class="bandHeaderRow">
                                                        BT Security Walk
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Monthly BT Security Walk Completed
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecurity_Walk_Comp" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Date Completed&nbsp;<span id="Span44" runat="server" style="color: Red; display: none">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:TextBox ID="txtBTSecurity_Walk_Comp_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtBTSecurity_Walk_Comp_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revBTSecurity_Walk_Comp_Date" runat="server" ValidationGroup="vsErrorBTSecuritywalkGroup"
                                                                    Display="none" ErrorMessage="[BT Security Walk]/Date Completed is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtBTSecurity_Walk_Comp_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationGroup="vsErrorBTSecuritywalkGroup"
                                                                    Display="none" ErrorMessage="[BT Security Walk]/Date Completed is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtBTSecurity_Walk_Comp_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Monthly BT Security Walk Completed by the following SLT Members
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:GridView ID="gvMonBTSecurityWalk" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    AllowPaging="true" PageSize="10" EmptyDataText="No Record Found" OnPageIndexChanging="gvMonBTSecurityWalk_PageIndexChanging"
                                                                    OnRowDataBound="gvMonBTSecurityWalk_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="First Name" DataField="First_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="Last Name" DataField="Last_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="SLT Role" DataField="SLT_Role" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:TemplateField HeaderText="Participated">
                                                                            <ItemTemplate>
                                                                                <asp:RadioButtonList ID="rdoBTSecParticipated" runat="server" SkinID="YesNoType" />
                                                                                <asp:HiddenField ID="hdnBTSecFK_SLT_Member" runat="server" Value='<%# Eval("PK_SLT_Members") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <hr size="1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6">
                                                                <b>Departments Reviewed</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Sales
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecSales_Reviewed" runat="server" SkinID="YesNoType" onclick="ShowHideBTSecComments(this.id,'Sales');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecSales_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecSales" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecSales_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parts
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecParts_Reviewed" runat="server" SkinID="YesNoType" onclick="ShowHideBTSecComments(this.id,'Parts');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecParts_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecParts" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecParts_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Service Facility
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecService_Facility_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideBTSecComments(this.id,'Service');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecService_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecService" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecService_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Body Shop
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecBody_Shop_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideBTSecComments(this.id,'Body_Shop');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecBody_Shop_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecBody_Shop" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecBody_Shop_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Business Office
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecBus_Off_Reviewed" runat="server" SkinID="YesNoType" onclick="ShowHideBTSecComments(this.id,'Business');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecBus_Off_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecBusiness" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecBus_Off_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Detail Area
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecDetail_Area_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideBTSecComments(this.id,'DetailArea');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecDetail_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecDetailArea" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecDetail_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Car Wash
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecCar_Wash_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideBTSecComments(this.id,'CarWash');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecCar_Wash_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecCarWash" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecCar_Wash_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parking Lot
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecParking_Lot_Reviewed" runat="server" SkinID="YesNoType"
                                                                    onclick="ShowHideBTSecComments(this.id,'Parking');">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoBTSecParking_Deficiencies" runat="server" SkinID="YesNoNone">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecParking" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtBTSecParking_Comments" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left">
                                                                <b>BT Security Walk Attachments</b><br />
                                                                <i>Click to view details</i>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:GridView ID="gvBTSecuritywalkAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvBTSecuritywalkAttachmentDetails_RowDataBound"
                                                                    OnRowCommand="gvBTSecuritywalkAttachmentDetails_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="File Name">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <a id="lnkBTSecuritywalkAttachFile" runat="server" href="#">
                                                                                    <%# Eval("Attachment_Name1")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <%# Eval("Attachment_Description")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="30%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Name") %>'
                                                                                    CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove the Attachment?');" />
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
                                                                <asp:LinkButton ID="lnlADDAttachmentBTSecwalk" runat="server" CausesValidation="true"
                                                                    Text="Add New" ValidationGroup="vsErrorBTSecuritywalkGroup" OnClientClick="javascript:CheckBeforeAddBTSecurityWalkAttach();return false;"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecWalkAttachment" runat="server" style="display: none;">
                                                            <td align="left" colspan="6">
                                                                <uc:ctrlAttachment runat="server" ID="BTSecwalkAttachment" OnFileSelection="Upload_BTSecurityWalk_Attachment" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center">
                                                                <asp:Button ID="btnSave_BTSecWalk" runat="server" Text="Save" CausesValidation="true"
                                                                    ValidationGroup="vsErrorBTSecuritywalkGroup" OnClick="btnSave_BTSecWalk_Click" />
                                                                &nbsp;&nbsp;<asp:Button ID="btnView_auditBTSecWalk" runat="server" Text="View Audit Trail"
                                                                    OnClientClick="javascript:return AuditPopUpMeeting('SLTBTSecurityWalk');" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>

                                                <asp:Panel ID="pnlBTSecurityGrid" runat="server">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="bandHeaderRow">
                                                                <asp:Label ID="lblBTWalk" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="min-height: 302px;">
                                                                    <asp:GridView ID="gvBTSecurityWalk" runat="server" Width="100%" AutoGenerateColumns="false" 
                                                                        EmptyDataText="No Record Found" OnRowCommand="gvBTSecurityWalk_RowCommand" OnRowDataBound="gvBTSecurityWalk_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Month" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnBTSecMonthNumber" runat="server" Value='<%# Eval("MonthNum") %>' />
                                                                                    <asp:HiddenField ID="hdnBTSecActualMeetingDate" runat="server" Value='<%# Eval("Actual_Meeting_Date") %>' />
                                                                                    <asp:HiddenField ID="hdnBTSec_Walk_Comp" runat="server" Value='<%# Convert.ToBoolean(Eval("BT_Security_Walk_Comp")) %>' />
                                                                                    <asp:HiddenField ID="hdnPK_SLT_BTSec_Walk" runat="server" Value='<%# Eval("PK_SLT_BT_Security_Walk") %>' />
                                                                                    <asp:HiddenField ID="hdnBTSecPK_SLT_Meeting_Schedule" runat="server" Value='<%# Eval("PK_SLT_Meeting_Schedule") %>' />
                                                                                    <%# Eval("Month") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Focus Area" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Focus_Area") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Monthly BT Security Walk Completed?" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButtonList ID="rdoBTSecParticipated" runat="server" SkinID="YesNoType" Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date Completed" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtBTSecCompletedDate" runat="server" Width="80px" SkinID="txtDate" Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>' Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("BT_Security_Walk_Comp_Date")) %>' />
                                                                                    <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="../../Images/iconPicDate.gif" ImageAlign="Middle" Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>' OnClientClick="javascript:return false;" />
                                                                                    <cc1:CalendarExtender ID="calCompletedDate" runat="server" TargetControlID="txtBTSecCompletedDate" PopupButtonID="imgbtn"></cc1:CalendarExtender>
                                                                                    <asp:RegularExpressionValidator ID="revDate_Completed_Inspection" runat="server"
                                                                                        ValidationGroup="vsErrorInspectionGroup" Display="none" ErrorMessage="Date Completed is not a valid date"
                                                                                        SetFocusOnError="true" ControlToValidate="txtBTSecCompletedDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="BT Security Walk Participation" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkParticipation" runat="server" Text="Participants" CommandName="Participation"
                                                                                        CommandArgument='<%#Eval("MonthNum") + ":" + Eval("PK_SLT_BT_Security_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'></asp:LinkButton>
                                                                                    <%--<asp:HyperLink ID="SafetyWalkParticipation" runat="server" Text="Participants"></asp:HyperLink>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Observations Open" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkObservationOpen" runat="server" Text='<%# Eval("Observations_Open") %>' CommandName="ObservationOpen"
                                                                                        CommandArgument='<%#Eval("Month") + ":" + Eval("PK_SLT_BT_Security_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'>
                                                                                    </asp:LinkButton>
                                                                                    <%--<asp:HyperLink ID="ObservationsOpen" runat="server" Text='<%# Eval("Observations_Open") %>'></asp:HyperLink>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center">
                                                                <asp:Button ID="btnSave_BTSecurity" runat="server" Text="Save" OnClick="btnSave_SLTSafety_Click" Visible="false" />
                                                                &nbsp;&nbsp;<asp:Button ID="btnBTAudit" runat="server" Text="View Audit Trail"
                                                                    OnClientClick="javascript:return AuditPopUpMeeting('SLTSafetyWalk');" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Button ID="btnhdnBTSecurityReload" runat="server" OnClick="btnhdnBTSecurityReload_Click" Style="display: none;" />
                                                    <asp:Button ID="btnReload_BTParticipant" runat="server" OnClick="btnReload_BTParticipant_Click" Style="display: none;" />
                                                </asp:Panel>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    SLT Members
                                                </div>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 455px">
                                                    <tr id="tr_Sltmembers_View" runat="server">
                                                        <td align="left" valign="top" width="100%">
                                                            <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <asp:GridView ID="gvSLT_membersView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvSLT_Members_RowCommand"
                                                                            OnPageIndexChanging="gvSLT_membersView_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="5%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnk1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                            CommandArgument='<%# Eval("PK_SLT_Members") %>' CommandName="ViewMembers" CausesValidation="false" />
                                                                                        <asp:HiddenField ID="hdnPK_SLT_Members" runat="server" Value='<%# Eval("PK_SLT_Members") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="First Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Last Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SLT Role">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Start Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Start_Date")) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="End Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEnd_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="25%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandArgument='<%#Eval("PK_SLT_Members") %>'
                                                                                            CommandName="ViewMembers" CausesValidation="false" />
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
                                                                    <td align="left" valign="top" colspan="3">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <span style="font-weight: bold">Yearly Member Report Grid</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Year
                                                                    </td>
                                                                    <td align="left" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpMemberYearView" runat="server" SkinID="dropGen" Width="80px"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="3">
                                                                        <asp:GridView ID="gvSlt_Membersbyyearview" runat="server" Width="80%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvSlt_Membersbyyearview_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="First Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Last Name">
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SLT Role">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Start Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Start_Date")) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="End Date">
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEnd_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>' />
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_SltmembersBYYear_View" runat="server" visible="false">
                                                        <td align="left" valign="top" width="100%">
                                                            <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="14%">Member Start Date
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="20%">
                                                                        <asp:Label ID="lblMambers_Start_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top" width="14%">Member End Date
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="20%">
                                                                        <asp:Label ID="lblMambers_End_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Member Name<br />
                                                                        (First, Middle,Last)
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblEmployee_Name" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Department
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">SLT Role
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSLT_Role" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Email Address
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:Label ID="lblMemberEmail_Address" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td align="left" valign="top">
                                                                        Member Location(s)
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4">
                                                                        <asp:ListBox ID="lstMembers_ListboxView" runat="server" Width="330px" SelectionMode="Multiple" Enabled="false">
                                                                        </asp:ListBox>
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btnCancelMemberView" runat="server" Text="Cancel" OnClick="btnMember_Cancel_Click" />
                                                                        &nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnSLTMemberAudit_View" runat="server" Text="View Audit Trail" Visible="false"
                                                                            OnClientClick="javascript:return AuditPopUpMeeting('SLTMembers');" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none" Height="455px">
                                                <div class="bandHeaderRow">
                                                    Meeting Agenda
                                                </div>
                                                <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                    <tr id="Tr_AgendaSearchView" runat="server" visible="true">
                                                        <td align="center" valign="top">
                                                            <table cellpadding="4" cellspacing="1" border="0" width="90%">
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="16%">
                                                                        <asp:RadioButton ID="rdoFromView" runat="server" GroupName="Agenda_Search" Checked="true" />
                                                                        &nbsp;&nbsp;&nbsp; From
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="32%">
                                                                        <asp:TextBox ID="txtFromView" runat="server" Width="155px" SkinID="txtDate"></asp:TextBox>
                                                                        <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFromView', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorSchedule"
                                                                            Display="none" ErrorMessage="[Meeting Agenda]/From Date is not valid" SetFocusOnError="true"
                                                                            ControlToValidate="txtFromView" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="16%">To
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="32%">
                                                                        <asp:TextBox ID="txtToView" runat="server" Width="155px" SkinID="txtDate"></asp:TextBox>
                                                                        <img alt="Policy Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtToView', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="vsErrorSchedule"
                                                                            Display="none" ErrorMessage="[Meeting Agenda]/To Date is not valid" SetFocusOnError="true"
                                                                            ControlToValidate="txtToView" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtToView"
                                                                            ControlToCompare="txtFromView" Operator="GreaterThanEqual" Type="Date" ValidationGroup="vsErrorSchedule"
                                                                            ErrorMessage="[Meeting Agenda]/To Date must be greater than or equal From Date"
                                                                            SetFocusOnError="true" Display="None" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButton ID="rdbAgendaYearView" runat="server" GroupName="Agenda_Search" />
                                                                        &nbsp;&nbsp;&nbsp; In Year
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpMeeting_AgendaYearView" runat="server" Width="160px" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" valign="top">Month
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="drpMeeting_AgendaMonthView" runat="server" Width="160px" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_AgendaGridview" runat="server" visible="false">
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:GridView ID="gvMeetingView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="gvMeetingView_PageIndexChanging" AllowSorting="True"
                                                                OnRowCommand="gvMeeting_RowCommand" OnSorting="gvMeetingView_Sorting" OnRowCreated="gvMeetingView_RowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnk1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="ViewMeeting" CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule")%>'
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Scheduled Meeting Date" DataField="Scheduled_Meeting_Date" SortExpression="Scheduled_Meeting_Date"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Date Meeting Minutes Sent" DataField="Date_Meeting_Minutes_Sent"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:TemplateField HeaderText="Actual Meeting Date" SortExpression="Actual_Meeting_Date">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblActual_Meeting_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Meeting_Date")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number Of Members Present">
                                                                        <ItemStyle Width="17%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNum_Present" runat="server" Text='<%#Eval("Num_Present") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SLT Score" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSLT_RLCM_SCORE" runat="server" Text='<%#Eval("Score") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderText="Email / Print">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMail" runat="server" Text="Mail" CausesValidation="false"
                                                                                CommandName="Mail" CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule")%>' />
                                                                            &nbsp;&nbsp;<asp:LinkButton ID="lnkPrint" runat="server" Text="Print" CommandName="Print"
                                                                                CausesValidation="false" CommandArgument='<%#Eval("FK_SLT_Meeting") + ";" + Eval("PK_SLT_Meeting_Schedule")%>' />
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
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:Button ID="btnAgendaSearchView" runat="server" Text="Search" OnClick="btnAgendaSearch_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorSchedule" />
                                                            <asp:Button ID="btnAgendaCancelview" runat="server" Text="Search" OnClick="btnAgenda_Cancel_Click"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvnonEditable" runat="server" width="794px" style="overflow-x: hidden; overflow-y: scroll;">
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Meeting Attendees
                                                </div>
                                                <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Scheduled Meeting Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:Label ID="lblMeeting_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Actual Meeting Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:Label ID="lblAttendeesActual_meeting_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <%--<div style="overflow-x: scroll; overflow-y: hidden; width: 800px;" id="dvAttendeesView"
                                                                runat="server">--%>
                                                            <asp:GridView ID="gvMeetingAttendeesView" runat="server" PageSize="10" Width="100%"
                                                                EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvMeetingAttendeesView_PageIndexChanging"
                                                                OnRowDataBound="gvMeetingAttendeesView_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="First Name">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                                                            <asp:HiddenField ID="hdnPK_SLT_Members" runat="server" Value='<%#Eval("PK_SLT_Members") %>' />
                                                                            <%--<asp:HiddenField ID="hdnPK_SLT_Meeting_Attendees" runat="server" Value='<%#Eval("PK_SLT_Meeting_Attendees") %>' />--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SLT Role">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Present">
                                                                        <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPresent" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField>
                                                                            <ItemStyle Width="15%" VerticalAlign="Middle" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblifnoExplain" runat="server" Text="If No Explain" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="25%" VerticalAlign="Middle" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLU_Explain" runat="server"></asp:Label>
                                                                       </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="25%" VerticalAlign="Middle" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExplain" runat="server" Text="Explain : " Style="display: none" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="18%" VerticalAlign="Middle" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExplainView" runat="server" Width="155px" Style="display: none"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
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
                                                            <%--</div>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">RLCM In Attendance?
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:Label ID="lblRLCM_Attendance" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center" valign="top">
                                                            <asp:Button ID="btnCancelAttendessView" runat="server" Text="Cancel" OnClick="btnCancelAttendees_Click" />
                                                            <asp:Button ID="Button1" runat="server" Text="View Audit Trail" Visible="false" OnClientClick="javascript:return AuditPopUpMeeting('SLTSchedule');" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4View" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Call to Order
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Meeting Start Time
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblMeeting_Start_Time" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Meeting End Time
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblMeeting_End_Time" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Previous Meeting Reviewed and Approved
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPrev_Meeting_Review" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Safety Board Updated?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSafety_Board_Updated" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5View" runat="server" Style="display: none;">
                                                <asp:Panel ID="pnl16View" runat="server">
                                                    <div class="bandHeaderRow">
                                                        Safety Walk
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Monthly Safety Walk Completed
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblSafety_Walk_Comp" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Date Completed
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblSafety_Walk_Comp_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Monthly Safety Walk Completed by the following SLT Members
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:GridView ID="gvSafetyWalkView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    PageSize="10" EmptyDataText="No Record Found" OnPageIndexChanging="gvSafetyWalkView_PageIndexChanging"
                                                                    OnRowDataBound="gvSafetyWalkView_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="First Name" DataField="First_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="Last Name" DataField="Last_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="SLT Role" DataField="SLT_Role" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:TemplateField HeaderText="Participated">
                                                                            <ItemStyle Width="25%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblparticipated" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <hr size="1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <b>Departments Reviewed</b><br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Sales
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSales_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSales_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trSalesView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblSales_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parts
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblParts_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblParts_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPartsView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblParts_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Service Facility
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblService_Facility_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblService_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trServiceView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblService_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Body Shop
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBody_Shop_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBody_Shop_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBody_ShopView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBody_Shop_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Business Office
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBus_Off_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBus_Off_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBusinessView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBus_Off_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Detail Area
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDetail_Area_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDetail_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trDetailAreaView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblDetail_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Car Wash
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCar_Wash_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCar_Wash_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trCarWashView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblCar_Wash_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parking Lot
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblParking_Lot_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblParking_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trParkingView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblParking_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left">
                                                                <b>Safety Walk Attachments</b><br />
                                                                <i>Click to view details</i>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:GridView ID="gvSafetywalkAttachmentView" runat="server" Width="100%" OnRowDataBound="gvSafetywalkAttachmentView_RowDataBound"
                                                                    EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="File Name">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <a id="lnkSaftywalkAttachFile" runat="server" href="#">
                                                                                    <%# Eval("Attachment_Name1")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <%# Eval("Attachment_Description")%>
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
                                                        <tr>
                                                            <td colspan="6" align="center">&nbsp;&nbsp;<asp:Button ID="btnsaftety_walkAudit_view" runat="server" Text="View Audit Trail"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('SLTSafetyWalk');" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl15View" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="min-height: 302px;">
                                                                    <asp:GridView ID="gvSLTSafetyWalkView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                        AllowPaging="true" PageSize="10" EmptyDataText="No Record Found" OnRowCommand="gvSLTSafetyWalk_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Month" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnMonthNumber" runat="server" Value='<%# Eval("MonthNum") %>' />
                                                                                    <asp:HiddenField ID="hdnActualMeetingDate" runat="server" Value='<%# Eval("Actual_Meeting_Date") %>' />
                                                                                    <asp:HiddenField ID="hdnSafety_Walk_Comp" runat="server" Value='<%# Convert.ToBoolean(Eval("Safety_Walk_Comp")) %>' />
                                                                                    <asp:HiddenField ID="hdnPK_SLT_Safety_Walk" runat="server" Value='<%# Eval("PK_SLT_Safety_Walk") %>' />
                                                                                    <asp:HiddenField ID="hdnPK_SLT_Meeting_Schedule" runat="server" Value='<%# Eval("PK_SLT_Meeting_Schedule") %>' />
                                                                                    <%# Eval("Month") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Focus Area" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Focus_Area") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Monthly Safety Walk Completed?" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# clsGeneral.FormatYesNoToDisplayForView(Eval("Safety_Walk_Comp")) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date Completed" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Safety_Walk_Comp_Date")) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Safety Walk Participation" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkParticipation" runat="server" Text="Participants" CommandName="Participation"
                                                                                        CommandArgument='<%#Eval("MonthNum") + ":" + Eval("PK_SLT_Safety_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Observations Open" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkObservationOpen" runat="server" Text='<%# Eval("Observations_Open") %>' CommandName="ObservationOpen"
                                                                                        CommandArgument='<%#Eval("Month") + ":" + Eval("PK_SLT_Safety_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'>
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Quarterly Facility Inspection
                                                </div>
                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Year
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpYearInspectionView" runat="server" SkinID="dropGen" Width="150px"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpYearInspection_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Dealership Playbook Score
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblInspectionScoreView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <%--                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Quarterly Results
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoInspectionQuartersView" runat="server" RepeatDirection="Horizontal"
                                                                AutoPostBack="true" OnSelectedIndexChanged="rdoInspectionQuarters_SelectedIndexChanged">
                                                                <asp:ListItem Text="Q1" Value="1" Selected="True" />
                                                                <asp:ListItem Text="Q2" Value="2" />
                                                                <asp:ListItem Text="Q3" Value="3" />
                                                                <asp:ListItem Text="Q4" Value="4" />
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6">
                                                            <%-- <div style="width: 717px; overflow: hidden">
                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                    <tr style="background-color: #7f7f7f; color: White; font-size: 12px; font-weight: bold;"
                                                                        align="left">
                                                                        <td width="10%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%">
                                                                            Inspector Name
                                                                        </td>
                                                                        <td width="30%">
                                                                            Inspection Date
                                                                        </td>
                                                                        <td width="30%">
                                                                            Number of Deficiencies
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>--%>
                                                            <asp:GridView ID="gvInspectionView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                AutoGenerateColumns="false" ShowHeader="true" OnRowCommand="gvInspectionView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInspection" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandArgument='<%# Container.DataItemIndex + "," + Eval("PK_Inspection_ID")%>'
                                                                                CommandName="ViewDetails" />
                                                                            <input type="hidden" id="hdnDeficiencies" runat="server" value='<%#Eval("Deficiencies") %>' />
                                                                            <input type="hidden" id="hdnDeficienciesNotCompleted" runat="server" value='<%#Eval("Deficiencies_NotCompleted") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspector Name">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInspectorName" runat="server" Text='<%#Eval("Inspector_Name")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspection Date">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInspectionDate" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Date")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of Deficiencies">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDateCompleted" runat="server" Text='<%# Eval("Deficiencies") %>' />
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
                                                    <tr>
                                                        <td align="left" valign="top">Inspector Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInspectorNameView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Inspection Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInspectionDateView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Number of Deficiencies
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDeficienciesView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Number of Deficiencies Not Completed
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDeficienciesNotCompletedView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <%--<div style="width: 800px; overflow: hidden">
                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                    <tr style="background-color: #7f7f7f; color: White; font-size: 12px; font-weight: bold;"
                                                                        align="left">
                                                                        <td width="5%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="15%">
                                                                           Focus Area
                                                                        </td>
                                                                        <td width="25%">
                                                                            Question 
                                                                        </td>
                                                                        <td width="15%">
                                                                           Date Opened
                                                                        </td>
                                                                        <td width="10%">
                                                                          Days Open
                                                                        </td>
                                                                        <td width="20%">
                                                                           Target Completion Date
                                                                        </td>
                                                                        <td width="10%">
                                                                           &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>--%>
                                                            <asp:GridView ID="gvInspection_responsesView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                AutoGenerateColumns="false" ShowHeader="true" OnRowCommand="gvInspection_responsesView_RowCommand"
                                                                AllowPaging="true" PageSize="6" OnPageIndexChanging="gvInspection_responsesView_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInspection_Responses" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandArgument='<%# Eval("PK_Inspection_Responses_ID") %>' CommandName="ViewDetails" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Focus Area">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFocusArea" runat="server" Text='<%#Eval("Item_Number_Focus_Area")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Question">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQuestion_Text" runat="server" Text='<%# Eval("Question_Text")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Opened">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_opened" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Date_Opened")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Days Open">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldays_opened" runat="server" Text='<%# Eval("Days_Opened") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Target Completion Date">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTarget_Completion_Date" runat="server" Text='<%#Eval("Target_Completion_Date")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInspection_response_View" runat="server" Text="View" CommandArgument='<%# Eval("PK_Inspection_Responses_ID") %>'
                                                                                CommandName="ViewDetails" />
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
                                                    <tr>
                                                        <td align="left" valign="top">Focus Area
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResponseFocus_AreaView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Deficiency
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblresponse_Deficiencyview" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" style="padding-left: 10px" colspan="6">
                                                            <asp:Label ID="lblQuestionNumberview" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuestionTextView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 5px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left">
                                                            <table cellpadding="2" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td width="3%" valign="top" align="left">
                                                                        <img id="imgGuidanceplusView" runat="server" src="../../Images/plus.jpg" alt="" onclick="showPanelIncident(this.id);" />
                                                                        <img id="imgGuidanceminusView" runat="server" src="../../Images/minus.jpg" alt=""
                                                                            onclick="HidePaneIncident(this.id);" style="display: none" />
                                                                    </td>
                                                                    <td align="left" valign="top">Guidance
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 5px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr id="trGuidance_view" runat="server" style="display: none">
                                                                    <td width="100%" style="padding-left: 20px">
                                                                        <asp:Label ID="lblGuidancetextview" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Spacer" style="height: 5px;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <table cellpadding="3" cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td width="18%" align="left" valign="top">Repeat Deficiency?
                                                                                </td>
                                                                                <td width="4%" align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblRepeat_Deficiencyview" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="18%" align="left" valign="top">Department
                                                                                </td>
                                                                                <td width="4%" align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top" colspan="4">
                                                                                    <asp:DataList ID="rptdepartmentview" runat="server" Width="100%" RepeatColumns="3">
                                                                                        <ItemTemplate>
                                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td width="60%" align="left">
                                                                                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                                                                        <input type="hidden" id="hdnDeptID" runat="server" value='<%#Eval("PK_LU_Department_ID") %>' />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="lblValue" runat="server" Text="No" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">Date Opened
                                                                                </td>
                                                                                <td align="center">:
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:Label ID="lblDate_openedview" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="left" width="18%">Days Open
                                                                                </td>
                                                                                <td align="center" width="4%">:
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:Label ID="lblDaysopenView" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">Corrective Action:
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <uc:ctrlMultiLineTextBox ID="lblRecc_Action_View" runat="server" ControlType="Label" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">Target Completion Date
                                                                                </td>
                                                                                <td align="center">:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblTar_comp_dateview" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="left">Actual Completion Date
                                                                                </td>
                                                                                <td align="center">:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblAct_com_dateview" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">Notes:
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <uc:ctrlMultiLineTextBox ID="lblnotesview" runat="server" ControlType="Label" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Assigned To
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_SLT_Members" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Completed
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDate_Completed_Inspection" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments_Inspection" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">RLCM Notified
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRLCM_Notified" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top" colspan="3">
                                                            <asp:Button ID="btnInspectionAudit_view" runat="server" Text="View Audit Trail" Visible="false"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('QuarterlyInspections');" />
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7View" runat="server" Style="display: none">
                                                <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                    <tr>
                                                        <td align="left" valign="top" class="bandHeaderRow" width="100%">
                                                            <asp:Label ID="lblHeading_View" runat="server" Text="Incident Investigation"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1" runat="server">
                                                        <td>
                                                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tr id="tr2" runat="server" visible="true">
                                                                    <td align="left" width="19%">Dealership Playbook Score
                                                                    </td>
                                                                    <td align="center" width="1%">:&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" colspan="5" width="20%">
                                                                        <asp:Label ID="lblDealerShip_View" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="17%">Year
                                                                    </td>
                                                                    <td align="center" width="3%">:&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" width="20%">
                                                                        <asp:DropDownList ID="ddlYearIncident_View" runat="server" Width="80px" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddlYearIncident_View_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr3" runat="server">
                                                        <td>
                                                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tr>
                                                                    <td width="15%"></td>
                                                                    <td align="right" width="16%">
                                                                        <%--Month&nbsp;--%>
                                                                    </td>
                                                                    <td align="center" width="4%"></td>
                                                                    <td align="left" width="25%">
                                                                        <asp:DropDownList ID="ddlMonth_View" Visible="false" runat="server" Width="170px"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_View_SelectedIndexChanged">
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
                                                    <tr id="tr5" runat="server">
                                                        <td align="left">
                                                            <div style="color: White; font-weight: bold; width: 90%; background-color: #7f7f7f; float: left; height: 20px; text-align: center; font-size: 13px;">
                                                                Sonic Cause Code
                                                            </div>
                                                            <asp:GridView ID="gvIncidentGrid_View" ShowFooter="true" runat="server" Width="90%"
                                                                AutoGenerateColumns="false" OnRowDataBound="gvIncidentGrid_View_RowDataBound1">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Month
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("Month_Name")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle BackColor="#7f7f7f" Font-Bold="True" Width="15%" ForeColor="White" />
                                                                        <FooterTemplate>
                                                                            Yearly Total
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-1
                                                                                        <br />
                                                                                        S0-1
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S1")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS1" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-2
                                                                                        <br />
                                                                                        S0-2
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S2")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS2" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-3
                                                                                        <br />
                                                                                        S0-3
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S3")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS3" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-4
                                                                                        <br />
                                                                                        S0-4
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S4")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS4" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>S-5
                                                                                        <br />
                                                                                        S0-5
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("S5")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblS5" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Monthly Total
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Eval("Monthly_Total")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10%" />
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblMonthly_Total" runat="server" Text="0"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <%--<table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="7">
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8View" runat="server" Style="display: none">
                                                <cc1:IncidentReview ID="IncidentReview_WC_View" runat="server" Incident_ReviewType="WC"
                                                    OnIncidentReview="BindIncidentReviewGrid" />
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9View" runat="server" Style="display: none">
                                                <div class="bandHeaderRow">
                                                    WC Claim Management
                                                </div>
                                                <table cellpadding="4" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Dealership Playbook Score
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="24%">
                                                            <asp:Label ID="lblDealershipview" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top" width="4%">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top" width="24%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                            <td align="left" valign="top" width="18%">
                                                                Year
                                                            </td>
                                                            <td align="center" valign="top" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top" width="24%">
                                                                <asp:DropDownList ID="ddlYear_Claim_ManagementView" runat="server" Width="60px" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlYear_Claim_Management_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" valign="top" width="18%">
                                                                Month
                                                            </td>
                                                            <td align="center" valign="top" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top" width="24%">
                                                                <asp:DropDownList ID="ddlMonth_Claim_ManagementView" runat="server" Width="100px" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlMonth_Claim_Management_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:GridView ID="gvClaim_managemetview" runat="server" Width="100%" AllowPaging="true"
                                                                PageSize="8" AutoGenerateColumns="false" OnPageIndexChanging="gvClaim_managemetview_PageIndexChanging"
                                                                OnRowCommand="gvClaim_management_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnk1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandArgument='<%# Eval("PK_Workers_Comp_Claims_ID") %>' CommandName="viewClaim"
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClaim_Number" runat="server" Text='<%# Eval("Origin_Claim_Number") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date OF Incident">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_Of_Incident" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Accident")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Reported To Sedgewick">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_Reported_ToSed" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Reported_To_Insurer")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lag Time">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbllagTime" runat="server" Text='<%# Eval("Lag_Time") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Status">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClaim_Status" runat="server" Text='<%# Eval("Claim_Status") %>'></asp:Label>
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
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Claim Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCliam_numberview" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Associate Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblclaimant_view" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Date Of incident
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIncident_date_view" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Reported to Sedgwick
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_reportedview" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Lag Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lbllagtimeview" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Claim Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClaim_statusView" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cause/Injury/Body Part Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="lblCause_InjuryView" runat="server" ControlType="Label" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Please Explain If Lag Time Is Greater Than 3 Days
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="lblLagExplainationView" runat="server" ControlType="Label" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What is the associates current Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblAssociates_Status" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">If in a modified Light Duty Position Explain
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="lblLight_duty" runat="server" ControlType="Label" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="5">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" ControlType="Label" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl10View" runat="server" Style="display: none">
                                                <div class="bandHeaderRow">
                                                    Sonic University Training
                                                </div>
                                                <table cellpadding="4" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="18%" align="left" valign="top">Dealership Playbook Score
                                                        </td>
                                                        <td width="4%" align="center" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblTrainingScoreView" runat="server" />
                                                        </td>
                                                        <td width="18%" align="left" valign="top">Year
                                                        </td>
                                                        <td width="4%" align="center" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpTrainingYearView" runat="server" SkinID="dropGen" Width="100px"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpTrainingYear_SelectedIndexChanged" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>    
                                                        <td align="left" valign="top">Location Status</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpLocationStatusView" runat="server" Width="175px" SkinID="dropGen" AutoPostBack="true" OnSelectedIndexChanged="drpLocationStatus_SelectedIndexChanged"  />
                                                        </td>
                                                        <td colspan="3">&nbsp;</td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">Q1
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ1View" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Q2
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ2View" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Q3
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ3View" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Q4
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTrainingQ4View" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Quarterly Training Conducted by RLCM
                                                </div>
                                                <table cellpadding="4" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <asp:GridView ID="gvQuarterly_TrainingConducted_ByRLCMView" runat="server" Width="100%"
                                                                AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowDataBound="gvQuarterly_TrainingConducted_ByRLCMView_OnRowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkQuarterView" runat="server" Text='<%# Eval("Quarter") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Focus">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFocusView" runat="server" Text='<%# Eval("Focus") %>' CssClass="TextClip"
                                                                                Width="150px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Topic">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTopicView" runat="server" Text='<%# Eval("Topic") %>' CssClass="TextClip"
                                                                                Width="150px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Scheduled">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_ScheduledView" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Scheduled")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Completed">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_CompletedView" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Completed")) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reason Not Completed">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReason_Not_CompletedView" runat="server" Text='<%# Eval("Reason_Not_Completed") %>'
                                                                                CssClass="TextClip" Width="200px" />
                                                                            <asp:HiddenField ID="hdnPK_SLT_Training_RLCMView" runat="server" Value='<%# Eval("PK_SLT_Training_RLCM") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Training Suggestions
                                                </div>
                                                <table cellpadding="4" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <asp:GridView ID="gvTrainingSuggestionsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Found" AllowPaging="true" PageSize="3" OnRowCommand="gvTrainingSuggestions_RowCommand"
                                                                OnPageIndexChanging="gvTrainingSuggestionsView_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTrainSuggestion" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_SLT_Training") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Training Description" DataField="Training_Description"
                                                                        ItemStyle-Width="30%" />
                                                                    <asp:BoundField HeaderText="Desired Completion Date" DataField="Desired_Comp_Date"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="30%" />
                                                                    <asp:BoundField HeaderText="Completed" DataField="Completed" ItemStyle-Width="15%" />
                                                                    <asp:BoundField HeaderText="Date Completed" DataField="Date_Completed" DataFormatString="{0:MM/dd/yyyy}"
                                                                        ItemStyle-Width="15%" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Type/Description of Training
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblTraining_Description" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Desired Date to Have Training Completed
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDesired_Comp_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Completed
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Completed
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Completed_Training" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments_Training" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                    <td colspan="6" align="left">
                                                        <b>SABA Weekly Training Report Attachments</b>
                                                        <br />
                                                        <i>Click to view details</i>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:GridView ID="gvSLT_TrainingAttachmentView" runat="server" Width="100%" OnRowDataBound="gvSLT_TrainingAttachmentView_RowDataBound"
                                                            EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="File Name">
                                                                    <ItemStyle Width="35%" />
                                                                    <ItemTemplate>
                                                                        <a id="lnkTrainingAttachFile" runat="server" href="#">
                                                                            <%# Eval("Attachment_Name1")%>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Type">
                                                                    <ItemStyle Width="35%" />
                                                                    <ItemTemplate>
                                                                        <%# Eval("Attachment_Description")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>

                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl11View" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    New Procedures
                                                </div>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Year
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpProcedureYearView" Width="175px" runat="server" SkinID="dropGen"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpProcedureYear_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="3">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:GridView ID="gvNewProceduresView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                AllowPaging="true" PageSize="3" EmptyDataText="No Record Found" OnRowCommand="gvNewProcedures_RowCommand"
                                                                OnPageIndexChanging="gvNewProceduresView_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProcedure" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_SLT_New_Procedure") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Assigned To" DataField="Assigned_To" ItemStyle-Width="14%"
                                                                        ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Importance" DataField="Importance" ItemStyle-Width="14%"
                                                                        ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Procedure Source" DataField="Procedure_Source" ItemStyle-Width="18%"
                                                                        ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Target Completion Date" DataField="Target_Completion_Date"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Date Completed" DataField="Date_Completed" ItemStyle-Width="18%"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Left" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_procedureview" runat="server">
                                                        <td colspan="6">
                                                            <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Importance
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Importance" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">Procedure Source
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Procedure_Source" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Procedure Description
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblProcedure_Description" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Action Item
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblAction_Item" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">Assigned To
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblAssigned_To" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Target Completion Date
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTarget_Completion_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">Date Completed
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDate_Completed" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Status
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Item_Status" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="6" valign="top">
                                                                        <asp:Button ID="btnCancelproView" runat="server" Text="Cancel" OnClick="btnCancelProcedure_Click" />
                                                                        &nbsp;<asp:Button ID="btnNewProcedureAudit_View" runat="server" OnClientClick="javascript:return AuditPopUpMeeting('New_Procedure');"
                                                                            Text="View Audit Trail" Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl12View" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Suggestions/Comments/Notes
                                                </div>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:GridView ID="gvSuggestionsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                AllowPaging="true" PageSize="3" EmptyDataText="No Record Found" OnRowCommand="gvSuggestions_RowCommand"
                                                                OnPageIndexChanging="gvSuggestionsView_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSuggestion" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_SLT_Suggestion") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Assigned To" DataField="Assigned_To" ItemStyle-Width="15%"
                                                                        ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Suggestion Source" DataField="Suggestion_Source" ItemStyle-Width="19%"
                                                                        ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Importance" DataField="Importance" ItemStyle-Width="15%"
                                                                        ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Target Completion Date" DataField="Target_Completion_Date"
                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Date Completed" DataField="Date_Completed" DataFormatString="{0:MM/dd/yyyy}"
                                                                        ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr id="tr_suggview" runat="server" style="display: none">
                                                        <td colspan="6">
                                                            <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <hr />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Assigned To
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblAssigned_To_Sugg" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">Suggestion Source
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">:
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Suggestion_Source" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Importance
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Importance_Sugg" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">Target Completion Date
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTarget_Completion_Date_Sugg" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Suggestion
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblSuggestion_Description" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Action Item
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblAction_Item_Sugg" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">Date Completed
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDate_Completed_Sugg" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Status
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_Item_Status_Sugg" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Notes 
                                                                    </td>
                                                                    <td align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" colspan="4" valign="top">
                                                                        <uc:ctrlMultiLineTextBox ID="lblSuggestion_Notes" runat="server" ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" valign="top" colspan="6">
                                                                        <asp:Button ID="btnCancelsugg" runat="server" Text="Cancel" OnClick="btnCancelSuggestion_Click" />
                                                                        &nbsp;<asp:Button ID="btnSuggestionAudit_View" runat="server" Text="View Audit Trail"
                                                                            Visible="false" OnClientClick="javascript:return AuditPopUpMeeting('SLTSuggestion');" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl13View" runat="server" Style="display: none;" Height="460px">
                                                <div class="bandHeaderRow">
                                                    Meeting Schedule
                                                </div>
                                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6">
                                                            <br />
                                                            Next Scheduled Meeting Date<br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblSchedule_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Time
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblScheduled_Meeting_Time" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Meeting Place
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblMeeting_Place" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Time Zone
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTime_Zone" runat="server"></asp:Label>
                                                        </td>
                                                        <%--<td align="left" valign="top">
                                                            E-mail Members
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmail_Members" runat="server"></asp:Label>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="center" valign="top" colspan="3">
                                                            <asp:Button ID="btnSchedule_AuditTrail_View" runat="server" Text="View Audit Trail"
                                                                Visible="false" OnClientClick="javascript:return AuditPopUpMeeting('SLTSchedule');" />
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                             <asp:Panel ID="pnl17View" runat="server" Style="display: none;">
                                                 <asp:Panel ID="pnlBTSecurityView" runat="server">
                                                     <div class="bandHeaderRow">
                                                        BT Security Walk
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Monthly BT Security Walk Completed
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblBT_Security_Walk_Comp" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Date Completed
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblBT_Security_Walk_Comp_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Monthly BT Security Walk Completed by the following SLT Members
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:GridView ID="gvMonBTSecurityWalkView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    PageSize="10" EmptyDataText="No Record Found" OnPageIndexChanging="gvMonBTSecurityWalkView_PageIndexChanging"
                                                                    OnRowDataBound="gvMonBTSecurityWalkView_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="First Name" DataField="First_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="Last Name" DataField="Last_Name" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:BoundField HeaderText="SLT Role" DataField="SLT_Role" ItemStyle-HorizontalAlign="Left"
                                                                            ItemStyle-Width="25%" />
                                                                        <asp:TemplateField HeaderText="Participated">
                                                                            <ItemStyle Width="25%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBTSecparticipated" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <hr size="1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <b>Departments Reviewed</b><br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Sales
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecSales_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecSales_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecSalesView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecSales_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parts
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecParts_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecParts_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecPartsView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecParts_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Service Facility
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecService_Facility_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecService_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecServiceView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecService_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Body Shop
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecBody_Shop_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecBody_Shop_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecBody_ShopView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecBody_Shop_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Business Office
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecBus_Off_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecBus_Off_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecBusinessView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecBus_Off_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Detail Area
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecDetail_Area_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecDetail_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecDetailAreaView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecDetail_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Car Wash
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecCar_Wash_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecCar_Wash_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecCarWashView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecCar_Wash_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Parking Lot
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecParking_Lot_Reviewed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Deficiencies Corrected
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTSecParking_Deficiencies" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBTSecParkingView" runat="server" style="display: none;">
                                                            <td align="left" valign="top">Comments
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblBTSecParking_Comments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left">
                                                                <b>BT Security Walk Attachments</b><br />
                                                                <i>Click to view details</i>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:GridView ID="gvBTSecuritywalkAttachmentView" runat="server" Width="100%" OnRowDataBound="gvBTSecuritywalkAttachmentView_RowDataBound"
                                                                    EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="File Name">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <a id="lnkBTSecwalkAttachFile" runat="server" href="#">
                                                                                    <%# Eval("Attachment_Name1")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type">
                                                                            <ItemStyle Width="35%" />
                                                                            <ItemTemplate>
                                                                                <%# Eval("Attachment_Description")%>
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
                                                        <tr>
                                                            <td colspan="6" align="center">&nbsp;&nbsp;<asp:Button ID="btnBTSec_walkAudit_view" runat="server" Text="View Audit Trail"
                                                                OnClientClick="javascript:return AuditPopUpMeeting('SLTBTSecurityWalk');" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                 </asp:Panel>
                                                 <asp:Panel ID="pnlBTSecurityGridView" runat="server">
                                                     <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblBTSecurityView" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="min-height: 302px;">
                                                                    <asp:GridView ID="gvSLTBTSecurityWalkView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                        AllowPaging="true" PageSize="10" EmptyDataText="No Record Found" OnRowCommand="gvBTSecurityWalk_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Month" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                   <asp:HiddenField ID="hdnBTSecMonthNumber" runat="server" Value='<%# Eval("MonthNum") %>' />
                                                                                    <asp:HiddenField ID="hdnBTSecActualMeetingDate" runat="server" Value='<%# Eval("Actual_Meeting_Date") %>' />
                                                                                    <asp:HiddenField ID="hdnBTSec_Walk_Comp" runat="server" Value='<%# Convert.ToBoolean(Eval("BT_Security_Walk_Comp")) %>' />
                                                                                    <asp:HiddenField ID="hdnPK_SLT_BTSec_Walk" runat="server" Value='<%# Eval("PK_SLT_BT_Security_Walk") %>' />
                                                                                    <asp:HiddenField ID="hdnBTSecPK_SLT_Meeting_Schedule" runat="server" Value='<%# Eval("PK_SLT_Meeting_Schedule") %>' />
                                                                                    <%# Eval("Month") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Focus Area" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Focus_Area") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Monthly BT Security Walk Completed?" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# clsGeneral.FormatYesNoToDisplayForView(Eval("BT_Security_Walk_Comp")) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date Completed" ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("BT_Security_Walk_Comp_Date")) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Safety Walk Participation" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkParticipation" runat="server" Text="Participants" CommandName="Participation"
                                                                                        CommandArgument='<%#Eval("MonthNum") + ":" + Eval("PK_SLT_BT_Security_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Observations Open" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkObservationOpen" runat="server" Text='<%# Eval("Observations_Open") %>' CommandName="ObservationOpen"
                                                                                        CommandArgument='<%#Eval("Month") + ":" + Eval("PK_SLT_BT_Security_Walk") %>' Enabled='<%# Convert.ToBoolean(Eval("IsEnable")) %>'>
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                 </asp:Panel>
                                             </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnl14View" runat="server" Style="display: none;">
                                            <%--Height="610px"--%>
                                            <div class="bandHeaderRow">
                                                Review
                                            </div>
                                            <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">SLT Meeting Reviewed/Approved
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblMeeting_Approved_date" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left" width="18%" valign="top">Date Scored
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblDate_Scored" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Review Quality
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblFK_LU_Meeting_Quality" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left" width="18%" valign="top">Lag Time
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblLag_Time" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Comments
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top" colspan="4">
                                                        <uc:ctrlMultiLineTextBox ID="lblMeeting_Comments" runat="server" ControlType="Label" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">
                                                        <u>Scoring Activity </u>
                                                    </td>
                                                    <td align="center" width="4%" valign="top"></td>
                                                    <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<u>Possible Points</u>
                                                    </td>
                                                    <td align="left" width="18%" valign="top">
                                                        <u>Granted Points</u>
                                                    </td>
                                                    <td align="center" width="4%" valign="top"></td>
                                                    <td align="left" width="28%" valign="top"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Meeting Held and 100% Participation
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1
                                                    </td>
                                                    <td align="left" width="18%" valign="top">
                                                        <asp:Label runat="server" ID="lbl_Meeting_Participated_View"></asp:Label>
                                                    </td>
                                                    <td align="center" width="4%" valign="top"></td>
                                                    <td align="left" width="28%" valign="top"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Safety Walk Conducted and 100% Participated
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1
                                                    </td>
                                                    <td align="left" width="18%" valign="top">
                                                        <asp:Label runat="server" ID="lblSaftey_walk_Participated_View"></asp:Label>
                                                    </td>
                                                    <td align="center" width="4%" valign="top"></td>
                                                    <td align="left" width="28%" valign="top"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Incident Review Conducted
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1
                                                    </td>
                                                    <td align="left" width="18%" valign="top">
                                                        <asp:Label runat="server" ID="lblIncident_Review_Conducted_View"></asp:Label>
                                                    </td>
                                                    <td align="center" width="4%" valign="top"></td>
                                                    <td align="left" width="28%" valign="top"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Quality Review
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1,2
                                                    </td>
                                                    <td align="left" width="18%" valign="top">
                                                        <asp:Label runat="server" ID="lbl_Quality_Review_View"></asp:Label>
                                                    </td>
                                                    <td align="center" width="4%" valign="top"></td>
                                                    <td align="left" width="28%" valign="top"></td>
                                                </tr>
                                                

                                                <tr>
                                                    <td colspan="6">
                                                        <div id="dvAttachmentView" runat="server">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                                    <td colspan="100%">Attachments</td>
                                                                    <%--3439 Point 4--%>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <asp:Panel ID="pnlAttachmentDetailsView" runat="server" Width="714px" >
                                                            <table cellpadding="0" cellspacing="0" width="100%" style="height: 250px;">
                                                                <tr>
                                                                    <td width="100%" valign="top">
                                                                        <uc:ctrlAttachmentDetail ID="AttachmentDetails_Meeting_Review" runat="Server" isViewOnly="true" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <asp:Button ID="btnTrainingAudit_View" runat="server" Text="View Audit Trail" Visible="false"
                                                            OnClientClick="javascript:return AuditPopUpMeeting('SLTTraining');" />
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
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Visible="false" />&nbsp;
                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClientClick="javascript:return onPreviousStep();" />
                                            &nbsp;
                                            <asp:Button ID="btnSaveNnextCall" runat="server" Text="Save & Next" CausesValidation="true"
                                                OnClientClick="javascript:return SetValidationGroup();" OnClick="btnSaveNnextCall_Click" />
                                            <asp:Button ID="btnSaveNSend" runat="server" Text="Save" CausesValidation="true"
                                                ValidationGroup="vsErrorSchedule" Style="display: none" OnClick="btnSaveNSend_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnSendMail" runat="server" Text="Send" CausesValidation="true" OnClientClick="return CheckScheduleidForRLCM();"
                                                Style="display: none" />
                                            <asp:Button ID="btnSendMeetingView" runat="server" Text="Send" CausesValidation="false"
                                                OnClientClick="OpenPopupEmailSchedule('Next_Schedule');return false;" Style="display: none" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true"
                                                OnClientClick="javascript:return SetValidationGroup();" Style="display: none" />
                                            &nbsp;
                                            <asp:Button ID="btnNextStep" runat="server" Text="Next" OnClientClick="javascript:return onNextStep();"
                                                Style="display: none" />
                                            &nbsp;
                                            <asp:Button ID="btnSLTMeetingAudit_Trail" runat="server" Text="View Audit Trail"
                                                Visible="true" OnClientClick="javascript:return AuditPopUpMeeting('SLTMeeting');return false;" />
                                            <asp:Button ID="btnRecalculate" runat="server" Text="Recalculate Scores" OnClick="btnRecalculate_Click"
                                                Width="150px" OnClientClick="return confirm('This will recalculate score for all meetings available for current year. Are you sure to continue?');"
                                                Style="display: none" />
                                            <asp:Button ID="btnSend" runat="server" Text="Send" OnClientClick="javascript:OpenPopupEmail('Review');return false;"
                                                Style="display: none" />
                                            <asp:Button ID="btnHdnSend" runat="server" OnClick="btnSend_Click" Style="display: none" />
                                            <asp:Button ID="btnhdnBindRLCM_Training" runat="server" OnClick="btnhdnBindRLCM_Training_Click"
                                                Style="display: none" />
                                            <asp:Button ID="btnShowMemberHistory" Text="Show Member History" runat="server" OnClick="btnShowMemberHistory_Click"/>
                                            &nbsp;<%--<asp:Button ID="btnSendTO_RLCM" runat="server" Text="Send Minutes to RLCM" style="display:none;width:160px"   Enabled="false" OnClientClick="return CheckScheduleidForRLCM();"  OnClick="btnSendTO_RLCM_Click" />--%>
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
    <asp:HiddenField ID="hdnPanel" runat="server" />
    <asp:HiddenField ID="hdnPanel2" runat="server" />
    <asp:HiddenField ID="hdnEmail_Address" runat="server" />
    <asp:CustomValidator ID="CustomValidatorMembers" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorSLT_Members" />
    <input id="hdnControlIDsMembers" runat="server" type="hidden" />
    <input id="hdnErrorMsgsMembers" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorAttendees" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorAttendees" />
    <input id="hdnControlIDsAttendees" runat="server" type="hidden" />
    <input id="hdnErrorMsgsAttendees" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorcallToOrder" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorcallToOrder" />
    <input id="hdnControlIDscallToOrder" runat="server" type="hidden" />
    <input id="hdnErrorMsgscallToOrder" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorSafety" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorSafetywalkGroup" />
    <asp:CustomValidator ID="CustomValidatorBTSec" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorBTSecuritywalkGroup" />
    <input id="hdnControlIDsSafety" runat="server" type="hidden" />
    <input id="hdnErrorMsgsSafety" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorInspection" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorInspectionGroup" />
    <input id="hdnControlIDsInspection" runat="server" type="hidden" />
    <input id="hdnErrorMsgsInspection" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorClaim" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorClaimManagement" />
    <input id="hdnControlIDsClaim" runat="server" type="hidden" />
    <input id="hdnErrorMsgsClaim" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorTraining" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorTrainingGroup" />
    <input id="hdnControlIDsTraining" runat="server" type="hidden" />
    <input id="hdnErrorMsgsTraining" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorProcedure" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorProcedure" />
    <input id="hdnControlIDsProcedure" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProcedure" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorSuggestion" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorSuggestion" />
    <input id="hdnControlIDsSuggestion" runat="server" type="hidden" />
    <input id="hdnErrorMsgsSuggestion" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorSchedule" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorSchedule" />
    <input id="hdnControlIDsSchedule" runat="server" type="hidden" />
    <input id="hdnErrorMsgsSchedule" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorReview" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorMeetingReview" />
    <input id="hdnControlIDsReview" runat="server" type="hidden" />
    <input id="hdnErrorMsgsReview" runat="server" type="hidden" />
    <script type="text/javascript">

        function ValidateFields(sender, args) {
            var validatorID = sender.id;
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            if (validatorID.indexOf('Members') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsMembers.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsMembers.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsMembers.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Attendees') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsAttendees.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsAttendees.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsAttendees.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('callToOrder') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDscallToOrder.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDscallToOrder.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgscallToOrder.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Safety') > 0) {

                if (document.getElementById('ctl00_ContentPlaceHolder1_rdoSafety_Walk_Comp_0').checked) {
                    ctrlIDs = document.getElementById('<%=hdnControlIDsSafety.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsSafety.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsSafety.ClientID%>').value.split(',');
                }

            }
            else if (validatorID.indexOf('Inspection') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsInspection.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsInspection.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsInspection.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('WC') > 0) {
                ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_WC_hdnControlIDs').value.split(',');
                hdnID = 'ctl00_ContentPlaceHolder1_IncidentReview_WC_hdnControlIDs';
                Messages = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_WC_hdnErrorMsgs').value.split(',');
            }
            else if (validatorID.indexOf('AL') > 0) {
                ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_AL_hdnControlIDs').value.split(',');
                hdnID = 'ctl00_ContentPlaceHolder1_IncidentReview_AL_hdnControlIDs';
                Messages = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_AL_hdnErrorMsgs').value.split(',');
            }
            else if (validatorID.indexOf('PL') > 0) {
                ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_PL_hdnControlIDs').value.split(',');
                hdnID = 'ctl00_ContentPlaceHolder1_IncidentReview_PL_hdnControlIDs';
                Messages = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_PL_hdnErrorMsgs').value.split(',');
            }
            else if (validatorID.indexOf('DPD') > 0) {
                ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_DPD_hdnControlIDs').value.split(',');
                hdnID = 'ctl00_ContentPlaceHolder1_IncidentReview_DPD_hdnControlIDs';
                Messages = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_DPD_hdnErrorMsgs').value.split(',');
            }
            else if (validatorID.indexOf('Property') > 0) {
                ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_Property_hdnControlIDs').value.split(',');
                hdnID = 'ctl00_ContentPlaceHolder1_IncidentReview_Property_hdnControlIDs';
                Messages = document.getElementById('ctl00_ContentPlaceHolder1_IncidentReview_Property_hdnErrorMsgs').value.split(',');
            }
            else if (validatorID.indexOf('Claim') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsClaim.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsClaim.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsClaim.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Training') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsTraining.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsTraining.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsTraining.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Procedure') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsProcedure.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsProcedure.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsProcedure.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Suggestion') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsSuggestion.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsSuggestion.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsSuggestion.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Schedule') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsSchedule.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsSchedule.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsSchedule.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Review') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsReview.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsReview.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsReview.ClientID%>').value.split(',');
            }

    var focusCtrlID = "";

    if (hdnID != "") {
        if (document.getElementById(hdnID).value != "") {
            var i = 0;
            for (i = 0; i < ctrlIDs.length; i++) {
                var bEmpty = false;
                var ctrl = document.getElementById(ctrlIDs[i]);
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
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
        else
            args.IsValid = true;
    }
}


    </script>
</asp:Content>
