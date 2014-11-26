<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PurchasingAssetNote.aspx.cs"
    Inherits="SONIC_Purchasing_PurchasingAssetNote" %>

<%@ Register Src="../../Controls/SONIC_Purchasing/PurchasingAsset.ascx" TagName="PurchasingAsset"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">
        //Open Audit Popup
        function AssestNoteAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_PurchasingAssetNote.aspx?id=" + '<%=ViewState["PK_Purchasing_Asset_Notes"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function checkNotes() {
            var txt = document.getElementById("ctl00_ContentPlaceHolder1_txtNote_txtNote");
            if (txt.value.length > 0) {
                return true;
            }
            else {
                alert("Please Enter Note.");
                return false;
            }
        }

        function SetMenuStyle(index) {

            var i;
            for (i = 1; i <= 1; i++) {

                var tb = document.getElementById("Menu");
                if (tb != null) {
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
        }

        function ShowPanelNew(index) {
            if (index == 1) {
                document.getElementById("<%=pnlAssetNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                document.getElementById('<%=divsaveView.ClientID%>').style.display = "none";
            }
        }

        function ShowPanel(index) {

            SetMenuStyle(index);

            var op = '<%=strOperation%>';
            if (op == "view") {
                document.getElementById("<%=dvSave.ClientID %>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                if (index == 1) {
                    document.getElementById("<%=pnlAssetNotes.ClientID%>").style.display = "block";
                    document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                    document.getElementById('<%=divsaveView.ClientID%>').style.display = "none";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            document.getElementById('<%=divsaveView.ClientID%>').style.display = "block";
            if (index == 1) {
                document.getElementById("<%=pnlNotesView.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAssetNotes.ClientID%>").style.display = "none";
            }
        }

        function RedirectTo(index) {
            if (index == 1)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Purchasing/PurchasingSearch.aspx';
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
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
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
            else {
                args.IsValid = true;
            }
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" valign="bottom" colspan="2">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="tab1" class="tab" onclick="RedirectTo(1)">
                            Search
                        </td>
                        <td id="tab2" class="tabSelected">
                            Purchasing
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 19px">
                <uc1:PurchasingAsset ID="PurchasingAssetTab" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="groupHeaderBar" align="left" colspan="2">
                <asp:Label ID="lblTitle" runat="server" Text="Asset-Notes" CssClass="heading"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="leftMenu">
                <table cellpadding="0" cellspacing="0" width="203px">
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Notes" class="LeftMenuSelected">Notes&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer">
                            <div id="dvEdit" runat="server" width="794px">
                                <asp:Panel ID="pnlAssetNotes" runat="server" Style="display: block;">
                                    <div class="bandHeaderRow" id="assetheading" runat="server">
                                        Asset - Notes</div>
                                    <table width="100%" cellpadding="3" cellspacing="1" border="0">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note Date&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td width="4%" align="center">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <asp:TextBox runat="server" ID="txtNoteDate" SkinID="txtDate"></asp:TextBox>
                                                <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNoteDate', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                    align="middle" /><br />
                                                <asp:RangeValidator ID="revDate" ControlToValidate="txtNoteDate" MinimumValue="01/01/1753"
                                                    MaximumValue="12/31/9999" Type="Date" ErrorMessage="Note Date is not valid."
                                                    runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                                                <%--<asp:RequiredFieldValidator ID="rfvNoteSubject" runat="server" Display="None" ErrorMessage="Please select date"
                                                    ValidationGroup="vsErrorGroup" ControlToValidate="txtNoteDate" SetFocusOnError="true" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td width="4%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <uc:ctrlMultiLineTextBox ID="txtNote" Width="600" runat="server" IsRequired="false"
                                                    RequiredFieldMessage="Please Enter Notes" ValidationGroup="vsErrorGroup" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <div id="dvView" runat="server" width="794px">
                                <asp:Panel ID="pnlNotesView" runat="server" Style="display: block;">
                                    <div class="bandHeaderRow">
                                        Asset Notes - Grid</div>
                                    <table width="100%" cellpadding="3" cellspacing="1" border="0">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note Date
                                            </td>
                                            <td width="4%" align="center">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <asp:Label ID="lblNotesDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note
                                            </td>
                                            <td width="4%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <uc:ctrlMultiLineTextBox ID="lblNotes" ControlType="Label" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer">
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
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="40%" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSaveAndView_Click"
                                    ValidationGroup="vsErrorGroup" CausesValidation="true" />
                                &nbsp;<asp:Button runat="server" ID="btnAssetNotesAudit" Text="View Audit Trail"
                                    OnClientClick="javascript:return AssestNoteAuditPopUp();" ToolTip="View Audit Trail"
                                    CausesValidation="false" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divsaveView" runat="server">
                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" OnClick="btnBack_Click" />
                                &nbsp;&nbsp;<asp:Button runat="server" ID="btnAssetNotesAudit_View" Text="View Audit Trail"
                                    OnClientClick="javascript:return AssestNoteAuditPopUp();" ToolTip="View Audit Trail"
                                    CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
