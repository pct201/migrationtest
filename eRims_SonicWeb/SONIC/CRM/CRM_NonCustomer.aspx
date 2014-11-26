<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="CRM_NonCustomer.aspx.cs" Inherits="SONIC_CRM_CRM_NonCustomer" ValidateRequest="false" %>

<%@ Register Src="~/Controls/CRMTab/CRMTab.ascx" TagName="Tab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/CRMInfo/CRMInfo_NonCustomer.ascx" TagName="Info" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_CRM/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_CRM/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script language="VBScript" type="text/vbscript">
	    Function vbMsg(isTxt,isCaption)
	    testVal = MsgBox(isTxt,4,isCaption)
	    isChoice = testVal
	    End Function
    </script>
    <script type="text/javascript">
        function CheckCategory(bsave, bmail) {
            if (bmail == 'bmail') {
                callAlert("The e-mail address has changed, do you want to resend the auto e-mail to the new e-mail address?");
            }
            else if (bmail == 'bresume') {
                callAlert("The category was changed to 'Resume Submission', do you want to send the auto e-mail to the e-mail address?");
            }
            else if (bmail == 'bvendor') {
                callAlert("The category was changed to 'Vendor', do you want to send the auto e-mail to the e-mail address?");
            }
            if (isChoice == 7) {
                document.getElementById("ctl00_ContentPlaceHolder1_hdnCheckCategory").value = false
                document.getElementById("ctl00_ContentPlaceHolder1_hdnCheckEmail").value = false;
                if (bsave == 'bsave') {
                    __doPostBack('<%=btnSave.ClientID%>', 'nosaverecord');
                }
                else if (bsave == 'bnotes') {
                    __doPostBack('<%=lbtAddNotes.ClientID%>', 'nonotes');
                }
                else if (bsave = 'bres') {
                    __doPostBack('<%=lnkResolution.ClientID%>', 'noresolution');
                }
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_hdnCheckCategory").value = true;
                document.getElementById("ctl00_ContentPlaceHolder1_hdnCheckEmail").value = true;
                if (bsave == 'bsave') {
                    __doPostBack('<%=btnSave.ClientID%>', 'yessaverecord');
                }
                else if (bsave == 'bnotes') {
                    __doPostBack('<%=lbtAddNotes.ClientID%>', 'yesnotes');
                }
                else if (bsave = 'bres') {
                    __doPostBack('<%=lnkResolution.ClientID%>', 'yesresolution');
                }
            }
        }
        var isChoice = 0;
        function callAlert(Msg, Title) {
            txt = Msg;
            caption = 'Non-Customer Emails';
            vbMsg(txt, caption);
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
        }
        var ActiveTabIndex = 1;
        function onNextStep() {
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanelView(ActiveTabIndex);
                return false;
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanel(ActiveTabIndex);
                return false;
            }
        }
        function onPreviousStep() {
            ActiveTabIndex = ActiveTabIndex - 1;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            ShowPanel(ActiveTabIndex);
            return false;
        }
        function ShowPanel(index) {

            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 4) {
                    for (i = 1; i <= 3; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnNextStep.ClientID%>").style.display = "inline";
                }
                else {
                    for (i = 1; i <= 3; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                    document.getElementById("<%=btnNextStep.ClientID%>").style.display = "none";
                }
                SetFocusOnFirstControl(index)
            }
            if (index == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
            else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "block";
        }
        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 4) {
                for (i = 1; i <= 3; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                document.getElementById("<%=btnNextStep.ClientID%>").style.display = "inline";
            }
            else {
                for (i = 1; i <= 3; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                document.getElementById("<%=btnNextStep.ClientID%>").style.display = "none";
            }
            if (index == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
            else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "block";
        }
        function SetFocusOnFirstControl(index) {

            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_drpFK_LU_CRM_Source').focus(); break;
                case 2:
                    document.getElementById('ctl00_ContentPlaceHolder1_lbtAddNotes').focus(); break;
                case 3:
                    document.getElementById('ctl00_ContentPlaceHolder1_lnkResolution').focus(); break;
                case 4:
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_txtAttachDesc_txtNote').focus();
                default:
                    break;
            }
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open('AuditPopup_CRM_NonCustomer.aspx?id=<%=ViewState["PK_CRM_Non_Customer"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function IfSave() {
            var values = '<%=ViewState["PK_CRM_Non_Customer"]%>';
            if (values == '0') {
                alert('Please Save Non Customer Information First');
                ShowPanel(1);
                return false;
            }
            else return Page_ClientValidate('AddAttachment');
        }
        function CalculateDaysClosed(PanelNum) {
            var txtIncidentDate = document.getElementById("ctl00_ContentPlaceHolder1_txtRecord_Date").value;
            var txtCloseDate = document.getElementById("ctl00_ContentPlaceHolder1_txtResponse_Date").value;
            if (txtIncidentDate != '' && txtCloseDate != '')
                __doPostBack('CalculateNumDaysClosed', PanelNum);
            else
                document.getElementById("ctl00_ContentPlaceHolder1_txtDays_To_Close").value = '';

        }
        function CheckCategoryTest(bsave) {

            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate()) {
                var drpCategoryType = document.getElementById('<%=drpFK_LU_CRM_Category.ClientID%>');
                var drpCategoryName = drpCategoryType.options[drpCategoryType.selectedIndex].text;
                var txtEmail = document.getElementById('<%=txtEmail.ClientID%>');
                var txtEmailName = "";
                if (txtEmail != "")
                    txtEmailName = txtEmail.value;
                var hdnCategory = document.getElementById("ctl00_ContentPlaceHolder1_hdnCheckCategory").value;
                var hdnEmail = document.getElementById("ctl00_ContentPlaceHolder1_hdnCheckEmail").value;
                var values = '<%=ViewState["PK_CRM_Non_Customer"]%>';
                if (values > 0) {

                    if (hdnCategory != drpCategoryName && (drpCategoryName == 'Resume Submission' || drpCategoryName == 'Vendor') && hdnEmail != txtEmailName) {
                        if (txtEmailName != "") {
                            callAlert("The category was changed to '" + drpCategoryName + "', do you want to send the auto e-mail to the e-mail address? " + "\n\n" +
                                  "The e-mail address has changed, do you want to resend the auto e-mail to the new e-mail address?");
                            if (isChoice == 7) {
                                document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = false;
                            }
                            else {
                                document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = true;
                            }
                        }
                    }

                    else if (hdnCategory != drpCategoryName && drpCategoryName == 'Resume Submission') {
                        if (txtEmailName != "") {
                            callAlert("The category was changed to 'Resume Submission', do you want to send the auto e-mail to the e-mail address?");
                            if (isChoice == 7) {
                                document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = false;
                            }
                            else {
                                document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = true;
                            }
                        }
                    }
                    else if (hdnCategory != drpCategoryName && drpCategoryName == 'Vendor') {
                        if (txtEmailName != "") {
                            callAlert("The category was changed to 'Vendor', do you want to send the auto e-mail to the e-mail address?");
                            if (isChoice == 7) {
                                document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = false;
                            }
                            else {
                                document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = true;
                            }
                        }
                    }
                    else if (drpCategoryName == 'Resume Submission' || drpCategoryName == 'Vendor') {
                        if (txtEmailName != "") {
                            if (hdnEmail != txtEmailName) {
                                callAlert("The e-mail address has changed, do you want to resend the auto e-mail to the new e-mail address?");
                                if (isChoice == 7) {
                                    document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = false;
                                }
                                else {
                                    document.getElementById("ctl00_ContentPlaceHolder1_hdnSendMail").value = true;
                                }
                            }
                        }
                    }
                }
            }
            else {
                Page_ClientValidate('Dummy');
                return false;
            }
        }
        function ConfirmRemove() {
            return confirm("Are you sure to remove?");
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
    </script>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="trCustomerTab" visible="true">
            <td align="left">
                <uc:Tab ID="ucCRMTab" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="trCustomerInfo" visible="false">
            <td align="left">
                <uc:Info ID="ucCRMInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Non-Customer Information
            </td>
        </tr>
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Contact Information&nbsp;<span
                                           id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Notes</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Resolution&nbsp;<span
                                           id="MenuAsterisk3" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Attachments</span>
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
                                    <td class="dvContainer" width="794px">
                                        <div id="dvEdit" runat="server" width="794x">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Contact Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="22%" valign="top">
                                                            Contact Number
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="27%" valign="top">
                                                            <asp:TextBox ID="txtContactNumber" runat="server" Width="170px" Enabled="false" />
                                                        </td>
                                                        <td align="left" width="21%" valign="top">
                                                            Source&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Source" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtRecord_Date" runat="server" Width="150px" SkinID="txtDate" onblur="CalculateDaysClosed(1);" />
                                                            <img alt="Date of Contact" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRecord_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                onmouseout="javascript:ctl00_ContentPlaceHolder1_txtRecord_Date.focus();" align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Contact Information]/Date of Contact is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtRecord_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Company Name&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompany_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Location D/B/A&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpFK_LU_Location" Width="568px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Name&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLast_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            First Name&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFirst_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="30" />
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
                                                            State&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Zip (XXXXX-XXXX)&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtZip_Code" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Please Enter [Contact Information]/Zip Code is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtZip_code" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                Display="none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Email&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtEmail" runat="server" Width="565px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="RegExpEmailID" runat="server" ControlToValidate="txtEmail"
                                                                Display="None" ErrorMessage="Please Enter [Contact Information]/Valid Email Address"
                                                                SetFocusOnError="True" ToolTip="Please Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Home Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span11" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtHome_Telephone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="regSecuCam_Telephone_Number" ControlToValidate="txtHome_Telephone"
                                                                SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter [Contact Information]/Home Telephone in XXX-XXX-XXXX format."
                                                                Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Cell Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCell_Telephone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtCell_Telephone"
                                                                SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter [Contact Information]/Cell Telephone in XXX-XXX-XXXX format."
                                                                Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Work Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span13" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Telephone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtWork_Telephone"
                                                                SetFocusOnError="true" runat="server" ValidationGroup="vsErrorBuilding" ErrorMessage="Please Enter [Contact Information]/Work Telephone in XXX-XXX-XXXX format."
                                                                Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Work Telephone Extension&nbsp;<span id="Span14" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Telephone_Extension" runat="server" Width="170px" MaxLength="10" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Comment/Call/Inquiry Summary&nbsp;<span id="Span15" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtComment_Call_Inquiry_Summary" runat="server" RequiredFieldMessage="Please enter [Contact Information]/Comment/Call/Inquiry Summary"
                                                                ValidationGroup="vsErrorGroup" IsRequired="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Media Call Response Summary&nbsp;<span id="Span16" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtMedia_Call_Response_Summary" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Action Summary&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAction_Summary" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Category&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Category" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" height="170">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 15%">
                                                            Notes Grid
                                                            <br />
                                                            <asp:LinkButton ID="lbtAddNotes" runat="server" Text="--Add--" CausesValidation="true"
                                                                OnClick="lbtAddNotes_Click" ValidationGroup="vsErrorGroup" OnClientClick="return CheckCategoryTest('addnotes');" />
                                                        </td>
                                                        <td align="center" valign="top" style="width: 2%">
                                                            :
                                                        </td>
                                                        <td style="width: 83%">
                                                            <div id="divgvNotes" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 700px; height: 200px">
                                                                <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    OnRowCommand="gvNotes_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <a href='CRM_NonCustomer_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="75%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Note")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblRemove" runat="server" CommandName="Remove" CommandArgument='<%#Eval("PK_CRM_Notes") %>'
                                                                                    OnClientClick="javascript:return ConfirmRemove();" Text="Remove" ToolTip="Remove"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Record found.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Resolution</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 15%">
                                                            Resolution
                                                            <br />
                                                            <asp:LinkButton ID="lnkResolution" runat="server" Text="--Add--" OnClientClick="return CheckCategoryTest('addresolution');"
                                                                OnClick="lnkResolution_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 2%">
                                                            :
                                                        </td>
                                                        <td style="width: 83%">
                                                            <div id="divgvResolution" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 700px; height: 200px">
                                                                <asp:GridView ID="gvResolution" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    OnRowCommand="gvResolution_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <a href='CRM_NonCustomer_Resolution_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="75%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Note")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblRemove" runat="server" CommandName="Remove" CommandArgument='<%#Eval("PK_CRM_Notes") %>'
                                                                                    OnClientClick="javascript:return ConfirmRemove();" Text="Remove" ToolTip="Remove"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Record found.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" style="width: 15%">
                                                            Response Sent?
                                                        </td>
                                                        <td align="center" valign="top" style="width: 2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" style="width: 30%">
                                                            <asp:RadioButtonList ID="rdoResponse_Sent" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top" style="width: 21%">
                                                            Method of Response&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" style="width: 28%">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Response_Method" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date Response Sent&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtResponse_Date" runat="server" Width="150px" SkinID="txtDate"
                                                                onblur="CalculateDaysClosed(3);" />
                                                            <img alt="Date Response Sent" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtResponse_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                onmouseout="javascript:ctl00_ContentPlaceHolder1_txtResponse_Date.focus();" align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                ErrorMessage="[Contact Information]/Date of Response is not a valid date" Display="none"
                                                                SetFocusOnError="true" ControlToValidate="txtResponse_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Response N/A?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoResponse_NA" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Days to Close
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDays_To_Close" runat="server" Width="170px" Enabled="false" onkeypress="return FormatNumber(event,this.id,4,true);"
                                                                onpaste="return false" />
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
                                                </table>
                                            </asp:Panel>
                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Add Attachment
                                                </div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" runat="Server" ShowAttachmentButton="true" OnbtnHandler="Attachment_btnHandler" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Contact Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="22%" valign="top">
                                                            Contact Number
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="27%" valign="top">
                                                            <asp:Label ID="lblContactNumber" runat="server" />
                                                        </td>
                                                        <td align="left" width="21%" valign="top">
                                                            Date of Contact
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%" valign="top">
                                                            <asp:Label ID="lblRecord_Date" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Source
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Source" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Company Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompany_Name" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Location D/B/A
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblFK_LU_Location" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLast_Name" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            First Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFirst_Name" runat="server" />
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
                                                            <asp:Label ID="lblCity" runat="server" />
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
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Zip (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblZip_Code" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmail" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Home Telephone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHome_Telephone" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Cell Telephone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCell_Telephone" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Work Telephone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWork_Telephone" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Work Telephone Extension
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWork_Telephone_Extension" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Comment/Call/Inquiry Summary
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblComment_Call_Inquiry_Summary" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Media Call Response Summary
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblMedia_Call_Response_Summary" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Action Summary
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAction_Summary" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Category&nbsp;<span style="color: Red">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Category" runat="server">
                                                            </asp:Label>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" height="170">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 10%">
                                                            Notes Grid
                                                        </td>
                                                        <td align="center" valign="top" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td style="width: 86%">
                                                            <div id="divgvNotesView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 700px; height: 200px">
                                                                <asp:GridView ID="gvNotesView" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <a href='CRM_NonCustomer_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="88%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Note")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Record found.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Resolution</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 10%">
                                                            Resolution
                                                        </td>
                                                        <td align="center" valign="top" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td style="width: 86%">
                                                            <div id="divgvResolutionView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 700px; height: 200px">
                                                                <asp:GridView ID="gvResolutionView" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <a href='CRM_NonCustomer_Resolution_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="88%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Note")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Record found.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" bolbler="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Response Sent?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResponse_Sent" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Method of Response
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Response_Method" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date Response Sent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResponse_Date" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Response N/A?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResponse_NA" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Days to Close
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDays_To_Close" runat="server" />
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
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                            <div class="bandHeaderRow">
                                                Attachment Details
                                            </div>
                                            <table cellpadding="0" cellspacing="0" width="100%" height="88">
                                                <tr>
                                                    <td width="100%">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 15px;">
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
                                <table cellpadding="5" cellspacing="1" width="100%">
                                    <tr>
                                        <td width="100%" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnPreviousStep" runat="server" Text="Previous Step" CausesValidation="false"
                                                            OnClientClick="return  onPreviousStep();" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" Text=" Save & View " CausesValidation="true"
                                                            OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" OnClientClick="return CheckCategoryTest('bsave');" />
                                                        <asp:Button ID="btnEdit" runat="server" Visible="false" Text="  Edit  " OnClick="btnEdit_Click" />
                                                        <asp:Button ID="btnNextStep" runat="server" Text="Next Step" CausesValidation="true"
                                                            ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" />
                                                        <asp:Button runat="server" ID="btnLAAudit_View" Text="View Audit Trail" CausesValidation="false"
                                                            Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
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
                <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
                <asp:HiddenField ID="hdnCheckCategory" runat="server" Value="true" />
                <asp:HiddenField ID="hdnCheckEmail" runat="server" Value="true" />
                <asp:Button ID="btndays" runat="server" Style="display: none" />
                <asp:HiddenField ID="hdnSendMail" runat="server" Value="false" />
                <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
