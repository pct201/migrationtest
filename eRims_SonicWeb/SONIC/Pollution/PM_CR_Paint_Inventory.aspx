<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PM_CR_Paint_Inventory.aspx.cs" Inherits="SONIC_Pollution_PM_CR_Paint_Inventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo" TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
 <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
 <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
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
        var op = '<%=StrOperation%>';
        if (op == "view") {
            ShowPanelView(index);
        }
        else {
            var i;
            for (i = 1; i <= 1; i++) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
            }
            document.getElementById('<%=txtSupplier.ClientID%>').focus();
        }
    }

    function ShowPanelView(index) {
        SetMenuStyle(index);
        document.getElementById('<%=dvView.ClientID%>').style.display = "block";
        var i;
        for (i = 1; i <= 1; i++) {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = (i == index) ? "block" : "none";
        }
    }

    function ValSave() {
        if (Page_ClientValidate())
            return true;
        else
            return false;
    }
    function OpenAuditPopUp() {
        var winHeight = window.screen.availHeight - 400;
        var winWidth = window.screen.availWidth - 500;

        obj = window.open('AuditPopup_PM_PI_Inventory.aspx?id=<%=ViewState["PK_PM_CR_PI_Inventory"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
            <td width="100%" style="height: 50px;" valign="bottom" >
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
		<tr><td class="ghc" align="left">Compliance Reporting - Paint Inventory</td></tr>
		<tr>
			<td>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="Spacer" style="height: 15px;" colspan=2></td></tr>
					<tr>
						<td class="leftMenu">
							<table cellpadding="5" cellspacing="0" width="100%">
								<tr><td style="height: 18px;" class="Spacer"></td></tr>
								<tr>
									<td align="left" width="100%">
										<span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Paint Inventory</span>&nbsp;<span
                                           id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span></td>
								</tr>
							</table>
						</td>
						<td valign="top">
							<table cellpadding="0" cellspacing="0" border="0" width="100%">
								<tr>
									<td width="5px" class="Spacer">&nbsp;</td>
									<td class="dvContainer">
										<div id="dvEdit" runat="server" width="794px">
											<asp:Panel ID="pnl1" runat="server" Style="display: none;">
												<div class="bandHeaderRow">Paint Inventory</div>
												<table cellpadding="3" cellspacing="1" border="0" width="100%">
													<tr>
														<td align="left" width="18%" valign="top">Supplier&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top">
														<asp:TextBox ID="txtSupplier" runat="server" Width="170px" MaxLength="75" />
															
														</td>
														<td align="left" width="18%" valign="top">Date Purchased&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top">
														<asp:TextBox ID="txtDate_Purchased" runat="server" Width="150px" SkinID="txtDate" />
														<img alt="Date Purchased" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Purchased', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" />
														<asp:RegularExpressionValidator ID="revDate_Purchased" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Compliance Reporting]/Date Purchased is not a valid date" SetFocusOnError="true" ControlToValidate="txtDate_Purchased" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
															
														</td>
													</tr>
													<tr>
														<td align="left"  valign="top">Amount Purchased&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top">
														<asp:TextBox ID="txtAmount_Purchased" runat="server" Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false"/>
															
														</td>
														<td align="left"  valign="top">Units&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:DropDownList ID="drpFK_LU_Units" Width="175px" runat="server" SkinID="dropGen"></asp:DropDownList>
															
														</td>
													</tr>
													<tr>
														<td align="left"  valign="top">Start Date&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top">
														<asp:TextBox ID="txtStart_Date" runat="server" Width="150px" SkinID="txtDate" />
														<img alt="Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStart_Date', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" />
														<asp:RegularExpressionValidator ID="revStart_Date" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Compliance Reporting]/Start Date is not a valid date" SetFocusOnError="true" ControlToValidate="txtStart_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
														</td>
														<td align="left"  valign="top">End Date&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top">
														<asp:TextBox ID="txtEnd_Date" runat="server" Width="150px" SkinID="txtDate" />
														<img alt="End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEnd_Date', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" />
														<asp:RegularExpressionValidator ID="revEnd_Date" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Compliance Reporting]/End Date is not a valid date" SetFocusOnError="true" ControlToValidate="txtEnd_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>

                                                        <asp:CompareValidator ID="cvEnd_Date" runat="server" ErrorMessage="[Compliance Reporting]/End Date must be greater than or equal to [Compliance Reporting]/Start Date" ControlToValidate="txtEnd_Date" 
                                                            ControlToCompare="txtStart_Date" Type="Date" Operator="GreaterThanEqual" ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true" />
														</td>
													</tr>
													<tr>
														<td align="left"  valign="top">Amount Used&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top">
														<asp:TextBox ID="txtAmount_Used" runat="server" Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false"/>
														</td>
														<td align="left"  valign="top">Ending Inventory&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top">
														<asp:TextBox ID="txtEnding_Inventory" runat="server" Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false"/>
														</td>
													</tr>
												</table>
											</asp:Panel>
										</div>
										<div id="dvView" runat="server" width="794px">
											<asp:Panel ID="pnl1View" runat="server" Style="display: none;">
												<div class="bandHeaderRow">Paint Inventory</div>
												<table cellpadding="3" cellspacing="1" border="0" width="100%">
													<tr>
														<td align="left" width="18%" valign="top">Supplier</td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top"><asp:Label ID="lblSupplier" runat="server"></asp:Label>
														</td>
														<td align="left" width="18%" valign="top">Date Purchased</td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top"><asp:Label ID="lblDate_Purchased" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td align="left"  valign="top">Amount Purchased</td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:Label ID="lblAmount_Purchased" runat="server"></asp:Label>
														</td>
														<td align="left"  valign="top">Units</td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:Label ID="lblFK_LU_Units" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td align="left"  valign="top">Start Date</td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:Label ID="lblStart_Date" runat="server"></asp:Label>
														</td>
														<td align="left"  valign="top">End Date</td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:Label ID="lblEnd_Date" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td align="left"  valign="top">Amount Used</td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:Label ID="lblAmount_Used" runat="server"></asp:Label>
														</td>
														<td align="left"  valign="top">Ending Inventory</td>
														<td align="center"  valign="top">:</td>
														<td align="left"  valign="top"><asp:Label ID="lblEnding_Inventory" runat="server"></asp:Label>
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
						<td>&nbsp;</td>
						<td align="center">
							<div id="dvSave" runat="server">
								<table cellpadding="5" cellspacing="0" border="0" width="100%">
									<tr>
										<td width="60%" align="right">
												<asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                                        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                                        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
												<asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();"  />
                                                 <asp:Button ID="btnEdit" runat="server" Visible="false" Text="  Edit  " OnClick="btnEdit_Click" />
                                                 <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                                <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" />
											</td>
											<td align="left">&nbsp;</td>
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

