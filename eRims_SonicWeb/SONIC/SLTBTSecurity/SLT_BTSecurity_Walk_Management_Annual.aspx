<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
	CodeFile="SLT_BTSecurity_Walk_Management_Annual.aspx.cs" Inherits="SONIC_SLT_BTSecurity_Walk_Management_Annual" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
					<asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSave">
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tbody>
								<tr>
									<td colspan="2"><span class="heading">SLT BT Security Walk Question Management - Annual</span>
									</td>
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
													<td style="width: 13%" align="left">Year</td>
													<td style="width: 4%" align="center">: </td>
													<td style="width: 35%" align="left">
														<asp:Label ID="lblYear" runat="server"></asp:Label>
													</td>
													<td style="width: 13%" align="left"></td>
													<td style="width: 4%" align="center"></td>
													<td style="width: 33%" align="left"></td>
												</tr>
												<tr>
													<td style="width: 15%" align="left">Focus Area <span class="mf">*</span></td>
													<td style="width: 4%" align="center">: </td>
													<td style="width: 32%" align="left" colspan="4">
														<asp:TextBox ID="txtFocusArea" runat="server" MaxLength="100"></asp:TextBox>
														<asp:RequiredFieldValidator ID="rfvdrpYear" runat="server" ControlToValidate="txtFocusArea"
															Display="None" ValidationGroup="vsSearch" ErrorMessage="Please enter Focus Area"></asp:RequiredFieldValidator>
													</td>
												</tr>
												<tr>
													<td align="left" valign="top">Question <span class="mf">*</span></td>
													<td align="center" valign="top">: </td>
													<td align="left" colspan="4">
														<uc:ctrlMultiLineTextBox ID="txtQuestion" runat="server" MaxLength="2000" IsRequired="true" RequiredFieldMessage="Please enter Question" ValidationGroup="vsSearch" />
													</td>
												</tr>
												<tr>
													<td align="left" valign="top">Guidance</td>
													<td align="center" valign="top">: </td>
													<td align="left" colspan="4">
														<uc:ctrlMultiLineTextBox ID="txtGuidance" runat="server" MaxLength="2000" />
													</td>
												</tr>
												<tr>
													<td align="left" valign="top">Reference</td>
													<td align="center" valign="top">: </td>
													<td align="left" colspan="4">
														<uc:ctrlMultiLineTextBox ID="txtReference" runat="server" MaxLength="2000" />
													</td>
												</tr>
												<tr>
													<td align="left">Active</td>
													<td align="center">: </td>
													<td align="left" colspan="4">
														<asp:RadioButtonList ID="rblActive" runat="server">
															<asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
															<asp:ListItem Text="No" Value="N"></asp:ListItem>
														</asp:RadioButtonList>
													</td>
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
									<asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" ToolTip="Save"
										OnClick="btnSave_Click" ValidationGroup="vsSearch"></asp:Button>&nbsp;&nbsp;&nbsp;
									<asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnCancel_Click">
									</asp:Button>&nbsp;&nbsp;&nbsp; </td>
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
