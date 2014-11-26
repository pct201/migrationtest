<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
	CodeFile="ClaimReviewWorkSheetGroupSearchGrid.aspx.cs" Inherits="SONIC_Sedgwick_ClaimReviewWorkSheetGroupSearchGrid" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
									<td align="left"><span class="heading">Claim Review Worksheet Group</span> </td>
								</tr>
								<tr>
									<td align="left">&nbsp;
										<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Claim Review
										Worksheet Group Found </td>
								</tr>
							</table>
						</td>
						<td valign="top" align="right">
							<uc:ctrlPaging ID="ctrlPageClaimInfo" runat="server" OnGetPage="GetPage" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="Spacer" style="height: 10px;"></td>
		</tr>
		<tr>
			<td class="groupHeaderBar">&nbsp; </td>
		</tr>
		<tr>
			<td class="Spacer" style="height: 20px;"></td>
		</tr>
		<tr>
			<td>
				<table cellpadding="0" cellspacing="0" border="0" width="100%">
					<tr>
						<td width="100%" colspan="7" valign="top">
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
							<%--<asp:GridView ID="gvClaimReviewGroupSearchGrid" runat="server" DataKeyNames="PK_Sedgwick_Claim_Group"
								AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnRowCreated="gvClaimReviewGroupSearchGrid_RowCreated"
								OnSorting="gvClaimReviewGroupSearchGrid_Sorting">
								<Columns>
									<asp:TemplateField HeaderText="Sedgwick Claim Office" SortExpression="Fld_Desc">
										<ItemStyle HorizontalAlign="Left" Width="20%" />
										<ItemTemplate>
											<%#Eval("Fld_Desc")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="State" SortExpression="FLD_state">
										<ItemStyle HorizontalAlign="Left" Width="20%" />
										<ItemTemplate>
											<%#Eval("FLD_state")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Region" SortExpression="Regions">
										<ItemStyle HorizontalAlign="Left" Width="20%" />
										<ItemTemplate>
											<%#Eval("Regions")%>
										</ItemTemplate>
									</asp:TemplateField>
									
								</Columns>
								<EmptyDataTemplate>
									<table cellpadding="4" cellspacing="0" width="100%">
										<tr>
											<td width="100%" align="center" style="border: 1px solid #cccccc;">
												<asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
											</td>
										</tr>
									</table>
								</EmptyDataTemplate>
							</asp:GridView>--%>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td width="100%" class="Spacer" style="height: 20px;"></td>
		</tr>
		<tr>
			<td align="center">
				<table cellpadding="0" cellspacing="0" border="0" width="100%">
					<tr>
						<td align="center">
							<asp:Button ID="btnSearch" runat="server" Text="Search Again" OnClick="btnSearch_Click"
								ToolTip="Search Again" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="Spacer" style="height: 20px;"></td>
		</tr>
	</table>
</asp:Content>
