<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ClaimReviewWorkSheetGroupSearch.aspx.cs"
	Inherits="SONIC_Sedgwick_ClaimReviewWorkSheetGroupSearch" %>

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
	<script type="text/javascript">
	    function ConfirmRedirectToClaimSearch(LU_Sedgwick_Field_Office, Year, Quarter,isViewOnly)
	    {	        
	        if (isViewOnly == true)
	        {
	            alert("No Claim Review Worksheets exist for Sedgwick Claim Office = " + LU_Sedgwick_Field_Office + ", Year = " + Year + " and Quarter = " + Quarter + ".");
	        }
	        else
	        {
	            if (confirm("No Claim Review Worksheets exist for Sedgwick Claim Office = " + LU_Sedgwick_Field_Office + ", Year = " + Year + " and Quarter = " + Quarter + ", would you like to initiate a Claim Review Worksheet Group for that criteria?"))
	            {
	                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Sedgwick/ClaimSearch.aspx';
                }
	            else return false;
            }
		}
	</script>
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
									<td colspan="2"> <span class="heading">Claim Review Worksheet Group Search</span> </td>
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
													<td style="width: 16%" align="left">Sedgwick Claim Office <span class="mf">*</span></td>
													<td style="width: 4%" align="center">: </td>
													<td style="width: 32%" align="left">
														<asp:DropDownList ID="ddlSedgwickClaimOffice" runat="server" SkinID="ddlExposure">
														</asp:DropDownList>
														<asp:RequiredFieldValidator ID="rfvdrpOffice" runat="server" ControlToValidate="ddlSedgwickClaimOffice"
															InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select office"></asp:RequiredFieldValidator>
													</td>
													<td style="width: 18%" align="left"></td>
													<td style="width: 4%" align="center"></td>
													<td style="width: 26%" align="left"></td>
												</tr>
												<tr>
													<td align="left" style="font-weight:bold">Claim Review Period </td>
													<td align="center"></td>
													<td align="left"></td>
													<td></td>
													<td align="center"></td>
													<td align="left"></td>
												</tr>
												<tr>
													<td align="left">Year <span class="mf">*</span></td>
													<td align="center">: </td>
													<td align="left">
														<asp:DropDownList ID="ddlYear" runat="server" SkinID="ddlExposure">
														</asp:DropDownList>
														<asp:RequiredFieldValidator ID="rfvdrpYear" runat="server" ControlToValidate="ddlYear"
															InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Year"></asp:RequiredFieldValidator>
													</td>
													<td align="right">Quarter <span class="mf">*</span></td>
													<td align="center">: </td>
													<td align="left">
														<asp:DropDownList runat="Server" ID="ddlQuarter" SkinID="ddlExposure">
															<asp:ListItem Value="0" Text="-- Select --">
															</asp:ListItem>
															<asp:ListItem Value="1" Text="1">
															</asp:ListItem>
															<asp:ListItem Value="2" Text="2">
															</asp:ListItem>
															<asp:ListItem Value="3" Text="3">
															</asp:ListItem>
															<asp:ListItem Value="4" Text="4">
															</asp:ListItem>
														</asp:DropDownList>
															<asp:RequiredFieldValidator ID="rfvdrpQuarter" runat="server" ControlToValidate="ddlQuarter"
															InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Quarter"></asp:RequiredFieldValidator>
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
									<asp:Button ID="btnSearch" runat="server" Text="Search"
										CausesValidation="true" ToolTip="Search" OnClick="btnSearch_Click" ValidationGroup="vsSearch"></asp:Button>&nbsp;&nbsp;&nbsp;
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
