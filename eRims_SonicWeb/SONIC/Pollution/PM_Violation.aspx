﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PM_Violation.aspx.cs" Inherits="SONIC_Pollution_PM_Violation" %>

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
                    }
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                }
                if (index == 2)
                    document.getElementById("ctl00_ContentPlaceHolder1_Attachment_txtAttachDesc_txtNote").focus();
                else
                    document.getElementById('<%=txtDate_Of_Violation.ClientID%>').focus();
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
                    }
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                    }
                }
            }
            catch (e) { }
        }

        function ValSave() {
            //        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            //        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Violation.aspx?id=<%=ViewState["PK_PM_Violation"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab">
                </uc:CtlTab>
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
                Violations
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Violations</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
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
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Violations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date Of Violation&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Of_Violation" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Of Violation" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Violation', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Of_Violation" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Violations]/Date Of Violation is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Of_Violation" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Regulatory/Notifying Agency&nbsp;<span id="Span2" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpRegulatory_Notifying_Agency" runat="server" SkinID="dropGen"
                                                                Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            If Other, Please Specify
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOtherAgency" runat="server" Width="170px" MaxLength="35" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contact Name&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtContact_Name" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span4" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtContact_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ErrorMessage="Please Enter Valid [Violations]/Telephone"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtContact_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="None" SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Is this a Repeat Violation?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbRepeatViolation" runat="server" SkinID="YesNoType">
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
                                                        <td align="left" valign="top">
                                                            Fine&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtCost" runat="server" Width="160px" onkeypress="return FormatNumber(event,this.id,13,false);"
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
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Remediation Cost&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtRemediationCost" runat="server" Width="160px" onkeypress="return FormatNumber(event,this.id,13,false);"
                                                                onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Purchase of New Equipment&nbsp;<span id="Span7" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtPurchaseNewEquipment" runat="server" Width="160px" onkeypress="return FormatNumber(event,this.id,13,false);"
                                                                onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Consulting Fees&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtConsultingFee" runat="server" Width="160px" onkeypress="return FormatNumber(event,this.id,13,false);"
                                                                onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Attorney Fees&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtAttorneyFee" runat="server" Width="160px" onkeypress="return FormatNumber(event,this.id,13,false);"
                                                                onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Additional costs&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtAdditional_Costs" runat="server" Width="160px" onkeypress="return FormatNumber(event,this.id,13,false);"
                                                                onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Describe What Additional Costs relate to&nbsp;<span id="Span11" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAdditional_Costs_Description" runat="server" Width="170px" MaxLength="100"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Description of Violation(s)&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDescription_Of_Violations" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Does this Violation data apply to all buildings at this location?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
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
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Violations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date Of Violation
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDate_Of_Violation" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                           
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                           
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Regulatory/Notifying Agency
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRegulatory_Notifying_Agency" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                           If Other, Please Specify
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOtherAgency" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContact_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContact_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Is this a Repeat Violation?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRepeatViolation" runat="server"></asp:Label>
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
                                                            Fine
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCost" runat="server"></asp:Label>
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
                                                            Remediation Cost
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRemediationCost" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Purchase of New Equipment
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPurchaseofNewEquipment" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Consulting Fees
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblConsultingFees" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Attorney Fees
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAttrneyFees" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Additional Costs
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAdditional_Costs" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Describe What Additional Costs relate to
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAdditional_Costs_Description" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Description of Violation(s)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDescription_Of_Violations" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Does this Violation data apply to all buildings at this location?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
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
                        <td>
                            &nbsp;
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
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                        </td>
                                        <td align="left">
                                            &nbsp;
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
