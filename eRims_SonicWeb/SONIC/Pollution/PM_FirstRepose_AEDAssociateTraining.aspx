<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PM_FirstRepose_AEDAssociateTraining.aspx.cs" Inherits="SONIC_Pollution_PM_FirstRepose_AEDAssociateTraining" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_AED_First_Response/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" src="../../JavaScript/jquery.min.js"> </script>
    <script type="text/javascript">
        function ValSave() {
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 1; i++) {
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
                    if (!((ctrlIDs[i] == '<%=txtNotesComments.ClientID%>'))) {
                        switch (ctrl.type) {
                            case "textarea":
                            case "text":
                                if (ctrl.value == '') bEmpty = true; break;
                            case "select-one":
                                if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        }

                        if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                    }
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
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:"
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
            <td class="ghc" align="left">Occupational Health and Safety Programs – First Response and AED
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
                                    <td align="left" width="100%" nowrap="nowrap">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">First Response and AED</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
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
                                                    Associate Training for First Response and AED
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Training Required Associate Name&nbsp;<span id="Span1" style="color: Red;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAssociateName" runat="server" Width="150px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Associate Title&nbsp;<span id="Span2" style="color: Red;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAssociateTitle" runat="server" Width="150px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Training Date&nbsp;<span id="Span3" style="color: Red;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTrainingDate" runat="server" Width="150px" SkinID="txtDate" autocomplete="off" />
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTrainingDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="rfvTrainingDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Respiratory Protection]/Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtTrainingDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Notes and Comments
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="2">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotesComments" runat="server" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="3">
                                                            <b>Attachments</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <uc:ctrlAttachment ID="Attachments" runat="server" PanelNumber="1" AttachmentTable="PM_AssociateTrainingFirstRepose_AED_Attachments" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <div class="bandHeaderRow">
                                                Associate Training for First Response and AED
                                            </div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Training Required Associate Name&nbsp;<span id="Span10" style="color: Red;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblAssociateName" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Associate Title&nbsp;<span id="Span11" style="color: Red;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblAssociateTitle" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Training Date&nbsp;<span id="Span12" style="color: Red;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblTrainingDate" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" class="Spacer">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Notes and Comments
                                                    </td>
                                                    <td align="center" valign="top" width="4%">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <uc:ctrlMultiLineTextBox ID="lblNotesComments" runat="server" ControlType="Label" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <b>Attachments</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <uc:ctrlAttachment ID="AttachmentsView" runat="server" PanelNumber="1" AttachmentTable="PM_AssociateTrainingFirstRepose_AED_Attachments" />
                                                    </td>
                                                </tr>
                                            </table>
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
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
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

