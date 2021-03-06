﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ACI_Video_Request.aspx.cs" Inherits="Event_ACI_Video_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>--%>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Event/AttachmentEvent.ascx" TagName="Attachment" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>

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


        function ConfirmRemove() {
            return confirm("Are you sure to remove?");
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
            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                }
                document.getElementById('<%=pnlAttachment.ClientID%>').style.display = (index == 2) ? "block" : "none";
            }
        }



        function ShowPanelView(index) {
            SetMenuStyle(index);
           // document.getElementById('ctl00_ContentPlaceHolder1_pnl' + 1 +'view').style.display = "block";
        }

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
                if (Page_ClientValidate("vsErrorGroup")) {
                    bValid = true;

                }
                if (bValid)
                    CallSave(id);
            }
        }



        function CallSave(id) {
            
            if (id == 'btnSend_Notification_Video')
                __doPostBack('ctl00$ContentPlaceHolder1$btnSend_Notification_Video', '');
            else
                __doPostBack('ctl00$ContentPlaceHolder1$btnSave', '');
        }


        function setIncidentReportSonic()
        {
            //alert('98647');
        }

        
        function VideoNotePopup(NoteId, type) {            
            var winHeight = 500;
            var winWidth = 500;
            var VideoId = <%=ViewState["PK_Event_Video_Tracking_Request"]%>;            
        obj = window.open("Video_Request_Note.aspx?nid=" + NoteId + "&id=" + '<%=ViewState["PK_Event_Video_Tracking_Request"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
        obj.focus();
    }

    function VideoSelectedNotePopup(NoteId, type) {  
        var winHeight = 450;
        var winWidth = 750;
        var VideoId = <%=ViewState["PK_Event_Video_Tracking_Request"]%>;            
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

        function checkLength() {
            var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtVideo_Notes_txtNote')
            if (oObject.value.length < 50) {
                alert("Please enter minimum 50 Characters for Notes.");
                return false;
            }
            else {
                return true;
            }
        }

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

        function showbutton()
        {
            var savebutton =  document.getElementById("<%=btnSend_Notification_Video.ClientID%>");
            var status =  document.getElementById("<%=drpStatus.ClientID%>");
            var selectedText = status.options[status.selectedIndex].text;

            if(selectedText == 'Closed'){
                savebutton.style.display = "";
                savebutton.value = "Save";
            }
            else
            {
                savebutton.style.display = "none";
                savebutton.value = "Save and Send Notification";
            }
                

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
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">Video Request
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Video Request</span>
                                        <span id="Span1" runat="server" style="color: Red;">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachments</span>
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
                                        <asp:HiddenField ID="hndScrollX" runat="server" />
                                        <asp:HiddenField ID="hndScrollY" runat="server" />
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Video Request
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Location&nbsp;<span id="Span2" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation_Video" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvddlLocation_Video" runat="server" ControlToValidate="ddlLocation_Video"
                                                                InitialValue="0" ErrorMessage="Please Select Location" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Type Of Activity<%--&nbsp;<span id="Span3" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlFK_LU_Type_of_Activity_Video" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                          <%--  <asp:RequiredFieldValidator ID="rfvddlFK_LU_Type_of_Activity_Video" runat="server" ControlToValidate="ddlFK_LU_Type_of_Activity_Video"
                                                                InitialValue="0" ErrorMessage="Please Select Type of Activity" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Event&nbsp;<span id="Span4" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCurrentDate_Video" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="txtDate_Of_Event_Video" runat="server" SkinID="txtDate" />
                                                            <img alt="Date of Event" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Event_Video', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgEvent_Start_Date" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Of_Event_Video" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="Date of Event is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Of_Event_Video" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDate_Of_Event_Video" runat="server" ControlToCompare="txtCurrentDate_Video"
                                                                ControlToValidate="txtDate_Of_Event_Video" Display="None" Text="*" ErrorMessage="Date of Event should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:RequiredFieldValidator ID="rfvtxtDate_Of_Event_Video" runat="server" ControlToValidate="txtDate_Of_Event_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Date of Event" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Request&nbsp;<span id="Span5" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Of_Request_Video" runat="server" SkinID="txtDate" Enabled="false" />
                                                            <%--<img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Request_Video', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="img1" />--%>
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Of_Request_Video" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="Date of Request is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Of_Request_Video" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDate_Of_Request_Video" runat="server" ControlToCompare="txtCurrentDate_Video"
                                                                ControlToValidate="txtDate_Of_Request_Video" Display="None" Text="*" ErrorMessage="Date of Request should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:RequiredFieldValidator ID="rfvtxtDate_Of_Request_Video" runat="server" ControlToValidate="txtDate_Of_Request_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Date of Request" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Full Name&nbsp;<span id="Span6" runat="server" style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFull_Name_Video" runat="server" MaxLength="500" Width="170px" />
                                                            <asp:RequiredFieldValidator ID="revtxtFull_Name_Video" runat="server" ControlToValidate="txtFull_Name_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Full Name" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Work Phone<%--&nbsp;<span id="Span8" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Phone_Video" runat="server" autocomplete="off" MaxLength="12" Width="165px" SkinID="txtPhone"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regtxtWork_Phone_Video" ControlToValidate="txtWork_Phone_Video"
                                                                runat="server" SetFocusOnError="true" ErrorMessage="Please Enter Work Phone # in XXX-XXX-XXXX format"
                                                                Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                            <%--<asp:RequiredFieldValidator ID="revtxtWork_Phone_Video" runat="server" ControlToValidate="txtWork_Phone_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Work Phone" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <%--Location&nbsp;<span id="Span7" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top"><%--:--%>&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                           <%-- <asp:TextBox ID="txtLocation_Video" runat="server" MaxLength="500"  Width="170px" />
                                                            <asp:RequiredFieldValidator ID="revtxtLocation_Video" runat="server" ControlToValidate="txtFull_Name_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Location" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Alternate Phone<%--&nbsp;<span id="Span9" runat="server" style="color: Red;">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAlternate_Phone_Video" runat="server" autocomplete="off" MaxLength="12" Width="165px" SkinID="txtPhone"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regtxtAlternate_Phone_Video" ControlToValidate="txtAlternate_Phone_Video"
                                                                runat="server" SetFocusOnError="true" ErrorMessage="Please Enter Alternate Phone # in XXX-XXX-XXXX format"
                                                                Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                            <%--<asp:RequiredFieldValidator ID="revtxtAlternate_Phone_Video" runat="server" ControlToValidate="txtAlternate_Phone_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Alternate Phone" Display="None" SetFocusOnError="true"
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
                                                            <asp:RequiredFieldValidator ID="revdrpStatus" runat="server" ControlToValidate="drpStatus"
                                                                InitialValue="0" ErrorMessage="Please Select Status" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"  colspan="6">
                                                            Reason the Request is Being Made (Please Include as much Detail as Possible)&nbsp;<span style="color: Red;">*</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                        </td>
                                                        <td style="vertical-align: top;">:</td>
                                                        <td colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtReason_Request_Video" runat="server" Width="500" IsRequired="true" RequiredFieldMessage="Please Enter Reason the Request is Being Made (Please Include as much Detail as Possible)" ValidationGroup="vsErrorGroup" />
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
                                                                        <asp:Button ID="btnVideoNotesAdd" OnClick="btnVideoNotesAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
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
                                                                        <uc:ctrlPaging ID="ctrlPageVideoNotes" runat="server" OnGetPage="GetPage" RecordPerPage="true" />
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
                                                                        <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click"
                                                                            OnClientClick="return CheckSelectedVideoNotes('Print');" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnSpecificNote" runat="server" CausesValidation="false" Text=" Show Specific Notes Only "
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
                                                        <td align="left" width="18%" valign="top">
                                                            Camera Name&nbsp;<span style="color: Red;" runat="server" id="spancameraname">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCamera_Name_Video" runat="server" MaxLength="500" Width="170px" />
                                                            <asp:RequiredFieldValidator ID="revtxtCamera_Name_Video" runat="server" ControlToValidate="txtCamera_Name_Video"
                                                                    InitialValue="" ErrorMessage="Please Enter Camera Name" Display="None" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                           &nbsp;
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
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Start_Time_Video"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="regtxtEvent_Start_Time_Video" runat="server" ControlToValidate="txtEvent_Start_Time_Video"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="Invalid Event Start Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="revtxtEvent_Start_Time_Video" runat="server" ControlToValidate="txtEvent_Start_Time_Video"
                                                                InitialValue="" ErrorMessage="Please Enter Event Start Time" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" valign="top">Event End Time&nbsp;<span style="color: Red;" runat="server" id="spanendtime">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_End_Time_Video" runat="server" MaxLength="5" Width="170px" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_End_Time_Video"
                                                                CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="regtxtEvent_End_Time_Video" runat="server" ControlToValidate="txtEvent_End_Time_Video"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="Invalid Event End Time" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                             <asp:RequiredFieldValidator ID="revtxtEvent_End_Time_Video" runat="server" ControlToValidate="txtEvent_End_Time_Video"
                                                                InitialValue="" ErrorMessage="Please Enter Event End Time" Display="None" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Video Link - Email Address to Send Link
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtVideo_Link_Email_Video" runat="server" MaxLength="100" Width="170px" />
                                                              <asp:RegularExpressionValidator ID="regtxtVideo_Link_Email_Video" runat="server" ControlToValidate="txtVideo_Link_Email_Video"
                                                                Display="None" ErrorMessage="Video Link - Email Address to Send Link is not valid" SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                           &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Still Shots - Email Address to Send Link
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtStill_Shots_Email_Video" runat="server" MaxLength="100" Width="170px" />
                                                            <asp:RegularExpressionValidator ID="regtxtStill_Shots_Email_Video" runat="server" ControlToValidate="txtStill_Shots_Email_Video"
                                                                Display="None" ErrorMessage="Still Shots - Email Address to Send Link is not valid" SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                           &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            DVD No. of Copies
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtNo_DVD_Copy_Video" runat="server" MaxLength="3" Width="40px" autocomplete="off"
                                                                    onKeyPress="return FormatInteger(event);" onpaste="return false" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                           &nbsp;
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
                                                            <asp:RadioButtonList ID="rdoUrgent_Need_Video" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdoUrgent_Need_Video_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
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
                                                        <td align="left" valign="top">
                                                            Address
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                           <asp:TextBox ID="txtMailing_Address_Video" runat="server" MaxLength="1000" Width="370px" />             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Shipping Method
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoShipping_Method_Video" runat="server">
                                                                <asp:ListItem Text="Overnight" Value="Overnight"></asp:ListItem>
                                                                <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                                                                <asp:ListItem Text="Express/2-Day" Value="Express/2-Day"></asp:ListItem>
                                                            </asp:RadioButtonList>            
                                                        </td>
                                                        <td align="left" valign="top">
                                                                       
                                                        </td>
                                                        <td align="center" valign="top">
                                                                        
                                                        </td>
                                                        <td align="left" valign="top">
                                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachment" runat="server" Style="display: none;" Width="794px">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="100%" style="height: 200px;">
                                                        <uc:Attachment ID="ucAttachment_Video" runat="server" Attachment_Table="Event_Video_Tracking_Request" MajorCoverage="Event" ReadOnly="true" />
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
                                        <td width="100%" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <%--<asp:Button ID="btnPreviousStep" ToolTip="Previous Step" runat="server" Text="Previous Step"
                                                            OnClick="btnPreviousStep_Click" CausesValidation="false" OnClientClick="return  onPreviousStep();" />--%>
                                                    </td>
                                                    <td>
                                                        <%--<asp:Button ID="btnSave" runat="server" ToolTip="Save & Continue Editing" Text="Save & Continue Editing"
                                                            OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            Width="170px" OnClientClick="CheckBeforeSave('btnSave');return false;" />--%>
                                                        <asp:Button ID="btnSend_Notification_Video" runat="server" ToolTip="Save and Send Notification" Text="Save and Send Notification"
                                                            OnClick="btnSend_Notification_Video_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            Width="190px" OnClientClick="CheckBeforeSave('btnSend_Notification_Video');return false;" />
                                                        <asp:Button ID="btnSaveHidden" runat="server" OnClick="btnSaveHidden_Click" Style="display: none" />
                                                        <asp:Button ID="btnBack" runat="server" ToolTip="Back to Search" Text="Back to Search" CausesValidation="false"
                                                            OnClick="btnBack_Click" />
                                                        <%--<asp:Button ID="btnNextStep" runat="server" ToolTip="Next Step" Text="Next Step"
                                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="javascript:return onNextStep();"
                                                            OnClick="btnNextStep_Click" />--%>
                                                     <%--   <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                            ToolTip="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />&nbsp;--%>
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

