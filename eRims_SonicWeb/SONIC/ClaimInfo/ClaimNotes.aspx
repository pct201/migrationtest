<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ClaimNotes.aspx.cs" Inherits="SONIC_ClaimNotes" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimTab/ClaimTab.ascx" TagName="CtlClaimTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
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

            obj = window.open("AuditPopup_SonicNotes.aspx?id=" + '<%=ViewState["PK_Claim_Notes"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
            var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection_SendMail.aspx?Tab=DPD&PK_Fields=' + '<%=ViewState["ClaimNoteIDs"]%>' + '&Table_Name=' + '<%=ViewState["FK_Table_Name"]%>' + '&Claim_ID=' + '<%=ViewState["FK_Claim"]%>', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(450, 300);
            return false;
        }
    </script>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        HeaderText="Please verify following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:CtlClaimTab ID="ctlTab" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="trWCHeader" style="display: none;">
            <td colspan="2" width="100%">
                <asp:UpdatePanel runat="Server" ID="updSonic_WC" UpdateMode="Always">
                    <ContentTemplate>
                        <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                            border="0">
                            <tbody>
                                <tr class="PropertyInfoBG">
                                    <td style="width: 15%" align="left">
                                        <asp:Label ID="lblHeaderClaimNumber_WC" runat="server" Text="Claim Number"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:Label ID="lblHeaderLocationdba_WC" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                    </td>
                                    <td style="width: 15%" id="tdHeaderName_WC" align="left" runat="server">
                                        <asp:Label ID="lblHeaderName_WC" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:Label ID="lblHeaderDateIncident_WC" runat="server" Text="Date of Incident"></asp:Label>
                                    </td>
                                    <td style="width: 25%" align="left">
                                        <asp:Label ID="lblHeaderAssociatedFirstReport_WC" runat="server" Text="Associated First Report"></asp:Label>
                                    </td>
                                    <td style="width: 15%" align="left">
                                        <asp:Label ID="lblHeaderInvestigation_WC" runat="server" Text="Investigation"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: white">
                                    <td align="left">
                                        <asp:Label ID="lblClaimNumber_WC" runat="server">&nbsp;</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLocationdba_WC" runat="server"></asp:Label>
                                    </td>
                                    <td id="tdName_WC" align="left" runat="Server">
                                        <asp:Label ID="lblName_WC" runat="server"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDateIncident1_WC" runat="server"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnkAssociatedFirstReport_WC" runat="server" OnClick="lnkAssociatedFirstReport_WC_Click"></asp:LinkButton>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnkInvestigation_WC" runat="server" /><asp:LinkButton ID="lnkAddInvestigation_WC"
                                            runat="server" Text="Add New" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trALHeader" style="display: none;">
            <td width="100%" colspan="2">
                <asp:UpdatePanel runat="Server" ID="updSonic_AL" UpdateMode="Always">
                    <ContentTemplate>
                        <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                            border="0">
                            <tbody>
                                <tr class="PropertyInfoBG">
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderClaimNumber_AL" runat="server" Text="Claim Number"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderLocationdba_AL" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                    </td>
                                    <td style="display: none; width: 18%" id="tdHeaderName_AL" align="left" runat="server">
                                        <asp:Label ID="lblHeaderName_AL" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderDateIncident_AL" runat="server" Text="Date of Incident"></asp:Label>
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:Label ID="lblHeaderAssociatedFirstReport_AL" runat="server" Text="Associated First Report"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: white">
                                    <td align="left">
                                        <asp:Label ID="lblClaimNumber_AL" runat="server">&nbsp; </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLocationdba_AL" runat="server"> </asp:Label>
                                    </td>
                                    <td style="display: none" id="tdName_AL" align="left" runat="Server">
                                        <asp:Label ID="lblName_AL" runat="server"> </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDateIncident_AL" runat="server"> </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnkAssociatedFirstReport_AL" runat="server" OnClick="lnkAssociatedFirstReport_AL_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trDPDHeader" style="display: none;">
            <td width="100%" colspan="2">
                <asp:UpdatePanel runat="Server" ID="updSonic_DPD" UpdateMode="Always">
                    <ContentTemplate>
                        <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                            border="0">
                            <tbody>
                                <tr class="PropertyInfoBG">
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderClaimNumber_DPD" runat="server" Text="Claim Number"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderLocationdba_DPD" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                    </td>
                                    <td style="display: none; width: 18%" id="tdHeaderName_DPD" align="left" runat="server">
                                        <asp:Label ID="lblHeaderName_DPD" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderDateLoss_DPD" runat="server" Text="Date of Loss"></asp:Label>
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:Label ID="lblHeaderAssociatedFirstReport_DPD" runat="server" Text="Associated First Report"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: white">
                                    <td align="left">
                                        <asp:Label ID="lblClaimNumber_DPD" runat="server">&nbsp;</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLocationdba_DPD" runat="server"></asp:Label>
                                    </td>
                                    <td style="display: none" id="tdName_DPD" align="left" runat="Server">
                                        <asp:Label ID="lblName_DPD" runat="server"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDateLoss_DPD" runat="server"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnkAssociatedFirstReport_DPD" runat="server" OnClick="lnkAssociatedFirstReport_DPD_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trPLHeader" style="display: none;">
            <td width="100%" colspan="2">
                <asp:UpdatePanel runat="Server" ID="updSonic_PL" UpdateMode="Always">
                    <ContentTemplate>
                        <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                            border="0">
                            <tbody>
                                <tr class="PropertyInfoBG">
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderClaimNumber_PL" runat="server" Text="Claim Number"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderLocationdba_PL" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                    </td>
                                    <td style="display: none; width: 18%" id="tdHeaderName_PL" align="left" runat="server">
                                        <asp:Label ID="lblHeaderName_PL" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderDateIncident_PL" runat="server" Text="Date of Incident"></asp:Label>
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:Label ID="lblHeaderAssociatedFirstReport_PL" runat="server" Text="Associated First Report"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: white">
                                    <td align="left">
                                        <asp:Label ID="lblClaimNumber_PL" runat="server"> &nbsp;</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLocationdba_PL" runat="server"> &nbsp;</asp:Label>
                                    </td>
                                    <td style="display: none" id="tdName_PL" align="left" runat="Server">
                                        <asp:Label ID="lblName_PL" runat="server"> &nbsp;</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDateIncident_PL" runat="server"> &nbsp;</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnkAssociatedFirstReport_PL" runat="server" OnClick="lnkAssociatedFirstReport_PL_Click"> </asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trPROPHeader" style="display: none;">
            <td width="100%" colspan="2">
                <asp:UpdatePanel runat="Server" ID="updSonic_Prop" UpdateMode="Always">
                    <ContentTemplate>
                        <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                            border="0">
                            <tbody>
                                <tr class="PropertyInfoBG">
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderClaimNumber_Prop" runat="server" Text="Claim Number"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderLocationdba_Prop" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                    </td>
                                    <td style="display: none; width: 18%" id="tdHeaderName_Prop" align="left" runat="server">
                                        <asp:Label ID="lblHeaderName_Prop" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:Label ID="lblHeaderDateLoss_Prop" runat="server" Text="Date of Loss"></asp:Label>
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:Label ID="lblHeaderAssociatedFirstReport_Prop" runat="server" Text="Associated First Report"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: white">
                                    <td align="left">
                                        <asp:Label ID="lblClaimNumber_Prop" runat="server">&nbsp; </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLocationdba_Prop" runat="server"> </asp:Label>
                                    </td>
                                    <td style="display: none" id="tdName_Prop" align="left" runat="Server">
                                        <asp:Label ID="lblName_Prop" runat="server"> </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDateIncident_Prop" runat="server"> </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnkAssociatedFirstReport_Prop" runat="server" OnClick="lnkAssociatedFirstReport_Prop_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                                        <span class="left_menu_active" style="cursor: pointer">Sonic Notes</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
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
                                        <div id="dvEdit" runat="server" width="794px" style="display: none">
                                            <div class="bandHeaderRow">
                                                Sonic Notes</div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">
                                                        Date of Note&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">
                                                        :
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
                                                    <td align="left" width="18%" valign="top">
                                                        Notes&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">
                                                        :
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <uc:ctrlMultiLineTextBox ID="txtNotes" ControlType="TextBox" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvView" runat="server" width="794px" style="display: none">
                                            <div class="bandHeaderRow">
                                                Sonic Notes</div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">
                                                        Date of Note
                                                    </td>
                                                    <td align="center" width="4%" valign="top">
                                                        :
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblNote_Date" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="18%" valign="top">
                                                        Notes
                                                    </td>
                                                    <td align="center" width="4%" valign="top">
                                                        :
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <uc:ctrlMultiLineTextBox ID="lblNotes" ControlType="Label" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvNotesList" runat="server" width="794px" style="display: none">
                                            <div class="bandHeaderRow">
                                                Sonic Notes</div>
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
                                                                                        <td width="18%" align="left" valign="top">
                                                                                            Date of Note
                                                                                        </td>
                                                                                        <td width="4%" align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            Notes
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
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
                                                    <td>
                                                        &nbsp;
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
                                                    <td>
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
