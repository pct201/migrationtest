<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PM_Permits.aspx.cs" Inherits="SONIC_Pollution_PM_Permits" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/Attachment_Pollution.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/AttachmentDetails_Pollution.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <style type="text/css">
     .SubTotalRowStyle
        {
	        font-size: 10px;
	        background-image: url(../../images/TableHeader1.gif);
	        background-repeat: repeat-x;
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        background-color: #8ab2d7;
            color: black;
        }
     </style>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
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
                        document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = "block" ;
                    }
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                        document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = "block";
                    }
                }
                if (index == 2) {
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_txtAttachDesc_txtNote').focus();
                    document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = "none";
                }
                else
                    document.getElementById('<%=drpFK_Permit_Type.ClientID%>').focus();
            }
        }

        function ShowPanelView(index) {
            try {
                SetMenuStyle(index);
                document.getElementById('<%=dvView.ClientID%>').style.display = "block";
                var i;
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                        document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = "block";
                    }
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                        document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = "block";
                    }
                }
                    if (index == 2)
                    {
                        document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = "none";
                    }
            }
            catch (e) { }
        }

        function ValSave() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Permits.aspx?id=<%=ViewState["PK_PM_Permits"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                    if (ctrl != null) {
                        switch (ctrl.type) {
                            case "textarea":
                            case "text": if (ctrl.value == '') bEmpty = true; break;
                            case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        }
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
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Permits
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
                                        &nbsp;&nbsp; <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Permits</span>&nbsp;<span
                                        id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">&nbsp;&nbsp;<span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachments</span>
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
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Permits
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="15%" valign="top">Permit Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="2%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpFK_Permit_Type" Width="585px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="15%" valign="top">Permit Required?
                                                        </td>
                                                        <td align="center" width="2%" valign="top">:
                                                        </td>
                                                        <td align="left" width="30%" valign="top">
                                                            <asp:RadioButtonList ID="rdoPermit_Required" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="21%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="2%" valign="top">&nbsp
                                                        </td>
                                                        <td align="left" width="30%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Certification Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCertification_Number" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Application Regulation Number&nbsp;<span id="Span3" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtApplication_Regulation_Number" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Permit Start Date&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPermit_Start_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Permit Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Start_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revPermit_Start_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Permits]/Permit Start Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtPermit_Start_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Permit End Date&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPermit_End_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Permit End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_End_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revPermit_End_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Permits]/Permit End Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtPermit_End_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvPermit_End_Date" runat="server" ErrorMessage="[Permits]/Permit End Date must be greater than or equal to [Permits]/Permit Start Date"
                                                                ControlToValidate="txtPermit_End_Date" ControlToCompare="txtPermit_Start_Date"
                                                                Type="Date" Operator="GreaterThanEqual" ValidationGroup="vsErrorGroup" Display="none"
                                                                SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Last Inspection Date&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLast_Inspection_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Last Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLast_Inspection_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revLast_Inspection_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Permits]/Last Inspection Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtLast_Inspection_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Next Inspection Date&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNext_Inspection_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Next Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNext_Inspection_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revNext_Inspection_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Permits]/Next Inspection Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtNext_Inspection_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="[Permits]/Next Inspection Date must be greater than or equal to [Permits]/Last Inspection Date"
                                                                ControlToValidate="txtNext_Inspection_Date" ControlToCompare="txtLast_Inspection_Date"
                                                                Type="Date" Operator="GreaterThanEqual" ValidationGroup="vsErrorGroup" Display="none"
                                                                SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Next Report Date&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNext_Report_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Next Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNext_Report_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revNext_Report_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Permits]/Next Report Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtNext_Report_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Recommendations&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRecommendations" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Does this Permit data apply to all buildings at this location?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoApply_To_Location" runat="server" SkinID="YesNoType" />
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                            <div id="dvAttachment" runat="server" style="display: none;">
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
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Permits
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Permit Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:Label ID="lblFK_Permit_Type" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Permit Required?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblPermit_Required" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Certification Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCertification_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Application Regulation Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblApplication_Regulation_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Permit Start Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPermit_Start_Date" runat="server"></asp:Label>
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
                                                        <td align="left" valign="top">Last Inspection Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLast_Inspection_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Next Inspection Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNext_Inspection_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Next Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNext_Report_Date" runat="server"></asp:Label>
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
                                                    <tr>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
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
                                                        <td align="left" valign="top">Does this Permit data apply to all buildings at this location?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblApply_To_Location" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>

                                            <asp:Panel ID="pnl2View" runat="server" Style="display: inline;">
                                                <div id="Div1" runat="server" style="display: inline;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
													<td class="Spacer" style="height: 150px;"></td>
												</tr>--%>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div id="dvVOCGrid" runat="server" width="794px">
                                                    <div class="bandHeaderRow">
                                                        VOC Emissions
                                                    </div>
                                                    <br />
                                                    <input type="hidden" id="hiddenPKPermit" runat="server" />
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" runat="server" id="tblVOCGrid">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="gvVOCEmission" runat="server" EmptyDataText="No Other VOC Records Found"
                                                                    AutoGenerateColumns="false" Width="100%" OnRowCommand="gvVOCEmission_RowCommand" OnRowDataBound="gvVOCEmission_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Year">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkYear" runat="server" Text='<%# Eval("Year")%>' CommandName="ViewVOCDetail"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Month">
                                                                            <ItemStyle Width="15%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkMonth" runat="server" Text='<%#Eval("Month")%>' CommandName="ViewVOCDetail"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Paint Category">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkCategory" runat="server" Text='<%#Eval("Category")%>' CommandName="ViewVOCDetail"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Item Number">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkPart_Number" runat="server" Text='<%#Eval("Part_Number")%>' CommandName="ViewVOCDetail"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Gallons">
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkGallons" runat="server" Text='<%#Eval("Gallons")%>' CommandName="ViewVOCDetail"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="VOC Emissions">
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkVOC_Emissions" runat="server" Text='<%#Eval("VOC_Emissions")%>' CommandName="ViewVOCDetail"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" CommandName="Remove"
                                                                                    CommandArgument='<%# Eval("PK_PM_Permits_VOC_Emissions") %>' Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"></asp:LinkButton>
                                                                              <%--  <input type="hidden" id="hdnLink" runat="server" />--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField>
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdnLink" runat="server"  value ='<%# Eval("IsFromTable") %>'></asp:HiddenField>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <br />
                                                                <asp:LinkButton ID="lnkAddNew" OnClick="lnkAdd_Click" runat="server" Text="Add" ></asp:LinkButton>
                                                                <%--<asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" Text="Cancel"></asp:LinkButton>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkImport" OnClick="lnkImport_Click" runat="server" Text="VOC Emission Import" ></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnkPreviousYear"  runat="server" Text="<<" OnCommand="lnkPreviousNext_RowCommand" CommandName="PreviousYear"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkPreviousMonth"  runat="server" Text="<" OnCommand="lnkPreviousNext_RowCommand" CommandName="PreviousMonth"></asp:LinkButton>
                                                                <asp:Label runat="server" Text="Previous Next" ID="lbl"></asp:Label>
                                                                <asp:LinkButton ID="lnkNextMonth"  runat="server" Text=">" OnCommand="lnkPreviousNext_RowCommand" CommandName="NextMonth"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkNextYear"  runat="server" Text=">>" OnCommand="lnkPreviousNext_RowCommand" CommandName="NextYear"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:Panel ID="pnlVOCEdit" runat="server">
                                                    <br />
                                                    <%--<div id="dvEditVOC" runat="server">--%>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div style="display: none;">
                                                                        <%--  <asp:TextBox ID="txtVendorId" runat="server" Height="0px" Width="0px"></asp:TextBox>--%>
                                                                        <asp:TextBox ID="txtCompare" runat="server" Height="0px" Width="0px" Text="0.00"></asp:TextBox>
                                                                        <asp:TextBox ID="txtCompare2" runat="server" Height="0px" Text="0" Width="0px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Month&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="ddlMonth" Width="170px" runat="server" SkinID="dropGen">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">Year&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="ddlYear" Width="170px" runat="server" SkinID="dropGen">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Paint Category&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpPaintCategory" Width="170px" runat="server" SkinID="dropGen">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">Item Number&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtItemNumber" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Unit&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtUnit" runat="server" Width="170px" MaxLength="50" />
                                                                    <asp:CompareValidator ID="cvUnit" runat="server" ControlToValidate="txtUnit" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Enter Unit Greater Than 0." Operator="GreaterThan" ControlToCompare="txtCompare2" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                                <td align="left" valign="top">Quantity&nbsp;<span id="Span16" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtQuantity" runat="server" Width="170px" MaxLength="10" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtQuantity" ValidationExpression="(\d+)$"
                                                                        Display="none" ErrorMessage="Please Enter Valid Quantity." runat="server" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="cvQuantity" runat="server" ControlToValidate="txtQuantity" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Enter Quantity Greater Than 0." Operator="GreaterThan" ControlToCompare="txtCompare2" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Gallons&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtGallons" runat="server" Width="170px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                               <%--     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtGallons" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                                                        Display="none" ErrorMessage="Please Enter Gallons with 2 decimal places." runat="server" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CompareValidator ID="cvGallons" runat="server" ControlToValidate="txtGallons" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Enter Gallons Greater Than 0.00." Operator="GreaterThan" ControlToCompare="txtCompare" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                                <td align="left" valign="top">VOC Emissions&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtVOCEmissions" runat="server" Width="170px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtVOCEmissions" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                                                        Display="none" ErrorMessage="Please Enter VOC Emissions with 2 decimal places." runat="server" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CompareValidator ID="cvVOCEmissions" runat="server" ControlToValidate="txtVOCEmissions" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Enter VOC Emissions Greater Than 0.00." Operator="GreaterThan" ControlToCompare="txtCompare" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                   <%-- </div>--%>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlVOCView" runat="server">
                                                    <br />
                                                    <%--<div id="dvViewVOC" runat="server">--%>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top">Month&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Year&nbsp;<span id="Span20" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Paint Category&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblPaintCategory" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Item Number&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblItemNumber" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Unit&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblUnit" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">Quantity&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Gallons&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblGallon" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">VOC Emissions&nbsp;<span id="Span26" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblVOCEmissions" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--</div>--%>
                                                </asp:Panel>
                                                <div align="center">
                                                    <br />
                                                <asp:Button ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" Text="Cancel" ></asp:Button>
                                                     <br />
                                                    </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                                                        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                                                            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                                                            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
                                                        <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                                        <asp:Button ID="btnEdit" runat="server" Visible="false" Text="  Edit  " OnClick="btnEdit_Click" />
                                                        <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                            Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                                        <asp:Button ID="btnBack" runat="server" Text=" Back " OnClick="btnBack_Click" />
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
                <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
