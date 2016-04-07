<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" MasterPageFile="~/Default.master" CodeFile="ClaimSummary.aspx.cs" Inherits="SONIC_Sedgwick_ClaimSummary" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBoxWithSpellCheck"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Sedgwick/Attachment.ascx" TagName="ctrlAttachment" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Sedgwick/Attachment_Detail.ascx" TagName="ctrlAttachmentDetail"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var CheckChangeVal = false;
        var currIndex = 1;

        function CheckValueChange(Panelid, IndexVal) {
            if (CheckChangeVal == true) {
                if (confirm('Do you want to save your changes before leaving this screen?')) {
                    CheckChangeVal = false;
                }
                else {
                    CheckChangeVal = false;
                    if (Panelid != null)
                        ShowPanel(Panelid);
                    if (IndexVal != null)
                        ShowPrevNext(IndexVal);
                }
            }
            else {
                if (Panelid != null)
                    ShowPanel(Panelid);
                if (IndexVal != null)
                    ShowPrevNext(IndexVal);
            }
        }

        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 11) {
                ActiveTabIndex = 1;
                ShowPanel(ActiveTabIndex);
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
            currIndex = index;
            SetMenuStyle(index);
            ActiveTabIndex = index;
            if (ActiveTabIndex == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
            else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "";

            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            if (index == 1) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 2) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 3) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 4) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 5) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 6) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 7) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 8) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 9) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 10) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "none";
            }
            if (index == 11) {
                document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlInvestigation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSubrogation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlDisability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClosurePlans.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlReserves.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLeadership.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachments.ClientID%>").style.display = "block";
            }
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 11; i++) {
                var tb = document.getElementById("WCMenu" + i);
                if (i == index) {
                    tb.className = "C_LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuSelected'; }
                }
                else {
                    tb.className = "C_LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuStatic'; }
                }

            }
        }

        function CheckIsSaveRecord() {
            var hdnIsSave = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsSave");
            if (hdnIsSave.value != null) {
                if (hdnIsSave.value == "False") {
                    if (confirm('This Claim Review Worksheet has not been saved, would you like to save it before returning to the Claim Review Worksheet Group?')) {
                        if (SetValidationGroup() == false)
                            return false;
                        document.getElementById("ctl00_ContentPlaceHolder1_hdnIsSave").value = "true";
                        //return true;
                    }
                    return true;
                }
            }
        }

        function OpenActionItemPopup(txtID) {
            var winHeight = window.screen.availHeight - 850;
            var winWidth = window.screen.availWidth - 1200;

            obj = window.open("PopUpForActionItem.aspx?txtID=" + txtID, 'ActionItemPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function AuditPopUpMeeting() {
            var winHeight = window.screen.availHeight - 380;
            var winWidth = window.screen.availWidth - 390;

            var ID = '<%=ViewState["PK_Sedgwick_Claim_Review"]%>';
            obj = window.open("../Sedgwick/AuditPopup_Sedgwick_Claim_Review_Audit.aspx?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');

            return false;
        }
    </script>
    <div>
        <%--<asp:ValidationSummary ID="valWCClaim" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsWCClaimGroup" CssClass="errormessage"></asp:ValidationSummary>--%>
    </div>
    <div style="width: 100%;">
        <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid; text-align: left;">
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <div style="width: 100%;">
        <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid; text-align: left;">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="leftMenu" valign="top">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="height: 18px;" class="Spacer">
                                <asp:HiddenField ID="hdnIsSave" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td><span id="WCMenu1" onclick="javascript:CheckValueChange(1,null);">Claim Summary</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu2" href="#" onclick="javascript:CheckValueChange(2,null);">Claim
											Review</span>&nbsp;<span id="Span70" runat="server" style="color: Red; display: none">*</span></td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu3" href="#" onclick="javascript:CheckValueChange(3,null);">Investigation</span>&nbsp;
                                            <span id="Span71" runat="server" style="color: Red; display: none">*</span></td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu4" href="#" onclick="javascript:CheckValueChange(4,null);">Subrogation</span>&nbsp;
                                            <span id="Span72" runat="server" style="color: Red; display: none">*</span></td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu5" href="#" onclick="javascript:CheckValueChange(5,null);">Medical</span>&nbsp; 
                                            <span id="Span73" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu6" href="#" onclick="javascript:CheckValueChange(6,null);">Disability</span>&nbsp; 
                                            <span id="Span74" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu7" href="#" onclick="javascript:CheckValueChange(7,null);">Closure Plan</span>&nbsp; 
                                            <span id="Span75" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu8" href="#" onclick="javascript:CheckValueChange(8,null);">Reserves</span>&nbsp; 
                                            <span id="Span76" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu9" href="#" onclick="javascript:CheckValueChange(9,null);">Leadership</span>&nbsp; 
                                            <span id="Span77" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu10" href="#" onclick="javascript:CheckValueChange(10,null);">Review Scorecard</span>&nbsp; 
                                            <span id="Span78" runat="server" style="color: Red; display: none">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><span id="WCMenu11" href="#" onclick="javascript:CheckValueChange(11,null);">Attachments</span>&nbsp; </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;" class="Spacer"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblSubmitMessage" SkinID="lblError"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td width="5px">&nbsp; </td>
                            <td width="794px" valign="top" class="dvContainer" style="height: 205px;">
                                <div id="dvView" runat="server" style="width: 100%;">
                                    <asp:Panel ID="pnlClaimSummary" runat="server" Width="100%">
                                        <table width="100%" style="text-align: left;">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Claim Summary
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" style="width: 23%;">FROI Number&nbsp;<span id="Span9" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" style="width: 2%;">: </td>
                                                <td class="ic" style="width: 25%;"><a id="lblFROINumber" runat="server"></a>
                                                    <%--<asp:Label ID="lblFROINumber" runat="server"></asp:Label>--%>
                                                </td>
                                                <td class="lc" style="width: 23%;">Claim Number&nbsp;<span id="Span10" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" style="width: 2%;">: </td>
                                                <td class="ic" style="width: 25%;"><a id="ahrefClaimnumber" runat="server"></a>
                                                    <%--<asp:Label ID="lblClaimNumber" runat="server"></asp:Label>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" style="width: 23%;">Investigation Id&nbsp;<span id="Span25" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" style="width: 2%;">: </td>
                                                <td class="ic" style="width: 25%;"><a id="lblnvestigationID" runat="server"></a>
                                                    <%--<asp:Label ID="lblnvestigationID" runat="server"></asp:Label>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Location Information </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Location Number&nbsp;<span id="Span11" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtLocationNumber" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Location d/b/a&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtLocationDBA" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Associate Information </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Name&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox runat="server" ID="txtName" MaxLength="75" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Date of Birth&nbsp;<span id="Span14" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDtOfBirth" runat="server" SkinID="txtDate" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Age&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtAge" runat="server" SkinID="txtDate" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Date of Hire&nbsp;<span id="Span16" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateOfHire" runat="server" onkeypress="return numberOnly(event);"
                                                        MaxLength="4" Enabled="false"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revPolYear" runat="server" ControlToValidate="txtDateOfHire"
                                                        Display="none" SetFocusOnError="true" ErrorMessage="Policy Year is Invalid."
                                                        ValidationExpression="[\d]{4}" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                                <td class="lc">Job Title&nbsp;<span id="Span17" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtJobTitle" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Employment Status&nbsp;<span id="Span18" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtEmployementStatus" SkinID="txtAmt" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Incident Information </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Date of Incident&nbsp;<span id="Span19" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateOfIncident" SkinID="txtAmt" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Time of Incident&nbsp;<span id="Span20" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtTimeOfIncident" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Filing State&nbsp;<span id="Span21" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtFillingState" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Reported to Sonic&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateReportedToSonic" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Description of Incident&nbsp;<span id="Span23" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtDescOfIncident" ControlType="TextBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Department Where Injury Occurred&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDeptWhereInjuryOccured" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Nature of Injury&nbsp;<span id="Span26" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtNatureOfInjury" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Body Part Affected&nbsp;<span id="Span27" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtBodyPartAffected" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Was the Claim Questionable&nbsp;<span id="Span28" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:RadioButtonList ID="rdbClaimQuestionable" runat="server" Enabled="false">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">If Yes, Why?&nbsp;<span id="Span29" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtIfYesWhy" ControlType="TextBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Initial Medical </td>
                                            </tr>
                                            <tr>
                                                <td class="lc">Was Telephone Nurse Consultation Used?&nbsp;<span id="Span30" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:RadioButtonList ID="rdbTelConsultnUsed" runat="server" Enabled="false">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Describe Initial Treatment&nbsp;<span id="Span31" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtDescTretment" ControlType="TextBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Comments </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Initial Claim Classification&nbsp;<span id="Span32" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <asp:TextBox ID="txtInitialClaimClassifictn" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Comments/Special Instructions to Adjuster&nbsp;<span
                                                    id="Span33" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblComments" ControlType="TextBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Investigation </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" style="width: 23%;">Sonic Cause Code&nbsp;<span id="Span34" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" style="width: 2%;">: </td>
                                                <td class="ic" style="width: 25%;">
                                                    <asp:Label ID="lblSonicCauseCode" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: bold;">Return To Work </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Effective Date&nbsp;<span id="Span35" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <asp:TextBox ID="txtEffectiveDate" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Work Status Type&nbsp;<span id="Span36" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtWorkStatusType" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Authorized off work?&nbsp;<span id="Span37" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:RadioButtonList ID="rdbAuthorizesOffWork" runat="server" Enabled="false">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Date Last Worked&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateLastWorked" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Last Worked Aas a Full Day?&nbsp;<span id="Span39" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateLastWorkedAsFullDay" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Date Examiner Anticipates Return to Work Full Duty&nbsp;<span
                                                    id="Span40" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateExaminerReturnToWorkFullDay" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Examiner Anticipates Return to Work Restrictive Duty&nbsp;<span
                                                    id="Span41" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateExaminerReturnToWorkResDuty" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Date Case Manager Anticipates Return to Work Full Duty&nbsp;<span
                                                    id="Span42" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateCaseMngrToFullDay" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Case Manager Anticipates Return to Work Restrictive Duty&nbsp;<span
                                                    id="Span43" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateCaseMgrToResDuty" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Date Physician Anticipates Return to Work Full Duty&nbsp;<span
                                                    id="Span44" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDatePhysicianAnticipateToFullDay" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Physician Anticipates Return to Work Restrictive Duty&nbsp;<span
                                                    id="Span45" style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDatePhysicianAnticipateToResDuty" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Moderate Duty Available?&nbsp;<span id="Span46" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:RadioButtonList ID="rdbModerateDutyAvail" runat="server" Enabled="false">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td class="lc">Date Modified Duty Available&nbsp;<span id="Span47" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateModifiedDutyAvail" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Moderate Duty Offered?&nbsp;<span id="Span48" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtModerateDutyOffered" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Moderate Duty Offered&nbsp;<span id="Span49" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateModerateDutyOffered" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Moderate Duty Accepted?&nbsp;<span id="Span50" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtModerateDutyAccepted" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Date Moderate Duty Accepted&nbsp;<span id="Span51" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtDateModerateDutyACcepted" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Modified Duty Occupation&nbsp;<span id="Span52" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtModifiedDutyOccupation" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Modified Duty Demand&nbsp;<span id="Span53" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtModifiedDutyDemand" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Date Notified&nbsp;<span id="Span54" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <asp:TextBox ID="txtDateNotified" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Full Days Worked on Modified Duty?&nbsp;<span id="Span55"
                                                    style="color: Red; display: none;" runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">&nbsp; </td>
                                                <td class="lc">Hours Worked on Modified Duty&nbsp;<span id="Span56" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtHoursWorkedonModifiedDuty" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Return to Work Occupation&nbsp;<span id="Span57" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtReturnToWorkOccup" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Return to Work Demand&nbsp;<span id="Span58" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtReturnToWorkDemand" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Return to Work Schedule&nbsp;<span id="Span59" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <asp:TextBox ID="txtReturnToWorkSchedule" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Date Disability Began&nbsp;<span id="Span60" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <asp:TextBox ID="txtDateDisabilityBegan" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Number of Lost Time Days&nbsp;<span id="Span61" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtNumberOfLostTimeDays" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td class="lc">Number of Restricted Work Days&nbsp;<span id="Span62" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc">: </td>
                                                <td class="ic">
                                                    <asp:TextBox ID="txtNoOfRestWorkDays" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" valign="top">Reason for Termination&nbsp;<span id="Span63" style="color: Red; display: none;"
                                                    runat="server">*</span> </td>
                                                <td class="lc" valign="top">: </td>
                                                <td class="ic" colspan="4">
                                                    <asp:TextBox ID="txtReasonForTermination" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="6" style="font-weight: bold;">Risk Management Worksheet </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top">&nbsp; </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Indemnity </td>
                                                            <td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Medical </td>
                                                            <td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Expenses </td>
                                                            <td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Total </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Reserve </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtResIndemnity" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtResMedical" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtResExpense" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtResTotal" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Paid </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtPaidIndemnity" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtPaidMedical" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtPaidExpense" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtPaidTotal" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Outstanding </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtOSIndemnity" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtOSMedical" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtOSExpense" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtOSTotal" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%--<tr>
							<td align="center" colspan="6">
								<asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
									OnClick="btnSave_Click" />
								<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
							</td>
						</tr>--%>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlClaimReviewWorksheet" runat="server" Width="100%">
                                        <asp:UpdatePanel runat="Server" ID="updClaimReviewWorksheet" UpdateMode="Always">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                        <td colspan="100%">Claim Review Worksheet – Claim Review
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">Claim Number&nbsp; </td>
                                                        <td width="4%" align="center">: </td>
                                                        <td width="26%">
                                                            <asp:Label ID="lblCalimNUmber_Review" runat="server"></asp:Label>
                                                        </td>
                                                        <td width="20%">Associate Name&nbsp;<span id="Span64" style="color: Red; display: none;" runat="server">*</span> </td>
                                                        <td width="4%" align="center">: </td>
                                                        <td width="26%">
                                                            <asp:TextBox ID="txtAssociateName" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">Location d/b/a&nbsp; </td>
                                                        <td valign="top" align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLocationDBA_Review" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td>Date of Injury&nbsp; </td>
                                                        <td align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDateOfInjury" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">Job Title&nbsp; </td>
                                                        <td valign="top" align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtJobTitle_Review" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td valign="top">Date of Last Review&nbsp;<span id="Span69" style="color: Red; display: none" runat="server">*</span> </td>
                                                        <td valign="top" align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDateOfLastReview" runat="server" SkinID="txtDate"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="calDateOfLastReview" runat="server" Format="MM/dd/yyyy"
                                                                TargetControlID="txtDateOfLastReview">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">Sedgwick Field Office&nbsp; </td>
                                                        <td valign="top" align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSedgwickFieldOffice" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">Adjuster&nbsp;<span id="Span65" style="color: Red; display: none" runat="server">*</span></td>
                                                        <td valign="top" align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAdjuster" runat="server" MaxLength="100"></asp:TextBox>
                                                            <%-- <asp:RequiredFieldValidator ID="rfvtxtAdjuster" runat="server" ControlToValidate="txtAdjuster"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" ErrorMessage="Please enter Adjuster"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td>Sedgwick Team Leader&nbsp;<span id="Span66" style="color: Red; display: none" runat="server">*</span></td>
                                                        <td align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSedgwickTeamLeader" runat="server" MaxLength="100"></asp:TextBox>
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSedgwickTeamLeader"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" ErrorMessage="Please enter Sedgwick Team Leader"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">Date of File Review&nbsp;<span id="Span67" style="color: Red; display: none" runat="server">*</span> </td>
                                                        <td valign="top" align="center">: </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDateOfFileReview" runat="server" SkinID="txtDate"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="calDateOfFileReview" runat="server" Format="MM/dd/yyyy"
                                                                TargetControlID="txtDateOfFileReview">
                                                            </cc1:CalendarExtender>
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateOfFileReview"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" ErrorMessage="Please enter Date of File Review"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td colspan="6" style="font-weight: bold;">Related Claim Information</td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="20%">Law Suit Y/N
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td width="26%">
                                                                        <asp:Label ID="lblLawSuitYN" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">Claimant Attorney/Representative Y/N
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td width="26%">
                                                                        <asp:Label ID="lblClaimantAttorneyRepresentativeYN" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Date Disability Began
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDisabilityBegan" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">Date Return to Work
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDate_Return_To_Work" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Date of Maximum Medical Improvement
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDate_of_Max_Medical_Improvement" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Cause of Injury Code
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCauseofInjuryCode" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Nature of Injury Code
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblNatureofInjuryCode" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Part of Body Code
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPartofBodyCode" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Employment Status
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblEmploymentStatus" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Adjustor Code
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAdjustorCode" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" style="font-weight: bold;">Claim Status Denial Information</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Processing Office&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblProcessingOffice" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Status Change Date&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStatusChangeDate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Status&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Sub Status&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSubStatus" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Sub Status Reason for Denial or Termination Code&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReason1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Sub Status Reason for Denial or Termination Code 2&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReason2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Sub Status Reason for Denial or Termination Code 3&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReason3" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>Sub Status Reason for Denial or Termination Code 4&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReason4" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Sub Status Reason for Denial or Termination Code 5&nbsp;
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReason5" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </asp:Panel>
                                    <asp:Panel ID="pnlInvestigation" runat="server" Width="100%">
                                        <%--  <asp:GridView ID="gvMgtSection" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                            Width="100%" OnRowDataBound="gvMgtSection_OnRowDataBound" OnRowCommand="gvMgtSection_RowCommand"
                                            SkinID="none" CellPadding="0" CellSpacing="0">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="false">
                                                    <ItemTemplate>--%>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Investigation</i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_Investigation" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_Investigation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_Investigation" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_Investigation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_Investigation" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_Investigation" runat="server" Value="Investigation" />
                                                    <asp:Label ID="lblMgtSection_Investigation" runat="server" Text="Investigation"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_Investigation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblAdjusterNoteDate" runat="server" >Date</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblAdjusterNotes" ControlType="Label" />
                                                             <asp:Label id="hdnAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_Investigation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
                                                                    </cc1:CalendarExtender>--%>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_Investigation" runat="server" Text="Investigation Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_MedicalScoring_Investigation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_Investigation" runat="server" Text="RLCM Investigation Score"></asp:Label>&nbsp;<span id="Span3" style="color: Red; display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_Medical_Score_Investigation" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRLCM_Medical_Score_Investigation"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Investigation Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--</ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>--%>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlSubrogation" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Subrogation </i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_Subrogation" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_Subrogation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_Subrogation" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_Subrogation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_Subrogation" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_Subrogation" runat="server" Value="Subrogation" />
                                                    <asp:Label ID="lblMgtSection_Subrogation" runat="server" Text="Subrogation"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_Subrogation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblSubAdjusterDate" runat="server">Date</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblSubAdjusterNotes" ControlType="Label" />
                                                             <asp:Label id="hdnSubAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_Subrogation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
                                                                    </cc1:CalendarExtender>--%>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_Subrogation" runat="server" Text="Subrogation Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_MedicalScoring_Subrogation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_Subrogation" runat="server" Text="RLCM Subrogation Score"></asp:Label>&nbsp;<span id="Span4" style="color: Red; Display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_Medical_Score_Subrogation" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRLCM_Medical_Score_Subrogation"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Subrogation Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlMedical" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Medical </i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_Medical" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_Medical" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_Medical" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_Medical" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_Medical" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_Medical" runat="server" Value="Medical" />
                                                    <asp:Label ID="lblMgtSection_Medical" runat="server" Text="Medical"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_Medical" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblMedicalAdjusterDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblMedicalAdjusterNotes" ControlType="Label" />
                                                         <asp:Label id="hdnMedicalAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_Medical" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
                                                                    </cc1:CalendarExtender>--%>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_Medical" runat="server" Text="Medical Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_MedicalScoring_Medical" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_Medical" runat="server" Text="RLCM Medical Score"></asp:Label>&nbsp;<span id="Span5" style="color: Red; display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_Medical_Score_Medical" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlRLCM_Medical_Score_Medical"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Medical Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDisability" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Disability </i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_Disability" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_Disability" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_Disability" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_Disability" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_Disability" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_Disability" runat="server" Value="Disability" />
                                                    <asp:Label ID="lblMgtSection_Disability" runat="server" Text="Disability"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_Disability" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblDisAdjusterDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblDisAdjusterNotes" ControlType="Label" />
                                                         <asp:Label id="hdnDisAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_Disability" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_Disability" runat="server" Text="Disability Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_DisabilityScoring_Disability" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_Disability" runat="server" Text="RLCM Disability Score"></asp:Label>&nbsp;<span id="Span6" style="color: Red; display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_Disability_Score_Disability" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlRLCM_Disability_Score_Disability"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Disability Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlClosurePlans" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Closure Plan </i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_ClosurePlans" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_ClosurePlans" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_ClosurePlans" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_ClosurePlans" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_ClosurePlans" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_ClosurePlans" runat="server" Value="Closure Plan" />
                                                    <asp:Label ID="lblMgtSection_ClosurePlans" runat="server" Text="Closure Plan"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_ClosurePlans" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblClosureAdjusterDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblClosureAdjusterNotes" ControlType="Label" />
                                                         <asp:Label id="hdnClosureAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_ClosurePlans" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
                                                                    </cc1:CalendarExtender>--%>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_ClosurePlans" runat="server" Text="Closure Plan Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_ClosurePlansScoring_ClosurePlans" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_ClosurePlans" runat="server" Text="RLCM Closure Plan Score"></asp:Label>&nbsp;<span id="Span7" style="color: Red; Display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_ClosurePlans_Score_ClosurePlans" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRLCM_ClosurePlans_Score_ClosurePlans"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Closure Plan Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlReserves" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Reserves </i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_Reserves" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_Reserves" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_Reserves" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_Reserves" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_Reserves" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="6" style="font-weight: bold;">Reserves and Payment </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top">&nbsp; </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Indemnity </td>
                                                            <td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Medical </td>
                                                            <td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Expenses </td>
                                                            <td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Total </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Reserve </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtResIndemnity_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtResMedical_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtResExpense_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtResTotal_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Paid </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtPaidIndemnity_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtPaidMedical_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtPaidExpense_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtPaidTotal_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma; font-size: 10pt;">Outstanding </td>
                                                            <td class="lc" valign="top"></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtOSIndemnity_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtOSMedical_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtOSExpense_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:TextBox ID="txtOSTotal_Review" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_Reserves" runat="server" Value="Reserves" />
                                                    <asp:Label ID="lblMgtSection_Reserves" runat="server" Text="Reserves"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_Reserves" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblReservesAdjusterDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblReservesAdjusterNotes" ControlType="Label" />
                                                         <asp:Label id="hdnReservesAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_Reserves" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
                                                                    </cc1:CalendarExtender>--%>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_Reserves" runat="server" Text="Reserves Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_ReservesScoring_Reserves" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_Reserves" runat="server" Text="RLCM Reserves Score"></asp:Label>&nbsp;<span id="Span8" style="color: Red; display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_Reserves_Score_Reserves" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlRLCM_Reserves_Score_Reserves"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Reserves Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlLeadership" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <td colspan="100%">Claim Review Worksheet – Management Section: <i>Leadership </i>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 15%" align="left">Claim Number</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblClaimNumber_Leadership" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Associate Name</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblAssociateName_Leadership" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Job Title</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left">
                                                                <asp:Label ID="lblJobTitle_Leadership" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 13%" align="left">Date of Injury</td>
                                                            <td style="width: 4%" align="center">: </td>
                                                            <td style="width: 33%" align="left">
                                                                <asp:Label ID="lblInjuryDate_Leadership" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 15%" align="left">Sedgwick Field Office</td>
                                                            <td style="width: 2%" align="center">: </td>
                                                            <td style="width: 35%" align="left" colspan="4">
                                                                <asp:Label ID="lblSedgWickOffice_Leadership" runat="server"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" class="Spacer"></td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                <th colspan="100%">
                                                    <asp:HiddenField ID="hdnMgtSection_Leadership" runat="server" Value="Leadership" />
                                                    <asp:Label ID="lblMgtSection_Leadership" runat="server" Text="Leadership"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM Comments
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_Child_Leadership" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_LU_Sedgwick_Evaluation" SkinID="none">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Evaluation" DataField="Evaluation" ItemStyle-Width="40%"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" />
                                                            <asp:TemplateField HeaderText="RLCM Comments">
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_RLCM_Comments" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_RLCM_Comments") %>'></asp:HiddenField>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRLCM_Comments" Width="470" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Comments") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note Date</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                          <asp:Label ID="lblLeadAdjusterDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                             <tr>
                                                <td width="5%"></td>
                                                <td>
                                                <table>
                                                    <tr>
                                                         <td style="width: 7%" align="left" valign="top">Claim Adjuster Note</td>
                                                         <td style="width: 2%" align="center" valign="top">: </td>
                                                         <td style="width: 35%" align="left" valign="top">
                                                         <uc:ctrlMultiLineTextBox runat="server" ID="lblLeadAdjusterNotes" ControlType="Label" />
                                                         <asp:Label id="hdnLeadAdjusterNotes" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <th width="95%" style="text-align: center;">RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td width="95%" valign="top">
                                                    <asp:GridView ID="gv_NestedChild_Leadership" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnRowDataBound="gv_NestedChild_OnRowDataBound" OnRowCommand="gv_NestedChild_RowCommand"
                                                        CellPadding="0" CellSpacing="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RLCM/Sedgwick" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnRLCM" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "RLCM_Sedgwick") %>' />
                                                                    <asp:HiddenField ID="hdnPK_Sedgwick_Claim_Action_Plan" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "PK_Sedgwick_Claim_Action_Plan") %>'></asp:HiddenField>
                                                                    <asp:DropDownList ID="ddlRLCM_Sedgwick" runat="server" Width="80px">
                                                                        <asp:ListItem Value="RLCM" Text="RLCM"></asp:ListItem>
                                                                        <asp:ListItem Value="Sedgwick" Text="Sedgwick"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action Item" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Left" Width="51%" />
                                                                <ItemTemplate>
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Completed Action Item (Y/N)?" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
                                                                    </cc1:CalendarExtender>--%>
                                                                    <asp:RadioButtonList ID="rdoCompleted" runat="server" SkinID="YNTypeNullSelection"></asp:RadioButtonList>
                                                                    <asp:HiddenField ID="hdnCompleted" runat="server" Value='<%#Eval("Completed") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                        CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Action_Plan") %>'
                                                                        OnClientClick="javascript:return confirm('Are you sure that you want to REMOVE the selected Action Plan row from the RLCM/Sedgwick Action Plan grid?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                <td width="5%" style="background-color: White;"></td>
                                                <td colspan="95%">
                                                    <asp:Label ID="lblMgtSectionasd_Leadership" runat="server" Text="Leadership Scoring"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <asp:GridView ID="gv_LeadershipScoring_Leadership" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        SkinID="none" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="text_shipped" Text="" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Scoring_Note" HeaderText="" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid black;">
                                                <td width="5%"></td>
                                                <td colspan="95%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblMgtSectiondrp_Leadership" runat="server" Text="RLCM Leadership Score"></asp:Label>&nbsp;<span id="Span68" style="color: Red; display: none" runat="server">*</span>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlRLCM_Leadership_Score_Leadership" runat="server" Style="width: 100px;">
                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlRLCM_Leadership_Score_Leadership"
                                                                Display="None" ValidationGroup="vsWCClaimGroup" InitialValue="" ErrorMessage="Please select RLCM Leadership Score"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlScoring" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" width="99%" align="center">
                                            <!--<tr><td width="100%" class="Spacer" style="height: 20px;"></td></tr>-->
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                    <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                                        <td colspan="100%">Claim Review Worksheet – Review Scorecard
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">&nbsp; </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <%--<td valign="top" align="right"></td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="1px" width="100%">
                                                        <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                            <td width="40%" valign="top">Sedgwick Field Office </td>
                                                            <td width="30%" valign="top">Year </td>
                                                            <td width="30%" valign="top">Quarter </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="40%" valign="top">
                                                                <asp:Label ID="lblSedgwickOffice" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="30%" valign="top">
                                                                <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="30%" valign="top">
                                                                <asp:Label ID="lblQuarter" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellspacing="2" cellpadding="4" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%" align="left">Claim </td>
                                                                <td style="width: 4%" align="center">: </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblScoreClaimNumber" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Numeric Score </td>
                                                                <td align="center">: </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblNumericScore" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" style="font-weight: bold;">Claim Review Group</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Average Numeric Score</td>
                                                                <td align="center">: </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblavgNumericScore" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Scoring Classification </td>
                                                                <td align="center">: </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblSCR_SCoreClassification" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" style="font-weight: bold;">Sedgwick Field Office Annual</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Total of Average Numeric Scores</td>
                                                                <td align="center">: </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblTotalAvgScore" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Scoring Classification </td>
                                                                <td align="center">: </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblTotalScoringClassifcatn" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <table width="100%">
                                                                        <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                                            <td style="width: 100%;" colspan="3">
                                                                                <asp:Label ID="lblDisposition" runat="server" Text="Disposition"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc" style="width: 20%;">Claim Review Complete?&nbsp;<span id="Span2" style="color: Red; display: none" runat="server">*</span> </td>
                                                                            <td class="lc" style="width: 2%;">: </td>
                                                                            <td class="ic" style="width: 78%;">
                                                                                <asp:RadioButtonList ID="rblDisposition" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                                    <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="100%">&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">RLCM Comments&nbsp;<span id="Span1" style="color: Red; display: none" runat="server">*</span></td>
                                                                <td align="center" valign="top">: </td>
                                                                <td align="left" valign="top">
                                                                    <uc:ctrlMultiLineTextBoxWithSpellCheck ID="txtOverallComments" runat="server" MaxLength="3940" IsRequired="true" ValidationGroup="vsWCClaimGroup" RequiredFieldMessage="Please enter RLCM Comments" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Broker Claim Comments</td>
                                                                <td align="center" valign="top">: </td>
                                                                <td align="left" valign="top">
                                                                    <uc:ctrlMultiLineTextBoxWithSpellCheck ID="txtBrokerClaimComments" runat="server" MaxLength="3940" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px" class="Spacer" colspan="6"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAttachments" runat="server" Width="100%">
                                        <div id="dvAttachment" runat="server">
                                            <table cellpadding="0" cellspacing="0" width="100%" style="height: 230px;">
                                                <tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; padding: 2px;">
                                                    <td colspan="100%">Claim Review Worksheet – Attachments</td>
                                                </tr>
                                                <tr>
                                                    <td width="100%">
                                                        <uc:ctrlAttachment ID="Attachments" runat="Server" OnbtnHandler="btnAddAttachment_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 20px;"></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Width="794px">
                                            <table cellpadding="0" cellspacing="0" width="100%" style="height: 250px;">
                                                <tr>
                                                    <td width="100%" valign="top">
                                                        <uc:ctrlAttachmentDetail ID="AttachDetails" runat="Server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td width="5px">&nbsp; </td>
                            <td width="794px" align="center">
                                <div style="width: 100%;">
                                    <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnPreviousStep" ToolTip="Previous Step" runat="server" Text="Previous Step"
                                                    OnClientClick="return  onPreviousStep();" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" OnClientClick="return SetValidationGroup();" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnNextStep" runat="server" Text="Next Step" ToolTip="Next Step"
                                                    CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" />
                                                <asp:Button ID="btnSLTMembers_AuditEdit" runat="server" Text="View Audit Trail"
                                                    OnClientClick="javascript:return AuditPopUpMeeting();" />
                                                <asp:Button ID="btnReturn" runat="server" Text="Return" ToolTip="Return" OnClick="btnReturn_Click" />
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
    </div>
    <div>
        <asp:ValidationSummary ID="vsClaimReview" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorClaimReview" CssClass="errormessage"></asp:ValidationSummary>

    </div>

    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:CustomValidator ID="CustomValidatorClaimReview" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorClaimReview" />
    <input id="hdnControlIDsClaimReview" runat="server" type="hidden" />
    <input id="hdnErrorMsgsClaimReview" runat="server" type="hidden" />



    <script language="javascript" type="text/javascript">

        function SetValidationGroup() {

            //var Index = document.getElementById('<%= hdnPanel.ClientID%>').value;
            var ValidationGroups;
            ValidationGroups = "vsErrorClaimReview";

            if (ValidationGroups != "") {
                if (Page_ClientValidate(ValidationGroups)) {
                    return true;
                }
                else {
                    Page_ClientValidate('dummy');
                    return false;
                }
            }
            return true;
        }


        function ValidateFields(sender, args) {

            var validatorID = sender.id;
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            if (validatorID.indexOf('ClaimReview') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsClaimReview.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsClaimReview.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsClaimReview.ClientID%>').value.split(',');
            }



            var focusCtrlID = "";
            args.IsValid = false;

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
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
                        if (ctrlIDs[i] != null) {
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
                    if (msg.length > 0) {
                        sender.errormessage = msg;
                        args.IsValid = false;
                    }
                    else
                        args.IsValid = true;
                }
                else
                    args.IsValid = true;
            }
        }

    </script>
</asp:Content>
