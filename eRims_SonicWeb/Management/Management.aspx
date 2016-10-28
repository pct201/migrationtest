<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Management.aspx.cs" Inherits="Management_Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ManagementTab/ManagementTab.ascx" TagName="ctrlManagementTab"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Event/AttachmentEvent.ascx" TagName="Attachment" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">

        $(function () {
            $("#<%= drpFK_Work_Completed.ClientID %>").change(function () {
                var selected = ($('#<%= drpFK_Work_Completed.ClientID %> option:selected').text());
                if(selected.indexOf("Add New Equipment") > -1)
                {
                    $('#<%= trRPMApproval.ClientID%>').show();
                    if($('#<%= rdbRPMApproval.ClientID %> tr td input')[0].checked)
                    {
                        $('#<%= drpFK_LU_Approval_Submission.ClientID %> option:contains("Yes")').attr('selected','selected');    
                    }
                }
                else{
                    $('#<%= trRPMApproval.ClientID%>').hide();
                    $('#<%= drpFK_LU_Approval_Submission.ClientID %> option:contains("No")').attr('selected','selected');
                }
            });

            $('#<%= rdbRPMApproval.ClientID %> tr td input').click(function(){
                var val = $(this).val();

                if(val == "1")
                {
                    $($('#<%= rdoGM_Decision.ClientID%> tr td input')[0]).attr('checked','checked').trigger('click');
                    $($('#<%= rdoRLCM_Decision.ClientID%> tr td input')[0]).attr('checked','checked').trigger('click');
                    $($('#<%= rdoNAPM_Decision.ClientID%> tr td input')[0]).attr('checked','checked').trigger('click');
                    $($('#<%= rdoDRM_Decision.ClientID%> tr td input')[0]).attr('checked','checked').trigger('click');
                }
                else{
                    $($('#<%= rdoGM_Decision.ClientID%> tr td input')[1]).attr('checked','checked').trigger('click');
                    $($('#<%= rdoRLCM_Decision.ClientID%> tr td input')[1]).attr('checked','checked').trigger('click');
                    $($('#<%= rdoNAPM_Decision.ClientID%> tr td input')[1]).attr('checked','checked').trigger('click');
                    $($('#<%= rdoDRM_Decision.ClientID%> tr td input')[1]).attr('checked','checked').trigger('click');
                }
            });
        });

        function ConfirmDelete() {
            return confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?");
        }

        function AuditPopUp() {

            var winHeight = window.screen.availHeight - 300;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 20;
            }
            var winWidth = window.screen.availWidth - 200;
            obj = window.open("AuditPopup_Management.aspx?id=" + '<%=ViewState["PK_Management"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        jQuery(function ($) {
            $("#<%=txtdate_Scheduled.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Completed.ClientID%>").mask("99/99/9999");
            //$("#<%=txtCR_Approved.ClientID%>").mask("99/99/9999");
            $("#<%=txtGM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtGM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtRLCM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtRLCM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtNAPM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtNAPM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtDRM_Last_Email_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtDRM_Response_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtOrderDate.ClientID%>").mask("99/99/9999");

        });


        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }

        var ActiveTabIndex = 1;
        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            var op = '<%=StrOperation%>';
            var App_Access = '<%= App_Access%>';
            if (op == "view" || App_Access.toLowerCase() == 'view_only') {
                ShowPanelView(index);
            }
            else {
                var i;
                for (i = 1; i <= 4; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            for (i = 1; i <= 4; i++) {
                document.getElementById('ctl00_ContentPlaceHolder1_pnl' + i + 'View').style.display = (i == index) ? "block" : "none";
            }
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 4; i++) {
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

            var prevview = document.getElementById('<%=btnPreviousStep.ClientID%>');
            var nextview = document.getElementById('<%=btnNextStep.ClientID%>');

            if (index == 1) {
                prevview.disabled = true;
                nextview.disabled = false;
            }
            else if (index == 4) {
                prevview.disabled = false;
                nextview.disabled = true;
            }
            else {
                prevview.disabled = false;
                nextview.disabled = false;
            }
        }

        function onNextStep() {

            var rowVisibility = $('#ctl00_ContentPlaceHolder1_trApprovals').css("display");
            if(rowVisibility.toLowerCase() == "none" && ActiveTabIndex == 1)
            {
                ActiveTabIndex = ActiveTabIndex + 2;
            }
            else{
                ActiveTabIndex = ActiveTabIndex + 1;
            }
            document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
            ShowPanel(ActiveTabIndex);
            return false;

        }

        function onPreviousStep() {

            var rowVisibility = $('#ctl00_ContentPlaceHolder1_trApprovals').css("display");
            if(rowVisibility.toLowerCase() == "none"  && ActiveTabIndex == 3)
            {
                ActiveTabIndex = ActiveTabIndex - 2;
            }
            else{
                ActiveTabIndex = ActiveTabIndex - 1;
            }
            document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
            ShowPanel(ActiveTabIndex);
            return false;

        }

        function OpenWizardPopup(ManagementId, num) {
            document.getElementById('<%=hdnApprovalVal.ClientID %>').value = num;
            document.getElementById('<%=hdnEmailList.ClientID %>').value = '';
            document.getElementById('<%=hdnEmailDate.ClientID %>').value = '';
            GB_showCenter('', '<%=AppConfig.SiteURL%>Management/EmailAttachment.aspx?ManagementId=' + ManagementId + '&Tbl=Management', 500, 950, ReturnFunction);
        }
        var CheckChangeVal = false;
        function ReturnFunction() {
            var Ctl = document.getElementById('<%=hdnApprovalVal.ClientID %>').value;
            var EmailList = document.getElementById('<%=hdnEmailList.ClientID %>').value;
            var EMailDate = document.getElementById('<%=hdnEmailDate.ClientID %>').value;
            if (Ctl == 0) {
                if (EmailList != '' && EMailDate != '') {
                    //GM
                    document.getElementById('<%=txtGM_Email_To.ClientID %>').value = EmailList.substring(0, EmailList.length - 2);;
                    document.getElementById('<%=txtGM_Last_Email_Date.ClientID %>').value = EMailDate;
                    //RLCM
                    document.getElementById('<%=txtRLCM_Email_To.ClientID %>').value = EmailList.substring(0, EmailList.length - 2);;
                    document.getElementById('<%=txtRLCM_Last_Email_Date.ClientID %>').value = EMailDate;
                    //NAPM
                    document.getElementById('<%=txtNAPM_Email_To.ClientID %>').value = EmailList.substring(0, EmailList.length - 2);;
                    document.getElementById('<%=txtNAPM_Last_Email_Date.ClientID %>').value = EMailDate;
                    //DRM
                    document.getElementById('<%=txtDRM_Email_To.ClientID %>').value = EmailList.substring(0, EmailList.length - 2);;
                    document.getElementById('<%=txtDRM_Last_Email_Date.ClientID %>').value = EMailDate;

                    if (CheckChangeVal == false)
                        CheckChangeVal = true;
                }
            }
            else {
                var ListCtrl = 'ctl00_ContentPlaceHolder1_txt' + Ctl + '_Email_To';
                var DateCtrl = 'ctl00_ContentPlaceHolder1_txt' + Ctl + '_Last_Email_Date';
                if (EmailList != '') {
                    document.getElementById(ListCtrl).value = EmailList.substring(0, EmailList.length - 2);
                    if (CheckChangeVal == false)
                        CheckChangeVal = true;
                }
                if (EMailDate != '') {
                    document.getElementById(DateCtrl).value = EMailDate;
                    if (CheckChangeVal == false)
                        CheckChangeVal = true;
                }
            }
            __doPostBack('ctl00$ContentPlaceHolder1$btnSave', '');

        }

        function SetCRApprovedDate(selectedText) {
            if (selectedText == 'Yes') {
                var date = new Date();
                var yyyy = date.getFullYear().toString();
                var mm = (date.getMonth() + 1).toString();
                var dd = date.getDate().toString();

                var mmChars = mm.split('');
                var ddChars = dd.split('');

                dateString = (mmChars[1] ? mm : "0" + mmChars[0]) + '/' + (ddChars[1] ? dd : "0" + ddChars[0]) + '/' + yyyy;
                document.getElementById('<%=txtCR_Approved.ClientID%>').value = dateString;
            }
            else
            {
                document.getElementById('<%=txtCR_Approved.ClientID%>').value = '';
            }
        }

        function SetApprovalSubmissionOnSaveButton() {
            if (Page_ClientValidate('vsErrorGroup')) {

                var selectedWork = $('#ctl00_ContentPlaceHolder1_drpFK_Work_Completed option:selected').text().trim().toLowerCase();

                if(selectedWork.indexOf("repair equipment") > -1)
                {
                    if($('#ctl00_ContentPlaceHolder1_chkNoApprovalNeeded').attr('checked') == false && $('#ctl00_ContentPlaceHolder1_chkApprovalNeeded').attr('checked') == false)
                    {
                        alert("Either No approval needed and Approval needed checkbox needs to be checked");
                        return false;
                    }
                }

                var drpLU_Approval_Submission = document.getElementById('<%=drpFK_LU_Approval_Submission.ClientID %>');
                var hdnApprovalSubmission = document.getElementById('<%=hdnApprovalSubmission.ClientID %>');
                //alert(drpLU_Approval_Submission.value);
                if (drpLU_Approval_Submission.value == '0')
                    SetApprovalSubmission();
                else
                    hdnApprovalSubmission.value = drpLU_Approval_Submission.value;

                var btn = document.getElementById('<%= btnSave.ClientID %>');
                btn.value = "Saving...";
                btn.disabled = true;
                $('#<%=txtService_Repair_Cost.ClientID %>').removeAttr('disabled');
                return true;
            }
            else
                return false;
        }

        function SetApprovalSubmission() {

            //set approval submission dropdown and "CR approved" date #Issue 3402 point 1-d,e
            var rdoGMStatus = document.getElementById('<%=rdoGM_Decision.ClientID %>');
            var rdoRLCMStatus = document.getElementById('<%=rdoRLCM_Decision.ClientID %>');
            var rdoNAPMStatus = document.getElementById('<%=rdoNAPM_Decision.ClientID %>');
            var rdoDRMStatus = document.getElementById('<%=rdoDRM_Decision.ClientID %>');
            var drpLU_Approval_Submission = document.getElementById('<%=drpFK_LU_Approval_Submission.ClientID %>');
            var hdnApprovalSubmission = document.getElementById('<%=hdnApprovalSubmission.ClientID %>');

            for (var i = 0; i < rdoGMStatus.rows.length; ++i) {//all radio button have same value
                //alert(rdoGMStatus.rows[i].cells[0].firstChild.value + '  and  ' + rdoGMStatus.rows[i].cells[1].firstChild.value);
                //rdoGMStatus.rows[i].cells[0].firstChild.value  for Approved and cells[1] = NotApproved
                if (rdoGMStatus.rows[i].cells[0].firstChild.checked && rdoRLCMStatus.rows[i].cells[0].firstChild.checked && rdoNAPMStatus.rows[i].cells[0].firstChild.checked && rdoDRMStatus.rows[i].cells[0].firstChild.checked) {
                    //all radio buttons are approved then Approval Submission = Yes 
                    for (var i = 0; i < drpLU_Approval_Submission.options.length; i++) {
                        if (drpLU_Approval_Submission.options[i].text === 'Yes') {
                            //drpLU_Approval_Submission.selectedIndex = i;//drpLU_Approval_Submission.value = drpLU_Approval_Submission.options[i].value;
                            drpLU_Approval_Submission.value = drpLU_Approval_Submission.options[i].value;
                            hdnApprovalSubmission.value = drpLU_Approval_Submission.options[i].value;
                            break;
                        }
                    }
                    SetCRApprovedDate('Yes');
                }
                else if (rdoGMStatus.rows[i].cells[1].firstChild.checked || rdoRLCMStatus.rows[i].cells[1].firstChild.checked || rdoNAPMStatus.rows[i].cells[1].firstChild.checked || rdoDRMStatus.rows[i].cells[1].firstChild.checked) {
                    //any radio buttons are Not Approved then Approval Submission = No
                    for (var i = 0; i < drpLU_Approval_Submission.options.length; i++) {
                        if (drpLU_Approval_Submission.options[i].text === 'No') {
                            //drpLU_Approval_Submission.selectedIndex = i;
                            drpLU_Approval_Submission.value = drpLU_Approval_Submission.options[i].value;
                            hdnApprovalSubmission.value = drpLU_Approval_Submission.options[i].value;
                            break;
                        }
                    }
                    SetCRApprovedDate('No');
                }
                else {
                    for (var i = 0; i < drpLU_Approval_Submission.options.length; i++) {
                        if (drpLU_Approval_Submission.options[i].text === '-- Select --') {
                            //drpLU_Approval_Submission.selectedIndex = i;
                            drpLU_Approval_Submission.value = drpLU_Approval_Submission.options[i].value;
                            hdnApprovalSubmission.value = drpLU_Approval_Submission.options[i].value;
                            break;
                        }
                    }
                    SetCRApprovedDate('-- Select --');
                }
            }
           
        }

        function ClearReponseDateControls(btn){
            switch(btn)
            {
                case "GM":
                    $('#<%= rdoGM_Decision.ClientID %> input:checked').removeAttr('checked');
                    $('#<%= txtGM_Response_Date.ClientID %>').val('');
                    break;
                case "RLCM":
                    $('#<%= rdoRLCM_Decision.ClientID %> input:checked').removeAttr('checked');
                    $('#<%= txtRLCM_Response_Date.ClientID %>').val('');
                    break;
                case "NAPM":
                    $('#<%= rdoNAPM_Decision.ClientID %> input:checked').removeAttr('checked');
                    $('#<%= txtNAPM_Response_Date.ClientID %>').val('');
                    break;
                case "DRM":
                    $('#<%= rdoDRM_Decision.ClientID %> input:checked').removeAttr('checked');
                    $('#<%= txtDRM_Response_Date.ClientID %>').val('');
                    break;
            }
        }

        function checkLengthSonic() {
            var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtManagement_Notes_txtNote')
            if (oObject.value.length < 50) {
                alert("Please enter minimum 50 Characters for Notes.");
                return false;
            }
            else {
                return true;
            }
        }
        function SelectDeselectAllACISonicNotes(bChecked) {
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
            var rowCnt = document.getElementById('<%=gvManagement_Notes.ClientID%>').rows.length - 1;
            var headerChkID = 'chkMultiSelectSonicACINotes';

            if (cnt == rowCnt)
                document.getElementById(headerChkID).checked = true;
            else
                document.getElementById(headerChkID).checked = false;
        }
        function CheckSelectedSonicNotes(buttonType) {

            var gv = document.getElementById('<%=dvManagementNotes.ClientID%>');
            var ctrls = gv.getElementsByTagName('input');
            var i;
            var cnt = 0;
            var m_strAttIds = '';
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSonicACINotes") > 0) {
                    if (ctrls[i].checked) {
                        var ctrlId = ctrls[i].id;
                        ctrlId = ctrlId.substring(ctrlId.lastIndexOf("_") - 2);
                        var hdnpk = ctrlId.replace("chkSelectSonicACINotes", "hdnPK_Sonic_Management_Notes");
                        //index = Number(index) - 2;
                        var id = document.getElementById('ctl00_ContentPlaceHolder1_gvManagement_Notes_ctl' + hdnpk).value;
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
                if (buttonType != 'Print') {
                    SonicSelectedNotePopup(m_strAttIds, buttonType);
                    return false;
                }
                else
                    return true;
            }
        }

        function SonicSelectedNotePopup(NoteId, type) {  
            var winHeight = 450;
            var winWidth = 750;
            var EventId = <%=ViewState["PK_Management"]%>;            
            obj = window.open("Management_Note.aspx?viewIDs=" +  NoteId + "&id=" + '<%=ViewState["PK_Management"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',resizable=yes,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function SonicNotePopup(NoteId, type) {            
            var winHeight = 500;
            var winWidth = 500;
            var ManagementId = <%=ViewState["PK_Management"]%>;            
            obj = window.open("Management_Note.aspx?nid=" + NoteId + "&id=" + '<%=ViewState["PK_Management"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
        }

        function CheckManagement() {
            var values = '<%=ViewState["PK_Management"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Management Record First');
                return false;
            }
            else {
                return true;
            }
        }

        function SelectDeselectAllACINotesView(bChecked) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicACINotesView";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function SelectDeselectSonicNoteHeaderView() {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicACINotesView";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }
            var rowCnt = document.getElementById('<%=gvManagement_NotesView.ClientID%>').rows.length - 1;
            var headerChkID = 'chkMultiSelectSonicACINotesView';

            if (cnt == rowCnt)
                document.getElementById(headerChkID).checked = true;
            else
                document.getElementById(headerChkID).checked = false;
        }

        function SelectDeselectAllSonicNotesView(bChecked) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicNotesView";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function CheckSelectedSonicNotesView(buttonType) {

            var gv = document.getElementById('<%=dvManagementNotesView.ClientID%>');
            var ctrls = gv.getElementsByTagName('input');
            var i;
            var cnt = 0;
            var m_strAttIds = '';
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSonicACINotesView") > 0) {
                    if (ctrls[i].checked) {
                        var ctrlId = ctrls[i].id;
                        ctrlId = ctrlId.substring(ctrlId.lastIndexOf("_") - 2);
                        var hdnpk = ctrlId.replace("chkSelectSonicACINotesView", "hdnPK_Sonic_Management_NotesView");
                        //index = Number(index) - 2;
                        var id = document.getElementById('ctl00_ContentPlaceHolder1_gvManagement_NotesView_ctl' + hdnpk).value;
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
                if (buttonType != 'Print') {
                    SonicSelectedNotePopup(m_strAttIds, buttonType);
                    return false;
                }
                else
                    return true;
            }
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <uc:ctrlManagementTab runat="server" ID="ctrlMgmtTab" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td width="5px" class="Spacer">
                                <asp:HiddenField runat="Server" ID="hdnApprovalVal" />
                                <asp:HiddenField runat="Server" ID="hdnEmailList" />
                                <asp:HiddenField runat="Server" ID="hdnEmailDate" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="leftMenu">
                                            <table cellpadding="5" cellspacing="0" width="180px">
                                                <tr>
                                                    <td style="height: 10px;" class="Spacer"></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="100%">
                                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Management</span>
                                                        <span id="MenuAsterisk1" runat="server" style="color: Red; display: none;">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="trApprovals" runat="server">
                                                    <td align="left" width="100%">
                                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Approvals</span>
                                                        <span id="MenuAsterisk2" runat="server" style="color: Red; display: none;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="100%">
                                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Project Cost</span>
                                                        <span id="MenuAsterisk3" runat="server" style="color: Red; display: none;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="100%">
                                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Attachment</span>
                                                        <span id="MenuAsterisk4" runat="server" style="color: Red; display: none;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px;" class="Spacer"></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 5px;" class="Spacer">&nbsp;
                                        </td>
                                        <td valign="top" width="100%" class="dvContainer">
                                            <div id="dvEdit" runat="server">
                                                <asp:Panel ID="pnl1" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Management
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td style="height: 5px" colspan="6"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Reference Number
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:TextBox ID="txtReferenceNumber" autocomplete="off" runat="server" SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Date Entered
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:TextBox ID="txtDate_Entered" autocomplete="off" runat="server" SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%--<td align="left" width="18%" valign="top">
                                                            Company<span class="mf">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCompany" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtCompany" runat="server" ControlToValidate="txtCompany"
                                                                ErrorMessage="Please Enter Company" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>--%>
                                                            <td align="left" width="18%" valign="top">DBA<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:DropDownList ID="drpLocation" runat="server" Width="170px" SkinID="dropGen"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="drpLocation_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvdrpLocation" runat="server" ControlToValidate="drpLocation"
                                                                    InitialValue="0" ErrorMessage="Please Select DBA" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Location Code
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:UpdatePanel ID="upnlCode" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtLocation_Code" runat="server" Width="175px" MaxLength="4" autocomplete="off"
                                                                            onKeyPress="return FormatInteger(event);" onpaste="return false" onblur="CheckNumericValOnly(this,4);" />
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="drpLocation" EventName="SelectedIndexChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                       <td align="left" valign="top">
                                                            Company Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompany_Phone" runat="server" Width="170px" MaxLength="12" onpaste="return false;"
                                                                SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtCompany_Phone"
                                                                runat="server" SetFocusOnError="true" ErrorMessage="Please Enter valid Company Phone No"
                                                                Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="[0-9\-\(\)]+"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                        </td>
                                                    </tr>--%>
                                                        <%-- <tr>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpState" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCity" MaxLength="100" runat="server" Width="170px"></asp:TextBox>
                                                        </td>

                                            
                                                    </tr>--%>
                                                        <%--<tr>
                                                      <td align="left" valign="top">
                                                            Region
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpRegion" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            County
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCounty" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                        <%-- <tr>
                                                        <td align="left" valign="top">Camera Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCameraNumber" MaxLength="30" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">Camera Type
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpCameraType" runat="server" Width="175px" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Date Scheduled
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtdate_Scheduled" runat="server" SkinID="txtDate" Enabled="false" />
                                                                <asp:TextBox ID="txtCurrentDate" runat="server" Width="180px" MaxLength="10" Style="display: none;"></asp:TextBox>
                                                                <%--  <img alt="Scheduled Date" onclick="return showCalendar('<%= txtdate_Scheduled.ClientID %>', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                    align="middle" />--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                    Display="none" ErrorMessage="Scheduled Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtdate_Scheduled" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <%--<asp:CompareValidator ID="cmpvalid" runat="server" ErrorMessage="Date Sheduled should be greater than or equal to current date"
                                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                                    ControlToValidate="txtdate_Scheduled" Type="Date" Operator="GreaterThanEqual"></asp:CompareValidator>--%>
                                                            </td>
                                                            <td align="left" valign="top">Date Completed
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtDate_Completed" runat="server" SkinID="txtDate" />
                                                                <img alt="Completed Date" onclick="return showCalendar('<%= txtDate_Completed.ClientID %>', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                                                    Display="none" ErrorMessage="Completed Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtDate_Completed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Date Completed should be less than or equal to current date"
                                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                                    ControlToValidate="txtDate_Completed" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Work To Be Completed<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_Work_Completed" runat="server" Width="175px" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvFK_Work_Completed" runat="server" ControlToValidate="drpFK_Work_Completed"
                                                                    InitialValue="0" ErrorMessage="Please Select Work to be Completed" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" valign="top">Other
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtWork_To_Complete_Other" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Work To Be Completed By
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                               <%-- <asp:RadioButtonList ID="rdoWork_Completed_By" runat="server">
                                                                    <asp:ListItem Text="ACI" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Sonic" Value="0"></asp:ListItem>
                                                                </asp:RadioButtonList>--%>
                                                              <asp:DropDownList ID="drpFK_Work_To_Be_Completed_By" runat="server" Width="175px" SkinID="dropGen">
                                                              </asp:DropDownList>
                                                            </td>
                                                            <td align="left" valign="top">Status<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <%--<asp:RadioButtonList ID="rblTask_Complete" runat="server">
                                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                                                </asp:RadioButtonList>--%>
                                                                <asp:DropDownList runat="server" ID="drpMaintenanceStatus" Width="175px"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvMaintenanceStatus" runat="server" ControlToValidate="drpMaintenanceStatus"
                                                                 InitialValue="0" ErrorMessage="Please Select Status" Display="None" SetFocusOnError="true"
                                                                 ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">No Approval Needed<br />
                                                                (Repair Est. Under $1000)</td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CheckBox runat="server" ID="chkNoApprovalNeeded" AutoPostBack="true" OnCheckedChanged="chkNoApprovalNeeded_CheckedChanged" />
                                                            </td>
                                                            <td align="left" valign="top">Approval Needed<br />
                                                                (Repair Est. Exceed $1000)</td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CheckBox runat="server" ID="chkApprovalNeeded" AutoPostBack="true" OnCheckedChanged="chkApprovalNeeded_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top"><label runat="server" id="lblOriginalService" style="display:none"> Original Service Estimate<span class="mf" id="spOriginalService" runat="server"  style="display:none">*</span></label>
                                                            </td>
                                                            <td align="center" valign="top"><label runat="server" id="lblOriginalServiceCol" style="display:none">:</label> 
                                                            </td>
                                                            <td align="left" valign="top"><label runat="server" id="lblOriginalServiceDollar" style="display:none">$</label> 
                                                                <asp:TextBox ID="txtPreviousContractAmount" autocomplete="off" onpaste="return false;" OnBlur="CheckNumericVal(this,20);" Visible="false"
                                                                runat="server" Width="165px" onkeypress="javascript:return FormatNumber(event,this.id,12,false,true);" />
                                                                <asp:RequiredFieldValidator ID="rfvPreviousContractAmount" runat="server" ControlToValidate="txtPreviousContractAmount"
                                                                    InitialValue="" ErrorMessage="Please Enter Original Service Estimate" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" valign="top"><label runat="server" id="lblRepairEstimate" style="display:none"> Repair and Estimate Amount<span class="mf" id="spRepairEstimate" runat="server" style="display:none">*</span></label>
                                                            </td>
                                                            <td align="center" valign="top"><label runat="server" id="lblRepairEstimateCol" style="display:none">:</label> 
                                                            </td>
                                                            <td align="left" valign="top"><label runat="server" id="lblRepairEstimateDollar" style="display:none">$</label> 
                                                                <asp:TextBox ID="txtRevisedContractAmount" autocomplete="off" onpaste="return false;" OnBlur="CheckNumericVal(this,20);"  Visible="false"
                                                                runat="server" Width="165px" onkeypress="javascript:return FormatNumber(event,this.id,12,false,true);" />
                                                               <asp:RequiredFieldValidator ID="rfvRevisedContractAmount" runat="server" ControlToValidate="txtRevisedContractAmount"
                                                                    InitialValue="" ErrorMessage="Please Enter Repair and Estimate Amount" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Repair Cost
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <%--$<asp:TextBox ID="txtService_Repair_Cost" runat="server" MaxLength="10" onKeyPress="return(currencyFormat_New(this,',','.',10,event))"
                                                                    OnBlur="CheckNumericVal(this,20);" Width="170px" AutoComplete="off"></asp:TextBox>--%>
                                                                $<asp:TextBox ID="txtService_Repair_Cost" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,true);" onpaste="return false;"
                                                                    OnBlur="CheckNumericVal(this,20);" Width="170px" AutoComplete="off" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="top">Approval Submission
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_LU_Approval_Submission" Enabled="false" runat="server" Width="175px" SkinID="dropGen">
                                                                    <%--onchange="SetCRApprovedDate(this.options[this.selectedIndex].text);"--%>
                                                                </asp:DropDownList>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Record Type<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_Record_Type" runat="server" Width="175px" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                                 <asp:RequiredFieldValidator ID="rfvFK_Record_Type" runat="server" ControlToValidate="drpFK_Record_Type"
                                                                    InitialValue="0" ErrorMessage="Please Select Record Type" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" valign="top">CR Approved
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCR_Approved" runat="server" SkinID="txtDate" onkeydown="javascript:return disableDeleteBackSpace();" CssClass="disbled" onpaste="return false;" />
                                                                <%--<img alt="CR Approved Date" onclick="return showCalendar('<%= txtCR_Approved.ClientID %>', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                    align="middle" />--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                                                    Display="none" ErrorMessage="CR Approved Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtCR_Approved" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CR Approved should be less than or equal to current date"
                                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                                    ControlToValidate="txtCR_Approved" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Job #
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtJob" MaxLength="50" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="top">Order Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtOrderDate" runat="server" SkinID="txtDate" Enabled="false" />
                                                                <%-- <img alt="Order Date" onclick="return showCalendar('<%= txtOrderDate.ClientID %>', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                    align="middle" />--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorGroup"
                                                                    Display="none" ErrorMessage="Order Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtOrderDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Order Date should be less than or equal to current date"
                                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                                    ControlToValidate="txtOrderDate" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td align="left" valign="top">Order Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtOrderDate" runat="server" SkinID="txtDate" Enabled="false" />
                                                                <%-- <img alt="Order Date" onclick="return showCalendar('<%= txtOrderDate.ClientID %>', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="rgvtxtOrderDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                    Display="none" ErrorMessage="Order Date is not a valid date" SetFocusOnError="true"
                                                                    ControlToValidate="txtOrderDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <asp:CompareValidator ID="cmp" runat="server" ErrorMessage="Order Date should be less than or equal to current date"
                                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                                    ControlToValidate="txtOrderDate" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>
                                                            </td>
                                                            <td align="left" valign="top">Order #
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtOrder" MaxLength="50" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>--%>
                                                        <%--<tr>
                                                        <td align="left" valign="top">Sonic Task
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpClientIssue" runat="server" Width="175px" SkinID="dropGen">
                                                                <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">ACI Task
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFacilitiesIssue" runat="server" Width="175px" SkinID="dropGen">
                                                                <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Requested By<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtRequestedBy" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvRequestedBy" runat="server" ControlToValidate="txtRequestedBy"
                                                                    InitialValue="" ErrorMessage="Please Enter Request By" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" valign="top">Created By<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtCreatedBy" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                                                
                                                                <asp:RequiredFieldValidator ID="rfvCreatedBy" runat="server" ControlToValidate="txtCreatedBy"
                                                                    InitialValue="" ErrorMessage="Please Enter Created By" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        
                                                        <%--  <tr>
                                                        <td align="left" valign="top">Cost
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$<asp:TextBox ID="txtCost" autocomplete="off" onpaste="return false;" runat="server" Width="165px" onkeypress="javascript:return FormatNumber(event,this.id,12,false,true);" />
                                                        </td>
                                                        
                                                    </tr>--%>
                                                        <%--<tr>
                                                        <td align="left" valign="top">Camera Concern<span class="mf">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="ctrlCameraConcern" runat="server" IsRequired="true"
                                                                ValidationGroup="vsErrorGroup" RequiredFieldMessage="Please Enter Camera Concern" />
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Reason for Request<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <uc:ctrlMultiLineTextBox ID="ctrlReason_Request" runat="server" IsRequired="true"
                                                                    ValidationGroup="vsErrorGroup" RequiredFieldMessage="Please Enter Reason for Request" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Recommendation<span class="mf">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <uc:ctrlMultiLineTextBox ID="ctrlRecommendation" runat="server" IsRequired="true"
                                                                    ValidationGroup="vsErrorGroup" RequiredFieldMessage="Please Enter Recommendation" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trManagementNotes" style="display: none;">
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <b>Management Notes Grid </b>
                                                                        </td>
                                                                        <td align="center" valign="top" colspan="5">&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" width="19%">Note
                                                                        </td>
                                                                        <td align="center" valign="top" width="2%">:
                                                                        </td>
                                                                        <td align="left" valign="top" style="padding-left: 5px;">
                                                                            <uc:ctrlMultiLineTextBox ID="txtManagement_Notes" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left"></td>
                                                                        <td align="center"></td>
                                                                        <td align="left" colspan="4">
                                                                            <asp:Button ID="btnManagementNotesAdd" OnClick="btnManagementNotesAdd_Click" runat="server"
                                                                                ValidationGroup="vsErrorGroup" OnClientClick="javascript:return checkLengthSonic();"
                                                                                Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="btnManagementNotesCancel" OnClick="btnManagementNotesCancel_Click"
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
                                                        <tr runat="server" id="trManagementNotesGrid">
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top" width="17%">Management Notes Grid
                                                                        </td>
                                                                        <td align="center" valign="top" width="5%">:
                                                                        </td>
                                                                        <td align="left" valign="top" colspan="4">
                                                                            <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" OnGetPage="GetManagementPage" RecordPerPage="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <div runat="server" id="dvManagementNotes" style="width: 99%; overflow-y: scroll; border: solid 1px #000000;">
                                                                                <asp:GridView ID="gvManagement_Notes" runat="server" Width="97%" AutoGenerateColumns="false"
                                                                                    OnSorting="gvManagement_Notes_Sorting" EnableViewState="true" AllowPaging="false"
                                                                                    OnRowCommand="gvManagement_Notes_RowCommand" AllowSorting="true" OnRowDataBound="gvManagement_Notes_RowDataBound"
                                                                                    OnPageIndexChanging="gvManagement_Notes_PageIndexChanging" Style="word-wrap: normal; word-break: break-all;">
                                                                                    <Columns>
                                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                                            <HeaderTemplate>
                                                                                                <input type="checkbox" id="chkMultiSelectSonicACINotes" onclick="SelectDeselectAllACISonicNotes(this.checked);" />Select
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkSelectSonicACINotes" runat="server" onclick="SelectDeselectSonicNoteHeader();" />
                                                                                                <input type="hidden" id="hdnPK_Sonic_Management_Notes" runat="server" value='<%#Eval("PK_Sonic_Management_Notes") %>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Date" SortExpression="Note_Date">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <a href="javascript:function(){return false};" onclick="SonicNotePopup('<%#Eval("PK_Sonic_Management_Notes") %>','SONIC');">
                                                                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="User">
                                                                                            <ItemStyle Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblUpdated_By" runat="server" Text='<%# Eval("Updated_by_Name") %>'
                                                                                                    Style="word-wrap: normal; word-break: break-all;"></asp:Label>
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
                                                                                                    CommandArgument='<%#Eval("PK_Sonic_Management_Notes") %>'>
                                                                                                </asp:LinkButton>
                                                                                                &nbsp;&nbsp;&nbsp;
                                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Sonic_Management_Notes") %>'
                                                                                                    CommandName="RemoveManagementNote" OnClientClick="return confirm('Are you sure to remove Management Note record?');"
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
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-bottom: 5px;" colspan="6">
                                                                            <asp:LinkButton Style="display: inline" ID="lnkAddManagementNotesNew" OnClick="lnkAddManagementNotesNew_Click"
                                                                                runat="server" Text="Add New" OnClientClick="return CheckManagement();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="btnManagementNoteView" runat="server" Text=" View" OnClientClick="return SonicSelectedNotePopup('','ManagementView');" />&nbsp;&nbsp;
                                                                            <asp:Button ID="btnManagementPrint" runat="server" Text=" Print " OnClick="btnManagementPrint_Click"
                                                                                OnClientClick="return CheckSelectedSonicNotes('Print');" />
                                                                            &nbsp;&nbsp;
                                                                            <asp:Button ID="btnManagementSpecificNote" runat="server" CausesValidation="false" Text=" Show Specific Notes Only "
                                                                                OnClientClick="javascript:return CheckSelectedSonicNotes('ManagementSpecificNote');" />
                                                                            <asp:LinkButton Style="display: none" ID="lnkManagementNotesCancel" runat="server"
                                                                                Text="Cancel"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trstoreGrid">
                                                            <td align="left" valign="top">
                                                                <b>Store Contact</b>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:GridView ID="gvStoreContact" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvStoreContact_RowCommand"
                                                                                OnPageIndexChanging="gvStoreContact_PageIndexChanging" OnRowDataBound="gvStoreContact_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="First Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("First_Name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Last_name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Phone">
                                                                                        <ItemStyle Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Phone")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Email">
                                                                                        <ItemStyle Width="30%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Email")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <ItemStyle Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                                CommandArgument='<%#Eval("PK_Management_Sonic_Contact") %>'>
                                                                                            </asp:LinkButton>
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                            <asp:LinkButton runat="server" ID="lnkDelete" Text=" Delete " OnClientClick="return ConfirmDelete();"
                                                                                                CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_Management_Sonic_Contact") %>'>
                                                                                            </asp:LinkButton>
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
                                                                            <asp:LinkButton Style="display: inline" ID="lnkAddStoreNew" OnClick="lnkAddStoreNew_Click"
                                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton Style="display: none" ID="lnkStoreCancel" OnClick="lnkStoreCancel_Click"
                                                                                runat="server" Text="Cancel"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trstoreContact" style="display: none;">
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <b>Store Contact :</b>
                                                                        </td>
                                                                        <td align="center" valign="top" colspan="5">&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" width="18%" valign="top">First Name
                                                                        </td>
                                                                        <td align="center" width="4%" valign="top">:
                                                                        </td>
                                                                        <td align="left" width="28%" valign="top">
                                                                            <asp:TextBox ID="txtStore_Contact_First_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" width="18%" valign="top">Last Name
                                                                        </td>
                                                                        <td align="center" width="4%" valign="top">:
                                                                        </td>
                                                                        <td align="left" width="28%" valign="top">
                                                                            <asp:TextBox ID="txtStore_Contact_Last_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                                            <asp:Button ID="btnStore_Contact" runat="server" Text="V" OnClientClick="javascript: return OpenAssociateName();" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Phone
                                                                        </td>
                                                                        <td align="center" valign="top">:
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtStore_Contact_Phone" runat="server" Width="170px" SkinID="txtPhone"
                                                                                MaxLength="12" autocomplete="off" onpaste="return false"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revtxtCell_phone" ControlToValidate="txtStore_Contact_Phone"
                                                                                runat="server" ErrorMessage="Please Enter Store Contact Phone in XXX-XXX-XXXX format."
                                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" valign="top">Email
                                                                        </td>
                                                                        <td align="center" valign="top">:
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtStore_Contact_Email" runat="server" Width="170px" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revtxtStore_Contact_Email" runat="server" ControlToValidate="txtStore_Contact_Email"
                                                                                Display="None" ErrorMessage="Store contact Email Address is not valid" SetFocusOnError="True"
                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left"></td>
                                                                        <td align="center"></td>
                                                                        <td align="left" colspan="4">
                                                                            <asp:Button ID="btnStoreAdd" OnClick="btnStoreAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                                Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="btnStoreCancel" OnClick="lnkStoreCancel_Click" runat="server" Text="Cancel"
                                                                                Width="70px"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trACIGrid">
                                                            <td align="left" valign="top">
                                                                <b>ACI Contact</b>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:GridView ID="gvACIContact" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvACIContact_RowCommand"
                                                                                OnPageIndexChanging="gvACIContact_PageIndexChanging" OnRowDataBound="gvACIContact_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="First Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("First_Name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Last_name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Phone">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Phone")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Email">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Email")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <ItemStyle Width="10%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                                CommandArgument='<%#Eval("PK_Management_ACI_Contact") %>'>
                                                                                            </asp:LinkButton>
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                            <asp:LinkButton runat="server" ID="lnkDelete" Text=" Delete " OnClientClick="return ConfirmDelete();"
                                                                                                CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_Management_ACI_Contact") %>'>
                                                                                            </asp:LinkButton>
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
                                                                            <asp:LinkButton Style="display: inline" ID="lnkAddACINew" OnClick="lnkAddACINew_Click"
                                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton Style="display: none" ID="lnkACICancel" OnClick="lnkACICancel_Click"
                                                                                runat="server" Text="Cancel"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trACIContact" style="display: none;">
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <b>ACI Contact :</b>
                                                                        </td>
                                                                        <td align="center" valign="top" colspan="5">&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" width="18%" valign="top">First Name
                                                                        </td>
                                                                        <td align="center" width="4%" valign="top">:
                                                                        </td>
                                                                        <td align="left" width="28%" valign="top">
                                                                            <asp:TextBox ID="txtAci_Contact_First_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" width="18%" valign="top">Last Name
                                                                        </td>
                                                                        <td align="center" width="4%" valign="top">:
                                                                        </td>
                                                                        <td align="left" width="28%" valign="top">
                                                                            <asp:TextBox ID="txtAci_Contact_Last_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">Phone
                                                                        </td>
                                                                        <td align="center" valign="top">:
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtAci_Contact_Phone" runat="server" Width="170px" SkinID="txtPhone"
                                                                                MaxLength="12" autocomplete="off" onpaste="return false"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revtxtAci_Contact_Phone" ControlToValidate="txtAci_Contact_Phone"
                                                                                runat="server" ErrorMessage="Please Enter ACI Contact Phone in XXX-XXX-XXXX format."
                                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" valign="top">Email
                                                                        </td>
                                                                        <td align="center" valign="top">:
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtAci_Contact_Email" runat="server" Width="170px" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revtxtAci_Contact_Email" runat="server" ControlToValidate="txtAci_Contact_Email"
                                                                                Display="None" ErrorMessage="ACI contact Email Address is not valid" SetFocusOnError="True"
                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left"></td>
                                                                        <td align="center"></td>
                                                                        <td align="left" colspan="4">
                                                                            <asp:Button ID="btnACIAdd" OnClick="btnACIAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                                Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="btnACICancel" OnClick="lnkACICancel_Click" runat="server" Text="Cancel"
                                                                                Width="70px"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl2" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Approvals
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <a href="#" onclick="OpenWizardPopup(<%=ViewState["PK_Management"] %>,0);">Email ALL</a>
                                                            </td>
                                                        </tr>
                                                        <tr id="trRPMApproval" runat="server" style="display: none">
                                                            <td colspan="6" style="width: 100%;">
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td align="left" width="20%">RPM Approval
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td>
                                                                            <asp:RadioButtonList runat="server" ID="rdbRPMApproval">
                                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                                                            --<a href="#" onclick="OpenWizardPopup(<%=ViewState["PK_Management"] %>,'GM');">Email GM</a>--
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox runat="server" ID="txtGM_Email_To" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtGM_Email_To"
                                                                                ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Approvals]/GM Email To Address Is Invalid"
                                                                                SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox ID="txtGM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtGM_Last_Email_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="GM Last Email Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <asp:RegularExpressionValidator ID="revtxtGM_Last_Email_Date" runat="server" ControlToValidate="txtGM_Last_Email_Date"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="[Approvals]/Date Not Valid(GM Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup">
                                                                            </asp:RegularExpressionValidator>
                                                                            <%--<asp:CustomValidator ID="cvGM_Last_Email_Date" runat="server" ControlToValidate="txtGM_Last_Email_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/GM Last Email Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:RadioButtonList runat="server" ID="rdoGM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection" onclick="SetApprovalSubmission();" Style="float: left">
                                                                            </asp:RadioButtonList>
                                                                            <asp:Button runat="server" Text="C" CommandArgument="GM" OnClick="btnClear_Click" OnClientClick="ClearReponseDateControls('GM');" ValidationGroup="vsErrorGroup" Style="float: left; margin-left: 5px;" />
                                                                        </td>
                                                                        <td align="left">GM Response Date&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtGM_Response_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtGM_Response_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="GM Response Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <asp:RegularExpressionValidator ID="revtxtGM_Response_Date" runat="server" ControlToValidate="txtGM_Response_Date"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="[Approvals]/Date Not Valid(GM Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                            <%--  <asp:CustomValidator ID="cvGM_Response_Date" runat="server" ControlToValidate="txtGM_Response_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/GM Response Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">RLCM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="width: 100%;">
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td align="left" width="20%">E-Mail To&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                            <br />
                                                                            --<a href="#" onclick="OpenWizardPopup(<%=ViewState["PK_Management"] %>,'RLCM');">Email
                                                                                RLCM--</a>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox runat="server" ID="txtRLCM_Email_To" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="rgvRLCM_Email_To" runat="server" ControlToValidate="txtRLCM_Email_To"
                                                                                ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Approvals]/RLCM Email To Address Is Invalid"
                                                                                SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox ID="txtRLCM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtRLCM_Last_Email_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="RLCM Last Email Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <asp:RegularExpressionValidator ID="revtxtRLCM_Last_Email_Date" runat="server" ControlToValidate="txtRLCM_Last_Email_Date"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="[Approvals]/Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                            <%--  <asp:CustomValidator ID="cvRLCM_Last_Email_Date" runat="server" ControlToValidate="txtRLCM_Last_Email_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/RLCM Last Email Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:RadioButtonList runat="server" ID="rdoRLCM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection" onclick="SetApprovalSubmission();" Style="float: left">
                                                                            </asp:RadioButtonList>
                                                                            <asp:Button runat="server" Text="C" CommandArgument="RLCM" OnClick="btnClear_Click" OnClientClick="ClearReponseDateControls('RLCM');" ValidationGroup="vsErrorGroup" Style="float: left; margin-left: 5px;" />
                                                                        </td>
                                                                        <td align="left">RLCM Response Date&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtRLCM_Response_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtRLCM_Response_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="RLCM Response Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <asp:RegularExpressionValidator ID="revtxtRLCM_Response_Date" runat="server" ControlToValidate="txtRLCM_Response_Date"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="[Approvals]/Date Not Valid(RLCM Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                            <%-- <asp:CustomValidator ID="cvRLCM_Response_Date" runat="server" ControlToValidate="txtRLCM_Response_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/RLCM Response Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">NAPM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="width: 100%;">
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td align="left" width="20%">E-Mail To&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                            <br />
                                                                            --<a href="#" onclick="OpenWizardPopup(<%=ViewState["PK_Management"] %>,'NAPM');">Email
                                                                                NAPM</a>--
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox runat="server" ID="txtNAPM_Email_To" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="rgvNAPM_Email_To" runat="server" ControlToValidate="txtNAPM_Email_To"
                                                                                ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Approvals]/NAPM Email To Address Is Invalid"
                                                                                SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox ID="txtNAPM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtNAPM_Last_Email_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="NAPM Last Email Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <asp:RegularExpressionValidator ID="revtxtNAPM_Last_Email_Date" runat="server" ControlToValidate="txtNAPM_Last_Email_Date"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="[Approvals]/Date Not Valid(Last E-Mail Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                            <%-- <asp:CustomValidator ID="cvNAPM_Last_Email_Date" runat="server" ControlToValidate="txtNAPM_Last_Email_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/NAPM Last Email Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:RadioButtonList runat="server" ID="rdoNAPM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection" onclick="SetApprovalSubmission();" Style="float: left">
                                                                            </asp:RadioButtonList>
                                                                            <asp:Button runat="server" Text="C" CommandArgument="NAPM" OnClick="btnClear_Click" OnClientClick="ClearReponseDateControls('NAPM');" ValidationGroup="vsErrorGroup" Style="float: left; margin-left: 5px;" />
                                                                        </td>
                                                                        <td align="left">NAPM Response Date&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtNAPM_Response_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtNAPM_Response_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="NAPM Response Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <asp:RegularExpressionValidator ID="revtxtNAPM_Response_Date" runat="server" ControlToValidate="txtNAPM_Response_Date"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="[Approvals]/Date Not Valid(NAPM Response Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                            <%-- <asp:CustomValidator ID="cvNAPM_Response_Date" runat="server" ControlToValidate="txtNAPM_Response_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/NAPM Response Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
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
                                                                            --<a href="#" onclick="OpenWizardPopup(<%=ViewState["PK_Management"] %>,'DRM');">Email
                                                                                DRM</a>--
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox runat="server" ID="txtDRM_Email_To" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="rgvDRM_Email_To" runat="server" ControlToValidate="txtDRM_Email_To"
                                                                                ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Approvals]/DRM Email To Address Is Invalid"
                                                                                SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:TextBox ID="txtDRM_Last_Email_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtDRM_Last_Email_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="DRM Last Email Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <%-- <asp:CustomValidator ID="cvDRM_Last_Email_Date" runat="server" ControlToValidate="txtDRM_Last_Email_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/DRM Last Email Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:RadioButtonList runat="server" ID="rdoDRM_Decision" SkinID="ApprovedNotApprovedTypeNullSelection" onclick="SetApprovalSubmission();" Style="float: left">
                                                                            </asp:RadioButtonList>
                                                                            <asp:Button runat="server" Text="C" CommandArgument="DRM" OnClick="btnClear_Click" OnClientClick="ClearReponseDateControls('DRM');" ValidationGroup="vsErrorGroup" Style="float: left; margin-left: 5px;" />
                                                                        </td>
                                                                        <td align="left">DRM Response Date&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDRM_Response_Date" runat="server"></asp:TextBox>
                                                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%= txtDRM_Response_Date.ClientID %>', 'mm/dd/y');"
                                                                                alt="DRM Response Date" src="../Images/iconPicDate.gif" align="middle" /><br />
                                                                            <%-- <asp:CustomValidator ID="cvDRM_Response_Date" runat="server" ControlToValidate="txtDRM_Response_Date"
                                                                                ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="[Approvals]/DRM Response Date is not valid."
                                                                                Display="None">
                                                                            </asp:CustomValidator>--%>
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
                                                                <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" ControlType="TextBox" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl3" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Project Cost
                                                    </div>
                                                    <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                        <tr id="Tr1" runat="server">
                                                            <td align="left" valign="top" width="15%">Project Cost Grid<br />
                                                                <asp:LinkButton ID="lnkAddProjectCost" runat="server" OnClick="lnkAddProjectCost_Click" OnClientClick="return CheckManagement();"
                                                                    CausesValidation="false">--Add--</asp:LinkButton>
                                                            </td>
                                                            <td align="center" valign="top" width="2%">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:GridView ID="gvProjectCost" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    OnRowCommand="gvProjectCost_RowCommand" OnRowDataBound="gvProjectCost_OnRowDataBound"
                                                                    ShowFooter="true">
                                                                    <Columns>
                                                                        <%-- <asp:TemplateField HeaderText="Project Number">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkProject_Number" runat="server" CommandName="EditProjectCost"
                                                                                    CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                    Text='<%# Eval("Project_Number") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Project Type">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkProject_Type" runat="server" CommandName="EditProjectCost"
                                                                                    CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                    Text='<%# Eval("Project_Type")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Project Phase">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkProject_Phase" runat="server" CommandName="EditProjectCost"
                                                                                    CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# Eval("Project_Phase") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotal" Text="Total" runat="server" Font-Bold="true" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Budget($)">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbudget" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# string.Format("{0:C2}",Eval("Budget")) %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblBudgetSum" runat="server" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Cost($)">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkEstimated_Cost" runat="server" CommandName="EditProjectCost"
                                                                                    CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") + ";" + Eval("FK_Management") %>'
                                                                                    Text='<%# string.Format("{0:C2}",Eval("Estimated_Cost")) %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblEstimatedCostSum" runat="server" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Actual Cost($)">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkActualCost" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# string.Format("{0:C2}",Eval("Actual_Cost")) %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblActualCostSum" runat="server" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" CommandName="RemoveProjectCost" CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") %>'
                                                                                    Text="Remove" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                                                <asp:HiddenField ID="hdnFK_Management" runat="server" Value='<%# Eval("FK_Management") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No Records Found."></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <%--<tr id="Tr2" runat="server">
                                                            <td align="left" valign="top">Include Companion Project(s) in Project Cost Grid
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td colspan="4">
                                                                <asp:CheckBox ID="chkIncludeCompProject" runat="server" AutoPostBack="true" OnCheckedChanged="chkIncludeCompProject_OnCheckedChanged" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td valign="top" style="width: auto">Invoice Grid<br />
                                                                <asp:LinkButton ID="lnkAddInvoice" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                                    OnClick="lnkAddInvoice_Click" OnClientClick="return CheckManagement();"></asp:LinkButton>
                                                            </td>
                                                            <td align="center" valign="top" style="width: 3%">&nbsp;:
                                                            </td>
                                                            <td style="margin-left: 40px" style="width: 650px" align="left">
                                                                <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    OnRowCommand="gvInvoice_RowCommand">
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Records Found."></asp:Label>
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Invoice Number">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblInvoiceNumber" runat="server" Text='<%# Eval("Invoice_Number") %>'
                                                                                    CommandName="EditRecord" CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="80px"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Invoice Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblInvoice_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Invoice_Date")) %>'
                                                                                    CommandName="EditRecord" CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="100px"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Invoice Amount($)">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblInvoice_Amount" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Amount")) %>' CommandName="EditRecord"
                                                                                    CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="120px" Style="word-wrap: normal; word-break: break-all"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Vendor">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblVendor" runat="server" Text='<%# Eval("Vendor") %>' CommandName="EditRecord"
                                                                                    CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="100px" CssClass="TextClip"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                                    CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
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
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl4" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Attachment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <uc:Attachment ID="ucAttachment" runat="server" Attachment_Table="Management" MajorCoverage="Management" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div id="dvView" runat="server">
                                                <asp:Panel ID="pnl1View" runat="server" Style="display: none;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Management
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td style="height: 5px" colspan="6"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">Reference Number
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblReference_Number" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Date Entered
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblDate_Entered" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%--<td align="left" width="18%" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                        </td>--%>
                                                            <td align="left" width="18%" valign="top">DBA
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" width="18%" valign="top">Location Code
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:Label ID="lblLocation_Code" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--  <tr>
                                                        <td align="left" valign="top">
                                                            Company Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompany_Phone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                        </td>
                                                    </tr>--%>
                                                        <%-- <tr>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblState" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Region
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRegion" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            County
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCounty" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                        <%--<tr>
                                                        <td align="left" valign="top">Camera Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCameraNumber" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Camera Type
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblCameraType" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Date Scheduled
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDateScheduled" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Date Completed
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblDateComleted" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Work To Be Completed
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_Work_Completed" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Other
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblWork_To_Complete_Other" MaxLength="30" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Work To Be Completed By
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblWork_To_Be_Completed_By" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Status
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <%--<asp:Label runat="server" ID="lblTask_Complete"></asp:Label>--%>
                                                                <asp:Label runat="server" ID="lblFK_LU_Maintenance_Status"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">No Approval Needed<br />
                                                                (Repair Est. Under $1000)</td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CheckBox runat="server" ID="chkNoAppovalNeededView" Enabled="false"/>
                                                            </td>
                                                            <td align="left" valign="top">Approval Needed<br />
                                                                (Repair Est. Exceed $1000)</td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CheckBox runat="server" ID="chkApprovalNeededView" Enabled="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Original Service Estimate
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">$<asp:Label ID="lblPreviousContractAmount" runat="server" />
                                                            </td>
                                                            <td align="left" valign="top">Repair and Estimate Amount
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">$<asp:Label ID="lblRevisedContractAmount" runat="server" Width="165px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Repair Cost
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>$<asp:Label ID="lblService_Repair_Cost" runat="server" MaxLength="10"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Approval Submission
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_LU_Approval_Submission" runat="server">
                                                                </asp:Label>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Record Type
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblFK_LU_Record_Type" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">CR Approved
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCRApproved" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                        <%--<tr>
                                                        <td align="left" valign="top">Client Issue
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClientIssue" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Facilities Issue
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFacilitiesIssue" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                        <%-- <tr>
                                                        <td align="left" valign="top">Cost
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$<asp:Label runat="server" ID="lblCost"></asp:Label>
                                                        </td>
                                                        
                                                    </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Job #
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblJob" runat="server"></asp:Label>
                                                            </td>
                                                             <td align="left" valign="top">Order Date
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblOrderDate" runat="server" />
                                                            </td>
                                                        </tr>
                                                     <%--   <tr>
                                                            <td align="left" valign="top">Other
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblRecord_Type_Other" MaxLength="30" runat="server"></asp:Label>
                                                            </td>
                                                           
                                                            <td align="left" valign="top">Order #
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblOrder" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td align="left" valign="top">Requested By
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblRequestedBy" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Created By
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblCreatedBy" runat="server" Width="170px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td align="left" valign="top">Reason for Request
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <uc:ctrlMultiLineTextBox ID="lblReason_Request" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Recommendation
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <uc:ctrlMultiLineTextBox ID="lblRecommendation" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trManagementNotesGridView">
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top" width="17%">Management Notes Grid
                                                                        </td>
                                                                        <td align="center" valign="top" width="5%">:
                                                                        </td>
                                                                        <td align="left" valign="top" colspan="4">
                                                                            <uc:ctrlPaging ID="ctrlPageSonicNotesView" runat="server" OnGetPage="GetManagementPageView" RecordPerPage="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <div runat="server" id="dvManagementNotesView" style="width: 99%; overflow-y: scroll; border: solid 1px #000000;">
                                                                                <asp:GridView ID="gvManagement_NotesView" runat="server" Width="97%" AutoGenerateColumns="false"
                                                                                    OnSorting="gvManagement_NotesView_Sorting" EnableViewState="true" AllowPaging="false"
                                                                                    OnRowCommand="gvManagement_NotesView_RowCommand" AllowSorting="true"
                                                                                    OnPageIndexChanging="gvManagement_NotesView_PageIndexChanging" Style="word-wrap: normal; word-break: break-all;">
                                                                                    <Columns>
                                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                                            <HeaderTemplate>
                                                                                                <input type="checkbox" id="chkMultiSelectSonicACINotesView" onclick="SelectDeselectAllACINotesView(this.checked);" />Select
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkSelectSonicACINotesView" runat="server" onclick="SelectDeselectSonicNoteHeaderView();" />
                                                                                                <input type="hidden" id="hdnPK_Sonic_Management_NotesView" runat="server" value='<%#Eval("PK_Sonic_Management_Notes") %>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Date" SortExpression="Note_Date">
                                                                                            <ItemStyle Width="10%" />
                                                                                            <ItemTemplate>
                                                                                                <a href="javascript:function(){return false};" onclick="SonicNotePopup('<%#Eval("PK_Sonic_Management_Notes") %>','SONIC');">
                                                                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="User">
                                                                                            <ItemStyle Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblUpdated_By" runat="server" Text='<%# Eval("Updated_by_Name") %>'
                                                                                                    Style="word-wrap: normal; word-break: break-all;"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Notes">
                                                                                            <ItemStyle Width="45%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' Style="word-wrap: normal; word-break: break-all;"
                                                                                                    Width="310px" CssClass="TextClip"></asp:Label>
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
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-bottom: 5px;" colspan="6">
                                                                            <asp:Button ID="btnManagementNoteView_View" runat="server" Text=" View" OnClientClick="return SonicSelectedNotePopup('','ManagementView');" />&nbsp;&nbsp;
                                                                            <asp:Button ID="btnManagementPrintView" runat="server" Text=" Print " OnClick="btnManagementPrintView_Click"
                                                                                OnClientClick="return CheckSelectedSonicNotesView('Print');" />
                                                                            &nbsp;&nbsp;
                                                                            <asp:Button ID="btnManagementSpecificNote_View" runat="server" CausesValidation="false" Text=" Show Specific Notes Only "
                                                                                OnClientClick="javascript:return CheckSelectedSonicNotesView('ManagementSpecificNote');" />
                                                                            <asp:LinkButton Style="display: none" ID="lnkManagementNotesCancelView" runat="server"
                                                                                Text="Cancel"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trgridstoreview">
                                                            <td align="left" valign="top">
                                                                <b>Store Contact</b>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:GridView ID="gvStoreContactView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                                PageSize="10" EnableViewState="true" AllowPaging="true">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="First Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("First_Name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Last_name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Phone">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Phone")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Email">
                                                                                        <ItemStyle Width="40%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Email")%>&nbsp;
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
                                                        <%-- <tr>
                                                        <td colspan="6">
                                                            <b>Store Contact :</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">First Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStore_Contact_First_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Last Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStore_Contact_Last_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Phone
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStore_Contact_Phone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Email
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStore_Contact_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>ACI Contact :</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">First Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAci_Contact_First_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Last Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAci_Contact_Last_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Phone
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAci_Contact_Phone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Email
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAci_Contact_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trgridACIview">
                                                            <td align="left" valign="top">
                                                                <b>ACI Contact</b>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                <b>:</b>
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:GridView ID="gvACIContactView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                                PageSize="10" EnableViewState="true" AllowPaging="true">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="First Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("First_Name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Last_name")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Phone">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Phone")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Email">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Email")%>&nbsp;
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
                                                        <tr>
                                                            <td colspan="6">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl2View" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Approvals
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="6">GM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="width: 100%;">
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td align="left" width="20%">E-Mail To&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label runat="server" ID="lblGM_Email_To"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label ID="lblGM_Last_Email_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label runat="server" ID="lblGM_Decisionview">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td align="left">GM Response Date&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblGM_Response_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">RLCM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="width: 100%;">
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td align="left" width="20%">E-Mail To&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label runat="server" ID="lblRLCM_Email_To"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label ID="lblRLCM_Last_Email_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label runat="server" ID="lblRLCM_Decisionview">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td align="left">RLCM Response Date&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblRLCM_Response_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">NAPM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="width: 100%;">
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td align="left" width="20%">E-Mail To&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label runat="server" ID="lblNAPM_Email_To"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label ID="lblNAPM_Last_Email_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label runat="server" ID="lblNAPM_DecisionView">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td align="left">NAPM Response Date&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblNAPM_Response_Date" runat="server"></asp:Label>
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
                                                                        <td align="left" width="20%">E-Mail To&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label runat="server" ID="lblDRM_Email_To"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="20%">Last E-Mail Date&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" width="4%">:
                                                                        </td>
                                                                        <td align="left" width="26%">
                                                                            <asp:Label ID="lblDRM_Last_Email_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">Decision
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label runat="server" ID="lblDRM_Decisionview">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td align="left">DRM Response Date&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblDRM_Response_Date" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="20%" valign="top">Comments&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl3View" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Project Cost
                                                    </div>
                                                    <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top" width="15%">Project Cost Grid<br />
                                                            </td>
                                                            <td align="center" valign="top" width="2%">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:GridView ID="gvProjectCostView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    OnRowCommand="gvProjectCost_RowCommand" OnRowDataBound="gvProjectCost_OnRowDataBound"
                                                                    ShowFooter="true">
                                                                    <Columns>
                                                                        <%--<asp:TemplateField HeaderText="Project Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Number" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Project Type">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Type" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Type")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Project Phase">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkProject_Phase" runat="server" CommandName="EditProjectCost"
                                                                                    CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# Eval("Project_Phase") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotal" Text="Total" runat="server" Font-Bold="true" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Budget($)">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbudget" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# string.Format("{0:C2}",Eval("Budget")) %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblBudgetSum" runat="server" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Cost($)">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkEstimated_Cost" runat="server" CommandName="EditProjectCost"
                                                                                    CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# string.Format("{0:C2}",Eval("Estimated_Cost")) %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblEstimatedCostSum" runat="server" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Actual Cost($)">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkActualCost" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_ACIManagement_ProjectCost") +";" + Eval("FK_Management") %>'
                                                                                    Text='<%# string.Format("{0:C2}",Eval("Actual_Cost")) %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblActualCostSum" runat="server" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No Records Found."></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr>
                                                        <td align="left" valign="top">Include Companion Project(s) in Project Cost Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:CheckBox ID="chkIncludeCompProjectView" runat="server" AutoPostBack="true" OnCheckedChanged="chkIncludeCompProject_OnCheckedChanged" />
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                            <td valign="top" style="width: auto">Invoice Grid
                                                            </td>
                                                            <td align="center" valign="top" style="width: 3%">&nbsp;:
                                                            </td>
                                                            <td style="margin-left: 40px" style="width: 650px" align="left">
                                                                <asp:GridView ID="gvInvoiceView" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    OnRowCommand="gvInvoice_RowCommand">
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Records Found."></asp:Label>
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Invoice Number">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblInvoiceNumber" runat="server" Text='<%# Eval("Invoice_Number") %>'
                                                                                    CommandName="EditRecord" CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="80px"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Invoice Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblInvoice_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Invoice_Date")) %>'
                                                                                    CommandName="EditRecord" CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="100px"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Invoice Amount($)">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblInvoice_Amount" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Amount")) %>' CommandName="EditRecord"
                                                                                    CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="120px" Style="word-wrap: normal; word-break: break-all"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Vendor">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblVendor" runat="server" Text='<%# Eval("Vendor") %>' CommandName="EditRecord"
                                                                                    CommandArgument='<%#Eval("PK_ACIManagement_ProjectCost_Invoice") %>' Width="100px" CssClass="TextClip"></asp:LinkButton>
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
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnl4View" runat="server" Style="display: block;" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Attachment
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <uc:Attachment ID="ucAttachmentView" runat="server" Attachment_Table="Management" MajorCoverage="Management" />
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
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnPreviousStep" ToolTip="Previous Step" runat="server" Text="Previous Step"
                                    CausesValidation="false" OnClientClick="return  onPreviousStep();" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="false" ValidationGroup="vsErrorGroup"
                                    OnClick="btnSave_Click" ToolTip="Save" OnClientClick="SetApprovalSubmissionOnSaveButton();" UseSubmitBehavior="false" />
                                <asp:Button ID="btnEdit" runat="server" Text=" Edit " CausesValidation="false" OnClick="btnEdit_Click"
                                    Visible="false" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnResendManagementAbstract" runat="server" Text="Save and Send Management Abstract" CausesValidation="true" Visible="false"
                                    OnClick="btnResendManagementAbstract_Click" ValidationGroup="vsErrorGroup" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" CausesValidation="false"
                                    Visible="false" OnClientClick="javascript:return AuditPopUp();" ToolTip="View Audit Trail" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnNextStep" runat="server" ToolTip="Next Step" Text="Next Step"
                                    CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="javascript:return onNextStep();" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">

        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenAssociateName() {
            var pk_Location = document.getElementById('<%=drpLocation.ClientID %>')
            if (pk_Location.selectedIndex > 0)
                GB_showCenter('Employee Name', '<%=AppConfig.SiteURL%>Management/EmployeePopup.aspx?pk=' + pk_Location.value, 500, 500, '');
            else
                alert('Please select DBA');
            return false;
        }

        function CheckNumericValOnly(Ctl, length) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true) {
                Ctl.innerText = "";
            }
        }

        function CheckNumericVal(Ctl, length) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = "";
            else {
                var len1 = Ctl.value.split(".")[0].replace(/,/g, '').length;
                if (len1 > length - 2) {
                    alert("Length is exceeded.");
                    Ctl.innerText = "";
                }
                else
                    Ctl.innerText = formatCurrency_New(Ctl.value);
            }

            var originalAmount =  $('#<%= txtPreviousContractAmount.ClientID %>').length > 0 ? $('#<%= txtPreviousContractAmount.ClientID %>').val().trim() : "";
            var estimatedAmount = $('#<%= txtRevisedContractAmount.ClientID %>').length > 0 ? $('#<%= txtRevisedContractAmount.ClientID %>').val().trim() : "";
            var total = 0;

            originalAmount = originalAmount.replace(/,/g , "");
            estimatedAmount = estimatedAmount.replace(/,/g,"");

            originalAmount = parseFloat(originalAmount);
            estimatedAmount = parseFloat(estimatedAmount);

            if(!isNaN(originalAmount) && !isNaN(estimatedAmount))
            {
                total = originalAmount + estimatedAmount;
            }
            else if(isNaN(originalAmount) && isNaN(estimatedAmount))
            {
                total = 0;
            }
            else if(isNaN(originalAmount)){
                total = estimatedAmount;
            }
            else if(isNaN(estimatedAmount)){
                total = originalAmount;
            }

            $('#<%= txtService_Repair_Cost.ClientID %>').val(formatCurrency_New(total));
        }
        function formatCurrency_New(num) {
            num = num.toString().replace(/\$|\,/g, '');
            if (isNaN(num))
                num = "0";

            sign = (num == (num = Math.abs(num)));
            num = Math.floor(num * 100 + 0.50000000001);
            cents = num % 100;
            num = Math.floor(num / 100).toString();

            if (cents < 10)
                cents = "0" + cents;

            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
                num = num.substring(0, num.length - (4 * i + 3)) + ',' +

            num.substring(num.length - (4 * i + 3));

            return (((sign) ? '' : '-') + num + '.' + cents);
        }
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:HiddenField ID="hdnApprovalSubmission" runat="server" Value="0" />
</asp:Content>
