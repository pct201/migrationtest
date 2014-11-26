<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
	CodeFile="ClaimSummary_OLD.aspx.cs" Inherits="SONIC_Sedgwick_ClaimSummary" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBoxWithSpellCheck"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
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
			if (ActiveTabIndex == 3) {
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
				document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
			}
			if (index == 2) {
				document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
				document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "block";
				document.getElementById("<%=pnlScoring.ClientID%>").style.display = "none";
			}
			if (index == 3) {
				document.getElementById("<%=pnlClaimSummary.ClientID%>").style.display = "none";
				document.getElementById("<%=pnlClaimReviewWorksheet.ClientID%>").style.display = "none";
				document.getElementById("<%=pnlScoring.ClientID%>").style.display = "block";
			}
		}

		function SetMenuStyle(index) {
			var i;
			for (i = 1; i <= 3; i++) {
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
				if (hdnIsSave.value == "false") {
					if (confirm('This Claim Review Worksheet has not been saved, would you like to save it before returning to the Claim Review Worksheet Group?')) {
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
	</script>
	<div>
		<asp:ValidationSummary ID="valWCClaim" runat="server" ShowSummary="false" ShowMessageBox="true"
			HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray"
			ValidationGroup="vsWCClaimGroup" CssClass="errormessage"></asp:ValidationSummary>
	</div>
	<div style="width: 100%;">
		<table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
			text-align: left;">
			<tr>
				<td>&nbsp;</td>
			</tr>
			<%--<tr>
				<td colspan="2">
					<table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
						font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
						<tr>
							<td class="ghc">Claim Review Worksheet – Claim Summary
								<asp:Label ID="lblPolicyDetailsId" runat="server" Height="0px" Width="0px" Visible="false"></asp:Label>
							</td>
						</tr>
					</table>
				</td>
			</tr>--%>
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
											Review</span>&nbsp; </td>
									</tr>
									<tr>
										<td><span id="WCMenu3" href="#" onclick="javascript:CheckValueChange(3,null);">Review
											Scorecard</span>&nbsp; </td>
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
						<tr>
							<td>
								<asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
									<ProgressTemplate>
										<div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
											<table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
												height: 100%;">
												<tr align="center" valign="middle">
													<td class="LoadingText" align="center" valign="middle">
														<img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
													</td>
												</tr>
											</table>
										</div>
									</ProgressTemplate>
								</asp:UpdateProgress>
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
											<tr>
												<td class="lc" style="width: 23%;">FROI Number&nbsp;<span id="Span1" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" style="width: 2%;">: </td>
												<td class="ic" style="width: 25%;"><a id="lblFROINumber" runat="server"></a>
													<%--<asp:Label ID="lblFROINumber" runat="server"></asp:Label>--%>
												</td>
												<td class="lc" style="width: 23%;">Claim Number&nbsp;<span id="Span2" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" style="width: 2%;">: </td>
												<td class="ic" style="width: 25%;"><a id="ahrefClaimnumber" runat="server"></a>
													<%--<asp:Label ID="lblClaimNumber" runat="server"></asp:Label>--%>
												</td>
											</tr>
											<tr>
												<td class="lc" style="width: 23%;">Investigation Id&nbsp;<span id="Span25" style="color: Red;
													display: none;" runat="server">*</span> </td>
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
												<td class="lc">Location Number&nbsp;<span id="Span3" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtLocationNumber" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Location d/b/a&nbsp;<span id="Span4" style="color: Red; display: none;"
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
												<td class="lc">Name&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
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
												<td class="lc">Date of Birth&nbsp;<span id="Span7" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDtOfBirth" runat="server" SkinID="txtDate" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Age&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
												</td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtAge" runat="server" SkinID="txtDate" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc">Date of Hire&nbsp;<span id="Span9" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateOfHire" runat="server" onkeypress="return numberOnly(event);"
														MaxLength="4" Enabled="false"></asp:TextBox>
													<asp:RegularExpressionValidator ID="revPolYear" runat="server" ControlToValidate="txtDateOfHire"
														Display="none" SetFocusOnError="true" ErrorMessage="Policy Year is Invalid."
														ValidationExpression="[\d]{4}" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
												</td>
												<td class="lc">Job Title&nbsp;<span id="Span10" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtJobTitle" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc">Employment Status&nbsp;<span id="Span11" style="color: Red; display: none;"
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
												<td class="lc">Date of Incident&nbsp;<span id="Span13" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateOfIncident" SkinID="txtAmt" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Time of Incident&nbsp;<span id="Span14" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtTimeOfIncident" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc">Filing State&nbsp;<span id="Span15" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtFillingState" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Reported to Sonic&nbsp;<span id="Span16" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateReportedToSonic" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Description of Incident&nbsp;<span id="Span17" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic" colspan="4">
													<uc:ctrlMultiLineTextBox runat="server" ID="txtDescOfIncident" ControlType="TextBox" />
												</td>
											</tr>
											<tr>
												<td class="lc">Department Where Injury Occurred&nbsp;<span id="Span19" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDeptWhereInjuryOccured" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Nature of Injury&nbsp;<span id="Span6" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtNatureOfInjury" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc">Body Part Affected&nbsp;<span id="Span20" style="color: Red; display: none;"
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
												<td class="lc">Was the Claim Questionable&nbsp;<span id="Span22" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:RadioButtonList ID="rdbClaimQuestionable" runat="server" Enabled="false">
														<asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
														<asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
													</asp:RadioButtonList>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">If Yes, Why?&nbsp;<span id="Span23" style="color: Red;
													display: none;" runat="server">*</span> </td>
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
												<td class="lc">Was Telephone Nurse Consultation Used?&nbsp;<span id="Span12" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:RadioButtonList ID="rdbTelConsultnUsed" runat="server" Enabled="false">
														<asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
														<asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
													</asp:RadioButtonList>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Describe Initial Treatment&nbsp;<span id="Span18" style="color: Red;
													display: none;" runat="server">*</span> </td>
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
												<td class="lc" valign="top">Initial Claim Classification&nbsp;<span id="Span21" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic" colspan="4">
													<asp:TextBox ID="txtInitialClaimClassifictn" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Comments/Special Instructions to Adjuster&nbsp;<span
													id="Span24" style="color: Red; display: none;" runat="server">*</span> </td>
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
												<td class="lc" style="width: 23%;">Sonic Cause Code&nbsp;<span id="Span26" style="color: Red;
													display: none;" runat="server">*</span> </td>
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
												<td class="lc" valign="top">Effective Date&nbsp;<span id="Span27" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic" colspan="4">
													<asp:TextBox ID="txtEffectiveDate" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Work Status Type&nbsp;<span id="Span28" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtWorkStatusType" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Authorized off work?&nbsp;<span id="Span29" style="color: Red; display: none;"
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
												<td class="lc" valign="top">Date Last Worked&nbsp;<span id="Span30" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateLastWorked" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Last Worked Aas a Full Day?&nbsp;<span id="Span31" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateLastWorkedAsFullDay" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Date Examiner Anticipates Return to Work Full Duty&nbsp;<span
													id="Span32" style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateExaminerReturnToWorkFullDay" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Examiner Anticipates Return to Work Restrictive Duty&nbsp;<span
													id="Span33" style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateExaminerReturnToWorkResDuty" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Date Case Manager Anticipates Return to Work Full Duty&nbsp;<span
													id="Span34" style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateCaseMngrToFullDay" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Case Manager Anticipates Return to Work Restrictive Duty&nbsp;<span
													id="Span35" style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateCaseMgrToResDuty" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Date Physician Anticipates Return to Work Full Duty&nbsp;<span
													id="Span36" style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDatePhysicianAnticipateToFullDay" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Physician Anticipates Return to Work Restrictive Duty&nbsp;<span
													id="Span37" style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDatePhysicianAnticipateToResDuty" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Moderate Duty Available?&nbsp;<span id="Span38" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:RadioButtonList ID="rdbModerateDutyAvail" runat="server" Enabled="false">
														<asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
														<asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
													</asp:RadioButtonList>
												</td>
												<td class="lc">Date Modified Duty Available&nbsp;<span id="Span39" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateModifiedDutyAvail" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Moderate Duty Offered?&nbsp;<span id="Span40" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtModerateDutyOffered" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Moderate Duty Offered&nbsp;<span id="Span41" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateModerateDutyOffered" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Moderate Duty Accepted?&nbsp;<span id="Span42" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtModerateDutyAccepted" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Date Moderate Duty Accepted&nbsp;<span id="Span43" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtDateModerateDutyACcepted" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Modified Duty Occupation&nbsp;<span id="Span44" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtModifiedDutyOccupation" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Modified Duty Demand&nbsp;<span id="Span45" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtModifiedDutyDemand" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Date Notified&nbsp;<span id="Span46" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic" colspan="4">
													<asp:TextBox ID="txtDateNotified" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Full Days Worked on Modified Duty?&nbsp;<span id="Span47"
													style="color: Red; display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">&nbsp; </td>
												<td class="lc">Hours Worked on Modified Duty&nbsp;<span id="Span48" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtHoursWorkedonModifiedDuty" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Return to Work Occupation&nbsp;<span id="Span49" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtReturnToWorkOccup" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Return to Work Demand&nbsp;<span id="Span50" style="color: Red; display: none;"
													runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtReturnToWorkDemand" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Return to Work Schedule&nbsp;<span id="Span51" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic" colspan="4">
													<asp:TextBox ID="txtReturnToWorkSchedule" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Date Disability Began&nbsp;<span id="Span52" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic" colspan="4">
													<asp:TextBox ID="txtDateDisabilityBegan" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Number of Lost Time Days&nbsp;<span id="Span53" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc" valign="top">: </td>
												<td class="ic">
													<asp:TextBox ID="txtNumberOfLostTimeDays" runat="server" Enabled="false"></asp:TextBox>
												</td>
												<td class="lc">Number of Restricted Work Days&nbsp;<span id="Span54" style="color: Red;
													display: none;" runat="server">*</span> </td>
												<td class="lc">: </td>
												<td class="ic">
													<asp:TextBox ID="txtNoOfRestWorkDays" runat="server" Enabled="false"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="lc" valign="top">Reason for Termination&nbsp;<span id="Span55" style="color: Red;
													display: none;" runat="server">*</span> </td>
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
															<td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Indemnity </td>
															<td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Medical </td>
															<td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Expenses </td>
															<td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Total </td>
														</tr>
														<tr>
															<td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Reserve </td>
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
															<td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Paid </td>
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
															<td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																font-size: 10pt;">Outstanding </td>
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
												Claim Review Worksheet – Claim Review
												<br />
												<table>
													<tr>
														<td class="lc" valign="top">Claim Number&nbsp; </td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:Label ID="lblCalimNUmber_Review" runat="server"></asp:Label>
														</td>
														<td class="lc">Associate Name&nbsp;<span id="Span57" style="color: Red; display: none;"
															runat="server">*</span> </td>
														<td class="lc">: </td>
														<td class="ic">
															<asp:TextBox ID="txtAssociateName" runat="server" Enabled="false"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc" valign="top">Location d/b/a&nbsp; </td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:TextBox ID="txtLocationDBA_Review" runat="server" Enabled="false"></asp:TextBox>
														</td>
														<td class="lc">Date of Injury&nbsp; </td>
														<td class="lc">: </td>
														<td class="ic">
															<asp:TextBox ID="txtDateOfInjury" runat="server" Enabled="false"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc" valign="top">Job Title&nbsp; </td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:TextBox ID="txtJobTitle_Review" runat="server" Enabled="false"></asp:TextBox>
														</td>
														<td class="lc" valign="top">Date of Last Review&nbsp; </td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:TextBox ID="txtDateOfLastReview" runat="server" SkinID="txtDate"></asp:TextBox>
															<cc1:CalendarExtender ID="calDateOfLastReview" runat="server" Format="MM/dd/yyyy"
																TargetControlID="txtDateOfLastReview">
															</cc1:CalendarExtender>
														</td>
													</tr>
													<tr>
														<td class="lc" valign="top">Sedgwick Field Office&nbsp; </td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:TextBox ID="txtSedgwickFieldOffice" runat="server" Enabled="false"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc" valign="top">Adjuster&nbsp;<span id="Span62" style="color: Red;" runat="server">*</span>
														</td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:TextBox ID="txtAdjuster" runat="server" MaxLength="100"></asp:TextBox>
															<asp:RequiredFieldValidator ID="rfvtxtAdjuster" runat="server" ControlToValidate="txtAdjuster"
																Display="None" ValidationGroup="vsWCClaimGroup" ErrorMessage="Please enter Adjuster"></asp:RequiredFieldValidator>
														</td>
														<td class="lc">Sedgwick Team Leader&nbsp;<span id="Span63" style="color: Red;" runat="server">*</span>
														</td>
														<td class="lc">: </td>
														<td class="ic">
															<asp:TextBox ID="txtSedgwickTeamLeader" runat="server" MaxLength="100"></asp:TextBox>
															<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSedgwickTeamLeader"
																Display="None" ValidationGroup="vsWCClaimGroup" ErrorMessage="Please enter Sedgwick Team Leader"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td class="lc" valign="top">Date of File Review&nbsp;<span id="Span64" style="color: Red;"
															runat="server">*</span> </td>
														<td class="lc" valign="top">: </td>
														<td class="ic">
															<asp:TextBox ID="txtDateOfFileReview" runat="server" SkinID="txtDate"></asp:TextBox>
															<cc1:CalendarExtender ID="calDateOfFileReview" runat="server" Format="MM/dd/yyyy"
																TargetControlID="txtDateOfFileReview">
															</cc1:CalendarExtender>
															<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateOfFileReview"
																Display="None" ValidationGroup="vsWCClaimGroup" ErrorMessage="Please enter Date of File Review"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td colspan="6">&nbsp;</td>
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
																	<td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Indemnity </td>
																	<td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Medical </td>
																	<td class="lc" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Expenses </td>
																	<td class="ic" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Total </td>
																</tr>
																<tr>
																	<td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Reserve </td>
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
																	<td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Paid </td>
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
																	<td class="lc" valign="top" style="text-align: left; background-color: #7f7f7f; font-family: Tahoma;
																		font-size: 10pt;">Outstanding </td>
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
												</table>
												<div id="divClaimReviewWorksheet" style="width: 100%; border: solid 1px #000000;">
													<asp:GridView ID="gvMgtSection" runat="server" AutoGenerateColumns="false" ShowFooter="true"
														Width="100%" OnRowDataBound="gvMgtSection_OnRowDataBound" OnRowCommand="gvMgtSection_RowCommand"
														SkinID="none" CellPadding="0" CellSpacing="0">
														<Columns>
															<asp:TemplateField ShowHeader="false">
																<ItemTemplate>
																	<table width="100%">
																		<tr style="background-color: #06537c; font-family: Tahoma; color: white; font-size: 10pt;
																			font-weight: bold; padding: 2px;">
																			<th colspan="100%">
																				<asp:HiddenField ID="hdnMgtSection" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Management_Section") %>' />
																				<asp:Label ID="lblMgtSection" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Management_Section_Header") %>'></asp:Label>
																			</th>
																		</tr>
																		<tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt;
																			font-weight: bold;">
																			<td width="5%" style="background-color:White;"></td>
																			<th width="95%" style="text-align: center;">
																				RLCM Comments
																			</th>
																		</tr>
																		<tr>
																			<td width="5%"></td>
																			<td width="95%" valign="top">
																				<asp:GridView ID="gv_Child" runat="server" Width="100%" AutoGenerateColumns="false"
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
																		<tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt;
																			font-weight: bold;">
																			<td width="5%" style="background-color:White;"></td>
																			<th width="95%" style="text-align: center;">
																				RLCM/Sedgwick Action Plan &nbsp;&nbsp; &nbsp;
																				<%--<asp:LinkButton runat="server" ID="lnkAddRow" CommandName="AddNewRow" CommandArgument='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Management_Section") %>'>
                                                                        --Add--
																				</asp:LinkButton>--%>
																			</th>
																		</tr>
																		<tr>
																			<td width="5%"></td>
																			<td width="95%" valign="top">
																				<asp:GridView ID="gv_NestedChild" runat="server" Width="100%" AutoGenerateColumns="false"
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
																								<%--<a href="#" runat="server" onclick=<%# "javascript:OpenActionItemPopup('" + Eval("PK_Sedgwick_Claim_Action_Plan") + "')"%>>
																									<img id="imgPlus" runat="server" alt="" src="../../Images/plus.jpg" style="cursor: pointer;" />
																								</a>--%>
																								<%--<asp:image id="imgPlus" runat="server" alt="" src="../../Images/plus.jpg" style="cursor: pointer;" />
																								<asp:TextBox ID="txtActionItem" runat="server" MaxLength="500" TextMode="MultiLine"
																									Rows="2" Columns="8" Width="100px" Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>'></asp:TextBox>--%>
																								<uc:ctrlMultiLineTextBox runat="server" ID="txtActionItem" Width="400" ControlType="TextBox"
																									Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Action_Item") %>' />
																							</ItemTemplate>
																						</asp:TemplateField>
																						<%--<asp:BoundField DataField="Action_Item" HeaderText="Action Item" />--%>
																						<asp:TemplateField HeaderText="Target Date" HeaderStyle-HorizontalAlign="Center">
																							<ItemStyle HorizontalAlign="Center" Width="12%" />
																							<ItemTemplate>
																								<asp:TextBox ID="txtTargetDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
																									Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Target_Date"))%>'></asp:TextBox>
																								<cc1:CalendarExtender ID="calTargetDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDate">
																								</cc1:CalendarExtender>
																							</ItemTemplate>
																						</asp:TemplateField>
																						<asp:TemplateField HeaderText="Actual Date" HeaderStyle-HorizontalAlign="Center">
																							<ItemStyle HorizontalAlign="Center" Width="12%" />
																							<ItemTemplate>
																								<asp:TextBox ID="txtActualDate" runat="server" MaxLength="10" SkinID="txtdate" Width="80px"
																									Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Actual_Date"))%>'></asp:TextBox>
																								<cc1:CalendarExtender ID="calActualDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtActualDate">
																								</cc1:CalendarExtender>
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
																		<tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt;
																			font-weight: bold;">
																			<td width="5%" style="background-color:White;"></td>
																			<td colspan="95%">
																				<asp:Label ID="lblMgtSectionasd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Management_Section_Scoring") %>'></asp:Label>
																			</td>
																		</tr>
																		<tr>
																			<td width="5%"></td>
																			<td colspan="95%">
																				<asp:GridView ID="gv_MedicalScoring" runat="server" Width="100%" AutoGenerateColumns="false"
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
																							<asp:Label ID="lblMgtSectiondrp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,
                                                                    "Mgt_Section_RLCM_Scoring") %>'></asp:Label>
																						</td>
																						<td style="text-align: left;">
																							<asp:DropDownList ID="ddlRLCM_Medical_Score" runat="server" Style="width: 100px;">
																								<asp:ListItem Value="0" Text="Select"></asp:ListItem>
																								<asp:ListItem Value="1" Text="1"></asp:ListItem>
																								<asp:ListItem Value="0" Text="0"></asp:ListItem>
																							</asp:DropDownList>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</table>
																</ItemTemplate>
															</asp:TemplateField>
														</Columns>
													</asp:GridView>
													<table width="100%">
														<tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt;
															font-weight: bold;">
															<td style="width: 100%;" colspan="3">
																<asp:Label ID="lblDisposition" runat="server" Text="Disposition"></asp:Label>
															</td>
														</tr>
														<tr>
															<td class="lc" style="width: 20%;">Claim Review Complete?&nbsp; </td>
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
												</div>
											</ContentTemplate>
										</asp:UpdatePanel>
									</asp:Panel>
									<asp:Panel ID="pnlScoring" runat="server" Width="100%">
										<table cellpadding="0" cellspacing="0" width="99%" align="center">
											<tr>
												<td width="100%" class="Spacer" style="height: 20px;"></td>
											</tr>
											<tr>
												<td align="left">
													<table cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td width="45%">
																<table cellpadding="0" cellspacing="0" border="0" width="100%">
																	<tr>
																		<td align="left"><span class="heading">Claim Review Worksheet – Review Scorecard</span>
																		</td>
																	</tr>
																	<tr>
																		<td align="left">&nbsp; </td>
																	</tr>
																</table>
															</td>
															<td valign="top" align="right"></td>
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
														<tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt;
															font-weight: bold;">
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
																<td align="left" valign="top">Overall Comments</td>
																<td align="center" valign="top">: </td>
																<td align="left" valign="top">
																	<%--<uc:ctrlMultiLineTextBox runat="server" ID="txtOverallComments" ControlType="TextBox" />--%>
                                                                    <uc:ctrlMultiLineTextBoxWithSpellCheck ID="txtOverallComments" runat="server" MaxLength="3940" TabIndex="2" />
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
												<asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" ValidationGroup="vsWCClaimGroup"
													OnClick="btnSave_Click" />
												<asp:Button ID="btnNextStep" runat="server" Text="Next Step" ToolTip="Next Step"
													CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" />
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
	<asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
</asp:Content>
