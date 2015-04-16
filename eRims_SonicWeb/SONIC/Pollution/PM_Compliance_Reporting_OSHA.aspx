﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PM_Compliance_Reporting_OSHA.aspx.cs" Inherits="SONIC_Pollution_PM_Compliance_Reporting_OSHA" %>

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
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
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

        function numberOnly(e) {
            var k;
            if (window.event) {
                k = event.keyCode;
            }
            else {
                k = e.which;
            }
            if (k == 8) {
                return true;
            }
            if ((k <= 47) || (k >= 58)) {
                if (window.event) {
                    window.event.returnValue = null;
                    return false;
                }
                else {
                    e.preventDefault();
                }
            }
            if (k == 8)
            { }
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
                    if (index == 1)
                        document.getElementById('<%=txtDateCompleted.ClientID %>').focus();
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
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Compliance_Reporting_OSHA.aspx?id=<%=ViewState["PK_PM_Compliance_Reporting_OSHA"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                    
                    if(ctrl != null)
                    {
                        switch (ctrl.type)
                        {
                            case "textarea": if (ctrl.value == '') bEmpty = true; break;
                            case "text": if (ctrl.value == '') bEmpty = true; break;
                            case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                            case undefined:
                                if (ctrl.tagName == "TABLE") {
                                    var rdbtnLstValues = ctrl.getElementsByTagName("input");
                                    var Checkdvalue;
                                    for (var j = 0; j < rdbtnLstValues.length; j++) {
                                        if (rdbtnLstValues[j].checked) {
                                            Checkdvalue = rdbtnLstValues[j];
                                            break;
                                        }
                                    }
                                    if (!Checkdvalue) {
                                        bEmpty = true;
                                    }
                                };
                                break;
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
    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;"></td>
        </tr>
        <tr>
            <td width="100%">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">OSHA Log Grid Screen
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">OSHA Log</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
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
                                                <div class="bandHeaderRow">
                                                    OSHA Log
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date Completed&nbsp;<span id="spnDateCompleted" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDateCompleted" Width="175px" runat="server" SkinID="txtDate">
                                                            </asp:TextBox>
                                                            <img alt="Date Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateCompleted', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[OSHA Log]/Date Completed is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDateCompleted" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Log Posted By February 1st?&nbsp;<span id="spnLogPosted" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoLogPosted" runat="server" SkinID="YNTypeNullSelection" AutoPostBack="true" OnSelectedIndexChanged="rdoLogPosted_SelectedIndexChanged">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="divExplain">
                                                        <td align="left" valign="top">Explain why the OSHA Log was not posted by Feb 1st&nbsp;<span id="spnExplainReason" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:</td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtExplainOsha" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Number of OSHA Recordable Incidents&nbsp;<span id="spnNumberofOsha" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNumberofOsha" runat="server" Width="170px" onkeypress="return numberOnly(event);" autocomplete="off"
                                                                MaxLength="6" onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">Number of Lost Work Days&nbsp;<span id="spnNumberofLostWorkDays" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNumberofLostWorkDays" runat="server" Width="170px" onkeypress="return numberOnly(event);" autocomplete="off"
                                                                MaxLength="6" onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Number of Restricted Work Days&nbsp;<span id="spnNumberofRestrictedWorkDays" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNumberofRestrictedWorkDays" runat="server" Width="170px" onkeypress="return numberOnly(event);" autocomplete="off"
                                                                MaxLength="6" onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">Total Number of Associates&nbsp;<span id="spnTotalNumberofAssociates" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTotalNumberofAssociates" runat="server" Width="170px" onkeypress="return numberOnly(event);" autocomplete="off"
                                                                MaxLength="6" onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="left" valign="top">
                                                            SIC Code&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtSIC" runat="server" Width="150px" ReadOnly="true" />                                                            
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:Label ID="lblSIC" runat="server" />                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="spnComments" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
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
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    OSHA Log
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date Completed
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDateCompleted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Log Posted By February 1st?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblLogPosted" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="viewExplain" runat="server">
                                                        <td align="left" valign="top">Explain why the OSHA Log was not posted by Feb 1st
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblExplainOsha" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Number of OSHA Recordable Incidents
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumberofOshaRecordableIncidents" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Number of Lost Work Days
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumberofLostWorkDays" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Number of Restricted Work Days
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumberofRestrictedWorkDays" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Total Number of Associates
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTotalNumberofAssociates" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="left" valign="top">
                                                            SIC Code&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblvwSICCode" runat="server" Width="150px" ReadOnly="true" SkinID="txtDisabled" />                                                            
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:Label ID="lblvwSICDesc" runat="server" />                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">&nbsp;
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
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
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
