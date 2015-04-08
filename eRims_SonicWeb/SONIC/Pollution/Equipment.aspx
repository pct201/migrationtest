<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Equipment.aspx.cs" Inherits="SONIC_Pollution_Equipment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/Attachment_Pollution.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/AttachmentDetails_Pollution.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 2; i++) {
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

        function ShowPanel(index) {

            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                }
            }
        }
        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 3) {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
            }
            else {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
            }
        }

        function ConfirmDelete() {
            return confirm("Are you sure to remove the record?");
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;
            var selected_text = '<%=ViewState["AuditTrailText"]%>'
            if (selected_text == "Tank" || selected_text == "PM_Equipment_Tank") {
                obj = window.open('AuditPopup_PM_Equipment_Tank.aspx?id=<%=ViewState["PK_PM_Equipment_Tank"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (selected_text == "Paint Booth" || selected_text == "PM_Equipment_Spray_Booth") {
                obj = window.open('AuditPopup_PM_Equipment_Spray_Booth.aspx?id=<%=ViewState["PK_PM_Equipment_Spray_Booth"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (selected_text == "Prep Station" || selected_text == "PM_Equipment_Prep_Station") {
                obj = window.open('AuditPopup_PM_Equipment_Prep_Station.aspx?id=<%=ViewState["PK_PM_Equipment_Prep_Station"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (selected_text == "Oil and Water Separator" || selected_text == "PM_Equipment_OWS") {
                obj = window.open('AuditPopup_PM_Equipment_OWS.aspx?id=<%=ViewState["PK_PM_Equipment_OWS"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (selected_text == "Hydraulic Lift" || selected_text == "PM_Equipment_Hydraulic_Lift" || selected_text == "Alignment Rack") {
                obj = window.open('AuditPopup_PM_Equipment_Hydraulic_Lift.aspx?id=<%=ViewState["PK_PM_Equipment_Hydraulic_Lift"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (selected_text == "Paint Gun Cleaning Cabinet" || selected_text == "PM_Equipment_PGCC") {
                obj = window.open('AuditPopup_PM_Equipment_PGCC.aspx?id=<%=ViewState["PK_PM_Equipment_PGCC"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            else if (selected_text == "-- Select --" || selected_text == "0" || selected_text == "") {
                return false;
            }
    obj.focus();
    return false;
}
function ValSave() {
    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;

    var selected_text = '<%=ViewState["AuditTrailText"]%>'
    if (selected_text == "Tank" || selected_text == "PM_Equipment_Tank") {
        if (Page_ClientValidate('vsErrorGroupTank'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;
    }
    else if (selected_text == "Paint Booth" || selected_text == "PM_Equipment_Spray_Booth") {
        if (Page_ClientValidate('vsErrorSprayBooth'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;
    }
    else if (selected_text == "Prep Station" || selected_text == "PM_Equipment_Prep_Station") {
        if (Page_ClientValidate('vsErrorPrepStation'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;
    }
    else if (selected_text == "Oil and Water Separator" || selected_text == "PM_Equipment_OWS") {
        if (Page_ClientValidate('vsErrorGroupOWS'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;
    }
    else if (selected_text == "Hydraulic Lift" || selected_text == "PM_Equipment_Hydraulic_Lift") {
        if (Page_ClientValidate('vsErrorHydraulicLift'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;
    }
    else if (selected_text == "Paint Gun Cleaning Cabinet" || selected_text == "PM_Equipment_PGCC") {
        if (Page_ClientValidate('vsErrorPGCC'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;
    }
    else if (selected_text == "-- Select --" || selected_text == "0" || selected_text == "") {
        if (Page_ClientValidate('vsErrorGroupEquipment'))
            return true;
        else
            Page_ClientValidate('dummy'); return false;

    }
}

function OpenPopupSludge() {
    var winHeight = window.screen.availHeight - 400;
    var winWidth = window.screen.availWidth - 500;
    obj = window.open('AuditPopup_Sludge_Removal.aspx?id=<%=ViewState["PK_PM_Equipment_OWS_SR"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');

}
function displaySludge(strdisplay) {
    document.getElementById('Menu2').style.display = strdisplay;
    document.getElementById('<%=btnSaveView.ClientID %>').style.display = strdisplay;
    if (document.getElementById('<%=btnAuditTrail.ClientID %>') != null)
        document.getElementById('<%=btnAuditTrail.ClientID %>').style.display = strdisplay;
    document.getElementById('<%=btnBack.ClientID %>').style.display = strdisplay;
}
function viewSludge(strdisplay) {
    document.getElementById('Menu2').style.display = strdisplay;
    document.getElementById('<%=btnEdit.ClientID %>').style.display = strdisplay;
    document.getElementById('<%=btnAuditTrail.ClientID %>').style.display = strdisplay;
    document.getElementById('<%=btnBack.ClientID %>').style.display = strdisplay;
}
function OpenPopupHydraulicLift() {
    var winHeight = window.screen.availHeight - 400;
    var winWidth = window.screen.availWidth - 500;
    obj = window.open('AuditPopup_PM_Equipment_Hydraulic_Lift_Grid.aspx?id=<%=ViewState["PK_PM_Equipment_Hydraulic_Lift_Grid"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');

}
function displayHydraulicLift(strdisplay) {
    document.getElementById('Menu2').style.display = strdisplay;
    document.getElementById('<%=btnSaveView.ClientID %>').style.display = strdisplay;
    if (document.getElementById('<%=btnAuditTrail.ClientID %>') != null)
        document.getElementById('<%=btnAuditTrail.ClientID %>').style.display = strdisplay;
    document.getElementById('<%=btnBack.ClientID %>').style.display = strdisplay;
}
function viewHydraulicLift(strdisplay) {
    document.getElementById('Menu2').style.display = strdisplay;
    document.getElementById('<%=btnEdit.ClientID %>').style.display = strdisplay;
    document.getElementById('<%=btnAuditTrail.ClientID %>').style.display = strdisplay;
    document.getElementById('<%=btnBack.ClientID %>').style.display = strdisplay;
}
function ValidateFieldsTank(sender, args) {
    var msg = '';
    var ctrlIDs = document.getElementById('<%=hdnControlIDsTank.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsTank.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsTank.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsEquipment(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsEquipment.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsEquipment.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsEquipment.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsSprayBooth(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsSprayBooth.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsSprayBooth.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsSprayBooth.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsPrepStation(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsPrepStation.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsPrepStation.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsPrepStation.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsHydraulicLiftGrid(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsHydraulicLiftGrid.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsHydraulicLiftGrid.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsHydraulicLiftGrid.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsPGCC(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsPGCC.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsPGCC.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsPGCC.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsOWS(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsOWS.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsOWS.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsOWS.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        function ValidateFieldsOWSInnerGrid(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsOWSInnerGrid.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsOWSInnerGrid.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsOWSInnerGrid.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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

        //#3187
        function showCalendarEquipment(id, format, AfterSelect, AfterSelArgs) {
            //hardik
            var el = document.getElementById(id);
            if (calendar != null) {

                calendar.hide();

            } else {

                var cal = new Calendar(false, null, selected, closeHandler, AfterSelect, AfterSelArgs);

                calendar = cal;

                cal.setRange(1900, 2070);

                cal.create();
            }


            calendar.setDateFormat(format);

            calendar.parseDate(el.value);

            calendar.sel = el;

            calendar.showAtElement(el);
            $(calendar.element).find('td.day').click(function () {
                var date = calendar.date;
                var newDate = new Date(parseInt(date.getFullYear()) + 5, date.getMonth(), date.getDate());
                $('#<%=txtSPCCExpiration_Date.ClientID%>').val(("0" + parseInt(newDate.getMonth() + 1)).slice(-2) + "/" + ("0" + newDate.getDate()).slice(-2) + "/" + newDate.getFullYear());
            });
            return false;

        }

    </script>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;" colspan="2"></td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">Equipment
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Equipment</span><asp:Label
                                            ID="lblRequire" runat="server" Text="*" CssClass="mf"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: inline;">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblEquipment"
                                                    runat="server">
                                                    <tr>
                                                        <td colspan="6" class="bandHeaderRow">Equipment
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Equipment Type &nbsp;<span style="color: Red">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpEquipmentType" Width="175px" runat="server" SkinID="dropGen"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpEquipmentType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpEquipmentType"
                                                                Display="None" ErrorMessage="Please Select [Equipment]/ Equipment Type" InitialValue="0"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroupEquipment" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="pnlTank" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Manufacturer&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:TextBox ID="txtTankManufacture" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Description &nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:TextBox ID="txtDescription" runat="server" Width="170px" MaxLength="100" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Ground Location
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoGround_Location" runat="server" RepeatDirection="Horizontal"
                                                                    CellPadding="0" CellSpacing="0">
                                                                    <asp:ListItem Text="On Surface" Value="S" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Underground" Value="U"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Identification&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtIdentification" runat="server" Width="170px" MaxLength="50" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Contents&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_Tank_Contents" Width="175px" runat="server" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" valign="top">Other Contents&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtContents_Other" runat="server" Width="170px" MaxLength="50" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Material&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_Tank_Material" Width="175px" runat="server" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" valign="top">Other Material&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtMaterial_Other" runat="server" Width="170px" MaxLength="50" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Construction&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_Tank_Construction" Width="175px" runat="server" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" valign="top">Other Construction&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtConstruction_Other" runat="server" Width="170px" MaxLength="50" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Capacity in Gallons&nbsp;<span id="Span10" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCapcity" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                                    onpaste="return false" />
                                                            </td>
                                                            <td align="left" valign="top">Certificate Number&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCertificate_Number" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Is Tank UL Certified?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdbULCertified" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Is Tank Secure during Non-Business Hours?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdbSecureNonBusiness" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Installation Date&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtInstallation_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInstallation_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revInstallation_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtInstallation_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Installation Firm&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtInstallation_Firm" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Last Maintenance Date&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtLast_Maintenance_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Last Maintenance Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLast_Maintenance_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revLast_Maintenance_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Last Maintenance Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtLast_Maintenance_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Last Revision Date&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtLast_Revision_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Last Revision Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLast_Revision_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revLast_Revision_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Last Revision Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtLast_Revision_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank In Use?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoTank_In_Use" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Last Inspection Date&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtLast_Inspection_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Last Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLast_Inspection_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revLast_Inspection_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Last Inspection Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtLast_Inspection_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Closure Date&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtClosure_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Closure Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtClosure_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revClosure_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Closure Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtClosure_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Removal Date&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtRemoval_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Removal Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRemoval_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revRemoval_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Removal Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtRemoval_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Revised Removal Date&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtRevised_Removal_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Revised Removal Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRevised_Removal_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revRevised_Removal_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Revised Removal Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtRevised_Removal_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Permit Begin Date&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPermit_Begin_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Permit Begin Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Begin_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revPermit_Begin_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Permit Begin Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtPermit_Begin_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Permit End Date&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPermit_End_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Permit End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_End_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revPermit_End_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Permit End Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtPermit_End_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="[Equipment]/Permit End Date Should Be Greater Then Or Equal To Permit Begin Date"
                                                                    ControlToValidate="txtPermit_End_Date" ControlToCompare="txtPermit_Begin_Date"
                                                                    SetFocusOnError="true" Operator="GreaterThanEqual" Type="Date" Display="None"
                                                                    ValidationGroup="vsErrorGroupTank"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Registration Required?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoRegistration_Required" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Registration Number&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtRegistration_Number" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Leak Detection Required?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoLeak_Detection_Required" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Leak Detection Type&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtLeak_Detection_Type" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Overfill Protection?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoOverfill_Protection" runat="server" SkinID="YesNoType">
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
                                                            <td align="left" valign="top">Secondary Containment Adequate?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoSecondary_Containment_Adequate" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Secondary Containment Type&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_LU_Secondary_Containment_Type" Width="175px" runat="server"
                                                                    SkinID="dropGen">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Description of Other Reporting Requirements&nbsp;<span id="Span25" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtDescription_Other_Reporting_Requirements" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Plan Date&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPlan_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Plan Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revPlan_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Plan Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtPlan_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Plan Identification&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPlan_Identification" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Recommendations&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtRecommendations" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Effective Date&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtEffective_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Effective Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEffective_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revEffective_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Effective Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtEffective_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Expiration Date&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExpiration_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Expiration Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtExpiration_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revExpiration_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Expiration Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtExpiration_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="[Equipment]/Expiration Date Should Be Greater Then Or Equal To Effective Date"
                                                                    ControlToValidate="txtExpiration_Date" ControlToCompare="txtEffective_Date" SetFocusOnError="true"
                                                                    Operator="GreaterThanEqual" Type="Date" Display="None" ValidationGroup="vsErrorGroupTank"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Record Keeping Requirements&nbsp;<span id="Span31" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtRecordkeeping_Requirements" runat="server" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" valign="top" style="font-weight: bold;">SPCC&nbsp;
                                                            </td>
                                                            <td align="center" valign="top"></td>
                                                            <td align="left" colspan="4" valign="top"></td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" valign="top">SPCC Required&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <asp:RadioButtonList ID="rdoSPCC_Required" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" valign="top">Date Developed&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtSPCCDate_Developed" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Date Developed" onclick="return showCalendarEquipment('ctl00_ContentPlaceHolder1_txtSPCCDate_Developed', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revtxtSPCCDate_Developed" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/SPCC Date Developed is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtSPCCDate_Developed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Expiration Date&nbsp;<span id="Span72" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtSPCCExpiration_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Permit End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSPCCExpiration_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revtxtSPCCExpiration_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/SPCC Expiration Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtSPCCExpiration_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="[Equipment]/SPCC Expiration Date Should Be Greater Then Or Equal To SPCC Date Developed"
                                                                    ControlToValidate="txtSPCCExpiration_Date" ControlToCompare="txtSPCCDate_Developed"
                                                                    SetFocusOnError="true" Operator="GreaterThanEqual" Type="Date" Display="None"
                                                                    ValidationGroup="vsErrorGroupTank"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td align="left" valign="top">
                                                                Inadvertent Release Control and Countermeasures Plan&nbsp;<span id="Span32" style="color: Red;
                                                                    display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtRelease_Control_Countermeasures_Plan" runat="server" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Maintenance Vendor&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtMaintenance_Vendor" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top">Vendor Contact Name&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtVendor_Contact_Name" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Vendor Contact Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span35" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtVendor_Contact_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                    SkinID="txtPhone" />
                                                                <asp:RegularExpressionValidator ID="revtxtHome_Phone" ControlToValidate="txtVendor_Contact_Telephone"
                                                                    runat="server" ErrorMessage="Please Enter [Equipment]/Vendor Contact Telephone in XXX-XXX-XXXX format."
                                                                    ValidationGroup="vsErrorGroupTank" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Insurer&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtInsurer" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Coverage Start Date&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCoverage_Start_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Coverage Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCoverage_Start_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revCoverage_Start_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Coverage Start Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtCoverage_Start_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Coverage End Date&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCoverage_End_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Coverage End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCoverage_End_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revCoverage_End_Date" runat="server" ValidationGroup="vsErrorGroupTank"
                                                                    Display="none" ErrorMessage="[Equipment]/Coverage End Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtCoverage_End_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="[Equipment]/Coverage End Date Should Be Greater Then Or Equal To Coverage Start Date"
                                                                    ControlToValidate="txtCoverage_End_Date" ControlToCompare="txtCoverage_Start_Date"
                                                                    SetFocusOnError="true" Operator="GreaterThanEqual" Type="Date" Display="None"
                                                                    ValidationGroup="vsErrorGroupTank"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Multiple Event/Total Coverage&nbsp;<span id="Span39" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtMultiple_Event_Total_Coverage" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                                    onpaste="return false" />
                                                            </td>
                                                            <td align="left" valign="top">Single Event Coverage&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtSingle_Event_Coverage" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                                    onpaste="return false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Inspection Company&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtInspection_Company" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top">Inspection Company Contact Name&nbsp;<span id="Span42" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtInspection_Company_Contact_Name" runat="server" Width="170px"
                                                                    MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Inspection Company Contact Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span43" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtInspection_Company_Contact_Telephone" runat="server" Width="170px"
                                                                    MaxLength="12" SkinID="txtPhone" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtInspection_Company_Contact_Telephone"
                                                                    ValidationGroup="vsErrorGroupTank" runat="server" ErrorMessage="Please Enter [Equipment]/Inspection Company Contact Telephone in XXX-XXX-XXXX format."
                                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlSprayBooth" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <%-- <td align="left" width="18%" valign="top">
                                                                Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblEquiptmentSprayBooth" runat="server"></asp:Label>
                                                            </td>--%>
                                                            <td align="left" width="18%" valign="top">Description &nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:TextBox ID="txtSprayBoothDesc" runat="server" Width="550px" MaxLength="100" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="18%">Manufacturer Name&nbsp;<span id="Span46" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="4%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtManufacturer_Name" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top" width="18%">Installation Date&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="4%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtInstallationDate" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInstallationDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorSprayBooth"
                                                                    Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtInstallationDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Configured for Water Borne Application?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoConfigured_For_Water_Borne_Application" runat="server"
                                                                    SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Direct or Indirect Burners?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoDirect_Indirect_Burners" runat="server" RepeatDirection="Horizontal"
                                                                    CellPadding="0" CellSpacing="0">
                                                                    <asp:ListItem Text="Direct" Value="D" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Indirect" Value="I"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">BTU Rating&nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtBTU_Rating" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Height In Feet&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHeight_In_Feet" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Width in Feet&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtWidth_In_Feet" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Depth in Feet&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtDepth_In_Feet" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Technology&nbsp;<span id="Span52" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtFilter_System" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top">Manual for Paint Booth location in 6H Binder?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdbManual6HBinder" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Capture Efficiency&nbsp;<span id="Span53" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCapture_Efficiency" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,5,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency&nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtControl_Efficiency" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,5,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Capture Efficiency as of Date&nbsp;<span id="Span55" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCaptureEfficiencyDate" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Capture Efficiency as of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCaptureEfficiencyDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationGroup="vsErrorSprayBooth"
                                                                    Display="none" ErrorMessage="[Equipment]/Capture Efficiency as of Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtCaptureEfficiencyDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency as of Date&nbsp;<span id="Span56" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtControlEfficiencyDate" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Control Efficiency as of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtControlEfficiencyDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                    ValidationGroup="vsErrorSprayBooth" Display="none" ErrorMessage="[Equipment]/Control Efficiency as of Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtControlEfficiencyDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Stack Height Above Grade in Feet&nbsp;<span id="Span57" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtStack_Height_In_Feet" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,7,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Exit Flow Rate in Cubic Feet Per Minute&nbsp;<span id="Span58" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExit_Flow_Rate_CFM" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,8,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Exit Temperature (Low) Degrees Farenheight&nbsp;<span id="Span59" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExit_Temperature_Low" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,8,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Exit Temperature (High) Degrees Farenheight&nbsp;<span id="Span60" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExit_Temperature_High" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,8,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes&nbsp;<span id="Span61" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtSprayBoothNotes" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlPrepStation" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <%-- <td align="left" width="18%" valign="top">
                                                                Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblEquiptmentPrepStation" runat="server"></asp:Label>
                                                            </td>--%>
                                                            <td align="left" width="18%" valign="top">Description &nbsp;<span id="Span86" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:TextBox ID="txtPrepStationDesc" runat="server" Width="550px" MaxLength="100" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="18%">Manufacturer Name&nbsp;<span id="Span87" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="4%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtManufacturer_Name_PrepStation" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top" width="18%">Installation Date&nbsp;<span id="Span88" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="4%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtInstallationDate_PrepStation" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInstallationDate_PrepStation', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                    ValidationGroup="vsErrorPrepStation" Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtInstallationDate_PrepStation" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Configured for Water Borne Application?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoConfigured_For_Water_Borne_Application_PrepStation" runat="server"
                                                                    SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Direct or Indirect Burners?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoDirect_Indirect_Burners_PrepStation" runat="server" RepeatDirection="Horizontal"
                                                                    CellPadding="0" CellSpacing="0">
                                                                    <asp:ListItem Text="Direct" Value="D" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Indirect" Value="I"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">BTU Rating&nbsp;<span id="Span89" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtBTU_Rating_PrepStation" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Height In Feet&nbsp;<span id="Span90" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHeight_In_Feet_PrepStation" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Width in Feet&nbsp;<span id="Span91" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtWidth_In_Feet_PrepStation" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Depth in Feet&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtDepth_In_Feet_PrepStation" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Technology&nbsp;<span id="Span93" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtFilter_System_PrepStation" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top">Manual for Prep Station location in 6H Binder?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdbManual6HBinder_PrepStation" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Capture Efficiency&nbsp;<span id="Span94" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCapture_Efficiency_PrepStation" runat="server" Width="170px"
                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency&nbsp;<span id="Span95" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtControl_Efficiency_PrepStation" runat="server" Width="170px"
                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Capture Efficiency as of Date&nbsp;<span id="Span96" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCaptureEfficiencyDate_PrepStation" runat="server" Width="150px"
                                                                    SkinID="txtDate" />
                                                                <img alt="Capture Efficiency as of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCaptureEfficiencyDate_PrepStation', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                    ValidationGroup="vsErrorPrepStation" Display="none" ErrorMessage="[Equipment]/Capture Efficiency as of Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtCaptureEfficiencyDate_PrepStation"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency as of Date&nbsp;<span id="Span97" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtControlEfficiencyDate_PrepStation" runat="server" Width="150px"
                                                                    SkinID="txtDate" />
                                                                <img alt="Control Efficiency as of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtControlEfficiencyDate_PrepStation', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                                    ValidationGroup="vsErrorPrepStation" Display="none" ErrorMessage="[Equipment]/Control Efficiency as of Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtControlEfficiencyDate_PrepStation"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Stack Height Above Grade in Feet&nbsp;<span id="Span98" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtStack_Height_In_Feet_PrepStation" runat="server" Width="170px"
                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,7,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Exit Flow Rate in Cubic Feet Per Minute&nbsp;<span id="Span99" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExit_Flow_Rate_CFM_PrepStation" runat="server" Width="170px"
                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,8,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Exit Temperature (Low) Degrees Farenheight&nbsp;<span id="Span100" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExit_Temperature_Low_PrepStation" runat="server" Width="170px"
                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,8,false);" />
                                                            </td>
                                                            <td align="left" valign="top">Exit Temperature (High) Degrees Farenheight&nbsp;<span id="Span101" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtExit_Temperature_High_PrepStation" runat="server" Width="170px"
                                                                    onpaste="return false" onkeypress="return FormatNumber(event,this.id,8,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes&nbsp;<span id="Span102" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtPrepStationNotes" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlOWS" runat="server" Visible="false">
                                                    <asp:Panel ID="pnlOWSDetail" runat="server">
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <%--<td align="left" width="18%" valign="top">
                                                                    Equipment Type
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblOWS" runat="server"></asp:Label>
                                                                </td>--%>
                                                                <td align="left" width="18%" valign="top">Description &nbsp;<span id="Span62" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:TextBox ID="txtOWSDescription" runat="server" Width="550px" MaxLength="100" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" width="18%">Connected to Public Water System?
                                                                </td>
                                                                <td align="center" valign="top" width="4%">:
                                                                </td>
                                                                <td align="left" valign="top" width="28%">
                                                                    <asp:RadioButtonList ID="rdOWSConnectedtoPublicWater" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top" width="18%">Installation Date&nbsp;<span id="Span63" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top" width="4%">:
                                                                </td>
                                                                <td align="left" valign="top" width="28%">
                                                                    <asp:TextBox ID="txtOWS_Installation_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                    <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOWS_Installation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="vsErrorGroupOWS"
                                                                        Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtOWS_Installation_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Manufacturer&nbsp;<span id="Span64" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtOWSManufacturer_Name" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Service Provider&nbsp;<span id="Span65" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtOWSInspectionCompany" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">Service Provider Contact Person&nbsp;<span id="Span66" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtInspectionCompanyContactName" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Service Provider Telephone Number (XXX-XXX-XXXX)&nbsp;<span id="Span67" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtOWSTelephone" runat="server" Width="170px" MaxLength="12" SkinID="txtPhone" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtOWSTelephone"
                                                                        runat="server" ErrorMessage="Please Enter [Equipment]/Service Provider Contact Telephone in XXX-XXX-XXXX format."
                                                                        ValidationGroup="vsErrorGroupOWS" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">Sludge Removal Date Grid
                                                                    <br />
                                                                    <asp:LinkButton ID="lnkAddHazards" runat="server" Text="--Add--" ValidationGroup="vsErrorGroupOWS"
                                                                        CausesValidation="true" OnClick="lnkAddSludgeRemovalDate_Click" />
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:GridView ID="gvSludge" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                        EnableViewState="true" AllowPaging="true" OnRowCommand="gvSludge_RowCommand" OnPageIndexChanging="gvSludge_PageIndexChanging">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sludge Removal Date">
                                                                                <ItemStyle Width="40%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemovalDate" runat="server" Text='<%#(Eval("Sludge_Removal_Date")) == DBNull.Value ? "" : Eval("Sludge_Removal_Date", "{0:MM/dd/yyyy}")%>'
                                                                                        CommandName="EditSludge" CommandArgument='<%# Eval("PK_PM_Equipment_OWS_SR") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Sludge Removed By">
                                                                                <ItemStyle Width="40%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemoveby" runat="server" Text='<%#Eval("Sludge_Removed_By")%>'
                                                                                        CommandName="EditSludge" CommandArgument='<%# Eval("PK_PM_Equipment_OWS_SR") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton runat="server" ID="lnkDeleteRole" Text=" Remove " CausesValidation="false"
                                                                                        OnClientClick="return ConfirmDelete();" CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_PM_Equipment_OWS_SR") %>'>
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            <table cellpadding="4" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                        <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Exits"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Notes&nbsp;<span id="Span68" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtOWSNotes" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlAddSludge" runat="server" Visible="false">
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" valign="top">
                                                                    <div class="bandHeaderRow">
                                                                        Equipment Type Screen – OWS – Sludge Removal Grid Screen
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Sludge Removal Date&nbsp;<span id="Span69" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtSludgeRemovalDate" runat="server" Width="150px" SkinID="txtDate" />
                                                                    <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSludgeRemovalDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="vsErrorGroupOWSInnerGrid"
                                                                        Display="none" ErrorMessage="[Equipment]/Sludge Removal Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtSludgeRemovalDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Sludge Removed By&nbsp;<span id="Span70" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtSludgeRemovedBy" runat="server" Width="150px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">TCLP Performed?
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:RadioButtonList ID="rdbTCLPPerformed" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">TCLP Conducted Date&nbsp;<span id="Span85" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtTCLPConductedDate" runat="server" Width="150px" SkinID="txtDate" />
                                                                    <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTCLPConductedDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                        ValidationGroup="vsErrorGroupOWSInnerGrid" Display="none" ErrorMessage="[Equipment]/TCLP Conducted Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtTCLPConductedDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">TCLP On File?
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <asp:RadioButtonList ID="rdbTCLPonFile" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Notes&nbsp;<span id="Span71" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtSludgeNotes" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="top" colspan="6">
                                                                    <asp:Button ID="btnSaveSludge" runat="server" Text="Save" OnClick="btnSaveSludge_Click"
                                                                        CausesValidation="true" ValidationGroup="vsErrorGroupOWSInnerGrid" />
                                                                    <asp:Button ID="btnAuditSludge" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                                        OnClientClick="OpenPopupSludge();return false;" />
                                                                    <asp:Button ID="btnCancelSludge" runat="server" Text="Cancel" OnClick="btnCancelSludge_Click"
                                                                        CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlHydraulicLiftType" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top" width="20%"></td>
                                                            <td align="center" valign="top"></td>
                                                            <td align="left" valign="top" width="20%"></td>
                                                            <td align="left" valign="top" width="30%"></td>
                                                            <td align="center" valign="top"></td>
                                                            <td align="left" valign="top"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" colspan="4" width="80%">Apply the Installation and Inspection Dates of the First Installed <span id="spnInstalledLift" runat="server">Lift</span> in the Below
                                                                Grid to all Installed <span id="spnInstalledLift2" runat="server">Lifts</span> in the Grid?                                                                
                                                            </td>
                                                            <td align="left" valign="top" colspan="2" width="20%">
                                                                <asp:RadioButtonList ID="rdbUseSameDates" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <span id="spnLiftGrid" runat="server">Hydraulic Lift</span> Grid                                                                
                                                                <br />
                                                                <asp:LinkButton ID="lnkAddHydraulicLift" runat="server" Text="--Add--" OnClick="lnkAddHydraulicLift_Click" />
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="gvHydraulicLift" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                    EnableViewState="true" AllowPaging="true" OnRowCommand="gvHydraulicLift_RowCommand" AllowSorting="true" OnPageIndexChanging="gvHydraulicLift_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Lift Number">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkIs_Number_Of_Lifts_At_Location" runat="server" Text='<%#Eval("Is_Number_Of_Lifts_At_Location")%>'
                                                                                    CommandName="EditHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Manufacturer">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkManufacturer_Name" runat="server" Text='<%#Eval("Manufacturer_Name")%>'
                                                                                    CommandName="EditHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Above Ground">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkAbove_Ground" runat="server" Text='<%# Convert.ToString(Eval("Above_Ground"))==""?"No":(Convert.ToString(Eval("Above_Ground"))=="Y"?"Yes":"No")%>'
                                                                                    CommandName="EditHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installation Date">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkInstallation_Date" runat="server" Text='<%#(Eval("Installation_Date")) == DBNull.Value ? "" : Eval("Installation_Date", "{0:MM/dd/yyyy}")%>'
                                                                                    CommandName="EditHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Last Inspection Date">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkLast_Inspection_Date" runat="server" Text='<%#(Eval("Last_Inspection_Date")) == DBNull.Value ? "" : Eval("Last_Inspection_Date", "{0:MM/dd/yyyy}")%>'
                                                                                    CommandName="EditHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="lnkDeleteRole" Text=" Remove " CausesValidation="false"
                                                                                    OnClientClick="return ConfirmDelete();" CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table cellpadding="4" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Exits"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--<table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                             <td align="left" width="18%" valign="top">
                                                                Equipment Type
                                                            </td>
                                                            <td align="center" width="3%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblHydraulicLiftType" runat="server" />
                                                            </td>
                                                            <td align="left" width="18%" valign="top">
                                                                Description &nbsp;<span id="Span72" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="3%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:TextBox ID="txtHydraulicLiftDescription" runat="server" Width="550px" MaxLength="100" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="18%">
                                                                Oil Type&nbsp;<span id="Span73" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="3%">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtOil_Type" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top" width="20%">
                                                                Above Ground?
                                                            </td>
                                                            <td align="center" valign="top" width="3%">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:RadioButtonList ID="rdoAbove_Ground" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Manufacturer&nbsp;<span id="Span74" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHydraulicLiftManufacture" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Number of Lifts at the Location?&nbsp;<span id="Span75" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtIs_Number_Of_Lifts_At_Location" MaxLength="10" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Lift Number&nbsp;<span id="Span76" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtNumber_Of_Lifts_At_Location" MaxLength="3" onkeypress="return numberOnly(event);"
                                                                    onpaste="return false;" runat="server" Width="170px" />
                                                            </td>
                                                            <td align="left" valign="top">
                                                                As of Date (Number)&nbsp;<span id="Span77" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtAs_Of_Date_Number" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="As of Date (Number)" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAs_Of_Date_Number', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revAs_Of_Date_Number" runat="server" ValidationGroup="vsErrorHydraulicLift"
                                                                    Display="none" ErrorMessage="[Equipment]/As of Date (Number) is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtAs_Of_Date_Number" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Installation Date&nbsp;<span id="Span78" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHydraulicLift_Installation_Date" runat="server" Width="150px"
                                                                    SkinID="txtDate" />
                                                                <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHydraulicLift_Installation_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorHydraulicLift"
                                                                    Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtHydraulicLift_Installation_Date"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Last Annual Inspection Date&nbsp;<span id="Span79" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHydraulicLift_Last_Inspection_Date" runat="server" Width="150px"
                                                                    SkinID="txtDate" />
                                                                <img alt="Last Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHydraulicLift_Last_Inspection_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorHydraulicLift"
                                                                    Display="none" ErrorMessage="[Equipment]/Last Inspection Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtHydraulicLift_Last_Inspection_Date"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Have Any In-Ground Lifts Been Removed from the Location?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoAny_Inground_Lifts_Been_Removed" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If Yes, Is Documentation Related to Lift Removal Attached?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoDocumentation_Related_To_Removed_Lifts" runat="server"
                                                                    SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span80" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtHydraulicLiftNotes" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlAdd_Hydraulic_Lift" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="6" valign="top">
                                                                <div class="bandHeaderRow">
                                                                    Equipment Type Screen – <span id="spnEquipmentTypeScreen" runat="server">Hydraulic Lift – Hydraulic Lift</span> Grid Screen
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <span id="spLiftNumber" runat="server">Lift</span> Number&nbsp;<span id="Span103" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtNumber_Of_Lifts_At_Location" MaxLength="3" onkeypress="return numberOnly(event);"
                                                                    onpaste="return false;" runat="server" Width="170px" />
                                                            </td>
                                                            <td align="left" valign="top">Replacement <span id="spnReplacementLiftRack" runat="server">Lift</span>?<span id="spnReplacementLift" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoReplacementLift" SkinID="YNTypeNullSelection" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <span id="spLiftNumberAsOfDate" runat="server">Lift</span> Number As of Date&nbsp;<span id="Span104" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:TextBox ID="txtAs_Of_Date_Number" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Lift Number As of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAs_Of_Date_Number', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revAs_Of_Date_Number" runat="server" ValidationGroup="vsErrorHydraulicLiftGrid"
                                                                    Display="none"
                                                                    SetFocusOnError="true" ControlToValidate="txtAs_Of_Date_Number" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Description &nbsp;<span id="Span105" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="3%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtHydraulicLiftDescription" runat="server" Width="150px" MaxLength="100" />
                                                            </td>
                                                            <td align="left" valign="top" width="18%">Oil Type&nbsp;<span id="Span106" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtOil_Type" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top"></td>
                                                            <td align="center" width="3%" valign="top"></td>
                                                            <td align="left" valign="top" width="28%"></td>
                                                            <td align="left" valign="top" width="18%">Status
                                                                &nbsp;<span id="spnStatus" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                                    <asp:ListItem Text="Active" Value="A"></asp:ListItem>
                                                                    <asp:ListItem Text="Non-Active" Value="N" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Removed" Value="R"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="20%">Above Ground?&nbsp;<span id="spnAbove_Ground" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:RadioButtonList ID="rdoAbove_Ground" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Manufacturer&nbsp;<span id="Span107" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHydraulicLiftManufacture" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Installation Date&nbsp;<span id="Span108" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHydraulicLift_Installation_Date" runat="server" Width="150px"
                                                                    SkinID="txtDate" />
                                                                    <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHydraulicLift_Installation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorHydraulicLiftGrid"
                                                                    Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtHydraulicLift_Installation_Date"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" valign="top">Last Annual Inspection Date&nbsp;<span id="Span109" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtHydraulicLift_Last_Inspection_Date" runat="server" Width="150px"
                                                                    SkinID="txtDate" />
                                                                    <img alt="Last Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHydraulicLift_Last_Inspection_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" runat="server" id="imgInspectionDate" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                                    ValidationGroup="vsErrorHydraulicLiftGrid" Display="none" ErrorMessage="[Equipment]/Last Inspection Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtHydraulicLift_Last_Inspection_Date"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Have Any In-Ground <span id="spnInGroundLifts" runat="server">Lifts</span> been Removed from the Location?&nbsp;
                                                            </td>
                                                            <td align="center" width="3%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:RadioButtonList ID="rdoInGroundLifts" runat="server" SkinID="YesNoType" AutoPostBack="true" OnSelectedIndexChanged="rdoInGroundLifts_SelectedIndexChanged">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top" width="18%">If Yes, is Documentation Related to <span id="spnDocumentation" runat="server">Lift</span> Removal Attached?
                                                                &nbsp;<span id="spnDocumentRelatedtoLifts" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:RadioButtonList ID="rdoDocumentRelatedtoLifts" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <asp:Panel runat="server" ID="pnlReplacementLiftInformation">
                                                            <tr>
                                                                <td colspan="6"><b>Replacement <span id="spnReplacementLiftInformation" runat="server">Lift</span> Information</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Description &nbsp;<span id="spnReplacementLiftDescription" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="3%" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" width="28%">
                                                                    <asp:TextBox ID="txtReplacementLiftDescription" runat="server" Width="150px" MaxLength="100" Enabled="false" />
                                                                </td>
                                                                <td align="left" valign="top" width="18%">Oil Type&nbsp;<span id="spnOilType" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top" width="3%">:
                                                                </td>
                                                                <td align="left" valign="top" width="28%">
                                                                    <asp:TextBox ID="txtReplacementOilType" runat="server" Width="170px" MaxLength="75" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Above Ground? &nbsp;<span id="spnAboveGround" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="3%" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top" width="28%">
                                                                    <asp:RadioButtonList ID="rdoAboveGround" runat="server" SkinID="YesNoType" Enabled="false" />
                                                                </td>
                                                                <td align="left" valign="top" width="18%">Manufacturer&nbsp;<span id="spnManufacturer" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top" width="3%">:
                                                                </td>
                                                                <td align="left" valign="top" width="28%">
                                                                    <asp:TextBox ID="txtManufacturer" runat="server" Width="170px" MaxLength="75" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Installation Date&nbsp;<span id="spnReplacementInstallationDate" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtReplacementInstallationDate" runat="server" Width="150px" Enabled="false"
                                                                        SkinID="txtDate" />
                                                                    <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReplacementInstallationDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" runat="server" id="imgInstallationDate1" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ValidationGroup="vsErrorHydraulicLiftGrid"
                                                                        Display="none" ErrorMessage="[Equipment]/Replacement Installation Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtReplacementInstallationDate"
                                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">Last Annual Inspection Date&nbsp;<span id="spnReplacementLastAnnualInspectionDate" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtReplacementLastAnnualInspectionDate" runat="server" Width="150px" Enabled="false"
                                                                        SkinID="txtDate" />
                                                                    <img alt="Last Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReplacementLastAnnualInspectionDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" runat="server" id="imgLastAnnualInspectionDate1" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                                        ValidationGroup="vsErrorHydraulicLiftGrid" Display="none" ErrorMessage="[Equipment]/Replacement Last Inspection Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtReplacementLastAnnualInspectionDate"
                                                                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Notes&nbsp;<span id="spnReplacementNotes" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtReplacementNotes" runat="server" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Removal Date&nbsp;<span id="Span110" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtHydraulicLift_Removal_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                    <img alt="Removal Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHydraulicLift_Removal_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" id="imgHydraulicLift_Removal_Date" runat="server" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorHydraulicLiftGrid"
                                                                        Display="none" ErrorMessage="[Equipment]/Removal Date is not a valid date" SetFocusOnError="true"
                                                                        ControlToValidate="txtHydraulicLift_Removal_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td colspan="3">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Notes&nbsp;<span id="Span111" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtHydraulicLiftNotes" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="top" colspan="6">
                                                                    <asp:Button ID="btnSave_Hydraulic_Lift" runat="server" Text="Save" OnClick="btnSaveHydraulicLift_Click"
                                                                        CausesValidation="true" ValidationGroup="vsErrorHydraulicLiftGrid" />
                                                                    <asp:Button ID="btnAudit_Hydraulic_Lift" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                                        OnClientClick="OpenPopupHydraulicLift();return false;" />
                                                                    <asp:Button ID="btnCancel_Hydraulic_Lift" runat="server" Text="Cancel" OnClick="btnCancelHydraulicLift_Click"
                                                                        CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlPGCC" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <%-- <td align="left" width="18%" valign="top">
                                                                Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblPGCCType" runat="server"></asp:Label>
                                                            </td>--%>
                                                            <td align="left" width="18%" valign="top">Description &nbsp;<span id="Span81" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:TextBox ID="txtPGCCDescription" runat="server" Width="550px" MaxLength="100" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="18%">Manufacturer&nbsp;<span id="Span82" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="4%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtPGCCManufacturer" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                            <td align="left" valign="top" width="18%">Installation Date&nbsp;<span id="Span83" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top" width="4%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:TextBox ID="txtPGCCInstallation_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                                <img alt="Installation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPGCCInstallation_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorPGCC"
                                                                    Display="none" ErrorMessage="[Equipment]/Installation Date is not a valid date"
                                                                    SetFocusOnError="true" ControlToValidate="txtPGCCInstallation_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Water Borne?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoWater_Borne" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Solvent Based?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoSolvent_Based" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Combination Water/Solvent?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoCombination_Water_Solvent" runat="server" SkinID="YesNoType">
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
                                                            <td align="left" valign="top">Is cabinet 6H compliant?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdbIsCabinet6HComplaint" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">Manual for Paint Gun Cleaning Cabinet located in 6H Binder?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdbManualPaintGunCleaningCabinet6H" runat="server" SkinID="YesNoType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes&nbsp;<span id="Span84" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtPGCCNotes" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: inline;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="dvAttachment" runat="server">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1view" runat="server" Style="display: inline;">
                                                <asp:Panel ID="pnlTankview" runat="server" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Equipment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblEquiptmentTank" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top"></td>
                                                            <td align="center" width="4%" valign="top"></td>
                                                            <td align="left" width="28%" valign="top"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Manufacturer
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblTankManufacturer" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Description
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Ground Location
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblGround_Location" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Identification
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblIdentification" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Contents
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_Tank_Contents" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Other Contents
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblContents_Other" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Material
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_Tank_Material" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Other Material
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblMaterial_Other" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Construction
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_Tank_Construction" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Other Construction
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblConstruction_Other" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank Capacity in Gallons
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCapcity" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Certificate Number
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCertificate_Number" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Is Tank UL Certified?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblULCertified" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Is Tank Secure during Non-Business Hours?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSecureNonBusiness" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Installation Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInstallation_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Installation Firm
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInstallation_Firm" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Last Maintenance Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblLast_Maintenance_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Last Revision Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblLast_Revision_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Tank In Use?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblTank_In_Use" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Last Inspection Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblLast_Inspection_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Closure Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblClosure_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Removal Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblRemoval_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Revised Removal Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblRevised_Removal_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Permit Begin Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPermit_Begin_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Permit End Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPermit_End_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Registration Required?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblRegistration_Required" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Registration Number
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblRegistration_Number" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Leak Detection Required?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblLeak_Detection_Required" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Leak Detection Type
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblLeak_Detection_Type" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Overfill Protection?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblOverfill_Protection" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Secondary Containment Adequate?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSecondary_Containment_Adequate" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Secondary Containment Type
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_LU_Secondary_Containment_Type" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Description of Other Reporting Requirements
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblDescription_Other_Reporting_Requirements" runat="server"
                                                                    ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Plan Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPlan_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Plan Identification
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPlan_Identification" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Recommendations
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblRecommendations" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Effective Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblEffective_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Expiration Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExpiration_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Record Keeping Requirements
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblRecordkeeping_Requirements" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" valign="top" style="font-weight: bold;">SPCC&nbsp;
                                                            </td>
                                                            <td align="center" valign="top"></td>
                                                            <td align="left" colspan="4" valign="top"></td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" valign="top">SPCC Required
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:Label ID="lblSPCC_Required" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Date Developed
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSPCCDate_Developed" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Expiration Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSPCCExpiration_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <%-- <tr>
                                                            <td align="left" valign="top">
                                                                Inadvertent Release Control and Countermeasures Plan
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblRelease_Control_Countermeasures_Plan" runat="server"
                                                                    ControlType="Label" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Maintenance Vendor
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblMaintenance_Vendor" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Vendor Contact Name
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblVendor_Contact_Name" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Vendor Contact Telephone
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblVendor_Contact_Telephone" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Insurer
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInsurer" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Coverage Start Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCoverage_Start_Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Coverage End Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCoverage_End_Date" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Multiple Event/Total Coverage
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblMultiple_Event_Total_Coverage" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Single Event Coverage
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSingle_Event_Coverage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Inspection Company
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInspection_Company" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Inspection Company Contact Name
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInspection_Company_Contact_Name" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Inspection Company Contact Telephone
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInspection_Company_Contact_Telephone" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlSprayBoothTypeview" runat="server" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Equipment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblSprayBoothType" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Description
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblSprayBoothDescription" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Manufacturer Name
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblManufacturer_Name" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Installation Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInstallationDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Configured for Water Borne Application?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblConfigured_For_Water_Borne_Application" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Direct or Indirect Burners?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDirect_Indirect_Burners" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">BTU Rating
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTU_Rating" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Height In Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblHeight_In_Feet" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Width in Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblWidth_In_Feet" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Depth in Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDepth_In_Feet" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Technology
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFilter_System" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Manual for Paint Booth location in 6H Binder?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblManual6HBinder" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Capture Efficiency
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCapture_Efficiency" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblControl_Efficiency" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Capture Efficiency as of Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCapture_EfficiencyDate" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency as of Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblControl_EfficiencyDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Stack Height Above Grade in Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblStack_Height_In_Feet" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Exit Flow Rate in Cubic Feet Per Minute
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExit_Flow_Rate_CFM" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Exit Temperature (Low) Degrees Farenheight
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExit_Temperature_Low" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Exit Temperature (High) Degrees Farenheight
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExit_Temperature_High" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblSprayBoothNotes" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlPrepStationTypeview" runat="server" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Equipment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblPrepStationType" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Description
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblPrepStationDescription" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Manufacturer Name
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblManufacturer_Name_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Installation Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInstallationDate_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Configured for Water Borne Application?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblConfigured_For_Water_Borne_Application_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Direct or Indirect Burners?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDirect_Indirect_Burners_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">BTU Rating
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblBTU_Rating_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Height In Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblHeight_In_Feet_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Width in Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblWidth_In_Feet_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Depth in Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDepth_In_Feet_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Technology
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFilter_System_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Manual for Prep Station location in 6H Binder?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblManual6HBinder_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Filter Capture Efficiency
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCapture_Efficiency_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblControl_Efficiency_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Capture Efficiency as of Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCapture_EfficiencyDate_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Control Efficiency as of Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblControl_EfficiencyDate_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Stack Height Above Grade in Feet
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblStack_Height_In_Feet_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Exit Flow Rate in Cubic Feet Per Minute
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExit_Flow_Rate_CFM_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Exit Temperature (Low) Degrees Farenheight
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExit_Temperature_Low_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Exit Temperature (High) Degrees Farenheight
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblExit_Temperature_High_PrepStation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblPrepStationNotes" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlOWSTypeview" runat="server" Style="display: none;">
                                                    <asp:Panel ID="pnlOWSTypeDetailview" runat="server">
                                                        <div class="bandHeaderRow">
                                                            Equipment
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Equipment Type
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblOWSType" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Description
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblOWSDescription" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Connected to Public Water System?
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblConnectedtoPublicWater" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Installation Date
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblOWS_Installation_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Manufacturer
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblOWSManufacturer" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Service Provider
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblOWSInspection" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Service Provider Contact Person
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblOWSInspectionCompanyContactName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Service Provider Telephone Number
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblOWSContactTelephone" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">Sludge Removal Date Grid
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:GridView ID="gvSludgeView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                        EnableViewState="true" AllowPaging="true" OnRowCommand="gvSludgeView_RowCommand" OnPageIndexChanging="gvSludgeView_PageIndexChanging">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sludge Removal Date">
                                                                                <ItemStyle Width="45%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemovalDate" runat="server" Text='<%#(Eval("Sludge_Removal_Date")) == DBNull.Value ? "" : Eval("Sludge_Removal_Date", "{0:MM/dd/yyyy}")%>'
                                                                                        CommandName="ViewSludge" CommandArgument='<%# Eval("PK_PM_Equipment_OWS_SR") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Sludge Removed By">
                                                                                <ItemStyle Width="45%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemoveby" runat="server" Text='<%#Eval("Sludge_Removed_By")%>'
                                                                                        CommandName="ViewSludge" CommandArgument='<%# Eval("PK_PM_Equipment_OWS_SR") %>' />
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
                                                                <td align="left" valign="top">Notes
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="lblOWSNotes" runat="server" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlOWSTypeViewData" runat="server" Visible="false">
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" valign="top">
                                                                    <div class="bandHeaderRow">
                                                                        Equipment Type Screen – OWS – Sludge Removal Grid Screen
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Sludge Removal Date&nbsp;<span style="color: Red">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblSludgeRemovalDate" runat="server" Width="150px" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Sludge Removed By&nbsp;<span style="color: Red">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblSludgeRemovedBy" runat="server" Width="150px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">TCLP Performed?
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblTCLPPerformed" runat="server" Width="150px" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">TCLP Conducted Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblTCLPConductedDate" runat="server" Width="150px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">TCLP On File?
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <asp:Label ID="lblTCLPOnFile" runat="server" Width="150px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Notes
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="lblSludgeNotes" runat="server" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="top" colspan="6">
                                                                    <asp:Button ID="btnAuditSludgeView" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                                        OnClientClick="OpenPopupSludge();return false;" />
                                                                    <asp:Button ID="btnCancelSludgeView" runat="server" Text="Cancel" OnClick="btnCancelSludgeView_Click"
                                                                        CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlHydraulicLiftTypeview" runat="server" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Equipment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top" width="20%">Equipment Type  
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="20%">
                                                                <asp:Label ID="lblEquipmentHydraulicLift" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="20%">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top" width="20%">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top" width="30%">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" colspan="5">Apply the Installation and Inspection Dates of the First Installed <span id="spnvwFirstInstalled" runat="server">Lift</span> in the Below
                                                                Grid to all Installed <span id="spnvwFirstInstalled2" runat="server">Lifts</span> in the Grid?
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblUse_Same_Dates" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <span id="spnvwHydraulicLiftGrid" runat="server">Hydraulic Lift</span> Grid
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="gvHydraulicLiftView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                    EnableViewState="true" AllowPaging="true" OnRowCommand="gvHydraulicLiftView_RowCommand" OnPageIndexChanging="gvHydraulicLiftView_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Lift Number">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkIs_Number_Of_Lifts_At_Location" runat="server" Text='<%#Eval("Is_Number_Of_Lifts_At_Location")%>'
                                                                                    CommandName="ViewHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Manufacturer">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkManufacturer_Name" runat="server" Text='<%#Eval("Manufacturer_Name")%>'
                                                                                    CommandName="ViewHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Above Ground">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkAbove_Ground" runat="server" Text='<%# Convert.ToString(Eval("Above_Ground"))==""?"No":(Convert.ToString(Eval("Above_Ground"))=="Y"?"Yes":"No")%>'
                                                                                    CommandName="ViewHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installation Date">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkInstallation_Date" runat="server" Text='<%#(Eval("Installation_Date")) == DBNull.Value ? "" : Eval("Installation_Date", "{0:MM/dd/yyyy}")%>'
                                                                                    CommandName="ViewHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Last Inspection Date">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkLast_Inspection_Date" runat="server" Text='<%#(Eval("Last_Inspection_Date")) == DBNull.Value ? "" : Eval("Last_Inspection_Date", "{0:MM/dd/yyyy}")%>'
                                                                                    CommandName="ViewHydraulicLift" CommandArgument='<%# Eval("PK_PM_Equipment_Hydraulic_Lift_Grid") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table cellpadding="4" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Exits"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlHydraulicLifGridViewData" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="6" valign="top">
                                                                <div class="bandHeaderRow">
                                                                    Equipment Type Screen – <span id="spnvwEquipmentTypeScreen" runat="server">Hydraulic Lift – Hydraulic Lift</span> Grid Screen
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">
                                                                <span id="spvwLiftNumber" runat="server">Lift</span> Number
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblNumber_Of_Lifts_At_Location" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" valign="top">Replacement <span id="spnvwReplacementLift" runat="server">Lift</span>?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblReplacementLift" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">
                                                                <span id="spvwLiftNumberAsOfDate" runat="server">Lift</span> Number As of Date&nbsp;
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top" colspan="4">
                                                                <asp:Label ID="lblAs_Of_Date_Number" runat="server" Width="150px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Description
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblHydraulicLiftDescription" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Oil Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblOil_Type" runat="server" Width="150px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top"></td>
                                                            <td align="center" width="3%" valign="top"></td>
                                                            <td align="left" valign="top" width="28%"></td>
                                                            <td align="left" valign="top" width="18%">Status
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblStatus" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Above Ground?
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblAbove_Ground" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Manufacturer
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblHydraulicLiftManufacture" runat="server" Width="150px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Installation Date
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblInstallationDateHydraulicLift" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Last Annual Inspection Date
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblHydraulicLift_Last_Inspection_Date" runat="server" Width="150px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Have Any In-Ground <span id="spnvwInGround" runat="server">Lifts</span> been Removed from the Location?
                                                            </td>
                                                            <td align="center" width="3%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblInGroundLifts" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td align="left" valign="top" width="18%">If Yes, is Documentation Related to <span id="spnvwDocumentation" runat="server">Lift</span> Removal Attached?
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblDocumentRelatedLifts" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6"><b>Replacement <span id="spnvwReplacementLiftInformation" runat="server">Lift</span> Information</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Description 
                                                            </td>
                                                            <td align="center" width="3%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblReplacementDescription" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" valign="top" width="18%">Oil Type
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblReplacementOilType" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Above Ground? &nbsp;
                                                            </td>
                                                            <td align="center" width="3%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblAboveGround" runat="server" SkinID="YesNoType" />
                                                            </td>
                                                            <td align="left" valign="top" width="18%">Manufacturer&nbsp;
                                                            </td>
                                                            <td align="center" valign="top" width="3%">:
                                                            </td>
                                                            <td align="left" valign="top" width="28%">
                                                                <asp:Label ID="lblManufacturer" runat="server" Width="170px" MaxLength="75" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Installation Date&nbsp;<span id="Span80" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblReplacementInstallationDate" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" valign="top">Last Annual Inspection Date&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblLastAnnualInspectionDate" runat="server" Width="150px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes&nbsp;<span id="Span113" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblReplacementNotes" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Removal Date
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblHydraulicLift_Removal_Date" runat="server" Width="150px" />
                                                            </td>
                                                            <td align="left" width="18%" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" width="4%" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" width="28%" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblHydraulicLiftNote" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" valign="top" colspan="6">
                                                                <asp:Button ID="btnAuditHydraulicLiftView" runat="server" Text="View Audit Trail"
                                                                    CausesValidation="false" OnClientClick="OpenPopupHydraulicLift();return false;" />
                                                                <asp:Button ID="btnCancelHydraulicLiftView" runat="server" Text="Cancel" OnClick="btnCancelHydraulicLiftView_Click"
                                                                    CausesValidation="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlPGCCview" runat="server" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Equipment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Equipment Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblPGCCTypeView" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Description
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblPGCCTypeDescription" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Manufacturer
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPGCCTypeManufacturer" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Installation Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPGCCTypeInstallationDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Water Borne?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblWater_Borne" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Solvent Based?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSolvent_Based" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Combination Water/Solvent?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCombination_Water_Solvent" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                            <td align="center" valign="top">&nbsp;
                                                            </td>
                                                            <td align="left" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Is cabinet 6H compliant?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblIsCabinet6HComplaint" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Manual for Paint Gun Cleaning Cabinet located in 6H Binder?
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblManualPaintGunCleaningCabinet6H" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Notes
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblPGCCTypeNotes" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: inline;">
                                                <div id="Div1" runat="server" style="display: inline;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="center">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="60%" align="right">
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" />
                                            <asp:Button ID="btnSaveView" runat="server" Text="Save & View" OnClick="btnSaveView_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />
                                        </td>
                                        <td align="left">&nbsp;
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
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroupTank" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorTank" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsTank"
        Display="None" ValidationGroup="vsErrorGroupTank" />
    <input id="hdnControlIDsTank" runat="server" type="hidden" />
    <input id="hdnErrorMsgsTank" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorGroupEquipment" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorEquipment" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsEquipment" Display="None" ValidationGroup="vsErrorGroupEquipment" />
    <input id="hdnControlIDsEquipment" runat="server" type="hidden" />
    <input id="hdnErrorMsgsEquipment" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorSprayBooth" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorSprayBooth" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsSprayBooth" Display="None" ValidationGroup="vsErrorSprayBooth" />
    <input id="hdnControlIDsSprayBooth" runat="server" type="hidden" />
    <input id="hdnErrorMsgsSprayBooth" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorPrepStation" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorPrepStation" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsPrepStation" Display="None" ValidationGroup="vsErrorPrepStation" />
    <input id="hdnControlIDsPrepStation" runat="server" type="hidden" />
    <input id="hdnErrorMsgsPrepStation" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorHydraulicLiftGrid" CssClass="errormessage"></asp:ValidationSummary>
    <%--<asp:CustomValidator ID="CustomValidatorHydraulicLift" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsHydraulicLift" Display="None" ValidationGroup="vsErrorHydraulicLift" />
    <input id="hdnControlIDsHydraulicLift" runat="server" type="hidden" />
    <input id="hdnErrorMsgsHydraulicLift" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorHydraulicLiftGrid" CssClass="errormessage">
    </asp:ValidationSummary>--%>
    <asp:CustomValidator ID="CustomValidatorHydraulicLiftGrid" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsHydraulicLiftGrid" Display="None" ValidationGroup="vsErrorHydraulicLiftGrid" />
    <input id="hdnControlIDsHydraulicLiftGrid" runat="server" type="hidden" />
    <input id="hdnErrorMsgsHydraulicLiftGrid" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorPGCC" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorPGCC" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsPGCC"
        Display="None" ValidationGroup="vsErrorPGCC" />
    <input id="hdnControlIDsPGCC" runat="server" type="hidden" />
    <input id="hdnErrorMsgsPGCC" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorGroupOWS" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorOWS" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsOWS"
        Display="None" ValidationGroup="vsErrorGroupOWS" />
    <input id="hdnControlIDsOWS" runat="server" type="hidden" />
    <input id="hdnErrorMsgsOWS" runat="server" type="hidden" />
    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsErrorGroupOWSInnerGrid" CssClass="errormessage"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidatorOWSInnerGrid" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsOWSInnerGrid" Display="None" ValidationGroup="vsErrorGroupOWSInnerGrid" />
    <input id="hdnControlIDsOWSInnerGrid" runat="server" type="hidden" />
    <input id="hdnErrorMsgsOWSInnerGrid" runat="server" type="hidden" />
</asp:Content>
