<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ClaimNotesAP.aspx.cs" Inherits="ClaimNotesAP" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript">        
    </script>
    <script type="text/javascript">
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ClaimNotesAP.aspx?id=" + '<%=ViewState["PK_AP_Notes"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                    //if (bEmpty && focusCtrlID == "") {
                    //    focusCtrlID = ctrlIDs[i];
                    //    document.getElementById(ctrlIDs[i]).focus();
                    //                     };
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

        function OpenMailPopUp() {
            var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection_SendMail.aspx?Tab=APNOTES&PK_Fields=' + '<%=ViewState["ClaimNoteIDs"]%>' + '&Table_Name=' + '<%=ViewState["FK_Table_Name"]%>' + '&Claim_ID=' + '<%=ViewState["FK_Claim"]%>', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(450, 300);
            return false;
        }
    </script>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        HeaderText="Please verify following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;" colspan="2"></td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                    border="0">
                    <tbody>
                        <tr class="PropertyInfoBG">
                            <td style="width: 19%" align="left">
                                <asp:Label ID="lblHeaderLocationNumber" runat="server" Text="Location Number"></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                            </td>
                            <td style="width: 16%" align="left">
                                <asp:Label ID="lblHeaderAddress" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td style="width: 16%" align="left">
                                <asp:Label ID="lblHeaderCity" runat="server" Text="City"></asp:Label>
                            </td>
                            <td style="width: 16%" align="left">
                                <asp:Label ID="lblHeaderState" runat="server" Text="State"></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:Label ID="lblHeaderZip" runat="server" Text="Zip"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: white">
                            <td align="left">
                                <asp:Label ID="lblLocation_Number" runat="server">&nbsp;</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblState" runat="server" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblZip" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2"></td>
        </tr>
        <tr>
            <td class="ghc" align="left" colspan="2">
                <asp:Label ID="lblPanelDesc" runat="server" Text="Asset Protection – Property Security - Sonic Notes" />
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
                                        <span class="left_menu_active" style="cursor: pointer">Sonic Notes</span>&nbsp;<span
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
                                        <div id="dvEdit" runat="server" width="794px" style="display: none">
                                            <div class="bandHeaderRow">
                                                Notes
                                            </div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Date of Note&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:TextBox ID="txtNote_Date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                                        <img alt="Date of Note" onclick="return showCalendar('<%= txtNote_Date.ClientID %>', 'mm/dd/y');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                            align="middle" id="imgtxtNote_Date" />
                                                        <asp:RegularExpressionValidator ID="rvtxtNote_Date" runat="server" ControlToValidate="txtNote_Date"
                                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                            ErrorMessage="[Sonic Notes]/Date of Note is Not Valid Date." Display="none" SetFocusOnError="true">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Notes&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <uc:ctrlMultiLineTextBox ID="txtNotes" ControlType="TextBox" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvView" runat="server" width="794px" style="display: none">
                                            <div class="bandHeaderRow">
                                                Sonic Notes
                                            </div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Date of Note
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblNote_Date" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Notes
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <uc:ctrlMultiLineTextBox ID="lblNotes" ControlType="Label" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvNotesList" runat="server" width="794px" style="display: none">
                                            <div class="bandHeaderRow">
                                                Sonic Notes
                                            </div>
                                            <table cellpadding="1" cellspacing="1" width="100%">
                                                <tr>
                                                    <td width="100%">
                                                        <div style="width: 785px; height: 370px; overflow-x: hidden; overflow-y: scroll;">
                                                            <asp:Repeater ID="rptNotes" runat="server">
                                                                <ItemTemplate>
                                                                    <table cellpadding="1" cellspacing="1" width="100%">
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                                                    <tr>
                                                                                        <td width="18%" align="left" valign="top">Date of Note
                                                                                        </td>
                                                                                        <td width="4%" align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Notes
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox ID="lblNoteText" runat="server" Text='<%# Eval("Note") %>'
                                                                                                ControlType="Label" Width="540" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 30px">
                                                                            <td colspan="2" style="vertical-align: middle;">
                                                                                <hr size="1" color="Black" style="width: 758px;" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnPrintSelectedNotes" runat="server" Text=" Print " OnClick="btnPrintSelectedNotes_Click"
                                                            CausesValidation="false" />&nbsp;
                                                        <asp:Button ID="btnCancel" runat="server" Text=" Return " OnClick="btnRevert_Click"
                                                            CausesValidation="false" />&nbsp;
                                                        <asp:Button ID="btnMail" runat="server" Text=" Mail " OnClientClick="return OpenMailPopUp();"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trButtons" runat="server">
                        <td align="center" colspan="2">
                            <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                <tr align="center" id="trSave">
                                    <td align="right" style="width: 50%">
                                        <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                            ValidationGroup="vsErrorGroup" CausesValidation="true" />
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Style="margin-left: 0px"
                                            Width="51px" Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnLAAudit_View" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                            ToolTip="View Audit Trail" CausesValidation="false" />
                                    </td>
                                    <td align="left" style="width: 50%">
                                        <asp:Button ID="btnRevert" runat="server" Text="Revert and Return" OnClick="btnRevert_Click"
                                            CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
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


