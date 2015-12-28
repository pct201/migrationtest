<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
	CodeFile="MonthlyQuestions.aspx.cs" Inherits="SONIC_SLT_BT_Security_Walk_MonthlyQuestions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
	<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
	<script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
	<div>
		<asp:ValidationSummary ID="vsSearchInvestigation" runat="server" HeaderText="Please verify following fields:"
			ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsSearch" />
	</div>
	<table cellspacing="0" cellpadding="0" width="100%">
		<tbody>
			<tr>
				<td class="groupHeaderBar" align="left">&nbsp; </td>
			</tr>
			<tr>
				<td style="height: 20px" class="Spacer"></td>
			</tr>
			<tr>
				<td>
					<asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tbody>
								<tr>
									<td colspan="2"><span class="heading">Monthly Questions</span> </td>
									<%--<td class="Spacer"></td>--%>
								</tr>
								<tr>
									<td colspan="2">&nbsp;</td>
								</tr>
								<tr>
									<td colspan="2">&nbsp;</td>
								</tr>
								<tr>
									<td style="width: 150px" class="Spacer"></td>
									<td>
										<table cellspacing="1" cellpadding="3" width="100%" border="0">
											<tbody>
												<tr>
													<td style="width: 15%" align="left">Select Year <span class="mf">*</span> </td>
													<td style="width: 4%" align="center">: </td>
													<td style="width: 32%" align="left">
														<asp:DropDownList ID="ddlYear" runat="server" SkinID="ddlExposure">
														</asp:DropDownList>
														<asp:RequiredFieldValidator ID="rfvdrpYear" runat="server" ControlToValidate="ddlYear"
															InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Year"></asp:RequiredFieldValidator>
													</td>
													<td style="width: 18%" align="left"></td>
													<td style="width: 4%" align="center"></td>
													<td style="width: 28%" align="left"></td>
												</tr>
												<tr>
													<td align="left">Select Month <span class="mf">*</span></td>
													<td align="center">: </td>
													<td align="left">
														<asp:DropDownList runat="Server" ID="ddlMonth" SkinID="ddlExposure">
														</asp:DropDownList>
														<asp:RequiredFieldValidator ID="rfvdrpQuarter" runat="server" ControlToValidate="ddlMonth"
															InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Quarter"></asp:RequiredFieldValidator>
													</td>
													<td align="right"></td>
													<td align="center"></td>
													<td align="left"></td>
												</tr>
												<tr>
													<td style="height: 20px" class="Spacer" colspan="6"></td>
												</tr>
											</tbody>
										</table>
									</td>
								</tr>
								<tr>
									<td align="center" colspan="2">&nbsp; </td>
								</tr>
							</tbody>
						</table>
					</asp:Panel>
				</td>
			</tr>
			<tr>
				<td>
					<table cellspacing="0" cellpadding="0" width="100%" border="0">
						<tbody>
							<tr>
								<td style="height: 24px" align="center">
									<asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" ToolTip="Search"
										OnClick="btnSearch_Click" ValidationGroup="vsSearch"></asp:Button>&nbsp;&nbsp;&nbsp;
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
			<tr>
				<td style="height: 20px" class="Spacer"></td>
			</tr>
		</tbody>
	</table>
</asp:Content>
