<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="CRM_NonCustomer_Resolution_Notes.aspx.cs" Inherits="SONIC_CRM_CRM_NonCustomer_Resolution_Notes"
    ValidateRequest="false" %>

<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachments/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/CRMInfo/CRMInfo_NonCustomer.ascx" TagName="Info" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript">
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
                if (index < 2) {
                    for (i = 1; i <= 1; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }

                }
                else {
                    for (i = 1; i <= 1; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }

                }
                SetFocusOnFirstControl(index)
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 2) {
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
            }
            else {
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
            }
        }

        function ValSave() {
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }


        function SetFocusOnFirstControl(index) {

            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtNotesDate').focus(); break;

                default:
                    break;
            }
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 30;
            }
            obj = window.open("AuditPopup_CRM_NonCustomer_Notes.aspx?id=" + '<%=ViewState["PK_CRM_Notes"]%>&type=res', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
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
    <asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Resolution - Resolution Grid
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="trCustomerInfo">
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
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Resolution
                                            &nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none;">*</span></span>
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
                                                    Resolution
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 100%">
                                                            <div id="divgvNotes" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 780px; height: 200px">
                                                                <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    EnableViewState="true" OnRowCommand="gvNotes_RowCommand" OnRowEditing="gvNotes_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDate" runat="server" CommandName="EditDetails" CommandArgument='<%#Eval("PK_CRM_Notes") %>'
                                                                                    Text='<%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>'
                                                                                    ToolTip="Note Date"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="75%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNote" runat="server" Text='<%#Eval("Note")%>'></asp:Label>
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
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Note&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtNotesDate" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt=" Date of Note" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotesDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <%--<asp:RequiredFieldValidator ID="revApplication" runat="server" ControlToValidate="txtNotesDate"
                                                                Display="None" ErrorMessage="Please Select Date of Note" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" />--%>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="Date of Note is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtNotesDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Resolution&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" RequiredFieldMessage="Please Enter Resolution"
                                                                ValidationGroup="vsErrorGroup" IsRequired="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Resolution</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 100%">
                                                            <div id="divgvResolutionView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 780px; height: 200px">
                                                                <asp:GridView ID="gvResolutionView" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    EnableViewState="true" OnRowCommand="gvResolutionView_RowCommand" OnRowEditing="gvResolutionView_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDate" runat="server" CommandName="View" CommandArgument='<%#Eval("PK_CRM_Notes") %>'
                                                                                    Text='<%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>'
                                                                                    ToolTip="Note Date"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="88%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNote" runat="server" Text='<%#Eval("Note")%>'></asp:Label>
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
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Note
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblNotesDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Resolution
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" />
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
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td width="100%" align="center">
                                            <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click" CausesValidation="true"
                                                ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " Visible="false" CausesValidation="false"
                                                OnClick="btnEdit_Click" />
                                            <asp:Button ID="btnViewAuditTrial" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                OnClientClick="javascript:return AuditPopUp();" />
                                            <asp:Button ID="btnRevertReturn" runat="server" Text="Revert & Return" CausesValidation="false"
                                                ValidationGroup="vsErrorGroup" OnClick="btnRevertReturn_Click" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CausesValidation="false" />
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
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
